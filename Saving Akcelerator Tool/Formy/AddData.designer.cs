using System.Windows.Forms;
namespace Saving_Accelerator_Tool
{
    partial class AddData : Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lab_AddData_Text = new System.Windows.Forms.Label();
            this.tb_AddData_Data = new System.Windows.Forms.TextBox();
            this.pb_AddData_Close = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PB_CopyTemplate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lab_AddData_Text
            // 
            this.lab_AddData_Text.AutoSize = true;
            this.lab_AddData_Text.Location = new System.Drawing.Point(23, 16);
            this.lab_AddData_Text.Name = "lab_AddData_Text";
            this.lab_AddData_Text.Size = new System.Drawing.Size(35, 13);
            this.lab_AddData_Text.TabIndex = 0;
            this.lab_AddData_Text.Text = "label1";
            // 
            // tb_AddData_Data
            // 
            this.tb_AddData_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_AddData_Data.Location = new System.Drawing.Point(0, 0);
            this.tb_AddData_Data.MaxLength = 10000000;
            this.tb_AddData_Data.Multiline = true;
            this.tb_AddData_Data.Name = "tb_AddData_Data";
            this.tb_AddData_Data.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tb_AddData_Data.Size = new System.Drawing.Size(675, 563);
            this.tb_AddData_Data.TabIndex = 1;
            // 
            // pb_AddData_Close
            // 
            this.pb_AddData_Close.Location = new System.Drawing.Point(13, 12);
            this.pb_AddData_Close.Name = "pb_AddData_Close";
            this.pb_AddData_Close.Size = new System.Drawing.Size(126, 33);
            this.pb_AddData_Close.TabIndex = 2;
            this.pb_AddData_Close.Text = "OK";
            this.pb_AddData_Close.UseVisualStyleBackColor = true;
            this.pb_AddData_Close.Click += new System.EventHandler(this.pb_AddData_Close_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PB_CopyTemplate);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.lab_AddData_Text);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 62);
            this.panel1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pb_AddData_Close);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(524, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(151, 62);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tb_AddData_Data);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(675, 563);
            this.panel2.TabIndex = 4;
            // 
            // PB_CopyTemplate
            // 
            this.PB_CopyTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PB_CopyTemplate.Location = new System.Drawing.Point(410, 7);
            this.PB_CopyTemplate.Name = "PB_CopyTemplate";
            this.PB_CopyTemplate.Size = new System.Drawing.Size(108, 22);
            this.PB_CopyTemplate.TabIndex = 4;
            this.PB_CopyTemplate.Text = "Download Template";
            this.PB_CopyTemplate.UseVisualStyleBackColor = true;
            this.PB_CopyTemplate.Visible = false;
            this.PB_CopyTemplate.Click += new System.EventHandler(this.PB_CopyTemplate_Click);
            // 
            // AddData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 625);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AddData";
            this.Text = "AddData";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lab_AddData_Text;
        private System.Windows.Forms.TextBox tb_AddData_Data;
        private System.Windows.Forms.Button pb_AddData_Close;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private Button PB_CopyTemplate;
    }
}