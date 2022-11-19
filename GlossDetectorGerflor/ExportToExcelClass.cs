using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.ConditionalFormatting;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Drawing.Chart.Style;

public class ExportToExcelClass
{

    Calibration calibration;
    Interpolator interpolator;
    GuFinder guFinder;

    public ExportToExcelClass(Calibration calibration, Interpolator interpolator, GuFinder guFinder)
    {
        this.calibration = calibration;
        this.interpolator = interpolator;
        this.guFinder = guFinder;
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        ExcelPackage excel = new ExcelPackage();
        if (guFinder.rrTest)
        {
            createRRresultSheet(excel);
            createCalibrationSheet(excel);
        }
        else
        {
            createMainSheetResult(excel);
            createCalibrationSheet(excel);
        }


        saveExcelToFile(excel);
        GC.Collect();
    }


    void createRRresultSheet(ExcelPackage excel)
    {
        var workSheet = excel.Workbook.Worksheets.Add("Test R&R");

        workSheet.TabColor = System.Drawing.Color.Black;
        workSheet.DefaultRowHeight = 12;

        workSheet.Column(1).Width = 24;
        workSheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        workSheet.Column(1).Style.Font.Bold = true;
        workSheet.Row(1).Style.Font.Bold = true;

        string useByk = "Valeurs NCS pour les mires";
        if (interpolator.useBykValue)
            useByk = "Valeurs BYK pour les mires";
        workSheet.Cells[1, 1].Value = "Calibrage :";
        workSheet.Cells[2, 1].Value = "Nombres de lignes : " + calibration.nbLines.ToString();
        workSheet.Cells[3, 1].Value = "Distribution: " + calibration.distribution.ToString();
        workSheet.Cells[4, 1].Value = "Colorspace: " + calibration.colorspace.ToString();
        workSheet.Cells[5, 1].Value = "Référence: " + useByk;

        workSheet.Cells[1, 3].Value = "Nom Echantillon:";
        workSheet.Cells[1, 4].Value = "Type Echantillon:";
        workSheet.Cells[1, 5].Value = "UB Calculé";
        workSheet.Cells[1, 6].Value = "Valeur BYK";
        workSheet.Cells[1, 7].Value = "Incertitude absolue";
        workSheet.Cells[1, 8].Value = "Incertitude relative %";



        for (int i = 0; i < guFinder.results.Length; i++)
        {

            workSheet.Cells[i + 2, 3].Value = guFinder.nameAndType[i][0];
            workSheet.Cells[i + 2, 4].Value = guFinder.nameAndType[i][1];
            workSheet.Cells[i + 2, 5].Value = guFinder.results[i][0];
            workSheet.Cells[i + 2, 6].Value = guFinder.bykValueSamples[i];
            workSheet.Cells[i + 2, 7].Value = guFinder.absUncertainty[i];
            workSheet.Cells[i + 2, 8].Value = guFinder.relativeUncertaintyPercent[i];
        }

        for (int i = 1; i < 22; i++)
        {
            workSheet.Column(i).AutoFit();
        }
        var cells = new ExcelAddress("E2:E" + (guFinder.results.Length + 1).ToString());
        var cells2 = new ExcelAddress("F2:F" + (guFinder.results.Length + 1).ToString());
        var cells3 = new ExcelAddress("G2:G" + (guFinder.results.Length + 1).ToString());
        var cells4 = new ExcelAddress("H2:H" + (guFinder.results.Length + 1).ToString());
        var cfRule = workSheet.Cells[cells.Address].ConditionalFormatting.AddThreeColorScale();
        cfRule.LowValue.Color = Color.LightBlue;
        var cfRule2 = workSheet.Cells[cells2.Address].ConditionalFormatting.AddThreeColorScale();
        cfRule2.LowValue.Color = Color.LightBlue;
        var cfRule3 = workSheet.Cells[cells3.Address].ConditionalFormatting.AddThreeColorScale();
        cfRule3.LowValue.Color = Color.LightBlue;
        var cfRule4 = workSheet.Cells[cells4.Address].ConditionalFormatting.AddThreeColorScale();
        cfRule4.LowValue.Color = Color.LightBlue;

    }

