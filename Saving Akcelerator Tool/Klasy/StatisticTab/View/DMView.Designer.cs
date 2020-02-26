namespace Saving_Accelerator_Tool.Klasy.StatisticTab.View
{
    partial class DMView
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
            this.gb_StatisticDM = new System.Windows.Forms.GroupBox();
            this.dgv_StatisticDM = new System.Windows.Forms.DataGridView();
            this.cb_Statistic_ExchangeRate = new System.Windows.Forms.ComboBox();
            this.gb_StatisticDM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StatisticDM)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_StatisticDM
            // 
            this.gb_StatisticDM.Controls.Add(this.cb_Statistic_ExchangeRate);
            this.gb_StatisticDM.Controls.Add(this.dgv_StatisticDM);
            this.gb_StatisticDM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_StatisticDM.Location = new System.Drawing.Point(0, 0);
            this.gb_StatisticDM.Name = "gb_StatisticDM";
            this.gb_StatisticDM.Size = new System.Drawing.Size(550, 160);
            this.gb_StatisticDM.TabIndex = 0;
            this.gb_StatisticDM.TabStop = false;
            this.gb_StatisticDM.Text = "Direct Material:";
            // 
            // dgv_StatisticDM
            // 
            this.dgv_StatisticDM.AllowUserToAddRows = false;
            this.dgv_StatisticDM.AllowUserToDeleteRows = false;
            this.dgv_StatisticDM.AllowUserToResizeColumns = false;
            this.dgv_StatisticDM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_StatisticDM.Enabled = false;
            this.dgv_StatisticDM.Location = new System.Drawing.Point(10, 15);
            this.dgv_StatisticDM.Name = "dgv_StatisticDM";
            this.dgv_StatisticDM.ReadOnly = true;
            this.dgv_StatisticDM.Size = new System.Drawing.Size(470, 135);
            this.dgv_StatisticDM.TabIndex = 0;
            // 
            // cb_Statistic_ExchangeRate
            // 
            this.cb_Statistic_ExchangeRate.FormattingEnabled = true;
            this.cb_Statistic_ExchangeRate.Items.AddRange(new object[] {
            "PLN",
            "EUR",
            "USD",
            "SEK"});
            this.cb_Statistic_ExchangeRate.Location = new System.Drawing.Point(490, 15);
            this.cb_Statistic_ExchangeRate.Name = "cb_Statistic_ExchangeRate";
            this.cb_Statistic_ExchangeRate.Size = new System.Drawing.Size(50, 21);
            this.cb_Statistic_ExchangeRate.TabIndex = 1;
            this.cb_Statistic_ExchangeRate.SelectedIndexChanged += new System.EventHandler(this.Cb_Statistic_ExchangeRate_SelectedIndexChanged);
            // 
            // DMView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_StatisticDM);
            this.Name = "DMView";
            this.Size = new System.Drawing.Size(550, 160);
            this.gb_StatisticDM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StatisticDM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_StatisticDM;
        private System.Windows.Forms.ComboBox cb_Statistic_ExchangeRate;
        private System.Windows.Forms.DataGridView dgv_StatisticDM;
    }
}
