namespace Saving_Accelerator_Tool.Klasy.AdminTab.View.AdminTabTable
{
    partial class AdminTableView
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
            this.buttonLoadView = new Saving_Accelerator_Tool.Klasy.AdminTab.View.AdminTabTable.View.ButtonLoadView();
            this.optionsView = new Saving_Accelerator_Tool.Klasy.AdminTab.View.AdminTabTable.View.OptionsView();
            this.DGV_AdminTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AdminTable)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadView
            // 
            this.buttonLoadView.Location = new System.Drawing.Point(0, 0);
            this.buttonLoadView.Name = "buttonLoadView";
            this.buttonLoadView.Size = new System.Drawing.Size(1912, 100);
            this.buttonLoadView.TabIndex = 0;
            // 
            // optionsView
            // 
            this.optionsView.Location = new System.Drawing.Point(0, 96);
            this.optionsView.Name = "optionsView";
            this.optionsView.Size = new System.Drawing.Size(1912, 100);
            this.optionsView.TabIndex = 1;
            // 
            // DGV_AdminTable
            // 
            this.DGV_AdminTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_AdminTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGV_AdminTable.Location = new System.Drawing.Point(0, 202);
            this.DGV_AdminTable.Name = "DGV_AdminTable";
            this.DGV_AdminTable.Size = new System.Drawing.Size(1912, 772);
            this.DGV_AdminTable.TabIndex = 2;
            // 
            // AdminTableView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DGV_AdminTable);
            this.Controls.Add(this.optionsView);
            this.Controls.Add(this.buttonLoadView);
            this.Name = "AdminTableView";
            this.Size = new System.Drawing.Size(1912, 974);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_AdminTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public View.ButtonLoadView buttonLoadView;
        public View.OptionsView optionsView;
        private System.Windows.Forms.DataGridView DGV_AdminTable;
    }
}
