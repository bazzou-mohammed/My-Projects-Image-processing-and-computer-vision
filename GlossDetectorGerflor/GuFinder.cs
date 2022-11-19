using Emgu.CV;
using GlossDetectorGerflor;
using MathNet.Numerics;
using MathNet.Numerics.Interpolation;
using MathNet.Numerics.RootFinding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

public class GuFinder
{

	public double[][] results;
	public String[][] nameAndType;
	public bool rrTest;
	public ColorAdjustment colorAdjust;
	public double[] bykValueSamples;
	public double[] absUncertainty;
	public double[] relativeUncertaintyPercent;

	public Calibration calibration;
	private Interpolator interpolator;
	private Polynomial[] poly;
	private double[][] linearCurves;


	public GuFinder(Interpolator interpolator, Calibration calibration, ColorAdjustment colorAdjust, bool rrTest)
	{
		this.calibration = calibration;
		this.interpolator = interpolator;
		this.colorAdjust = colorAdjust;
		this.poly = interpolator.polynomialArray;
		this.linearCurves = interpolator.curvesLinear;
		this.colorAdjust = colorAdjust;
		this.rrTest = rrTest;
	}

	public double[][] analyzePhotos(string[] paths, ComboBox sampleCombo, Label resultLabel)
	{
		results = new double[paths.Length][];
		nameAndType = new string[paths.Length][];
		for (int i = 0; i < paths.Length; i++)
		{
			results[i] = getUBFromSample(paths[i], sampleCombo.SelectedValue.ToString());
			nameAndType[i] = new string[2] { Path.GetFileName(paths[i]), sampleCombo.SelectedValue.ToString() };
			resultLabel.Text = "UB mesuré: " + results[i][0] + " UB";
		}
		return results;
	}

	public void mesureStdOneTypeSample(string[] pathPhotos, ComboBox sampleCombo)
	{

		bykValueSamples = new double[pathPhotos.Length];
		absUncertainty = new double[pathPhotos.Length];
		relativeUncertaintyPercent = new double[pathPhotos.Length];
		nameAndType = new string[pathPhotos.Length][];
		// MAKE SOME UPDATE HERE
		for (int w = 0; w < bykValueSamples.Length; w++)
		{
			bykValueSamples[w] = 3.6;
		}

		results = new double[pathPhotos.Length][];
		for (int i = 0; i < pathPhotos.Length; i++)
		{
			results[i] = getUBFromSample(pathPhotos[i], sampleCombo.SelectedValue.ToString());
			absUncertainty[i] = Math.Abs(bykValueSamples[i] - results[i][0]);
			relativeUncertaintyPercent[i] = absUncertainty[i] / bykValueSamples[i] * 100;
			nameAndType[i] = new string[2] { Path.GetFileName(pathPhotos[i]), sampleCombo.SelectedValue.ToString() };
		}

	}
	public double[] getUBFromSample(string pathPhoto, string typeSample)
	{
		double res = 0;
		double[] maxDerivativeandStd = calculDerivatifSample(pathPhoto);

		for (int i = 0; i < 4; i++)
		{
			if (interpolator.interpolationType == "Régression polynomiale")
            {
				double UBlinear = getLinearResult(maxDerivativeandStd[0], interpolator.curvesLinear[i],i);
				poly[i].Coefficients[0] = poly[i].Coefficients[0] - maxDerivativeandStd[0];
				Complex[] result = FindRoots.Polynomial(poly[i]);
				poly[i].Coefficients[0] = poly[i].Coefficients[0] + maxDerivativeandStd[0];
				res += findingBestResult(result, UBlinear) * colorAdjust.predominanteColorCoefPattern.GetValueOrDefault(typeSample)[i];
			}
			else{
				double UBlinear = getLinearResult(maxDerivativeandStd[0], interpolator.curvesLinear[i], i);
				double ubResWithoutColorAd = getResultFromCurve(maxDerivativeandStd[0], UBlinear, interpolator.curves[i], i);
				double colorAd = colorAdjust.predominanteColorCoefPattern.GetValueOrDefault(typeSample)[i];
				res += ubResWithoutColorAd * colorAd;

			}

		}
		return new double[] { Math.Round(res, 2), maxDerivativeandStd[1] };
	}

