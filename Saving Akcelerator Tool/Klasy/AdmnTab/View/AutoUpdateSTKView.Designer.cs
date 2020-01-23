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
            this.label1 = new System.Windows.Forms.Label();
            this.num_Admin_AutoUpdateSTK_Year = new System.Windows.Forms.NumericUpDown();
            this.Pb_Admin_AutoUpdateSTK = new System.Windows.Forms.Button();
            this.gb_Admin_AutoUpdateSTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_AutoUpdateSTK_Year)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Admin_AutoUpdateSTK
            // 
            this.gb_Admin_AutoUpdateSTK.Controls.Add(this.Pb_Admin_AutoUpdateSTK);
            this.gb_Admin_AutoUpdateSTK.Controls.Add(this.num_Admin_AutoUpdateSTK_Year);
            this.gb_Admin_AutoUpdateSTK.Controls.Add(this.label1);
            this.gb_Admin_AutoUpdateSTK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Admin_AutoUpdateSTK.Location = new System.Drawing.Point(0, 0);
            this.gb_Admin_AutoUpdateSTK.Name = "gb_Admin_AutoUpdateSTK";
            this.gb_Admin_AutoUpdateSTK.Size = new System.Drawing.Size(200, 100);
            this.gb_Admin_AutoUpdateSTK.TabIndex = 0;
            this.gb_Admin_AutoUpdateSTK.TabStop = false;
            this.gb_Admin_AutoUpdateSTK.Text = "Auto Update STK:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year:";
            // 
            // num_Admin_AutoUpdateSTK_Year
            // 
            this.num_Admin_AutoUpdateSTK_Year.Location = new System.Drawing.Point(92, 23);
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
            // AutoUpdateSTKView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_Admin_AutoUpdateSTK);
            this.Name = "AutoUpdateSTKView";
            this.Size = new System.Drawing.Size(200, 100);
            this.gb_Admin_AutoUpdateSTK.ResumeLayout(false);
            this.gb_Admin_AutoUpdateSTK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Admin_AutoUpdateSTK_Year)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Admin_AutoUpdateSTK;
        private System.Windows.Forms.Button Pb_Admin_AutoUpdateSTK;
        private System.Windows.Forms.NumericUpDown num_Admin_AutoUpdateSTK_Year;
        private System.Windows.Forms.Label label1;
    }
}
