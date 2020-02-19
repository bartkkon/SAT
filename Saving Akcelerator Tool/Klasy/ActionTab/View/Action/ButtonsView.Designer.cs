namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class ButtonsView
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
            this.pb_IDCO = new System.Windows.Forms.Button();
            this.pb_SavePNC = new System.Windows.Forms.Button();
            this.pb_SpecialCalc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pb_IDCO
            // 
            this.pb_IDCO.Location = new System.Drawing.Point(5, 3);
            this.pb_IDCO.Name = "pb_IDCO";
            this.pb_IDCO.Size = new System.Drawing.Size(70, 28);
            this.pb_IDCO.TabIndex = 0;
            this.pb_IDCO.Text = "IDCO";
            this.pb_IDCO.UseVisualStyleBackColor = true;
            this.pb_IDCO.Click += new System.EventHandler(this.pb_IDCO_Click);
            // 
            // pb_SavePNC
            // 
            this.pb_SavePNC.Location = new System.Drawing.Point(5, 469);
            this.pb_SavePNC.Name = "pb_SavePNC";
            this.pb_SavePNC.Size = new System.Drawing.Size(70, 28);
            this.pb_SavePNC.TabIndex = 1;
            this.pb_SavePNC.Text = "Save Data";
            this.pb_SavePNC.UseVisualStyleBackColor = true;
            this.pb_SavePNC.Visible = false;
            this.pb_SavePNC.Click += new System.EventHandler(this.pb_SavePNC_Click);
            // 
            // pb_SpecialCalc
            // 
            this.pb_SpecialCalc.Enabled = false;
            this.pb_SpecialCalc.Location = new System.Drawing.Point(5, 435);
            this.pb_SpecialCalc.Name = "pb_SpecialCalc";
            this.pb_SpecialCalc.Size = new System.Drawing.Size(70, 28);
            this.pb_SpecialCalc.TabIndex = 2;
            this.pb_SpecialCalc.Text = "Spec Calc";
            this.pb_SpecialCalc.UseVisualStyleBackColor = true;
            this.pb_SpecialCalc.Visible = false;
            this.pb_SpecialCalc.Click += new System.EventHandler(this.pb_SpecialCalc_Click);
            // 
            // ButtonsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pb_SpecialCalc);
            this.Controls.Add(this.pb_SavePNC);
            this.Controls.Add(this.pb_IDCO);
            this.Name = "ButtonsView";
            this.Size = new System.Drawing.Size(80, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pb_IDCO;
        private System.Windows.Forms.Button pb_SavePNC;
        private System.Windows.Forms.Button pb_SpecialCalc;
    }
}
