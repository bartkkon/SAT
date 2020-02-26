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

        public int GetExchangeRateIndex()
        {
            return cb_Statistic_ExchangeRate.SelectedIndex;
        }

        private void PreapreTable()
        {
            dgv_StatisticDM.Columns.Add("DM", "DM");
            dgv_StatisticDM.Columns["DM"].Width = 90;
            dgv_StatisticDM.Columns.Add("BU", "BU");
            dgv_StatisticDM.Columns["BU"].Width = 80;
            dgv_StatisticDM.Columns.Add("EA1", "EA1");
            dgv_StatisticDM.Columns["EA1"].Width = 80;
            dgv_StatisticDM.Columns.Add("EA2", "EA2");
            dgv_StatisticDM.Columns["EA2"].Width = 80;
            dgv_StatisticDM.Columns.Add("EA3", "EA3");
            dgv_StatisticDM.Columns["EA3"].Width = 80;
            dgv_StatisticDM.Columns["DM"].DefaultCellStyle.Font = new Font(dgv_StatisticDM.Font, FontStyle.Bold);
            dgv_StatisticDM.Rows.Add(5);
            dgv_StatisticDM.RowHeadersWidth = 58;
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
            _ = new StatisticDMLoad(dgv_StatisticDM);
            Cursor.Current = Cursors.Default;
        }
    }
}
