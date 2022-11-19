
using System;
using System.ComponentModel;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Security;
using System.Diagnostics;

using ExcelDataReader;
using Newtonsoft.Json;

namespace GlossDetectorGerflor
{
    public class ColorAdjustment
    {
        public ComboBox combo;
        public Dictionary<string, double[]> meanColor = new Dictionary<string, double[]>();
        public Dictionary<string, double[]> percentageColorsKM5 = new Dictionary<string, double[]>();
        public Dictionary<string, double[][]> predominanteColor = new Dictionary<string, double[][]>();
        public Dictionary<string, double[]> predominanteColorCoefPattern = new Dictionary<string, double[]>();

        private PictureBox pictureMeanColor;
        private PictureBox pictureDominantColor1;
        private PictureBox pictureDominantColor2;
        private PictureBox pictureDominantColor3;
        private PictureBox pictureDominantColor4;
        private PictureBox pictureDominantColor5;


        public double[][] colorMireRef = new  double[4][] { 
           new Double[3]{241,239,235},
           new Double[3]{186,186,184},
           new Double[3]{133,133,133},
           new Double[3]{25,26,27}};
        public ColorAdjustment(ComboBox combo, PictureBox pictureMeanColor, PictureBox pictureDominantColor1, PictureBox pictureDominantColor2, PictureBox pictureDominantColor3, PictureBox pictureDominantColor4, PictureBox pictureDominantColor5)
		{
            this.combo = combo;
            this.pictureMeanColor = pictureMeanColor;
            this.pictureDominantColor1 = pictureDominantColor1;
            this.pictureDominantColor2 = pictureDominantColor2;
            this.pictureDominantColor3 = pictureDominantColor3;
            this.pictureDominantColor4 = pictureDominantColor4;
            this.pictureDominantColor5 = pictureDominantColor5;
            initiateKMEANSExcel();
            fillListItemCombo();
            foreach (string key in predominanteColor.Keys)
            {
                predominanteColorCoefPattern.Add(key, coeffMireDominante(key));
            }
        }

        public ColorAdjustment(ColorDataStrorage cds, ComboBox combo, PictureBox pictureMeanColor, PictureBox pictureDominantColor1, PictureBox pictureDominantColor2, PictureBox pictureDominantColor3, PictureBox pictureDominantColor4, PictureBox pictureDominantColor5) {
            this.meanColor = cds.meanColor;
            this.percentageColorsKM5 = cds.percentageColorsKM5;
            this.predominanteColor = cds.predominanteColors;
            this.predominanteColorCoefPattern = cds.predominanteColorCoefPattern;
            this.combo = combo;
            this.pictureMeanColor = pictureMeanColor;
            this.pictureDominantColor1 = pictureDominantColor1;
            this.pictureDominantColor2 = pictureDominantColor2;
            this.pictureDominantColor3 = pictureDominantColor3;
            this.pictureDominantColor4 = pictureDominantColor4;
            this.pictureDominantColor5 = pictureDominantColor5;
            fillListItemCombo();
        }


        public double parseStringToDouble(string[] row,int column)
        {
            double res;
            try
            {
                res = Double.Parse(row[column], System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                res = 0;
            }


            return res;
        }

		void initiateKMEANSExcel()
		{

			string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\data\\excelData\\km5.xlsx";
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader reader;

                reader = ExcelDataReader.ExcelReaderFactory.CreateReader(stream);
            
                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = false
                    }
                };

                var dataSet = reader.AsDataSet(conf);

                // Now you can get data from each sheet by its index or its "name"
                var dataTable = dataSet.Tables[0];

