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
        Data_Import data_Import;
        BuildForm buildForm = new BuildForm();
        Action action;
        DataTable Access = new DataTable();
        SummaryDetails summaryDetails;
        Admin admin;
        public static MainProgram Self;

        //Wprowadzam zmny dla HotFixa

        public MainProgram()
        {
            try
            {
                data_Import = Data_Import.Singleton();

                if(!data_Import.CheckConnectionToDataBase())
                {
                    Environment.Exit(0);
                }

                //Pobranie danych z bazy dla dostępów osób logujących się do programy
                Access = data_Import.Load_Access("Access");
                //Tworzenie Użytkowanika
                CreateUsers NewUsers = new CreateUsers(Access);
                //Inicjalizowanie programu
                InitializeComponent();
                action = new Action(this, data_Import);
                admin = new Admin(this, data_Import);
                summaryDetails = new SummaryDetails(this, data_Import);

                //Budowanie Formsa w zależności od uprawnień
                buildForm.Tab_Control_Add(Access, this, action, summaryDetails, admin, data_Import);

                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    toolStripStatusLabel1.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + " Beta Version";
                }
                else
                {
                    toolStripStatusLabel1.Text = "0.5.0.25  Beta Version Portable Version";
                }

                if (Environment.UserName.ToString() == "BartkKon")
                {
                    string Link = data_Import.CheckLink();
                    toolStripStatusLabel1.Text = toolStripStatusLabel1.Text + "      " + Link;
                }
                Self = this;

            }
            catch (Exception ex)
            {
                LogSingleton.Instance.SaveLog(ex.Message);
            }
        }

    }
}
