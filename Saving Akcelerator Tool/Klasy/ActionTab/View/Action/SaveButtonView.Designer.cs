namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class SaveButtonView
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
            this.Pb_Save = new System.Windows.Forms.Button();
            this.Pb_SaveDraft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Pb_Save
            // 
            this.Pb_Save.Location = new System.Drawing.Point(15, 13);
            this.Pb_Save.Name = "Pb_Save";
            this.Pb_Save.Size = new System.Drawing.Size(100, 40);
            this.Pb_Save.TabIndex = 0;
            this.Pb_Save.Text = "Save";
            this.Pb_Save.UseVisualStyleBackColor = true;
            this.Pb_Save.Click += new System.EventHandler(this.Pb_Save_Click);
            // 
            // Pb_SaveDraft
            // 
            this.Pb_SaveDraft.Enabled = false;
            this.Pb_SaveDraft.Location = new System.Drawing.Point(15, 60);
            this.Pb_SaveDraft.Name = "Pb_SaveDraft";
            this.Pb_SaveDraft.Size = new System.Drawing.Size(100, 40);
            this.Pb_SaveDraft.TabIndex = 1;
            this.Pb_SaveDraft.Text = "Save as Draft";
            this.Pb_SaveDraft.UseVisualStyleBackColor = true;
            this.Pb_SaveDraft.Click += new System.EventHandler(this.Pb_SaveDraft_Click);
            // 
            // SaveButtonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Pb_SaveDraft);
            this.Controls.Add(this.Pb_Save);
            this.Name = "SaveButtonView";
            this.Size = new System.Drawing.Size(130, 115);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Pb_Save;
        private System.Windows.Forms.Button Pb_SaveDraft;
    }
}
