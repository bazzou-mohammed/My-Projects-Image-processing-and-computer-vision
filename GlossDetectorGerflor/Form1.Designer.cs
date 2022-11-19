
namespace GlossDetectorGerflor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sampleCombo = new System.Windows.Forms.ComboBox();
            this.colorspace = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.analyseButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.calibrageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utiliserUnCalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouvelleCalibrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.créerUneCalibrationÀLaideDuneCaméraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerUneInterpolationIncluLeCalibrageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerDesImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerUnDossierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banqueDéchantillonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnÉchantillonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retirerUnÉchantillonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderUneBanqueDéchantillonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerUneBanqueDéchantillonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.périphériquesEtCamérasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connecterUneCaméraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sélectionnerEspaceDeTravailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changerCouleurDuViseurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blancToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rougeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valeurBYKPourLesMiresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valeurBYKToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valeurThéoriqueNCSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testsRRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.effectuerLeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.désactiverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optimiseurDeParamètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.imageArea = new System.Windows.Forms.PictureBox();
            this.calibrationStatusLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.clearBucket = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.verticalBar = new System.Windows.Forms.TrackBar();
            this.horizontalBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.crossHair = new System.Windows.Forms.PictureBox();
            this.hideCrosshairCheckbox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.horizontalShift = new System.Windows.Forms.TrackBar();
            this.verticalShift = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.nbLines = new System.Windows.Forms.TrackBar();
            this.nbLinesLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.distribution = new System.Windows.Forms.ComboBox();
            this.interpolationCombo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.bgw_calibration = new System.ComponentModel.BackgroundWorker();
            this.deleteCalibrationButton = new System.Windows.Forms.Button();
            this.cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.resultLabel = new System.Windows.Forms.Label();
            this.echantillonsType = new System.Windows.Forms.Label();
            this.pictureMeanColor = new System.Windows.Forms.PictureBox();
            this.MeanColor = new System.Windows.Forms.Label();
            this.PictureDominante1 = new System.Windows.Forms.PictureBox();
            this.PictureDominante2 = new System.Windows.Forms.PictureBox();
            this.PictureDominante3 = new System.Windows.Forms.PictureBox();
            this.PictureDominante4 = new System.Windows.Forms.PictureBox();
            this.PictureDominante5 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.curvesChart = new System.Windows.Forms.CheckBox();
            this.exportExcel = new System.Windows.Forms.CheckBox();
            this.degrePolyCombo = new System.Windows.Forms.ComboBox();
            this.degreLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossHair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalShift)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMeanColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDominante1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDominante2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDominante3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDominante4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDominante5)).BeginInit();
            this.SuspendLayout();
            // 
            // sampleCombo
            // 
            this.sampleCombo.Enabled = false;
            this.sampleCombo.FormattingEnabled = true;
            this.sampleCombo.Location = new System.Drawing.Point(907, 296);
            this.sampleCombo.Name = "sampleCombo";
            this.sampleCombo.Size = new System.Drawing.Size(174, 23);
            this.sampleCombo.TabIndex = 39;
            this.sampleCombo.SelectedIndexChanged += new System.EventHandler(this.echantillonCombo_SelectedIndexChanged);
            // 
            // colorspace
            // 
            this.colorspace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colorspace.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.colorspace.Items.AddRange(new object[] {
            "HSV",
            "RGB(GRAY)",
            "LAB",
            "YCbCR",
            "LUV",
            "YUV"});
            this.colorspace.Location = new System.Drawing.Point(742, 33);
            this.colorspace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorspace.Name = "colorspace";
            this.colorspace.Size = new System.Drawing.Size(148, 23);
            this.colorspace.TabIndex = 5;
            this.colorspace.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(200, 95);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(689, 22);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // analyseButton
            // 
            this.analyseButton.Enabled = false;
            this.analyseButton.Location = new System.Drawing.Point(201, 66);
            this.analyseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.analyseButton.Name = "analyseButton";
            this.analyseButton.Size = new System.Drawing.Size(82, 22);
            this.analyseButton.TabIndex = 1;
            this.analyseButton.Text = "Analyse";
            this.analyseButton.UseVisualStyleBackColor = true;
            this.analyseButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AllowDrop = true;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calibrageToolStripMenuItem,
            this.chargerImagesToolStripMenuItem,
            this.banqueDéchantillonsToolStripMenuItem,
            this.paramètresToolStripMenuItem,
            this.testsRRToolStripMenuItem,
            this.optimiseurDeParamètresToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1092, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // calibrageToolStripMenuItem
            // 
            this.calibrageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utiliserUnCalToolStripMenuItem,
            this.nouvelleCalibrationToolStripMenuItem,
            this.créerUneCalibrationÀLaideDuneCaméraToolStripMenuItem,
            this.chargerUneInterpolationIncluLeCalibrageToolStripMenuItem});
            this.calibrageToolStripMenuItem.Name = "calibrageToolStripMenuItem";
            this.calibrageToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.calibrageToolStripMenuItem.Text = "Calibrage";
            this.calibrageToolStripMenuItem.Click += new System.EventHandler(this.calibrageToolStripMenuItem_Click);
            // 
            // utiliserUnCalToolStripMenuItem
            // 
            this.utiliserUnCalToolStripMenuItem.Name = "utiliserUnCalToolStripMenuItem";
            this.utiliserUnCalToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.utiliserUnCalToolStripMenuItem.Text = "Charger un calibrage à partir de photos existantes";
            this.utiliserUnCalToolStripMenuItem.Click += new System.EventHandler(this.utiliserUnCalToolStripMenuItem_Click);
            // 
            // nouvelleCalibrationToolStripMenuItem
            // 
            this.nouvelleCalibrationToolStripMenuItem.Name = "nouvelleCalibrationToolStripMenuItem";
            this.nouvelleCalibrationToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.nouvelleCalibrationToolStripMenuItem.Text = "Charger un calibrage à partir d\'un fichier XML";
            this.nouvelleCalibrationToolStripMenuItem.Click += new System.EventHandler(this.nouvelleCalibrationToolStripMenuItem_Click);
            // 
            // créerUneCalibrationÀLaideDuneCaméraToolStripMenuItem
            // 
            this.créerUneCalibrationÀLaideDuneCaméraToolStripMenuItem.Enabled = false;
            this.créerUneCalibrationÀLaideDuneCaméraToolStripMenuItem.Name = "créerUneCalibrationÀLaideDuneCaméraToolStripMenuItem";
            this.créerUneCalibrationÀLaideDuneCaméraToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.créerUneCalibrationÀLaideDuneCaméraToolStripMenuItem.Text = "Créer un calibrage à l\'aide d\'une caméra";
            // 
            // chargerUneInterpolationIncluLeCalibrageToolStripMenuItem
            // 
            this.chargerUneInterpolationIncluLeCalibrageToolStripMenuItem.Name = "chargerUneInterpolationIncluLeCalibrageToolStripMenuItem";
            this.chargerUneInterpolationIncluLeCalibrageToolStripMenuItem.Size = new System.Drawing.Size(442, 22);
            this.chargerUneInterpolationIncluLeCalibrageToolStripMenuItem.Text = "Charger une interpolation à partir d\'un fichier JSON ( Calibrage inclus)";
            this.chargerUneInterpolationIncluLeCalibrageToolStripMenuItem.Click += new System.EventHandler(this.chargerUneInterpolationIncluLeCalibrageToolStripMenuItem_Click);
            // 
            // chargerImagesToolStripMenuItem
            // 
            this.chargerImagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chargerDesImagesToolStripMenuItem,
            this.chargerUnDossierToolStripMenuItem});
            this.chargerImagesToolStripMenuItem.Name = "chargerImagesToolStripMenuItem";
            this.chargerImagesToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.chargerImagesToolStripMenuItem.Text = "Charger des images";
            this.chargerImagesToolStripMenuItem.Click += new System.EventHandler(this.chargerImagesToolStripMenuItem_Click);
            // 
            // chargerDesImagesToolStripMenuItem
            // 
            this.chargerDesImagesToolStripMenuItem.Name = "chargerDesImagesToolStripMenuItem";
            this.chargerDesImagesToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.chargerDesImagesToolStripMenuItem.Text = "Charger des images";
            this.chargerDesImagesToolStripMenuItem.Click += new System.EventHandler(this.chargerDesImagesToolStripMenuItem_Click);
            // 
            // chargerUnDossierToolStripMenuItem
            // 
            this.chargerUnDossierToolStripMenuItem.Name = "chargerUnDossierToolStripMenuItem";
            this.chargerUnDossierToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.chargerUnDossierToolStripMenuItem.Text = "Charger un dossier";
            this.chargerUnDossierToolStripMenuItem.Click += new System.EventHandler(this.chargerUnDossierToolStripMenuItem_Click);
            // 
            // banqueDéchantillonsToolStripMenuItem
            // 
            this.banqueDéchantillonsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUnÉchantillonToolStripMenuItem,
            this.retirerUnÉchantillonToolStripMenuItem,
            this.sauvegarderUneBanqueDéchantillonsToolStripMenuItem,
            this.chargerUneBanqueDéchantillonsToolStripMenuItem});
            this.banqueDéchantillonsToolStripMenuItem.Name = "banqueDéchantillonsToolStripMenuItem";
            this.banqueDéchantillonsToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.banqueDéchantillonsToolStripMenuItem.Text = "Banque d\'échantillons";
            // 
            // ajouterUnÉchantillonToolStripMenuItem
            // 
            this.ajouterUnÉchantillonToolStripMenuItem.Name = "ajouterUnÉchantillonToolStripMenuItem";
            this.ajouterUnÉchantillonToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.ajouterUnÉchantillonToolStripMenuItem.Text = "Ajouter un échantillon";
            // 
            // retirerUnÉchantillonToolStripMenuItem
            // 
            this.retirerUnÉchantillonToolStripMenuItem.Name = "retirerUnÉchantillonToolStripMenuItem";
            this.retirerUnÉchantillonToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.retirerUnÉchantillonToolStripMenuItem.Text = "Retirer un échantillon";
            // 
            // sauvegarderUneBanqueDéchantillonsToolStripMenuItem
            // 
            this.sauvegarderUneBanqueDéchantillonsToolStripMenuItem.Name = "sauvegarderUneBanqueDéchantillonsToolStripMenuItem";
            this.sauvegarderUneBanqueDéchantillonsToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.sauvegarderUneBanqueDéchantillonsToolStripMenuItem.Text = "Sauvegarder une banque d\'échantillons";
            this.sauvegarderUneBanqueDéchantillonsToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderUneBanqueDéchantillonsToolStripMenuItem_Click);
            // 
            // chargerUneBanqueDéchantillonsToolStripMenuItem
            // 
            this.chargerUneBanqueDéchantillonsToolStripMenuItem.Name = "chargerUneBanqueDéchantillonsToolStripMenuItem";
            this.chargerUneBanqueDéchantillonsToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.chargerUneBanqueDéchantillonsToolStripMenuItem.Text = "Charger une banque d\'échantillons";
            this.chargerUneBanqueDéchantillonsToolStripMenuItem.Click += new System.EventHandler(this.chargerUneBanqueDéchantillonsToolStripMenuItem_Click);
            // 
            // paramètresToolStripMenuItem
            // 
            this.paramètresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.périphériquesEtCamérasToolStripMenuItem,
            this.sélectionnerEspaceDeTravailToolStripMenuItem,
            this.changerCouleurDuViseurToolStripMenuItem,
            this.valeurBYKPourLesMiresToolStripMenuItem});
            this.paramètresToolStripMenuItem.Name = "paramètresToolStripMenuItem";
            this.paramètresToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.paramètresToolStripMenuItem.Text = "Paramètres";
            // 
            // périphériquesEtCamérasToolStripMenuItem
            // 
            this.périphériquesEtCamérasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connecterUneCaméraToolStripMenuItem});
            this.périphériquesEtCamérasToolStripMenuItem.Name = "périphériquesEtCamérasToolStripMenuItem";
            this.périphériquesEtCamérasToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.périphériquesEtCamérasToolStripMenuItem.Text = "Périphériques et caméras";
            // 
            // connecterUneCaméraToolStripMenuItem
            // 
            this.connecterUneCaméraToolStripMenuItem.Name = "connecterUneCaméraToolStripMenuItem";
            this.connecterUneCaméraToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.connecterUneCaméraToolStripMenuItem.Text = "Connecter une caméra";
            this.connecterUneCaméraToolStripMenuItem.Click += new System.EventHandler(this.connecterUneCaméraToolStripMenuItem_Click);
            // 
            // sélectionnerEspaceDeTravailToolStripMenuItem
            // 
            this.sélectionnerEspaceDeTravailToolStripMenuItem.Enabled = false;
            this.sélectionnerEspaceDeTravailToolStripMenuItem.Name = "sélectionnerEspaceDeTravailToolStripMenuItem";
            this.sélectionnerEspaceDeTravailToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.sélectionnerEspaceDeTravailToolStripMenuItem.Text = "Sélectionner espace de travail";
            // 
            // changerCouleurDuViseurToolStripMenuItem
            // 
            this.changerCouleurDuViseurToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blancToolStripMenuItem,
            this.rougeToolStripMenuItem,
            this.vertToolStripMenuItem});
            this.changerCouleurDuViseurToolStripMenuItem.Name = "changerCouleurDuViseurToolStripMenuItem";
            this.changerCouleurDuViseurToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.changerCouleurDuViseurToolStripMenuItem.Text = "Changer couleur du viseur";
            // 
            // blancToolStripMenuItem
            // 
            this.blancToolStripMenuItem.Name = "blancToolStripMenuItem";
            this.blancToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.blancToolStripMenuItem.Text = "Blanc";
            this.blancToolStripMenuItem.Click += new System.EventHandler(this.blancToolStripMenuItem_Click);
            // 
            // rougeToolStripMenuItem
            // 
            this.rougeToolStripMenuItem.Name = "rougeToolStripMenuItem";
            this.rougeToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.rougeToolStripMenuItem.Text = "Rouge";
            this.rougeToolStripMenuItem.Click += new System.EventHandler(this.rougeToolStripMenuItem_Click);
            // 
            // vertToolStripMenuItem
            // 
            this.vertToolStripMenuItem.Name = "vertToolStripMenuItem";
            this.vertToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.vertToolStripMenuItem.Text = "Vert";
            this.vertToolStripMenuItem.Click += new System.EventHandler(this.vertToolStripMenuItem_Click);
            // 
            // valeurBYKPourLesMiresToolStripMenuItem
            // 
            this.valeurBYKPourLesMiresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.valeurBYKToolStripMenuItem,
            this.valeurThéoriqueNCSToolStripMenuItem});
            this.valeurBYKPourLesMiresToolStripMenuItem.Name = "valeurBYKPourLesMiresToolStripMenuItem";
            this.valeurBYKPourLesMiresToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.valeurBYKPourLesMiresToolStripMenuItem.Text = "Valeur BYK pour les mires";
            // 
            // valeurBYKToolStripMenuItem
            // 
            this.valeurBYKToolStripMenuItem.Name = "valeurBYKToolStripMenuItem";
            this.valeurBYKToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.valeurBYKToolStripMenuItem.Text = "Valeur BYK";
            this.valeurBYKToolStripMenuItem.Click += new System.EventHandler(this.valeurBYKToolStripMenuItem_Click);
            // 
            // valeurThéoriqueNCSToolStripMenuItem
            // 
            this.valeurThéoriqueNCSToolStripMenuItem.Name = "valeurThéoriqueNCSToolStripMenuItem";
            this.valeurThéoriqueNCSToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.valeurThéoriqueNCSToolStripMenuItem.Text = "Valeur théorique NCS";
            this.valeurThéoriqueNCSToolStripMenuItem.Click += new System.EventHandler(this.valeurThéoriqueNCSToolStripMenuItem_Click);
            // 
            // testsRRToolStripMenuItem
            // 
            this.testsRRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.effectuerLeTestToolStripMenuItem});
            this.testsRRToolStripMenuItem.Name = "testsRRToolStripMenuItem";
            this.testsRRToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.testsRRToolStripMenuItem.Text = "Tests RR";
            // 
            // effectuerLeTestToolStripMenuItem
            // 
            this.effectuerLeTestToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activerToolStripMenuItem,
            this.désactiverToolStripMenuItem});
            this.effectuerLeTestToolStripMenuItem.Name = "effectuerLeTestToolStripMenuItem";
            this.effectuerLeTestToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.effectuerLeTestToolStripMenuItem.Text = "Effectuer le test";
            this.effectuerLeTestToolStripMenuItem.Click += new System.EventHandler(this.effectuerLeTestToolStripMenuItem_Click);
            // 
            // activerToolStripMenuItem
            // 
            this.activerToolStripMenuItem.Name = "activerToolStripMenuItem";
            this.activerToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.activerToolStripMenuItem.Text = "Activer";
            this.activerToolStripMenuItem.Click += new System.EventHandler(this.activerToolStripMenuItem_Click);
            // 
            // désactiverToolStripMenuItem
            // 
            this.désactiverToolStripMenuItem.Name = "désactiverToolStripMenuItem";
            this.désactiverToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.désactiverToolStripMenuItem.Text = "Désactiver";
            this.désactiverToolStripMenuItem.Click += new System.EventHandler(this.désactiverToolStripMenuItem_Click);
            // 
            // optimiseurDeParamètresToolStripMenuItem
            // 
            this.optimiseurDeParamètresToolStripMenuItem.Name = "optimiseurDeParamètresToolStripMenuItem";
            this.optimiseurDeParamètresToolStripMenuItem.Size = new System.Drawing.Size(156, 20);
            this.optimiseurDeParamètresToolStripMenuItem.Text = "Optimiseur de paramètres";
            this.optimiseurDeParamètresToolStripMenuItem.Click += new System.EventHandler(this.optimiseurDeParamètresToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(600, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Espace colorimétrique";
            // 
            // imageArea
            // 
            this.imageArea.Image = global::GlossDetectorGerflor.Properties.Resources.gerflor;
            this.imageArea.Location = new System.Drawing.Point(201, 125);
            this.imageArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageArea.Name = "imageArea";
            this.imageArea.Size = new System.Drawing.Size(689, 411);
            this.imageArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageArea.TabIndex = 11;
            this.imageArea.TabStop = false;
            this.imageArea.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // calibrationStatusLabel
            // 
            this.calibrationStatusLabel.AutoSize = true;
            this.calibrationStatusLabel.Location = new System.Drawing.Point(748, 542);
            this.calibrationStatusLabel.Name = "calibrationStatusLabel";
            this.calibrationStatusLabel.Size = new System.Drawing.Size(141, 15);
            this.calibrationStatusLabel.TabIndex = 13;
            this.calibrationStatusLabel.Text = "Calibration non effectuée";
            this.calibrationStatusLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 35);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 43);
            this.button2.TabIndex = 14;
            this.button2.Text = "Prendre une photo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // clearBucket
            // 
            this.clearBucket.Location = new System.Drawing.Point(12, 494);
            this.clearBucket.Name = "clearBucket";
            this.clearBucket.Size = new System.Drawing.Size(169, 44);
            this.clearBucket.TabIndex = 15;
            this.clearBucket.Text = "Vider le panier";
            this.clearBucket.UseVisualStyleBackColor = true;
            this.clearBucket.Click += new System.EventHandler(this.button3_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 84);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(169, 393);
            this.listView1.TabIndex = 18;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // verticalBar
            // 
            this.verticalBar.Location = new System.Drawing.Point(896, 46);
            this.verticalBar.Maximum = 100;
            this.verticalBar.Minimum = -100;
            this.verticalBar.Name = "verticalBar";
            this.verticalBar.Size = new System.Drawing.Size(184, 45);
            this.verticalBar.TabIndex = 19;
            this.verticalBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // horizontalBar
            // 
            this.horizontalBar.Location = new System.Drawing.Point(896, 97);
            this.horizontalBar.Maximum = 150;
            this.horizontalBar.Minimum = -90;
            this.horizontalBar.Name = "horizontalBar";
            this.horizontalBar.Size = new System.Drawing.Size(184, 45);
            this.horizontalBar.TabIndex = 20;
            this.horizontalBar.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(896, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Réglage hauteur du viseur";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(896, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Réglage épaisseur du viseur";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // crossHair
            // 
            this.crossHair.BackColor = System.Drawing.Color.Transparent;
            this.crossHair.Image = global::GlossDetectorGerflor.Properties.Resources.viewFinderRed;
            this.crossHair.Location = new System.Drawing.Point(453, 296);
            this.crossHair.Name = "crossHair";
            this.crossHair.Size = new System.Drawing.Size(178, 90);
            this.crossHair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.crossHair.TabIndex = 23;
            this.crossHair.TabStop = false;
            this.crossHair.Visible = false;
            this.crossHair.Click += new System.EventHandler(this.pictureBox1_Click_2);
            // 
            // hideCrosshairCheckbox
            // 
            this.hideCrosshairCheckbox.AutoSize = true;
            this.hideCrosshairCheckbox.Checked = true;
            this.hideCrosshairCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideCrosshairCheckbox.Location = new System.Drawing.Point(289, 67);
            this.hideCrosshairCheckbox.Name = "hideCrosshairCheckbox";
            this.hideCrosshairCheckbox.Size = new System.Drawing.Size(109, 19);
            this.hideCrosshairCheckbox.TabIndex = 24;
            this.hideCrosshairCheckbox.Text = "Cacher le viseur";
            this.hideCrosshairCheckbox.UseVisualStyleBackColor = true;
            this.hideCrosshairCheckbox.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(896, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "Réglage décalage horizontal";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // horizontalShift
            // 
            this.horizontalShift.Location = new System.Drawing.Point(896, 149);
            this.horizontalShift.Maximum = 100;
            this.horizontalShift.Minimum = -100;
            this.horizontalShift.Name = "horizontalShift";
            this.horizontalShift.Size = new System.Drawing.Size(184, 45);
            this.horizontalShift.TabIndex = 26;
            this.horizontalShift.Scroll += new System.EventHandler(this.trackBar1_Scroll_1);
            // 
            // verticalShift
            // 
            this.verticalShift.Location = new System.Drawing.Point(896, 200);
            this.verticalShift.Maximum = 50;
            this.verticalShift.Minimum = -50;
            this.verticalShift.Name = "verticalShift";
            this.verticalShift.Size = new System.Drawing.Size(184, 45);
            this.verticalShift.TabIndex = 27;
            this.verticalShift.Scroll += new System.EventHandler(this.trackBar2_Scroll_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(896, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Réglage décalage vertical";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // nbLines
            // 
            this.nbLines.Location = new System.Drawing.Point(412, 46);
            this.nbLines.Maximum = 250;
            this.nbLines.Minimum = 10;
            this.nbLines.Name = "nbLines";
            this.nbLines.Size = new System.Drawing.Size(184, 45);
            this.nbLines.TabIndex = 29;
            this.nbLines.Value = 75;
            this.nbLines.Scroll += new System.EventHandler(this.nbLignes_Scroll);
            // 
            // nbLinesLabel
            // 
            this.nbLinesLabel.AutoSize = true;
            this.nbLinesLabel.Location = new System.Drawing.Point(412, 28);
            this.nbLinesLabel.Name = "nbLinesLabel";
            this.nbLinesLabel.Size = new System.Drawing.Size(160, 15);
            this.nbLinesLabel.TabIndex = 30;
            this.nbLinesLabel.Text = "Nombre de lignes de calcul : ";
            this.nbLinesLabel.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(623, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 15);
            this.label9.TabIndex = 31;
            this.label9.Text = "Distribution des lignes";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // distribution
            // 
            this.distribution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.distribution.FormattingEnabled = true;
            this.distribution.Items.AddRange(new object[] {
            "Régulière",
            "Normale"});
            this.distribution.Location = new System.Drawing.Point(766, 67);
            this.distribution.Name = "distribution";
            this.distribution.Size = new System.Drawing.Size(123, 23);
            this.distribution.TabIndex = 32;
            this.distribution.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged_1);
            // 
            // interpolationCombo
            // 
            this.interpolationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.interpolationCombo.Enabled = false;
            this.interpolationCombo.FormattingEnabled = true;
            this.interpolationCombo.Items.AddRange(new object[] {
            "Régression polynomiale",
            "CubicSpline Akima",
            "Interpolation Polynomiale de Néville",
            "Step Interpolation"});
            this.interpolationCombo.Location = new System.Drawing.Point(907, 414);
            this.interpolationCombo.Name = "interpolationCombo";
            this.interpolationCombo.Size = new System.Drawing.Size(173, 23);
            this.interpolationCombo.TabIndex = 33;
            this.interpolationCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(907, 396);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 15);
            this.label10.TabIndex = 34;
            this.label10.Text = "Méthode d\'interpolation";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // bgw_calibration
            // 
            this.bgw_calibration.WorkerReportsProgress = true;
            this.bgw_calibration.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.bgw_calibration.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.bgw_calibration.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // deleteCalibrationButton
            // 
            this.deleteCalibrationButton.Enabled = false;
            this.deleteCalibrationButton.Location = new System.Drawing.Point(903, 538);
            this.deleteCalibrationButton.Name = "deleteCalibrationButton";
            this.deleteCalibrationButton.Size = new System.Drawing.Size(173, 23);
            this.deleteCalibrationButton.TabIndex = 35;
            this.deleteCalibrationButton.Text = "Supprimer la calibration";
            this.deleteCalibrationButton.UseVisualStyleBackColor = true;
            this.deleteCalibrationButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.cartesianChart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cartesianChart1.Location = new System.Drawing.Point(201, 125);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(689, 411);
            this.cartesianChart1.TabIndex = 36;
            this.cartesianChart1.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.Automatic;
            this.cartesianChart1.TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top;
            this.cartesianChart1.Visible = false;
            this.cartesianChart1.Load += new System.EventHandler(this.cartesianChart1_Load);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Enabled = false;
            this.resultLabel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultLabel.Location = new System.Drawing.Point(200, 28);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(161, 25);
            this.resultLabel.TabIndex = 38;
            this.resultLabel.Text = "UB mesuré : 0 UB ";
            this.resultLabel.Click += new System.EventHandler(this.resultat_Click);
            // 
            // echantillonsType
            // 
            this.echantillonsType.AutoSize = true;
            this.echantillonsType.Enabled = false;
            this.echantillonsType.Location = new System.Drawing.Point(907, 275);
            this.echantillonsType.Name = "echantillonsType";
            this.echantillonsType.Size = new System.Drawing.Size(104, 15);
            this.echantillonsType.TabIndex = 40;
            this.echantillonsType.Text = "Type d\'échantillon";
            this.echantillonsType.Click += new System.EventHandler(this.echantillonsType_Click);
            // 
            // pictureMeanColor
            // 
            this.pictureMeanColor.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pictureMeanColor.Location = new System.Drawing.Point(907, 330);
            this.pictureMeanColor.Name = "pictureMeanColor";
            this.pictureMeanColor.Size = new System.Drawing.Size(20, 20);
            this.pictureMeanColor.TabIndex = 41;
            this.pictureMeanColor.TabStop = false;
            // 
            // MeanColor
            // 
            this.MeanColor.AutoSize = true;
            this.MeanColor.Location = new System.Drawing.Point(933, 330);
            this.MeanColor.Name = "MeanColor";
            this.MeanColor.Size = new System.Drawing.Size(102, 15);
            this.MeanColor.TabIndex = 42;
            this.MeanColor.Text = "Couleur moyenne";
            this.MeanColor.Click += new System.EventHandler(this.MeanColor_Click);
            // 
            // PictureDominante1
            // 
            this.PictureDominante1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.PictureDominante1.Location = new System.Drawing.Point(907, 373);
            this.PictureDominante1.Name = "PictureDominante1";
            this.PictureDominante1.Size = new System.Drawing.Size(20, 20);
            this.PictureDominante1.TabIndex = 43;
            this.PictureDominante1.TabStop = false;
            // 
            // PictureDominante2
            // 
            this.PictureDominante2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.PictureDominante2.Location = new System.Drawing.Point(933, 373);
            this.PictureDominante2.Name = "PictureDominante2";
            this.PictureDominante2.Size = new System.Drawing.Size(20, 20);
            this.PictureDominante2.TabIndex = 44;
            this.PictureDominante2.TabStop = false;
            // 
            // PictureDominante3
            // 
            this.PictureDominante3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.PictureDominante3.Location = new System.Drawing.Point(959, 373);
            this.PictureDominante3.Name = "PictureDominante3";
            this.PictureDominante3.Size = new System.Drawing.Size(20, 20);
            this.PictureDominante3.TabIndex = 45;
            this.PictureDominante3.TabStop = false;
            this.PictureDominante3.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // PictureDominante4
            // 
            this.PictureDominante4.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.PictureDominante4.Location = new System.Drawing.Point(985, 373);
            this.PictureDominante4.Name = "PictureDominante4";
            this.PictureDominante4.Size = new System.Drawing.Size(20, 20);
            this.PictureDominante4.TabIndex = 46;
            this.PictureDominante4.TabStop = false;
            // 
            // PictureDominante5
            // 
            this.PictureDominante5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.PictureDominante5.Location = new System.Drawing.Point(1011, 373);
            this.PictureDominante5.Name = "PictureDominante5";
            this.PictureDominante5.Size = new System.Drawing.Size(20, 20);
            this.PictureDominante5.TabIndex = 47;
            this.PictureDominante5.TabStop = false;
            this.PictureDominante5.Click += new System.EventHandler(this.PictureDominante5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(907, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 48;
            this.label1.Text = "Couleurs principales";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // curvesChart
            // 
            this.curvesChart.AutoSize = true;
            this.curvesChart.Enabled = false;
            this.curvesChart.Location = new System.Drawing.Point(903, 478);
            this.curvesChart.Name = "curvesChart";
            this.curvesChart.Size = new System.Drawing.Size(178, 19);
            this.curvesChart.TabIndex = 37;
            this.curvesChart.Text = "Afficher les courbes de mires";
            this.curvesChart.UseVisualStyleBackColor = true;
            this.curvesChart.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // exportExcel
            // 
            this.exportExcel.AutoSize = true;
            this.exportExcel.Location = new System.Drawing.Point(903, 513);
            this.exportExcel.Name = "exportExcel";
            this.exportExcel.Size = new System.Drawing.Size(122, 19);
            this.exportExcel.TabIndex = 49;
            this.exportExcel.Text = "Exporter vers Excel";
            this.exportExcel.UseVisualStyleBackColor = true;
            this.exportExcel.CheckedChanged += new System.EventHandler(this.exportExcel_CheckedChanged);
            // 
            // degrePolyCombo
            // 
            this.degrePolyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.degrePolyCombo.Enabled = false;
            this.degrePolyCombo.FormattingEnabled = true;
            this.degrePolyCombo.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.degrePolyCombo.Location = new System.Drawing.Point(1033, 449);
            this.degrePolyCombo.Name = "degrePolyCombo";
            this.degrePolyCombo.Size = new System.Drawing.Size(48, 23);
            this.degrePolyCombo.Sorted = true;
            this.degrePolyCombo.TabIndex = 50;
            this.degrePolyCombo.Visible = false;
            this.degrePolyCombo.SelectedIndexChanged += new System.EventHandler(this.degrePolyCombo_SelectedIndexChanged);
            // 
            // degreLabel
            // 
            this.degreLabel.AutoSize = true;
            this.degreLabel.Location = new System.Drawing.Point(908, 452);
            this.degreLabel.Name = "degreLabel";
            this.degreLabel.Size = new System.Drawing.Size(119, 15);
            this.degreLabel.TabIndex = 51;
            this.degreLabel.Text = "Degré d\'interpolation";
            this.degreLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 562);
            this.Controls.Add(this.degreLabel);
            this.Controls.Add(this.degrePolyCombo);
            this.Controls.Add(this.exportExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PictureDominante5);
            this.Controls.Add(this.PictureDominante4);
            this.Controls.Add(this.PictureDominante3);
            this.Controls.Add(this.PictureDominante2);
            this.Controls.Add(this.PictureDominante1);
            this.Controls.Add(this.MeanColor);
            this.Controls.Add(this.pictureMeanColor);
            this.Controls.Add(this.echantillonsType);
            this.Controls.Add(this.sampleCombo);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.curvesChart);
            this.Controls.Add(this.cartesianChart1);
            this.Controls.Add(this.deleteCalibrationButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.interpolationCombo);
            this.Controls.Add(this.distribution);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nbLinesLabel);
            this.Controls.Add(this.nbLines);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.verticalShift);
            this.Controls.Add(this.horizontalShift);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.hideCrosshairCheckbox);
            this.Controls.Add(this.crossHair);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.horizontalBar);
            this.Controls.Add(this.verticalBar);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.clearBucket);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.calibrationStatusLabel);
            this.Controls.Add(this.imageArea);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.colorspace);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.analyseButton);
            this.Controls.Add(this.progressBar1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Analyse brillance 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossHair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.horizontalShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verticalShift)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMeanColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDominante1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDominante2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDominante3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDominante4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureDominante5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button analyseButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ComboBox colorspace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem calibrageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utiliserUnCalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nouvelleCalibrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramètresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem périphériquesEtCamérasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connecterUneCaméraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargerImagesToolStripMenuItem;
        private System.Windows.Forms.PictureBox imageArea;
        private System.Windows.Forms.Label calibrationStatusLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button clearBucket;
        private System.Windows.Forms.ToolStripMenuItem chargerDesImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargerUnDossierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sélectionnerEspaceDeTravailToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TrackBar verticalBar;
        private System.Windows.Forms.TrackBar horizontalBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox crossHair;
        private System.Windows.Forms.CheckBox hideCrosshairCheckbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar horizontalShift;
        private System.Windows.Forms.TrackBar verticalShift;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem changerCouleurDuViseurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blancToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rougeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vertToolStripMenuItem;
        private System.Windows.Forms.TrackBar nbLines;
        private System.Windows.Forms.Label nbLinesLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox distribution;
        private System.Windows.Forms.ToolStripMenuItem créerUneCalibrationÀLaideDuneCaméraToolStripMenuItem;
        private System.Windows.Forms.ComboBox interpolationCombo;
        private System.Windows.Forms.Label label10;
        public System.ComponentModel.BackgroundWorker bgw_calibration;
        private System.Windows.Forms.Button deleteCalibrationButton;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label echantillonsType;
        private System.Windows.Forms.ToolStripMenuItem banqueDéchantillonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnÉchantillonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retirerUnÉchantillonToolStripMenuItem;
        public System.Windows.Forms.ComboBox sampleCombo;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderUneBanqueDéchantillonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargerUneBanqueDéchantillonsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureMeanColor;
        private System.Windows.Forms.Label MeanColor;
        private System.Windows.Forms.PictureBox PictureDominante1;
        private System.Windows.Forms.PictureBox PictureDominante2;
        private System.Windows.Forms.PictureBox PictureDominante3;
        private System.Windows.Forms.PictureBox PictureDominante4;
        private System.Windows.Forms.PictureBox PictureDominante5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox curvesChart;
        private System.Windows.Forms.ToolStripMenuItem valeurBYKPourLesMiresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valeurBYKToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valeurThéoriqueNCSToolStripMenuItem;
        private System.Windows.Forms.CheckBox exportExcel;
        private System.Windows.Forms.ToolStripMenuItem testsRRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem effectuerLeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem désactiverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optimiseurDeParamètresToolStripMenuItem;
        private System.Windows.Forms.ComboBox degrePolyCombo;
        private System.Windows.Forms.Label degreLabel;
        private System.Windows.Forms.ToolStripMenuItem chargerUneInterpolationIncluLeCalibrageToolStripMenuItem;
    }
}

