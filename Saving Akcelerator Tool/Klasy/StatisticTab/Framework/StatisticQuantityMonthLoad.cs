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
    class StatisticQuantityMonthLoad
    {
        private static Data_Import _Import;

        public StatisticQuantityMonthLoad()
        {
            _Import = Data_Import.Singleton();

            LoadData_QuantityMonth();
        }

        private void LoadData_QuantityMonth()
        {
            DataTable Actual;
            DataTable Plan;

            string Revision = ((ComboBox)MainProgram.Self.TabControl.Controls.Find("comb_StatisicQuantityMonthRev", true).First()).SelectedItem.ToString();
            string Structure = ((ComboBox)MainProgram.Self.TabControl.Controls.Find("comb_StatisicQuantityMonthStructure", true).First()).SelectedItem.ToString();
            string Installation = ((ComboBox)MainProgram.Self.TabControl.Controls.Find("comb_StatisicQuantityMonthInstalation", true).First()).SelectedItem.ToString();
            decimal Year = ((NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_StatisticYearOption", true).First()).Value;

            DataGridView QuantityMonth = (DataGridView)MainProgram.Self.TabControl.Controls.Find("GDV_StatisticQuantityMonth", true).First();

            Actual = ActualValue(Structure, Installation, false);
            Plan = ActualValue(Structure, Installation, true);

            ClearTable();

            foreach (DataRow Row in Actual.Rows)
            {
                for (int counter = StartRevision(Revision); counter <= 12; counter++)
                {
                    if (Actual.Columns.Contains(counter.ToString() + "/" + Year.ToString()))
                    {
                        if (QuantityMonth.Rows[0].Cells[counter.ToString()].Value != null)
                            QuantityMonth.Rows[0].Cells[counter.ToString()].Value = decimal.Parse(QuantityMonth.Rows[0].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(Row[counter.ToString() + "/" + Year.ToString()].ToString());
                        else
                            QuantityMonth.Rows[0].Cells[counter.ToString()].Value = decimal.Parse(Row[counter.ToString() + "/" + Year.ToString()].ToString());
                    }
                }
            }
            foreach (DataRow Row in Plan.Rows)
            {
                if (Revision != "All")
                {
                    for (int counter = StartRevision(Revision); counter <= 12; counter++)
                    {
                        if (Plan.Columns.Contains(Revision + "/" + counter.ToString() + "/" + Year.ToString()))
                        {
                            if (QuantityMonth.Rows[1].Cells[counter.ToString()].Value != null)
                                QuantityMonth.Rows[1].Cells[counter.ToString()].Value = decimal.Parse(QuantityMonth.Rows[0].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(Row[Revision + "/" + counter.ToString() + "/" + Year.ToString()].ToString());
                            else
                                QuantityMonth.Rows[1].Cells[counter.ToString()].Value = decimal.Parse(Row[Revision + "/" + counter.ToString() + "/" + Year.ToString()].ToString());
                        }
                    }
                }
                else
                {
                    for (int counter = 1; counter <= 12; counter++)
                    {
                        string Rewizja;
                        if (counter < 3)
                            Rewizja = "BU";
                        else if (counter < 6)
                            Rewizja = "EA1";
                        else if (counter < 9)
                            Rewizja = "EA2";
                        else
                            Rewizja = "EA3";

                        if (Plan.Columns.Contains(Rewizja + "/" + counter.ToString() + "/" + Year.ToString()))
                        {
                            if (QuantityMonth.Rows[1].Cells[counter.ToString()].Value != null)
                                QuantityMonth.Rows[1].Cells[counter.ToString()].Value = decimal.Parse(QuantityMonth.Rows[0].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(Row[Rewizja + "/" + counter.ToString() + "/" + Year.ToString()].ToString());
                            else
                                QuantityMonth.Rows[1].Cells[counter.ToString()].Value = decimal.Parse(Row[Rewizja + "/" + counter.ToString() + "/" + Year.ToString()].ToString());
                        }
                    }
                }
            }
            SumRow();
            Different();
        }

        private void SumRow()
        {
            DataGridView QuantityMonth = (DataGridView)MainProgram.Self.TabControl.Controls.Find("GDV_StatisticQuantityMonth", true).First();



            for(int counter =0; counter<12; counter++)
            {
                //QuantityMonth[]
            }
        }

        private void Different()
        {
            DataGridView QuantityMonth = (DataGridView)MainProgram.Self.TabControl.Controls.Find("GDV_StatisticQuantityMonth", true).First();

            for (int counter = 0; counter <= 12; counter++)
            {
                if (QuantityMonth.Rows[0].Cells[counter].Value != null && QuantityMonth.Rows[1].Cells[counter].Value != null)
                {
                    QuantityMonth.Rows[2].Cells[counter].Value = decimal.Parse(QuantityMonth.Rows[0].Cells[counter].Value.ToString()) - decimal.Parse(QuantityMonth.Rows[1].Cells[counter].Value.ToString());
                    ColorTable(QuantityMonth.Rows[2].Cells[counter]);
                }
            }
        }

        private void ColorTable(DataGridViewCell Cell)
        {
            if (decimal.Parse(Cell.Value.ToString()) > 0)
            {
                Cell.Style.ForeColor = Color.FromArgb(0, 97, 0);
                Cell.Style.BackColor = Color.FromArgb(198, 239, 206);
            }
            else if (decimal.Parse(Cell.Value.ToString()) < 0)
            {
                Cell.Style.ForeColor = Color.FromArgb(156, 0, 6);
                Cell.Style.BackColor = Color.FromArgb(255, 199, 206);
            }
        }

        private void ClearTable()
        {
            DataGridView QuantityMonth = (DataGridView)MainProgram.Self.TabControl.Controls.Find("GDV_StatisticQuantityMonth", true).First();

            for (int counter = 0; counter <= 12; counter++)
            {
                QuantityMonth.Rows[0].Cells[counter].Value = null;
                QuantityMonth.Rows[1].Cells[counter].Value = null;
                QuantityMonth.Rows[2].Cells[counter].Value = null;
                QuantityMonth.Rows[2].Cells[counter].Style.ForeColor = Color.FromArgb(0, 0, 0);
                QuantityMonth.Rows[2].Cells[counter].Style.BackColor = Color.FromArgb(255, 255, 255);
            }
        }
        private int StartRevision(string Rewizion)
        {
            if (Rewizion == "All" || Rewizion == "BU")
            {
                return 1;
            }
            else if (Rewizion == "EA1")
            {
                return 3;
            }
            else if (Rewizion == "EA2")
            {
                return 6;
            }
            else
            {
                return 9;
            }
        }

        private DataTable ActualValue(string Structure, string Instalation, bool Estymacja)
        {
            DataTable SumPNC = new DataTable();
            DataTable ActualAllRow;
            DataRow Actual;
            string Name;

            if (Estymacja)
                _Import.Load_TxtToDataTable2(ref SumPNC, "SumPNCBU");
            else
                _Import.Load_TxtToDataTable2(ref SumPNC, "SumPNC");

            ActualAllRow = SumPNC.Clone();

            if (Structure == Instalation)
            {
                Actual = SumPNC.Select(string.Format("PNC LIKE '%{0}%'", "All")).First();
                ActualAllRow.Rows.Add(Actual.ItemArray);
            }
            else
            {
                if (Instalation == "All")
                {
                    Actual = SumPNC.Select(string.Format("PNC LIKE '%{0}%'", Structure)).First();
                    ActualAllRow.Rows.Add(Actual.ItemArray);
                }
                else if (Structure == "All")
                {
                    Actual = SumPNC.Select(string.Format("PNC LIKE '%{0}%'", "DMD_" + Instalation)).First();
                    ActualAllRow.Rows.Add(Actual.ItemArray);
                    Actual = SumPNC.Select(string.Format("PNC LIKE '%{0}%'", "D45_" + Instalation)).First();
                    ActualAllRow.Rows.Add(Actual.ItemArray);
                }
                else
                {
                    Actual = SumPNC.Select(string.Format("PNC LIKE '%{0}%'", Structure + "_" + Instalation)).First();
                    ActualAllRow.Rows.Add(Actual.ItemArray);
                }
            }

            return ActualAllRow;
        }
    }
}
