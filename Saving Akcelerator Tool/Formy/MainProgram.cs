using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Deployment.Application;
using Saving_Accelerator_Tool.Klasy.User;
using Saving_Accelerator_Tool.Klasy.Acton;
using Saving_Accelerator_Tool.Klasy.ActionTab.Framework;

namespace Saving_Accelerator_Tool
{
    public partial class MainProgram : Form
    {
        public static MainProgram Self;

        public MainProgram()
        {
            //try
            //{
            //Sprawdzenie czy jest dostęp do Baz Danych
            if (!Data_Import.Singleton().CheckConnectionToDataBase())
                Environment.Exit(0);

            //Sprawdzenie czy masz uprawnienia do korzystania z programu
            if (Users.Singleton.Role == "Employee")
            {
                MessageBox.Show("You don't have permision to acces this tool. Please contact with administrator!", "No Access!");
                Environment.Exit(0);
            }

            //Inicjalizowanie programu
            InitializeComponent();
            //Inicjalizowanie danych
            this.Shown += new EventHandler(this.InitializeData);

            //Widocznoś Maina dla Wszystkich.
            Self = this;


            if (ApplicationDeployment.IsNetworkDeployed)
                toolStripStatusLabel1.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + " Beta Version";
            else
                toolStripStatusLabel1.Text = "0.5.0.32  Beta Version Portable Version";


            if (Environment.UserName.ToString() == "BartkKon")
                toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + "      " + Data_Import.Singleton().CheckLink();
            //}
            //catch (Exception ex)
            //{
            //    LogSingleton.Instance.SaveLog(ex.Message);
            //}
        }

        private void InitializeData(object sender, EventArgs e)
        {
            //
            //  ActionTab
            //
            if (Users.Singleton.ActionTab)
            {
                treeActionView.InitializeData();
                mainFilter.InitializeData();
                actionView.stateView.InitializeData();
                actionView.SavingsTable.InitializeData();
                _ = new ClearForm();
                _ = new ActionVerificationEnabled(false);
            }
            else
                TabControl.TabPages.Remove(tab_Action);

            //
            //  Summary Tab
            //
            if (Users.Singleton.SummaryTab)
            {
                sdOptions1.InitiazlizeData();
                sdOptions2.InitiazlizeData();
                sdTableAllView.InitializeData();
                sdReporting1.InitializeData();
                SDSumAllAction.InitializeData();
            }
            else
            {
                TabControl.TabPages.Remove(tab_Summary);
                TabControl.TabPages.Remove(tab_SummaryS);
            }

            //
            //  StatisticTab
            //
            if (Users.Singleton.StatisticTab)
            {
                optionView.SetYear(DateTime.UtcNow.Year);
                dmView.InitializeData();
                productionQuantityView.InitializeData();
                productionQuantityMonthView1.InitializeData();
            }
            else
            {
                TabControl.TabPages.Remove(tab_Statistic);
            }

            //
            //  AdminTab
            //
            if (Users.Singleton.AdminTab)
            {

            }
            else
            {
                TabControl.TabPages.Remove(tab_Admin);
                TabControl.TabPages.Remove(tab_AdminAction);
            }

            //
            //  PlatformTab
            //
            if (Users.Singleton.PlatformTab)
            {

            }
            else
            {
                TabControl.TabPages.Remove(tab_Platform);
            }

            //
            //  STK Tab
            //
            if (Users.Singleton.STKTab)
            {

            }
            else
            {
                TabControl.TabPages.Remove(tab_STK);
            }

            //
            //  QuantityTab
            //
            if (Users.Singleton.QuantityTab)
            {

            }
            else
            {
                TabControl.TabPages.Remove(tab_Quantity);
            }
        }
    }
}
