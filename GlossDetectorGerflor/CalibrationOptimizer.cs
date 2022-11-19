using GlossDetectorGerflor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Concurrent;
using System.Threading;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Text.Json;

public class CalibrationOptimizer
{
	public Calibration[] calibrationArray;
	public OptimizedParameters[] optimizedParamArray;
	public ColorAdjustment colorAdjust;
	private float[] shiftCrosshair;
	private float[] scaleCrosshair;
	private int verticalBar;
	private int horizontalBar;
	private int horizontalShift;
	private int verticalShift;
	private string[] photoPathsCal;
	private string[] fileTest;
	double[] bykValuesForTesting;
	string[] typeSamplesForTesting;
	public ProgressBar progressbar;
	SeizeValuesTestingForm bykValuesForm;
	public event EventHandler<OptimizedParameters> provideData;
	public CalibrationOptimizer(float[] shiftCrosshair, float[] scaleCrosshair, int verticalBar,
		int horizontalBar, int horizontalShift, int verticalShift, string[] photoPathsCal,
		ProgressBar progressbar, ColorAdjustment colorAdjust, ComboBox sampleCombo)
	{
		this.shiftCrosshair = shiftCrosshair;
		this.scaleCrosshair = scaleCrosshair;
		this.verticalBar = verticalBar;
		this.horizontalBar = horizontalBar;
		this.horizontalShift = horizontalShift;
		this.verticalShift = verticalShift;
		this.photoPathsCal = photoPathsCal;
		this.progressbar = progressbar;
		this.colorAdjust = colorAdjust;
		
		bykValuesForm = new SeizeValuesTestingForm(sampleCombo);

		bykValuesForm.Show();
		//bykValuesForm.cancel += bykFormCancelling;
		bykValuesForm.provideData += provideArrayBYKValues;
		

	}


	void provideArrayBYKValues(object sender, provideBYKArrayEvent e)
	{
		bykValuesForTesting = e.resBYK;
		typeSamplesForTesting = e.resType;
		bykValuesForm.Close();
		mainOptimizerMethod();
	}

	void bykFormCancelling(object sender, EventArgs e)
	{
		
	}

