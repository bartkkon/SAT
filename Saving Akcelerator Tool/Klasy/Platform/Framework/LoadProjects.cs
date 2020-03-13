using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform.Framework
{
    public class LoadProjects
    {
        private readonly ComboBox _project;
        private readonly NumericUpDown _year;
        public LoadProjects()
        {
            _project = (ComboBox)MainProgram.Self.TabControl.Controls.Find("combo_Project", true).First();
            _year = (NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Platform_YearOption", true).First();


            RemoveAllObject();
            //LoadComboBox();
        }

        private void LoadComboBox()
        {
            DataTable ProjectList = new DataTable();
            DataRow[] ProjectYear;

            Data_Import.Singleton().Load_TxtToDataTable2(ref ProjectList, "PlatformList");

            ProjectYear = ProjectList.Select(string.Format("StartYear LIKE '%{0}%'", _year.Value.ToString())).ToArray();

            if (ProjectYear != null)
            {
                foreach (DataRow Row in ProjectYear)
                {
                    _project.Items.Add(Row["Project"].ToString());
                }
            }
        }

        private void RemoveAllObject()
        {
            _project.Items.Clear();
            _project.ResetText();
        }
    }
}
