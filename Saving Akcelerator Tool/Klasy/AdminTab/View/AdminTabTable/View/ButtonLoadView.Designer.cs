namespace Saving_Accelerator_Tool.Klasy.AdminTab.View.AdminTabTable.View
{
    partial class ButtonLoadView
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
            this.but_Access = new System.Windows.Forms.Button();
            this.but_ANCMonthly = new System.Windows.Forms.Button();
            this.but_SaveChange = new System.Windows.Forms.Button();
            this.but_Clear = new System.Windows.Forms.Button();
            this.but_OptionANCRevision = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // but_Access
            // 
            this.but_Access.Location = new System.Drawing.Point(15, 15);
            this.but_Access.Name = "but_Access";
            this.but_Access.Size = new System.Drawing.Size(106, 23);
            this.but_Access.TabIndex = 0;
            this.but_Access.Text = "Access Load";
            this.but_Access.UseVisualStyleBackColor = true;
            this.but_Access.Click += new System.EventHandler(this.But_Access_Click);
            // 
            // but_ANCMonthly
            // 
            this.but_ANCMonthly.Location = new System.Drawing.Point(127, 15);
            this.but_ANCMonthly.Name = "but_ANCMonthly";
            this.but_ANCMonthly.Size = new System.Drawing.Size(106, 23);
            this.but_ANCMonthly.TabIndex = 1;
            this.but_ANCMonthly.Text = "ANC Monthly";
            this.but_ANCMonthly.UseVisualStyleBackColor = true;
            this.but_ANCMonthly.Click += new System.EventHandler(this.But_ANCMonthly_Click);
            // 
            // but_SaveChange
            // 
            this.but_SaveChange.Location = new System.Drawing.Point(1769, 15);
            this.but_SaveChange.Name = "but_SaveChange";
            this.but_SaveChange.Size = new System.Drawing.Size(127, 23);
            this.but_SaveChange.TabIndex = 2;
            this.but_SaveChange.Text = "Save change";
            this.but_SaveChange.UseVisualStyleBackColor = true;
            // 
            // but_Clear
            // 
            this.but_Clear.Location = new System.Drawing.Point(1769, 64);
            this.but_Clear.Name = "but_Clear";
            this.but_Clear.Size = new System.Drawing.Size(127, 23);
            this.but_Clear.TabIndex = 3;
            this.but_Clear.Text = "Clear Table";
            this.but_Clear.UseVisualStyleBackColor = true;
            this.but_Clear.Click += new System.EventHandler(this.But_Clear_Click);
            // 
            // but_OptionANCRevision
            // 
            this.but_OptionANCRevision.Location = new System.Drawing.Point(239, 15);
            this.but_OptionANCRevision.Name = "but_OptionANCRevision";
            this.but_OptionANCRevision.Size = new System.Drawing.Size(106, 23);
            this.but_OptionANCRevision.TabIndex = 4;
            this.but_OptionANCRevision.Text = "ANC Revision";
            this.but_OptionANCRevision.UseVisualStyleBackColor = true;
            this.but_OptionANCRevision.Click += new System.EventHandler(this.But_OptionANCRevision_Click);
            // 
            // ButtonLoadView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.but_OptionANCRevision);
            this.Controls.Add(this.but_Clear);
            this.Controls.Add(this.but_SaveChange);
            this.Controls.Add(this.but_ANCMonthly);
            this.Controls.Add(this.but_Access);
            this.Name = "ButtonLoadView";
            this.Size = new System.Drawing.Size(1912, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_Access;
        private System.Windows.Forms.Button but_ANCMonthly;
        private System.Windows.Forms.Button but_SaveChange;
        private System.Windows.Forms.Button but_Clear;
        private System.Windows.Forms.Button but_OptionANCRevision;
    }
}
