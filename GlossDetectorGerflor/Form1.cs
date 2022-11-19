using System;
using System.ComponentModel;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Threading;
using Newtonsoft.Json;
using static CalibrationOptimizer;

namespace GlossDetectorGerflor
{
    public partial class Form1 : Form
    {
        VideoCapture capture;
        private Mat frame;
        string folderpath = "";
        private FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        private OpenFileDialog filesDialog = new OpenFileDialog();
        private OpenFileDialog filesDialogCalibrage = new OpenFileDialog();
        //private ImageList loadedImages;
        private List<String> photoPaths;
        private bool isRecording = false;
        private bool useBykValue = true;

        private float[] percentagesScaleCrosshair = { 0, 0 };
        private float[] percentagesShiftCrosshair = { 0, 0 };
        private int[] shift = { 0, 0};

        private Calibration calibration;
        private Interpolator interpolator;
        private GuFinder guFinder;
        private ColorAdjustment colorAdjust;
        private ExportToExcelClass export;
        string[] photoPathsCalibration;
        bool calibrationInProgress = false;
        bool isDataExportedtoExcel = false;
        bool rrTest = false;
        string[] photosPathToAnalyze; // Calibration paths are not linked with it

        public Form1()
        {
            InitializeComponent();

        }


        private void ProcessFrame(object sender, EventArgs e)
        {
            if (capture != null && capture.Ptr != IntPtr.Zero)
            {
                Image<Bgr, byte> image = capture.QueryFrame().ToImage<Bgr, Byte>();
                imageArea.Image = image.ToBitmap();
                GC.Collect();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (calibration is null)
            {
                if (!bgw_calibration.IsBusy)
                {
                    calibration = new Calibration(percentagesShiftCrosshair, percentagesScaleCrosshair,
                        nbLines.Value, photoPathsCalibration, colorspace.SelectedItem.ToString(),
                        distribution.SelectedItem.ToString(), verticalBar.Value, horizontalBar.Value, horizontalShift.Value, verticalShift.Value);
                    calibrationDone();
                    bgw_calibration.RunWorkerAsync();
                }
            }
            if (calibrationInProgress)
            {
                MessageBox.Show("Calibrage en cours, veuillez patienter");
                return;
            }

            if (interpolator is not null && guFinder is not null && colorAdjust is not null)
            {
                if (photosPathToAnalyze is not null && photosPathToAnalyze.Length > 0)
                {

                    if (rrTest)
                    {
                        guFinder.mesureStdOneTypeSample(photosPathToAnalyze, sampleCombo);
                    }
                    else
                    {
                        guFinder.analyzePhotos(photosPathToAnalyze, sampleCombo, resultLabel);
                    }
                    if (isDataExportedtoExcel)
                    {
                        export = new ExportToExcelClass(calibration, interpolator, guFinder);
                    }

                }else {
                    MessageBox.Show("Veuillez sélectionner au moins une photo");
                }



            }
            GC.Collect();

        }




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Echantillons",150);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            //loadedImages = new ImageList();
            //loadedImages.ImageSize = new Size(50, 30);
            filesDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            filesDialog.Multiselect = true;
            filesDialogCalibrage.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            filesDialogCalibrage.Multiselect = true;
            colorspace.SelectedItem = "HSV";
            distribution.SelectedItem = "Régulière";
            interpolationCombo.SelectedItem = "Régression polynomiale";
            degrePolyCombo.SelectedItem = "5";
            menuStrip1.Items[1].Enabled = false;
            



            photoPaths = new List<string>();
            createCrosshair();
            nbLinesLabel.Text = "Nombre de lignes de calcul : " + nbLines.Value.ToString();
            //checkBox1.CheckState = CheckState.Checked;

            percentagesShiftCrosshair[0] = (float)crossHair.Location.X / (float)imageArea.Width;
            percentagesShiftCrosshair[1] = (float)crossHair.Location.Y / (float)imageArea.Height;
            percentagesScaleCrosshair[0] = (float)crossHair.Width / (float)imageArea.Width;
            percentagesScaleCrosshair[1] = (float)crossHair.Height / (float)imageArea.Height;

            colorAdjust = new ColorAdjustment(sampleCombo,  pictureMeanColor,  PictureDominante1, PictureDominante2, PictureDominante3, PictureDominante4, PictureDominante5);
            colorAdjust.fillColorArea(sampleCombo.SelectedValue.ToString());

            }

