using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.IO;
using System.Xml.Linq;
using System.Collections.Specialized;

public class ColorDataStrorage
{
    public Dictionary<string, double[]> meanColor;
    public Dictionary<string, double[]> percentageColorsKM5;
    public Dictionary<string, double[]> predominanteColorCoefPattern;
    public Dictionary<string, double[][]> predominanteColors;
    public ColorDataStrorage()
	{
	}

    public ColorDataStrorage(Dictionary<string, double[]> couleurMoyenneInput,
        Dictionary<string, double[]> percentageColorKM5Input,
        Dictionary<string, double[][]> predominanteColorInput,
        Dictionary<string, double[]> predominanteColorCoefMireInput) {

        this.meanColor = couleurMoyenneInput;
        this.percentageColorsKM5 = percentageColorKM5Input;
        this.predominanteColors = predominanteColorInput;
        this.predominanteColorCoefPattern = predominanteColorCoefMireInput;

    }


}
