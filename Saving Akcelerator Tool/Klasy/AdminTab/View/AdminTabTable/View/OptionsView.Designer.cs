namespace Saving_Accelerator_Tool.Klasy.AdminTab.View.AdminTabTable.View
{
    partial class OptionsView
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
            this.num_Year = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_OptionMonth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.comb_Revision = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_OptionMonth)).BeginInit();
            this.SuspendLayout();
            // 
            // num_Year
            // 
            this.num_Year.Location = new System.Drawing.Point(66, 15);
            this.num_Year.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.num_Year.Minimum = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            this.num_Year.Name = "num_Year";
            this.num_Year.Size = new System.Drawing.Size(62, 20);
            this.num_Year.TabIndex = 0;
            this.num_Year.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Year:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Month:";
            // 
            // num_OptionMonth
            // 
            this.num_OptionMonth.Location = new System.Drawing.Point(195, 15);
            this.num_OptionMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.num_OptionMonth.Name = "num_OptionMonth";
            this.num_OptionMonth.Size = new System.Drawing.Size(43, 20);
            this.num_OptionMonth.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Revision:";
            // 
            // comb_Revision
            // 
            this.comb_Revision.FormattingEnabled = true;
            this.comb_Revision.Items.AddRange(new object[] {
            "",
            "BU",
            "EA1",
            "EA2",
            "EA3"});
            this.comb_Revision.Location = new System.Drawing.Point(312, 14);
            this.comb_Revision.Name = "comb_Revision";
            this.comb_Revision.Size = new System.Drawing.Size(91, 21);
            this.comb_Revision.TabIndex = 5;
            // 
            // OptionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comb_Revision);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.num_OptionMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num_Year);
            this.Name = "OptionsView";
            this.Size = new System.Drawing.Size(1912, 100);
            ((System.ComponentModel.ISupportInitialize)(this.num_Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_OptionMonth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown num_Year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_OptionMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comb_Revision;
    }
}
