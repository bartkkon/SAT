namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    partial class DataBaseView
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
            this.pb_CloneBase = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.pb_CloneBase);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 300);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Base:";
            // 
            // pb_CloneBase
            // 
            this.pb_CloneBase.Location = new System.Drawing.Point(6, 26);
            this.pb_CloneBase.Name = "pb_CloneBase";
            this.pb_CloneBase.Size = new System.Drawing.Size(138, 29);
            this.pb_CloneBase.TabIndex = 0;
            this.pb_CloneBase.Text = "Clone All Data Base";
            this.pb_CloneBase.UseVisualStyleBackColor = true;
            this.pb_CloneBase.Click += new System.EventHandler(this.Pb_CloneBase_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "IDB Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.PB_IDB_Update_DataBase_Click);
            // 
            // DataBaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "DataBaseView";
            this.Size = new System.Drawing.Size(150, 300);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button pb_CloneBase;
    }
}
