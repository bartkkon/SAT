namespace Saving_Accelerator_Tool.Klasy.ActionTab.NewWindow.SpecialCalc
{
    partial class SpecialCalcAction
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gb_Configure = new System.Windows.Forms.GroupBox();
            this.Dgv_Action = new System.Windows.Forms.DataGridView();
            this.cb_SingleAction = new System.Windows.Forms.CheckBox();
            this.tb_Comments = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Pb_SaveChange = new System.Windows.Forms.Button();
            this.Cb_Savings = new System.Windows.Forms.CheckBox();
            this.Cb_Quantity = new System.Windows.Forms.CheckBox();
            this.CB_Eccc = new System.Windows.Forms.CheckBox();
            this.Pb_Calc = new System.Windows.Forms.Button();
            this.gb_Sum = new System.Windows.Forms.GroupBox();
            this.DGV_Suma = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.gb_Configure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Action)).BeginInit();
            this.gb_Sum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Suma)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Dgv_Action);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1139, 340);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // gb_Configure
            // 
            this.gb_Configure.Controls.Add(this.Pb_Calc);
            this.gb_Configure.Controls.Add(this.CB_Eccc);
            this.gb_Configure.Controls.Add(this.Cb_Quantity);
            this.gb_Configure.Controls.Add(this.Cb_Savings);
            this.gb_Configure.Controls.Add(this.Pb_SaveChange);
            this.gb_Configure.Controls.Add(this.label1);
            this.gb_Configure.Controls.Add(this.tb_Comments);
            this.gb_Configure.Controls.Add(this.cb_SingleAction);
            this.gb_Configure.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gb_Configure.Location = new System.Drawing.Point(0, 500);
            this.gb_Configure.Name = "gb_Configure";
            this.gb_Configure.Size = new System.Drawing.Size(1139, 182);
            this.gb_Configure.TabIndex = 1;
            this.gb_Configure.TabStop = false;
            this.gb_Configure.Text = "Configure";
            // 
            // Dgv_Action
            // 
            this.Dgv_Action.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Action.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_Action.Location = new System.Drawing.Point(3, 16);
            this.Dgv_Action.Name = "Dgv_Action";
            this.Dgv_Action.Size = new System.Drawing.Size(1133, 321);
            this.Dgv_Action.TabIndex = 0;
            this.Dgv_Action.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Action_CellValueChanged);
            // 
            // cb_SingleAction
            // 
            this.cb_SingleAction.AutoSize = true;
            this.cb_SingleAction.Location = new System.Drawing.Point(12, 33);
            this.cb_SingleAction.Name = "cb_SingleAction";
            this.cb_SingleAction.Size = new System.Drawing.Size(90, 17);
            this.cb_SingleAction.TabIndex = 0;
            this.cb_SingleAction.Text = "Single action ";
            this.cb_SingleAction.UseVisualStyleBackColor = true;
            // 
            // tb_Comments
            // 
            this.tb_Comments.Location = new System.Drawing.Point(428, 33);
            this.tb_Comments.Multiline = true;
            this.tb_Comments.Name = "tb_Comments";
            this.tb_Comments.Size = new System.Drawing.Size(699, 145);
            this.tb_Comments.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Comments:";
            // 
            // Pb_SaveChange
            // 
            this.Pb_SaveChange.Location = new System.Drawing.Point(12, 133);
            this.Pb_SaveChange.Name = "Pb_SaveChange";
            this.Pb_SaveChange.Size = new System.Drawing.Size(120, 45);
            this.Pb_SaveChange.TabIndex = 3;
            this.Pb_SaveChange.Text = "Save";
            this.Pb_SaveChange.UseVisualStyleBackColor = true;
            this.Pb_SaveChange.Click += new System.EventHandler(this.Pb_SaveChange_Click);
            // 
            // Cb_Savings
            // 
            this.Cb_Savings.AutoSize = true;
            this.Cb_Savings.Location = new System.Drawing.Point(294, 19);
            this.Cb_Savings.Name = "Cb_Savings";
            this.Cb_Savings.Size = new System.Drawing.Size(64, 17);
            this.Cb_Savings.TabIndex = 4;
            this.Cb_Savings.Text = "Savings";
            this.Cb_Savings.UseVisualStyleBackColor = true;
            this.Cb_Savings.CheckedChanged += new System.EventHandler(this.Cb_Savings_CheckedChanged);
            // 
            // Cb_Quantity
            // 
            this.Cb_Quantity.AutoSize = true;
            this.Cb_Quantity.Checked = true;
            this.Cb_Quantity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Cb_Quantity.Location = new System.Drawing.Point(294, 42);
            this.Cb_Quantity.Name = "Cb_Quantity";
            this.Cb_Quantity.Size = new System.Drawing.Size(65, 17);
            this.Cb_Quantity.TabIndex = 5;
            this.Cb_Quantity.Text = "Quantity";
            this.Cb_Quantity.UseVisualStyleBackColor = true;
            this.Cb_Quantity.Click += new System.EventHandler(this.Cb_Savings_CheckedChanged);
            // 
            // CB_Eccc
            // 
            this.CB_Eccc.AutoSize = true;
            this.CB_Eccc.Location = new System.Drawing.Point(294, 65);
            this.CB_Eccc.Name = "CB_Eccc";
            this.CB_Eccc.Size = new System.Drawing.Size(51, 17);
            this.CB_Eccc.TabIndex = 6;
            this.CB_Eccc.Text = "Eccc";
            this.CB_Eccc.UseVisualStyleBackColor = true;
            // 
            // Pb_Calc
            // 
            this.Pb_Calc.Location = new System.Drawing.Point(266, 133);
            this.Pb_Calc.Name = "Pb_Calc";
            this.Pb_Calc.Size = new System.Drawing.Size(120, 45);
            this.Pb_Calc.TabIndex = 7;
            this.Pb_Calc.Text = "Calc";
            this.Pb_Calc.UseVisualStyleBackColor = true;
            // 
            // gb_Sum
            // 
            this.gb_Sum.Controls.Add(this.DGV_Suma);
            this.gb_Sum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Sum.Location = new System.Drawing.Point(0, 340);
            this.gb_Sum.Name = "gb_Sum";
            this.gb_Sum.Size = new System.Drawing.Size(1139, 160);
            this.gb_Sum.TabIndex = 2;
            this.gb_Sum.TabStop = false;
            this.gb_Sum.Text = "Sum:";
            // 
            // DGV_Suma
            // 
            this.DGV_Suma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Suma.Location = new System.Drawing.Point(3, 33);
            this.DGV_Suma.Name = "DGV_Suma";
            this.DGV_Suma.Size = new System.Drawing.Size(1133, 107);
            this.DGV_Suma.TabIndex = 0;
            // 
            // SpecialCalcAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 682);
            this.Controls.Add(this.gb_Sum);
            this.Controls.Add(this.gb_Configure);
            this.Controls.Add(this.groupBox1);
            this.Name = "SpecialCalcAction";
            this.Text = "SpecialCalcAction";
            this.groupBox1.ResumeLayout(false);
            this.gb_Configure.ResumeLayout(false);
            this.gb_Configure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Action)).EndInit();
            this.gb_Sum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Suma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView Dgv_Action;
        private System.Windows.Forms.GroupBox gb_Configure;
        private System.Windows.Forms.Button Pb_SaveChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Comments;
        private System.Windows.Forms.CheckBox cb_SingleAction;
        private System.Windows.Forms.Button Pb_Calc;
        private System.Windows.Forms.CheckBox CB_Eccc;
        private System.Windows.Forms.CheckBox Cb_Quantity;
        private System.Windows.Forms.CheckBox Cb_Savings;
        private System.Windows.Forms.GroupBox gb_Sum;
        private System.Windows.Forms.DataGridView DGV_Suma;
    }
}