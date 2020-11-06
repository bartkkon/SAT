using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.AdminTab.View.AdminTabTable.Firmwork;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View.AdminTabTable.View
{
    public partial class OptionsView : UserControl
    {
        public OptionsView()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            num_Year.Value = DateTime.UtcNow.Year;
            num_OptionMonth.Value = DateTime.UtcNow.Month;
        }

        public decimal GetYear()
        {
            return num_Year.Value;
        }

        public decimal GetMonth()
        {
            return num_OptionMonth.Value;
        }

        public string GetRevision()
        {
            if (comb_Revision.SelectedItem == null)
                return "";

            return comb_Revision.SelectedItem.ToString();
        }

        private void But_SaveData_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new SaveDataDisplay(MainProgram.Self.adminTableView.ReturnDataGridView());
            Cursor.Current = Cursors.Default;
        }
    }
}
