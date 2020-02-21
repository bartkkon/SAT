using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.Acton;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class SavingsTableView : UserControl
    {
        public SavingsTableView()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            CreateTable(dg_Saving);
            CreateTable(dg_Quantity);
            CreateTable(dg_ECCC);
        }

        public void SetData(string What, decimal[] Use, decimal[] BU, decimal[] EA1, decimal[] EA2, decimal[] EA3)
        {
            DataGridView Table = WhatGrid(What);
            if (Table == null)
                return;

            for (int counter = 0; counter < 13; counter++)
            {
                Table.Rows[0].Cells[counter].Value = Use[counter];
                Table.Rows[1].Cells[counter].Value = EA3[counter];
                Table.Rows[2].Cells[counter].Value = EA2[counter];
                Table.Rows[3].Cells[counter].Value = EA1[counter];
                Table.Rows[4].Cells[counter].Value = BU[counter];
            }

            RemoveZeroFromTable(Table);
        }
        public void Clear()
        {
            for(int Row =0; Row<5; Row++)
            {
                for(int Column = 0; Column<13; Column++)
                {
                    dg_Saving.Rows[Row].Cells[Column].Value = null;
                    dg_Quantity.Rows[Row].Cells[Column].Value = null;
                    dg_ECCC.Rows[Row].Cells[Column].Value = null;
                }
            }
        }
        public void SetButton(string What)
        {
            if(What == "CurrentYear")
            {
                pb_CurrentYear.BackColor = Color.Lime;
                pb_CarryOver.BackColor = SystemColors.Control;
            }
            else if( What == "CarryOver")
            {
                pb_CurrentYear.BackColor = SystemColors.Control;
                pb_CarryOver.BackColor = Color.Lime;
            }
        }

        private void RemoveZeroFromTable(DataGridView Table)
        {
            for(int Row = 0; Row <5; Row++)
            {
                for(int Column = 0; Column<13; Column++)
                {
                    if (Table.Rows[Row].Cells[Column].Value.ToString() == "0")
                        Table.Rows[Row].Cells[Column].Value = null;
                }
            }
        }

        private DataGridView WhatGrid(string what)
        {
            if (what == "Savings")
                return dg_Saving;
            else if (what == "Quantity")
                return dg_Quantity;
            else if (what == "ECCC")
                return dg_ECCC;
            else
                return null;

        }

        private void CreateTable(DataGridView Table)
        {
            Table.Columns.Add("1", "I");
            Table.Columns.Add("2", "II");
            Table.Columns.Add("3", "III");
            Table.Columns.Add("4", "IV");
            Table.Columns.Add("5", "V");
            Table.Columns.Add("6", "VI");
            Table.Columns.Add("7", "VII");
            Table.Columns.Add("8", "VIII");
            Table.Columns.Add("9", "IX");
            Table.Columns.Add("10", "X");
            Table.Columns.Add("11", "XI");
            Table.Columns.Add("12", "XII");
            Table.Columns.Add("Sum:", "Sum:");
            Table.Columns[0].Width = 67;
            Table.Columns[1].Width = 67;
            Table.Columns[2].Width = 67;
            Table.Columns[3].Width = 67;
            Table.Columns[4].Width = 67;
            Table.Columns[5].Width = 67;
            Table.Columns[6].Width = 67;
            Table.Columns[7].Width = 67;
            Table.Columns[8].Width = 67;
            Table.Columns[9].Width = 67;
            Table.Columns[10].Width = 67;
            Table.Columns[11].Width = 67;
            Table.Columns[12].Width = 84;
            Table.Rows.Add(5);
            Table.RowHeadersWidth = 55;
            Table.Rows[0].HeaderCell.Value = "Use:";
            Table.Rows[1].HeaderCell.Value = "EA3:";
            Table.Rows[2].HeaderCell.Value = "EA2:";
            Table.Rows[3].HeaderCell.Value = "EA1:";
            Table.Rows[4].HeaderCell.Value = "BU:";
            Table.CurrentCell = Table[0, 0];
            Table.ClearSelection();
            Table.Columns["Sum:"].DefaultCellStyle.Font = new Font(Table.Font, FontStyle.Bold);
            Table.Rows[0].DefaultCellStyle.Font = new Font(Table.Font, FontStyle.Bold);
            Table.Rows[1].DefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);
            Table.Rows[2].DefaultCellStyle.BackColor = Color.FromArgb(248, 203, 173);
            Table.Rows[3].DefaultCellStyle.BackColor = Color.FromArgb(244, 176, 132);
            Table.Rows[4].DefaultCellStyle.BackColor = Color.FromArgb(240, 146, 91);
            Table.Rows[0].DefaultCellStyle.Format = "#,0.###";
            Table.Rows[1].DefaultCellStyle.Format = "#,0.###";
            Table.Rows[2].DefaultCellStyle.Format = "#,0.###";
            Table.Rows[3].DefaultCellStyle.Format = "#,0.###";
            Table.Rows[4].DefaultCellStyle.Format = "#,0.###";
            Table.Rows[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Table.Rows[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Table.Rows[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Table.Rows[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Table.Rows[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void Pb_CurrentYear_Click(object sender, EventArgs e)
        {
            SetData("Savings", CopyAction.Value.CalcUSESaving, CopyAction.Value.CalcBUSaving, CopyAction.Value.CalcEA1Saving, CopyAction.Value.CalcEA2Saving, CopyAction.Value.CalcEA3Saving);
            SetData("Quantity", CopyAction.Value.CalcUSEQuantity, CopyAction.Value.CalcBUQuantity, CopyAction.Value.CalcEA1Quantity, CopyAction.Value.CalcEA2Quantity, CopyAction.Value.CalcEA3Quantity);
            SetData("ECCC", CopyAction.Value.CalcUSEECCC, CopyAction.Value.CalcBUECCC, CopyAction.Value.CalcEA1ECCC, CopyAction.Value.CalcEA2ECCC, CopyAction.Value.CalcEA3ECCC);
            SetButton("CurrentYear");
        }

        private void Pb_CarryOver_Click(object sender, EventArgs e)
        {
            SetData("Savings", CopyAction.Value.CalcUSESavingCarry, CopyAction.Value.CalcBUSavingCarry, CopyAction.Value.CalcEA1SavingCarry, CopyAction.Value.CalcEA2SavingCarry, CopyAction.Value.CalcEA3SavingCarry);
            SetData("Quantity", CopyAction.Value.CalcUSEQuantityCarry, CopyAction.Value.CalcBUQuantityCarry, CopyAction.Value.CalcEA1QuantityCarry, CopyAction.Value.CalcEA2QuantityCarry, CopyAction.Value.CalcEA3QuantityCarry);
            SetData("ECCC", CopyAction.Value.CalcUSEECCCCarry, CopyAction.Value.CalcBUECCCCarry, CopyAction.Value.CalcEA1ECCCCarry, CopyAction.Value.CalcEA2ECCCCarry, CopyAction.Value.CalcEA3ECCCCarry);
            SetButton("CarryOver");
        }

        private void pb_SavingCalc_Click(object sender, EventArgs e)
        {

        }
    }
}
