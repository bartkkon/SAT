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

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    public partial class AddPersonView : UserControl
    {
        public AddPersonView()
        {
            InitializeComponent();
        }

        private void Pb_Admin_AccessRefresh_Click(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new LoadAccess(comBox_AdminAccess);
            Cursor.Current = Cursors.Default;
        }

        private void Combox_AdminAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new LoadPerson(comBox_AdminAccess);
            Cursor.Current = Cursors.Default;
        }

        private void Pb_Admin_AccessSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new SaveAccess();
            Cursor.Current = Cursors.Default;
        }

        private void Pb_Admin_AddNewAccount_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new NewAccount(TB_Admin_NewAccount);
            _ = new LoadAccess(comBox_AdminAccess);
            Cursor.Current = Cursors.Default;
        }

        private void Pb_Admin_DeleteAccount_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new DeleteAccount(TB_Admin_NewAccount);
            _ = new LoadAccess(comBox_AdminAccess);
            Cursor.Current = Cursors.Default;
        }
    }
}
