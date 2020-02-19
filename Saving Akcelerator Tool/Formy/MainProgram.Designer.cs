using System.Data;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool
{
    partial class MainProgram
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProgram));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_Action = new System.Windows.Forms.TabPage();
            this.actionView = new Saving_Accelerator_Tool.Klasy.ActionTab.View.ActionView();
            this.treeActionView = new Saving_Accelerator_Tool.Klasy.ActionTab.View.TreeActionView();
            this.mainFilter = new Saving_Accelerator_Tool.Klasy.ActionTab.View.MainFilter();
            this.tab_Summary = new System.Windows.Forms.TabPage();
            this.tab_SummaryS = new System.Windows.Forms.TabPage();
            this.tab_Statistic = new System.Windows.Forms.TabPage();
            this.tab_Platform = new System.Windows.Forms.TabPage();
            this.tab_STK = new System.Windows.Forms.TabPage();
            this.tab_Quantity = new System.Windows.Forms.TabPage();
            this.tab_Admin = new System.Windows.Forms.TabPage();
            this.tab_AdminAction = new System.Windows.Forms.TabPage();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tab_Action.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1001);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1920, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 0);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.tabControl);
            this.panel2.Location = new System.Drawing.Point(0, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1920, 1000);
            this.panel2.TabIndex = 3;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab_Action);
            this.tabControl.Controls.Add(this.tab_Summary);
            this.tabControl.Controls.Add(this.tab_SummaryS);
            this.tabControl.Controls.Add(this.tab_Statistic);
            this.tabControl.Controls.Add(this.tab_Platform);
            this.tabControl.Controls.Add(this.tab_STK);
            this.tabControl.Controls.Add(this.tab_Quantity);
            this.tabControl.Controls.Add(this.tab_Admin);
            this.tabControl.Controls.Add(this.tab_AdminAction);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1920, 1000);
            this.tabControl.TabIndex = 0;
            // 
            // tab_Action
            // 
            this.tab_Action.Controls.Add(this.actionView);
            this.tab_Action.Controls.Add(this.treeActionView);
            this.tab_Action.Controls.Add(this.mainFilter);
            this.tab_Action.Location = new System.Drawing.Point(4, 22);
            this.tab_Action.Name = "tab_Action";
            this.tab_Action.Size = new System.Drawing.Size(1912, 974);
            this.tab_Action.TabIndex = 0;
            this.tab_Action.Text = "Action";
            this.tab_Action.UseVisualStyleBackColor = true;
            // 
            // actionView
            // 
            this.actionView.Location = new System.Drawing.Point(305, 0);
            this.actionView.Name = "actionView";
            this.actionView.Size = new System.Drawing.Size(1603, 972);
            this.actionView.TabIndex = 2;
            // 
            // treeActionView
            // 
            this.treeActionView.Location = new System.Drawing.Point(0, 140);
            this.treeActionView.Name = "treeActionView";
            this.treeActionView.Size = new System.Drawing.Size(300, 833);
            this.treeActionView.TabIndex = 1;
            // 
            // mainFilter
            // 
            this.mainFilter.Location = new System.Drawing.Point(0, 0);
            this.mainFilter.Name = "mainFilter";
            this.mainFilter.Size = new System.Drawing.Size(300, 140);
            this.mainFilter.TabIndex = 0;
            // 
            // tab_Summary
            // 
            this.tab_Summary.Location = new System.Drawing.Point(4, 22);
            this.tab_Summary.Name = "tab_Summary";
            this.tab_Summary.Size = new System.Drawing.Size(1912, 974);
            this.tab_Summary.TabIndex = 1;
            this.tab_Summary.Text = "Summary Detail";
            this.tab_Summary.UseVisualStyleBackColor = true;
            // 
            // tab_SummaryS
            // 
            this.tab_SummaryS.Location = new System.Drawing.Point(4, 22);
            this.tab_SummaryS.Name = "tab_SummaryS";
            this.tab_SummaryS.Size = new System.Drawing.Size(1912, 974);
            this.tab_SummaryS.TabIndex = 2;
            this.tab_SummaryS.Text = "Summary";
            this.tab_SummaryS.UseVisualStyleBackColor = true;
            // 
            // tab_Statistic
            // 
            this.tab_Statistic.Location = new System.Drawing.Point(4, 22);
            this.tab_Statistic.Name = "tab_Statistic";
            this.tab_Statistic.Size = new System.Drawing.Size(1912, 974);
            this.tab_Statistic.TabIndex = 3;
            this.tab_Statistic.Text = "Statistic";
            this.tab_Statistic.UseVisualStyleBackColor = true;
            // 
            // tab_Platform
            // 
            this.tab_Platform.Location = new System.Drawing.Point(4, 22);
            this.tab_Platform.Name = "tab_Platform";
            this.tab_Platform.Size = new System.Drawing.Size(1912, 974);
            this.tab_Platform.TabIndex = 4;
            this.tab_Platform.Text = "Platform";
            this.tab_Platform.UseVisualStyleBackColor = true;
            // 
            // tab_STK
            // 
            this.tab_STK.Location = new System.Drawing.Point(4, 22);
            this.tab_STK.Name = "tab_STK";
            this.tab_STK.Size = new System.Drawing.Size(1912, 974);
            this.tab_STK.TabIndex = 5;
            this.tab_STK.Text = "STK";
            this.tab_STK.UseVisualStyleBackColor = true;
            // 
            // tab_Quantity
            // 
            this.tab_Quantity.Location = new System.Drawing.Point(4, 22);
            this.tab_Quantity.Name = "tab_Quantity";
            this.tab_Quantity.Size = new System.Drawing.Size(1912, 974);
            this.tab_Quantity.TabIndex = 6;
            this.tab_Quantity.Text = "Quantity";
            this.tab_Quantity.UseVisualStyleBackColor = true;
            // 
            // tab_Admin
            // 
            this.tab_Admin.Location = new System.Drawing.Point(4, 22);
            this.tab_Admin.Name = "tab_Admin";
            this.tab_Admin.Size = new System.Drawing.Size(1912, 974);
            this.tab_Admin.TabIndex = 7;
            this.tab_Admin.Text = "Administration";
            this.tab_Admin.UseVisualStyleBackColor = true;
            // 
            // tab_AdminAction
            // 
            this.tab_AdminAction.Location = new System.Drawing.Point(4, 22);
            this.tab_AdminAction.Name = "tab_AdminAction";
            this.tab_AdminAction.Size = new System.Drawing.Size(1912, 974);
            this.tab_AdminAction.TabIndex = 9;
            this.tab_AdminAction.Text = "Action Admin";
            this.tab_AdminAction.UseVisualStyleBackColor = true;
            // 
            // MainProgram
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1899, 1040);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Saving Accelerator Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tab_Action.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TabPage tab_Action;
        private TabPage tab_Summary;
        private TabPage tab_SummaryS;
        private TabPage tab_Statistic;
        private TabPage tab_Platform;
        private TabPage tab_STK;
        private TabPage tab_Quantity;
        private TabPage tab_Admin;
        private TabPage tab_AdminAction;
        public Klasy.ActionTab.View.ActionView actionView;
        public Klasy.ActionTab.View.MainFilter mainFilter;
        public Klasy.ActionTab.View.TreeActionView treeActionView;

        public TabControl TabControl { get => tabControl; set => tabControl = value; }

    }
}

