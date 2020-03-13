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
        private readonly Data_Import data_Import;
        private readonly BuildForm buildForm = new BuildForm();
        private readonly Action action;
        private readonly DataTable  Access = new DataTable();
        private readonly SummaryDetails summaryDetails;
        private readonly Admin admin;
        public static MainProgram Self;


        public MainProgram()
        {
            try
            {
                data_Import = Data_Import.Singleton();

                if(!data_Import.CheckConnectionToDataBase())
                {
                    Environment.Exit(0);
                }

                //Widocznoś Maina dla Wszystkich.
                Self = this;

                //Pobranie danych z bazy dla dostępów osób logujących się do programy
                Access = data_Import.Load_Access();
                //Tworzenie Użytkowanika
                CreateUsers NewUsers = new CreateUsers(Access);
                //Inicjalizowanie programu
                InitializeComponent();
                action = new Action(this, data_Import);
                admin = new Admin();
                summaryDetails = new SummaryDetails();

                //Budowanie Formsa w zależności od uprawnień
                buildForm.Tab_Control_Add(Access, this, action, summaryDetails, admin, data_Import);

                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    toolStripStatusLabel1.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + " Beta Version";
                }
                else
                {
                    toolStripStatusLabel1.Text = "0.5.0.33  Beta Portable Version";
                }

                if (Environment.UserName.ToString() == "BartkKon")
                {
                    string Link = data_Import.CheckLink();
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
