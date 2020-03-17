using Saving_Accelerator_Tool.Controllers;
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
        public StatisticDMLoad(DataGridView DM, string Kurs)
        {
            decimal _Year = MainProgram.Self.optionView.GetYear();

            double EA4;
            double BU;
            double EA1;
            double EA2;
            double EA3;
            double Rate =1;

            var ActualItems = TargetsCoinsController.Load_Year(Convert.ToInt32(_Year));

            if (Kurs == "EUR")
                Rate = ActualItems.First().Euro;
            else if (Kurs == "USD")
                Rate = ActualItems.First().USD;
            else if (Kurs == "SEK")
                Rate = ActualItems.First().SEK;

            if (ActualItems.Count() == 0)
                return;

            BU = ActualItems.First().DM_BU / Rate;
            EA1 = ActualItems.First().DM_EA1 / Rate;
            EA2 = ActualItems.First().DM_EA2 / Rate;
            EA3 = ActualItems.First().DM_EA3 / Rate;
            EA4 = ActualItems.First().DM_EA4 / Rate;

            if (BU != 0)
                DM.Rows[0].Cells[0].Value = BU;
            if (EA1 != 0)
                DM.Rows[1].Cells[0].Value = EA1;
            if (EA2 != 0)
                DM.Rows[2].Cells[0].Value = EA2;
            if (EA3 != 0)
                DM.Rows[3].Cells[0].Value = EA3;
            if (EA4 != 0)
                DM.Rows[4].Cells[0].Value = EA4;

            if (BU != 0 && EA1 != 0)
                AddData(DM.Rows[1].Cells["BU"], EA1 - BU);

            if (BU != 0 && EA2 != 0)
                AddData(DM.Rows[2].Cells["BU"], EA2 - BU);
            if (EA1 != 0 && EA2 != 0)
                AddData(DM.Rows[2].Cells["EA1"], EA2 - EA1);

            if (BU != 0 && EA3 != 0)
                AddData(DM.Rows[3].Cells["BU"], EA3 - BU);
            if (EA1 != 0 && EA3 != 0)
                AddData(DM.Rows[3].Cells["EA1"], EA3 - EA1);
            if (EA2 != 0 && EA3 != 0)
                AddData(DM.Rows[3].Cells["EA2"], EA3 - EA2);

            if (BU != 0 && EA4 != 0)
                AddData(DM.Rows[4].Cells["BU"], EA4 - BU);
            if (EA1 != 0 && EA4 != 0)
                AddData(DM.Rows[4].Cells["EA1"], EA4 - EA1);
            if (EA2 != 0 && EA4 != 0)
                AddData(DM.Rows[4].Cells["EA2"], EA4 - EA2);
            if (EA3 != 0 && EA4 != 0)
                AddData(DM.Rows[4].Cells["EA3"], EA4 - EA3);
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
    }
}
