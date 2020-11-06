namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    partial class ActionActivatorView
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
            this.Pb_Activator_Action = new System.Windows.Forms.Button();
            this.Pb_Deactivator_Action = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Pb_Deactivator_Action);
            this.groupBox1.Controls.Add(this.Pb_Activator_Action);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action Activator:";
            // 
            // Pb_Activator_Action
            // 
            this.Pb_Activator_Action.Location = new System.Drawing.Point(10, 20);
            this.Pb_Activator_Action.Name = "Pb_Activator_Action";
            this.Pb_Activator_Action.Size = new System.Drawing.Size(180, 30);
            this.Pb_Activator_Action.TabIndex = 0;
            this.Pb_Activator_Action.Text = "Active Action";
            this.Pb_Activator_Action.UseVisualStyleBackColor = true;
            this.Pb_Activator_Action.Click += new System.EventHandler(this.Pb_ActivatorAction_Click);
            // 
            // Pb_Deactivator_Action
            // 
            this.Pb_Deactivator_Action.Location = new System.Drawing.Point(10, 60);
            this.Pb_Deactivator_Action.Name = "Pb_Deactivator_Action";
            this.Pb_Deactivator_Action.Size = new System.Drawing.Size(180, 30);
            this.Pb_Deactivator_Action.TabIndex = 1;
            this.Pb_Deactivator_Action.Text = "Deactivation Action";
            this.Pb_Deactivator_Action.UseVisualStyleBackColor = true;
            this.Pb_Deactivator_Action.Click += new System.EventHandler(this.Pb_DeactivatorAction_Click);
            // 
            // ActionActivatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ActionActivatorView";
            this.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Pb_Deactivator_Action;
        private System.Windows.Forms.Button Pb_Activator_Action;
    }
}
