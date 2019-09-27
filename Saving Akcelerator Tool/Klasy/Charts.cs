using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;

namespace Saving_Accelerator_Tool
{
    class Charts
    {
        MainProgram mainProgram;

        public Charts(MainProgram mainProgram)
        {
            this.mainProgram = mainProgram;
        }

        public void Charts_AddSeries()
        {
            AddSeries();
        }

        public void ChartSummary()
        {
            string[] xValues = new[]
            {
                "I",
                "II",
                "III",
                "IV",
                "V",
                "VI",
                "VII",
                "VIII",
                "IX",
                "X",
                "XI",
                "XII",
            };

            GroupBox Gb_Summary = (GroupBox)mainProgram.Controls.Find("gb_ShowActionSum", true).First();

            Chart ChartSummary = new Chart();
            ChartSummary.Size = new Size(1100, 350);
            ChartSummary.Name = "ChartSummary";
            ChartSummary.Location = new Point(5, 540);
            ChartSummary.Legends.Add(new Legend("Expenses"));
            ChartSummary.Legends[0].TableStyle = LegendTableStyle.Auto;
            ChartSummary.Legends[0].Docking = Docking.Bottom;
            ChartSummary.Legends[0].Alignment = StringAlignment.Center;

            ChartArea ChartAreaSummary = new ChartArea();
            ChartAreaSummary.AxisX.MajorGrid.LineColor = Color.LightGray;
            ChartAreaSummary.AxisY.MajorGrid.LineColor = Color.LightGray;
            ChartAreaSummary.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            ChartAreaSummary.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            ChartAreaSummary.AxisX.Interval = 1;

            ChartSummary.ChartAreas.Add(ChartAreaSummary);
            Gb_Summary.Controls.Add(ChartSummary);
            ChartSummary.Invalidate();

            AddSeries();
        }

