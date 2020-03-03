using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.View
{
    public partial class SDSumAllAction : UserControl
    {
        public SDSumAllAction()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            CreateTable(dgv_SavingSum);
            CreateTable(dgv_CarryOverSum);
            CreateTable(dgv_ECCCSum);
            PlanGrid(dgv_PlanActual);
            PlanGrid(dgv_PlanCarryOver);
            PlanGrid(dgv_PlanECCC);
            SumPlanGrid();
        }

        public DataGridView GetActual()
        {
            return dgv_SavingSum;
        }

        public DataGridView GetCarryOver()
        {
            return dgv_CarryOverSum;
        }

        public DataGridView GetECCC()
        {
            return dgv_ECCCSum;
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
            Table.Columns.Add("Sum", "Sum:");
            Table.Columns[0].Width = 80;
            Table.Columns[1].Width = 80;
            Table.Columns[2].Width = 80;
            Table.Columns[3].Width = 80;
            Table.Columns[4].Width = 80;
            Table.Columns[5].Width = 80;
            Table.Columns[6].Width = 80;
            Table.Columns[7].Width = 80;
            Table.Columns[8].Width = 80;
            Table.Columns[9].Width = 80;
            Table.Columns[10].Width = 80;
            Table.Columns[11].Width = 80;
            Table.Columns[12].Width = 103;
            Table.Rows.Add(6);
            Table.RowHeadersWidth = 68;
            TheSameInAllTable(Table, true);
            Table.Columns[0].Frozen = true;
            Table.Columns["Sum"].DefaultCellStyle.Font = new Font(Table.Font, FontStyle.Bold);
            Table.Rows[0].DefaultCellStyle.Font = new Font(Table.Font, FontStyle.Bold);
        }

        private void PlanGrid(DataGridView Table)
        {
            Table.Columns.Add("Percent", "Execution of plan [%]");
            Table.Columns.Add("PercentDM", "Delivery DM [%]");
            Table.Columns[0].Width = 140;
            Table.Columns[1].Width = 120;
            Table.Rows.Add(5);
            Table.RowHeadersWidth = 68;
            TheSameInAllTable(Table, false);
        }

        private void SumPlanGrid()
        {
            dgv_SumPlan.Columns.Add("Sum", "Sum [PLN]");
            dgv_SumPlan.Columns.Add("Plan", "Execution of plan [%]");
            dgv_SumPlan.Columns.Add("DM", "DM [%]");
            dgv_SumPlan.Columns.Add("Target DM", "Target DM [PLN]");
            dgv_SumPlan.Columns.Add("Target DMP", "Target DM [%]");
            dgv_SumPlan.Columns.Add("Delta", "Delta [PLN]");
            dgv_SumPlan.Columns.Add("DeltaP", "Delta [%]");
            dgv_SumPlan.Columns[0].Width = 100;
            dgv_SumPlan.Columns[1].Width = 100;
            dgv_SumPlan.Columns[2].Width = 100;
            dgv_SumPlan.Columns[3].Width = 100;
            dgv_SumPlan.Columns[4].Width = 100;
            dgv_SumPlan.Columns[5].Width = 100;
            dgv_SumPlan.Columns[6].Width = 100;
            dgv_SumPlan.Rows.Add(5);
            dgv_SumPlan.RowHeadersWidth = 68;
            TheSameInAllTable(dgv_SumPlan, false);

        }

        private void TheSameInAllTable(DataGridView Table, bool Diff)
        {
            Table.Rows[0].HeaderCell.Value = "Actual:";
            Table.Rows[1].HeaderCell.Value = "EA3:";
            Table.Rows[2].HeaderCell.Value = "EA2:";
            Table.Rows[3].HeaderCell.Value = "EA1:";
            Table.Rows[4].HeaderCell.Value = "BU:";
            if(Diff)
                Table.Rows[5].HeaderCell.Value = "Diff:";

            foreach (DataGridViewRow Row in Table.Rows)
            {
                Row.DefaultCellStyle.Format = "#,0.####";
                Row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            Table.Rows[1].DefaultCellStyle.BackColor = Color.FromArgb(252, 228, 214);
            Table.Rows[2].DefaultCellStyle.BackColor = Color.FromArgb(248, 203, 173);
            Table.Rows[3].DefaultCellStyle.BackColor = Color.FromArgb(244, 176, 132);
            Table.Rows[4].DefaultCellStyle.BackColor = Color.FromArgb(240, 146, 91);
            Table.CurrentCell = Table[0, 0];
            Table.ClearSelection();
        }
    }
}
