using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using MathNet.Numerics;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Forms;
using LiveChartsCore.Kernel.Sketches;
using MathNet.Numerics.Interpolation;
using System.IO;
using ExcelDataReader;
using System.Linq;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

public class Interpolator
{

	public double[] resMeanDerivative { get; set; }
	public double[][] coeffs { get; set; }
	public string interpolationType { get; set; }
	public double[][] curves { get; set; }

	public double[][] curvesLinear { get; set; }
	public double[][] bykValue { get; set; }
	CartesianChart chart;
	public Polynomial[] polynomialArray { get; set; } = new Polynomial[4];
	public int nbPoints { get; set; }
	public double sumStd { get; set; }
	public int orderPolynomial { get; set; }
	public bool useBykValue { get; set; }



	public Interpolator(double[] resMeanDerivative, string interpolationType, CartesianChart chart, int nbPoints, bool useBykValue, int orderPolynomial = 5)
	{
		this.resMeanDerivative = resMeanDerivative;
		this.interpolationType = interpolationType;
		this.chart = chart;
		this.nbPoints = nbPoints;
		this.useBykValue = useBykValue;
		this.bykValue = getBYKValue();
		this.orderPolynomial = orderPolynomial;
		initializeInterpolation(true);

	}

	//Use for the optimizer
	[JsonConstructor]
	public Interpolator(double[] resMeanDerivative, string interpolationType, int nbPoints, bool useBykValue, int orderPolynomial = 5)
	{
		this.resMeanDerivative = resMeanDerivative;
		this.interpolationType = interpolationType;
		this.nbPoints = nbPoints;
		this.useBykValue = useBykValue;
		this.orderPolynomial = orderPolynomial;
		this.bykValue = getBYKValue();
	}

	public Interpolator()
	{

	}



	public void initializeInterpolation(bool useCharts)
	{
		coeffs = new double[4][];
		try
		{
				
			 LinearSpline[] linearArray = new LinearSpline[4];
			 CubicSpline[] cubicSplines = new CubicSpline[4];
			 StepInterpolation[] stepInterp = new StepInterpolation[4];
			 NevillePolynomialInterpolation[] nevilleInterp = new NevillePolynomialInterpolation[4];
			 QuadraticSpline[] quadraSpline = new QuadraticSpline[4];

			for (int i = 0; i < 4; i++)
			{
				double[] xData = { 0, 2, 6, 12, 30, 50, 75, 95 };
				if (useBykValue) {
					bykValue[i].CopyTo(xData, 1);
				}
				double[] yData = {0,resMeanDerivative[0+i*7], resMeanDerivative[1+i*7], resMeanDerivative[2+i*7], resMeanDerivative[3+i*7],
				resMeanDerivative[4+i*7], resMeanDerivative[5+i*7], resMeanDerivative[6+i*7] };
				curves = new double[4][];
				curvesLinear = new double[4][];
				linearArray[i] = LinearSpline.Interpolate(xData, yData);
				if (interpolationType == "Régression polynomiale")
				{
					double[] tmp = Fit.Polynomial(xData, yData, orderPolynomial);
					polynomialArray[i] = Polynomial.Fit(xData, yData, orderPolynomial);
					coeffs[i] = tmp;
				}
				if (interpolationType == "CubicSpline Akima")
				{
					cubicSplines[i] = CubicSpline.InterpolateAkimaSorted(xData, yData);
				}
				if (interpolationType == "Interpolation Polynomiale de Néville")
				{
					nevilleInterp[i] = new NevillePolynomialInterpolation(xData, yData);
				}
				if (interpolationType == "Step Interpolation")
				{
					stepInterp[i] = new StepInterpolation(xData, yData);
				}
			}
			for (int i = 0; i < 4; i++)
			{
				if (interpolationType == "Régression polynomiale")
				{
					curves[i] = evaluatePolyCurve(coeffs[i], nbPoints);
				}
				if (interpolationType == "CubicSpline Akima")
				{
					curves[i] = evaluateCubicCurve(nbPoints, cubicSplines[i]);
				}
				if (interpolationType == "Interpolation Polynomiale de Néville")
				{
					curves[i] = evaluateNeville(nbPoints, nevilleInterp[i]);
				}
				if (interpolationType == "Step Interpolation")
				{
					curves[i] = evaluateStepInter(nbPoints, stepInterp[i]);
				}

				curvesLinear[i] = evaluateLinear(nbPoints, linearArray[i]);

			}
			if (useCharts)
			{
				setUpChart(nbPoints,chart);
			}


		}
		catch (Exception e)
		{
			MessageBox.Show("Il n'y a pas les 28 photos nécessaires à la calibration\nVeuillez recommencer en sélectionnant toutes les photos\n Stackstrace : " + e.Message);
		}

	}

	public void setChartFromJson(CartesianChart chartArg)
	{
		setUpChart(nbPoints, chartArg);
	}

