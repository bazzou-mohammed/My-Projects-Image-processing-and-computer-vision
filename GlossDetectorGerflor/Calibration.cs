using System;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Random;
using System.Collections.Generic;
using System.Linq;
using Emgu.CV.Util;
using System.Xml.Serialization;
using System.Xml;
using System.Text;
using MathNet.Numerics;


public class Calibration
{


	public float[] shiftCrosshair { get; set; }
	public float[] scaleCrosshair { get; set; }
	public string distribution { get; set; }
	public int nbLines { get; set; }
	public int[] indexLines { get; set; }
	public string colorspace { get; set; }
	public int widthPhotoCalibrated { get; set; }
	public int heightPhotoCalibrated { get; set; }
	public double[] resMeanDerivative { get; set; }
	public double[] resStdDerivative { get; set; }
	public Rectangle cropImageSelection;
	private string[] photoPaths;
	public event ProgressChangedEventHandler ProgressChanged;



	public int verticalBar { get; set; }
	public int horizontalBar { get; set; }
	public int horizontalShift { get; set; }
	public int verticalShift { get; set; }
	private Mat RowDebug;

	public Calibration(float[] shiftCrosshair, float[] scaleCrosshair, int nbLines, string[] photoPaths,
		string colorspace, string distribution, int verticalBar, int horizontalBar, int horizontalShift, int verticalShift)
	{
		this.shiftCrosshair = shiftCrosshair;
		this.scaleCrosshair = scaleCrosshair;
		this.photoPaths = photoPaths;
		this.nbLines = nbLines;
		this.colorspace = colorspace;
		this.distribution = distribution;

		this.verticalBar = verticalBar;
		this.horizontalBar = horizontalBar;
		this.horizontalShift = horizontalShift;
		this.verticalShift = verticalShift;

	}

	public Calibration() { }


	public void launch()
    {
		calculateBoundariesSector(shiftCrosshair, scaleCrosshair, photoPaths[0]);
		resStdDerivative = new double[photoPaths.Length];
		resMeanDerivative = calculMeanDerivative(calculMaxDerivatives(colorspace, distribution));
		GC.Collect();
	}

	public void calculateBoundariesSector(float[] shiftCrosshair, float[] scaleCrosshair, string pathToAPhoto)
	{
		Image imageAnalysed = Image.FromFile(pathToAPhoto);
		int widthImg = imageAnalysed.Width;
		int heightImg = imageAnalysed.Height;


		widthPhotoCalibrated = (int)Math.Round(scaleCrosshair[0] * widthImg);
		heightPhotoCalibrated = (int)Math.Round(scaleCrosshair[1] * heightImg);
		int horizontalShiftCrosshair = (int)Math.Round(shiftCrosshair[0] * widthImg);
		int verticalShiftCrosshair = (int)Math.Round(shiftCrosshair[1] * heightImg);
		cropImageSelection = new Rectangle(horizontalShiftCrosshair, verticalShiftCrosshair, widthPhotoCalibrated, heightPhotoCalibrated);
	}


	public void representArea(PictureBox imagera)
	{
		Mat imageUsedForIndx = cropAtRect(CvInvoke.Imread(photoPaths[0], Emgu.CV.CvEnum.ImreadModes.Unchanged), cropImageSelection);
		imagera.Image = imageUsedForIndx.ToBitmap();
	}

	public Mat cropAtRect(Mat img, Rectangle r)
	{
		Mat tmp = new Mat();
		try
		{
			tmp = new Mat(img, r);
		}

		catch (Exception ex)
		{
			// Could not load the image - probably related to Windows file system permissions.
			MessageBox.Show("Impossible de régler correctement le viseur. Les images sélectionnées n'ont pas tous les mêmes dimensions: " + ex.Message);
			tmp = img;
		}

		return tmp;
	}

	public Mat convertImage(string colorspace, Mat img) {
		Mat tmp = new Mat();
		
		if (colorspace == "HSV")
		{
			CvInvoke.CvtColor(img, tmp, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv);
			Mat[] channels = tmp.Split();
			return channels[2];
		}

		if (colorspace == "RGB(GRAY)")
		{
			CvInvoke.CvtColor(img, tmp, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);


			return tmp;
		}


		if (colorspace == "LAB")
		{
			CvInvoke.CvtColor(img, tmp, Emgu.CV.CvEnum.ColorConversion.Bgr2Lab);

			Mat[] channels = tmp.Split();
			return channels[0];
		}
		if (colorspace == "LUV")
		{
			CvInvoke.CvtColor(img, tmp, Emgu.CV.CvEnum.ColorConversion.Bgr2Luv);

			Mat[] channels = tmp.Split();
			return channels[0];

		}
		if (colorspace == "YCbCR")
		{
			CvInvoke.CvtColor(img, tmp, Emgu.CV.CvEnum.ColorConversion.Bgr2YCrCb);

			Mat[] channels = tmp.Split();
			return channels[0];
		}
		if (colorspace == "YUV")
		{
			CvInvoke.CvtColor(img, tmp, Emgu.CV.CvEnum.ColorConversion.Bgr2Yuv);

			Mat[] channels = tmp.Split();
			return channels[0];
		}
		return tmp;


	}


