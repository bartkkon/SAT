namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class ECCCView
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
            this.Gb_ECCC = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Num_ECCC = new System.Windows.Forms.NumericUpDown();
            this.Cb_ECCCSpec = new System.Windows.Forms.CheckBox();
            this.Cb_ECCC = new System.Windows.Forms.CheckBox();
            this.Gb_ECCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_ECCC)).BeginInit();
            this.SuspendLayout();
            // 
            // Gb_ECCC
            // 
            this.Gb_ECCC.Controls.Add(this.label1);
            this.Gb_ECCC.Controls.Add(this.Num_ECCC);
            this.Gb_ECCC.Controls.Add(this.Cb_ECCCSpec);
            this.Gb_ECCC.Controls.Add(this.Cb_ECCC);
            this.Gb_ECCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gb_ECCC.Location = new System.Drawing.Point(0, 0);
            this.Gb_ECCC.Name = "Gb_ECCC";
            this.Gb_ECCC.Size = new System.Drawing.Size(120, 115);
            this.Gb_ECCC.TabIndex = 0;
            this.Gb_ECCC.TabStop = false;
            this.Gb_ECCC.Text = "ECCC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "sec.";
            // 
            // Num_ECCC
            // 
            this.Num_ECCC.Enabled = false;
            this.Num_ECCC.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Num_ECCC.Location = new System.Drawing.Point(19, 51);
            this.Num_ECCC.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.Num_ECCC.Name = "Num_ECCC";
            this.Num_ECCC.Size = new System.Drawing.Size(57, 20);
            this.Num_ECCC.TabIndex = 2;
            this.Num_ECCC.Click += new System.EventHandler(this.Change);
            // 
            // Cb_ECCCSpec
            // 
            this.Cb_ECCCSpec.AutoSize = true;
            this.Cb_ECCCSpec.Enabled = false;
            this.Cb_ECCCSpec.Location = new System.Drawing.Point(19, 85);
            this.Cb_ECCCSpec.Name = "Cb_ECCCSpec";
            this.Cb_ECCCSpec.Size = new System.Drawing.Size(92, 17);
            this.Cb_ECCCSpec.TabIndex = 1;
            this.Cb_ECCCSpec.Text = "ECCC Special";
            this.Cb_ECCCSpec.UseVisualStyleBackColor = true;
            this.Cb_ECCCSpec.Visible = false;
            this.Cb_ECCCSpec.CheckedChanged += new System.EventHandler(this.Cb_ECCCSpec_CheckedChanged);
            // 
            // Cb_ECCC
            // 
            this.Cb_ECCC.AutoSize = true;
            this.Cb_ECCC.Location = new System.Drawing.Point(19, 23);
            this.Cb_ECCC.Name = "Cb_ECCC";
            this.Cb_ECCC.Size = new System.Drawing.Size(54, 17);
            this.Cb_ECCC.TabIndex = 0;
            this.Cb_ECCC.Text = "ECCC";
            this.Cb_ECCC.UseVisualStyleBackColor = true;
            this.Cb_ECCC.CheckedChanged += new System.EventHandler(this.Cb_ECCC_CheckedChanged);
            // 
            // ECCCView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Gb_ECCC);
            this.Name = "ECCCView";
            this.Size = new System.Drawing.Size(120, 115);
            this.Gb_ECCC.ResumeLayout(false);
            this.Gb_ECCC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_ECCC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Gb_ECCC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Num_ECCC;
        private System.Windows.Forms.CheckBox Cb_ECCCSpec;
        private System.Windows.Forms.CheckBox Cb_ECCC;
    }
}
