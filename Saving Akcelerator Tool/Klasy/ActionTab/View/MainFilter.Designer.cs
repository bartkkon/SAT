namespace Saving_Accelerator_Tool.Klasy.ActionTab.View
{
    partial class MainFilter
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
            this.cb_ActionActive = new System.Windows.Forms.CheckBox();
            this.cb_ActionIdea = new System.Windows.Forms.CheckBox();
            this.but_Action_NewAction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_ActionActive
            // 
            this.cb_ActionActive.AutoSize = true;
            this.cb_ActionActive.Checked = true;
            this.cb_ActionActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_ActionActive.Location = new System.Drawing.Point(17, 20);
            this.cb_ActionActive.Name = "cb_ActionActive";
            this.cb_ActionActive.Size = new System.Drawing.Size(89, 17);
            this.cb_ActionActive.TabIndex = 0;
            this.cb_ActionActive.Text = "Active Action";
            this.cb_ActionActive.UseVisualStyleBackColor = true;
            this.cb_ActionActive.Click += new System.EventHandler(this.Active_Idea_CheckedChange);
            // 
            // cb_ActionIdea
            // 
            this.cb_ActionIdea.AllowDrop = true;
            this.cb_ActionIdea.AutoSize = true;
            this.cb_ActionIdea.Location = new System.Drawing.Point(17, 43);
            this.cb_ActionIdea.Name = "cb_ActionIdea";
            this.cb_ActionIdea.Size = new System.Drawing.Size(80, 17);
            this.cb_ActionIdea.TabIndex = 1;
            this.cb_ActionIdea.Text = "Idea Action";
            this.cb_ActionIdea.UseVisualStyleBackColor = true;
            this.cb_ActionIdea.Click += new System.EventHandler(this.Active_Idea_CheckedChange);
            // 
            // but_Action_NewAction
            // 
            this.but_Action_NewAction.Location = new System.Drawing.Point(170, 20);
            this.but_Action_NewAction.Name = "but_Action_NewAction";
            this.but_Action_NewAction.Size = new System.Drawing.Size(110, 35);
            this.but_Action_NewAction.TabIndex = 2;
            this.but_Action_NewAction.Text = "New Action";
            this.but_Action_NewAction.UseVisualStyleBackColor = true;
            this.but_Action_NewAction.Click += new System.EventHandler(this.But_Action_NewAction_Click);
            // 
            // MainFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.but_Action_NewAction);
            this.Controls.Add(this.cb_ActionIdea);
            this.Controls.Add(this.cb_ActionActive);
            this.Name = "MainFilter";
            this.Size = new System.Drawing.Size(300, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_ActionActive;
        private System.Windows.Forms.CheckBox cb_ActionIdea;
        private System.Windows.Forms.Button but_Action_NewAction;
    }
}
