using Saving_Accelerator_Tool.Klasy.StatisticTab.Handlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab.View
{
    public class StatisticDMView : StatisticDMHandler
    {
        private TabPage _StatisticTab;
        private GroupBox _DMGroupBox;
        public StatisticDMView(TabPage StatisticTab)
        {
            _StatisticTab = StatisticTab;

            GroupBoxCreate();
            DMTables();
            ExchangeRate();
        }

        private void ExchangeRate()
        {
            ComboBox Exchange = new ComboBox
            {
                Location = new Point(490, 15),
                Size = new Size(50, 25),
                Name = "cb_Statistic ExchangeRate",
            };
            Exchange.Items.Add("PLN");
            Exchange.Items.Add("EUR");
            Exchange.Items.Add("USD");
            Exchange.Items.Add("SEK");
            Exchange.SelectedIndex = 0;
            Exchange.SelectedIndexChanged += new EventHandler(Exchange_SelectedItemChange);
            _DMGroupBox.Controls.Add(Exchange);
        }

        private void GroupBoxCreate()
        {
            GroupBox gb_DM = new GroupBox
            {
                Location = new Point(205, 5),
                Size = new Size(550, 160),
                Text = "Direct Material [PLN]:",
                Name = "Gb_StatisticDM",
                TabStop = false,
            };
            _StatisticTab.Controls.Add(gb_DM);
            _DMGroupBox = gb_DM;
        }

        private void DMTables()
        {
            DataGridView DMTable = new DataGridView
            {
                Location = new Point(10, 15),
                Size = new Size(470, 135),
                Name = "DGV_StatisticDM",
                ReadOnly = true,
                AllowUserToAddRows = false,
                Enabled = false,
            };
            _DMGroupBox.Controls.Add(DMTable);
            GeneretedColumnForDMTable(DMTable);
        }

        private void GeneretedColumnForDMTable(DataGridView dMTable)
        {
            dMTable.Columns.Add("DM", "DM");
            dMTable.Columns["DM"].Width = 90;
            dMTable.Columns.Add("BU", "BU");
            dMTable.Columns["BU"].Width = 80;
            dMTable.Columns.Add("EA1", "EA1");
            dMTable.Columns["EA1"].Width = 80;
            dMTable.Columns.Add("EA2", "EA2");
            dMTable.Columns["EA2"].Width = 80;
            dMTable.Columns.Add("EA3", "EA3");
            dMTable.Columns["EA3"].Width = 80;
            dMTable.Columns["DM"].DefaultCellStyle.Font = new Font(dMTable.Font, FontStyle.Bold);
            dMTable.Rows.Add(5);
            dMTable.RowHeadersWidth = 58;
            dMTable.Rows[0].HeaderCell.Value = "BU";
            dMTable.Rows[1].HeaderCell.Value = "EA1";
            dMTable.Rows[2].HeaderCell.Value = "EA2";
            dMTable.Rows[3].HeaderCell.Value = "EA3";
            dMTable.Rows[4].HeaderCell.Value = "EA4";
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
