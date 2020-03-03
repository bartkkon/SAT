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
            this.sdReporting1 = new Saving_Accelerator_Tool.Klasy.SummaryDetails.View.SDReporting();
            this.sdTableAllView = new Saving_Accelerator_Tool.Klasy.SummaryDetails.View.SDTableAllView();
            this.sdOptions1 = new Saving_Accelerator_Tool.Klasy.SummaryDetails.View.SDOptions();
            this.tab_SummaryS = new System.Windows.Forms.TabPage();
            this.sdOptions2 = new Saving_Accelerator_Tool.Klasy.SummaryDetails.View.SDOptions();
            this.tab_Statistic = new System.Windows.Forms.TabPage();
            this.productionQuantityMonthView1 = new Saving_Accelerator_Tool.Klasy.StatisticTab.View.ProductionQuantityMonthView();
            this.productionQuantityView = new Saving_Accelerator_Tool.Klasy.StatisticTab.View.ProductionQuantityView();
            this.dmView = new Saving_Accelerator_Tool.Klasy.StatisticTab.View.DMView();
            this.optionView = new Saving_Accelerator_Tool.Klasy.StatisticTab.View.OptionView();
            this.tab_Platform = new System.Windows.Forms.TabPage();
            this.tab_STK = new System.Windows.Forms.TabPage();
            this.tab_Quantity = new System.Windows.Forms.TabPage();
            this.tab_Admin = new System.Windows.Forms.TabPage();
            this.sendMailView1 = new Saving_Accelerator_Tool.Klasy.AdmnTab.View.SendMailView();
            this.dataBaseView1 = new Saving_Accelerator_Tool.Klasy.AdminTab.View.DataBaseView();
            this.coinsView1 = new Saving_Accelerator_Tool.Klasy.AdminTab.View.CoinsView();
            this.targetView1 = new Saving_Accelerator_Tool.Klasy.AdminTab.View.TargetView();
            this.autoUpdateSTKView1 = new Saving_Accelerator_Tool.Klasy.AdmnTab.View.AutoUpdateSTKView();
            this.addPersonView1 = new Saving_Accelerator_Tool.Klasy.AdminTab.View.AddPersonView();
            this.actionActivatorView1 = new Saving_Accelerator_Tool.Klasy.AdminTab.View.ActionActivatorView();
            this.frozen1 = new Saving_Accelerator_Tool.Klasy.AdminTab.View.Frozen();
            this.sumPNC1 = new Saving_Accelerator_Tool.Klasy.AdminTab.View.SumPNC();
            this.quantityRevAddView1 = new Saving_Accelerator_Tool.Klasy.AdminTab.View.QuantityRevAddView();
            this.quantityMonthAddView1 = new Saving_Accelerator_Tool.Klasy.AdminTab.View.QuantityMonthAddView();
            this.tab_AdminAction = new System.Windows.Forms.TabPage();
            this.SDSumAllAction = new Saving_Accelerator_Tool.Klasy.SummaryDetails.View.SDSumAllAction();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tab_Action.SuspendLayout();
            this.tab_Summary.SuspendLayout();
            this.tab_SummaryS.SuspendLayout();
            this.tab_Statistic.SuspendLayout();
            this.tab_Admin.SuspendLayout();
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
            this.actionView.Location = new System.Drawing.Point(301, 6);
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
            this.tab_Summary.Controls.Add(this.sdReporting1);
            this.tab_Summary.Controls.Add(this.sdTableAllView);
            this.tab_Summary.Controls.Add(this.sdOptions1);
            this.tab_Summary.Location = new System.Drawing.Point(4, 22);
            this.tab_Summary.Name = "tab_Summary";
            this.tab_Summary.Size = new System.Drawing.Size(192, 74);
            this.tab_Summary.TabIndex = 1;
            this.tab_Summary.Text = "Summary Detail";
            this.tab_Summary.UseVisualStyleBackColor = true;
            // 
            // sdReporting1
            // 
            this.sdReporting1.Location = new System.Drawing.Point(8, 691);
            this.sdReporting1.Name = "sdReporting1";
            this.sdReporting1.Size = new System.Drawing.Size(200, 279);
            this.sdReporting1.TabIndex = 2;
            // 
            // sdTableAllView
            // 
            this.sdTableAllView.Location = new System.Drawing.Point(210, 0);
            this.sdTableAllView.Name = "sdTableAllView";
            this.sdTableAllView.Size = new System.Drawing.Size(1580, 970);
            this.sdTableAllView.TabIndex = 1;
            // 
            // sdOptions1
            // 
            this.sdOptions1.Location = new System.Drawing.Point(3, 3);
            this.sdOptions1.Name = "sdOptions1";
            this.sdOptions1.Size = new System.Drawing.Size(201, 253);
            this.sdOptions1.TabIndex = 0;
            // 
            // tab_SummaryS
            // 
            this.tab_SummaryS.Controls.Add(this.SDSumAllAction);
            this.tab_SummaryS.Controls.Add(this.sdOptions2);
            this.tab_SummaryS.Location = new System.Drawing.Point(4, 22);
            this.tab_SummaryS.Name = "tab_SummaryS";
            this.tab_SummaryS.Size = new System.Drawing.Size(1912, 974);
            this.tab_SummaryS.TabIndex = 2;
            this.tab_SummaryS.Text = "Summary";
            this.tab_SummaryS.UseVisualStyleBackColor = true;
            // 
            // sdOptions2
            // 
            this.sdOptions2.Location = new System.Drawing.Point(3, 3);
            this.sdOptions2.Name = "sdOptions2";
            this.sdOptions2.Size = new System.Drawing.Size(201, 253);
            this.sdOptions2.TabIndex = 0;
            // 
            // tab_Statistic
            // 
            this.tab_Statistic.Controls.Add(this.productionQuantityMonthView1);
            this.tab_Statistic.Controls.Add(this.productionQuantityView);
            this.tab_Statistic.Controls.Add(this.dmView);
            this.tab_Statistic.Controls.Add(this.optionView);
            this.tab_Statistic.Location = new System.Drawing.Point(4, 40);
            this.tab_Statistic.Name = "tab_Statistic";
            this.tab_Statistic.Size = new System.Drawing.Size(192, 56);
            this.tab_Statistic.TabIndex = 3;
            this.tab_Statistic.Text = "Statistic";
            this.tab_Statistic.UseVisualStyleBackColor = true;
            // 
            // productionQuantityMonthView1
            // 
            this.productionQuantityMonthView1.Location = new System.Drawing.Point(156, 169);
            this.productionQuantityMonthView1.Name = "productionQuantityMonthView1";
            this.productionQuantityMonthView1.Size = new System.Drawing.Size(1042, 148);
            this.productionQuantityMonthView1.TabIndex = 3;
            // 
            // productionQuantityView
            // 
            this.productionQuantityView.Location = new System.Drawing.Point(712, 3);
            this.productionQuantityView.Name = "productionQuantityView";
            this.productionQuantityView.Size = new System.Drawing.Size(490, 160);
            this.productionQuantityView.TabIndex = 2;
            // 
            // dmView
            // 
            this.dmView.Location = new System.Drawing.Point(156, 3);
            this.dmView.Name = "dmView";
            this.dmView.Size = new System.Drawing.Size(550, 160);
            this.dmView.TabIndex = 1;
            // 
            // optionView
            // 
            this.optionView.Location = new System.Drawing.Point(8, 3);
            this.optionView.Name = "optionView";
            this.optionView.Size = new System.Drawing.Size(142, 112);
            this.optionView.TabIndex = 0;
            // 
            // tab_Platform
            // 
            this.tab_Platform.Location = new System.Drawing.Point(4, 40);
            this.tab_Platform.Name = "tab_Platform";
            this.tab_Platform.Size = new System.Drawing.Size(192, 56);
            this.tab_Platform.TabIndex = 4;
            this.tab_Platform.Text = "Platform";
            this.tab_Platform.UseVisualStyleBackColor = true;
            // 
            // tab_STK
            // 
            this.tab_STK.Location = new System.Drawing.Point(4, 40);
            this.tab_STK.Name = "tab_STK";
            this.tab_STK.Size = new System.Drawing.Size(192, 56);
            this.tab_STK.TabIndex = 5;
            this.tab_STK.Text = "STK";
            this.tab_STK.UseVisualStyleBackColor = true;
            // 
            // tab_Quantity
            // 
            this.tab_Quantity.Location = new System.Drawing.Point(4, 40);
            this.tab_Quantity.Name = "tab_Quantity";
            this.tab_Quantity.Size = new System.Drawing.Size(192, 56);
            this.tab_Quantity.TabIndex = 6;
            this.tab_Quantity.Text = "Quantity";
            this.tab_Quantity.UseVisualStyleBackColor = true;
            // 
            // tab_Admin
            // 
            this.tab_Admin.Controls.Add(this.sendMailView1);
            this.tab_Admin.Controls.Add(this.dataBaseView1);
            this.tab_Admin.Controls.Add(this.coinsView1);
            this.tab_Admin.Controls.Add(this.targetView1);
            this.tab_Admin.Controls.Add(this.autoUpdateSTKView1);
            this.tab_Admin.Controls.Add(this.addPersonView1);
            this.tab_Admin.Controls.Add(this.actionActivatorView1);
            this.tab_Admin.Controls.Add(this.frozen1);
            this.tab_Admin.Controls.Add(this.sumPNC1);
            this.tab_Admin.Controls.Add(this.quantityRevAddView1);
            this.tab_Admin.Controls.Add(this.quantityMonthAddView1);
            this.tab_Admin.Location = new System.Drawing.Point(4, 58);
            this.tab_Admin.Name = "tab_Admin";
            this.tab_Admin.Size = new System.Drawing.Size(192, 38);
            this.tab_Admin.TabIndex = 7;
            this.tab_Admin.Text = "Administration";
            this.tab_Admin.UseVisualStyleBackColor = true;
            // 
            // sendMailView1
            // 
            this.sendMailView1.Location = new System.Drawing.Point(1280, 3);
            this.sendMailView1.Name = "sendMailView1";
            this.sendMailView1.Size = new System.Drawing.Size(330, 339);
            this.sendMailView1.TabIndex = 10;
            // 
            // dataBaseView1
            // 
            this.dataBaseView1.Location = new System.Drawing.Point(1124, 3);
            this.dataBaseView1.Name = "dataBaseView1";
            this.dataBaseView1.Size = new System.Drawing.Size(150, 300);
            this.dataBaseView1.TabIndex = 9;
            // 
            // coinsView1
            // 
            this.coinsView1.Location = new System.Drawing.Point(818, 259);
            this.coinsView1.Name = "coinsView1";
            this.coinsView1.Size = new System.Drawing.Size(200, 200);
            this.coinsView1.TabIndex = 8;
            // 
            // targetView1
            // 
            this.targetView1.Location = new System.Drawing.Point(818, 3);
            this.targetView1.Name = "targetView1";
            this.targetView1.Size = new System.Drawing.Size(300, 250);
            this.targetView1.TabIndex = 7;
            // 
            // autoUpdateSTKView1
            // 
            this.autoUpdateSTKView1.Location = new System.Drawing.Point(412, 509);
            this.autoUpdateSTKView1.Name = "autoUpdateSTKView1";
            this.autoUpdateSTKView1.Size = new System.Drawing.Size(200, 270);
            this.autoUpdateSTKView1.TabIndex = 6;
            // 
            // addPersonView1
            // 
            this.addPersonView1.Location = new System.Drawing.Point(412, 3);
            this.addPersonView1.Name = "addPersonView1";
            this.addPersonView1.Size = new System.Drawing.Size(400, 500);
            this.addPersonView1.TabIndex = 5;
            // 
            // actionActivatorView1
            // 
            this.actionActivatorView1.Location = new System.Drawing.Point(206, 659);
            this.actionActivatorView1.Name = "actionActivatorView1";
            this.actionActivatorView1.Size = new System.Drawing.Size(200, 100);
            this.actionActivatorView1.TabIndex = 4;
            // 
            // frozen1
            // 
            this.frozen1.Location = new System.Drawing.Point(206, 3);
            this.frozen1.Name = "frozen1";
            this.frozen1.Size = new System.Drawing.Size(200, 650);
            this.frozen1.TabIndex = 3;
            // 
            // sumPNC1
            // 
            this.sumPNC1.Location = new System.Drawing.Point(0, 452);
            this.sumPNC1.Name = "sumPNC1";
            this.sumPNC1.Size = new System.Drawing.Size(200, 160);
            this.sumPNC1.TabIndex = 2;
            // 
            // quantityRevAddView1
            // 
            this.quantityRevAddView1.Location = new System.Drawing.Point(0, 0);
            this.quantityRevAddView1.Name = "quantityRevAddView1";
            this.quantityRevAddView1.Size = new System.Drawing.Size(200, 220);
            this.quantityRevAddView1.TabIndex = 1;
            // 
            // quantityMonthAddView1
            // 
            this.quantityMonthAddView1.Location = new System.Drawing.Point(0, 226);
            this.quantityMonthAddView1.Name = "quantityMonthAddView1";
            this.quantityMonthAddView1.Size = new System.Drawing.Size(200, 220);
            this.quantityMonthAddView1.TabIndex = 0;
            // 
            // tab_AdminAction
            // 
            this.tab_AdminAction.Location = new System.Drawing.Point(4, 58);
            this.tab_AdminAction.Name = "tab_AdminAction";
            this.tab_AdminAction.Size = new System.Drawing.Size(192, 38);
            this.tab_AdminAction.TabIndex = 9;
            this.tab_AdminAction.Text = "Action Admin";
            this.tab_AdminAction.UseVisualStyleBackColor = true;
            // 
            // SDSumAllAction
            // 
            this.SDSumAllAction.Location = new System.Drawing.Point(210, 3);
            this.SDSumAllAction.Name = "SDSumAllAction";
            this.SDSumAllAction.Size = new System.Drawing.Size(1600, 970);
            this.SDSumAllAction.TabIndex = 1;
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
            this.tab_Summary.ResumeLayout(false);
            this.tab_SummaryS.ResumeLayout(false);
            this.tab_Statistic.ResumeLayout(false);
            this.tab_Admin.ResumeLayout(false);
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
        private Klasy.AdminTab.View.QuantityRevAddView quantityRevAddView1;
        private Klasy.AdminTab.View.QuantityMonthAddView quantityMonthAddView1;
        private Klasy.AdminTab.View.SumPNC sumPNC1;
        private Klasy.AdminTab.View.ActionActivatorView actionActivatorView1;
        private Klasy.AdminTab.View.Frozen frozen1;
        private Klasy.AdminTab.View.CoinsView coinsView1;
        private Klasy.AdminTab.View.TargetView targetView1;
        private Klasy.AdmnTab.View.AutoUpdateSTKView autoUpdateSTKView1;
        private Klasy.AdminTab.View.AddPersonView addPersonView1;
        private Klasy.AdminTab.View.DataBaseView dataBaseView1;
        private Klasy.AdmnTab.View.SendMailView sendMailView1;
        public Klasy.StatisticTab.View.ProductionQuantityView productionQuantityView;
        public Klasy.StatisticTab.View.DMView dmView;
        public Klasy.StatisticTab.View.OptionView optionView;
        public Klasy.StatisticTab.View.ProductionQuantityMonthView productionQuantityMonthView1;
        public Klasy.SummaryDetails.View.SDOptions sdOptions1;
        public Klasy.SummaryDetails.View.SDOptions sdOptions2;
        public Klasy.SummaryDetails.View.SDTableAllView sdTableAllView;
        public Klasy.SummaryDetails.View.SDReporting sdReporting1;
        public Klasy.SummaryDetails.View.SDSumAllAction SDSumAllAction;

        public TabControl TabControl { get => tabControl; set => tabControl = value; }

    }
}

