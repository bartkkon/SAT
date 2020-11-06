namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class PNCListView
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
            this.gb_PNC = new System.Windows.Forms.GroupBox();
            this.dg_PNC = new System.Windows.Forms.DataGridView();
            this.gb_PNC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_PNC)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_PNC
            // 
            this.gb_PNC.Controls.Add(this.dg_PNC);
            this.gb_PNC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_PNC.Location = new System.Drawing.Point(0, 0);
            this.gb_PNC.Name = "gb_PNC";
            this.gb_PNC.Size = new System.Drawing.Size(525, 830);
            this.gb_PNC.TabIndex = 0;
            this.gb_PNC.TabStop = false;
            this.gb_PNC.Text = "PNC:";
            // 
            // dg_PNC
            // 
            this.dg_PNC.AllowUserToAddRows = false;
            this.dg_PNC.AllowUserToDeleteRows = false;
            this.dg_PNC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_PNC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_PNC.Location = new System.Drawing.Point(3, 16);
            this.dg_PNC.Name = "dg_PNC";
            this.dg_PNC.ReadOnly = true;
            this.dg_PNC.RowHeadersWidth = 4;
            this.dg_PNC.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dg_PNC.Size = new System.Drawing.Size(519, 811);
            this.dg_PNC.TabIndex = 0;
            // 
            // PNCListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_PNC);
            this.Name = "PNCListView";
            this.Size = new System.Drawing.Size(525, 830);
            this.gb_PNC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_PNC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_PNC;
        private System.Windows.Forms.DataGridView dg_PNC;
    }
}
