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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gb_StatisticDM = new System.Windows.Forms.GroupBox();
            this.cb_Statistic_ExchangeRate = new System.Windows.Forms.ComboBox();
            this.dgv_StatisticDM = new System.Windows.Forms.DataGridView();
            this.DM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EA2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EA3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // dgv_StatisticDM
            // 
            this.dgv_StatisticDM.AllowUserToAddRows = false;
            this.dgv_StatisticDM.AllowUserToDeleteRows = false;
            this.dgv_StatisticDM.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_StatisticDM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_StatisticDM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_StatisticDM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DM,
            this.BU,
            this.EA1,
            this.EA2,
            this.EA3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_StatisticDM.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_StatisticDM.Enabled = false;
            this.dgv_StatisticDM.Location = new System.Drawing.Point(10, 15);
            this.dgv_StatisticDM.Name = "dgv_StatisticDM";
            this.dgv_StatisticDM.ReadOnly = true;
            this.dgv_StatisticDM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgv_StatisticDM.RowHeadersWidth = 58;
            this.dgv_StatisticDM.Size = new System.Drawing.Size(470, 135);
            this.dgv_StatisticDM.TabIndex = 0;
            // 
            // DM
            // 
            this.DM.HeaderText = "DM";
            this.DM.Name = "DM";
            this.DM.ReadOnly = true;
            this.DM.Width = 90;
            // 
            // BU
            // 
            this.BU.HeaderText = "BU";
            this.BU.Name = "BU";
            this.BU.ReadOnly = true;
            this.BU.Width = 80;
            // 
            // EA1
            // 
            this.EA1.HeaderText = "EA1";
            this.EA1.Name = "EA1";
            this.EA1.ReadOnly = true;
            this.EA1.Width = 80;
            // 
            // EA2
            // 
            this.EA2.HeaderText = "EA2";
            this.EA2.Name = "EA2";
            this.EA2.ReadOnly = true;
            this.EA2.Width = 80;
            // 
            // EA3
            // 
            this.EA3.HeaderText = "EA3";
            this.EA3.Name = "EA3";
            this.EA3.ReadOnly = true;
            this.EA3.Width = 80;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn DM;
        private System.Windows.Forms.DataGridViewTextBoxColumn BU;
        private System.Windows.Forms.DataGridViewTextBoxColumn EA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EA2;
        private System.Windows.Forms.DataGridViewTextBoxColumn EA3;
    }
}
