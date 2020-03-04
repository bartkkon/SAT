namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.View
{
    partial class SDSumAllAction
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gb_ShowActionSum = new System.Windows.Forms.GroupBox();
            this.gb_ChartFilters = new System.Windows.Forms.GroupBox();
            this.cb_ChartFilters_ECCC = new System.Windows.Forms.CheckBox();
            this.cb_ChartFilters_CarryOver = new System.Windows.Forms.CheckBox();
            this.cb_ChartFilters_Actual = new System.Windows.Forms.CheckBox();
            this.cb_ChartFilters_BU = new System.Windows.Forms.CheckBox();
            this.cb_ChartFilters_EA1 = new System.Windows.Forms.CheckBox();
            this.cb_ChartFilters_EA2 = new System.Windows.Forms.CheckBox();
            this.cb_ChartFilters_EA3 = new System.Windows.Forms.CheckBox();
            this.cb_ChartFilters_USE = new System.Windows.Forms.CheckBox();
            this.dgv_SumPlan = new System.Windows.Forms.DataGridView();
            this.dgv_PlanECCC = new System.Windows.Forms.DataGridView();
            this.dgv_PlanCarryOver = new System.Windows.Forms.DataGridView();
            this.dgv_PlanActual = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_ECCCSum = new System.Windows.Forms.DataGridView();
            this.dgv_CarryOverSum = new System.Windows.Forms.DataGridView();
            this.dgv_SavingSum = new System.Windows.Forms.DataGridView();
            this.ChartSummary = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gb_ShowActionSum.SuspendLayout();
            this.gb_ChartFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SumPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PlanECCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PlanCarryOver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PlanActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ECCCSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CarryOverSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SavingSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartSummary)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_ShowActionSum
            // 
            this.gb_ShowActionSum.Controls.Add(this.ChartSummary);
            this.gb_ShowActionSum.Controls.Add(this.gb_ChartFilters);
            this.gb_ShowActionSum.Controls.Add(this.dgv_SumPlan);
            this.gb_ShowActionSum.Controls.Add(this.dgv_PlanECCC);
            this.gb_ShowActionSum.Controls.Add(this.dgv_PlanCarryOver);
            this.gb_ShowActionSum.Controls.Add(this.dgv_PlanActual);
            this.gb_ShowActionSum.Controls.Add(this.label3);
            this.gb_ShowActionSum.Controls.Add(this.label2);
            this.gb_ShowActionSum.Controls.Add(this.label1);
            this.gb_ShowActionSum.Controls.Add(this.dgv_ECCCSum);
            this.gb_ShowActionSum.Controls.Add(this.dgv_CarryOverSum);
            this.gb_ShowActionSum.Controls.Add(this.dgv_SavingSum);
            this.gb_ShowActionSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_ShowActionSum.Location = new System.Drawing.Point(0, 0);
            this.gb_ShowActionSum.Name = "gb_ShowActionSum";
            this.gb_ShowActionSum.Size = new System.Drawing.Size(1600, 970);
            this.gb_ShowActionSum.TabIndex = 0;
            this.gb_ShowActionSum.TabStop = false;
            // 
            // gb_ChartFilters
            // 
            this.gb_ChartFilters.Controls.Add(this.cb_ChartFilters_ECCC);
            this.gb_ChartFilters.Controls.Add(this.cb_ChartFilters_CarryOver);
            this.gb_ChartFilters.Controls.Add(this.cb_ChartFilters_Actual);
            this.gb_ChartFilters.Controls.Add(this.cb_ChartFilters_BU);
            this.gb_ChartFilters.Controls.Add(this.cb_ChartFilters_EA1);
            this.gb_ChartFilters.Controls.Add(this.cb_ChartFilters_EA2);
            this.gb_ChartFilters.Controls.Add(this.cb_ChartFilters_EA3);
            this.gb_ChartFilters.Controls.Add(this.cb_ChartFilters_USE);
            this.gb_ChartFilters.Location = new System.Drawing.Point(7, 627);
            this.gb_ChartFilters.Name = "gb_ChartFilters";
            this.gb_ChartFilters.Size = new System.Drawing.Size(300, 70);
            this.gb_ChartFilters.TabIndex = 10;
            this.gb_ChartFilters.TabStop = false;
            this.gb_ChartFilters.Text = "ChartFilters:";
            // 
            // cb_ChartFilters_ECCC
            // 
            this.cb_ChartFilters_ECCC.AutoSize = true;
            this.cb_ChartFilters_ECCC.Checked = true;
            this.cb_ChartFilters_ECCC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ChartFilters_ECCC.Location = new System.Drawing.Point(220, 42);
            this.cb_ChartFilters_ECCC.Name = "cb_ChartFilters_ECCC";
            this.cb_ChartFilters_ECCC.Size = new System.Drawing.Size(54, 17);
            this.cb_ChartFilters_ECCC.TabIndex = 16;
            this.cb_ChartFilters_ECCC.Text = "ECCC";
            this.cb_ChartFilters_ECCC.UseVisualStyleBackColor = true;
            this.cb_ChartFilters_ECCC.CheckedChanged += new System.EventHandler(this.Cb_ChartFilter_CheckedChanged);
            // 
            // cb_ChartFilters_CarryOver
            // 
            this.cb_ChartFilters_CarryOver.AutoSize = true;
            this.cb_ChartFilters_CarryOver.Checked = true;
            this.cb_ChartFilters_CarryOver.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ChartFilters_CarryOver.Location = new System.Drawing.Point(114, 42);
            this.cb_ChartFilters_CarryOver.Name = "cb_ChartFilters_CarryOver";
            this.cb_ChartFilters_CarryOver.Size = new System.Drawing.Size(76, 17);
            this.cb_ChartFilters_CarryOver.TabIndex = 15;
            this.cb_ChartFilters_CarryOver.Text = "Carry Over";
            this.cb_ChartFilters_CarryOver.UseVisualStyleBackColor = true;
            this.cb_ChartFilters_CarryOver.CheckedChanged += new System.EventHandler(this.Cb_ChartFilter_CheckedChanged);
            // 
            // cb_ChartFilters_Actual
            // 
            this.cb_ChartFilters_Actual.AutoSize = true;
            this.cb_ChartFilters_Actual.Checked = true;
            this.cb_ChartFilters_Actual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ChartFilters_Actual.Location = new System.Drawing.Point(10, 42);
            this.cb_ChartFilters_Actual.Name = "cb_ChartFilters_Actual";
            this.cb_ChartFilters_Actual.Size = new System.Drawing.Size(56, 17);
            this.cb_ChartFilters_Actual.TabIndex = 14;
            this.cb_ChartFilters_Actual.Text = "Actual";
            this.cb_ChartFilters_Actual.UseVisualStyleBackColor = true;
            this.cb_ChartFilters_Actual.CheckedChanged += new System.EventHandler(this.Cb_ChartFilter_CheckedChanged);
            // 
            // cb_ChartFilters_BU
            // 
            this.cb_ChartFilters_BU.AutoSize = true;
            this.cb_ChartFilters_BU.Checked = true;
            this.cb_ChartFilters_BU.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ChartFilters_BU.Location = new System.Drawing.Point(220, 19);
            this.cb_ChartFilters_BU.Name = "cb_ChartFilters_BU";
            this.cb_ChartFilters_BU.Size = new System.Drawing.Size(41, 17);
            this.cb_ChartFilters_BU.TabIndex = 13;
            this.cb_ChartFilters_BU.Text = "BU";
            this.cb_ChartFilters_BU.UseVisualStyleBackColor = true;
            this.cb_ChartFilters_BU.CheckedChanged += new System.EventHandler(this.Cb_ChartFilter_CheckedChanged);
            // 
            // cb_ChartFilters_EA1
            // 
            this.cb_ChartFilters_EA1.AutoSize = true;
            this.cb_ChartFilters_EA1.Checked = true;
            this.cb_ChartFilters_EA1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ChartFilters_EA1.Location = new System.Drawing.Point(168, 19);
            this.cb_ChartFilters_EA1.Name = "cb_ChartFilters_EA1";
            this.cb_ChartFilters_EA1.Size = new System.Drawing.Size(46, 17);
            this.cb_ChartFilters_EA1.TabIndex = 12;
            this.cb_ChartFilters_EA1.Text = "EA1";
            this.cb_ChartFilters_EA1.UseVisualStyleBackColor = true;
            this.cb_ChartFilters_EA1.CheckedChanged += new System.EventHandler(this.Cb_ChartFilter_CheckedChanged);
            // 
            // cb_ChartFilters_EA2
            // 
            this.cb_ChartFilters_EA2.AutoSize = true;
            this.cb_ChartFilters_EA2.Checked = true;
            this.cb_ChartFilters_EA2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ChartFilters_EA2.Location = new System.Drawing.Point(116, 19);
            this.cb_ChartFilters_EA2.Name = "cb_ChartFilters_EA2";
            this.cb_ChartFilters_EA2.Size = new System.Drawing.Size(46, 17);
            this.cb_ChartFilters_EA2.TabIndex = 11;
            this.cb_ChartFilters_EA2.Text = "EA2";
            this.cb_ChartFilters_EA2.UseVisualStyleBackColor = true;
            this.cb_ChartFilters_EA2.CheckedChanged += new System.EventHandler(this.Cb_ChartFilter_CheckedChanged);
            // 
            // cb_ChartFilters_EA3
            // 
            this.cb_ChartFilters_EA3.AutoSize = true;
            this.cb_ChartFilters_EA3.Checked = true;
            this.cb_ChartFilters_EA3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ChartFilters_EA3.Location = new System.Drawing.Point(64, 19);
            this.cb_ChartFilters_EA3.Name = "cb_ChartFilters_EA3";
            this.cb_ChartFilters_EA3.Size = new System.Drawing.Size(46, 17);
            this.cb_ChartFilters_EA3.TabIndex = 1;
            this.cb_ChartFilters_EA3.Text = "EA3";
            this.cb_ChartFilters_EA3.UseVisualStyleBackColor = true;
            this.cb_ChartFilters_EA3.CheckedChanged += new System.EventHandler(this.Cb_ChartFilter_CheckedChanged);
            // 
            // cb_ChartFilters_USE
            // 
            this.cb_ChartFilters_USE.AutoSize = true;
            this.cb_ChartFilters_USE.Checked = true;
            this.cb_ChartFilters_USE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ChartFilters_USE.Location = new System.Drawing.Point(10, 19);
            this.cb_ChartFilters_USE.Name = "cb_ChartFilters_USE";
            this.cb_ChartFilters_USE.Size = new System.Drawing.Size(48, 17);
            this.cb_ChartFilters_USE.TabIndex = 0;
            this.cb_ChartFilters_USE.Text = "USE";
            this.cb_ChartFilters_USE.UseVisualStyleBackColor = true;
            this.cb_ChartFilters_USE.CheckedChanged += new System.EventHandler(this.Cb_ChartFilter_CheckedChanged);
            // 
            // dgv_SumPlan
            // 
            this.dgv_SumPlan.AllowUserToAddRows = false;
            this.dgv_SumPlan.AllowUserToDeleteRows = false;
            this.dgv_SumPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SumPlan.Enabled = false;
            this.dgv_SumPlan.Location = new System.Drawing.Point(749, 551);
            this.dgv_SumPlan.Name = "dgv_SumPlan";
            this.dgv_SumPlan.ReadOnly = true;
            this.dgv_SumPlan.Size = new System.Drawing.Size(771, 146);
            this.dgv_SumPlan.TabIndex = 9;
            // 
            // dgv_PlanECCC
            // 
            this.dgv_PlanECCC.AllowUserToAddRows = false;
            this.dgv_PlanECCC.AllowUserToDeleteRows = false;
            this.dgv_PlanECCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PlanECCC.Enabled = false;
            this.dgv_PlanECCC.Location = new System.Drawing.Point(1190, 380);
            this.dgv_PlanECCC.Name = "dgv_PlanECCC";
            this.dgv_PlanECCC.ReadOnly = true;
            this.dgv_PlanECCC.Size = new System.Drawing.Size(330, 133);
            this.dgv_PlanECCC.TabIndex = 8;
            // 
            // dgv_PlanCarryOver
            // 
            this.dgv_PlanCarryOver.AllowUserToAddRows = false;
            this.dgv_PlanCarryOver.AllowUserToDeleteRows = false;
            this.dgv_PlanCarryOver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PlanCarryOver.Enabled = false;
            this.dgv_PlanCarryOver.Location = new System.Drawing.Point(1190, 205);
            this.dgv_PlanCarryOver.Name = "dgv_PlanCarryOver";
            this.dgv_PlanCarryOver.ReadOnly = true;
            this.dgv_PlanCarryOver.Size = new System.Drawing.Size(330, 133);
            this.dgv_PlanCarryOver.TabIndex = 7;
            // 
            // dgv_PlanActual
            // 
            this.dgv_PlanActual.AllowUserToAddRows = false;
            this.dgv_PlanActual.AllowUserToDeleteRows = false;
            this.dgv_PlanActual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_PlanActual.Enabled = false;
            this.dgv_PlanActual.Location = new System.Drawing.Point(1190, 30);
            this.dgv_PlanActual.Name = "dgv_PlanActual";
            this.dgv_PlanActual.ReadOnly = true;
            this.dgv_PlanActual.Size = new System.Drawing.Size(330, 133);
            this.dgv_PlanActual.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "ECCC:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(1, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Carry Over:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Actual:";
            // 
            // dgv_ECCCSum
            // 
            this.dgv_ECCCSum.AllowUserToAddRows = false;
            this.dgv_ECCCSum.AllowUserToDeleteRows = false;
            this.dgv_ECCCSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ECCCSum.Enabled = false;
            this.dgv_ECCCSum.Location = new System.Drawing.Point(5, 380);
            this.dgv_ECCCSum.Name = "dgv_ECCCSum";
            this.dgv_ECCCSum.ReadOnly = true;
            this.dgv_ECCCSum.Size = new System.Drawing.Size(1133, 155);
            this.dgv_ECCCSum.TabIndex = 2;
            // 
            // dgv_CarryOverSum
            // 
            this.dgv_CarryOverSum.AllowUserToAddRows = false;
            this.dgv_CarryOverSum.AllowUserToDeleteRows = false;
            this.dgv_CarryOverSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CarryOverSum.Enabled = false;
            this.dgv_CarryOverSum.Location = new System.Drawing.Point(5, 205);
            this.dgv_CarryOverSum.Name = "dgv_CarryOverSum";
            this.dgv_CarryOverSum.ReadOnly = true;
            this.dgv_CarryOverSum.Size = new System.Drawing.Size(1133, 155);
            this.dgv_CarryOverSum.TabIndex = 1;
            // 
            // dgv_SavingSum
            // 
            this.dgv_SavingSum.AllowUserToAddRows = false;
            this.dgv_SavingSum.AllowUserToDeleteRows = false;
            this.dgv_SavingSum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SavingSum.Enabled = false;
            this.dgv_SavingSum.Location = new System.Drawing.Point(5, 30);
            this.dgv_SavingSum.Name = "dgv_SavingSum";
            this.dgv_SavingSum.ReadOnly = true;
            this.dgv_SavingSum.Size = new System.Drawing.Size(1133, 155);
            this.dgv_SavingSum.TabIndex = 0;
            // 
            // ChartSummary
            // 
            this.ChartSummary.BorderlineColor = System.Drawing.Color.WhiteSmoke;
            legend1.Name = "Legend1";
            this.ChartSummary.Legends.Add(legend1);
            this.ChartSummary.Location = new System.Drawing.Point(7, 703);
            this.ChartSummary.Name = "ChartSummary";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ChartSummary.Series.Add(series1);
            this.ChartSummary.Size = new System.Drawing.Size(1585, 261);
            this.ChartSummary.TabIndex = 11;
            // 
            // SDSumAllAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_ShowActionSum);
            this.Name = "SDSumAllAction";
            this.Size = new System.Drawing.Size(1600, 970);
            this.gb_ShowActionSum.ResumeLayout(false);
            this.gb_ShowActionSum.PerformLayout();
            this.gb_ChartFilters.ResumeLayout(false);
            this.gb_ChartFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SumPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PlanECCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PlanCarryOver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_PlanActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ECCCSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CarryOverSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SavingSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartSummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_ShowActionSum;
        private System.Windows.Forms.DataGridView dgv_SavingSum;
        private System.Windows.Forms.DataGridView dgv_ECCCSum;
        private System.Windows.Forms.DataGridView dgv_CarryOverSum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_PlanECCC;
        private System.Windows.Forms.DataGridView dgv_PlanCarryOver;
        private System.Windows.Forms.DataGridView dgv_PlanActual;
        private System.Windows.Forms.DataGridView dgv_SumPlan;
        private System.Windows.Forms.GroupBox gb_ChartFilters;
        private System.Windows.Forms.CheckBox cb_ChartFilters_USE;
        private System.Windows.Forms.CheckBox cb_ChartFilters_ECCC;
        private System.Windows.Forms.CheckBox cb_ChartFilters_CarryOver;
        private System.Windows.Forms.CheckBox cb_ChartFilters_Actual;
        private System.Windows.Forms.CheckBox cb_ChartFilters_BU;
        private System.Windows.Forms.CheckBox cb_ChartFilters_EA1;
        private System.Windows.Forms.CheckBox cb_ChartFilters_EA2;
        private System.Windows.Forms.CheckBox cb_ChartFilters_EA3;
        public System.Windows.Forms.DataVisualization.Charting.Chart ChartSummary;
    }
}
