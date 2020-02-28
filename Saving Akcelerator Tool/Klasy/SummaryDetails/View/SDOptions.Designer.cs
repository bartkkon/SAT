namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.View
{
    partial class SDOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.num_SummaryDetailYear = new System.Windows.Forms.NumericUpDown();
            this.Comb_SummDetLeader = new System.Windows.Forms.ComboBox();
            this.Comb_SummDetDevision = new System.Windows.Forms.ComboBox();
            this.CB_Active = new System.Windows.Forms.CheckBox();
            this.CB_Idea = new System.Windows.Forms.CheckBox();
            this.CB_Positive = new System.Windows.Forms.CheckBox();
            this.CB_Negative = new System.Windows.Forms.CheckBox();
            this.pb_SummDet_Show = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_SummaryDetailYear)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Leader:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Devision:";
            // 
            // num_SummaryDetailYear
            // 
            this.num_SummaryDetailYear.Location = new System.Drawing.Point(124, 10);
            this.num_SummaryDetailYear.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.num_SummaryDetailYear.Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_SummaryDetailYear.Name = "num_SummaryDetailYear";
            this.num_SummaryDetailYear.Size = new System.Drawing.Size(64, 20);
            this.num_SummaryDetailYear.TabIndex = 3;
            this.num_SummaryDetailYear.Value = new decimal(new int[] {
            2018,
            0,
            0,
            0});
            this.num_SummaryDetailYear.ValueChanged += new System.EventHandler(this.Num_SummaryDetailYear_ValueChanged);
            // 
            // Comb_SummDetLeader
            // 
            this.Comb_SummDetLeader.FormattingEnabled = true;
            this.Comb_SummDetLeader.Location = new System.Drawing.Point(68, 36);
            this.Comb_SummDetLeader.Name = "Comb_SummDetLeader";
            this.Comb_SummDetLeader.Size = new System.Drawing.Size(121, 21);
            this.Comb_SummDetLeader.TabIndex = 4;
            this.Comb_SummDetLeader.SelectedIndexChanged += new System.EventHandler(this.Comb_SummDetLeader_SelectedIndexChanged);
            // 
            // Comb_SummDetDevision
            // 
            this.Comb_SummDetDevision.FormattingEnabled = true;
            this.Comb_SummDetDevision.Location = new System.Drawing.Point(68, 63);
            this.Comb_SummDetDevision.Name = "Comb_SummDetDevision";
            this.Comb_SummDetDevision.Size = new System.Drawing.Size(121, 21);
            this.Comb_SummDetDevision.TabIndex = 5;
            this.Comb_SummDetDevision.SelectedIndexChanged += new System.EventHandler(this.Comb_SummDetDevision_SelectedIndexChanged);
            // 
            // CB_Active
            // 
            this.CB_Active.AutoSize = true;
            this.CB_Active.Checked = true;
            this.CB_Active.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Active.Location = new System.Drawing.Point(15, 101);
            this.CB_Active.Name = "CB_Active";
            this.CB_Active.Size = new System.Drawing.Size(89, 17);
            this.CB_Active.TabIndex = 6;
            this.CB_Active.Text = "Active Action";
            this.CB_Active.UseVisualStyleBackColor = true;
            this.CB_Active.CheckedChanged += new System.EventHandler(this.CB_Active_CheckedChanged);
            // 
            // CB_Idea
            // 
            this.CB_Idea.AutoSize = true;
            this.CB_Idea.Location = new System.Drawing.Point(15, 124);
            this.CB_Idea.Name = "CB_Idea";
            this.CB_Idea.Size = new System.Drawing.Size(80, 17);
            this.CB_Idea.TabIndex = 7;
            this.CB_Idea.Text = "Idea Action";
            this.CB_Idea.UseVisualStyleBackColor = true;
            this.CB_Idea.CheckedChanged += new System.EventHandler(this.CB_Idea_CheckedChanged);
            // 
            // CB_Positive
            // 
            this.CB_Positive.AutoSize = true;
            this.CB_Positive.Checked = true;
            this.CB_Positive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Positive.Location = new System.Drawing.Point(15, 160);
            this.CB_Positive.Name = "CB_Positive";
            this.CB_Positive.Size = new System.Drawing.Size(96, 17);
            this.CB_Positive.TabIndex = 8;
            this.CB_Positive.Text = "Positive Action";
            this.CB_Positive.UseVisualStyleBackColor = true;
            this.CB_Positive.CheckedChanged += new System.EventHandler(this.CB_Positive_CheckedChanged);
            // 
            // CB_Negative
            // 
            this.CB_Negative.AutoSize = true;
            this.CB_Negative.Checked = true;
            this.CB_Negative.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Negative.Location = new System.Drawing.Point(15, 183);
            this.CB_Negative.Name = "CB_Negative";
            this.CB_Negative.Size = new System.Drawing.Size(102, 17);
            this.CB_Negative.TabIndex = 9;
            this.CB_Negative.Text = "Negative Action";
            this.CB_Negative.UseVisualStyleBackColor = true;
            this.CB_Negative.CheckedChanged += new System.EventHandler(this.CB_Negative_CheckedChanged);
            // 
            // pb_SummDet_Show
            // 
            this.pb_SummDet_Show.Location = new System.Drawing.Point(113, 221);
            this.pb_SummDet_Show.Name = "pb_SummDet_Show";
            this.pb_SummDet_Show.Size = new System.Drawing.Size(75, 23);
            this.pb_SummDet_Show.TabIndex = 10;
            this.pb_SummDet_Show.Text = "Show";
            this.pb_SummDet_Show.UseVisualStyleBackColor = true;
            this.pb_SummDet_Show.Click += new System.EventHandler(this.Pb_SummDet_Show_Click);
            // 
            // SDOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pb_SummDet_Show);
            this.Controls.Add(this.CB_Negative);
            this.Controls.Add(this.CB_Positive);
            this.Controls.Add(this.CB_Idea);
            this.Controls.Add(this.CB_Active);
            this.Controls.Add(this.Comb_SummDetDevision);
            this.Controls.Add(this.Comb_SummDetLeader);
            this.Controls.Add(this.num_SummaryDetailYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SDOptions";
            this.Size = new System.Drawing.Size(200, 250);
            ((System.ComponentModel.ISupportInitialize)(this.num_SummaryDetailYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown num_SummaryDetailYear;
        private System.Windows.Forms.ComboBox Comb_SummDetLeader;
        private System.Windows.Forms.ComboBox Comb_SummDetDevision;
        private System.Windows.Forms.CheckBox CB_Active;
        private System.Windows.Forms.CheckBox CB_Idea;
        private System.Windows.Forms.CheckBox CB_Positive;
        private System.Windows.Forms.CheckBox CB_Negative;
        private System.Windows.Forms.Button pb_SummDet_Show;
    }
}
