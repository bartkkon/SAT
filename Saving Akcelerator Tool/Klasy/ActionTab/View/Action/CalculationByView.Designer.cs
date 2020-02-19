namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class CalculationByView
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
            this.Cb_CalcANC = new System.Windows.Forms.CheckBox();
            this.Cb_CalcANCby = new System.Windows.Forms.CheckBox();
            this.Cb_CalcPNC = new System.Windows.Forms.CheckBox();
            this.Cb_CalcPNCSpec = new System.Windows.Forms.CheckBox();
            this.Pb_PNC = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Pb_PNC);
            this.groupBox1.Controls.Add(this.Cb_CalcPNCSpec);
            this.groupBox1.Controls.Add(this.Cb_CalcPNC);
            this.groupBox1.Controls.Add(this.Cb_CalcANCby);
            this.groupBox1.Controls.Add(this.Cb_CalcANC);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculation by:";
            // 
            // Cb_CalcANC
            // 
            this.Cb_CalcANC.AutoSize = true;
            this.Cb_CalcANC.Location = new System.Drawing.Point(15, 19);
            this.Cb_CalcANC.Name = "Cb_CalcANC";
            this.Cb_CalcANC.Size = new System.Drawing.Size(48, 17);
            this.Cb_CalcANC.TabIndex = 0;
            this.Cb_CalcANC.Text = "ANC";
            this.Cb_CalcANC.UseVisualStyleBackColor = true;
            this.Cb_CalcANC.CheckedChanged += new System.EventHandler(this.Cb_Calc_CheckedChanged);
            // 
            // Cb_CalcANCby
            // 
            this.Cb_CalcANCby.AutoSize = true;
            this.Cb_CalcANCby.Location = new System.Drawing.Point(15, 42);
            this.Cb_CalcANCby.Name = "Cb_CalcANCby";
            this.Cb_CalcANCby.Size = new System.Drawing.Size(86, 17);
            this.Cb_CalcANCby.TabIndex = 1;
            this.Cb_CalcANCby.Text = "ANC Special";
            this.Cb_CalcANCby.UseVisualStyleBackColor = true;
            this.Cb_CalcANCby.CheckedChanged += new System.EventHandler(this.Cb_Calc_CheckedChanged);
            // 
            // Cb_CalcPNC
            // 
            this.Cb_CalcPNC.AutoSize = true;
            this.Cb_CalcPNC.Location = new System.Drawing.Point(15, 65);
            this.Cb_CalcPNC.Name = "Cb_CalcPNC";
            this.Cb_CalcPNC.Size = new System.Drawing.Size(48, 17);
            this.Cb_CalcPNC.TabIndex = 2;
            this.Cb_CalcPNC.Text = "PNC";
            this.Cb_CalcPNC.UseVisualStyleBackColor = true;
            this.Cb_CalcPNC.CheckedChanged += new System.EventHandler(this.Cb_Calc_CheckedChanged);
            // 
            // Cb_CalcPNCSpec
            // 
            this.Cb_CalcPNCSpec.AutoSize = true;
            this.Cb_CalcPNCSpec.Location = new System.Drawing.Point(15, 88);
            this.Cb_CalcPNCSpec.Name = "Cb_CalcPNCSpec";
            this.Cb_CalcPNCSpec.Size = new System.Drawing.Size(86, 17);
            this.Cb_CalcPNCSpec.TabIndex = 3;
            this.Cb_CalcPNCSpec.Text = "PNC Special";
            this.Cb_CalcPNCSpec.UseVisualStyleBackColor = true;
            this.Cb_CalcPNCSpec.CheckedChanged += new System.EventHandler(this.Cb_Calc_CheckedChanged);
            // 
            // Pb_PNC
            // 
            this.Pb_PNC.Location = new System.Drawing.Point(110, 72);
            this.Pb_PNC.Name = "Pb_PNC";
            this.Pb_PNC.Size = new System.Drawing.Size(92, 25);
            this.Pb_PNC.TabIndex = 4;
            this.Pb_PNC.UseVisualStyleBackColor = true;
            this.Pb_PNC.Visible = false;
            this.Pb_PNC.Click += new System.EventHandler(this.Pb_PNC_Click);
            // 
            // CalculationByView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "CalculationByView";
            this.Size = new System.Drawing.Size(220, 115);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Pb_PNC;
        private System.Windows.Forms.CheckBox Cb_CalcPNCSpec;
        private System.Windows.Forms.CheckBox Cb_CalcPNC;
        private System.Windows.Forms.CheckBox Cb_CalcANCby;
        private System.Windows.Forms.CheckBox Cb_CalcANC;
    }
}
