using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Controllers.AdminTableTab;
using Saving_Accelerator_Tool.Controllers;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View.AdminTabTable.View
{
    public partial class ButtonLoadView : UserControl
    {
        public ButtonLoadView()
        {
            InitializeComponent();
        }

        private void But_Access_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            AdminTableController.LoadAccess();
            Cursor.Current = Cursors.Default;
        }

        private void But_Clear_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            MainProgram.Self.adminTableView.ReturnDataGridView().DataSource = null;
            Cursor.Current = Cursors.Default;
        }

        private void But_ANCMonthly_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var Option = MainProgram.Self.adminTableView.optionsView;
            var Table = MainProgram.Self.adminTableView.ReturnDataGridView();

            if (Option.GetMonth() != 0)
            {
                Table.DataSource = ANCMonthlyQuantity.LoadByYear_Month(Convert.ToInt32(Option.GetYear()), Convert.ToInt32(Option.GetMonth()));
            }
            else
            {
                Table.DataSource = ANCMonthlyQuantity.LoadByYear(Convert.ToInt32(Option.GetYear()));
            }

            Cursor.Current = Cursors.Default;
        }

        private void But_OptionANCRevision_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var Option = MainProgram.Self.adminTableView.optionsView;
            var Table = MainProgram.Self.adminTableView.ReturnDataGridView();

            if (Option.GetMonth() != 0 && Option.GetRevision() != "")
            {
                Table.DataSource = ANCRevisionQuantity.LoadByYear_Month_Revision(
                    Convert.ToInt32(Option.GetYear()),
                    Convert.ToInt32(Option.GetMonth()),
                    Option.GetRevision()
                    );
            }
            else if (Option.GetMonth() != 0)
            {
                Table.DataSource = ANCRevisionQuantity.LoadByYear_Month(
                    Convert.ToInt32(Option.GetYear()),
                    Convert.ToInt32(Option.GetMonth())
                    );
            }
            else if (Option.GetRevision() != "")
            {
                Table.DataSource = ANCRevisionQuantity.LoadByYear_Revision(
                    Convert.ToInt32(Option.GetYear()),
                    Option.GetRevision()
                    );
            }
            else
            {
                Table.DataSource = ANCRevisionQuantity.LoadByYear(
                    Convert.ToInt32(Option.GetYear()));
            }

            Cursor.Current = Cursors.Default;
        }

        private void But_STK_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var Option = MainProgram.Self.adminTableView.optionsView;
            var Table = MainProgram.Self.adminTableView.ReturnDataGridView();

            Table.DataSource = STKController.Load_By_Year(Convert.ToInt32(Option.GetYear()));

            Cursor.Current = Cursors.Default;
        }

        private void But_PNCMonthly_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var Option = MainProgram.Self.adminTableView.optionsView;
            var Table = MainProgram.Self.adminTableView.ReturnDataGridView();

            if (Option.GetMonth() != 0)
            {
                Table.DataSource = PNCMonthlyQuantity.LoadByYear_Month(Convert.ToInt32(Option.GetYear()), Convert.ToInt32(Option.GetMonth()));
            }
            else
            {
                Table.DataSource = PNCMonthlyQuantity.LoadByYear(Convert.ToInt32(Option.GetYear()));
            }

            Cursor.Current = Cursors.Default;
        }

        private void But_PNCRevision_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            var Option = MainProgram.Self.adminTableView.optionsView;
            var Table = MainProgram.Self.adminTableView.ReturnDataGridView();

            if (Option.GetMonth() != 0 && Option.GetRevision() != "")
            {
                Table.DataSource = PNCRevisionQuantity.LoadByYear_Month_Revision(
                    Convert.ToInt32(Option.GetYear()),
                    Convert.ToInt32(Option.GetMonth()),
                    Option.GetRevision()
                    );
            }
            else if (Option.GetMonth() != 0)
            {
                Table.DataSource = PNCRevisionQuantity.LoadByYear_Month(
                    Convert.ToInt32(Option.GetYear()),
                    Convert.ToInt32(Option.GetMonth())
                    );
            }
            else if (Option.GetRevision() != "")
            {
                Table.DataSource = PNCRevisionQuantity.LoadByYear_Revision(
                    Convert.ToInt32(Option.GetYear()),
                    Option.GetRevision()
                    );
            }
            else
            {
                Table.DataSource = PNCRevisionQuantity.LoadByYear(
                    Convert.ToInt32(Option.GetYear()));
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
