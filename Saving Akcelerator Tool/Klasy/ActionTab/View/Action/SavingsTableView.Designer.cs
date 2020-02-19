namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class SavingsTableView
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
            this.gb_CalcFinal = new System.Windows.Forms.GroupBox();
            this.pb_SavingCalc = new System.Windows.Forms.Button();
            this.pb_CarryOver = new System.Windows.Forms.Button();
            this.pb_CurrentYear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dg_ECCC = new System.Windows.Forms.DataGridView();
            this.dg_Quantity = new System.Windows.Forms.DataGridView();
            this.dg_Saving = new System.Windows.Forms.DataGridView();
            this.gb_CalcFinal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_ECCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Saving)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_CalcFinal
            // 
            this.gb_CalcFinal.Controls.Add(this.pb_SavingCalc);
            this.gb_CalcFinal.Controls.Add(this.pb_CarryOver);
            this.gb_CalcFinal.Controls.Add(this.pb_CurrentYear);
            this.gb_CalcFinal.Controls.Add(this.label3);
            this.gb_CalcFinal.Controls.Add(this.label2);
            this.gb_CalcFinal.Controls.Add(this.label1);
            this.gb_CalcFinal.Controls.Add(this.dg_ECCC);
            this.gb_CalcFinal.Controls.Add(this.dg_Quantity);
            this.gb_CalcFinal.Controls.Add(this.dg_Saving);
            this.gb_CalcFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_CalcFinal.Location = new System.Drawing.Point(0, 0);
            this.gb_CalcFinal.Name = "gb_CalcFinal";
            this.gb_CalcFinal.Size = new System.Drawing.Size(955, 500);
            this.gb_CalcFinal.TabIndex = 0;
            this.gb_CalcFinal.TabStop = false;
            // 
            // pb_SavingCalc
            // 
            this.pb_SavingCalc.Location = new System.Drawing.Point(874, 7);
            this.pb_SavingCalc.Name = "pb_SavingCalc";
            this.pb_SavingCalc.Size = new System.Drawing.Size(75, 23);
            this.pb_SavingCalc.TabIndex = 8;
            this.pb_SavingCalc.Text = "Calc";
            this.pb_SavingCalc.UseVisualStyleBackColor = true;
            this.pb_SavingCalc.Click += new System.EventHandler(this.pb_SavingCalc_Click);
            // 
            // pb_CarryOver
            // 
            this.pb_CarryOver.Location = new System.Drawing.Point(88, 7);
            this.pb_CarryOver.Name = "pb_CarryOver";
            this.pb_CarryOver.Size = new System.Drawing.Size(75, 23);
            this.pb_CarryOver.TabIndex = 7;
            this.pb_CarryOver.Text = "Carry Over";
            this.pb_CarryOver.UseVisualStyleBackColor = true;
            this.pb_CarryOver.Click += new System.EventHandler(this.Pb_CarryOver_Click);
            // 
            // pb_CurrentYear
            // 
            this.pb_CurrentYear.BackColor = System.Drawing.SystemColors.Control;
            this.pb_CurrentYear.Location = new System.Drawing.Point(7, 7);
            this.pb_CurrentYear.Name = "pb_CurrentYear";
            this.pb_CurrentYear.Size = new System.Drawing.Size(75, 23);
            this.pb_CurrentYear.TabIndex = 6;
            this.pb_CurrentYear.Text = "Start Year";
            this.pb_CurrentYear.UseVisualStyleBackColor = false;
            this.pb_CurrentYear.Click += new System.EventHandler(this.Pb_CurrentYear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(446, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Saving";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(439, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Quantity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(449, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "ECCC";
            // 
            // dg_ECCC
            // 
            this.dg_ECCC.AllowUserToAddRows = false;
            this.dg_ECCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_ECCC.Enabled = false;
            this.dg_ECCC.Location = new System.Drawing.Point(5, 355);
            this.dg_ECCC.Name = "dg_ECCC";
            this.dg_ECCC.ReadOnly = true;
            this.dg_ECCC.Size = new System.Drawing.Size(945, 133);
            this.dg_ECCC.TabIndex = 2;
            // 
            // dg_Quantity
            // 
            this.dg_Quantity.AllowUserToAddRows = false;
            this.dg_Quantity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Quantity.Enabled = false;
            this.dg_Quantity.Location = new System.Drawing.Point(5, 195);
            this.dg_Quantity.Name = "dg_Quantity";
            this.dg_Quantity.ReadOnly = true;
            this.dg_Quantity.Size = new System.Drawing.Size(945, 133);
            this.dg_Quantity.TabIndex = 1;
            // 
            // dg_Saving
            // 
            this.dg_Saving.AllowUserToAddRows = false;
            this.dg_Saving.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Saving.Enabled = false;
            this.dg_Saving.Location = new System.Drawing.Point(5, 35);
            this.dg_Saving.Name = "dg_Saving";
            this.dg_Saving.ReadOnly = true;
            this.dg_Saving.Size = new System.Drawing.Size(945, 133);
            this.dg_Saving.TabIndex = 0;
            // 
            // SavingsTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_CalcFinal);
            this.Name = "SavingsTableView";
            this.Size = new System.Drawing.Size(955, 500);
            this.gb_CalcFinal.ResumeLayout(false);
            this.gb_CalcFinal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_ECCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Saving)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_CalcFinal;
        private System.Windows.Forms.DataGridView dg_Saving;
        private System.Windows.Forms.DataGridView dg_ECCC;
        private System.Windows.Forms.DataGridView dg_Quantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pb_CarryOver;
        private System.Windows.Forms.Button pb_CurrentYear;
        private System.Windows.Forms.Button pb_SavingCalc;
    }
}
