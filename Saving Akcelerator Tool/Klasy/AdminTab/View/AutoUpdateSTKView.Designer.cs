namespace Saving_Accelerator_Tool.Klasy.AdmnTab.View
{
    partial class AutoUpdateSTKView
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
            this.gb_Admin_AutoUpdateSTK = new System.Windows.Forms.GroupBox();
            this.Pb_Admin_AutoUpdateSTK = new System.Windows.Forms.Button();
            this.num_Admin_AutoUpdateSTK_Year = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pb_Admin_UpdateSTK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gb_Admin_AutoUpdateSTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_AutoUpdateSTK_Year)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Admin_AutoUpdateSTK
            // 
            this.gb_Admin_AutoUpdateSTK.Controls.Add(this.Pb_Admin_AutoUpdateSTK);
            this.gb_Admin_AutoUpdateSTK.Controls.Add(this.num_Admin_AutoUpdateSTK_Year);
            this.gb_Admin_AutoUpdateSTK.Controls.Add(this.label1);
            this.gb_Admin_AutoUpdateSTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Admin_AutoUpdateSTK.Location = new System.Drawing.Point(0, 180);
            this.gb_Admin_AutoUpdateSTK.Name = "gb_Admin_AutoUpdateSTK";
            this.gb_Admin_AutoUpdateSTK.Size = new System.Drawing.Size(200, 90);
            this.gb_Admin_AutoUpdateSTK.TabIndex = 0;
            this.gb_Admin_AutoUpdateSTK.TabStop = false;
            this.gb_Admin_AutoUpdateSTK.Text = "Auto Update STK:";
            // 
            // Pb_Admin_AutoUpdateSTK
            // 
            this.Pb_Admin_AutoUpdateSTK.Location = new System.Drawing.Point(40, 50);
            this.Pb_Admin_AutoUpdateSTK.Name = "Pb_Admin_AutoUpdateSTK";
            this.Pb_Admin_AutoUpdateSTK.Size = new System.Drawing.Size(120, 30);
            this.Pb_Admin_AutoUpdateSTK.TabIndex = 1;
            this.Pb_Admin_AutoUpdateSTK.Text = "Do AutoUpdate STK";
            this.Pb_Admin_AutoUpdateSTK.UseVisualStyleBackColor = true;
            this.Pb_Admin_AutoUpdateSTK.Click += new System.EventHandler(this.Pb_Admin_AutoUpdateSTK_Click);
            // 
            // num_Admin_AutoUpdateSTK_Year
            // 
            this.num_Admin_AutoUpdateSTK_Year.Location = new System.Drawing.Point(65, 21);
            this.num_Admin_AutoUpdateSTK_Year.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.num_Admin_AutoUpdateSTK_Year.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_Admin_AutoUpdateSTK_Year.Name = "num_Admin_AutoUpdateSTK_Year";
            this.num_Admin_AutoUpdateSTK_Year.Size = new System.Drawing.Size(83, 20);
            this.num_Admin_AutoUpdateSTK_Year.TabIndex = 1;
            this.num_Admin_AutoUpdateSTK_Year.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pb_Admin_UpdateSTK);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update STK:";
            // 
            // pb_Admin_UpdateSTK
            // 
            this.pb_Admin_UpdateSTK.Location = new System.Drawing.Point(40, 19);
            this.pb_Admin_UpdateSTK.Name = "pb_Admin_UpdateSTK";
            this.pb_Admin_UpdateSTK.Size = new System.Drawing.Size(120, 30);
            this.pb_Admin_UpdateSTK.TabIndex = 2;
            this.pb_Admin_UpdateSTK.Text = "Update STK";
            this.pb_Admin_UpdateSTK.UseVisualStyleBackColor = true;
            this.pb_Admin_UpdateSTK.Click += new System.EventHandler(this.Pb_Admin_UpdateSTK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 122);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manual Update:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Year:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(98, 20);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Clear Year";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Pb_Admin_YearClear_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(37, 82);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 30);
            this.button2.TabIndex = 3;
            this.button2.Text = "Manual Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Pb_Admin_ManualUpdate_Click);
            // 
            // AutoUpdateSTKView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_Admin_AutoUpdateSTK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AutoUpdateSTKView";
            this.Size = new System.Drawing.Size(200, 270);
            this.gb_Admin_AutoUpdateSTK.ResumeLayout(false);
            this.gb_Admin_AutoUpdateSTK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_AutoUpdateSTK_Year)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Admin_AutoUpdateSTK;
        private System.Windows.Forms.Button Pb_Admin_AutoUpdateSTK;
        private System.Windows.Forms.NumericUpDown num_Admin_AutoUpdateSTK_Year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button pb_Admin_UpdateSTK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
    }
}
