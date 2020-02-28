namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.View
{
    partial class SDTableAllView
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
            this.gb_ShownActionDetails = new System.Windows.Forms.GroupBox();
            this.dgv_CarryOverAction = new System.Windows.Forms.DataGridView();
            this.dgv_ActualAction = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_SDOptionECCC = new System.Windows.Forms.CheckBox();
            this.cb_SDOptionQuantity = new System.Windows.Forms.CheckBox();
            this.cb_SDOptionSavings = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gb_ShownActionDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CarryOverAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ActualAction)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_ShownActionDetails
            // 
            this.gb_ShownActionDetails.Controls.Add(this.dgv_CarryOverAction);
            this.gb_ShownActionDetails.Controls.Add(this.dgv_ActualAction);
            this.gb_ShownActionDetails.Controls.Add(this.label3);
            this.gb_ShownActionDetails.Controls.Add(this.label2);
            this.gb_ShownActionDetails.Controls.Add(this.cb_SDOptionECCC);
            this.gb_ShownActionDetails.Controls.Add(this.cb_SDOptionQuantity);
            this.gb_ShownActionDetails.Controls.Add(this.cb_SDOptionSavings);
            this.gb_ShownActionDetails.Controls.Add(this.label1);
            this.gb_ShownActionDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_ShownActionDetails.Location = new System.Drawing.Point(0, 0);
            this.gb_ShownActionDetails.Name = "gb_ShownActionDetails";
            this.gb_ShownActionDetails.Size = new System.Drawing.Size(1580, 970);
            this.gb_ShownActionDetails.TabIndex = 0;
            this.gb_ShownActionDetails.TabStop = false;
            // 
            // dgv_CarryOverAction
            // 
            this.dgv_CarryOverAction.AllowUserToAddRows = false;
            this.dgv_CarryOverAction.AllowUserToDeleteRows = false;
            this.dgv_CarryOverAction.AllowUserToResizeColumns = false;
            this.dgv_CarryOverAction.AllowUserToResizeRows = false;
            this.dgv_CarryOverAction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CarryOverAction.Location = new System.Drawing.Point(5, 520);
            this.dgv_CarryOverAction.Name = "dgv_CarryOverAction";
            this.dgv_CarryOverAction.ReadOnly = true;
            this.dgv_CarryOverAction.RowHeadersVisible = false;
            this.dgv_CarryOverAction.Size = new System.Drawing.Size(1480, 400);
            this.dgv_CarryOverAction.TabIndex = 7;
            // 
            // dgv_ActualAction
            // 
            this.dgv_ActualAction.AllowUserToAddRows = false;
            this.dgv_ActualAction.AllowUserToDeleteRows = false;
            this.dgv_ActualAction.AllowUserToResizeColumns = false;
            this.dgv_ActualAction.AllowUserToResizeRows = false;
            this.dgv_ActualAction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ActualAction.Location = new System.Drawing.Point(5, 60);
            this.dgv_ActualAction.Name = "dgv_ActualAction";
            this.dgv_ActualAction.ReadOnly = true;
            this.dgv_ActualAction.RowHeadersVisible = false;
            this.dgv_ActualAction.Size = new System.Drawing.Size(1480, 400);
            this.dgv_ActualAction.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(10, 480);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Carry Over Action:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Actual Action:";
            // 
            // cb_SDOptionECCC
            // 
            this.cb_SDOptionECCC.AutoSize = true;
            this.cb_SDOptionECCC.Location = new System.Drawing.Point(1500, 75);
            this.cb_SDOptionECCC.Name = "cb_SDOptionECCC";
            this.cb_SDOptionECCC.Size = new System.Drawing.Size(54, 17);
            this.cb_SDOptionECCC.TabIndex = 3;
            this.cb_SDOptionECCC.Text = "ECCC";
            this.cb_SDOptionECCC.UseVisualStyleBackColor = true;
            this.cb_SDOptionECCC.CheckedChanged += new System.EventHandler(this.SDOptionForTable_CheckChanged);
            // 
            // cb_SDOptionQuantity
            // 
            this.cb_SDOptionQuantity.AutoSize = true;
            this.cb_SDOptionQuantity.Location = new System.Drawing.Point(1500, 55);
            this.cb_SDOptionQuantity.Name = "cb_SDOptionQuantity";
            this.cb_SDOptionQuantity.Size = new System.Drawing.Size(65, 17);
            this.cb_SDOptionQuantity.TabIndex = 2;
            this.cb_SDOptionQuantity.Text = "Quantity";
            this.cb_SDOptionQuantity.UseVisualStyleBackColor = true;
            this.cb_SDOptionQuantity.CheckedChanged += new System.EventHandler(this.SDOptionForTable_CheckChanged);
            // 
            // cb_SDOptionSavings
            // 
            this.cb_SDOptionSavings.AutoSize = true;
            this.cb_SDOptionSavings.Checked = true;
            this.cb_SDOptionSavings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_SDOptionSavings.Location = new System.Drawing.Point(1500, 35);
            this.cb_SDOptionSavings.Name = "cb_SDOptionSavings";
            this.cb_SDOptionSavings.Size = new System.Drawing.Size(64, 17);
            this.cb_SDOptionSavings.TabIndex = 1;
            this.cb_SDOptionSavings.Text = "Savings";
            this.cb_SDOptionSavings.UseVisualStyleBackColor = true;
            this.cb_SDOptionSavings.CheckedChanged += new System.EventHandler(this.SDOptionForTable_CheckChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(1500, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Options:";
            // 
            // SDTableAllView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_ShownActionDetails);
            this.Name = "SDTableAllView";
            this.Size = new System.Drawing.Size(1580, 970);
            this.gb_ShownActionDetails.ResumeLayout(false);
            this.gb_ShownActionDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CarryOverAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ActualAction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_ShownActionDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_CarryOverAction;
        private System.Windows.Forms.DataGridView dgv_ActualAction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_SDOptionECCC;
        private System.Windows.Forms.CheckBox cb_SDOptionQuantity;
        private System.Windows.Forms.CheckBox cb_SDOptionSavings;
    }
}
