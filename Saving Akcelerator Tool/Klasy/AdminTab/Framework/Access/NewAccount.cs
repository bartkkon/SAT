using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Access
{
    public class NewAccount
    {
        public NewAccount(TextBox BIZ)
        {
            DataTable Access = new DataTable();
            DataRow NewAccount;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Access, "Access");

            NewAccount = Access.NewRow();

            NewAccount["Name"] = BIZ.Text;
            NewAccount["FullName"] = "";
            NewAccount["Mail"] = "";
            NewAccount["Role"] = "Employee";
            NewAccount["tab_Action"] = "false";
            NewAccount["Action"] = "false";
            NewAccount["ActionEle"] = "false";
            NewAccount["ActionMech"] = "false";
            NewAccount["ActionNVR"] = "false";
            NewAccount["tab_Summary"] = "false";
            NewAccount["tab_STK"] = "false";
            NewAccount["tab_Quantity"] = "false";
            NewAccount["tab_Admin"] = "false";
            NewAccount["EleApprove"] = "false";
            NewAccount["MechApprove"] = "false";
            NewAccount["NVRApprove"] = "false";
            NewAccount["PCApprove"] = "false";

            Access.Rows.Add(NewAccount);

            Data_Import.Singleton().Save_DataTableToTXT2(ref Access, "Access");
        }
    }
}
