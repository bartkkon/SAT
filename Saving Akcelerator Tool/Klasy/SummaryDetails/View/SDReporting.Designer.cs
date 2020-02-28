namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.View
{
    partial class SDReporting
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
            this.pb_Approval_Mechanic = new System.Windows.Forms.Button();
            this.pb_Approval_NVR = new System.Windows.Forms.Button();
            this.pb_Approval_PC = new System.Windows.Forms.Button();
            this.pb_GenerateRaport = new System.Windows.Forms.Button();
            this.pb_Approval_Electronic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pb_Approval_Mechanic
            // 
            this.pb_Approval_Mechanic.Enabled = false;
            this.pb_Approval_Mechanic.Location = new System.Drawing.Point(20, 49);
            this.pb_Approval_Mechanic.Name = "pb_Approval_Mechanic";
            this.pb_Approval_Mechanic.Size = new System.Drawing.Size(160, 40);
            this.pb_Approval_Mechanic.TabIndex = 0;
            this.pb_Approval_Mechanic.Text = "Mechanic Approve";
            this.pb_Approval_Mechanic.UseVisualStyleBackColor = true;
            this.pb_Approval_Mechanic.Click += new System.EventHandler(this.Pb_SummDet_Approve_Click);
            // 
            // pb_Approval_NVR
            // 
            this.pb_Approval_NVR.Enabled = false;
            this.pb_Approval_NVR.Location = new System.Drawing.Point(20, 95);
            this.pb_Approval_NVR.Name = "pb_Approval_NVR";
            this.pb_Approval_NVR.Size = new System.Drawing.Size(160, 40);
            this.pb_Approval_NVR.TabIndex = 1;
            this.pb_Approval_NVR.Text = "NVR Approve";
            this.pb_Approval_NVR.UseVisualStyleBackColor = true;
            this.pb_Approval_NVR.Click += new System.EventHandler(this.Pb_SummDet_Approve_Click);
            // 
            // pb_Approval_PC
            // 
            this.pb_Approval_PC.Enabled = false;
            this.pb_Approval_PC.Location = new System.Drawing.Point(20, 141);
            this.pb_Approval_PC.Name = "pb_Approval_PC";
            this.pb_Approval_PC.Size = new System.Drawing.Size(160, 40);
            this.pb_Approval_PC.TabIndex = 2;
            this.pb_Approval_PC.Text = "Product Care Approve";
            this.pb_Approval_PC.UseVisualStyleBackColor = true;
            this.pb_Approval_PC.Click += new System.EventHandler(this.Pb_SummDet_Approve_Click);
            // 
            // pb_GenerateRaport
            // 
            this.pb_GenerateRaport.Enabled = false;
            this.pb_GenerateRaport.Location = new System.Drawing.Point(20, 233);
            this.pb_GenerateRaport.Name = "pb_GenerateRaport";
            this.pb_GenerateRaport.Size = new System.Drawing.Size(160, 40);
            this.pb_GenerateRaport.TabIndex = 3;
            this.pb_GenerateRaport.Text = "Generate Report";
            this.pb_GenerateRaport.UseVisualStyleBackColor = true;
            this.pb_GenerateRaport.Visible = false;
            // 
            // pb_Approval_Electronic
            // 
            this.pb_Approval_Electronic.Enabled = false;
            this.pb_Approval_Electronic.Location = new System.Drawing.Point(20, 3);
            this.pb_Approval_Electronic.Name = "pb_Approval_Electronic";
            this.pb_Approval_Electronic.Size = new System.Drawing.Size(160, 40);
            this.pb_Approval_Electronic.TabIndex = 4;
            this.pb_Approval_Electronic.Text = "Electronic Approve";
            this.pb_Approval_Electronic.UseVisualStyleBackColor = true;
            this.pb_Approval_Electronic.Click += new System.EventHandler(this.Pb_SummDet_Approve_Click);
            // 
            // SDReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pb_Approval_Electronic);
            this.Controls.Add(this.pb_GenerateRaport);
            this.Controls.Add(this.pb_Approval_PC);
            this.Controls.Add(this.pb_Approval_NVR);
            this.Controls.Add(this.pb_Approval_Mechanic);
            this.Name = "SDReporting";
            this.Size = new System.Drawing.Size(200, 279);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pb_Approval_Mechanic;
        private System.Windows.Forms.Button pb_Approval_NVR;
        private System.Windows.Forms.Button pb_Approval_PC;
        private System.Windows.Forms.Button pb_GenerateRaport;
        private System.Windows.Forms.Button pb_Approval_Electronic;
    }
}
