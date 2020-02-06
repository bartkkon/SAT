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

namespace Saving_Accelerator_Tool
{
    public partial class MainProgram : Form
    {
        private readonly Action action;
        private readonly SummaryDetails summaryDetails;
        public static MainProgram Self;


        public MainProgram()
        {
            try
            {
                if(!Data_Import.Singleton().CheckConnectionToDataBase())
                {
                    Environment.Exit(0);
                }

                //Widocznoś Maina dla Wszystkich.
                Self = this;

                //Tworzenie Użytkowanika
                _ = new CreateUsers(Data_Import.Singleton().Load_Access());
                if(Users.Singleton().Role == "Employee")
                {
                    MessageBox.Show("You don't have permision to acces this tool. Please contact with administrator!", "No Access!");
                    Environment.Exit(0);
                }
                //Inicjalizowanie programu
                InitializeComponent();

                action = new Action(this, Data_Import.Singleton());
                summaryDetails = new SummaryDetails();

                //Budowanie Formsa w zależności od uprawnień
                _ = new BuildForm(action, summaryDetails);

                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    toolStripStatusLabel1.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + " Beta Version";
                }
                else
                {
                    toolStripStatusLabel1.Text = "0.5.0.32  Beta Version Portable Version";
                }

                if (Environment.UserName.ToString() == "BartkKon")
                {
                    string Link = Data_Import.Singleton().CheckLink();
                    toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + "      " + Link;
                }
                

            }
            catch (Exception ex)
            {
                LogSingleton.Instance.SaveLog(ex.Message);
            }
        }

    }
}
