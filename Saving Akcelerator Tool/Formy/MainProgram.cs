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
        

        public MainProgram()
        {
            try
            {
                string Link = @"\\PLWS4031\Project\CAD\Work\bartkkon\EC_Accelerator_Data\Links.txt";
                //string Link = @"C:\Moje\EC_Accelerator_Data\Links.txt";
                if (!File.Exists(Link))
                {
                    MessageBox.Show("Brak dostępu do bazy danych. Proszę uruchomić dyski sieciowe lub połączyć się z siecią lub skontaktować się z Adminem.");
                    Environment.Exit(0);
                }
                data_Import = new Data_Import(Link);
                Access = data_Import.Load_Access("Access");
                InitializeComponent();
                action = new Action(this, data_Import);
                admin = new Admin(this, data_Import);
                summaryDetails = new SummaryDetails(this, data_Import);
                buildForm.Tab_Control_Add(Access, this, action, summaryDetails, admin, data_Import);

                if (ApplicationDeployment.IsNetworkDeployed)
                {
                    toolStripStatusLabel1.Text = ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() + " Beta Version";
                }
            }
            catch(Exception ex)
            {
                LogSingleton.Instance.SaveLog(ex.Message);
            }
        }

        private void MainProgram_Load(object sender, EventArgs e)
        {

        }
    }
}