	private double getStandardDeviation(double[] maxGradientArray, double average)
	{
		double sumOfSquaresOfDifferences = maxGradientArray.Select(val => (val - average) * (val - average)).Sum();
		double sd = Math.Sqrt(sumOfSquaresOfDifferences / maxGradientArray.Length);
		return sd;
	}



	private double getResultFromCurve(double derivative, double derivativeLinear, double[] curve, int indexPattern ) {
		double res;
		//TO DO : IF MANY ROOTS ,FIND THE BEST
		double[] curve_Modif = curve.Select(x => x - derivative).ToArray();
		int  nearestIndex = curve_Modif.Select((x, i) => new { Diff = Math.Abs(x - 0), Index = i }).Aggregate((x, y) => x.Diff < y.Diff ? x : y).Index;
		res = (nearestIndex * interpolator.bykValue[indexPattern].Max() )/ interpolator.nbPoints;
		return res;
	}


	private double getLinearResult(double derivative, double[] curve, int indexPattern)
	{
		double res;
		//TO DO : IF MANY ROOTS ,FIND THE BEST
		double[] curve_Modif = curve.Select(x => x - derivative).ToArray();
		int nearestIndex = curve_Modif.Select((x, i) => new { Diff = Math.Abs(x - 0), Index = i }).Aggregate((x, y) => x.Diff < y.Diff ? x : y).Index;
		res = (nearestIndex * interpolator.bykValue[indexPattern].Max()) / interpolator.nbPoints;
		return res;
	}

	private double findingBestResult(Complex[] result, double linearIterpolationResult)
	{
		List<Double> tmp = new List<Double>();
		for (int i = 0; i < result.Length; i++)
		{
			if (result[i].Imaginary == 0)
			{
				tmp.Add(result[i].Real);
			}
			if (result[i].Imaginary < 5 && result[i].Real > 0 && result[i].Real < 100)
			{
				tmp.Add(result[i].Real);
			}

		}
		if (tmp.Count == 0)
			tmp.Add(0);
		int indx = tmp.IndexOf(tmp.Aggregate((x, y) => Math.Abs(x - linearIterpolationResult) < Math.Abs(y - linearIterpolationResult) ? x : y));
		return tmp[indx];
	}

	public double[] calculDerivatifSample(string pathPhoto)
	{
		if (calibration.cropImageSelection.Width != calibration.widthPhotoCalibrated)
        {
			calibration.calculateBoundariesSector(calibration.shiftCrosshair, calibration.scaleCrosshair, pathPhoto);
        }
		
		
		double[] maxDerivativeSample = new double[calibration.nbLines];
		Mat data = new Mat();
		Mat imageUsed = calibration.cropAtRect(CvInvoke.Imread(pathPhoto), calibration.cropImageSelection);
		data = calibration.convertImage(calibration.colorspace, imageUsed);
		for (int w = 0; w < calibration.nbLines; w++)
		{
			double[] diff = calibration.systemArrayToArrayDiff(data, calibration.indexLines[w]);
			maxDerivativeSample[w] = diff.Max();
		}

		double[] total = { 0, 0 };
		total[0] = maxDerivativeSample.Sum();
		total[0] = total[0] / (double)calibration.nbLines;
		total[1] = getStandardDeviation(maxDerivativeSample, total[0]);
		return total;
	}


	public double mesureSumStdTest(string[] pathPhotos, string[] typeSample, double[] bykValues)
	{

		double sum = 0;
		absUncertainty = new double[pathPhotos.Length];
		relativeUncertaintyPercent = new double[pathPhotos.Length];


		results = new double[pathPhotos.Length][];
		for (int i = 0; i < pathPhotos.Length; i++)
		{
			results[i] = getUBFromSample(pathPhotos[i],typeSample[i]);
			absUncertainty[i] = Math.Abs(bykValues[i] - results[i][0]);
			relativeUncertaintyPercent[i] = absUncertainty[i] / bykValues[i] * 100;
			sum += relativeUncertaintyPercent[i];
		}
		return sum;
	}

}
