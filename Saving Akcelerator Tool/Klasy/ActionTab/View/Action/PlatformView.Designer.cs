namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class PlatformView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cb_DMD = new System.Windows.Forms.CheckBox();
            this.Cb_D45 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cb_D45);
            this.groupBox1.Controls.Add(this.Cb_DMD);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Platform:";
            // 
            // Cb_DMD
            // 
            this.Cb_DMD.AutoSize = true;
            this.Cb_DMD.Location = new System.Drawing.Point(34, 25);
            this.Cb_DMD.Name = "Cb_DMD";
            this.Cb_DMD.Size = new System.Drawing.Size(51, 17);
            this.Cb_DMD.TabIndex = 0;
            this.Cb_DMD.Text = "DMD";
            this.Cb_DMD.UseVisualStyleBackColor = true;
            // 
            // Cb_D45
            // 
            this.Cb_D45.AutoSize = true;
            this.Cb_D45.Location = new System.Drawing.Point(101, 25);
            this.Cb_D45.Name = "Cb_D45";
            this.Cb_D45.Size = new System.Drawing.Size(46, 17);
            this.Cb_D45.TabIndex = 1;
            this.Cb_D45.Text = "D45";
            this.Cb_D45.UseVisualStyleBackColor = true;
            // 
            // PlatformView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "PlatformView";
            this.Size = new System.Drawing.Size(175, 55);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Cb_D45;
        private System.Windows.Forms.CheckBox Cb_DMD;
    }
}