	public int GenerateRandomVariant(double mean, double deviation, System.Random rand)
	{

		double randNormal = (MathNet.Numerics.Distributions.Normal.Sample(rand, mean, deviation));
		int temps = (int)Math.Ceiling(randNormal);
		return temps;
	}


	public int[] calculIndexNormalDistribution(int width, float std, int nbLines)
	{
		System.Random rand = null;
		rand = rand ?? new Random();
		int[] tmp = new int[this.nbLines];
		int mean = (int)Math.Round((double)width / 2);

		for (int i = 0; i < nbLines; i++)
		{
			int indexLine = GenerateRandomVariant(mean, std, rand);
			if (indexLine >= width)
			{
				indexLine = width - 1;
			}
			if (indexLine < 0)
			{
				indexLine = 0;
			}
			tmp[i] = indexLine;
		}
		return tmp;
	}



	public int[] calculIndexRegulier(int width, int nbLines)
	{
		int[] tmp = new int[this.nbLines];


		for (int i = 0; i < nbLines; i++)
		{
			int indexLine = (int)Math.Floor( ((double)width / (double)this.nbLines) * (double)i);
			tmp[i] = indexLine;
		}
		return tmp;
	}





	public double[][] calculMaxDerivatives(string colorspace, string distribution)
	{

		double[][] maxDerivativesPhotos = new double[photoPaths.Length][];
		Mat imageUsefForIndx = cropAtRect(CvInvoke.Imread(photoPaths[0], Emgu.CV.CvEnum.ImreadModes.Color), cropImageSelection);
		if (distribution == "Régulière")
		{
			indexLines = calculIndexRegulier(imageUsefForIndx.Width, nbLines);
		}
		if (distribution == "Normale")
		{
			indexLines = calculIndexNormalDistribution(imageUsefForIndx.Width, imageUsefForIndx.Width / 2.0f, nbLines);
		}

		for (int j = 0;j<photoPaths.Length;j++)
		{
			int percentages = (int)Math.Round(((double)j / (double)photoPaths.Length) * 100);
			OnProgressChanged(percentages);
			double[] maxDerivartiveSinglePhoto = new double[nbLines];
			Mat data = new Mat();
			Mat imageUsed = cropAtRect(CvInvoke.Imread(photoPaths[j]), cropImageSelection);
			data = convertImage(colorspace, imageUsed);
			 // Mat.COL do not work , use of Mat.Row instead

			for (int w = 0; w < nbLines; w++)
			{
				double[] diff = systemArrayToArrayDiff(data, indexLines[w]);
				maxDerivartiveSinglePhoto[w] = diff.Max();
			}
			maxDerivativesPhotos[j] = maxDerivartiveSinglePhoto;

		}
		return maxDerivativesPhotos;
	}

	public double[] systemArrayToArrayDiff(Mat data,int indx)
	{
		double[] arr = new double[data.Size.Height];
		double[] test = new double[data.Size.Height];

		RowDebug = data.T().Row(indx);

		double[] diff = calculateGradientNumpyLike(RowDebug,1);

		return diff;
	}



	public double[] calculateGradientNumpyLike(Mat data, float dx)
	{
		int N = data.Size.Width;
		double[] gradData = new double[N];
		gradData[0] = (Convert.ToDouble(data.GetData().GetValue(0, 1)) - Convert.ToDouble(data.GetData().GetValue(0, 0))) / dx;
		gradData[N - 1] = (Convert.ToDouble(data.GetData().GetValue(0, N-1)) - Convert.ToDouble(data.GetData().GetValue(0, N-2))) / dx;
		for (int i = 1; i < (N - 1); i++)
		{
			gradData[i] = (Convert.ToDouble(data.GetData().GetValue(0, i+1)) - Convert.ToDouble(data.GetData().GetValue(0, i-1))) / (2 * dx);
		}

		return gradData;

	}


	public double[] calculMeanDerivative(double[][] input)
    {
		double[] temp = new double[input.GetLength(0)];
		for (int i =0; i< input.GetLength(0); i++)
		{
			double total = input[i].Sum();
			total = total / (double)nbLines;
			temp[i] = total;
			resStdDerivative[i] = getStandardDeviation(input[i],total);
		}
		return temp;
	}

	protected virtual void OnProgressChanged(int progress)
	{
		if (ProgressChanged != null)
		{
			ProgressChanged(this, new ProgressChangedEventArgs(progress, null));
		}
	}

	public void saveCalibrationFile()
    {

		SaveFileDialog saveFileDialog1 = new SaveFileDialog();

		saveFileDialog1.Filter = "XML |*.xml |All Files|*.*";
		saveFileDialog1.Title = "Sauvegarder un calibrage";

		DialogResult result = saveFileDialog1.ShowDialog();
		if (result == DialogResult.OK)
		{
			XmlSerializer xs = new XmlSerializer(typeof(Calibration));

			TextWriter txtWriter = new StreamWriter(saveFileDialog1.FileName);

			xs.Serialize(txtWriter, this);

			txtWriter.Close();
		}
		
	}
	private double getStandardDeviation(double[] maxGradientArray, double average)
	{
		double sumOfSquaresOfDifferences = maxGradientArray.Select(val => (val - average) * (val - average)).Sum();
		double sd = Math.Sqrt(sumOfSquaresOfDifferences / maxGradientArray.Length);
		return sd;
	}



}
