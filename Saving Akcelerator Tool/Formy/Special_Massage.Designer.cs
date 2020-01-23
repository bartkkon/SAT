namespace Saving_Accelerator_Tool.Formy
{
    partial class Special_Massage
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
            this.Pb_AdminSpecialMessage_Send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_AdminSpecialMassage_Subject = new System.Windows.Forms.TextBox();
            this.tb_AdminSpecialMassage_Body = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Pb_AdminSpecialMessage_Send
            // 
            this.Pb_AdminSpecialMessage_Send.Location = new System.Drawing.Point(448, 7);
            this.Pb_AdminSpecialMessage_Send.Name = "Pb_AdminSpecialMessage_Send";
            this.Pb_AdminSpecialMessage_Send.Size = new System.Drawing.Size(105, 31);
            this.Pb_AdminSpecialMessage_Send.TabIndex = 0;
            this.Pb_AdminSpecialMessage_Send.Text = "Send";
            this.Pb_AdminSpecialMessage_Send.UseVisualStyleBackColor = true;
            this.Pb_AdminSpecialMessage_Send.Click += new System.EventHandler(this.Pb_AdminSpecialMessage_Send_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Subject:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Body:";
            // 
            // tb_AdminSpecialMassage_Subject
            // 
            this.tb_AdminSpecialMassage_Subject.Location = new System.Drawing.Point(15, 45);
            this.tb_AdminSpecialMassage_Subject.Name = "tb_AdminSpecialMassage_Subject";
            this.tb_AdminSpecialMassage_Subject.Size = new System.Drawing.Size(535, 20);
            this.tb_AdminSpecialMassage_Subject.TabIndex = 3;
            // 
            // tb_AdminSpecialMassage_Body
            // 
            this.tb_AdminSpecialMassage_Body.Location = new System.Drawing.Point(15, 100);
            this.tb_AdminSpecialMassage_Body.Multiline = true;
            this.tb_AdminSpecialMassage_Body.Name = "tb_AdminSpecialMassage_Body";
            this.tb_AdminSpecialMassage_Body.Size = new System.Drawing.Size(535, 190);
            this.tb_AdminSpecialMassage_Body.TabIndex = 4;
            // 
            // Special_Massage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 301);
            this.Controls.Add(this.tb_AdminSpecialMassage_Body);
            this.Controls.Add(this.tb_AdminSpecialMassage_Subject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Pb_AdminSpecialMessage_Send);
            this.Name = "Special_Massage";
            this.Text = "Special_Massage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Pb_AdminSpecialMessage_Send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_AdminSpecialMassage_Subject;
        private System.Windows.Forms.TextBox tb_AdminSpecialMassage_Body;
    }
}