using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab.Framework
{
    class StatisticQuantityLoad
    {
        Data_Import _Import;


        public StatisticQuantityLoad()
        {
            _Import = Data_Import.Singleton();

            LoadData_Quantity();
        }

        private void LoadData_Quantity()
        {
            DataGridView Quantity = (DataGridView)MainProgram.Self.TabControl.Controls.Find("DGV_StatisticQuantity", true).First();
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_StatisticYearOption", true).First()).Value;
            decimal BU = 0;
            decimal EA1 = 0;
            decimal EA2 = 0;
            decimal EA3 = 0;
            decimal EA4 = 0;

            DataTable QuantityBU = new DataTable();
            DataTable QuantityActual = new DataTable();
            DataRow BUData = null;
            DataRow Actual = null;

            _Import.Load_TxtToDataTable2(ref QuantityBU, "SumPNCBU");
            _Import.Load_TxtToDataTable2(ref QuantityActual, "SumPNC");

            ClearDGVForQuantity(Quantity);

            BUData = QuantityBU.Select(string.Format("PNC LIKE '%{0}%'", "All")).First();
            Actual = QuantityActual.Select(string.Format("PNC LIKE '%{0}%'", "All")).First();

            if (Actual != null)
            {
                for (int counter = 1; counter <= 12; counter++)
                {
                    if (QuantityActual.Columns.Contains(counter.ToString() + "/" + Year.ToString()))
                    {
                        decimal Help = decimal.Parse(Actual[counter.ToString() + "/" + Year.ToString()].ToString());

                        EA4 += Help;

                        if (counter < 3)
                        {
                            EA1 += Help;
                        }
                        if (counter < 6)
                        {
                            EA2 += Help;
                        }
                        if (counter < 9)
                        {
                            EA3 += Help;
                        }
                    }
                }
            }

            if (BUData != null)
            {
                if (QuantityBU.Columns.Contains("BU/1/" + Year.ToString()))
                {
                    for (int counter = 1; counter <= 12; counter++)
                    {
                        BU += decimal.Parse(BUData["BU/" + counter.ToString() + "/" + Year.ToString()].ToString());
                    }
                    Quantity.Rows[0].Cells["Q"].Value = BU;
                }
                if (QuantityBU.Columns.Contains("EA1/3/" + Year.ToString()))
                {
                    for (int counter = 3; counter <= 12; counter++)
                    {
                        EA1 += decimal.Parse(BUData["EA1/" + counter.ToString() + "/" + Year.ToString()].ToString());
                    }
                    Quantity.Rows[1].Cells["Q"].Value = EA1;
                }
                if (QuantityBU.Columns.Contains("EA2/6/" + Year.ToString()))
                {
                    for (int counter = 6; counter <= 12; counter++)
                    {
                        EA2 += decimal.Parse(BUData["EA2/" + counter.ToString() + "/" + Year.ToString()].ToString());
                    }
                    Quantity.Rows[2].Cells["Q"].Value = EA2;
                }
                if (QuantityBU.Columns.Contains("EA3/9/" + Year.ToString()))
                {
                    for (int counter = 9; counter <= 12; counter++)
                    {
                        EA3 += decimal.Parse(BUData["EA3/" + counter.ToString() + "/" + Year.ToString()].ToString());
                    }
                    Quantity.Rows[3].Cells["Q"].Value = EA3;
                }
                if (EA4 != 0)
                {
                    Quantity.Rows[4].Cells["Q"].Value = EA4;
                }
                CalcDelta(Quantity);
            }
        }

        private void ClearDGVForQuantity(DataGridView Quantity)
        {
            for (int counter = 0; counter < 5; counter++)
            {
                Quantity.Rows[counter].Cells["Q"].Value = null;
            }

            for (int counter = 1; counter <= 4; counter++)
            {
                ClearCells(Quantity.Rows[counter].Cells["BU"]);
                if (counter >= 2)
                {
                    ClearCells(Quantity.Rows[counter].Cells["EA1"]);
                }
                if (counter >= 3)
                {
                    ClearCells(Quantity.Rows[counter].Cells["EA2"]);
                }
                if (counter == 4)
                {
                    ClearCells(Quantity.Rows[counter].Cells["EA3"]);
                }
            }
        }

        private void CalcDelta(DataGridView QuantityTable)
        {
            decimal BU = 0;
            decimal EA1 = 0;
            decimal EA2 = 0;
            decimal EA3 = 0;
            decimal EA4 = 0;

            if (QuantityTable.Rows[0].Cells["Q"].Value != null)
            {
                BU = decimal.Parse(QuantityTable.Rows[0].Cells["Q"].Value.ToString());

                if (QuantityTable.Rows[1].Cells["Q"].Value != null)
                {
                    EA1 = decimal.Parse(QuantityTable.Rows[1].Cells["Q"].Value.ToString());
                    QuantityTable.Rows[1].Cells["BU"].Value = EA1 - BU;
                    ColoringCells(QuantityTable.Rows[1].Cells["BU"]);
                }
                if (QuantityTable.Rows[2].Cells["Q"].Value != null)
                {
                    EA2 = decimal.Parse(QuantityTable.Rows[2].Cells["Q"].Value.ToString());
                    QuantityTable.Rows[2].Cells["BU"].Value = EA2 - BU;
                    ColoringCells(QuantityTable.Rows[2].Cells["BU"]);
                    QuantityTable.Rows[2].Cells["EA1"].Value = EA2 - EA1;
                    ColoringCells(QuantityTable.Rows[2].Cells["EA1"]);
                }
                if (QuantityTable.Rows[3].Cells["Q"].Value != null)
                {
                    EA3 = decimal.Parse(QuantityTable.Rows[3].Cells["Q"].Value.ToString());
                    QuantityTable.Rows[3].Cells["BU"].Value = EA3 - BU;
                    ColoringCells(QuantityTable.Rows[3].Cells["BU"]);
                    QuantityTable.Rows[3].Cells["EA1"].Value = EA3 - EA1;
                    ColoringCells(QuantityTable.Rows[3].Cells["EA1"]);
                    QuantityTable.Rows[3].Cells["EA2"].Value = EA3 - EA2;
                    ColoringCells(QuantityTable.Rows[3].Cells["EA2"]);
                }
                if (QuantityTable.Rows[4].Cells["Q"].Value != null)
                {
                    EA4 = decimal.Parse(QuantityTable.Rows[4].Cells["Q"].Value.ToString());
                    if (QuantityTable.Rows[0].Cells["Q"].Value != null)
                    {
                        QuantityTable.Rows[4].Cells["BU"].Value = EA4 - BU;
                        ColoringCells(QuantityTable.Rows[4].Cells["BU"]);
                    }
                    if (QuantityTable.Rows[1].Cells["Q"].Value != null)
                    {
                        QuantityTable.Rows[4].Cells["EA1"].Value = EA4 - EA1;
                        ColoringCells(QuantityTable.Rows[4].Cells["EA1"]);
                    }
                    if (QuantityTable.Rows[2].Cells["Q"].Value != null)
                    {
                        QuantityTable.Rows[4].Cells["EA2"].Value = EA4 - EA2;
                        ColoringCells(QuantityTable.Rows[4].Cells["EA2"]);
                    }
                    if (QuantityTable.Rows[3].Cells["Q"].Value != null)
                    {
                        QuantityTable.Rows[4].Cells["EA3"].Value = EA4 - EA3;
                        ColoringCells(QuantityTable.Rows[4].Cells["EA3"]);
                    }
                }
            }
        }

        private void ColoringCells(DataGridViewCell QuantityCells)
        {
            decimal Value = decimal.Parse(QuantityCells.Value.ToString());

            if (Value > 0)
            {
                QuantityCells.Style.ForeColor = Color.FromArgb(0, 97, 0);
                QuantityCells.Style.BackColor = Color.FromArgb(198, 239, 206);
            }
            else if (Value < 0)
            {
                QuantityCells.Style.ForeColor = Color.FromArgb(156, 0, 6);
                QuantityCells.Style.BackColor = Color.FromArgb(255, 199, 206);
            }
            else
            {
                QuantityCells.Style.ForeColor = Color.FromArgb(0, 0, 0);
                QuantityCells.Style.BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void ClearCells(DataGridViewCell QuantityCells)
        {
            QuantityCells.Value = null;
            QuantityCells.Style.ForeColor = Color.FromArgb(0, 0, 0);
            QuantityCells.Style.BackColor = Color.FromArgb(255, 255, 255);
        }
    }
}