	public double[] evaluateStepInter(int nbPoints, StepInterpolation inter)
	{
		double[] tmp = new double[nbPoints];
		for (int i = 0; i < nbPoints; i++)
		{
			tmp[i] = inter.Interpolate(i);
		}
		return tmp;
	}

	public double[] evaluateLinear(int nbPoints, LinearSpline inter)
	{
		double[] tmp = new double[nbPoints];
		for (int i = 0; i < nbPoints; i++)
		{
			tmp[i] = inter.Interpolate(i);
		}
		return tmp;
	}




	public double[] evaluateCubicCurve(int nbPoints, CubicSpline inter)
	{
		double[] tmp = new double[nbPoints];
		for (int i = 0; i < nbPoints; i++)
		{
			tmp[i] = inter.Interpolate(i);
		}
		return tmp;
	}


	public double[] evaluateNeville(int nbPoints, NevillePolynomialInterpolation inter)
	{
		double[] tmp = new double[nbPoints];
		for (int i = 0; i < nbPoints; i++)
		{
			tmp[i] = inter.Interpolate(i);
		}
		return tmp;
	}


	public double[] evaluatePolyCurve(double[] coef, int nbPoints)
	{
		double[] tmp = new double[nbPoints];
		for (int i =0; i<nbPoints;i++)
        {
			tmp[i] = Polynomial.Evaluate(i, coef);
		}
		return tmp;
	}


	public void setUpChart(int nbPoints, CartesianChart chartArg)
	{
		double[] Xaxis = new double[nbPoints];
		for (int j = 0; j < nbPoints; j++)
		{
			Xaxis[j] = j;
	}

		//chart.XAxes = Xaxis;
		// create series and populate them with data
		ISeries[] Series = new ISeries[]
		{


			new LineSeries<double>
			{
				Values = curves[0],
				Stroke = new SolidColorPaintTask(SKColors.White) { StrokeThickness = 4 },
				Fill = null,
				GeometryStroke = null,
				GeometryFill = null,
				Name = "Mire blanche",

			},
			new LineSeries<double>
			{
				Values = curves[1],
				Stroke = new SolidColorPaintTask(SKColors.LightGray){ StrokeThickness = 4 },
				Fill = null,
				GeometryStroke = null,
				GeometryFill = null,
				Name = "Mire gris claire",

			},
			new LineSeries<double>
			{
				Values = curves[2],
				Stroke = new SolidColorPaintTask(SKColors.DarkGray){ StrokeThickness = 4 },
				Fill = null,
				GeometryStroke = null,
				GeometryFill = null,
				Name = "Mire gris foncé",

			},
			new LineSeries<double>
			{
				Values = curves[3],
				Stroke = new SolidColorPaintTask(SKColors.Black){ StrokeThickness = 4 },
				Fill = null,
				GeometryStroke = null,
				GeometryFill = null,
				Name = "Mire noire",
			}
		};
		chartArg.Series = Series;
		List<Axis> XAxes = new List<Axis>();
		List<Axis> YAxes = new List<Axis>();
        Axis axisX = new Axis();
        axisX.Name = "Unité de brillance théorique";
		Axis axisY = new Axis();
		axisY.Name = "Maximum de dérivée";
		XAxes.Add(axisX);
		YAxes.Add(axisY);
		chartArg.XAxes = XAxes;
		chartArg.YAxes = YAxes;
	}

	public double evaluate(double x, double[] coef)
    {
		 return Polynomial.Evaluate(x, coef);

	}


	public void saveInterpolatorFile()
	{

		SaveFileDialog saveFileDialog1 = new SaveFileDialog();

		saveFileDialog1.Filter = "XML |*.xml |All Files|*.*";
		saveFileDialog1.Title = "Sauvegarder un calibrage";

		DialogResult result = saveFileDialog1.ShowDialog();
		if (result == DialogResult.OK)
		{
			XmlSerializer xs = new XmlSerializer(typeof(Interpolator));

			TextWriter txtWriter = new StreamWriter(saveFileDialog1.FileName);

			xs.Serialize(txtWriter, this);

			txtWriter.Close();
		}

	}

	public double[][] getBYKValue()
	{

		string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\data\\excelData\\BYK-MIRE.xlsx";
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
			double[] tmpArr = new double[28];
			for (int i = 16; i < dataTable.Rows.Count; i++)
			{
				tmpArr[i - 16] = Double.Parse(dataTable.Rows[i][15].ToString(), System.Globalization.CultureInfo.CurrentCulture);
			}


			double[][] bykValuesPattern = tmpArr
					.Select((s, i) => new { Value = s, Index = i })
					.GroupBy(x => x.Index / 7)
					.Select(grp => grp.Select(x => x.Value).ToArray())
					.ToArray();

			reader.Close();
			reader.Dispose();
			return bykValuesPattern;
		}

	}
}