                for (int i =1; i < dataTable.Rows.Count; i++)
                {
                    string[] dataRow = dataTable.Rows[i].ItemArray.Select(x => x.ToString()).ToArray();
                    //double[] dataRowDouble = new double[dataRow.Length];
                    for (int j = 0; j< dataRow.Length;j++)
                    {
                        dataRow[j] = dataRow[j].Replace(',', '.');
                        
                    }
                    double data1 = parseStringToDouble(dataRow, 2);

                    double data2 = parseStringToDouble(dataRow, 3);
                    string sampleName = Convert.ToString(dataTable.Rows[i][0]);
                    
                    double[] tmpMeanColor = {

                        parseStringToDouble(dataRow, 4),
                        parseStringToDouble(dataRow, 5),
                        parseStringToDouble(dataRow, 6)};

                    double[] tmpPercentageColor = {
                        parseStringToDouble(dataRow, 8),
                        parseStringToDouble(dataRow, 9),
                        parseStringToDouble(dataRow, 10),
                        parseStringToDouble(dataRow, 11),
                        parseStringToDouble(dataRow, 12)};

                    double[][] tmpColorPredominante = new double[5][]; 
                    for (int k=0; k<5; k++)
                    {
                        double[] colorDominanteK = {
                            parseStringToDouble(dataRow,14+k*3),
                            parseStringToDouble(dataRow,15+k*3),
                            parseStringToDouble(dataRow,16+k*3)};
                        tmpColorPredominante[k] = colorDominanteK;
                    }
                    meanColor.Add(sampleName, tmpMeanColor);
                    percentageColorsKM5.Add(sampleName, tmpPercentageColor);
                    predominanteColor.Add(sampleName,tmpColorPredominante);



                }
                reader.Close();
                reader.Dispose();
                GC.Collect();
            }

        }


        void fillListItemCombo()
        {
            combo.DataSource = new BindingSource(meanColor, null);
            combo.DisplayMember = "Key";
            combo.ValueMember = "Key";
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }


        public double calculdeltaE_RGB(double[] color1,double[] color2)
        {
            double[] color1LAB = RGBtoLab(color1);
            double[] color2LAB = RGBtoLab(color2);
            double deltaE = Math.Sqrt( Math.Pow(color1LAB[0] - color2LAB[0],2)
                + Math.Pow(color1LAB[1] - color2LAB[1], 2)
                + Math.Pow(color1LAB[2] - color2LAB[2], 2));
            return deltaE;
        }

        public void fillColorArea(string key)
        {
            double[] meanC = meanColor.GetValueOrDefault(key);
            double[][] domnantC = predominanteColor.GetValueOrDefault(key);
            pictureMeanColor.BackColor =  Color.FromArgb((int)meanC[0], (int)meanC[1], (int)meanC[2]);
            pictureDominantColor1.BackColor = Color.FromArgb((int)domnantC[0][0], (int)domnantC[0][1], (int)domnantC[0][2]);
            pictureDominantColor2.BackColor = Color.FromArgb((int)domnantC[1][0], (int)domnantC[1][1], (int)domnantC[1][2]);
            pictureDominantColor3.BackColor = Color.FromArgb((int)domnantC[2][0], (int)domnantC[2][1], (int)domnantC[2][2]);
            pictureDominantColor4.BackColor = Color.FromArgb((int)domnantC[3][0], (int)domnantC[3][1], (int)domnantC[3][2]);
            pictureDominantColor5.BackColor = Color.FromArgb((int)domnantC[4][0], (int)domnantC[4][1], (int)domnantC[4][2]);
        }
        public double[] RGBtoLab(Double[] color)
        {
            double[] xyz = new double[3];
            double[] lab = new double[3];
            double[] rgb = new double[] { color[0]/255.0f, color[1] / 255.0f, color[2] / 255.0f };

            if (rgb[0] > .04045f)
            {
                rgb[0] = (float)Math.Pow((rgb[0] + .0055) / 1.055, 2.4);
            }
            else
            {
                rgb[0] = rgb[0] / 12.92f;
            }

            if (rgb[1] > .04045f)
            {
                rgb[1] = (float)Math.Pow((rgb[1] + .0055) / 1.055, 2.4);
            }
            else
            {
                rgb[1] = rgb[1] / 12.92f;
            }

            if (rgb[2] > .04045f)
            {
                rgb[2] = (float)Math.Pow((rgb[2] + .0055) / 1.055, 2.4);
            }
            else
            {
                rgb[2] = rgb[2] / 12.92f;
            }

            xyz[0] = ((rgb[0] * .412453f) + (rgb[1] * .357580f) + (rgb[2] * .180423f)) * 95.047f;
            xyz[1] = ((rgb[0] * .212671f) + (rgb[1] * .715160f) + (rgb[2] * .072169f)) * 100.0f;
            xyz[2] = ((rgb[0] * .019334f) + (rgb[1] * .119193f) + (rgb[2] * .950227f)) * 108.883f;

            if (xyz[0] > .008856f)
            {
                xyz[0] = (float)Math.Pow(xyz[0], 1.0 / 3.0);
            }
            else
            {
                xyz[0] = (xyz[0] * 7.787f) + (16.0f / 116.0f);
            }

            if (xyz[1] > .008856f)
            {
                xyz[1] = (float)Math.Pow(xyz[1], 1.0 / 3.0);
            }
            else
            {
                xyz[1] = (xyz[1] * 7.787f) + (16.0f / 116.0f);
            }

            if (xyz[2] > .008856f)
            {
                xyz[2] = (float)Math.Pow(xyz[2], 1.0 / 3.0);
            }
            else
            {
                xyz[2] = (xyz[2] * 7.787f) + (16.0f / 116.0f);
            }

            lab[0] = (116.0f * xyz[1]) - 16.0f;
            lab[1] = 500.0f * (xyz[0] - xyz[1]);
            lab[2] = 200.0f * (xyz[1] - xyz[2]);
            return lab;
        }

        public double[] BGRoLab(Double[] color)
        {
            double[] xyz = new double[3];
            double[] lab = new double[3];
            double[] rgb = new double[] { color[2] / 255.0f, color[1] / 255.0f, color[0] / 255.0f };

            if (rgb[0] > .04045f)
            {
                rgb[0] = (float)Math.Pow((rgb[0] + .0055) / 1.055, 2.4);
            }
            else
            {
                rgb[0] = rgb[0] / 12.92f;
            }

            if (rgb[1] > .04045f)
            {
                rgb[1] = (float)Math.Pow((rgb[1] + .0055) / 1.055, 2.4);
            }
            else
            {
                rgb[1] = rgb[1] / 12.92f;
            }

            if (rgb[2] > .04045f)
            {
                rgb[2] = (float)Math.Pow((rgb[2] + .0055) / 1.055, 2.4);
            }
            else
            {
                rgb[2] = rgb[2] / 12.92f;
            }

            xyz[0] = ((rgb[0] * .412453f) + (rgb[1] * .357580f) + (rgb[2] * .180423f)) * 95.047f;
            xyz[1] = ((rgb[0] * .212671f) + (rgb[1] * .715160f) + (rgb[2] * .072169f)) * 100.0f;
            xyz[2] = ((rgb[0] * .019334f) + (rgb[1] * .119193f) + (rgb[2] * .950227f)) * 108.883f;

            if (xyz[0] > .008856f)
            {
                xyz[0] = (float)Math.Pow(xyz[0], 1.0 / 3.0);
            }
            else
            {
                xyz[0] = (xyz[0] * 7.787f) + (16.0f / 116.0f);
            }

            if (xyz[1] > .008856f)
            {
                xyz[1] = (float)Math.Pow(xyz[1], 1.0 / 3.0);
            }
            else
            {
                xyz[1] = (xyz[1] * 7.787f) + (16.0f / 116.0f);
            }

            if (xyz[2] > .008856f)
            {
                xyz[2] = (float)Math.Pow(xyz[2], 1.0 / 3.0);
            }
            else
            {
                xyz[2] = (xyz[2] * 7.787f) + (16.0f / 116.0f);
            }

            lab[0] = (116.0f * xyz[1]) - 16.0f;
            lab[1] = 500.0f * (xyz[0] - xyz[1]);
            lab[2] = 200.0f * (xyz[1] - xyz[2]);
            return lab;
        }



        public double[] coeffMireDominante(string nomEchantillons)
        {
            double[][] coefDeltaEPredo = new double[5][];
            double[] coefMirePerc = new double[4];
            for (int k = 0; k<5; k++)
            {
                double[] deltaE = new double[4];
                for (int i =0; i < 4; i++ )
                {
                    double[] colorNull = { 0, 0, 0 };
                    double[] colorTotest = predominanteColor.GetValueOrDefault(nomEchantillons)[k];

                    deltaE[i] = calculdeltaE_RGB(colorMireRef[i], predominanteColor.GetValueOrDefault(nomEchantillons)[k]);
                                 
                }
                double[] deltaEPerc;
                if (deltaE.Contains(0)) // Si une mire unicolore est mise en test
                {
                    deltaEPerc = new double[4] { 0,0,0,0};
                    int indxPattern = Array.IndexOf(deltaE, 0);
                    deltaEPerc[indxPattern] = 1;
                }
                else
                {
                    double sum = deltaE.Sum();
                    deltaEPerc = new double[4] { deltaE[0] / sum, deltaE[1] / sum, deltaE[2] / sum, deltaE[3] / sum };
                }

                coefDeltaEPredo[k] = deltaEPerc;

            }
            double[] percentages = percentageColorsKM5.GetValueOrDefault(nomEchantillons);
            for (int w = 0; w < 4; w++)
            {
                coefMirePerc[w] = coefDeltaEPredo[0][w] * percentages[0] +
                    coefDeltaEPredo[1][w] * percentages[1] +
                    coefDeltaEPredo[2][w] * percentages[2] +
                    coefDeltaEPredo[3][w] * percentages[3] +
                    coefDeltaEPredo[4][w] * percentages[4];
            }
            return coefMirePerc;
        }


        public double[] calculNearestTestPattern(string nomEchantillons)
        {
            
            double[] percentagesM = {100,0,0,0,0};
            /*
            double[] deltaE = new double[4];
            for (int i = 0; i < 4; i++)
            {
                deltaE[i] = calculdeltaE_RGB(colorMireRef[i], meanColor.GetValueOrDefault(nomEchantillons));

            }
            double min = deltaE.Min();
            int indx = Array.IndexOf(deltaE, min);
            */

            return percentagesM;
        }

        public void saveTojsonFile()
        {
            ColorDataStrorage storageColor = new ColorDataStrorage(meanColor, percentageColorsKM5, predominanteColor,predominanteColorCoefPattern);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "json |*.json |All Files|*.*";
            saveFileDialog1.Title = "Sauvegarder un interpreteur de couleur";

            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string jsonString = JsonConvert.SerializeObject(storageColor);
                File.WriteAllText(saveFileDialog1.FileName, jsonString);
            }

        }



        void calculKMEANS(string path)
		{
		}

        void AddSampleToDictionnary(string path)
        {
        }

       
    }
}

