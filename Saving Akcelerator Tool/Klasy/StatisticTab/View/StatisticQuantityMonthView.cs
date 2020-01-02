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
    class StatisticQuantityMonthView : StatisticQuantityMonthHandler
    {
        private static TabPage _StatisticTab;
        private static GroupBox _QuantityMonthGroupBox;
        public StatisticQuantityMonthView(TabPage StatisticTab)
        {
            _StatisticTab = StatisticTab;

            GroupBoxCreat();
            Controls();
            QuantityTable();
        }

        private void GroupBoxCreat()
        {
            GroupBox gb_QunatityMonthly = new GroupBox
            {
                Location = new Point(205, 165),
                Size = new Size(1045, 200),
                Text = "Production Monthy Quantity:",
                Name = "Gb_StatisticQuantityMonthly",
                TabStop = false,
            };
            _StatisticTab.Controls.Add(gb_QunatityMonthly);
            _QuantityMonthGroupBox = gb_QunatityMonthly;
        }

        private void Controls()
        {
            Label Lab_Rewizion = new Label
            {
                Location = new Point(500, 18),
                AutoSize = true,
                Size = new Size(10, 10),
                Name = "lab_StatisticQuantityMonthRev",
                Text = "Revision:",
            };
            _QuantityMonthGroupBox.Controls.Add(Lab_Rewizion);

            ComboBox comb_Revizion = new ComboBox
            {
                Location = new Point(560, 15),
                Size = new Size(70, 25),
                Name = "comb_StatisicQuantityMonthRev",
            };
            comb_Revizion.Items.Add("All");
            comb_Revizion.Items.Add("BU");
            comb_Revizion.Items.Add("EA1");
            comb_Revizion.Items.Add("EA2");
            comb_Revizion.Items.Add("EA3");
            comb_Revizion.SelectedIndex = 0;
            comb_Revizion.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChange);
            _QuantityMonthGroupBox.Controls.Add(comb_Revizion);

            Label Lab_Structure = new Label
            {
                Location = new Point(650, 18),
                AutoSize = true,
                Size = new Size(10, 10),
                Name = "lab_StatisticQuantityMonthStruc",
                Text = "Structure:",
            };
            _QuantityMonthGroupBox.Controls.Add(Lab_Structure);

            ComboBox comb_Structure = new ComboBox
            {
                Location = new Point(710, 15),
                Size = new Size(70, 25),
                Name = "comb_StatisicQuantityMonthStructure",
            };
            comb_Structure.Items.Add("All");
            comb_Structure.Items.Add("DMD");
            comb_Structure.Items.Add("D45");
            comb_Structure.SelectedIndex = 0;
            comb_Structure.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChange);
            _QuantityMonthGroupBox.Controls.Add(comb_Structure);

            Label Lab_Instalation = new Label
            {
                Location = new Point(790, 18),
                AutoSize = true,
                Size = new Size(10, 10),
                Name = "lab_StatisticQuantityMonthInstalation",
                Text = "Installation:",
            };
            _QuantityMonthGroupBox.Controls.Add(Lab_Instalation);

            ComboBox comb_Instalation = new ComboBox
            {
                Location = new Point(860, 15),
                Size = new Size(70, 25),
                Name = "comb_StatisicQuantityMonthInstalation",
            };
            comb_Instalation.Items.Add("All");
            comb_Instalation.Items.Add("FS");
            comb_Instalation.Items.Add("FI");
            comb_Instalation.Items.Add("BI");
            comb_Instalation.Items.Add("FSBU");
            comb_Instalation.SelectedIndex = 0;
            comb_Instalation.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChange);
            _QuantityMonthGroupBox.Controls.Add(comb_Instalation);
        }

        private void QuantityTable()
        {
            DataGridView QuantityMonthTable = new DataGridView
            {
                Location = new Point(10, 45),
                Size = new Size(1025, 91),
                Name = "GDV_StatisticQuantityMonth",
                ReadOnly = true,
                AllowUserToAddRows = false,
                Enabled = false,
            };
            _QuantityMonthGroupBox.Controls.Add(QuantityMonthTable);
            GeneretedColumnforQuantityMonthTabe(QuantityMonthTable);
        }

        private void GeneretedColumnforQuantityMonthTabe(DataGridView quantityMonthTable)
        {
            quantityMonthTable.Columns.Add("1", "I");
            quantityMonthTable.Columns.Add("2", "II");
            quantityMonthTable.Columns.Add("3", "III");
            quantityMonthTable.Columns.Add("4", "IV");
            quantityMonthTable.Columns.Add("5", "V");
            quantityMonthTable.Columns.Add("6", "VI");
            quantityMonthTable.Columns.Add("7", "VII");
            quantityMonthTable.Columns.Add("8", "VIII");
            quantityMonthTable.Columns.Add("9", "IX");
            quantityMonthTable.Columns.Add("10", "X");
            quantityMonthTable.Columns.Add("11", "XI");
            quantityMonthTable.Columns.Add("12", "XII");
            quantityMonthTable.Columns.Add("Sum", "SUM");

            foreach (DataGridViewColumn Column in quantityMonthTable.Columns)
                Column.Width = 72;

            quantityMonthTable.RowHeadersWidth = 87;
            quantityMonthTable.Rows.Add(3);
            quantityMonthTable.Rows[0].HeaderCell.Value = "Actual:";
            quantityMonthTable.Rows[1].HeaderCell.Value = "Plan:";
            quantityMonthTable.Rows[2].HeaderCell.Value = "Different:";
            quantityMonthTable.Rows[0].DefaultCellStyle.Format = "#,0.###";
            quantityMonthTable.Rows[1].DefaultCellStyle.Format = "#,0.###";
            quantityMonthTable.Rows[2].DefaultCellStyle.Format = "#,0.###";

            quantityMonthTable.CurrentCell = quantityMonthTable[0, 0];
            quantityMonthTable.ClearSelection();
        }
    }
}
