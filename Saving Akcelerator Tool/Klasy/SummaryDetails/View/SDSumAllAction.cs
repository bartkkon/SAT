using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

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

        public void ClearPlanTable()
        {
            for (int counter = 0; counter <=4; counter++)
            {
                dgv_PlanActual.Rows[counter].Cells[0].Value = null;
                dgv_PlanActual.Rows[counter].Cells[1].Value = null;
                dgv_PlanCarryOver.Rows[counter].Cells[0].Value = null;
                dgv_PlanCarryOver.Rows[counter].Cells[1].Value = null;
                dgv_PlanECCC.Rows[counter].Cells[0].Value = null;
                dgv_PlanECCC.Rows[counter].Cells[1].Value = null;
            }
        }

        public void PlanTable()
        {
            DataTable Kurs = new DataTable();
            DataRow KursRow;
            decimal Year;

            Year = MainProgram.Self.sdOptions1.GetYear();
            Data_Import.Singleton().Load_TxtToDataTable2(ref Kurs, "Kurs");

            KursRow = Kurs.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();

            PlanTableCheck(dgv_SavingSum, dgv_PlanActual, KursRow);
            PlanTableCheck(dgv_CarryOverSum, dgv_PlanCarryOver, KursRow);
            PlanTableCheck(dgv_ECCCSum, dgv_PlanECCC, KursRow);
        }

        public void SumPlanTable()
        {
            DataTable Kurs = new DataTable();
            DataRow KursRow;
            decimal Year;

            Year = MainProgram.Self.sdOptions1.GetYear();

            Data_Import.Singleton().Load_TxtToDataTable2(ref Kurs, "Kurs");

            KursRow = Kurs.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();

            //Czyszczenie tablicy
            CleanSummTabel();

            //Sumowanie wartości z Actuala, CarryOver i ECCC
            dgv_SumPlan.Rows[0].Cells[0].Value = PlanTableSum(0);
            dgv_SumPlan.Rows[1].Cells[0].Value = PlanTableSum(1);
            dgv_SumPlan.Rows[2].Cells[0].Value = PlanTableSum(2);
            dgv_SumPlan.Rows[3].Cells[0].Value = PlanTableSum(3);
            dgv_SumPlan.Rows[4].Cells[0].Value = PlanTableSum(4);

            //Wyliczenie Procentów dostarczonych 
            PercentWykonania();

            //Wyliczenie ile już dostarczyliśmy DM 
            DMForRewizion(KursRow);

            //Wpisanie targetów
            TargetsSum(KursRow);

            //Delta 
            DeltaSumm();
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

        public Chart GetChart()
        {
            return ChartSummary;
        }

        public bool ChartUse()
        {
            return cb_ChartFilters_USE.Checked;
        }

        public bool ChartEA3()
        {
            return cb_ChartFilters_EA3.Checked;
        }

        public bool ChartEA2()
        {
            return cb_ChartFilters_EA2.Checked;
        }

        public bool ChartEA1()
        {
            return cb_ChartFilters_EA1.Checked;
        }

        public bool ChartBU()
        {
            return cb_ChartFilters_BU.Checked;
        }

        public bool ChartActual()
        {
            return cb_ChartFilters_Actual.Checked;
        }

        public bool ChartCarrOver()
        {
            return cb_ChartFilters_CarryOver.Checked;
        }

        public bool ChartECCC()
        {
            return cb_ChartFilters_ECCC.Checked;
        }

        private void PlanTableCheck(DataGridView Actions, DataGridView Percent, DataRow KursRow)
        {
            string[] DM = new string[3];
            bool DMexist = false;
            decimal ActualDec;
            decimal Rew;
            decimal DMRew;
            decimal PercentValue = 0;

            if (KursRow != null)
            {
                if (KursRow["DM"].ToString() != "////" || KursRow["DM"].ToString() != "")
                {
                    DM = KursRow["DM"].ToString().Split('/');
                    DMexist = true;
                }
            }

            if (Actions.Rows[0].Cells["Sum"].Value != null && Actions.Rows[0].Cells["Sum"].Value.ToString() != "")
            {
                ActualDec = decimal.Parse(Actions.Rows[0].Cells["Sum"].Value.ToString());

                for (int counter = 1; counter <= 4; counter++)
                {
                    if (Actions.Rows[counter].Cells["Sum"].Value != null && Actions.Rows[counter].Cells["Sum"].Value.ToString() != "")
                    {
                        Rew = decimal.Parse(Actions.Rows[counter].Cells["Sum"].Value.ToString());
                        if (ActualDec > 0 && Rew > 0)
                        {
                            PercentValue = (ActualDec / Rew) * 100;
                        }
                        else if (ActualDec < 0 && Rew < 0)
                        {
                            PercentValue = (Rew / ActualDec) * 100;
                        }
                        else if (ActualDec > 0 && Rew < 0)
                        {
                            Rew = ActualDec - Rew;
                            PercentValue = (Rew / ActualDec) * 100;
                        }
                        else if (ActualDec < 0 && Rew > 0)
                        {
                            Rew -= ActualDec;
                            PercentValue = (Rew / ActualDec) * 100;
                        }
                        Percent.Rows[counter].Cells[0].Value = Math.Round(PercentValue, 2, MidpointRounding.AwayFromZero);
                        if (DMexist)
                        {
                            if (DM[4 - counter].ToString() != "")
                            {
                                DMRew = decimal.Parse(DM[4 - counter].ToString());
                                Percent.Rows[counter].Cells[1].Value = Math.Round((ActualDec / DMRew) * 100, 4, MidpointRounding.AwayFromZero);
                            }
                        }
                    }
                }

                for (int counter = 1; counter <= 4; counter++)
                {
                    if (Percent.Rows[counter].Cells[0].Value != null)
                    {
                        decimal Tocheck = decimal.Parse(Percent.Rows[counter].Cells[0].Value.ToString());
                        if (Tocheck >= 100)
                        {
                            Percent.Rows[counter].Cells[0].Style.ForeColor = Color.Green;
                        }
                        else
                        {
                            Percent.Rows[counter].Cells[0].Style.ForeColor = Color.Red;
                        }
                    }
                }
            }
        }

        private void CleanSummTabel()
        {
            for (int counter = 0; counter <= 4; counter++)
            {
                for (int counter2 = 0; counter2 <= 6; counter2++)
                {
                    dgv_SumPlan.Rows[counter].Cells[counter2].Value = null;
                }
            }
        }

        private decimal PlanTableSum(int Row)
        {
            decimal Sum = 0;

            if (dgv_SavingSum.Rows[Row].Cells["Sum"].Value != null && dgv_SavingSum.Rows[Row].Cells["Sum"].Value.ToString() != "")
            {
                Sum += decimal.Parse(dgv_SavingSum.Rows[Row].Cells["Sum"].Value.ToString());
            }
            if (dgv_CarryOverSum.Rows[Row].Cells["Sum"].Value != null && dgv_CarryOverSum.Rows[Row].Cells["Sum"].Value.ToString() != "")
            {
                Sum += decimal.Parse(dgv_CarryOverSum.Rows[Row].Cells["Sum"].Value.ToString());
            }
            if (dgv_ECCCSum.Rows[Row].Cells["Sum"].Value != null && dgv_ECCCSum.Rows[Row].Cells["Sum"].Value.ToString() != "")
            {
                Sum += decimal.Parse(dgv_ECCCSum.Rows[Row].Cells["Sum"].Value.ToString());
            }

            return Sum;
        }

        private void PercentWykonania()
        {
            decimal Rew;
            decimal Actual;
            decimal Percent = 0;

            if (dgv_SumPlan.Rows[0].Cells[0].Value != null && dgv_SumPlan.Rows[0].Cells[0].Value.ToString() != "")
            {
                Actual = decimal.Parse(dgv_SumPlan.Rows[0].Cells[0].Value.ToString());

                for (int counter = 1; counter <= 4; counter++)
                {
                    if (dgv_SumPlan.Rows[counter].Cells[0].Value != null && dgv_SumPlan.Rows[counter].Cells[0].Value.ToString() != "")
                    {
                        Rew = decimal.Parse(dgv_SumPlan.Rows[counter].Cells[0].Value.ToString());

                        if (Actual > 0 && Rew > 0)
                        {
                            Percent = (Actual / Rew) * 100;
                        }
                        else if (Actual < 0 && Rew < 0)
                        {
                            Percent = (Rew / Actual) * 100;
                        }
                        else if (Actual > 0 && Rew < 0)
                        {
                            Rew = Actual - Rew;
                            Percent = (Rew / Actual) * 100;
                        }
                        else if (Actual < 0 && Rew > 0)
                        {
                            Rew -= Actual;
                            Percent = (Rew / Actual) * 100;
                        }

                        dgv_SumPlan.Rows[counter].Cells[1].Value = Math.Round(Percent, 2, MidpointRounding.AwayFromZero);
                        if (Percent >= 100)
                            dgv_SumPlan.Rows[counter].Cells[1].Style.ForeColor = Color.Green;
                        else
                            dgv_SumPlan.Rows[counter].Cells[1].Style.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void TargetsSum(DataRow KursRow)
        {
            string[] DMPercent = new string[4];
            string[] DMValue = new string[4];
            bool CanCalc = false;
            decimal Target;
            decimal Percent;
            decimal DMRew;

            string Devision = MainProgram.Self.sdOptions1.GetDevision();

            if (Devision == "All")
            {
                if (KursRow["PC"].ToString() != "")
                {
                    DMPercent = KursRow["PC"].ToString().Split('/');
                    CanCalc = true;
                }
            }
            else if (Devision == "Electronic")
            {
                if (KursRow["Ele"].ToString() != "")
                {
                    DMPercent = KursRow["Ele"].ToString().Split('/');
                    CanCalc = true;
                }
            }
            else if (Devision == "Mechanic")
            {
                if (KursRow["Mech"].ToString() != "")
                {
                    DMPercent = KursRow["Mech"].ToString().Split('/');
                    CanCalc = true;
                }
            }
            else if (Devision == "NVR")
            {
                if (KursRow["NVR"].ToString() != "")
                {
                    DMPercent = KursRow["NVR"].ToString().Split('/');
                    CanCalc = true;
                }
            }

            if (KursRow["DM"].ToString() != "")
            {
                DMValue = KursRow["DM"].ToString().Split('/');
            }

            if (CanCalc)
            {
                if (DMPercent[0].ToString() != "" && DMValue[0].ToString() != "")
                {
                    Percent = decimal.Parse(DMPercent[0].ToString());
                    DMRew = decimal.Parse(DMValue[0].ToString());
                    Target = DMRew * (Percent / 100);
                    Target = Math.Round(Target, 0, MidpointRounding.AwayFromZero);
                    dgv_SumPlan.Rows[4].Cells[3].Value = Target;
                    dgv_SumPlan.Rows[4].Cells[4].Value = Percent;
                }
                if (DMPercent[1].ToString() != "" && DMValue[1].ToString() != "")
                {
                    Percent = decimal.Parse(DMPercent[1].ToString());
                    DMRew = decimal.Parse(DMValue[1].ToString());
                    Target = DMRew * (Percent / 100);
                    Target = Math.Round(Target, 0, MidpointRounding.AwayFromZero);
                    dgv_SumPlan.Rows[3].Cells[3].Value = Target;
                    dgv_SumPlan.Rows[3].Cells[4].Value = Percent;
                }
                if (DMPercent[2].ToString() != "" && DMValue[2].ToString() != "")
                {
                    Percent = decimal.Parse(DMPercent[2].ToString());
                    DMRew = decimal.Parse(DMValue[2].ToString());
                    Target = DMRew * (Percent / 100);
                    Target = Math.Round(Target, 0, MidpointRounding.AwayFromZero);
                    dgv_SumPlan.Rows[2].Cells[3].Value = Target;
                    dgv_SumPlan.Rows[2].Cells[4].Value = Percent;
                }
                if (DMPercent[3].ToString() != "" && DMValue[3].ToString() != "")
                {
                    Percent = decimal.Parse(DMPercent[3].ToString());
                    DMRew = decimal.Parse(DMValue[3].ToString());
                    Target = DMRew * (Percent / 100);
                    Target = Math.Round(Target, 0, MidpointRounding.AwayFromZero);
                    dgv_SumPlan.Rows[1].Cells[3].Value = Target;
                    dgv_SumPlan.Rows[1].Cells[4].Value = Percent;
                }
                if (DMPercent[4].ToString() != "" && DMValue[4].ToString() != "")
                {
                    Percent = decimal.Parse(DMPercent[4].ToString());
                    DMRew = decimal.Parse(DMValue[4].ToString());
                    Target = DMRew * (Percent / 100);
                    Target = Math.Round(Target, 0, MidpointRounding.AwayFromZero);
                    dgv_SumPlan.Rows[0].Cells[3].Value = Target;
                    dgv_SumPlan.Rows[0].Cells[4].Value = Percent;
                }
            }
        }

        private void DeltaSumm()
        {
            decimal Delivery;
            decimal Plan;
            for (int counter = 0; counter <= 4; counter++)
            {
                if (dgv_SumPlan.Rows[counter].Cells[3].Value != null && dgv_SumPlan.Rows[counter].Cells[3].Value.ToString() != "")
                {
                    if (dgv_SumPlan.Rows[0].Cells[0].Value != null && dgv_SumPlan.Rows[0].Cells[0].Value.ToString() != "")
                    {
                        Plan = decimal.Parse(dgv_SumPlan.Rows[counter].Cells[3].Value.ToString());
                        Delivery = decimal.Parse(dgv_SumPlan.Rows[0].Cells[0].Value.ToString());
                        dgv_SumPlan.Rows[counter].Cells[5].Value = Delivery - Plan;
                        if (Delivery - Plan < 0)
                        {
                            dgv_SumPlan.Rows[counter].Cells[5].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            dgv_SumPlan.Rows[counter].Cells[5].Style.ForeColor = Color.Green;
                        }
                    }
                }
                if (dgv_SumPlan.Rows[counter].Cells[4].Value != null && dgv_SumPlan.Rows[counter].Cells[4].Value.ToString() != "")
                {
                    if (dgv_SumPlan.Rows[counter].Cells[2].Value != null && dgv_SumPlan.Rows[counter].Cells[2].Value.ToString() != "")
                    {
                        Plan = decimal.Parse(dgv_SumPlan.Rows[counter].Cells[4].Value.ToString());
                        Delivery = decimal.Parse(dgv_SumPlan.Rows[counter].Cells[2].Value.ToString());
                        dgv_SumPlan.Rows[counter].Cells[6].Value = Delivery - Plan;
                        if (Delivery - Plan < 0)
                        {
                            dgv_SumPlan.Rows[counter].Cells[6].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            dgv_SumPlan.Rows[counter].Cells[6].Style.ForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        private void DMForRewizion(DataRow KursRow)
        {
            string[] DM = new string[4];
            bool CanCalc = false;
            decimal Actual;
            decimal DMValue;
            decimal Percent;

            if (KursRow["DM"].ToString() != "")
            {
                DM = KursRow["DM"].ToString().Split('/');
                CanCalc = true;
            }

            if (CanCalc)
            {
                if (dgv_SumPlan.Rows[0].Cells[0].Value != null && dgv_SumPlan.Rows[0].Cells[0].Value.ToString() != "")
                {
                    Actual = decimal.Parse(dgv_SumPlan.Rows[0].Cells[0].Value.ToString());

                    if (DM[0].ToString() != "")
                    {
                        DMValue = decimal.Parse(DM[0].ToString());
                        Percent = (Actual / DMValue) * 100;
                        Percent = Math.Round(Percent, 4, MidpointRounding.AwayFromZero);
                        dgv_SumPlan.Rows[4].Cells[2].Value = Percent;
                    }
                    if (DM[1].ToString() != "")
                    {
                        DMValue = decimal.Parse(DM[1].ToString());
                        Percent = (Actual / DMValue) * 100;
                        Percent = Math.Round(Percent, 4, MidpointRounding.AwayFromZero);
                        dgv_SumPlan.Rows[3].Cells[2].Value = Percent;
                    }
                    if (DM[2].ToString() != "")
                    {
                        DMValue = decimal.Parse(DM[2].ToString());
                        Percent = (Actual / DMValue) * 100;
                        Percent = Math.Round(Percent, 4, MidpointRounding.AwayFromZero);
                        dgv_SumPlan.Rows[2].Cells[2].Value = Percent;
                    }
                    if (DM[3].ToString() != "")
                    {
                        DMValue = decimal.Parse(DM[3].ToString());
                        Percent = (Actual / DMValue) * 100;
                        Percent = Math.Round(Percent, 4, MidpointRounding.AwayFromZero);
                        dgv_SumPlan.Rows[1].Cells[2].Value = Percent;
                    }
                    if (DM[4].ToString() != "")
                    {
                        DMValue = decimal.Parse(DM[4].ToString());
                        Percent = (Actual / DMValue) * 100;
                        Percent = Math.Round(Percent, 4, MidpointRounding.AwayFromZero);
                        dgv_SumPlan.Rows[0].Cells[2].Value = Percent;
                    }
                }
            }
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

        public void Cb_ChartFilter_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            Charts charts = new Charts(ChartSummary);
            charts.Charts_AddSeries();
            System.Windows.Forms.Cursor.Current = Cursors.Default;
        }
    }
}
