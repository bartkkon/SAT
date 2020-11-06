namespace Saving_Accelerator_Tool.Klasy.ActionTab.View
{
    partial class TreeActionView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tree_Action = new System.Windows.Forms.TreeView();
            this.comBox_FilterBy = new System.Windows.Forms.ComboBox();
            this.num_Action_YearOption = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Action_YearOption)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tree_Action);
            this.groupBox1.Controls.Add(this.comBox_FilterBy);
            this.groupBox1.Controls.Add(this.num_Action_YearOption);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 833);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // tree_Action
            // 
            this.tree_Action.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tree_Action.Location = new System.Drawing.Point(3, 48);
            this.tree_Action.Name = "tree_Action";
            this.tree_Action.Size = new System.Drawing.Size(294, 782);
            this.tree_Action.TabIndex = 4;
            this.tree_Action.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Tree_Action_AfterSelect);
            // 
            // comBox_FilterBy
            // 
            this.comBox_FilterBy.FormattingEnabled = true;
            this.comBox_FilterBy.Location = new System.Drawing.Point(164, 13);
            this.comBox_FilterBy.Name = "comBox_FilterBy";
            this.comBox_FilterBy.Size = new System.Drawing.Size(130, 21);
            this.comBox_FilterBy.TabIndex = 3;
            this.comBox_FilterBy.SelectedIndexChanged += new System.EventHandler(this.ComBox_FilterBy_SelectedIndexChanged);
            // 
            // num_Action_YearOption
            // 
            this.num_Action_YearOption.Location = new System.Drawing.Point(44, 14);
            this.num_Action_YearOption.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.num_Action_YearOption.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_Action_YearOption.Name = "num_Action_YearOption";
            this.num_Action_YearOption.Size = new System.Drawing.Size(46, 20);
            this.num_Action_YearOption.TabIndex = 2;
            this.num_Action_YearOption.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_Action_YearOption.ValueChanged += new System.EventHandler(this.Num_Action_YearOption_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Leader:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year:";
            // 
            // TreeActionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "TreeActionView";
            this.Size = new System.Drawing.Size(300, 833);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Action_YearOption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comBox_FilterBy;
        private System.Windows.Forms.NumericUpDown num_Action_YearOption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView tree_Action;
    }
}
