namespace Saving_Accelerator_Tool.Klasy.StatisticTab.View
{
    partial class ProductionQuantityMonthView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_StatisticQuantityMonthly = new System.Windows.Forms.GroupBox();
            this.dgv_StatisticQuantityMonth = new System.Windows.Forms.DataGridView();
            this.comb_StatisticQuantityMonthInstallation = new System.Windows.Forms.ComboBox();
            this.comb_StatisticQuantityMonthStructure = new System.Windows.Forms.ComboBox();
            this.comb_StatisticQuantityMonthRev = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_StatisticQuantityMonthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StatisticQuantityMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_StatisticQuantityMonthly
            // 
            this.gb_StatisticQuantityMonthly.Controls.Add(this.dgv_StatisticQuantityMonth);
            this.gb_StatisticQuantityMonthly.Controls.Add(this.comb_StatisticQuantityMonthInstallation);
            this.gb_StatisticQuantityMonthly.Controls.Add(this.comb_StatisticQuantityMonthStructure);
            this.gb_StatisticQuantityMonthly.Controls.Add(this.comb_StatisticQuantityMonthRev);
            this.gb_StatisticQuantityMonthly.Controls.Add(this.label3);
            this.gb_StatisticQuantityMonthly.Controls.Add(this.label2);
            this.gb_StatisticQuantityMonthly.Controls.Add(this.label1);
            this.gb_StatisticQuantityMonthly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_StatisticQuantityMonthly.Location = new System.Drawing.Point(0, 0);
            this.gb_StatisticQuantityMonthly.Name = "gb_StatisticQuantityMonthly";
            this.gb_StatisticQuantityMonthly.Size = new System.Drawing.Size(1042, 148);
            this.gb_StatisticQuantityMonthly.TabIndex = 0;
            this.gb_StatisticQuantityMonthly.TabStop = false;
            this.gb_StatisticQuantityMonthly.Text = "Production Monthy Qunatity:";
            // 
            // dgv_StatisticQuantityMonth
            // 
            this.dgv_StatisticQuantityMonth.AllowUserToAddRows = false;
            this.dgv_StatisticQuantityMonth.AllowUserToDeleteRows = false;
            this.dgv_StatisticQuantityMonth.AllowUserToResizeColumns = false;
            this.dgv_StatisticQuantityMonth.AllowUserToResizeRows = false;
            this.dgv_StatisticQuantityMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_StatisticQuantityMonth.Location = new System.Drawing.Point(10, 45);
            this.dgv_StatisticQuantityMonth.Name = "dgv_StatisticQuantityMonth";
            this.dgv_StatisticQuantityMonth.ReadOnly = true;
            this.dgv_StatisticQuantityMonth.Size = new System.Drawing.Size(1025, 90);
            this.dgv_StatisticQuantityMonth.TabIndex = 6;
            // 
            // comb_StatisticQuantityMonthInstallation
            // 
            this.comb_StatisticQuantityMonthInstallation.FormattingEnabled = true;
            this.comb_StatisticQuantityMonthInstallation.Items.AddRange(new object[] {
            "All",
            "FS",
            "FI",
            "BI",
            "FSBU"});
            this.comb_StatisticQuantityMonthInstallation.Location = new System.Drawing.Point(860, 15);
            this.comb_StatisticQuantityMonthInstallation.Name = "comb_StatisticQuantityMonthInstallation";
            this.comb_StatisticQuantityMonthInstallation.Size = new System.Drawing.Size(70, 21);
            this.comb_StatisticQuantityMonthInstallation.TabIndex = 5;
            this.comb_StatisticQuantityMonthInstallation.SelectedIndexChanged += new System.EventHandler(this.Comb_StatisticQuantityMonthInstallation_SelectedIndexChanged);
            // 
            // comb_StatisticQuantityMonthStructure
            // 
            this.comb_StatisticQuantityMonthStructure.FormattingEnabled = true;
            this.comb_StatisticQuantityMonthStructure.Items.AddRange(new object[] {
            "All",
            "DMD",
            "D45"});
            this.comb_StatisticQuantityMonthStructure.Location = new System.Drawing.Point(710, 15);
            this.comb_StatisticQuantityMonthStructure.Name = "comb_StatisticQuantityMonthStructure";
            this.comb_StatisticQuantityMonthStructure.Size = new System.Drawing.Size(71, 21);
            this.comb_StatisticQuantityMonthStructure.TabIndex = 4;
            this.comb_StatisticQuantityMonthStructure.SelectedIndexChanged += new System.EventHandler(this.Comb_StatisticQuantityMonthStructure_SelectedIndexChanged);
            // 
            // comb_StatisticQuantityMonthRev
            // 
            this.comb_StatisticQuantityMonthRev.FormattingEnabled = true;
            this.comb_StatisticQuantityMonthRev.Items.AddRange(new object[] {
            "All",
            "BU",
            "EA1",
            "EA2",
            "EA3"});
            this.comb_StatisticQuantityMonthRev.Location = new System.Drawing.Point(560, 15);
            this.comb_StatisticQuantityMonthRev.Name = "comb_StatisticQuantityMonthRev";
            this.comb_StatisticQuantityMonthRev.Size = new System.Drawing.Size(70, 21);
            this.comb_StatisticQuantityMonthRev.Sorted = true;
            this.comb_StatisticQuantityMonthRev.TabIndex = 3;
            this.comb_StatisticQuantityMonthRev.SelectedIndexChanged += new System.EventHandler(this.Comb_StatisticQuantityMonthRev_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(794, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Installation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(651, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Structure:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(503, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Revision:";
            // 
            // ProductionQuantityMonthView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_StatisticQuantityMonthly);
            this.Name = "ProductionQuantityMonthView";
            this.Size = new System.Drawing.Size(1042, 148);
            this.gb_StatisticQuantityMonthly.ResumeLayout(false);
            this.gb_StatisticQuantityMonthly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StatisticQuantityMonth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_StatisticQuantityMonthly;
        private System.Windows.Forms.DataGridView dgv_StatisticQuantityMonth;
        private System.Windows.Forms.ComboBox comb_StatisticQuantityMonthInstallation;
        private System.Windows.Forms.ComboBox comb_StatisticQuantityMonthStructure;
        private System.Windows.Forms.ComboBox comb_StatisticQuantityMonthRev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
