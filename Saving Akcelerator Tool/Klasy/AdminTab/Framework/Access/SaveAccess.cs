using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Access
{
    public class SaveAccess
    {
        public SaveAccess()
        {
            DataTable Access = new DataTable();
            DataRow FoundRow;

            ComboBox cb_comBox_AdminAccess = (ComboBox)MainProgram.Self.TabControl.Controls.Find("comBox_AdminAccess", true).First();

            Data_Import.Singleton().Load_TxtToDataTable2(ref Access, "Access");

            if (cb_comBox_AdminAccess.Text != "")
            {
                FoundRow = Access.Select(string.Format("Name LIKE '%{0}%'", cb_comBox_AdminAccess.Text)).FirstOrDefault();

                FoundRow["FullName"] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminAccessFullName", true).First()).Text;

                FoundRow["Mail"] = ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminAccess_Email", true).First()).Text;

                if (((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "Employee")
                    FoundRow["Role"] = "Employee";
                else if (((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "Electronic")
                    FoundRow["Role"] = "EleMenager";
                else if (((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "Mechanic")
                    FoundRow["Role"] = "MechMenager";
                else if (((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "NVR")
                    FoundRow["Role"] = "NVRMenager";
                else if (((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "PC")
                    FoundRow["Role"] = "PCMenager";
                else if (((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).Text == "Admin")
                    FoundRow["Role"] = "Admin";

                FoundRow["tab_Action"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabAction", true).First()).Checked.ToString().ToLower();

                if (((RadioButton)MainProgram.Self.TabControl.Controls.Find("radbut_AdminViwer", true).First()).Checked)
                    FoundRow["Action"] = "View";
                else if(((RadioButton)MainProgram.Self.TabControl.Controls.Find("radbut_AdminDevelop", true).First()).Checked)
                    FoundRow["Action"] = "Developer";

                FoundRow["ActionEle"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminElectronic", true).First()).Checked.ToString().ToLower();

                FoundRow["ActionMech"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminMechanic", true).First()).Checked.ToString().ToLower();

                FoundRow["ActionNVR"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminNVR", true).First()).Checked.ToString().ToLower();

                FoundRow["tab_Summary"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabSummary", true).First()).Checked.ToString().ToLower();

                FoundRow["tab_Statistic"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabStatistic", true).First()).Checked.ToString().ToLower();

                FoundRow["tab_Platform"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabPlatform", true).First()).Checked.ToString().ToLower();

                FoundRow["tab_STK"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabSTK", true).First()).Checked.ToString().ToLower();

                FoundRow["tab_Quantity"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabQuantity", true).First()).Checked.ToString().ToLower();

                FoundRow["tab_Admin"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabAdmin", true).First()).Checked.ToString().ToLower();

                FoundRow["EleApprove"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Admin_RapEle", true).First()).Checked.ToString().ToLower();

                FoundRow["MechApprove"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Admin_RapMech", true).First()).Checked.ToString().ToLower();

                FoundRow["NVRApprove"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Admin_RapNVR", true).First()).Checked.ToString().ToLower();

                FoundRow["PCApprove"] = ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Admin_RapPC", true).First()).Checked.ToString().ToLower();
            }
            else
            {
                return;
            }

            Data_Import.Singleton().Save_DataTableToTXT2(ref Access, "Access");
        }
    }
}
