using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Access
{
    public class DeleteAccount
    {
        public DeleteAccount(TextBox BIZ)
        {
            DataTable Account = new DataTable();
            DataRow FoundRow;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Account, "Access");

            FoundRow = Account.Select(string.Format("Name LIKE '%{0}%'", BIZ.Text)).FirstOrDefault();
            if (FoundRow != null)
            {
                Account.Rows.Remove(FoundRow);
            }

            Data_Import.Singleton().Save_DataTableToTXT(ref Account, "Access");
        }
    }
}
