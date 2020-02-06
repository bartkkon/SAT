namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    partial class QuantityMonthAddView
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
            this.gb_NewQuantityMonth = new System.Windows.Forms.GroupBox();
            this.pb_Admin_SaveQuantityMonth = new System.Windows.Forms.Button();
            this.num_Admin_YearMonth = new System.Windows.Forms.NumericUpDown();
            this.num_Admin_QuantityMonth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_AdminANCMonth = new System.Windows.Forms.CheckBox();
            this.cb_AdminPNCMonth = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pb_Admin_SaveCalcMonthNew = new System.Windows.Forms.Button();
            this.gb_NewQuantityMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_YearMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_QuantityMonth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_NewQuantityMonth
            // 
            this.gb_NewQuantityMonth.Controls.Add(this.pb_Admin_SaveQuantityMonth);
            this.gb_NewQuantityMonth.Controls.Add(this.num_Admin_YearMonth);
            this.gb_NewQuantityMonth.Controls.Add(this.num_Admin_QuantityMonth);
            this.gb_NewQuantityMonth.Controls.Add(this.label2);
            this.gb_NewQuantityMonth.Controls.Add(this.label1);
            this.gb_NewQuantityMonth.Controls.Add(this.cb_AdminANCMonth);
            this.gb_NewQuantityMonth.Controls.Add(this.cb_AdminPNCMonth);
            this.gb_NewQuantityMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_NewQuantityMonth.Location = new System.Drawing.Point(0, 0);
            this.gb_NewQuantityMonth.Name = "gb_NewQuantityMonth";
            this.gb_NewQuantityMonth.Size = new System.Drawing.Size(200, 150);
            this.gb_NewQuantityMonth.TabIndex = 0;
            this.gb_NewQuantityMonth.TabStop = false;
            this.gb_NewQuantityMonth.Text = "AddQyantity pew Month";
            // 
            // pb_Admin_SaveQuantityMonth
            // 
            this.pb_Admin_SaveQuantityMonth.Location = new System.Drawing.Point(50, 105);
            this.pb_Admin_SaveQuantityMonth.Name = "pb_Admin_SaveQuantityMonth";
            this.pb_Admin_SaveQuantityMonth.Size = new System.Drawing.Size(100, 35);
            this.pb_Admin_SaveQuantityMonth.TabIndex = 6;
            this.pb_Admin_SaveQuantityMonth.Text = "Add Quantity";
            this.pb_Admin_SaveQuantityMonth.UseVisualStyleBackColor = true;
            this.pb_Admin_SaveQuantityMonth.Click += new System.EventHandler(this.Pb_Admin_SaveQuantityMonth_Click);
            // 
            // num_Admin_YearMonth
            // 
            this.num_Admin_YearMonth.Location = new System.Drawing.Point(92, 74);
            this.num_Admin_YearMonth.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.num_Admin_YearMonth.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_Admin_YearMonth.Name = "num_Admin_YearMonth";
            this.num_Admin_YearMonth.Size = new System.Drawing.Size(80, 20);
            this.num_Admin_YearMonth.TabIndex = 5;
            this.num_Admin_YearMonth.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // num_Admin_QuantityMonth
            // 
            this.num_Admin_QuantityMonth.Location = new System.Drawing.Point(92, 48);
            this.num_Admin_QuantityMonth.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.num_Admin_QuantityMonth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_Admin_QuantityMonth.Name = "num_Admin_QuantityMonth";
            this.num_Admin_QuantityMonth.Size = new System.Drawing.Size(80, 20);
            this.num_Admin_QuantityMonth.TabIndex = 4;
            this.num_Admin_QuantityMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Year:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Month:";
            // 
            // cb_AdminANCMonth
            // 
            this.cb_AdminANCMonth.AutoSize = true;
            this.cb_AdminANCMonth.Location = new System.Drawing.Point(97, 19);
            this.cb_AdminANCMonth.Name = "cb_AdminANCMonth";
            this.cb_AdminANCMonth.Size = new System.Drawing.Size(48, 17);
            this.cb_AdminANCMonth.TabIndex = 1;
            this.cb_AdminANCMonth.Text = "ANC";
            this.cb_AdminANCMonth.UseVisualStyleBackColor = true;
            this.cb_AdminANCMonth.CheckedChanged += new System.EventHandler(this.Cb_AdminMonth_CheckedChanged);
            // 
            // cb_AdminPNCMonth
            // 
            this.cb_AdminPNCMonth.AutoSize = true;
            this.cb_AdminPNCMonth.Location = new System.Drawing.Point(34, 19);
            this.cb_AdminPNCMonth.Name = "cb_AdminPNCMonth";
            this.cb_AdminPNCMonth.Size = new System.Drawing.Size(48, 17);
            this.cb_AdminPNCMonth.TabIndex = 0;
            this.cb_AdminPNCMonth.Text = "PNC";
            this.cb_AdminPNCMonth.UseVisualStyleBackColor = true;
            this.cb_AdminPNCMonth.CheckedChanged += new System.EventHandler(this.Cb_AdminMonth_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pb_Admin_SaveCalcMonthNew);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calc Month:";
            // 
            // pb_Admin_SaveCalcMonthNew
            // 
            this.pb_Admin_SaveCalcMonthNew.Location = new System.Drawing.Point(50, 19);
            this.pb_Admin_SaveCalcMonthNew.Name = "pb_Admin_SaveCalcMonthNew";
            this.pb_Admin_SaveCalcMonthNew.Size = new System.Drawing.Size(100, 35);
            this.pb_Admin_SaveCalcMonthNew.TabIndex = 7;
            this.pb_Admin_SaveCalcMonthNew.Text = "Calc Month";
            this.pb_Admin_SaveCalcMonthNew.UseVisualStyleBackColor = true;
            this.pb_Admin_SaveCalcMonthNew.Click += new System.EventHandler(this.Pb_Admin_SaveCalcMonthNew_Click);
            // 
            // QuantityMonthAddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_NewQuantityMonth);
            this.Name = "QuantityMonthAddView";
            this.Size = new System.Drawing.Size(200, 220);
            this.gb_NewQuantityMonth.ResumeLayout(false);
            this.gb_NewQuantityMonth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_YearMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_QuantityMonth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_NewQuantityMonth;
        private System.Windows.Forms.CheckBox cb_AdminANCMonth;
        private System.Windows.Forms.CheckBox cb_AdminPNCMonth;
        private System.Windows.Forms.Button pb_Admin_SaveQuantityMonth;
        private System.Windows.Forms.NumericUpDown num_Admin_YearMonth;
        private System.Windows.Forms.NumericUpDown num_Admin_QuantityMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button pb_Admin_SaveCalcMonthNew;
    }
}
