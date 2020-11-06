namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class NameView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Tb_Name = new System.Windows.Forms.TextBox();
            this.Tb_Description = new System.Windows.Forms.TextBox();
            this.Lab_MaxLength = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Action Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description:";
            // 
            // Tb_Name
            // 
            this.Tb_Name.Location = new System.Drawing.Point(15, 16);
            this.Tb_Name.Name = "Tb_Name";
            this.Tb_Name.Size = new System.Drawing.Size(380, 20);
            this.Tb_Name.TabIndex = 2;
            this.Tb_Name.TextChanged += new System.EventHandler(this.Tb_Name_TextChanged);
            this.Tb_Name.Leave += new System.EventHandler(this.Tb_Name_Leave);
            // 
            // Tb_Description
            // 
            this.Tb_Description.Location = new System.Drawing.Point(15, 55);
            this.Tb_Description.Multiline = true;
            this.Tb_Description.Name = "Tb_Description";
            this.Tb_Description.Size = new System.Drawing.Size(380, 71);
            this.Tb_Description.TabIndex = 3;
            this.Tb_Description.TextChanged += new System.EventHandler(this.Tb_Description_TextChanged);
            // 
            // Lab_MaxLength
            // 
            this.Lab_MaxLength.AutoSize = true;
            this.Lab_MaxLength.Location = new System.Drawing.Point(353, 129);
            this.Lab_MaxLength.Name = "Lab_MaxLength";
            this.Lab_MaxLength.Size = new System.Drawing.Size(42, 13);
            this.Lab_MaxLength.TabIndex = 4;
            this.Lab_MaxLength.Text = "0/1000";
            this.Lab_MaxLength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // NameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Lab_MaxLength);
            this.Controls.Add(this.Tb_Description);
            this.Controls.Add(this.Tb_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NameView";
            this.Size = new System.Drawing.Size(410, 145);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox Tb_Name;
        public System.Windows.Forms.TextBox Tb_Description;
        private System.Windows.Forms.Label Lab_MaxLength;
    }
}