	public void mainOptimizerMethod()
	{
		DialogResult result = MessageBox.Show("L'Optimisation des paramètres prend énormément de temps, voulez vous continuer ?\n" +
			" Il vous faut préalablement sélectionner la zone de calcul à l'aide des barres de contrôles", "Warning",
		MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
		if (result == DialogResult.Yes)
		{
			fileTest = getFilesForTesting();
			//MultiThreadingCalibration(photoPathsCal);


			prepareCalibrationArray();
			StartTasksCalibration();
			prepareInterpolationArray();
			StartTaskGuFinder();
			findBestInterpolationAndCalibration();

		}
		else if (result == DialogResult.No)
		{
			return;
		}
		else if (result == DialogResult.Cancel)
		{
			return;
		}
	}



protected virtual void provideDataFire(OptimizedParameters e)
{
	EventHandler<OptimizedParameters> handler = provideData;
	if (handler != null)
	{
		handler(this, e);
	}
}
void StartTasksCalibration()
	{
		var tasks = new Task[calibrationArray.Length];
		for (int i = 0; i < calibrationArray.Length; i++)
		{
			var i2 = i;
			tasks[i2] = Task.Run(() =>
			{
				calibrationArray[i2].launch();
			});
		}

		Task.WaitAll(tasks);
	}



	void StartTaskGuFinder()
	{
		var tasks = new Task[optimizedParamArray.Length];
		for (int i = 0; i < optimizedParamArray.Length; i++)
		{
			var i2 = i;
			tasks[i2] = Task.Run(() =>
			{
				optimizedParamArray[i2].interp.initializeInterpolation(false);
				GuFinder guFinder = new GuFinder(optimizedParamArray[i2].interp, optimizedParamArray[i2].cal, colorAdjust, true);
				optimizedParamArray[i2].interp.sumStd = double.PositiveInfinity;
				string[] typeSamples = typeSamplesForTesting;
				double[] bykValues = bykValuesForTesting;
				optimizedParamArray[i2].interp.sumStd = guFinder.mesureSumStdTest(fileTest, typeSamples, bykValues);
			});
		}

		Task.WaitAll(tasks);
	}



	public void prepareCalibrationArray()
    {
		List<Calibration> lstCal = new List<Calibration>();
		int[] nbLinesArray = new int[] { 10, 25, 50, 75, 100, 125, 150, 175, 200 };
		string[] ColorSpaceArray = new string[] { "HSV", "RGB(GRAY)", "LAB", "YCbCR", "LUV", "YUV" };
		string[] distributionArray = new string[] { "Régulière", "Normale" };

		for (int i = 0; i < nbLinesArray.Length; i++)
		{
			for (int j = 0; j < ColorSpaceArray.Length; j++)
			{
				for (int k = 0; k < distributionArray.Length; k++)
				{
					Calibration calTmp = new Calibration(shiftCrosshair, scaleCrosshair, nbLinesArray[i], photoPathsCal,
						ColorSpaceArray[j], distributionArray[k], verticalBar, horizontalBar, horizontalShift, verticalShift);
					lstCal.Add(calTmp);
				}

			}
		}
		calibrationArray = lstCal.ToArray();
	}

	public void findBestInterpolationAndCalibration() {
		int indx=0;
		double sumStdGlobal = double.PositiveInfinity;

		for (int i=0; i < optimizedParamArray.Length; i++)
        {
			if(optimizedParamArray[i].interp.sumStd < sumStdGlobal)
            {
				sumStdGlobal = optimizedParamArray[i].interp.sumStd;
				indx = i;

			}
        }
		OptimizedParameters args = new OptimizedParameters();
		args = optimizedParamArray[indx];
		provideDataFire(args);
		saveTojsonFile(args);

	
	}


	public void prepareInterpolationArray()
	{
		List<OptimizedParameters> lstOptimizedParam = new List<OptimizedParameters>();
		string[] interpolationArray = new string[] { "Régression polynomiale", "CubicSpline Akima", "Interpolation Polynomiale de Néville", "Step Interpolation" };
		int[] orderPolymial = new int[] { 2, 3, 4, 5, 6, 7 };
		for (int i = 0; i < calibrationArray.Length; i++)
		{
			for (int j = 0; j < interpolationArray.Length; j++)
			{
				if (interpolationArray[j] == "Régression polynomiale")
				{
					for (int deg = 0; deg < orderPolymial.Length; deg++)
					{

						Interpolator interpolator = new Interpolator(calibrationArray[i].resMeanDerivative, interpolationArray[j], 95, true, orderPolymial[deg]);
						OptimizedParameters optiTmp = new OptimizedParameters(calibrationArray[i],interpolator);
						lstOptimizedParam.Add(optiTmp);

					}
				}
				else
				{
					Interpolator interpolator = new Interpolator(calibrationArray[i].resMeanDerivative, interpolationArray[j], 95, true);
					OptimizedParameters optiTmp = new OptimizedParameters(calibrationArray[i], interpolator);
					lstOptimizedParam.Add(optiTmp);
				}
			}
		}
		optimizedParamArray = lstOptimizedParam.ToArray();
	}


	public string[] getFilesForTesting()
    {
		string[] pathTestImages;
		OpenFileDialog photosTestMeasurementsDialog = new OpenFileDialog();
		photosTestMeasurementsDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
		photosTestMeasurementsDialog.Multiselect = true;
		photosTestMeasurementsDialog.Title = "Sélectionner les échantillons de test";
		DialogResult result = photosTestMeasurementsDialog.ShowDialog();
		if (result == DialogResult.OK)
		{
			pathTestImages = photosTestMeasurementsDialog.FileNames;

			return pathTestImages;
		}

		return new string[0] { };
	}

	public void saveTojsonFile(OptimizedParameters opti)
	{
		
		SaveFileDialog saveFileDialog1 = new SaveFileDialog();	
		saveFileDialog1.Filter = "json|*.json |All Files|*.*";
		saveFileDialog1.Title = "Sauvegarder une interpolation";
		DialogResult result = saveFileDialog1.ShowDialog();
		if (result == DialogResult.OK)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			string jsonString = System.Text.Json.JsonSerializer.Serialize(opti, options);
			File.WriteAllText(saveFileDialog1.FileName, jsonString);
		}

	}

	[Serializable]
	public struct OptimizedParameters
    {
		public Interpolator interp { get; set; }
		public Calibration cal { get; set; }
		public OptimizedParameters(Calibration cal, Interpolator interp)
        {
			this.cal = cal;
			this.interp = interp;
        }
    }
}
