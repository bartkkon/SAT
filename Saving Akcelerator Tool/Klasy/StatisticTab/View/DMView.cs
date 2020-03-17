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
    public partial class DMView : UserControl
    {
        public DMView()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            cb_Statistic_ExchangeRate.SelectedIndexChanged -= Cb_Statistic_ExchangeRate_SelectedIndexChanged;
            cb_Statistic_ExchangeRate.SelectedIndex = 0;
            cb_Statistic_ExchangeRate.SelectedIndexChanged += Cb_Statistic_ExchangeRate_SelectedIndexChanged;

            PreapreTable();
        }

        public DataGridView ObjectTable()
        {
            return dgv_StatisticDM;
        }

        public void ClearDataGridView()
        {
            foreach (DataGridViewRow Row in dgv_StatisticDM.Rows)
            {
                foreach (DataGridViewColumn Column in dgv_StatisticDM.Columns)
                {
                    Row.Cells[Column.Name].Value = null;
                    Row.Cells[Column.Name].Style.ForeColor = Color.FromArgb(0, 0, 0);
                    Row.Cells[Column.Name].Style.BackColor = Color.FromArgb(255, 255, 255);
                }
            }

            dgv_StatisticDM.Rows[0].Cells["BU"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[0].Cells["EA1"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[0].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[0].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[1].Cells["EA1"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[1].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[1].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[2].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[2].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[3].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
        }

        public int GetExchangeRateIndex()
        {
            return cb_Statistic_ExchangeRate.SelectedIndex;
        }

        public string GetExchangeRate()
        {
            return cb_Statistic_ExchangeRate.SelectedItem.ToString();
        }

        private void PreapreTable()
        {
            dgv_StatisticDM.Columns["DM"].DefaultCellStyle.Font = new Font(dgv_StatisticDM.Font,FontStyle.Bold);
            dgv_StatisticDM.Rows.Add(5);
            dgv_StatisticDM.Rows[0].HeaderCell.Value = "BU";
            dgv_StatisticDM.Rows[1].HeaderCell.Value = "EA1";
            dgv_StatisticDM.Rows[2].HeaderCell.Value = "EA2";
            dgv_StatisticDM.Rows[3].HeaderCell.Value = "EA3";
            dgv_StatisticDM.Rows[4].HeaderCell.Value = "EA4";
            dgv_StatisticDM.Rows[0].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticDM.Rows[1].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticDM.Rows[2].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticDM.Rows[3].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticDM.Rows[4].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticDM.Rows[0].Cells["BU"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[0].Cells["EA1"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[0].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[0].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[1].Cells["EA1"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[1].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[1].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[2].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[2].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticDM.Rows[3].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);

            dgv_StatisticDM.CurrentCell = dgv_StatisticDM[0, 0];
            dgv_StatisticDM.ClearSelection();
        }

        private void Cb_Statistic_ExchangeRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new StatisticDMLoad(dgv_StatisticDM, cb_Statistic_ExchangeRate.SelectedItem.ToString());
            Cursor.Current = Cursors.Default;
        }


    }
}
