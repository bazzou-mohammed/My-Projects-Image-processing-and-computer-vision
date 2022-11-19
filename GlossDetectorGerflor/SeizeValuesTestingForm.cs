using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GlossDetectorGerflor
{
    public partial class SeizeValuesTestingForm : Form
    {
        public event EventHandler cancel;
        public event EventHandler<provideBYKArrayEvent> provideData;
        private ComboBox sampleCombo;
        public SeizeValuesTestingForm(ComboBox sampleCombo)
        {
            this.sampleCombo = sampleCombo;
            InitializeComponent();
            comboBox1.DataSource = sampleCombo.DataSource;
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Key";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SeizeBYKValueForm_Load(object sender, EventArgs e)
        {

        }

        private void paste_Click(object sender, EventArgs e)
        {
            pasterToDataGrid(dataGridView1);
        }

        public void pasterToDataGrid(DataGridView myDataGridView)
        {
            DataObject o = (DataObject)Clipboard.GetDataObject();
            if (o.GetDataPresent(DataFormats.Text))
            {
                if (myDataGridView.RowCount > 0)
                    myDataGridView.Rows.Clear();



                string[] pastedRows = Regex.Split(o.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                int row = 0;
                foreach (string pastedRow in pastedRows)
                {
                    string[] pastedRowCells = pastedRow.Split(new char[] { '\t' });
                    if(pastedRowCells.Length > 1)
                    {
                        MessageBox.Show("Seule une colonne doit être collé");
                        break;

                    }

                    myDataGridView.Rows.Add();
                    using (DataGridViewRow myDataGridViewRow = myDataGridView.Rows[row])
                    {
                        myDataGridViewRow.Cells[0].Value = pastedRow;
                       
                    }
                    row++;
                }
            }
        }


        public double[] createArrayFromDataGridBYK(DataGridView dataGridView)
        {
            double[] res;
            try {
                res = new double[dataGridView.Rows.Count-1];
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    string cellData = dataGridView.Rows[i].Cells[0].Value.ToString(); ;
                    cellData = cellData.Replace(',', '.');
                    Double.TryParse(cellData, NumberStyles.Any, CultureInfo.InvariantCulture, out res[i]);
                }
                
            }catch
            {
                MessageBox.Show("Format du tableau non valide");
                res = new double[0];
            }
            return res;
        }

        public string[] createArrayFromDataGridType(DataGridView dataGridView)
        {
            string[] res;
            try
            {
                res = new string[dataGridView.Rows.Count - 1];
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    string cellData = dataGridView.Rows[i].Cells[0].Value.ToString();
                    res[i] = cellData;
                }

            }
            catch
            {
                MessageBox.Show("Format du tableau non valide");
                res = new string[0];
            }
            return res;
        }

        private void SeizeBYKValueForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cancel?.Invoke(this, EventArgs.Empty);
        }

        private void validation_Click(object sender, EventArgs e)
        {
            provideBYKArrayEvent args = new provideBYKArrayEvent();
            args.resBYK = createArrayFromDataGridBYK(dataGridView1);
            args.resType = createArrayFromDataGridType(typeDataGrid);
            if (args.resBYK.Length >1 && (args.resBYK.Length == args.resType.Length))
                provideDataFire(args);

        }

        protected virtual void provideDataFire(provideBYKArrayEvent e)
        {
            EventHandler<provideBYKArrayEvent> handler = provideData;
            if (handler != null)
            {
                handler(this, e);
            }
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void typePaste_Click(object sender, EventArgs e)
        {
            pasterToDataGrid(typeDataGrid);
        }
    }

    public class provideBYKArrayEvent : EventArgs
    {
        public double[] resBYK { get; set; }
        public string[] resType { get; set; }
    }

}
