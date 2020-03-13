using Saving_Accelerator_Tool.Controllers;
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
    class StatisticQuantityLoad
    {
        public StatisticQuantityLoad(DataGridView Quantity)
        {
            decimal _Year = MainProgram.Self.optionView.GetYear();

            double Actual;
            double BU;
            double EA1;
            double EA2;
            double EA3;

            var ActualItems = PNCMonthlyQuantity.LoadByYear(Convert.ToInt32(_Year));

            Actual = SumActual(ActualItems);

            var AllItems = PNCRevisionQuantity.LoadByYear(Convert.ToInt32(_Year));

            BU = SumRevision(AllItems.Where(u => u.Revision == "BU").ToList(), ActualItems.Where(u => u.Month < 0).ToList());
            EA1 = SumRevision(AllItems.Where(u => u.Revision == "EA1").ToList(), ActualItems.Where(u => u.Month < 3).ToList());
            EA2 = SumRevision(AllItems.Where(u => u.Revision == "EA2").ToList(), ActualItems.Where(u => u.Month < 6).ToList());
            EA3 = SumRevision(AllItems.Where(u => u.Revision == "EA3").ToList(), ActualItems.Where(u => u.Month < 9).ToList());

            if (BU != 0)
                Quantity.Rows[0].Cells[0].Value = BU;
            if (EA1 != 0)
                Quantity.Rows[1].Cells[0].Value = EA1;
            if (EA2 != 0)
                Quantity.Rows[2].Cells[0].Value = EA2;
            if (EA3 != 0)
                Quantity.Rows[3].Cells[0].Value = EA3;
            if (Actual != 0)
                Quantity.Rows[4].Cells[0].Value = Actual;

            if (BU != 0 && EA1 != 0)
                AddData(Quantity.Rows[1].Cells["BU"], EA1 - BU);

            if (BU != 0 && EA2 != 0)
                AddData(Quantity.Rows[2].Cells["BU"], EA2 - BU);
            if (EA1 != 0 && EA2 != 0)
                AddData(Quantity.Rows[2].Cells["EA1"], EA2 - EA1);

            if (BU != 0 && EA3 != 0)
                AddData(Quantity.Rows[3].Cells["BU"], EA3 - BU);
            if (EA1 != 0 && EA3 != 0)
                AddData(Quantity.Rows[3].Cells["EA1"], EA3 - EA1);
            if (EA2 != 0 && EA3 != 0)
                AddData(Quantity.Rows[3].Cells["EA2"], EA3 - EA2);

            if (BU != 0 && Actual != 0)
                AddData(Quantity.Rows[4].Cells["BU"], Actual - BU);
            if (EA1 != 0 && Actual != 0)
                AddData(Quantity.Rows[4].Cells["EA1"], Actual - EA1);
            if (EA2 != 0 && Actual != 0)
                AddData(Quantity.Rows[4].Cells["EA2"], Actual - EA2);
            if (EA3 != 0 && Actual != 0)
                AddData(Quantity.Rows[4].Cells["EA3"], Actual - EA3);
        }

        private void AddData(DataGridViewCell Cell, double Delta)
        {
            Cell.Value = Delta;

            if (Delta > 0)
            {
                Cell.Style.ForeColor = Color.FromArgb(0, 97, 0);
                Cell.Style.BackColor = Color.FromArgb(198, 239, 206);
            }
            else if (Delta < 0)
            {
                Cell.Style.ForeColor = Color.FromArgb(156, 0, 6);
                Cell.Style.BackColor = Color.FromArgb(255, 199, 206);
            }
        }

        private double SumActual(IEnumerable<PNCMonthlyDB> AllItems)
        {
            double Actual = 0;

            foreach (var Iteam in AllItems)
            {
                Actual += Iteam.Value;
            }

            return Actual;
        }

        private double SumRevision(IEnumerable<PNCRevisionDB> ListRevision, IEnumerable<PNCMonthlyDB> ListActual)
        {
            double Sum = 0;

            if (ListRevision.Count() == 0)
                return 0;

            foreach (var Item in ListRevision)
            {
                Sum += Item.Value;
            }

            if (ListActual.Count() != 0)
            {
                foreach (var Item in ListActual)
                {
                    Sum += Item.Value;
                }
            }

            return Sum;
        }
    }
}
