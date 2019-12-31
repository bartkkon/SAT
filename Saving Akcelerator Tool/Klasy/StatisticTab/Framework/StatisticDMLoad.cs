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
    public class StatisticDMLoad
    {
        Data_Import _Import;


        public StatisticDMLoad()
        {
            _Import = Data_Import.Singleton();

            LoadData_DM();
        }

        private void LoadData_DM()
        {
            DataGridView DM = (DataGridView)MainProgram.Self.TabControl.Controls.Find("DGV_StatisticDM", true).First();
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_StatisticYearOption", true).First()).Value;
            decimal Kurs;

            DataTable Table = new DataTable();
            DataRow Data = null;

            _Import.Load_TxtToDataTable2(ref Table, "Kurs");

            ClearDGVForDM(DM);

            Data = Table.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).FirstOrDefault();

            if (Data != null)
            {
                Kurs = CheckExchangeRate(Data);

                if (Kurs == 0)
                {
                    return;
                }

                string[] DMRevision = Data["DM"].ToString().Split('/');

                if (DMRevision[0] != "")
                {
                    DM.Rows[0].Cells["DM"].Value = Math.Round(decimal.Parse(DMRevision[0]) / Kurs, 0, MidpointRounding.AwayFromZero);
                }
                if (DMRevision[1] != "")
                {
                    DM.Rows[1].Cells["DM"].Value = Math.Round(decimal.Parse(DMRevision[1]) / Kurs, 0, MidpointRounding.AwayFromZero);
                }
                if (DMRevision[2] != "")
                {
                    DM.Rows[2].Cells["DM"].Value = Math.Round(decimal.Parse(DMRevision[2]) / Kurs, 0, MidpointRounding.AwayFromZero);
                }
                if (DMRevision[3] != "")
                {
                    DM.Rows[3].Cells["DM"].Value = Math.Round(decimal.Parse(DMRevision[3]) / Kurs, 0, MidpointRounding.AwayFromZero);
                }
                if (DMRevision[4] != "")
                {
                    DM.Rows[4].Cells["DM"].Value = Math.Round(decimal.Parse(DMRevision[4]) / Kurs, 0, MidpointRounding.AwayFromZero);
                }

                CalcDelta(DM);
            }
        }

        private decimal CheckExchangeRate(DataRow Data)
        {
            decimal Exchenage = 0;
            ComboBox ExchangeCombo = (ComboBox)MainProgram.Self.TabControl.Controls.Find("cb_Statistic ExchangeRate", true).First();

            switch (ExchangeCombo.SelectedIndex)
            {
                case 0:
                    Exchenage = 1;
                    break;
                case 1:
                    if (Data["EURO"].ToString() != "")
                        Exchenage = decimal.Parse(Data["EURO"].ToString());
                    else
                        Exchenage = 0;
                    break;
                case 2:
                    if (Data["USD"].ToString() != "")
                        Exchenage = decimal.Parse(Data["USD"].ToString());
                    else
                        Exchenage = 0;
                    break;
                case 3:
                    if (Data["SEK"].ToString() != "")
                        Exchenage = decimal.Parse(Data["SEK"].ToString());
                    else
                        Exchenage = 0;
                    break;
                default:
                    Exchenage = 1;
                    break;
            }

            return Exchenage;
        }

        private void ClearDGVForDM(DataGridView dM)
        {
            for (int counter = 0; counter < 5; counter++)
            {
                dM.Rows[counter].Cells["DM"].Value = null;
            }

            for (int counter = 1; counter <= 4; counter++)
            {
                ClearCells(dM.Rows[counter].Cells["BU"]);
                if (counter >= 2)
                {
                    ClearCells(dM.Rows[counter].Cells["EA1"]);
                }
                if (counter >= 3)
                {
                    ClearCells(dM.Rows[counter].Cells["EA2"]);
                }
                if (counter == 4)
                {
                    ClearCells(dM.Rows[counter].Cells["EA3"]);
                }
            }
        }

        private void CalcDelta(DataGridView DMTable)
        {
            decimal BU = 0;
            decimal EA1 = 0;
            decimal EA2 = 0;
            decimal EA3 = 0;
            decimal EA4 = 0;

            if (DMTable.Rows[0].Cells["DM"].Value != null)
            {
                BU = decimal.Parse(DMTable.Rows[0].Cells["DM"].Value.ToString());

                if (DMTable.Rows[1].Cells["DM"].Value != null)
                {
                    EA1 = decimal.Parse(DMTable.Rows[1].Cells["DM"].Value.ToString());
                    DMTable.Rows[1].Cells["BU"].Value = EA1 - BU;
                    ColoringCells(DMTable.Rows[1].Cells["BU"]);
                }
                if (DMTable.Rows[2].Cells["DM"].Value != null)
                {
                    EA2 = decimal.Parse(DMTable.Rows[2].Cells["DM"].Value.ToString());
                    DMTable.Rows[2].Cells["BU"].Value = EA2 - BU;
                    ColoringCells(DMTable.Rows[2].Cells["BU"]);
                    DMTable.Rows[2].Cells["EA1"].Value = EA2 - EA1;
                    ColoringCells(DMTable.Rows[2].Cells["EA1"]);
                }
                if (DMTable.Rows[3].Cells["DM"].Value != null)
                {
                    EA3 = decimal.Parse(DMTable.Rows[3].Cells["DM"].Value.ToString());
                    DMTable.Rows[3].Cells["BU"].Value = EA3 - BU;
                    ColoringCells(DMTable.Rows[3].Cells["BU"]);
                    DMTable.Rows[3].Cells["EA1"].Value = EA3 - EA1;
                    ColoringCells(DMTable.Rows[3].Cells["EA1"]);
                    DMTable.Rows[3].Cells["EA2"].Value = EA3 - EA2;
                    ColoringCells(DMTable.Rows[3].Cells["EA2"]);
                }
                if (DMTable.Rows[4].Cells["DM"].Value != null)
                {
                    EA4 = decimal.Parse(DMTable.Rows[4].Cells["DM"].Value.ToString());
                    DMTable.Rows[4].Cells["BU"].Value = EA4 - BU;
                    ColoringCells(DMTable.Rows[4].Cells["BU"]);
                    DMTable.Rows[4].Cells["EA1"].Value = EA4 - EA1;
                    ColoringCells(DMTable.Rows[4].Cells["EA1"]);
                    DMTable.Rows[4].Cells["EA2"].Value = EA4 - EA2;
                    ColoringCells(DMTable.Rows[4].Cells["EA2"]);
                    DMTable.Rows[4].Cells["EA3"].Value = EA4 - EA3;
                    ColoringCells(DMTable.Rows[4].Cells["EA3"]);

                }
            }
        }

        private void ColoringCells(DataGridViewCell DMCells)
        {
            decimal Value = decimal.Parse(DMCells.Value.ToString());

            if (Value > 0)
            {
                DMCells.Style.ForeColor = Color.FromArgb(0, 97, 0);
                DMCells.Style.BackColor = Color.FromArgb(198, 239, 206);
            }
            else if (Value < 0)
            {
                DMCells.Style.ForeColor = Color.FromArgb(156, 0, 6);
                DMCells.Style.BackColor = Color.FromArgb(255, 199, 206);
            }
            else
            {
                DMCells.Style.ForeColor = Color.FromArgb(0, 0, 0);
                DMCells.Style.BackColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void ClearCells(DataGridViewCell DMCells)
        {
            DMCells.Value = null;
            DMCells.Style.ForeColor = Color.FromArgb(0, 0, 0);
            DMCells.Style.BackColor = Color.FromArgb(255, 255, 255);
        }
    }
}
