namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    partial class SumPNC
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
            this.gb_Admin_SumPNC = new System.Windows.Forms.GroupBox();
            this.num_Admin_SumPNC_Month = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.num_Admin_SumPNC_Year = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.but_Admin_SumPNC_Calc = new System.Windows.Forms.Button();
            this.comb_Admin_SumPNC_Rev = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.but_Admin_SumPNC_Calc_Revision = new System.Windows.Forms.Button();
            this.gb_Admin_SumPNC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_SumPNC_Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_SumPNC_Year)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Admin_SumPNC
            // 
            this.gb_Admin_SumPNC.Controls.Add(this.but_Admin_SumPNC_Calc_Revision);
            this.gb_Admin_SumPNC.Controls.Add(this.label3);
            this.gb_Admin_SumPNC.Controls.Add(this.comb_Admin_SumPNC_Rev);
            this.gb_Admin_SumPNC.Controls.Add(this.but_Admin_SumPNC_Calc);
            this.gb_Admin_SumPNC.Controls.Add(this.num_Admin_SumPNC_Month);
            this.gb_Admin_SumPNC.Controls.Add(this.label2);
            this.gb_Admin_SumPNC.Controls.Add(this.num_Admin_SumPNC_Year);
            this.gb_Admin_SumPNC.Controls.Add(this.label1);
            this.gb_Admin_SumPNC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Admin_SumPNC.Location = new System.Drawing.Point(0, 0);
            this.gb_Admin_SumPNC.Name = "gb_Admin_SumPNC";
            this.gb_Admin_SumPNC.Size = new System.Drawing.Size(200, 160);
            this.gb_Admin_SumPNC.TabIndex = 0;
            this.gb_Admin_SumPNC.TabStop = false;
            this.gb_Admin_SumPNC.Text = "Sum PNC:";
            // 
            // num_Admin_SumPNC_Month
            // 
            this.num_Admin_SumPNC_Month.Location = new System.Drawing.Point(90, 44);
            this.num_Admin_SumPNC_Month.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.num_Admin_SumPNC_Month.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Admin_SumPNC_Month.Name = "num_Admin_SumPNC_Month";
            this.num_Admin_SumPNC_Month.Size = new System.Drawing.Size(55, 20);
            this.num_Admin_SumPNC_Month.TabIndex = 3;
            this.num_Admin_SumPNC_Month.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Month:";
            // 
            // num_Admin_SumPNC_Year
            // 
            this.num_Admin_SumPNC_Year.Location = new System.Drawing.Point(90, 21);
            this.num_Admin_SumPNC_Year.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.num_Admin_SumPNC_Year.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_Admin_SumPNC_Year.Name = "num_Admin_SumPNC_Year";
            this.num_Admin_SumPNC_Year.Size = new System.Drawing.Size(55, 20);
            this.num_Admin_SumPNC_Year.TabIndex = 1;
            this.num_Admin_SumPNC_Year.Value = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year:";
            // 
            // but_Admin_SumPNC_Calc
            // 
            this.but_Admin_SumPNC_Calc.Location = new System.Drawing.Point(49, 70);
            this.but_Admin_SumPNC_Calc.Name = "but_Admin_SumPNC_Calc";
            this.but_Admin_SumPNC_Calc.Size = new System.Drawing.Size(96, 22);
            this.but_Admin_SumPNC_Calc.TabIndex = 4;
            this.but_Admin_SumPNC_Calc.Text = "Sum Month";
            this.but_Admin_SumPNC_Calc.UseVisualStyleBackColor = true;
            this.but_Admin_SumPNC_Calc.Click += new System.EventHandler(this.Pb_Admin_SumPNC_Month_Click);
            // 
            // comb_Admin_SumPNC_Rev
            // 
            this.comb_Admin_SumPNC_Rev.FormattingEnabled = true;
            this.comb_Admin_SumPNC_Rev.Items.AddRange(new object[] {
            "BU",
            "EA1",
            "EA2",
            "EA3"});
            this.comb_Admin_SumPNC_Rev.Location = new System.Drawing.Point(90, 98);
            this.comb_Admin_SumPNC_Rev.Name = "comb_Admin_SumPNC_Rev";
            this.comb_Admin_SumPNC_Rev.Size = new System.Drawing.Size(86, 21);
            this.comb_Admin_SumPNC_Rev.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Revision:";
            // 
            // but_Admin_SumPNC_Calc_Revision
            // 
            this.but_Admin_SumPNC_Calc_Revision.Location = new System.Drawing.Point(49, 130);
            this.but_Admin_SumPNC_Calc_Revision.Name = "but_Admin_SumPNC_Calc_Revision";
            this.but_Admin_SumPNC_Calc_Revision.Size = new System.Drawing.Size(96, 23);
            this.but_Admin_SumPNC_Calc_Revision.TabIndex = 7;
            this.but_Admin_SumPNC_Calc_Revision.Text = "Sum Rev";
            this.but_Admin_SumPNC_Calc_Revision.UseVisualStyleBackColor = true;
            this.but_Admin_SumPNC_Calc_Revision.Click += new System.EventHandler(this.Pb_Admin_SumPNC_Revision_Click);
            // 
            // SumPNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_Admin_SumPNC);
            this.Name = "SumPNC";
            this.Size = new System.Drawing.Size(200, 160);
            this.gb_Admin_SumPNC.ResumeLayout(false);
            this.gb_Admin_SumPNC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_SumPNC_Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_SumPNC_Year)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Admin_SumPNC;
        private System.Windows.Forms.NumericUpDown num_Admin_SumPNC_Year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_Admin_SumPNC_Month;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_Admin_SumPNC_Calc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comb_Admin_SumPNC_Rev;
        private System.Windows.Forms.Button but_Admin_SumPNC_Calc_Revision;
    }
}
