
namespace GlossDetectorGerflor
{
    partial class SeizeValuesTestingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Valeurs_BYK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paste = new System.Windows.Forms.Button();
            this.validation = new System.Windows.Forms.Button();
            this.typeDataGrid = new System.Windows.Forms.DataGridView();
            this.TypeSample = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.typePaste = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Valeurs_BYK});
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(143, 282);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Valeurs_BYK
            // 
            this.Valeurs_BYK.HeaderText = "Valeurs BYK";
            this.Valeurs_BYK.Name = "Valeurs_BYK";
            // 
            // paste
            // 
            this.paste.Location = new System.Drawing.Point(12, 12);
            this.paste.Name = "paste";
            this.paste.Size = new System.Drawing.Size(143, 41);
            this.paste.TabIndex = 1;
            this.paste.Text = "Coller la colonne Excel";
            this.paste.UseVisualStyleBackColor = true;
            this.paste.Click += new System.EventHandler(this.paste_Click);
            // 
            // validation
            // 
            this.validation.Location = new System.Drawing.Point(161, 348);
            this.validation.Name = "validation";
            this.validation.Size = new System.Drawing.Size(143, 41);
            this.validation.TabIndex = 2;
            this.validation.Text = "Valider la sélection";
            this.validation.UseVisualStyleBackColor = true;
            this.validation.Click += new System.EventHandler(this.validation_Click);
            // 
            // typeDataGrid
            // 
            this.typeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.typeDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeSample});
            this.typeDataGrid.Location = new System.Drawing.Point(161, 59);
            this.typeDataGrid.Name = "typeDataGrid";
            this.typeDataGrid.RowTemplate.Height = 25;
            this.typeDataGrid.Size = new System.Drawing.Size(143, 282);
            this.typeDataGrid.TabIndex = 3;
            this.typeDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // TypeSample
            // 
            this.TypeSample.HeaderText = "Type";
            this.TypeSample.Name = "TypeSample";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 365);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(143, 23);
            this.comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 348);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Sélecteur d\'échantillon";
            // 
            // typePaste
            // 
            this.typePaste.Location = new System.Drawing.Point(160, 12);
            this.typePaste.Name = "typePaste";
            this.typePaste.Size = new System.Drawing.Size(144, 41);
            this.typePaste.TabIndex = 6;
            this.typePaste.Text = "Coller la colonne Excel";
            this.typePaste.UseVisualStyleBackColor = true;
            this.typePaste.Click += new System.EventHandler(this.typePaste_Click);
            // 
            // SeizeValuesTestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 401);
            this.Controls.Add(this.typePaste);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.typeDataGrid);
            this.Controls.Add(this.validation);
            this.Controls.Add(this.paste);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SeizeValuesTestingForm";
            this.Text = "BYK";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SeizeBYKValueForm_FormClosed);
            this.Load += new System.EventHandler(this.SeizeBYKValueForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valeurs_BYK;
        private System.Windows.Forms.Button paste;
        private System.Windows.Forms.Button validation;
        private System.Windows.Forms.DataGridView typeDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeSample;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button typePaste;
    }
}