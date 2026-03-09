using nietras.SeparatedValues;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProcessControl_.Net8_
{
    public partial class FormNewReading : Form
    {
        public FormNewReading()
        {
            InitializeComponent();
        }
        public void FormNewReading_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            

            var sep = new Sep(',');

            using var stream = File.Open(ConfigurationManager.AppSettings.Get("DataFile"), FileMode.Append, FileAccess.Write);
            using var writer = new StreamWriter(stream);
            SepWriterOptions options = new SepWriterOptions();

            using var sepWriter = sep.Writer( o => o with { WriteHeader = false}).To(writer);


            using var writeRow = sepWriter.NewRow();


            writeRow["Type"].Set("reading");
            writeRow["Run"].Set("0");
            writeRow["Datetime"].Set(DateTime.Now.ToString());
            writeRow["Dmin_R"].Set(txtBoxDMinR.Text);
            writeRow["Dmin_G"].Set(txtBoxDMinG.Text);
            writeRow["Dmin_B"].Set(txtBoxDMinB.Text);
            writeRow["LD_R"].Set(txtBoxLDR.Text);
            writeRow["LD_G"].Set(txtBoxLDG.Text);
            writeRow["LD_B"].Set(txtBoxLDB.Text);
            writeRow["HD_R"].Set(txtBoxHDR.Text);
            writeRow["HD_G"].Set(txtBoxHDG.Text);
            writeRow["HD_B"].Set(txtBoxHDB.Text);
            writeRow["Dmax_R"].Set(txtBoxDMaxR.Text);
            writeRow["Dmax_G"].Set(txtBoxDMaxG.Text);
            writeRow["Dmax_B"].Set(txtBoxDMaxB.Text);
            writeRow["Yellow_R"].Set(txtBoxYellowR.Text);
            writeRow["Yellow_G"].Set(txtBoxYellowG.Text);
            writeRow["Yellow_B"].Set(txtBoxYellowB.Text);

            
            writeRow.Dispose();

            MessageBox.Show("Done!");

        }
    }
}
