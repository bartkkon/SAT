using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab.View
{
    class StatisticQuantityView
    {
        private TabPage _StatisticTab;
        private GroupBox _DMGroupBox;
        public StatisticQuantityView(TabPage StatisticTab)
        {
            _StatisticTab = StatisticTab;

            GroupBoxCreate();
            DMTables();
        }

        private void GroupBoxCreate()
        {
            GroupBox gb_Qunatity = new GroupBox
            {
                Location = new Point(760, 5),
                Size = new Size(490, 160),
                Text = "Production Quantity:",
                Name = "Gb_StatisticQuantity",
                TabStop = false,
            };
            _StatisticTab.Controls.Add(gb_Qunatity);
            _DMGroupBox = gb_Qunatity;
        }

        private void DMTables()
        {
            DataGridView QuantityTable = new DataGridView
            {
                Location = new Point(10, 15),
                Size = new Size(470, 135),
                Name = "DGV_StatisticQuantity",
                ReadOnly = true,
                AllowUserToAddRows = false,
                Enabled = false,
            };
            _DMGroupBox.Controls.Add(QuantityTable);
            GeneretedColumnForDMTable(QuantityTable);
        }

        private void GeneretedColumnForDMTable(DataGridView dMTable)
        {
            dMTable.Columns.Add("Q", "Quantity");
            dMTable.Columns["Q"].Width = 80;
            dMTable.Columns.Add("BU", "BU");
            dMTable.Columns["BU"].Width = 80;
            dMTable.Columns.Add("EA1", "EA1");
            dMTable.Columns["EA1"].Width = 80;
            dMTable.Columns.Add("EA2", "EA2");
            dMTable.Columns["EA2"].Width = 80;
            dMTable.Columns.Add("EA3", "EA3");
            dMTable.Columns["EA3"].Width = 80;
            dMTable.Columns["Q"].DefaultCellStyle.Font = new Font(dMTable.Font, FontStyle.Bold);
            dMTable.Rows.Add(5);
            dMTable.RowHeadersWidth = 68;
            dMTable.Rows[0].HeaderCell.Value = "BU";
            dMTable.Rows[1].HeaderCell.Value = "EA1";
            dMTable.Rows[2].HeaderCell.Value = "EA2";
            dMTable.Rows[3].HeaderCell.Value = "EA3";
            dMTable.Rows[4].HeaderCell.Value = "Actual";
            dMTable.Rows[0].DefaultCellStyle.Format = "#,0.###";
            dMTable.Rows[1].DefaultCellStyle.Format = "#,0.###";
            dMTable.Rows[2].DefaultCellStyle.Format = "#,0.###";
            dMTable.Rows[3].DefaultCellStyle.Format = "#,0.###";
            dMTable.Rows[4].DefaultCellStyle.Format = "#,0.###";
            dMTable.Rows[0].Cells["BU"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dMTable.Rows[0].Cells["EA1"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dMTable.Rows[0].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dMTable.Rows[0].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dMTable.Rows[1].Cells["EA1"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dMTable.Rows[1].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dMTable.Rows[1].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dMTable.Rows[2].Cells["EA2"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dMTable.Rows[2].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);
            dMTable.Rows[3].Cells["EA3"].Style.BackColor = Color.FromArgb(166, 166, 166);

            dMTable.CurrentCell = dMTable[0, 0];
            dMTable.ClearSelection();
        }
    }
}
