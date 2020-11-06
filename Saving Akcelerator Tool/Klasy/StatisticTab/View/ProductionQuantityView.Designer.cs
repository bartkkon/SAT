namespace Saving_Accelerator_Tool.Klasy.StatisticTab.View
{
    partial class ProductionQuantityView
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
            this.gb_StatisticQuantity = new System.Windows.Forms.GroupBox();
            this.dgv_StatisticQuantity = new System.Windows.Forms.DataGridView();
            this.gb_StatisticQuantity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StatisticQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_StatisticQuantity
            // 
            this.gb_StatisticQuantity.Controls.Add(this.dgv_StatisticQuantity);
            this.gb_StatisticQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_StatisticQuantity.Location = new System.Drawing.Point(0, 0);
            this.gb_StatisticQuantity.Name = "gb_StatisticQuantity";
            this.gb_StatisticQuantity.Size = new System.Drawing.Size(490, 160);
            this.gb_StatisticQuantity.TabIndex = 0;
            this.gb_StatisticQuantity.TabStop = false;
            this.gb_StatisticQuantity.Text = "Production Quantity:";
            // 
            // dgv_StatisticQuantity
            // 
            this.dgv_StatisticQuantity.AllowUserToAddRows = false;
            this.dgv_StatisticQuantity.AllowUserToDeleteRows = false;
            this.dgv_StatisticQuantity.AllowUserToResizeColumns = false;
            this.dgv_StatisticQuantity.AllowUserToResizeRows = false;
            this.dgv_StatisticQuantity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_StatisticQuantity.Enabled = false;
            this.dgv_StatisticQuantity.Location = new System.Drawing.Point(10, 15);
            this.dgv_StatisticQuantity.Name = "dgv_StatisticQuantity";
            this.dgv_StatisticQuantity.ReadOnly = true;
            this.dgv_StatisticQuantity.Size = new System.Drawing.Size(470, 135);
            this.dgv_StatisticQuantity.TabIndex = 0;
            // 
            // ProductionQuantityView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_StatisticQuantity);
            this.Name = "ProductionQuantityView";
            this.Size = new System.Drawing.Size(490, 160);
            this.gb_StatisticQuantity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_StatisticQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_StatisticQuantity;
        private System.Windows.Forms.DataGridView dgv_StatisticQuantity;
    }
}
