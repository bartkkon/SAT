using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Access
{
    public class LoadPerson
    {
        public LoadPerson(ComboBox Person)
        {
            DataTable Access = new DataTable();
            DataRow FoundAccess;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Access, "Access");

            FoundAccess = Access.Select(string.Format("Name LIKE '%{0}%'", Person.Text)).FirstOrDefault();

            if (FoundAccess == null)
                return;

            ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminAccessFullName", true).First()).Text = FoundAccess["FullName"].ToString();
            ((TextBox)MainProgram.Self.TabControl.Controls.Find("Tb_AdminAccess_Email", true).First()).Text = FoundAccess["Mail"].ToString();

            if (FoundAccess["Role"].ToString() == "Employee")
            {
                ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 0;
            }
            else if (FoundAccess["Role"].ToString() == "EleMenager")
            {
                ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 1;
            }
            else if (FoundAccess["Role"].ToString() == "MechMenager")
            {
                ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 2;
            }
            else if (FoundAccess["Role"].ToString() == "NVRMenager")
            {
                ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 3;
            }
            else if (FoundAccess["Role"].ToString() == "PCMenager")
            {
                ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 4;
            }
            else if (FoundAccess["Role"].ToString() == "Admin")
            {
                ((ComboBox)MainProgram.Self.TabControl.Controls.Find("Cb_AdminAccessMenager", true).First()).SelectedIndex = 5;
            }

            if (FoundAccess["Action"].ToString() == "Developer")
            {
                ((RadioButton)MainProgram.Self.TabControl.Controls.Find("radbut_AdminViwer", true).First()).Checked = false;
                ((RadioButton)MainProgram.Self.TabControl.Controls.Find("radbut_AdminDevelop", true).First()).Checked = true;
            }
            else
            {
                ((RadioButton)MainProgram.Self.TabControl.Controls.Find("radbut_AdminViwer", true).First()).Checked = true;
                ((RadioButton)MainProgram.Self.TabControl.Controls.Find("radbut_AdminDevelop", true).First()).Checked = false;
            }

            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabAction", true).First()).Checked = Convert.ToBoolean(FoundAccess["tab_Action"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminElectronic", true).First()).Checked = Convert.ToBoolean(FoundAccess["ActionEle"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminMechanic", true).First()).Checked = Convert.ToBoolean(FoundAccess["ActionMech"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminNVR", true).First()).Checked = Convert.ToBoolean(FoundAccess["ActionNVR"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabSummary", true).First()).Checked = Convert.ToBoolean(FoundAccess["tab_Summary"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabStatistic", true).First()).Checked = Convert.ToBoolean(FoundAccess["tab_Statistic"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabPlatform", true).First()).Checked = Convert.ToBoolean(FoundAccess["tab_Platform"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabSTK", true).First()).Checked = Convert.ToBoolean(FoundAccess["tab_STK"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabQuantity", true).First()).Checked = Convert.ToBoolean(FoundAccess["tab_Quantity"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_AdminTabAdmin", true).First()).Checked = Convert.ToBoolean(FoundAccess["tab_Admin"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Admin_RapEle", true).First()).Checked = Convert.ToBoolean(FoundAccess["EleApprove"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Admin_RapMech", true).First()).Checked = Convert.ToBoolean(FoundAccess["MechApprove"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Admin_RapNVR", true).First()).Checked = Convert.ToBoolean(FoundAccess["NVRApprove"].ToString());
            ((CheckBox)MainProgram.Self.TabControl.Controls.Find("cb_Admin_RapPC", true).First()).Checked = Convert.ToBoolean(FoundAccess["PCApprove"].ToString());
        }
    }
}