        private void LoadImagesFolder()
        {
            var photoFiles = Directory.EnumerateFiles(folderpath, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png") || s.EndsWith(".gif") || s.EndsWith(".tiff"));
            try
            {
                foreach(String path in photoFiles)
                {
                    //loadedImages.Images.Add(Image.FromFile(path));
                    photoPaths.Add(path);
                }
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            updateListViewItem();

            if (listView1.Items.Count > 0)
            {
                String pathFullImage = photoPaths[0];
                Image img1 = Image.FromFile(pathFullImage);
                hideCrosshairCheckbox.CheckState = CheckState.Unchecked;
                imageArea.Image = img1;
            }


        }

        private void updateListViewItem(bool calibration = false)
        {
            listView1.Items.Clear();
            //listView1.SmallImageList = loadedImages;
            int idx = 0;
            
            if (calibration == false) {
                foreach (String path in photoPaths)
                {
                    string filename = Path.GetFileName(path);
                    listView1.Items.Add(filename, idx);
                    idx++;
                }
            }
            else
            {
                foreach (String path in photoPaths)
                {
                    string nameFile = Path.GetFileName(path);
                    listView1.Items.Add("CAL-" + nameFile, idx);
                    idx++;
                }

            }

            if (listView1.Items.Count > 0)
            {
                analyseButton.Enabled = true;
            }
        }


        private void LoadImagesFiles(bool calibration = false)
        {
            if (calibration == false)
            {
                foreach (String file in filesDialog.FileNames)
                {
                    try
                    {
                        //loadedImages.Images.Add(Image.FromFile(file));
                        photoPaths.Add(file);
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
            }else
            {
                foreach (String file in filesDialogCalibrage.FileNames)
                {
                    try
                    {
                        Debug.WriteLine(file);
                        //loadedImages.Images.Add(Image.FromFile(file));
                        photoPaths.Add(file);
                    }
                    catch (SecurityException ex)
                    {
                        // The user lacks appropriate permissions to read files, discover paths, etc.
                        MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                            "Error message: " + ex.Message + "\n\n" +
                            "Details (send to Support):\n\n" + ex.StackTrace
                        );
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                            + ". You may not have permission to read the file, or " +
                            "it may be corrupt.\n\nReported error: " + ex.Message);
                    }
                }
            }
            updateListViewItem(false);
            if (listView1.Items.Count > 0)
            {
                String pathFullImage = photoPaths[0];
                Image img1 = Image.FromFile(pathFullImage);
                imageArea.Image = img1;
                hideCrosshairCheckbox.CheckState = CheckState.Unchecked;
            }

        }




        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void connecterUneCaméraToolStripMenuItem_Click(object sender, EventArgs e)
        {

            capture = new VideoCapture(0);
            capture.ImageGrabbed += ProcessFrame;
            frame = new Mat();
            if (capture != null)
            {
                try
                {
                    capture.Start();
                    isRecording = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void chargerImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (capture is null)
            {
                MessageBox.Show("Veuillez connecter une caméra");
                return;
            }
            else
            {
                capture.Start();
                isRecording = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void chargerUnDossierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderpath = folderBrowserDialog.SelectedPath;
                LoadImagesFolder();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                return;
            }
            //listView1.SmallImageList.Images.Clear();
            listView1.Items.Clear();
            //loadedImages.Images.Clear();
            photoPaths.Clear();
            
            analyseButton.Enabled = false;
            resultLabel.Text=  "UB mesuré : 0 UB";
            resultLabel.Enabled = false;




            if (isRecording)
            {
                // TODO
            } else
            {
                imageArea.Image = Properties.Resources.gerflor;
                hideCrosshairCheckbox.CheckState = CheckState.Checked;
                curvesChart.CheckState = CheckState.Unchecked;
            }
            GC.Collect();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (calibration is not null)
            {
                photosPathToAnalyze = new string[listView1.SelectedItems.Count];
                for (int i =0; i< listView1.SelectedItems.Count; i++)
                {
                    int indx = listView1.SelectedIndices[i];
                    photosPathToAnalyze[i] = photoPaths[i];
                }
            }

            if (listView1.SelectedIndices.Count == 0)
            {
                return;
            }

            int index = listView1.SelectedIndices[0];
            String pathFullImage = photoPaths[index];
            Image img1 = Image.FromFile(pathFullImage);
            imageArea.Image = img1;
            
 
            imageArea.SizeMode = PictureBoxSizeMode.StretchImage;
            if (capture != null)
            {
                try
                {
                    capture.Stop();
                    isRecording = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            GC.Collect();
        }

        private void selectedPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void chargerDesImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = filesDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadImagesFiles(false);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        public void createCrosshair()
        {
            crossHair.Parent = imageArea;
            crossHair.Visible = false;
            crossHair.Location = new Point(imageArea.Width/2- crossHair.Width/2,imageArea.Height/2-crossHair.Height/2);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            crossHair.Width = 178 + (int)Math.Ceiling((double)((double)horizontalBar.Value / (double)100 * 178));
            updateLocationCrosshair();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            crossHair.Height = 90 + (int)Math.Ceiling((double)((double)verticalBar.Value / (double)100 * 90));
            updateLocationCrosshair();
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            crossHair.Visible = !crossHair.Visible;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {

            shift[0] = horizontalShift.Value * 2;
            updateLocationCrosshair();
        }

        private void trackBar2_Scroll_1(object sender, EventArgs e)
        {
            shift[1] = verticalShift.Value * 2;
            updateLocationCrosshair();
        }

        private void updateLocationCrosshair()
        {
            crossHair.Location = new Point(imageArea.Width / 2 - crossHair.Width / 2 + shift[0], imageArea.Height / 2 - crossHair.Height / 2 + +shift[1]);
            percentagesShiftCrosshair[0] = (float)crossHair.Location.X / (float)imageArea.Width;
            percentagesShiftCrosshair[1] = (float)crossHair.Location.Y / (float)imageArea.Height;
            percentagesScaleCrosshair[0] = (float)crossHair.Width / (float)imageArea.Width;
            percentagesScaleCrosshair[1] = (float)crossHair.Height / (float)imageArea.Height;
        }

        private void blancToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crossHair.Image = Properties.Resources.viewFinder;
        }

        private void rougeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crossHair.Image = Properties.Resources.viewFinderRed;
        }

        private void vertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            crossHair.Image = Properties.Resources.viewFinderGreen;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void nbLignes_Scroll(object sender, EventArgs e)
        {
            nbLinesLabel.Text = "Nombre de lignes de calcul : "+ nbLines.Value.ToString();
        }

        private void utiliserUnCalToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Veuillez sélectionner les photos des mires dans l'ordre suivant : Du plus mat au plus brillant. \n Ainsi que les couleurs dans cette ordre : blanc, gris clair, gris foncé et noir. \n Une fois les images sélectionnées, régler le viseur et appuyer sur ANALYSER");
            DialogResult result = filesDialogCalibrage.ShowDialog();
            if (result == DialogResult.OK)
            {

                photoPathsCalibration = filesDialogCalibrage.FileNames;
                LoadImagesFiles(true);
                isCalibrating();
                calibrationInProgress = true;
            }
            
        }


        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void nouvelleCalibrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog xlmDialog = new OpenFileDialog();
            xlmDialog.Filter = "XML|*.xml|All files|*.*";
            DialogResult result = xlmDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Calibration));


                using (Stream reader = new FileStream(xlmDialog.FileName, FileMode.Open))
                {
                    // Call the Deserialize method to restore the object's state.
                    calibration = (Calibration)serializer.Deserialize(reader);
                }
                calibrationDone();
                setUpXMLCalibration();

                interpolator = new Interpolator(calibration.resMeanDerivative, interpolationCombo.SelectedItem.ToString(),cartesianChart1,95, useBykValue);
                guFinder = new GuFinder(interpolator, calibration, colorAdjust,rrTest);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (interpolationCombo.SelectedItem.ToString() == "Régression polynomiale")
            {
                degreLabel.Visible = true;
                degrePolyCombo.Visible = true;
            } else
            {
                degreLabel.Visible = false;
                degrePolyCombo.Visible = false;
            }

            if (calibration is not null)
            {
                interpolator = new Interpolator(calibration.resMeanDerivative, interpolationCombo.SelectedItem.ToString(), cartesianChart1, 95, useBykValue);
                guFinder = new GuFinder(interpolator, calibration, colorAdjust, rrTest);
            }

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Debug.WriteLine("Dowork");
            BackgroundWorker worker = sender as BackgroundWorker;
            calibration.ProgressChanged += (s, pe) => worker.ReportProgress(pe.ProgressPercentage);
            calibration.launch();

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressBar1.Update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            calibration.saveCalibrationFile();
            calibrationStatusLabel.Text = "Calibrage effectué";
            progressBar1.Value = 0;
            progressBar1.Update();
            clearBucket.PerformClick();
            interpolator = new Interpolator(calibration.resMeanDerivative, interpolationCombo.SelectedItem.ToString(), cartesianChart1, 95, useBykValue);
            guFinder = new GuFinder(interpolator, calibration,colorAdjust,rrTest);
        }

        private void isCalibrating()
        {
            analyseButton.Enabled = true;
            deleteCalibrationButton.Enabled = false;
        }
        private void calibrationDone()
        {
            analyseButton.Enabled = false;
            colorspace.Enabled = false;
            distribution.Enabled = false;
            nbLines.Enabled = false;
            verticalBar.Enabled = false;
            horizontalBar.Enabled = false;
            horizontalShift.Enabled = false;
            verticalShift.Enabled = false;
            deleteCalibrationButton.Enabled = true;
            calibrationInProgress = false;
            calibrationStatusLabel.Text = "Calibrage effectué";
            menuStrip1.Items[0].Enabled = false;
            menuStrip1.Items[1].Enabled = true;
            interpolationCombo.Enabled = true;
            degrePolyCombo.Enabled = true;
            exportExcel.Enabled = true;
            curvesChart.Enabled = true;
            sampleCombo.Enabled = true;
        }

        private void resetCalibration()
        {
            calibration = null;
            interpolator = null;
            export = null;
            guFinder = null;
            analyseButton.Enabled = false;
            colorspace.Enabled = true;
            distribution.Enabled = true;
            nbLines.Enabled = true;
            verticalBar.Enabled = true;
            horizontalBar.Enabled = true;
            horizontalShift.Enabled = true;
            verticalShift.Enabled = true;
            deleteCalibrationButton.Enabled = false;
            guFinder = null;
            calibrationStatusLabel.Text = "Calibrage non effectué";
            menuStrip1.Items[0].Enabled = true;
            menuStrip1.Items[1].Enabled = false;
            interpolationCombo.Enabled = false;
            exportExcel.Enabled = false;
            cartesianChart1.Visible = false;
            curvesChart.Enabled = false;
            resultLabel.Enabled = false;
            sampleCombo.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(calibration is null))
            {
                resetCalibration();
            }
        }

