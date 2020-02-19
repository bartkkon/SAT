namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    partial class Gb_PNCEsty
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
            this.label1 = new System.Windows.Forms.Label();
            this.TB_EstymacjaPNC = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_EstymacjaPNC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PNC Special Estymation:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estymation:";
            // 
            // TB_EstymacjaPNC
            // 
            this.TB_EstymacjaPNC.Location = new System.Drawing.Point(21, 55);
            this.TB_EstymacjaPNC.Name = "TB_EstymacjaPNC";
            this.TB_EstymacjaPNC.Size = new System.Drawing.Size(92, 20);
            this.TB_EstymacjaPNC.TabIndex = 1;
            this.TB_EstymacjaPNC.TextChanged += new System.EventHandler(this.TB_EstymacjaPNC_TextChanged);
            this.TB_EstymacjaPNC.Leave += new System.EventHandler(this.TB_EstymacjaPNC_Leave);
            // 
            // Gb_PNCEsty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "Gb_PNCEsty";
            this.Size = new System.Drawing.Size(140, 115);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TB_EstymacjaPNC;
        private System.Windows.Forms.Label label1;
    }
}