    void createMainSheetResult(ExcelPackage excel)
    {
        var workSheet = excel.Workbook.Worksheets.Add("Résultat");

        workSheet.TabColor = System.Drawing.Color.Black;
        workSheet.DefaultRowHeight = 12;

        workSheet.Column(1).Width = 24;
        workSheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        workSheet.Column(1).Style.Font.Bold = true;
        workSheet.Row(1).Style.Font.Bold = true;
        string useByk = "Valeurs NCS pour les mires";
        if (interpolator.useBykValue)
            useByk = "Valeurs BYK pour les mires";
        workSheet.Cells[1, 1].Value = "Calibrage :";
        workSheet.Cells[2, 1].Value = "Nombres de lignes : " + calibration.nbLines.ToString();
        workSheet.Cells[3, 1].Value = "Distribution: " + calibration.distribution.ToString();
        workSheet.Cells[4, 1].Value = "Colorspace: " + calibration.colorspace.ToString();
        workSheet.Cells[5, 1].Value = "Référence: " + useByk;

        workSheet.Cells[1, 3].Value = "Nom Echantillon:";
        workSheet.Cells[1, 4].Value = "Type Echantillon:";
        workSheet.Cells[1, 5].Value = "UB Calculé";
        workSheet.Cells[1, 6].Value = "Ecart-type";




        for (int i = 0; i < guFinder.results.Length; i++)
        {

            workSheet.Cells[i + 2, 3].Value = guFinder.nameAndType[i][0];
            workSheet.Cells[i + 2, 4].Value = guFinder.nameAndType[i][1];
            workSheet.Cells[i + 2, 5].Value = guFinder.results[i][0];
            workSheet.Cells[i + 2, 6].Value = guFinder.results[i][1];
        }

        for (int i = 1; i < 22; i++)
        {
            workSheet.Column(i).AutoFit();
        }
        var cells = new ExcelAddress("E2:E"+(guFinder.results.Length+1).ToString());
        var cells2 = new ExcelAddress("F2:F" + (guFinder.results.Length + 1).ToString());
        var cfRule = workSheet.Cells[cells.Address].ConditionalFormatting.AddThreeColorScale();
        cfRule.LowValue.Color = Color.LightBlue;
        var cfRule2 = workSheet.Cells[cells2.Address].ConditionalFormatting.AddThreeColorScale();
        cfRule2.LowValue.Color = Color.LightBlue;





    }



