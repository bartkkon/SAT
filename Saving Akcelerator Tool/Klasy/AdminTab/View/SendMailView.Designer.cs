
using System;

namespace Saving_Accelerator_Tool.Klasy.AdmnTab.View
{
    partial class SendMailView 
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
            this.gb_Admin_SendMail = new System.Windows.Forms.GroupBox();
            this.num_SendMailAdmin_year = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.pb_SendMailAdmin_NewData_Revsion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comb_SendMailAdmin_Revision = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.num_SentMailAdmin_Month = new System.Windows.Forms.NumericUpDown();
            this.cb_SendMailAdmin_PC = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_SendMailAdmin_NVR = new System.Windows.Forms.CheckBox();
            this.cb_SendMailAdmin_Mechanic = new System.Windows.Forms.CheckBox();
            this.cb_SendMailAdmin_Electronic = new System.Windows.Forms.CheckBox();
            this.cb_SendMailAdmin_ToAdmin = new System.Windows.Forms.CheckBox();
            this.pb_SendMail_NewCalc = new System.Windows.Forms.Button();
            this.Pb_Admin_SendMail_SpecialMassage = new System.Windows.Forms.Button();
            this.gb_Admin_SendMail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_SendMailAdmin_year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_SentMailAdmin_Month)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Admin_SendMail
            // 
            this.gb_Admin_SendMail.Controls.Add(this.Pb_Admin_SendMail_SpecialMassage);
            this.gb_Admin_SendMail.Controls.Add(this.num_SendMailAdmin_year);
            this.gb_Admin_SendMail.Controls.Add(this.label5);
            this.gb_Admin_SendMail.Controls.Add(this.pb_SendMailAdmin_NewData_Revsion);
            this.gb_Admin_SendMail.Controls.Add(this.label3);
            this.gb_Admin_SendMail.Controls.Add(this.comb_SendMailAdmin_Revision);
            this.gb_Admin_SendMail.Controls.Add(this.label2);
            this.gb_Admin_SendMail.Controls.Add(this.num_SentMailAdmin_Month);
            this.gb_Admin_SendMail.Controls.Add(this.cb_SendMailAdmin_PC);
            this.gb_Admin_SendMail.Controls.Add(this.label1);
            this.gb_Admin_SendMail.Controls.Add(this.cb_SendMailAdmin_NVR);
            this.gb_Admin_SendMail.Controls.Add(this.cb_SendMailAdmin_Mechanic);
            this.gb_Admin_SendMail.Controls.Add(this.cb_SendMailAdmin_Electronic);
            this.gb_Admin_SendMail.Controls.Add(this.cb_SendMailAdmin_ToAdmin);
            this.gb_Admin_SendMail.Controls.Add(this.pb_SendMail_NewCalc);
            this.gb_Admin_SendMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Admin_SendMail.Location = new System.Drawing.Point(0, 0);
            this.gb_Admin_SendMail.Name = "gb_Admin_SendMail";
            this.gb_Admin_SendMail.Size = new System.Drawing.Size(330, 339);
            this.gb_Admin_SendMail.TabIndex = 0;
            this.gb_Admin_SendMail.TabStop = false;
            this.gb_Admin_SendMail.Text = "SendMail";
            // 
            // num_SendMailAdmin_year
            // 
            this.num_SendMailAdmin_year.Location = new System.Drawing.Point(75, 111);
            this.num_SendMailAdmin_year.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.num_SendMailAdmin_year.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_SendMailAdmin_year.Name = "num_SendMailAdmin_year";
            this.num_SendMailAdmin_year.Size = new System.Drawing.Size(49, 20);
            this.num_SendMailAdmin_year.TabIndex = 14;
            this.num_SendMailAdmin_year.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Year:";
            // 
            // pb_SendMailAdmin_NewData_Revsion
            // 
            this.pb_SendMailAdmin_NewData_Revsion.Location = new System.Drawing.Point(16, 137);
            this.pb_SendMailAdmin_NewData_Revsion.Name = "pb_SendMailAdmin_NewData_Revsion";
            this.pb_SendMailAdmin_NewData_Revsion.Size = new System.Drawing.Size(110, 30);
            this.pb_SendMailAdmin_NewData_Revsion.TabIndex = 11;
            this.pb_SendMailAdmin_NewData_Revsion.Text = "New Data Revision";
            this.pb_SendMailAdmin_NewData_Revsion.UseVisualStyleBackColor = true;
            this.pb_SendMailAdmin_NewData_Revsion.Click += new System.EventHandler(this.Pb_SendMailAdmin_NewData_Revsion_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Revision:";
            // 
            // comb_SendMailAdmin_Revision
            // 
            this.comb_SendMailAdmin_Revision.FormattingEnabled = true;
            this.comb_SendMailAdmin_Revision.Items.AddRange(new object[] {
            "BU",
            "EA1",
            "EA2",
            "EA3"});
            this.comb_SendMailAdmin_Revision.Location = new System.Drawing.Point(73, 80);
            this.comb_SendMailAdmin_Revision.Name = "comb_SendMailAdmin_Revision";
            this.comb_SendMailAdmin_Revision.Size = new System.Drawing.Size(52, 21);
            this.comb_SendMailAdmin_Revision.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Month:";
            // 
            // num_SentMailAdmin_Month
            // 
            this.num_SentMailAdmin_Month.Location = new System.Drawing.Point(73, 16);
            this.num_SentMailAdmin_Month.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.num_SentMailAdmin_Month.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_SentMailAdmin_Month.Name = "num_SentMailAdmin_Month";
            this.num_SentMailAdmin_Month.Size = new System.Drawing.Size(53, 20);
            this.num_SentMailAdmin_Month.TabIndex = 7;
            this.num_SentMailAdmin_Month.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cb_SendMailAdmin_PC
            // 
            this.cb_SendMailAdmin_PC.AutoSize = true;
            this.cb_SendMailAdmin_PC.Checked = true;
            this.cb_SendMailAdmin_PC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_SendMailAdmin_PC.Location = new System.Drawing.Point(169, 110);
            this.cb_SendMailAdmin_PC.Name = "cb_SendMailAdmin_PC";
            this.cb_SendMailAdmin_PC.Size = new System.Drawing.Size(85, 17);
            this.cb_SendMailAdmin_PC.TabIndex = 6;
            this.cb_SendMailAdmin_PC.Text = "PC Manager";
            this.cb_SendMailAdmin_PC.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Send To:";
            // 
            // cb_SendMailAdmin_NVR
            // 
            this.cb_SendMailAdmin_NVR.AutoSize = true;
            this.cb_SendMailAdmin_NVR.Checked = true;
            this.cb_SendMailAdmin_NVR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_SendMailAdmin_NVR.Location = new System.Drawing.Point(169, 90);
            this.cb_SendMailAdmin_NVR.Name = "cb_SendMailAdmin_NVR";
            this.cb_SendMailAdmin_NVR.Size = new System.Drawing.Size(94, 17);
            this.cb_SendMailAdmin_NVR.TabIndex = 4;
            this.cb_SendMailAdmin_NVR.Text = "NVR Menager";
            this.cb_SendMailAdmin_NVR.UseVisualStyleBackColor = true;
            // 
            // cb_SendMailAdmin_Mechanic
            // 
            this.cb_SendMailAdmin_Mechanic.AutoSize = true;
            this.cb_SendMailAdmin_Mechanic.Checked = true;
            this.cb_SendMailAdmin_Mechanic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_SendMailAdmin_Mechanic.Location = new System.Drawing.Point(169, 70);
            this.cb_SendMailAdmin_Mechanic.Name = "cb_SendMailAdmin_Mechanic";
            this.cb_SendMailAdmin_Mechanic.Size = new System.Drawing.Size(118, 17);
            this.cb_SendMailAdmin_Mechanic.TabIndex = 3;
            this.cb_SendMailAdmin_Mechanic.Text = "Mechanic Menager";
            this.cb_SendMailAdmin_Mechanic.UseVisualStyleBackColor = true;
            // 
            // cb_SendMailAdmin_Electronic
            // 
            this.cb_SendMailAdmin_Electronic.AutoSize = true;
            this.cb_SendMailAdmin_Electronic.Checked = true;
            this.cb_SendMailAdmin_Electronic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_SendMailAdmin_Electronic.Location = new System.Drawing.Point(169, 50);
            this.cb_SendMailAdmin_Electronic.Name = "cb_SendMailAdmin_Electronic";
            this.cb_SendMailAdmin_Electronic.Size = new System.Drawing.Size(118, 17);
            this.cb_SendMailAdmin_Electronic.TabIndex = 2;
            this.cb_SendMailAdmin_Electronic.Text = "Electronic Menager";
            this.cb_SendMailAdmin_Electronic.UseVisualStyleBackColor = true;
            // 
            // cb_SendMailAdmin_ToAdmin
            // 
            this.cb_SendMailAdmin_ToAdmin.AutoSize = true;
            this.cb_SendMailAdmin_ToAdmin.Checked = true;
            this.cb_SendMailAdmin_ToAdmin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_SendMailAdmin_ToAdmin.Location = new System.Drawing.Point(169, 30);
            this.cb_SendMailAdmin_ToAdmin.Name = "cb_SendMailAdmin_ToAdmin";
            this.cb_SendMailAdmin_ToAdmin.Size = new System.Drawing.Size(55, 17);
            this.cb_SendMailAdmin_ToAdmin.TabIndex = 1;
            this.cb_SendMailAdmin_ToAdmin.Text = "Admin";
            this.cb_SendMailAdmin_ToAdmin.UseVisualStyleBackColor = true;
            // 
            // pb_SendMail_NewCalc
            // 
            this.pb_SendMail_NewCalc.Location = new System.Drawing.Point(16, 42);
            this.pb_SendMail_NewCalc.Name = "pb_SendMail_NewCalc";
            this.pb_SendMail_NewCalc.Size = new System.Drawing.Size(110, 30);
            this.pb_SendMail_NewCalc.TabIndex = 0;
            this.pb_SendMail_NewCalc.Text = "New Data Month";
            this.pb_SendMail_NewCalc.UseVisualStyleBackColor = true;
            this.pb_SendMail_NewCalc.Click += new System.EventHandler(this.Pb_SendMail_NewCalc_Click);
            // 
            // Pb_Admin_SendMail_SpecialMassage
            // 
            this.Pb_Admin_SendMail_SpecialMassage.Location = new System.Drawing.Point(16, 292);
            this.Pb_Admin_SendMail_SpecialMassage.Name = "Pb_Admin_SendMail_SpecialMassage";
            this.Pb_Admin_SendMail_SpecialMassage.Size = new System.Drawing.Size(110, 30);
            this.Pb_Admin_SendMail_SpecialMassage.TabIndex = 15;
            this.Pb_Admin_SendMail_SpecialMassage.Text = "Special Massage";
            this.Pb_Admin_SendMail_SpecialMassage.UseVisualStyleBackColor = true;
            this.Pb_Admin_SendMail_SpecialMassage.Click += new System.EventHandler(this.Pb_Admin_SendMail_SpecialMassage_Click);
            // 
            // SendMailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_Admin_SendMail);
            this.Name = "SendMailView";
            this.Size = new System.Drawing.Size(330, 339);
            this.gb_Admin_SendMail.ResumeLayout(false);
            this.gb_Admin_SendMail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_SendMailAdmin_year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_SentMailAdmin_Month)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Admin_SendMail;
        private System.Windows.Forms.Button pb_SendMail_NewCalc;
        private System.Windows.Forms.CheckBox cb_SendMailAdmin_PC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_SendMailAdmin_NVR;
        private System.Windows.Forms.CheckBox cb_SendMailAdmin_Mechanic;
        private System.Windows.Forms.CheckBox cb_SendMailAdmin_Electronic;
        private System.Windows.Forms.CheckBox cb_SendMailAdmin_ToAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown num_SentMailAdmin_Month;
        private System.Windows.Forms.NumericUpDown num_SendMailAdmin_year;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button pb_SendMailAdmin_NewData_Revsion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comb_SendMailAdmin_Revision;
        private System.Windows.Forms.Button Pb_Admin_SendMail_SpecialMassage;
    }
}
