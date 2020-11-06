using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    public partial class QuantityMonthAddView : UserControl
    {
        public QuantityMonthAddView()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            if (DateTime.UtcNow.Month == 1)
            {
                num_Admin_QuantityMonth.Value = 12;
                num_Admin_YearMonth.Value = DateTime.UtcNow.Year;
            }
            else
            {
                num_Admin_QuantityMonth.Value = DateTime.UtcNow.Month - 1;
                num_Admin_YearMonth.Value = DateTime.UtcNow.Year;
            }
        }

        private void Pb_Admin_SaveQuantityMonth_Click(object sender, EventArgs e)
        {
            if (cb_AdminANCMonth.Checked)
            {
                Form AddData = new AddData("Proszę podać liste ANC dla " + num_Admin_QuantityMonth.Value.ToString() + "/" + num_Admin_YearMonth.Value.ToString(), num_Admin_YearMonth.Value, num_Admin_QuantityMonth.Value, "AddMonthANC");
                AddData.Show();
            }
            else if (cb_AdminPNCMonth.Checked)
            {
                Form AddData = new AddData("Proszę podać liste PNC dla " + num_Admin_QuantityMonth.Value.ToString() + "/" + num_Admin_YearMonth.Value.ToString(), num_Admin_YearMonth.Value, num_Admin_QuantityMonth.Value, "AddMonthPNC");
                AddData.Show();
            }
            else
            {
                MessageBox.Show("Wybierz jakie dane chcesz dodać");
            }
        }

        private void Cb_AdminMonth_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Text == "PNC")
            {
                cb_AdminANCMonth.CheckedChanged -= Cb_AdminMonth_CheckedChanged;
                cb_AdminANCMonth.Checked = false;
                cb_AdminANCMonth.CheckedChanged += Cb_AdminMonth_CheckedChanged;
            }
            else
            {
                cb_AdminPNCMonth.CheckedChanged -= Cb_AdminMonth_CheckedChanged;
                cb_AdminPNCMonth.Checked = false;
                cb_AdminPNCMonth.CheckedChanged += Cb_AdminMonth_CheckedChanged;
            }
        }

        private void Pb_Admin_SaveCalcMonthNew_Click(object sender, EventArgs e)
        {
            DialogResult Results = MessageBox.Show("Czy chcesz przeliczyć Akcje za " + num_Admin_QuantityMonth.Value.ToString() + " miesiąc?", "ATENTION", MessageBoxButtons.YesNo);

            if (Results == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                _ = new CalculationMass(Convert.ToInt32(num_Admin_QuantityMonth.Value), num_Admin_YearMonth.Value);
                Cursor.Current = Cursors.Default;
            }
        }
    }
}