        private void setUpXMLCalibration()
        {
            colorspace.SelectedItem = calibration.colorspace;
            distribution.SelectedItem = calibration.distribution;
            nbLines.Value = calibration.nbLines;
            nbLinesLabel.Text = "Nombre de lignes de calcul : " + calibration.nbLines.ToString();
            verticalBar.Value = calibration.verticalBar;
            horizontalBar.Value = calibration.horizontalBar;
            horizontalShift.Value = calibration.horizontalShift;
            verticalShift.Value = calibration.verticalShift;


            shift[0] = horizontalShift.Value * 2;
            shift[1] = verticalShift.Value * 2;
            crossHair.Width = 178 + (int)Math.Ceiling((double)((double)horizontalBar.Value / (double)100 * 178));
            crossHair.Height = 90 + (int)Math.Ceiling((double)((double)verticalBar.Value / (double)100 * 90));
            updateLocationCrosshair();
        }

        private void setUpJsonInterpolation()
        {
            interpolationCombo.SelectedItem = interpolator.interpolationType;
            if(interpolator.interpolationType == "Régression polynomiale")
            {
                degrePolyCombo.SelectedItem = interpolator.orderPolynomial.ToString();
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            cartesianChart1.Visible = curvesChart.Checked;
        }

        private void resultat_Click(object sender, EventArgs e)
        {

        }

        private void echantillonCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (colorAdjust is not null)
            {
                if (sampleCombo.Items.Count > 0)
                {
                    colorAdjust.fillColorArea(sampleCombo.SelectedValue.ToString());
                }
            }

            
        }

