using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.StatisticTab.Framework;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab.View
{
    public partial class ProductionQuantityMonthView : UserControl
    {
        public ProductionQuantityMonthView()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            comb_StatisticQuantityMonthInstallation.SelectedIndexChanged -= Comb_StatisticQuantityMonthInstallation_SelectedIndexChanged;
            comb_StatisticQuantityMonthRev.SelectedIndexChanged -= Comb_StatisticQuantityMonthRev_SelectedIndexChanged;
            comb_StatisticQuantityMonthStructure.SelectedIndexChanged -= Comb_StatisticQuantityMonthStructure_SelectedIndexChanged;

            comb_StatisticQuantityMonthInstallation.SelectedIndex = 0;
            comb_StatisticQuantityMonthRev.SelectedIndex = 0;
            comb_StatisticQuantityMonthStructure.SelectedIndex = 0;
            PrepareTable();

            comb_StatisticQuantityMonthInstallation.SelectedIndexChanged += Comb_StatisticQuantityMonthInstallation_SelectedIndexChanged;
            comb_StatisticQuantityMonthRev.SelectedIndexChanged += Comb_StatisticQuantityMonthRev_SelectedIndexChanged;
            comb_StatisticQuantityMonthStructure.SelectedIndexChanged += Comb_StatisticQuantityMonthStructure_SelectedIndexChanged;
        }

        public string GetRevision()
        {
            return comb_StatisticQuantityMonthRev.SelectedItem.ToString();
        }

        public string GetStructure()
        {
            return comb_StatisticQuantityMonthStructure.SelectedItem.ToString();
        }

        public string GetInstallation()
        {
            return comb_StatisticQuantityMonthInstallation.SelectedItem.ToString();
        }

        public DataGridView ObjectTable()
        {
            return dgv_StatisticQuantityMonth;
        }

        public void ClearDataGridView()
        {
            foreach(DataGridViewRow Row in dgv_StatisticQuantityMonth.Rows)
            {
                foreach(DataGridViewColumn Column in dgv_StatisticQuantityMonth.Columns)
                {
                    Row.Cells[Column.Name].Value = null;
                }
            }
        }

        private void PrepareTable()
        {
            dgv_StatisticQuantityMonth.Columns.Add("1", "I");
            dgv_StatisticQuantityMonth.Columns.Add("2", "II");
            dgv_StatisticQuantityMonth.Columns.Add("3", "III");
            dgv_StatisticQuantityMonth.Columns.Add("4", "IV");
            dgv_StatisticQuantityMonth.Columns.Add("5", "V");
            dgv_StatisticQuantityMonth.Columns.Add("6", "VI");
            dgv_StatisticQuantityMonth.Columns.Add("7", "VII");
            dgv_StatisticQuantityMonth.Columns.Add("8", "VIII");
            dgv_StatisticQuantityMonth.Columns.Add("9", "IX");
            dgv_StatisticQuantityMonth.Columns.Add("10", "X");
            dgv_StatisticQuantityMonth.Columns.Add("11", "XI");
            dgv_StatisticQuantityMonth.Columns.Add("12", "XII");
            dgv_StatisticQuantityMonth.Columns.Add("Sum", "SUM");

            foreach (DataGridViewColumn Column in dgv_StatisticQuantityMonth.Columns)
            {
                Column.Width = 72;
                Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dgv_StatisticQuantityMonth.RowHeadersWidth = 87;
            dgv_StatisticQuantityMonth.Rows.Add(3);
            dgv_StatisticQuantityMonth.Rows[0].HeaderCell.Value = "Actual:";
            dgv_StatisticQuantityMonth.Rows[1].HeaderCell.Value = "Plan:";
            dgv_StatisticQuantityMonth.Rows[2].HeaderCell.Value = "Different:";
            dgv_StatisticQuantityMonth.Rows[0].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticQuantityMonth.Rows[1].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticQuantityMonth.Rows[2].DefaultCellStyle.Format = "#,0.###";

            dgv_StatisticQuantityMonth.CurrentCell = dgv_StatisticQuantityMonth[0, 0];
            dgv_StatisticQuantityMonth.ClearSelection();
        }

        private void Comb_StatisticQuantityMonthRev_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new StatisticQuantityMonthLoad(dgv_StatisticQuantityMonth);
            Cursor.Current = Cursors.Default;
        }

        private void Comb_StatisticQuantityMonthStructure_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new StatisticQuantityMonthLoad(dgv_StatisticQuantityMonth);
            Cursor.Current = Cursors.Default;
        }

        private void Comb_StatisticQuantityMonthInstallation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new StatisticQuantityMonthLoad(dgv_StatisticQuantityMonth);
            Cursor.Current = Cursors.Default;
        }
    }
}
