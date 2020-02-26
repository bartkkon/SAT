using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab.View
{
    public partial class ProductionQuantityView : UserControl
    {
        public ProductionQuantityView()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            PrepareTable();
        }

        public DataGridView ObjectTable()
        {
            return dgv_StatisticQuantity;
        }

        private void PrepareTable()
        {
            dgv_StatisticQuantity.Columns.Add("Q", "Quantity");
            dgv_StatisticQuantity.Columns["Q"].Width = 80;
            dgv_StatisticQuantity.Columns.Add("BU", "BU");
            dgv_StatisticQuantity.Columns["BU"].Width = 80;
            dgv_StatisticQuantity.Columns.Add("EA1", "EA1");
            dgv_StatisticQuantity.Columns["EA1"].Width = 80;
            dgv_StatisticQuantity.Columns.Add("EA2", "EA2");
            dgv_StatisticQuantity.Columns["EA2"].Width = 80;
            dgv_StatisticQuantity.Columns.Add("EA3", "EA3");
            dgv_StatisticQuantity.Columns["EA3"].Width = 80;
            dgv_StatisticQuantity.Columns["Q"].DefaultCellStyle.Font = new Font(dgv_StatisticQuantity.Font, FontStyle.Bold);
            dgv_StatisticQuantity.Rows.Add(5);
            dgv_StatisticQuantity.RowHeadersWidth = 68;
            dgv_StatisticQuantity.Rows[0].HeaderCell.Value = "BU";
            dgv_StatisticQuantity.Rows[1].HeaderCell.Value = "EA1";
            dgv_StatisticQuantity.Rows[2].HeaderCell.Value = "EA2";
            dgv_StatisticQuantity.Rows[3].HeaderCell.Value = "EA3";
            dgv_StatisticQuantity.Rows[4].HeaderCell.Value = "Actual";
            dgv_StatisticQuantity.Rows[0].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticQuantity.Rows[1].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticQuantity.Rows[2].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticQuantity.Rows[3].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticQuantity.Rows[4].DefaultCellStyle.Format = "#,0.###";
            dgv_StatisticQuantity.Rows[0].Cells["BU"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticQuantity.Rows[0].Cells["EA1"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticQuantity.Rows[0].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticQuantity.Rows[0].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticQuantity.Rows[1].Cells["EA1"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticQuantity.Rows[1].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticQuantity.Rows[1].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticQuantity.Rows[2].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticQuantity.Rows[2].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dgv_StatisticQuantity.Rows[3].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);

            dgv_StatisticQuantity.CurrentCell = dgv_StatisticQuantity[0, 0];
            dgv_StatisticQuantity.ClearSelection();
        }
    }
}
