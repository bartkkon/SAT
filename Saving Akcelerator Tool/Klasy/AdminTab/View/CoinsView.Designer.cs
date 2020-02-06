namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    partial class CoinsView
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
            this.gb_AdminValue = new System.Windows.Forms.GroupBox();
            this.num_Admin_ValueYear = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pb_Admin_ValueRefresh = new System.Windows.Forms.Button();
            this.pb_Admin_ValueSave = new System.Windows.Forms.Button();
            this.tb_AdminECCC = new System.Windows.Forms.TextBox();
            this.tb_AdminEuro = new System.Windows.Forms.TextBox();
            this.tb_AdminSek = new System.Windows.Forms.TextBox();
            this.tb_AdminDolars = new System.Windows.Forms.TextBox();
            this.gb_AdminValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_ValueYear)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_AdminValue
            // 
            this.gb_AdminValue.Controls.Add(this.tb_AdminDolars);
            this.gb_AdminValue.Controls.Add(this.tb_AdminSek);
            this.gb_AdminValue.Controls.Add(this.tb_AdminEuro);
            this.gb_AdminValue.Controls.Add(this.tb_AdminECCC);
            this.gb_AdminValue.Controls.Add(this.pb_Admin_ValueSave);
            this.gb_AdminValue.Controls.Add(this.pb_Admin_ValueRefresh);
            this.gb_AdminValue.Controls.Add(this.label9);
            this.gb_AdminValue.Controls.Add(this.label8);
            this.gb_AdminValue.Controls.Add(this.label7);
            this.gb_AdminValue.Controls.Add(this.label6);
            this.gb_AdminValue.Controls.Add(this.label5);
            this.gb_AdminValue.Controls.Add(this.label4);
            this.gb_AdminValue.Controls.Add(this.label3);
            this.gb_AdminValue.Controls.Add(this.label2);
            this.gb_AdminValue.Controls.Add(this.label1);
            this.gb_AdminValue.Controls.Add(this.num_Admin_ValueYear);
            this.gb_AdminValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_AdminValue.Location = new System.Drawing.Point(0, 0);
            this.gb_AdminValue.Name = "gb_AdminValue";
            this.gb_AdminValue.Size = new System.Drawing.Size(200, 200);
            this.gb_AdminValue.TabIndex = 0;
            this.gb_AdminValue.TabStop = false;
            this.gb_AdminValue.Text = "Coins:";
            // 
            // num_Admin_ValueYear
            // 
            this.num_Admin_ValueYear.Location = new System.Drawing.Point(80, 25);
            this.num_Admin_ValueYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.num_Admin_ValueYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_Admin_ValueYear.Name = "num_Admin_ValueYear";
            this.num_Admin_ValueYear.Size = new System.Drawing.Size(82, 20);
            this.num_Admin_ValueYear.TabIndex = 0;
            this.num_Admin_ValueYear.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_Admin_ValueYear.ValueChanged += new System.EventHandler(this.Pb_Admin_ValueRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Year:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ECCC:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Euro";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dolar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Sek";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "zł";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(150, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "€";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(149, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "$";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(150, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "kr";
            // 
            // pb_Admin_ValueRefresh
            // 
            this.pb_Admin_ValueRefresh.Location = new System.Drawing.Point(6, 167);
            this.pb_Admin_ValueRefresh.Name = "pb_Admin_ValueRefresh";
            this.pb_Admin_ValueRefresh.Size = new System.Drawing.Size(71, 26);
            this.pb_Admin_ValueRefresh.TabIndex = 10;
            this.pb_Admin_ValueRefresh.Text = "Refresh";
            this.pb_Admin_ValueRefresh.UseVisualStyleBackColor = true;
            this.pb_Admin_ValueRefresh.Click += new System.EventHandler(this.Pb_Admin_ValueRefresh_Click);
            // 
            // pb_Admin_ValueSave
            // 
            this.pb_Admin_ValueSave.Location = new System.Drawing.Point(120, 167);
            this.pb_Admin_ValueSave.Name = "pb_Admin_ValueSave";
            this.pb_Admin_ValueSave.Size = new System.Drawing.Size(71, 26);
            this.pb_Admin_ValueSave.TabIndex = 11;
            this.pb_Admin_ValueSave.Text = "Save";
            this.pb_Admin_ValueSave.UseVisualStyleBackColor = true;
            this.pb_Admin_ValueSave.Click += new System.EventHandler(this.Pb_Admin_ValueSave_Click);
            // 
            // tb_AdminECCC
            // 
            this.tb_AdminECCC.Location = new System.Drawing.Point(80, 51);
            this.tb_AdminECCC.Name = "tb_AdminECCC";
            this.tb_AdminECCC.Size = new System.Drawing.Size(64, 20);
            this.tb_AdminECCC.TabIndex = 12;
            this.tb_AdminECCC.TextChanged += new System.EventHandler(this.Tb_Value_TextChange);
            // 
            // tb_AdminEuro
            // 
            this.tb_AdminEuro.Location = new System.Drawing.Point(80, 77);
            this.tb_AdminEuro.Name = "tb_AdminEuro";
            this.tb_AdminEuro.Size = new System.Drawing.Size(64, 20);
            this.tb_AdminEuro.TabIndex = 13;
            this.tb_AdminEuro.TextChanged += new System.EventHandler(this.Tb_Value_TextChange);
            // 
            // tb_AdminSek
            // 
            this.tb_AdminSek.Location = new System.Drawing.Point(80, 129);
            this.tb_AdminSek.Name = "tb_AdminSek";
            this.tb_AdminSek.Size = new System.Drawing.Size(64, 20);
            this.tb_AdminSek.TabIndex = 14;
            this.tb_AdminSek.TextChanged += new System.EventHandler(this.Tb_Value_TextChange);
            // 
            // tb_AdminDolars
            // 
            this.tb_AdminDolars.Location = new System.Drawing.Point(80, 103);
            this.tb_AdminDolars.Name = "tb_AdminDolars";
            this.tb_AdminDolars.Size = new System.Drawing.Size(64, 20);
            this.tb_AdminDolars.TabIndex = 15;
            this.tb_AdminDolars.TextChanged += new System.EventHandler(this.Tb_Value_TextChange);
            // 
            // CoinsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_AdminValue);
            this.Name = "CoinsView";
            this.Size = new System.Drawing.Size(200, 200);
            this.gb_AdminValue.ResumeLayout(false);
            this.gb_AdminValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_ValueYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_AdminValue;
        private System.Windows.Forms.TextBox tb_AdminDolars;
        private System.Windows.Forms.TextBox tb_AdminSek;
        private System.Windows.Forms.TextBox tb_AdminEuro;
        private System.Windows.Forms.TextBox tb_AdminECCC;
        private System.Windows.Forms.Button pb_Admin_ValueSave;
        private System.Windows.Forms.Button pb_Admin_ValueRefresh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_Admin_ValueYear;
    }
}
