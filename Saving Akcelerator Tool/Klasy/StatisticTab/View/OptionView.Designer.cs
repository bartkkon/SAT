namespace Saving_Accelerator_Tool.Klasy.StatisticTab.View
{
    partial class OptionView
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
            this.pb_LoadStatistic = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.num_OptionYear = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.num_OptionYear)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_LoadStatistic
            // 
            this.pb_LoadStatistic.Location = new System.Drawing.Point(31, 54);
            this.pb_LoadStatistic.Name = "pb_LoadStatistic";
            this.pb_LoadStatistic.Size = new System.Drawing.Size(87, 35);
            this.pb_LoadStatistic.TabIndex = 0;
            this.pb_LoadStatistic.Text = "Load Data";
            this.pb_LoadStatistic.UseVisualStyleBackColor = true;
            this.pb_LoadStatistic.Click += new System.EventHandler(this.Pb_LoadStatistic_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Year:";
            // 
            // num_OptionYear
            // 
            this.num_OptionYear.Location = new System.Drawing.Point(48, 15);
            this.num_OptionYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.num_OptionYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_OptionYear.Name = "num_OptionYear";
            this.num_OptionYear.Size = new System.Drawing.Size(60, 20);
            this.num_OptionYear.TabIndex = 2;
            this.num_OptionYear.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_OptionYear.ValueChanged += new System.EventHandler(this.Num_OptionYear_ValueChanged);
            // 
            // OptionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.num_OptionYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_LoadStatistic);
            this.Name = "OptionView";
            this.Size = new System.Drawing.Size(142, 112);
            ((System.ComponentModel.ISupportInitialize)(this.num_OptionYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pb_LoadStatistic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_OptionYear;
    }
}
