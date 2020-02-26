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
        private readonly string _Revision;
        private readonly string _Installation;
        private readonly string _Structure;
        private readonly decimal _Year;
        private readonly DataGridView _QuantityMonth;

        public StatisticQuantityMonthLoad(DataGridView QuantityMonth)
        {
            _Import = Data_Import.Singleton();
            _QuantityMonth = QuantityMonth;
            _Revision = MainProgram.Self.productionQuantityMonthView1.GetRevision();
            _Structure = MainProgram.Self.productionQuantityMonthView1.GetStructure();
            _Installation = MainProgram.Self.productionQuantityMonthView1.GetInstallation();
            _Year = MainProgram.Self.optionView.GetYear();

            LoadData_QuantityMonth();
        }

        private void LoadData_QuantityMonth()
        {
            DataTable Actual;
            DataTable Plan;

            Actual = ActualValue(false);
            Plan = ActualValue(true);

            ClearTable();

            foreach (DataRow Row in Actual.Rows)
            {
                for (int counter = StartRevision(); counter <= 12; counter++)
                {
                    if (Actual.Columns.Contains(counter.ToString() + "/" + _Year.ToString()))
                    {
                        if (_QuantityMonth.Rows[0].Cells[counter.ToString()].Value != null)
                            _QuantityMonth.Rows[0].Cells[counter.ToString()].Value = decimal.Parse(_QuantityMonth.Rows[0].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(Row[counter.ToString() + "/" + _Year.ToString()].ToString());
                        else
                            _QuantityMonth.Rows[0].Cells[counter.ToString()].Value = decimal.Parse(Row[counter.ToString() + "/" + _Year.ToString()].ToString());
                    }
                }
            }
            foreach (DataRow Row in Plan.Rows)
            {
                if (_Revision != "All")
                {
                    for (int counter = StartRevision(); counter <= 12; counter++)
                    {
                        if (Plan.Columns.Contains(_Revision + "/" + counter.ToString() + "/" + _Year.ToString()))
                        {
                            if (_QuantityMonth.Rows[1].Cells[counter.ToString()].Value != null)
                                _QuantityMonth.Rows[1].Cells[counter.ToString()].Value = decimal.Parse(_QuantityMonth.Rows[0].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(Row[_Revision + "/" + counter.ToString() + "/" + _Year.ToString()].ToString());
                            else
                                _QuantityMonth.Rows[1].Cells[counter.ToString()].Value = decimal.Parse(Row[_Revision + "/" + counter.ToString() + "/" + _Year.ToString()].ToString());
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

                        if (Plan.Columns.Contains(Rewizja + "/" + counter.ToString() + "/" + _Year.ToString()))
                        {
                            if (_QuantityMonth.Rows[1].Cells[counter.ToString()].Value != null)
                                _QuantityMonth.Rows[1].Cells[counter.ToString()].Value = decimal.Parse(_QuantityMonth.Rows[0].Cells[counter.ToString()].Value.ToString()) + decimal.Parse(Row[Rewizja + "/" + counter.ToString() + "/" + _Year.ToString()].ToString());
                            else
                                _QuantityMonth.Rows[1].Cells[counter.ToString()].Value = decimal.Parse(Row[Rewizja + "/" + counter.ToString() + "/" + _Year.ToString()].ToString());
                        }
                    }
                }
            }
            SumRow();
            Different();
        }

        private void SumRow()
        {
            decimal SumActual = 0;
            decimal SumPlan = 0;

            for (int counter = 0; counter < 12; counter++)
            {
                if (_QuantityMonth.Rows[0].Cells[counter].Value != null)
                    SumActual += decimal.Parse(_QuantityMonth.Rows[0].Cells[counter].Value.ToString());
                if (_QuantityMonth.Rows[1].Cells[counter].Value != null)
                    SumPlan += decimal.Parse(_QuantityMonth.Rows[1].Cells[counter].Value.ToString());
            }

            if (SumActual != 0)
                _QuantityMonth.Rows[0].Cells[12].Value = SumActual;
            if (SumPlan != 0)
                _QuantityMonth.Rows[1].Cells[12].Value = SumPlan;
        }

        private void Different()
        {

            for (int counter = 0; counter <= 12; counter++)
            {
                if (_QuantityMonth.Rows[0].Cells[counter].Value != null && _QuantityMonth.Rows[1].Cells[counter].Value != null)
                {
                    _QuantityMonth.Rows[2].Cells[counter].Value = decimal.Parse(_QuantityMonth.Rows[0].Cells[counter].Value.ToString()) - decimal.Parse(_QuantityMonth.Rows[1].Cells[counter].Value.ToString());
                    ColorTable(_QuantityMonth.Rows[2].Cells[counter]);
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
            for (int counter = 0; counter <= 12; counter++)
            {
                _QuantityMonth.Rows[0].Cells[counter].Value = null;
                _QuantityMonth.Rows[1].Cells[counter].Value = null;
                _QuantityMonth.Rows[2].Cells[counter].Value = null;
                _QuantityMonth.Rows[2].Cells[counter].Style.ForeColor = Color.FromArgb(0, 0, 0);
                _QuantityMonth.Rows[2].Cells[counter].Style.BackColor = Color.FromArgb(255, 255, 255);
            }
        }
        private int StartRevision()
        {
            if (_Revision == "All" || _Revision == "BU")
            {
                return 1;
            }
            else if (_Revision == "EA1")
            {
                return 3;
            }
            else if (_Revision == "EA2")
            {
                return 6;
            }
            else
            {
                return 9;
            }
        }

        private DataTable ActualValue(bool Estymacja)
        {
            DataTable SumPNC = new DataTable();
            DataTable ActualAllRow;
            DataRow Actual;

            if (Estymacja)
                _Import.Load_TxtToDataTable2(ref SumPNC, "SumPNCBU");
            else
                _Import.Load_TxtToDataTable2(ref SumPNC, "SumPNC");

            ActualAllRow = SumPNC.Clone();

            if (_Structure == _Installation)
            {
                Actual = SumPNC.Select(string.Format("PNC LIKE '%{0}%'", "All")).First();
                ActualAllRow.Rows.Add(Actual.ItemArray);
            }
            else
            {
                if (_Installation == "All")
                {
                    Actual = SumPNC.Select(string.Format("PNC LIKE '%{0}%'", _Structure)).First();
                    ActualAllRow.Rows.Add(Actual.ItemArray);
                }
                else if (_Structure == "All")
                {
                    Actual = SumPNC.Select(string.Format("PNC LIKE '%{0}%'", "DMD_" + _Installation)).First();
                    ActualAllRow.Rows.Add(Actual.ItemArray);
                    Actual = SumPNC.Select(string.Format("PNC LIKE '%{0}%'", "D45_" + _Installation)).First();
                    ActualAllRow.Rows.Add(Actual.ItemArray);
                }
                else
                {
                    Actual = SumPNC.Select(string.Format("PNC LIKE '%{0}%'", _Structure + "_" + _Installation)).First();
                    ActualAllRow.Rows.Add(Actual.ItemArray);
                }
            }

            return ActualAllRow;
        }
    }
}
