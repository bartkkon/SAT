using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Controllers.AdminTab;
using Saving_Accelerator_Tool.Model;
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
        private readonly string _Revision;
        private readonly string _Installation;
        private readonly string _Structure;
        private readonly decimal _Year;
        private readonly DataGridView _QuantityMonth;

        public StatisticQuantityMonthLoad(DataGridView QuantityMonth)
        {
            _QuantityMonth = QuantityMonth;
            _Revision = MainProgram.Self.ProductionQuantityMonthView.GetRevision();
            _Structure = MainProgram.Self.ProductionQuantityMonthView.GetStructure();
            _Installation = MainProgram.Self.ProductionQuantityMonthView.GetInstallation();
            _Year = MainProgram.Self.optionView.GetYear();

            MainProgram.Self.ProductionQuantityMonthView.ClearDataGridView();
            LoadData_QuantityMonth_Actual();
            LoadData_QuantityMonth_Revision();
            SumTable();
            Different();
        }

        private void Different()
        {
            for (int Column = 0; Column <= 12; Column++)
            {
                if (_QuantityMonth.Rows[0].Cells[Column].Value != null && _QuantityMonth.Rows[1].Cells[Column].Value != null)
                {
                    _QuantityMonth.Rows[2].Cells[Column].Value = Convert.ToDouble(_QuantityMonth.Rows[0].Cells[Column].Value) - Convert.ToDouble(_QuantityMonth.Rows[1].Cells[Column].Value);
                    if (Convert.ToDouble(_QuantityMonth.Rows[2].Cells[Column].Value) > 0)
                    {
                        _QuantityMonth.Rows[2].Cells[Column].Style.ForeColor = Color.FromArgb(0, 97, 0);
                        _QuantityMonth.Rows[2].Cells[Column].Style.BackColor = Color.FromArgb(198, 239, 206);
                    }
                    else if (Convert.ToDouble(_QuantityMonth.Rows[2].Cells[Column].Value) < 0)
                    {
                        _QuantityMonth.Rows[2].Cells[Column].Style.ForeColor = Color.FromArgb(156, 0, 6);
                        _QuantityMonth.Rows[2].Cells[Column].Style.BackColor = Color.FromArgb(255, 199, 206);
                    }
                }
            }
        }

        private void SumTable()
        {
            double SumActual = 0;
            double SumRevision = 0;

            for (int Column = 0; Column < 12; Column++)
            {
                if (_QuantityMonth.Rows[0].Cells[Column].Value != null)
                    SumActual += Convert.ToDouble(_QuantityMonth.Rows[0].Cells[Column].Value);

                if (_QuantityMonth.Rows[1].Cells[Column].Value != null)
                    SumRevision += Convert.ToDouble(_QuantityMonth.Rows[1].Cells[Column].Value);
            }

            if (SumActual != 0)
                _QuantityMonth.Rows[0].Cells["Sum"].Value = SumActual;
            if (SumRevision != 0)
                _QuantityMonth.Rows[1].Cells["Sum"].Value = SumRevision;
        }

        private void LoadData_QuantityMonth_Actual()
        {
            var Actual = SumMonthlyController.LoadByYear(Convert.ToInt32(_Year));
            if (_Structure != "All")
                Actual = Actual.Where(u => u.Platform == _Structure).ToList();

            if (_Installation != "All")
                Actual = Actual.Where(u => u.Installation == _Installation).ToList();

            for (int Month = 1; Month <= 12; Month++)
            {
                var MonthActual = Actual.Where(u => u.Month == Month).ToList();

                if (MonthActual.Count() != 0)
                {
                    double Sum = 0;
                    foreach (var Row in MonthActual)
                    {
                        Sum += Row.Value;
                    }
                    _QuantityMonth.Rows[0].Cells[Month.ToString()].Value = Sum;
                }
            }
        }

        private void LoadData_QuantityMonth_Revision()
        {
            int StartMonth;
            int FinishMonth;

            var Revision = SumRevisionController.LoadByYear(Convert.ToInt32(_Year));

            if (_Structure != "All")
                Revision = Revision.Where(u => u.Platform == _Structure).ToList();

            if (_Installation != "All")
                Revision = Revision.Where(u => u.Installation == _Installation).ToList();

            if (_Revision == "BU")
            {
                StartMonth = 1;
                FinishMonth = 12;
                LoadRevision(StartMonth, FinishMonth, Revision.Where(u => u.Revision == "BU").ToList());
            }
            else if (_Revision == "EA1")
            {
                StartMonth = 3;
                FinishMonth = 12;
                LoadRevision(StartMonth, FinishMonth, Revision.Where(u => u.Revision == "EA1").ToList());
            }
            else if (_Revision == "EA2")
            {
                StartMonth = 6;
                FinishMonth = 12;
                LoadRevision(StartMonth, FinishMonth, Revision.Where(u => u.Revision == "EA2").ToList());
            }
            else if (_Revision == "EA3")
            {
                StartMonth = 9;
                FinishMonth = 12;
                LoadRevision(StartMonth, FinishMonth, Revision.Where(u => u.Revision == "EA3").ToList());
            }
            else if (_Revision == "All")
            {
                StartMonth = 1;
                FinishMonth = 2;
                LoadRevision(StartMonth, FinishMonth, Revision.Where(u => u.Revision == "BU").ToList());
                StartMonth = 3;
                FinishMonth = 5;
                LoadRevision(StartMonth, FinishMonth, Revision.Where(u => u.Revision == "EA1").ToList());
                StartMonth = 6;
                FinishMonth = 9;
                LoadRevision(StartMonth, FinishMonth, Revision.Where(u => u.Revision == "EA2").ToList());
                StartMonth = 9;
                FinishMonth = 12;
                LoadRevision(StartMonth, FinishMonth, Revision.Where(u => u.Revision == "EA3").ToList());
            }
        }

        private void LoadRevision(int startMonth, int finishMonth, List<SumRevisionQuantityDB> list)
        {
            for (int Month = startMonth; Month <= finishMonth; Month++)
            {
                var MonthList = list.Where(u => u.Month == Month).ToList();
                if (MonthList.Count() != 0)
                {
                    double Sum = 0;
                    foreach (var One in MonthList)
                    {
                        Sum += One.Value;
                    }
                    _QuantityMonth.Rows[1].Cells[Month.ToString()].Value = Sum;
                }
            }
        }
    }
}
