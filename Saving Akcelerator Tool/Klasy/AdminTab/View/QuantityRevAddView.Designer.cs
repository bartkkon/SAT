namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    partial class QuantityRevAddView
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
            this.gb_NewQuantity = new System.Windows.Forms.GroupBox();
            this.cb_AdminPNC = new System.Windows.Forms.CheckBox();
            this.cb_AdminANC = new System.Windows.Forms.CheckBox();
            this.cb_AdminBU = new System.Windows.Forms.CheckBox();
            this.cb_AdminEA1 = new System.Windows.Forms.CheckBox();
            this.cb_AdminEA2 = new System.Windows.Forms.CheckBox();
            this.cb_AdminEA3 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.num_Admin_YearQuantity = new System.Windows.Forms.NumericUpDown();
            this.pb_Admin_SaveQuantity = new System.Windows.Forms.Button();
            this.gb_NewQuantityBU = new System.Windows.Forms.GroupBox();
            this.pb_Admin_SaveCalcRevNew = new System.Windows.Forms.Button();
            this.gb_NewQuantity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_YearQuantity)).BeginInit();
            this.gb_NewQuantityBU.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_NewQuantity
            // 
            this.gb_NewQuantity.Controls.Add(this.pb_Admin_SaveQuantity);
            this.gb_NewQuantity.Controls.Add(this.num_Admin_YearQuantity);
            this.gb_NewQuantity.Controls.Add(this.label2);
            this.gb_NewQuantity.Controls.Add(this.label1);
            this.gb_NewQuantity.Controls.Add(this.cb_AdminEA3);
            this.gb_NewQuantity.Controls.Add(this.cb_AdminEA2);
            this.gb_NewQuantity.Controls.Add(this.cb_AdminEA1);
            this.gb_NewQuantity.Controls.Add(this.cb_AdminBU);
            this.gb_NewQuantity.Controls.Add(this.cb_AdminANC);
            this.gb_NewQuantity.Controls.Add(this.cb_AdminPNC);
            this.gb_NewQuantity.Dock = System.Windows.Forms.DockStyle.Top;
            this.gb_NewQuantity.Location = new System.Drawing.Point(0, 0);
            this.gb_NewQuantity.Name = "gb_NewQuantity";
            this.gb_NewQuantity.Size = new System.Drawing.Size(200, 150);
            this.gb_NewQuantity.TabIndex = 0;
            this.gb_NewQuantity.TabStop = false;
            this.gb_NewQuantity.Text = "Add Quantity for Revision";
            // 
            // cb_AdminPNC
            // 
            this.cb_AdminPNC.AutoSize = true;
            this.cb_AdminPNC.Location = new System.Drawing.Point(6, 19);
            this.cb_AdminPNC.Name = "cb_AdminPNC";
            this.cb_AdminPNC.Size = new System.Drawing.Size(48, 17);
            this.cb_AdminPNC.TabIndex = 0;
            this.cb_AdminPNC.Text = "PNC";
            this.cb_AdminPNC.UseVisualStyleBackColor = true;
            this.cb_AdminPNC.CheckedChanged += new System.EventHandler(this.Cb_ChangeANC_PNC_CheckedChanged);
            // 
            // cb_AdminANC
            // 
            this.cb_AdminANC.AutoSize = true;
            this.cb_AdminANC.Location = new System.Drawing.Point(83, 19);
            this.cb_AdminANC.Name = "cb_AdminANC";
            this.cb_AdminANC.Size = new System.Drawing.Size(48, 17);
            this.cb_AdminANC.TabIndex = 1;
            this.cb_AdminANC.Text = "ANC";
            this.cb_AdminANC.UseVisualStyleBackColor = true;
            // 
            // cb_AdminBU
            // 
            this.cb_AdminBU.AutoSize = true;
            this.cb_AdminBU.Location = new System.Drawing.Point(6, 61);
            this.cb_AdminBU.Name = "cb_AdminBU";
            this.cb_AdminBU.Size = new System.Drawing.Size(41, 17);
            this.cb_AdminBU.TabIndex = 2;
            this.cb_AdminBU.Text = "BU";
            this.cb_AdminBU.UseVisualStyleBackColor = true;
            this.cb_AdminBU.CheckedChanged += new System.EventHandler(this.Cb_ChangeRewision_CheckedChanged);
            // 
            // cb_AdminEA1
            // 
            this.cb_AdminEA1.AutoSize = true;
            this.cb_AdminEA1.Location = new System.Drawing.Point(6, 84);
            this.cb_AdminEA1.Name = "cb_AdminEA1";
            this.cb_AdminEA1.Size = new System.Drawing.Size(46, 17);
            this.cb_AdminEA1.TabIndex = 3;
            this.cb_AdminEA1.Text = "EA1";
            this.cb_AdminEA1.UseVisualStyleBackColor = true;
            this.cb_AdminEA1.CheckedChanged += new System.EventHandler(this.Cb_ChangeRewision_CheckedChanged);
            // 
            // cb_AdminEA2
            // 
            this.cb_AdminEA2.AutoSize = true;
            this.cb_AdminEA2.Location = new System.Drawing.Point(6, 107);
            this.cb_AdminEA2.Name = "cb_AdminEA2";
            this.cb_AdminEA2.Size = new System.Drawing.Size(46, 17);
            this.cb_AdminEA2.TabIndex = 4;
            this.cb_AdminEA2.Text = "EA2";
            this.cb_AdminEA2.UseVisualStyleBackColor = true;
            this.cb_AdminEA2.CheckedChanged += new System.EventHandler(this.Cb_ChangeRewision_CheckedChanged);
            // 
            // cb_AdminEA3
            // 
            this.cb_AdminEA3.AutoSize = true;
            this.cb_AdminEA3.Location = new System.Drawing.Point(6, 130);
            this.cb_AdminEA3.Name = "cb_AdminEA3";
            this.cb_AdminEA3.Size = new System.Drawing.Size(46, 17);
            this.cb_AdminEA3.TabIndex = 5;
            this.cb_AdminEA3.Text = "EA3";
            this.cb_AdminEA3.UseVisualStyleBackColor = true;
            this.cb_AdminEA3.CheckedChanged += new System.EventHandler(this.Cb_ChangeRewision_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Revision:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Year:";
            // 
            // num_Admin_YearQuantity
            // 
            this.num_Admin_YearQuantity.Location = new System.Drawing.Point(102, 60);
            this.num_Admin_YearQuantity.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.num_Admin_YearQuantity.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_Admin_YearQuantity.Name = "num_Admin_YearQuantity";
            this.num_Admin_YearQuantity.Size = new System.Drawing.Size(68, 20);
            this.num_Admin_YearQuantity.TabIndex = 8;
            this.num_Admin_YearQuantity.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // pb_Admin_SaveQuantity
            // 
            this.pb_Admin_SaveQuantity.Location = new System.Drawing.Point(102, 95);
            this.pb_Admin_SaveQuantity.Name = "pb_Admin_SaveQuantity";
            this.pb_Admin_SaveQuantity.Size = new System.Drawing.Size(87, 38);
            this.pb_Admin_SaveQuantity.TabIndex = 9;
            this.pb_Admin_SaveQuantity.Text = "Add Q-ty";
            this.pb_Admin_SaveQuantity.UseVisualStyleBackColor = true;
            this.pb_Admin_SaveQuantity.Click += new System.EventHandler(this.Pb_AdminSaveQuantity_Click);
            // 
            // gb_NewQuantityBU
            // 
            this.gb_NewQuantityBU.Controls.Add(this.pb_Admin_SaveCalcRevNew);
            this.gb_NewQuantityBU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_NewQuantityBU.Location = new System.Drawing.Point(0, 150);
            this.gb_NewQuantityBU.Name = "gb_NewQuantityBU";
            this.gb_NewQuantityBU.Size = new System.Drawing.Size(200, 70);
            this.gb_NewQuantityBU.TabIndex = 1;
            this.gb_NewQuantityBU.TabStop = false;
            this.gb_NewQuantityBU.Text = "Calc Revision:";
            // 
            // pb_Admin_SaveCalcRevNew
            // 
            this.pb_Admin_SaveCalcRevNew.Location = new System.Drawing.Point(37, 19);
            this.pb_Admin_SaveCalcRevNew.Name = "pb_Admin_SaveCalcRevNew";
            this.pb_Admin_SaveCalcRevNew.Size = new System.Drawing.Size(111, 35);
            this.pb_Admin_SaveCalcRevNew.TabIndex = 0;
            this.pb_Admin_SaveCalcRevNew.Text = " Calc Revision";
            this.pb_Admin_SaveCalcRevNew.UseVisualStyleBackColor = true;
            this.pb_Admin_SaveCalcRevNew.Click += new System.EventHandler(this.Pb_AdminSaveCalcRevNew_Click);
            // 
            // QuantityRevAddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_NewQuantityBU);
            this.Controls.Add(this.gb_NewQuantity);
            this.Name = "QuantityRevAddView";
            this.Size = new System.Drawing.Size(200, 220);
            this.gb_NewQuantity.ResumeLayout(false);
            this.gb_NewQuantity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_YearQuantity)).EndInit();
            this.gb_NewQuantityBU.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_NewQuantity;
        private System.Windows.Forms.Button pb_Admin_SaveQuantity;
        private System.Windows.Forms.NumericUpDown num_Admin_YearQuantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_AdminEA3;
        private System.Windows.Forms.CheckBox cb_AdminEA2;
        private System.Windows.Forms.CheckBox cb_AdminEA1;
        private System.Windows.Forms.CheckBox cb_AdminBU;
        private System.Windows.Forms.CheckBox cb_AdminANC;
        private System.Windows.Forms.CheckBox cb_AdminPNC;
        private System.Windows.Forms.GroupBox gb_NewQuantityBU;
        private System.Windows.Forms.Button pb_Admin_SaveCalcRevNew;
    }
}
