using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Access;
using Saving_Accelerator_Tool.Controllers.AdminTab;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    public partial class AddPersonView : UserControl
    {
        public AddPersonView()
        {
            InitializeComponent();
        }

        public void SetAllLogin(string User)
        {
            comBox_AdminAccess.Items.Add(User);
        }

        public void ClearAllLogin()
        {
            comBox_AdminAccess.Items.Clear();
        }

        public string GetUserName()
        {
            return TB_Admin_NewAccount.Text;
        }

        public string GetFullName()
        {
            return Tb_AdminAccessFullName.Text;
        }

        public void SetFullName(string FullName)
        {
            if (FullName != null)
                Tb_AdminAccessFullName.Text = FullName;
        }

        public string GetMail()
        {
            return Tb_AdminAccess_Email.Text;
        }

        public void SetMail(string Mail)
        {
            if (Mail != null)
                Tb_AdminAccess_Email.Text = Mail;
        }

        public string GetRole()
        {
            return Cb_AdminAccessMenager.Text;
        }

        public void SetRole(string Role)
        {
            if (Role == "Employee" || Role == null)
            {
                Cb_AdminAccessMenager.SelectedIndex = 0;
            }
            else if (Role == "Electronic")
            {
                Cb_AdminAccessMenager.SelectedIndex = 1;
            }
            else if (Role == "Mechanic")
            {
                Cb_AdminAccessMenager.SelectedIndex = 2;
            }
            else if (Role == "NVR")
            {
                Cb_AdminAccessMenager.SelectedIndex = 3;
            }
            else if (Role == "PC")
            {
                Cb_AdminAccessMenager.SelectedIndex = 4;
            }
            else if (Role == "Admin")
            {
                Cb_AdminAccessMenager.SelectedIndex = 5;
            }
        }

        public string GetViewer()
        {
            if(radbut_AdminDevelop.Checked)
            {
                return "Developer";
            }
            else if(radbut_AdminViwer.Checked)
            {
                return "Viwer";
            }

            return string.Empty;
        }

        public void SetViwer(string Viwer)
        {
            if(Viwer == "Developer")
            {
                radbut_AdminDevelop.Checked = true;
                radbut_AdminViwer.Checked = false;
            }
            else if(Viwer == "Viwer")
            {
                radbut_AdminDevelop.Checked = false;
                radbut_AdminViwer.Checked = true;
            }
            else
            {
                radbut_AdminDevelop.Checked = false;
                radbut_AdminViwer.Checked = false;
            }
        }

        public bool GetActionTab()
        {
            return cb_AdminTabAction.Checked;
        }

        public void SetActionTab(bool ActionTab)
        {
            cb_AdminTabAction.Checked = ActionTab;
        }

        public bool GetActionEle()
        {
            return cb_AdminElectronic.Checked;
        }

        public void SetActionEle(bool ActionEle)
        {
            cb_AdminElectronic.Checked = ActionEle;
        }

        public bool GetActionMech()
        {
            return cb_AdminMechanic.Checked;
        }

        public void SetActionMech(bool ActionMech)
        {
            cb_AdminMechanic.Checked = ActionMech;
        }

        public bool GetActionNVR()
        {
            return cb_AdminNVR.Checked;
        }

        public void SetActionNVR(bool ActionNVR)
        {
            cb_AdminNVR.Checked = ActionNVR;
        }

        public bool GetSummaryTab()
        {
            return cb_AdminTabSummary.Checked;
        }

        public void SetSummaryTab(bool SummaryTab)
        {
            cb_AdminTabSummary.Checked = SummaryTab;
        }

        public bool GetStatisticTab()
        {
            return cb_AdminTabStatistic.Checked;
        }

        public void SetStatisticTab(bool StatisticTab)
        {
            cb_AdminTabStatistic.Checked = StatisticTab;
        }

        public bool GetPlatformTab()
        {
            return cb_AdminTabPlatform.Checked;
        }

        public void SetPlatformTab(bool PlatformTab)
        {
            cb_AdminTabPlatform.Checked = PlatformTab;
        }

        public bool GetSTKTab()
        {
            return cb_AdminTabSTK.Checked;
        }

        public void SetSTKTab(bool STKTab)
        {
            cb_AdminTabSTK.Checked = STKTab;
        }

        public bool GetQuantityTab()
        {
            return cb_AdminTabQuantity.Checked;
        }

        public void SetQuantityTab(bool QuantityTab)
        {
            cb_AdminTabQuantity.Checked = QuantityTab;
        }

        public bool GetAdminTab()
        {
            return cb_AdminTabAdmin.Checked;
        }

        public void SetAdminTab(bool AdminTab)
        {
            cb_AdminTabAdmin.Checked = AdminTab;
        }

        public bool GetReportElectronic()
        {
            return cb_Admin_RapEle.Checked;
        }

        public void SetReportElectroic(bool Electronic)
        {
            cb_Admin_RapEle.Checked = Electronic;
        }

        public bool GetReportMechanic()
        {
            return cb_Admin_RapMech.Checked;
        }

        public void SetReportMechanic(bool Mechanic)
        {
            cb_Admin_RapMech.Checked = Mechanic;
        }

        public bool GetReportNVR()
        {
            return cb_Admin_RapNVR.Checked;
        }

        public void SetReportNVR(bool NVR)
        {
            cb_Admin_RapNVR.Checked = NVR;
        }

        public bool GetReportPC()
        {
            return cb_Admin_RapPC.Checked;
        }

        public void SetReportPC(bool PC)
        {
            cb_Admin_RapPC.Checked = PC;
        }

        private void Pb_Admin_AccessRefresh_Click(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            AddPersonController.Refresh();
            Cursor.Current = Cursors.Default;
        }

        private void Combox_AdminAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Tb_AdminAccessFullName.Text = "";
            Tb_AdminAccess_Email.Text = "";
            Cb_AdminAccessMenager.SelectedIndex = -1;
            AddPersonController.PersonLoad((sender as ComboBox).Text);
            Cursor.Current = Cursors.Default;
        }

        private void Pb_Admin_AccessSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new SaveAccess(comBox_AdminAccess.Text);
            Cursor.Current = Cursors.Default;
        }

        private void Pb_Admin_AddNewAccount_Click(object sender, EventArgs e)
        {
            if (TB_Admin_NewAccount.Text != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                if (AddPersonController.AddUser())
                {
                    AddPersonController.Refresh();
                    MessageBox.Show("User has been added.");
                }
                else
                {
                    MessageBox.Show("User was not added, is some problem!");
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void Pb_Admin_DeleteAccount_Click(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text != "")
            {
                Cursor.Current = Cursors.WaitCursor;
                if (AddPersonController.DeleteUser((sender as TextBox).Text))
                {
                    AddPersonController.Refresh();
                    MessageBox.Show("User has beed Removed.");
                }
                else
                {
                    MessageBox.Show("User hasn't been removed, it's some problem!");
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void TB_Admin_NewAccount_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text.ToLower();
        }

        private void Tb_AdminAccess_Email_Leave(object sender, EventArgs e)
        {
            (sender as TextBox).Text = (sender as TextBox).Text + "@electrolux.com";
        }
    }
}