    void createCalibrationSheet(ExcelPackage excel)
    {

        // name of the sheet
        var workSheet = excel.Workbook.Worksheets.Add("Calibrage");

        // setting the properties
        // of the work sheet 
        workSheet.TabColor = System.Drawing.Color.Black;
        workSheet.DefaultRowHeight = 12;

        // Setting the properties
        // of the first row
        workSheet.Column(1).Width = 24;
        workSheet.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
        workSheet.Column(1).Style.Font.Bold = true;

        // Header of the Excel sheet
        workSheet.Cells[1, 1].Value = "Calibrage :";
        workSheet.Cells[2, 1].Value = "Nombres de lignes : " + calibration.nbLines.ToString();
        workSheet.Cells[3, 1].Value = "Distribution: " + calibration.distribution.ToString();
        workSheet.Cells[4, 1].Value = "Colorspace: " + calibration.colorspace.ToString();

        workSheet.Cells[1, 3].Value = "Mire Blanche :";
        workSheet.Cells[1, 4].Value = "UB TH";
        workSheet.Cells[1, 5].Value = "Dérivé";
        workSheet.Cells[1, 6].Value = "Ecart-type";

        workSheet.Cells[1, 8].Value = "Mire Gris Clair :";
        workSheet.Cells[1, 9].Value = "UB TH";
        workSheet.Cells[1, 10].Value = "Dérivé";
        workSheet.Cells[1, 11].Value = "Ecart-type";


        workSheet.Cells[1, 13].Value = "Mire Gris foncé :";
        workSheet.Cells[1, 14].Value = "UB TH";
        workSheet.Cells[1, 15].Value = "Dérivé";
        workSheet.Cells[1, 16].Value = "Ecart-type";

        workSheet.Cells[1, 18].Value = "Mire noire :";
        workSheet.Cells[1, 19].Value = "UB TH";
        workSheet.Cells[1, 20].Value = "Dérivé";
        workSheet.Cells[1, 21].Value = "Ecart-type";


        double[] xData = { 2, 6, 12, 30, 50, 75, 95 };

        double[][] meanDerivative = calibration.resMeanDerivative
            .Select((s, i) => new { Value = s, Index = i })
            .GroupBy(x => x.Index / 7)
            .Select(grp => grp.Select(x => x.Value).ToArray())
            .ToArray();

        double[][] stdDerivative = calibration.resStdDerivative
            .Select((s, i) => new { Value = s, Index = i })
            .GroupBy(x => x.Index / 7)
            .Select(grp => grp.Select(x => x.Value).ToArray())
            .ToArray();



        for (int i =0; i< xData.Length;i++)
        {
            for (int j = 0; j < 4; j++)
            {
                workSheet.Cells[i+2, j*5+4 ].Value = xData[i];
                workSheet.Cells[i+2, j*5+5].Value = meanDerivative[j][i];
                workSheet.Cells[i+2, j*5+6].Value = stdDerivative[j][i];
            }

        }

        for (int i =1; i<22; i++)
        {
            workSheet.Column(i).AutoFit();
        }

        ExcelAddress _formatRangeAddress = new ExcelAddress("E2:E8,J2:J8,O2:O8,T2:T8");
        // fill GREEN color if value of the current cell is greater than 
        //    or equals to value of the previous cell
        string _statement = "IF(OFFSET(E2,0,-1)-E2>0,1,0)";
        var _cond1 = workSheet.ConditionalFormatting.AddExpression(_formatRangeAddress);
        _cond1.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        _cond1.Style.Fill.BackgroundColor.Color = Color.LightGreen;
        _cond1.Formula = _statement;

        // fill RED color if value of the current cell is less than 
        //    value of the previous cell
        _statement = "IF(OFFSET(E2,0,-1)-E2<0,1,0)";
        var _cond3 = workSheet.ConditionalFormatting.AddExpression(_formatRangeAddress);
        _cond3.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        _cond3.Style.Fill.BackgroundColor.Color = Color.IndianRed;
        _cond3.Formula = _statement;
        //the range of cells to be searched
        var cells = new ExcelAddress("F2:F8");
        var cells2 = new ExcelAddress("K2:K8");
        var cells3= new ExcelAddress("P2:P8");
        var cells4 = new ExcelAddress("U2:U8");

        var cfRule = workSheet.Cells[cells.Address].ConditionalFormatting.AddThreeColorScale();
        cfRule.LowValue.Color = Color.LightBlue;

        var cfRule2 = workSheet.Cells[cells2.Address].ConditionalFormatting.AddThreeColorScale();
        cfRule2.LowValue.Color = Color.LightBlue;
        var cfRule3 = workSheet.Cells[cells3.Address].ConditionalFormatting.AddThreeColorScale();
        cfRule3.LowValue.Color = Color.LightBlue;
        var cfRule4 = workSheet.Cells[cells4.Address].ConditionalFormatting.AddThreeColorScale();
        cfRule4.LowValue.Color = Color.LightBlue;


        for (int i =0; i<4;i++)
        {

            for (int j = 1; j <8; j++) 
            {
                workSheet.Cells[j+1,i*5+4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells[j + 1, i * 5 + 4].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
             }
        }
        workSheet.Row(1).Style.Fill.PatternType = ExcelFillStyle.Solid;
        workSheet.Row(1).Style.Fill.BackgroundColor.SetColor(Color.LightGray);


        for (int w =0; w<4; w++)
        {

            ExcelLineChart lineChart = workSheet.Drawings.AddChart("lineChart_+"+w.ToString(), eChartType.Line) as ExcelLineChart;

            //set the title
            lineChart.Title.Text = "Courbe " + workSheet.Cells[GetColumnName(w * 5 + 2)+"1"].Value.ToString();

            //create the ranges for the chart
            var rangeLabel = workSheet.Cells["D2:D8"];
            string column = GetColumnName(w * 5 + 4);
            var rangeLine = workSheet.Cells[column+"2:"+ column + "8"];

            
            //add the ranges to the chart
            lineChart.Series.Add(rangeLine, rangeLabel);


            var stdColumn = lineChart.PlotArea.ChartTypes.Add(eChartType.ColumnClustered);
            var serie2 = stdColumn.Series.Add(workSheet.Cells[GetColumnName(w * 5 + 5) + "2:" + GetColumnName(w * 5 + 5) + "8"], rangeLabel);
            //set the names of the legend
            lineChart.Series[0].Header = "Dérivée";
            serie2.Header = "Ecart-Type";

            lineChart.XAxis.Title.Text = "UB TH";
            lineChart.YAxis.Title.Text = "Maximum de dérivée";

            //size of the chart
            lineChart.SetSize(600, 300);

            //add the chart at cell B6
            lineChart.SetPosition(10, 0, 0+w*10, 0);
            lineChart.StyleManager.SetChartStyle(ePresetChartStyle.LineChartStyle9, ePresetChartColors.ColorfulPalette1);
        }

    }



    static string GetColumnName(int index)
    {
        const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        var value = "";

        if (index >= letters.Length)
            value += letters[index / letters.Length - 1];

        value += letters[index % letters.Length];

        return value;
    }

    public void saveExcelToFile(ExcelPackage excel)
    {

        SaveFileDialog saveFileDialog1 = new SaveFileDialog();

        saveFileDialog1.Filter = "Excel Document |*.xlsx |All Files|*.*";
        saveFileDialog1.Title = "Sauvegarder les résultats de brillance";

        DialogResult result = saveFileDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            string p_strPath = saveFileDialog1.FileName;

            if (File.Exists(p_strPath))
                File.Delete(p_strPath);

            // Create excel file on physical disk 
            FileStream objFileStrm = File.Create(p_strPath);
            objFileStrm.Close();

            // Write content to excel file 
            File.WriteAllBytes(p_strPath, excel.GetAsByteArray());
            //Close Excel package
            excel.Dispose();
        }

    }
}

