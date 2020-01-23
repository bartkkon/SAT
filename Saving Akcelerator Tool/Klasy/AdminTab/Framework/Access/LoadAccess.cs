using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Access
{
    public class LoadAccess
    {
        public LoadAccess(ComboBox AllPerson)
        {
            DataTable Access = new DataTable();

            Data_Import.Singleton().Load_TxtToDataTable2(ref Access, "Access");

            AllPerson.Items.Clear();
            AllPerson.Text = "";

            foreach(DataRow Row in Access.Rows)
            {
                AllPerson.Items.Add(Row["Name"]);
            }
        }
    }
}