        private void echantillonsType_Click(object sender, EventArgs e)
        {

        }

        private void sauvegarderUneBanqueDéchantillonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorAdjust is not null)
            {

            }
        }

        private void chargerUneBanqueDéchantillonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDialogJson = new OpenFileDialog();

            openfileDialogJson.Filter = "json |*.json |All Files|*.*";
            openfileDialogJson.Title = "Ouvrir un interpreteur de couleur";

            DialogResult result = openfileDialogJson.ShowDialog();
            if (result == DialogResult.OK)
            {
                string jsonString = File.ReadAllText(openfileDialogJson.FileName);
                ColorDataStrorage cds = JsonConvert.DeserializeObject<ColorDataStrorage>(jsonString);
                colorAdjust = new ColorAdjustment(cds,sampleCombo, pictureMeanColor, PictureDominante1, PictureDominante2, PictureDominante3, PictureDominante4, PictureDominante5);
                colorAdjust.fillColorArea(sampleCombo.SelectedValue.ToString());
            }


        }

        private void MeanColor_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void valeurBYKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useBykValue = true;
            interpolator = new Interpolator(calibration.resMeanDerivative, interpolationCombo.SelectedItem.ToString(), cartesianChart1, 95, useBykValue);
            guFinder = new GuFinder(interpolator, calibration, colorAdjust,rrTest);
        }

        private void valeurThéoriqueNCSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            useBykValue = false;
            interpolator = new Interpolator(calibration.resMeanDerivative, interpolationCombo.SelectedItem.ToString(), cartesianChart1, 95, useBykValue);
            guFinder = new GuFinder(interpolator, calibration, colorAdjust, rrTest);
        }

        private void exportExcel_CheckedChanged(object sender, EventArgs e)
        {
            isDataExportedtoExcel = !isDataExportedtoExcel;
        }

        private void calibrageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_Load(object sender, EventArgs e)
        {

        }

        private void effectuerLeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void activerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rrTest = true;
            MessageBox.Show("Veuillez sélectionner 30 images d'un même type");
            guFinder = new GuFinder(interpolator, calibration, colorAdjust, rrTest);
        }

        private void désactiverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rrTest = false;
            guFinder = new GuFinder(interpolator, calibration, colorAdjust, rrTest);
        }

        private void optimiseurDeParamètresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CalibrationOptimizer optimizer = new CalibrationOptimizer(percentagesShiftCrosshair, percentagesScaleCrosshair,
                verticalBar.Value, horizontalBar.Value, horizontalShift.Value, verticalShift.Value,
                photoPaths.ToArray(), progressBar1, colorAdjust, sampleCombo);

            optimizer.provideData += optimizerWorkingFinish;
            this.Enabled = false;

        }

        void optimizerWorkingFinish(object sender, OptimizedParameters e)
        {
            this.Enabled = true;
            interpolator = e.interp;
            calibration = e.cal;
            guFinder = new GuFinder(interpolator, calibration, colorAdjust, rrTest);
            calibrationDone();
            setUpXMLCalibration();
            setUpJsonInterpolation();
        }

        void provideArrayBYKValues(object sender, provideBYKArrayEvent e)
        {
            double[] bykValuesForTesting = e.resBYK;
        }

        void bykFormCancelling(object sender, EventArgs e)
        {
            this.Enabled = true;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void degrePolyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (calibration is not null)
            {
                interpolator = new Interpolator(calibration.resMeanDerivative, interpolationCombo.SelectedItem.ToString(), cartesianChart1, 95, useBykValue,Convert.ToInt32(degrePolyCombo.SelectedItem));
                guFinder = new GuFinder(interpolator, calibration, colorAdjust, rrTest);
            }

        }

        private void chargerUneInterpolationIncluLeCalibrageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfileDialogJson = new OpenFileDialog();

            openfileDialogJson.Filter = "json|*.json|All Files|*.*";
            openfileDialogJson.Title = "Ouvrir un interpolation et un calibrage";

            DialogResult result = openfileDialogJson.ShowDialog();
            if (result == DialogResult.OK)
            {
                string jsonString = File.ReadAllText(openfileDialogJson.FileName);


                OptimizedParameters opti = JsonConvert.DeserializeObject<OptimizedParameters>(jsonString);
                calibration = opti.cal;
                interpolator = opti.interp;
                interpolator.setChartFromJson(cartesianChart1);
                guFinder = new GuFinder(interpolator, calibration, colorAdjust, rrTest);
                
                setUpXMLCalibration();
                setUpJsonInterpolation();
                calibrationDone();
            }


        }

        private void PictureDominante5_Click(object sender, EventArgs e)
        {

        }
    }

    
}
