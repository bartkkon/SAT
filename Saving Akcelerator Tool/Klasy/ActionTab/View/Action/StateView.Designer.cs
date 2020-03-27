namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class StateView
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
            this.cb_Active = new System.Windows.Forms.CheckBox();
            this.cb_Idea = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.num_Action_YearAction = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.comBox_Month = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comBox_Factory = new System.Windows.Forms.ComboBox();
            this.comBox_Leader = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comBox_Devision = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_Action_YearAction)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_Active
            // 
            this.cb_Active.AutoSize = true;
            this.cb_Active.Location = new System.Drawing.Point(12, 3);
            this.cb_Active.Name = "cb_Active";
            this.cb_Active.Size = new System.Drawing.Size(56, 17);
            this.cb_Active.TabIndex = 0;
            this.cb_Active.Text = "Active";
            this.cb_Active.UseVisualStyleBackColor = true;
            this.cb_Active.CheckedChanged += new System.EventHandler(this.Cb_Active_CheckedChanged);
            // 
            // cb_Idea
            // 
            this.cb_Idea.AutoSize = true;
            this.cb_Idea.Location = new System.Drawing.Point(12, 26);
            this.cb_Idea.Name = "cb_Idea";
            this.cb_Idea.Size = new System.Drawing.Size(47, 17);
            this.cb_Idea.TabIndex = 1;
            this.cb_Idea.Text = "Idea";
            this.cb_Idea.UseVisualStyleBackColor = true;
            this.cb_Idea.CheckedChanged += new System.EventHandler(this.Cb_Active_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Year:";
            // 
            // num_Action_YearAction
            // 
            this.num_Action_YearAction.Location = new System.Drawing.Point(100, 23);
            this.num_Action_YearAction.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.num_Action_YearAction.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_Action_YearAction.Name = "num_Action_YearAction";
            this.num_Action_YearAction.Size = new System.Drawing.Size(58, 20);
            this.num_Action_YearAction.TabIndex = 3;
            this.num_Action_YearAction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_Action_YearAction.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_Action_YearAction.ValueChanged += new System.EventHandler(this.ChangeSomenthing_Change);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start Month:";
            // 
            // comBox_Month
            // 
            this.comBox_Month.FormattingEnabled = true;
            this.comBox_Month.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.comBox_Month.Location = new System.Drawing.Point(100, 66);
            this.comBox_Month.Name = "comBox_Month";
            this.comBox_Month.Size = new System.Drawing.Size(84, 21);
            this.comBox_Month.TabIndex = 5;
            this.comBox_Month.SelectedIndexChanged += new System.EventHandler(this.ChangeSomenthing_Change);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(200, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Action Leader:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Factory:";
            // 
            // comBox_Factory
            // 
            this.comBox_Factory.FormattingEnabled = true;
            this.comBox_Factory.Items.AddRange(new object[] {
            "PLV",
            "ZM"});
            this.comBox_Factory.Location = new System.Drawing.Point(12, 66);
            this.comBox_Factory.Name = "comBox_Factory";
            this.comBox_Factory.Size = new System.Drawing.Size(66, 21);
            this.comBox_Factory.TabIndex = 8;
            this.comBox_Factory.SelectedIndexChanged += new System.EventHandler(this.ChangeSomenthing_Change);
            // 
            // comBox_Leader
            // 
            this.comBox_Leader.FormattingEnabled = true;
            this.comBox_Leader.Location = new System.Drawing.Point(203, 24);
            this.comBox_Leader.Name = "comBox_Leader";
            this.comBox_Leader.Size = new System.Drawing.Size(121, 21);
            this.comBox_Leader.TabIndex = 9;
            this.comBox_Leader.SelectedIndexChanged += new System.EventHandler(this.ChangeSomenthing_Change);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Devision:";
            // 
            // comBox_Devision
            // 
            this.comBox_Devision.FormattingEnabled = true;
            this.comBox_Devision.Location = new System.Drawing.Point(203, 66);
            this.comBox_Devision.Name = "comBox_Devision";
            this.comBox_Devision.Size = new System.Drawing.Size(121, 21);
            this.comBox_Devision.TabIndex = 11;
            this.comBox_Devision.SelectedIndexChanged += new System.EventHandler(this.ChangeSomenthing_Change);
            // 
            // StateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comBox_Devision);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comBox_Leader);
            this.Controls.Add(this.comBox_Factory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comBox_Month);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num_Action_YearAction);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Idea);
            this.Controls.Add(this.cb_Active);
            this.Name = "StateView";
            this.Size = new System.Drawing.Size(340, 100);
            ((System.ComponentModel.ISupportInitialize)(this.num_Action_YearAction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_Active;
        private System.Windows.Forms.CheckBox cb_Idea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_Action_YearAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comBox_Month;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comBox_Factory;
        private System.Windows.Forms.ComboBox comBox_Leader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comBox_Devision;
    }
}