        private void AddSeries()
        {
            Chart ChartSummary = (Chart)mainProgram.TabControl.Controls.Find("ChartSummary", true).First();
            bool CurrentYear = false;
            bool CarryOver = false;
            bool ECCC = false;
            string[] xValues = new[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", };

            ChartSummary.Series.Clear();

            if (((CheckBox)mainProgram.Controls.Find("Cb_ChartFilters_CurrentAction", true).First()).Checked)
            {
                CurrentYear = true;
            }
            if (((CheckBox)mainProgram.Controls.Find("Cb_ChartFilters_CarryOver", true).First()).Checked)
            {
                CarryOver = true;
            }
            if (((CheckBox)mainProgram.Controls.Find("Cb_ChartFilters_ECCC", true).First()).Checked)
            {
                ECCC = true;
            }
            if (((CheckBox)mainProgram.Controls.Find("Cb_ChartFilters_USE", true).First()).Checked)
            {
                decimal[] USE = Summ_AllActionFromGrid("USE", CurrentYear, CarryOver, ECCC);
                Series Series0 = new Series();
                Series0.Name = "USE";
                Series0.LegendText = "USE";
                Series0.ChartType = SeriesChartType.Column;
                Series0.XValueType = ChartValueType.String;
                Series0.YValueType = ChartValueType.Int32;
                ChartSummary.Series.Add(Series0);
                ChartSummary.Series["USE"].Points.DataBindXY(xValues, USE);
            }
            if (((CheckBox)mainProgram.Controls.Find("Cb_ChartFilters_EA3", true).First()).Checked)
            {
                decimal[] EA3 = Summ_AllActionFromGrid("EA3", CurrentYear, CarryOver, ECCC);
                Series Series1 = new Series();
                Series1.Name = "EA3";
                Series1.LegendText = "EA3";
                Series1.ChartType = SeriesChartType.Column;
                Series1.XValueType = ChartValueType.String;
                Series1.YValueType = ChartValueType.Int32;
                ChartSummary.Series.Add(Series1);
                ChartSummary.Series["EA3"].Points.DataBindXY(xValues, EA3);
            }
            if (((CheckBox)mainProgram.Controls.Find("Cb_ChartFilters_EA2", true).First()).Checked)
            {
                decimal[] EA2 = Summ_AllActionFromGrid("EA2", CurrentYear, CarryOver, ECCC);
                Series Series3 = new Series();
                Series3.Name = "EA2";
                Series3.LegendText = "EA2";
                Series3.ChartType = SeriesChartType.Column;
                Series3.XValueType = ChartValueType.String;
                Series3.YValueType = ChartValueType.Int32;
                ChartSummary.Series.Add(Series3);
                ChartSummary.Series["EA2"].Points.DataBindXY(xValues, EA2);
            }
            if (((CheckBox)mainProgram.Controls.Find("Cb_ChartFilters_EA1", true).First()).Checked)
            {
                decimal[] EA1 = Summ_AllActionFromGrid("EA1", CurrentYear, CarryOver, ECCC);
                Series Series2 = new Series();
                Series2.Name = "EA1";
                Series2.LegendText = "EA1";
                Series2.ChartType = SeriesChartType.Column;
                Series2.XValueType = ChartValueType.String;
                Series2.YValueType = ChartValueType.Int32;
                ChartSummary.Series.Add(Series2);
                ChartSummary.Series["EA1"].Points.DataBindXY(xValues, EA1);
            }
            if (((CheckBox)mainProgram.Controls.Find("Cb_ChartFilters_BU", true).First()).Checked)
            {
                decimal[] BU = Summ_AllActionFromGrid("BU", CurrentYear, CarryOver, ECCC);
                Series Series1 = new Series();
                Series1.Name = "BU";
                Series1.LegendText = "BU";
                Series1.ChartType = SeriesChartType.Column;
                Series1.XValueType = ChartValueType.String;
                Series1.YValueType = ChartValueType.Int32;
                ChartSummary.Series.Add(Series1);
                ChartSummary.Series["BU"].Points.DataBindXY(xValues, BU);
            }
        }

        private decimal[] Summ_AllActionFromGrid(string Rewizion, bool CurrentYear, bool CarryOver, bool ECCC)
        {
            decimal[] Sum = new decimal[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
            int Row = 0;
            DataGridViewRow TableCurrentRow;
            DataGridViewRow TableCarryRow;
            DataGridViewRow TableECCCRow;

            DataGridView Dg_CurrentYear = (DataGridView)mainProgram.TabControl.Controls.Find("dg_SavingSum", true).First();
            DataGridView Dg_CarryOver = (DataGridView)mainProgram.TabControl.Controls.Find("dg_CarryOverSum", true).First();
            DataGridView Dg_ECCC = (DataGridView)mainProgram.TabControl.Controls.Find("dg_ECCCSum", true).First();

            if (Rewizion == "BU")
            {
                Row = 4;
            }
            else if (Rewizion == "EA1")
            {
                Row = 3;
            }
            else if (Rewizion == "EA2")
            {
                Row = 2;
            }
            else if (Rewizion == "EA3")
            {
                Row = 1;
            }
            else if (Rewizion == "USE")
            {
                Row = 0;
            }

            TableCurrentRow = Dg_CurrentYear.Rows[Row];
            TableCarryRow = Dg_CarryOver.Rows[Row];
            TableECCCRow = Dg_ECCC.Rows[Row];

            for (int counter = 1; counter <= 12; counter++)
            {
                if (CurrentYear)
                {
                    string Current = TableCurrentRow.Cells[counter.ToString()].Value.ToString();
                    if (Current != "")
                    {

                        Sum[counter - 1] = Sum[counter - 1] + decimal.Parse(Current);
                    }
                }

                if (CarryOver)
                {
                    string Carry = TableCarryRow.Cells[counter.ToString()].Value.ToString();
                    if (Carry != "")
                    {

                        Sum[counter - 1] = Sum[counter - 1] + decimal.Parse(Carry);
                    }
                }

                if (ECCC)
                {
                    string ECCCTab = TableECCCRow.Cells[counter.ToString()].Value.ToString();
                    if (ECCCTab != "")
                    {

                        Sum[counter - 1] = Sum[counter - 1] + decimal.Parse(ECCCTab);
                    }
                }
            }

            return Sum;
        }
    }
}
