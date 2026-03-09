using nietras.SeparatedValues;
using ProcessControl;
using ScottPlot;
using ScottPlot.AxisPanels;
using ScottPlot.Colormaps;
using ScottPlot.Plottables;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Windows.Forms;
using static nietras.SeparatedValues.Sep;


namespace ProcessControl_.Net8_
{
    public partial class MainForm : Form
    {
        List<DateTime> measurementLabel = new List<DateTime>();
        List<float> BP_Deviation = new List<float>();

        List<float> HDLD_R_Deviation = new List<float>();
        List<float> HDLD_G_Deviation = new List<float>();
        List<float> HDLD_B_Deviation = new List<float>();

        List<float> LD_R_Deviation = new List<float>();
        List<float> LD_G_Deviation = new List<float>();
        List<float> LD_B_Deviation = new List<float>();

        List<float> DMin_R_Deviation = new List<float>();
        List<float> DMin_G_Deviation = new List<float>();
        List<float> DMin_B_Deviation = new List<float>();

        List<Reading> readings = new List<Reading>();

        PatchValue DMinReference = new PatchValue(0.20f, 0.23f, 0.25f);
        PatchValue LDReference = new PatchValue(0.70f, 0.85f, 1.08f);
        PatchValue HDReference = new PatchValue(1.11f, 1.45f, 1.91f);
        PatchValue DMaxReference = new PatchValue(1.61f, 2.06f, 2.48f);
        PatchValue YellowReference = new PatchValue(1.10f, 1.14f, 1.73f);

        public MainForm()
        {
            InitializeComponent();

        }

