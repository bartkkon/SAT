namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class InstallationView
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
            this.Cb_InstallAll = new System.Windows.Forms.CheckBox();
            this.Cb_FI = new System.Windows.Forms.CheckBox();
            this.Cb_FS = new System.Windows.Forms.CheckBox();
            this.Cb_BI = new System.Windows.Forms.CheckBox();
            this.Cb_BU = new System.Windows.Forms.CheckBox();
            this.Cb_FSBU = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Cb_FSBU);
            this.groupBox1.Controls.Add(this.Cb_BU);
            this.groupBox1.Controls.Add(this.Cb_BI);
            this.groupBox1.Controls.Add(this.Cb_FS);
            this.groupBox1.Controls.Add(this.Cb_FI);
            this.groupBox1.Controls.Add(this.Cb_InstallAll);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Installation:";
            // 
            // Cb_InstallAll
            // 
            this.Cb_InstallAll.AutoSize = true;
            this.Cb_InstallAll.Location = new System.Drawing.Point(12, 18);
            this.Cb_InstallAll.Name = "Cb_InstallAll";
            this.Cb_InstallAll.Size = new System.Drawing.Size(37, 17);
            this.Cb_InstallAll.TabIndex = 0;
            this.Cb_InstallAll.Text = "All";
            this.Cb_InstallAll.UseVisualStyleBackColor = true;
            this.Cb_InstallAll.CheckedChanged += new System.EventHandler(this.Cb_Installation_CheckedChanged);
            // 
            // Cb_FI
            // 
            this.Cb_FI.AutoSize = true;
            this.Cb_FI.Location = new System.Drawing.Point(67, 18);
            this.Cb_FI.Name = "Cb_FI";
            this.Cb_FI.Size = new System.Drawing.Size(35, 17);
            this.Cb_FI.TabIndex = 1;
            this.Cb_FI.Text = "FI";
            this.Cb_FI.UseVisualStyleBackColor = true;
            this.Cb_FI.CheckedChanged += new System.EventHandler(this.Cb_Installation_CheckedChanged);
            // 
            // Cb_FS
            // 
            this.Cb_FS.AutoSize = true;
            this.Cb_FS.Location = new System.Drawing.Point(118, 18);
            this.Cb_FS.Name = "Cb_FS";
            this.Cb_FS.Size = new System.Drawing.Size(39, 17);
            this.Cb_FS.TabIndex = 2;
            this.Cb_FS.Text = "FS";
            this.Cb_FS.UseVisualStyleBackColor = true;
            this.Cb_FS.CheckedChanged += new System.EventHandler(this.Cb_Installation_CheckedChanged);
            // 
            // Cb_BI
            // 
            this.Cb_BI.AutoSize = true;
            this.Cb_BI.Location = new System.Drawing.Point(12, 37);
            this.Cb_BI.Name = "Cb_BI";
            this.Cb_BI.Size = new System.Drawing.Size(36, 17);
            this.Cb_BI.TabIndex = 3;
            this.Cb_BI.Text = "BI";
            this.Cb_BI.UseVisualStyleBackColor = true;
            this.Cb_BI.CheckedChanged += new System.EventHandler(this.Cb_Installation_CheckedChanged);
            // 
            // cb_BU
            // 
            this.Cb_BU.AutoSize = true;
            this.Cb_BU.Location = new System.Drawing.Point(67, 37);
            this.Cb_BU.Name = "cb_BU";
            this.Cb_BU.Size = new System.Drawing.Size(41, 17);
            this.Cb_BU.TabIndex = 4;
            this.Cb_BU.Text = "BU";
            this.Cb_BU.UseVisualStyleBackColor = true;
            this.Cb_BU.CheckedChanged += new System.EventHandler(this.Cb_Installation_CheckedChanged);
            // 
            // Cb_FSBU
            // 
            this.Cb_FSBU.AutoSize = true;
            this.Cb_FSBU.Location = new System.Drawing.Point(118, 37);
            this.Cb_FSBU.Name = "Cb_FSBU";
            this.Cb_FSBU.Size = new System.Drawing.Size(54, 17);
            this.Cb_FSBU.TabIndex = 5;
            this.Cb_FSBU.Text = "FSBU";
            this.Cb_FSBU.UseVisualStyleBackColor = true;
            this.Cb_FSBU.CheckedChanged += new System.EventHandler(this.Cb_Installation_CheckedChanged);
            // 
            // InstallationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "InstallationView";
            this.Size = new System.Drawing.Size(175, 60);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Cb_InstallAll;
        private System.Windows.Forms.CheckBox Cb_FSBU;
        private System.Windows.Forms.CheckBox Cb_BU;
        private System.Windows.Forms.CheckBox Cb_BI;
        private System.Windows.Forms.CheckBox Cb_FS;
        private System.Windows.Forms.CheckBox Cb_FI;
    }
}
