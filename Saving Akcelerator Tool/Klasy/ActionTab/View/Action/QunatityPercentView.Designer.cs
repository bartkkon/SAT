namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class QunatityPercentView
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
            this.gb_percent = new System.Windows.Forms.GroupBox();
            this.num_QuantityPercent = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_percent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_QuantityPercent)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_percent
            // 
            this.gb_percent.Controls.Add(this.label1);
            this.gb_percent.Controls.Add(this.num_QuantityPercent);
            this.gb_percent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_percent.Location = new System.Drawing.Point(0, 0);
            this.gb_percent.Name = "gb_percent";
            this.gb_percent.Size = new System.Drawing.Size(155, 45);
            this.gb_percent.TabIndex = 0;
            this.gb_percent.TabStop = false;
            this.gb_percent.Text = "Quantity Percent:";
            // 
            // num_QuantityPercent
            // 
            this.num_QuantityPercent.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.num_QuantityPercent.Location = new System.Drawing.Point(44, 19);
            this.num_QuantityPercent.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_QuantityPercent.Name = "num_QuantityPercent";
            this.num_QuantityPercent.Size = new System.Drawing.Size(55, 20);
            this.num_QuantityPercent.TabIndex = 0;
            this.num_QuantityPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_QuantityPercent.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "%";
            // 
            // QunatityPercentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_percent);
            this.Name = "QunatityPercentView";
            this.Size = new System.Drawing.Size(155, 45);
            this.gb_percent.ResumeLayout(false);
            this.gb_percent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_QuantityPercent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_percent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_QuantityPercent;
    }
}