        public void btnPlot_Click_1(object sender, EventArgs e)
        {

            List<DateTime> measurementLabel = new List<DateTime>();
            List<float> BP_Deviation = new List<float>();

            List<float> HDLD_R_Deviation = new List<float>();
            List<float> HDLD_G_Deviation = new List<float>();
            List<float> HDLD_B_Deviation = new List<float>();

            List<float> LD_R_Deviation = new List<float>();
            List<float> LD_G_Deviation = new List<float>();
            List<float> LD_B_Deviation = new List<float>();

            List<float> DMin_R_Deviation = new List<float>();
            List<float> DMin_G_Deviation = new List<float>();
            List<float> DMin_B_Deviation = new List<float>();

            plotBP.Plot.Clear();
            plotDMin.Plot.Clear();
            plotHDLD.Plot.Clear();
            plotLD.Plot.Clear();

            using var readerReference = Sep.New(',').Reader(o => o with { Unescape = true }).FromFile(ConfigurationManager.AppSettings.Get("ReferenceFile"));

            foreach (var readRow in readerReference)
            {
                DMinReference = new PatchValue(float.Parse(readRow["Dmin_R"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Dmin_G"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Dmin_B"].ToString(), CultureInfo.InvariantCulture));
                LDReference = new PatchValue(float.Parse(readRow["LD_R"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["LD_G"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["LD_B"].ToString(), CultureInfo.InvariantCulture));
                HDReference = new PatchValue(float.Parse(readRow["HD_R"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["HD_G"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["HD_B"].ToString(), CultureInfo.InvariantCulture));
                DMaxReference = new PatchValue(float.Parse(readRow["Dmax_R"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Dmax_G"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Dmax_B"].ToString(), CultureInfo.InvariantCulture));
                YellowReference = new PatchValue(float.Parse(readRow["Yellow_R"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Yellow_G"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Yellow_B"].ToString(), CultureInfo.InvariantCulture));
            }


            using var reader = Sep.New(',').Reader(o => o with { Unescape = true }).FromFile(ConfigurationManager.AppSettings.Get("DataFile"));

            foreach (var readRow in reader)
            {


                PatchValue dMinpatch = new PatchValue(float.Parse(readRow["Dmin_R"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Dmin_G"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Dmin_B"].ToString(), CultureInfo.InvariantCulture));
                PatchValue ldPatch = new PatchValue(float.Parse(readRow["LD_R"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["LD_G"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["LD_B"].ToString(), CultureInfo.InvariantCulture));
                PatchValue hdPatch = new PatchValue(float.Parse(readRow["HD_R"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["HD_G"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["HD_B"].ToString(), CultureInfo.InvariantCulture));
                PatchValue dMaxPatch = new PatchValue(float.Parse(readRow["Dmax_R"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Dmax_G"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Dmax_B"].ToString(), CultureInfo.InvariantCulture));
                PatchValue yellowPatch = new PatchValue(float.Parse(readRow["Yellow_R"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Yellow_G"].ToString(), CultureInfo.InvariantCulture), float.Parse(readRow["Yellow_B"].ToString(), CultureInfo.InvariantCulture));

                Reading reading = new Reading(Int32.Parse(readRow["Run"].ToString()), DateTime.Parse(readRow["Datetime"].ToString()), dMinpatch, ldPatch, hdPatch, dMaxPatch, yellowPatch);
                readings.Add(reading);




                measurementLabel.Add(reading.DateTime);
                float BMinY_BDeviationtemmp = MathF.Round((reading.DMaxPatch.Blue - reading.YellowPatch.Blue), 2);
                BP_Deviation.Add(BMinY_BDeviationtemmp);
                float HDLD_B_Deviationtemp = MathF.Round((reading.HDPatch.Blue - reading.LDPatch.Blue) - (HDReference.Blue - LDReference.Blue), 2);
                HDLD_B_Deviation.Add(HDLD_B_Deviationtemp);
                HDLD_R_Deviation.Add(MathF.Round((reading.HDPatch.Red - reading.LDPatch.Red) - (HDReference.Red - LDReference.Red), 2));
                HDLD_G_Deviation.Add(MathF.Round((reading.HDPatch.Green - reading.LDPatch.Green) - (HDReference.Green - LDReference.Green), 2));

                LD_R_Deviation.Add(MathF.Round(reading.LDPatch.Red - LDReference.Red, 2));
                LD_G_Deviation.Add(MathF.Round(reading.LDPatch.Green - LDReference.Green, 2));
                LD_B_Deviation.Add(MathF.Round(reading.LDPatch.Blue - LDReference.Blue, 2));

                DMin_R_Deviation.Add(MathF.Round(reading.DMinPatch.Red - DMinReference.Red, 2));
                DMin_G_Deviation.Add(MathF.Round(reading.DMinPatch.Green - DMinReference.Green, 2));
                DMin_B_Deviation.Add(MathF.Round(reading.DMinPatch.Blue - DMinReference.Blue, 2));


            }

            plotBP.Plot.Axes.Title.Label.Text = "BP / D-max(B) - Y(B)";
            plotBP.Plot.Add.Scatter(measurementLabel, BP_Deviation);
            plotBP.Plot.Add.HorizontalLine(0.10, 2, ScottPlot.Color.FromHex("0000FF"), ScottPlot.LinePattern.Dashed);
            plotBP.Plot.Add.HorizontalLine(0.12, 2, ScottPlot.Color.FromHex("0000FF"));
            plotBP.Plot.Axes.DateTimeTicksBottom();
            plotBP.PerformAutoScale();
            plotBP.Plot.Axes.SetLimitsY(0, 0.3);

            plotBP.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericFixedInterval(0.01);
            plotBP.Refresh();

            plotHDLD.Plot.Axes.Title.Label.Text = "HD - LD";
            plotHDLD.Plot.Add.Scatter(measurementLabel, HDLD_G_Deviation, ScottPlot.Color.FromColor(System.Drawing.Color.Green));
            plotHDLD.Plot.Add.Scatter(measurementLabel, HDLD_R_Deviation, ScottPlot.Color.FromColor(System.Drawing.Color.Red));
            plotHDLD.Plot.Add.Scatter(measurementLabel, HDLD_B_Deviation, ScottPlot.Color.FromColor(System.Drawing.Color.Blue));
            plotHDLD.Plot.Add.HorizontalLine(0.08, 2, ScottPlot.Color.FromHex("0000FF"), ScottPlot.LinePattern.Dashed);
            plotHDLD.Plot.Add.HorizontalLine(0.10, 2, ScottPlot.Color.FromHex("0000FF"));
            plotHDLD.Plot.Add.HorizontalLine(-0.08, 2, ScottPlot.Color.FromHex("0000FF"), ScottPlot.LinePattern.Dashed);
            plotHDLD.Plot.Add.HorizontalLine(-0.10, 2, ScottPlot.Color.FromHex("0000FF"));
            plotHDLD.Plot.Axes.DateTimeTicksBottom();
            plotHDLD.Plot.Axes.SetLimitsY(-0.3, 0.3);
            plotHDLD.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericFixedInterval(0.01);
            plotHDLD.Refresh();

            plotLD.Plot.Axes.Title.Label.Text = "LD";
            plotLD.Plot.Add.Scatter(measurementLabel, LD_G_Deviation, ScottPlot.Color.FromColor(System.Drawing.Color.Green));
            plotLD.Plot.Add.Scatter(measurementLabel, LD_R_Deviation, ScottPlot.Color.FromColor(System.Drawing.Color.Red));
            plotLD.Plot.Add.Scatter(measurementLabel, LD_B_Deviation, ScottPlot.Color.FromColor(System.Drawing.Color.Blue));
            plotLD.Plot.Add.HorizontalLine(0.06, 2, ScottPlot.Color.FromHex("0000FF"), ScottPlot.LinePattern.Dashed);
            plotLD.Plot.Add.HorizontalLine(0.08, 2, ScottPlot.Color.FromHex("0000FF"));
            plotLD.Plot.Add.HorizontalLine(-0.06, 2, ScottPlot.Color.FromHex("0000FF"), ScottPlot.LinePattern.Dashed);
            plotLD.Plot.Add.HorizontalLine(-0.08, 2, ScottPlot.Color.FromHex("0000FF"));
            plotLD.Plot.Axes.DateTimeTicksBottom();
            plotLD.Plot.Axes.SetLimitsY(-0.3, 0.3);
            plotLD.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericFixedInterval(0.01);
            plotLD.Refresh();

            plotDMin.Plot.Axes.Title.Label.Text = "DMin";
            plotDMin.Plot.Add.Scatter(measurementLabel, DMin_G_Deviation, ScottPlot.Color.FromColor(System.Drawing.Color.Green));
            plotDMin.Plot.Add.Scatter(measurementLabel, DMin_R_Deviation, ScottPlot.Color.FromColor(System.Drawing.Color.Red));
            plotDMin.Plot.Add.Scatter(measurementLabel, DMin_B_Deviation, ScottPlot.Color.FromColor(System.Drawing.Color.Blue));
            plotDMin.Plot.Add.HorizontalLine(0.03, 2, ScottPlot.Color.FromHex("0000FF"), ScottPlot.LinePattern.Dashed);
            plotDMin.Plot.Add.HorizontalLine(0.05, 2, ScottPlot.Color.FromHex("0000FF"));
            plotDMin.Plot.Axes.DateTimeTicksBottom();
            plotDMin.Plot.Axes.SetLimitsY(-0.15, 0.15);
            plotDMin.Plot.Axes.Left.TickGenerator = new ScottPlot.TickGenerators.NumericFixedInterval(0.01);
            plotDMin.Refresh();


        }

        private void btnEditReference_Click(object sender, EventArgs e)
        {
            FormNewReferenceStrip formNewReferenceStrip = new FormNewReferenceStrip();
            formNewReferenceStrip.ShowDialog();
        }

        private void btnNewReading_Click(object sender, EventArgs e)
        {
            FormNewReading formNewReading = new FormNewReading(); 
            formNewReading.ShowDialog();
        }
    }
}
