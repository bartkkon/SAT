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
        private readonly Chart ChartSum;
        public Charts(Chart _ChartSummary)
        {
            ChartSum = _ChartSummary;
        }

        public void Charts_AddSeries()
        {
            AddSeries();
        }

        public void ChartSummary()
        {

            ChartSum.Legends.Clear();
            ChartSum.Legends.Add(new Legend("Expenses"));
            ChartSum.Legends[0].TableStyle = LegendTableStyle.Auto;
            ChartSum.Legends[0].Docking = Docking.Right;
            ChartSum.Legends[0].Alignment = StringAlignment.Center;

            ChartSum.ChartAreas.Clear();

            ChartArea ChartAreaSummary = new ChartArea();
            ChartAreaSummary.AxisX.MajorGrid.LineColor = Color.LightGray;
            ChartAreaSummary.AxisY.MajorGrid.LineColor = Color.LightGray;
            ChartAreaSummary.AxisX.LabelStyle.Font = new Font("Consolas", 8);
            ChartAreaSummary.AxisY.LabelStyle.Font = new Font("Consolas", 8);
            ChartAreaSummary.AxisX.Interval = 1;
            ChartAreaSummary.AxisX.Title = "Months";
            ChartAreaSummary.AxisY.Title = "Savings [kPLN]";

            ChartSum.ChartAreas.Add(ChartAreaSummary);
            ChartSum.Invalidate();

            AddSeries();
        }

        private void AddSeries()
        {
            bool CurrentYear = false;
            bool CarryOver = false;
            bool ECCC = false;
            string[] xValues = new[] { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII", };

            ChartSum.Series.Clear();

            if (MainProgram.Self.SDSumAllAction.ChartActual())
            {
                CurrentYear = true;
            }
            if (MainProgram.Self.SDSumAllAction.ChartCarrOver())
            {
                CarryOver = true;
            }
            if (MainProgram.Self.SDSumAllAction.ChartECCC())
            {
                ECCC = true;
            }
            if (MainProgram.Self.SDSumAllAction.ChartUse())
            {
                decimal[] USE = Summ_AllActionFromGrid("USE", CurrentYear, CarryOver, ECCC);
                Series Series0 = new Series
                {
                    Name = "USE",
                    LegendText = "USE",
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Int32
                };
                ChartSum.Series.Add(Series0);
                ChartSum.Series["USE"].Points.DataBindXY(xValues, USE);
            }
            if (MainProgram.Self.SDSumAllAction.ChartEA3())
            {
                decimal[] EA3 = Summ_AllActionFromGrid("EA3", CurrentYear, CarryOver, ECCC);
                Series Series1 = new Series
                {
                    Name = "EA3",
                    LegendText = "EA3",
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Int32
                };
                ChartSum.Series.Add(Series1);
                ChartSum.Series["EA3"].Points.DataBindXY(xValues, EA3);
            }
            if (MainProgram.Self.SDSumAllAction.ChartEA2())
            {
                decimal[] EA2 = Summ_AllActionFromGrid("EA2", CurrentYear, CarryOver, ECCC);
                Series Series3 = new Series
                {
                    Name = "EA2",
                    LegendText = "EA2",
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Int32
                };
                ChartSum.Series.Add(Series3);
                ChartSum.Series["EA2"].Points.DataBindXY(xValues, EA2);
            }
            if (MainProgram.Self.SDSumAllAction.ChartEA1())
            {
                decimal[] EA1 = Summ_AllActionFromGrid("EA1", CurrentYear, CarryOver, ECCC);
                Series Series2 = new Series
                {
                    Name = "EA1",
                    LegendText = "EA1",
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Int32
                };
                ChartSum.Series.Add(Series2);
                ChartSum.Series["EA1"].Points.DataBindXY(xValues, EA1);
            }
            if (MainProgram.Self.SDSumAllAction.ChartBU())
            {
                decimal[] BU = Summ_AllActionFromGrid("BU", CurrentYear, CarryOver, ECCC);
                Series Series1 = new Series
                {
                    Name = "BU",
                    LegendText = "BU",
                    ChartType = SeriesChartType.Column,
                    XValueType = ChartValueType.String,
                    YValueType = ChartValueType.Int32
                };
                ChartSum.Series.Add(Series1);
                ChartSum.Series["BU"].Points.DataBindXY(xValues, BU);
            }
        }

        private decimal[] Summ_AllActionFromGrid(string Rewizion, bool CurrentYear, bool CarryOver, bool ECCC)
        {
            decimal[] Sum = new decimal[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
            int Row = 0;
            DataGridViewRow TableCurrentRow;
            DataGridViewRow TableCarryRow;
            DataGridViewRow TableECCCRow;

            DataGridView Dg_CurrentYear = MainProgram.Self.SDSumAllAction.GetActual();
            DataGridView Dg_CarryOver = MainProgram.Self.SDSumAllAction.GetCarryOver();
            DataGridView Dg_ECCC = MainProgram.Self.SDSumAllAction.GetECCC();

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
                    if (TableCurrentRow.Cells[counter.ToString()].Value != null)
                    {
                        string Current = TableCurrentRow.Cells[counter.ToString()].Value.ToString();
                        if (Current != "")
                        {

                            Sum[counter - 1] = Sum[counter - 1] + decimal.Parse(Current) / 1000;
                        }
                    }
                }

                if (CarryOver)
                {
                    if (TableCarryRow.Cells[counter.ToString()].Value != null)
                    {
                        string Carry = TableCarryRow.Cells[counter.ToString()].Value.ToString();
                        if (Carry != "")
                        {

                            Sum[counter - 1] = Sum[counter - 1] + decimal.Parse(Carry) / 1000;
                        }
                    }
                }

                if (ECCC)
                {
                    if (TableECCCRow.Cells[counter.ToString()].Value != null)
                    {
                        string ECCCTab = TableECCCRow.Cells[counter.ToString()].Value.ToString();
                        if (ECCCTab != "")
                        {

                            Sum[counter - 1] = Sum[counter - 1] + decimal.Parse(ECCCTab) / 1000;
                        }
                    }
                }
            }

            return Sum;
        }
    }
}
