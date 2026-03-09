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
    public partial class FormNewReferenceStrip : Form
    {
        public FormNewReferenceStrip()
        {
            InitializeComponent();
        }
        public void FormNewReferenceStrip_Load(object sender, EventArgs e)
        {
            using var reader = Sep.New(',').Reader(o => o with { Unescape = true }).FromFile(ConfigurationManager.AppSettings.Get("ReferenceFile"));

            foreach (var row in reader)
            {
                txtBoxStripName.Text = row["Name"].ToString();
                txtboxStripRefNo.Text = row["Number"].ToString();

                txtBoxDMinR.Text = row["Dmin_R"].ToString();
                txtBoxDMinG.Text = row["Dmin_G"].ToString();
                txtBoxDMinB.Text = row["Dmin_B"].ToString();
                txtBoxLDR.Text = row["LD_R"].ToString();
                txtBoxLDG.Text = row["LD_G"].ToString();
                txtBoxLDB.Text = row["LD_B"].ToString();
                txtBoxHDR.Text = row["HD_R"].ToString();
                txtBoxHDG.Text = row["HD_G"].ToString();
                txtBoxHDB.Text = row["HD_B"].ToString();
                txtBoxDMaxR.Text = row["Dmax_R"].ToString();
                txtBoxDMaxG.Text = row["Dmax_G"].ToString();
                txtBoxDMaxB.Text = row["Dmax_B"].ToString();
                txtBoxYellowR.Text = row["Yellow_R"].ToString();
                txtBoxYellowG.Text = row["Yellow_G"].ToString();
                txtBoxYellowB.Text = row["Yellow_B"].ToString();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            
            using var writer = Sep.New(',').Writer().ToFile(ConfigurationManager.AppSettings.Get("ReferenceFile"));
            using var writeRow = writer.NewRow();
            writeRow["Name"].Set(txtBoxStripName.Text);
            writeRow["Number"].Set(txtboxStripRefNo.Text);

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
