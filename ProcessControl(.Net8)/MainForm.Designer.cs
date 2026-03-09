namespace ProcessControl_.Net8_
{
    partial class MainForm
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
            plotBP = new ScottPlot.WinForms.FormsPlot();
            btnPlot = new Button();
            plotHDLD = new ScottPlot.WinForms.FormsPlot();
            plotLD = new ScottPlot.WinForms.FormsPlot();
            plotDMin = new ScottPlot.WinForms.FormsPlot();
            btnEditReference = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            btnNewReading = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // plotBP
            // 
            plotBP.DisplayScale = 1F;
            plotBP.Location = new Point(6, 6);
            plotBP.Name = "plotBP";
            plotBP.Size = new Size(853, 487);
            plotBP.TabIndex = 0;
            // 
            // btnPlot
            // 
            btnPlot.Location = new Point(12, 42);
            btnPlot.Name = "btnPlot";
            btnPlot.Size = new Size(175, 23);
            btnPlot.TabIndex = 1;
            btnPlot.Text = "Refresh!";
            btnPlot.UseVisualStyleBackColor = true;
            btnPlot.Click += btnPlot_Click_1;
            // 
            // plotHDLD
            // 
            plotHDLD.DisplayScale = 1F;
            plotHDLD.Location = new Point(6, 6);
            plotHDLD.Name = "plotHDLD";
            plotHDLD.Size = new Size(853, 487);
            plotHDLD.TabIndex = 2;
            // 
            // plotLD
            // 
            plotLD.DisplayScale = 1F;
            plotLD.Location = new Point(6, 6);
            plotLD.Name = "plotLD";
            plotLD.Size = new Size(856, 487);
            plotLD.TabIndex = 3;
            // 
            // plotDMin
            // 
            plotDMin.DisplayScale = 1F;
            plotDMin.Location = new Point(6, 6);
            plotDMin.Name = "plotDMin";
            plotDMin.Size = new Size(853, 487);
            plotDMin.TabIndex = 4;
            // 
            // btnEditReference
            // 
            btnEditReference.Location = new Point(12, 91);
            btnEditReference.Name = "btnEditReference";
            btnEditReference.Size = new Size(175, 23);
            btnEditReference.TabIndex = 5;
            btnEditReference.Text = "Edit reference strip";
            btnEditReference.UseVisualStyleBackColor = true;
            btnEditReference.Click += btnEditReference_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(217, 42);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(873, 527);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(plotBP);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(865, 499);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "BP";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(plotHDLD);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(865, 499);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "HD-LD";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(plotLD);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(865, 499);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "LD";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(plotDMin);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(865, 499);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "DMin";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnNewReading
            // 
            btnNewReading.Location = new Point(12, 143);
            btnNewReading.Name = "btnNewReading";
            btnNewReading.Size = new Size(175, 23);
            btnNewReading.TabIndex = 7;
            btnNewReading.Text = "Add reading";
            btnNewReading.UseVisualStyleBackColor = true;
            btnNewReading.Click += btnNewReading_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1102, 590);
            Controls.Add(btnNewReading);
            Controls.Add(tabControl1);
            Controls.Add(btnEditReference);
            Controls.Add(btnPlot);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ScottPlot.WinForms.FormsPlot plotBP;
        private Button btnPlot;
        private ScottPlot.WinForms.FormsPlot plotHDLD;
        private ScottPlot.WinForms.FormsPlot plotLD;
        private ScottPlot.WinForms.FormsPlot plotDMin;
        private Button btnEditReference;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button btnNewReading;
    }
}
