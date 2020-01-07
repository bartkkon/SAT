using Saving_Accelerator_Tool.Klasy.SummaryDetails.Handlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.View
{
    class SDTableView : SDTableHandler
    {
        TabPage _summaryDetailsTab;
        GroupBox _ShowAction;
        public SDTableView(TabPage SummaryDetailsTab)
        {
            _summaryDetailsTab = SummaryDetailsTab;

            CreateGroupBox();
            CreateOptions();
            NiceLabel();
            CreateTable();
        }


        private void CreateGroupBox()
        {
            GroupBox ShowAction = new GroupBox
            {
                Location = new Point(310, 5),
                Name = "gb_ShownActionDetails",
                Size = new Size(1580, 970),
                TabStop = false,
                Text = "",
            };
            _summaryDetailsTab.Controls.Add(ShowAction);
            _ShowAction = ShowAction;
        }

        private void CreateOptions()
        {
            Label Options = new Label
            {
                Location = new Point(1500, 15),
                AutoSize = true,
                Size = new Size(10, 10),
                Name = "lab_OptionSD",
                Text = "Options:"
            };
            _ShowAction.Controls.Add(Options);

            CheckBox Savings = new CheckBox
            {
                Location = new Point(1500, 35),
                Size = new Size(80, 17),
                Name = "cb_SDOptionSavings",
                Text = "Savings",
                Checked = true,
            };
            Savings.CheckedChanged += new EventHandler(SDOptionForTable_CheckChanged);
            _ShowAction.Controls.Add(Savings);

            CheckBox Quantity = new CheckBox
            {
                Location = new Point(1500, 55),
                Size = new Size(80, 17),
                Name = "cb_SDOptionQuantity",
                Text = "Quantity",
                Checked = false,
            };
            Quantity.CheckedChanged += new EventHandler(SDOptionForTable_CheckChanged);
            _ShowAction.Controls.Add(Quantity);

            CheckBox ECCC = new CheckBox
            {
                Location = new Point(1500, 75),
                Size = new Size(80, 17),
                Name = "cb_SDOptionECCC",
                Text = "ECCC",
                Checked = false,
            };
            ECCC.CheckedChanged += new EventHandler(SDOptionForTable_CheckChanged);
            _ShowAction.Controls.Add(ECCC);
        }

        private void NiceLabel()
        {
            Label ActualLab = new Label
            {
                Location = new Point(10, 20),
                AutoSize = true,
                Size = new Size(10, 10),
                Name = "lab_SDActual",
                Text = "Actual Action:",
                Font = new Font("Microsoft Sans Serif", 15.75F, ((FontStyle)(FontStyle.Bold | FontStyle.Italic)), GraphicsUnit.Point, ((byte)(238))),
            };
            _ShowAction.Controls.Add(ActualLab);

            Label CarryOverLab = new Label
            {
                Location = new Point(10, 480),
                AutoSize = true,
                Size = new Size(10, 10),
                Name = "lab_SDCarryOver",
                Text = "Carry Over Action:",
                Font = new Font("Microsoft Sans Serif", 15.75F, ((FontStyle)(FontStyle.Bold | FontStyle.Italic)), GraphicsUnit.Point, ((byte)(238))),
            };
            _ShowAction.Controls.Add(CarryOverLab);
        }

        private void CreateTable()
        {
            DataGridView ActualDGV = new DataGridView
            {
                Location = new Point(5, 60),
                Size = new Size(1480, 400),
                Name = "gd_ActualAction",
                AllowUserToAddRows = false,
                ReadOnly = true,
            };
            PreapreTable(ActualDGV);
            _ShowAction.Controls.Add(ActualDGV);

            DataGridView CarryOverDGV = new DataGridView
            {
                Location = new Point(5, 520),
                Size = new Size(1480, 400),
                Name = "gd_CarryOverAction",
                AllowUserToAddRows = false,
                ReadOnly = true,
            };
            PreapreTable(CarryOverDGV);
            _ShowAction.Controls.Add(CarryOverDGV);
        }

        private void PreapreTable(DataGridView DGV)
        {
            DGV.Columns.Add("Name", "NameAction");
            DGV.Columns.Add("Option", "");
            DGV.Columns.Add("1", "I");
            DGV.Columns.Add("2", "II");
            DGV.Columns.Add("3", "III");
            DGV.Columns.Add("4", "IV");
            DGV.Columns.Add("5", "V");
            DGV.Columns.Add("6", "VI");
            DGV.Columns.Add("7", "VII");
            DGV.Columns.Add("8", "VIII");
            DGV.Columns.Add("9", "IX");
            DGV.Columns.Add("10", "X");
            DGV.Columns.Add("11", "XI");
            DGV.Columns.Add("12", "XII");
            DGV.Columns.Add("Sum", "Sum");

            for (int counter = 1; counter <= 12; counter++)
            {
                DGV.Columns[counter.ToString()].Width = 85;
            }
            DGV.Columns["Name"].Width = 250;
            DGV.Columns["Option"].Width = 50;
            DGV.Columns["Sum"].Width = 90;  //W zapasie 2 piksele które możana wykorzystać jeśli będzie miejsce

            DGV.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            DGV.ClearSelection();
        }
    }
}
