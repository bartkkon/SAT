using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Frozen
{
    class SaveFrozen
    {
        public SaveFrozen(int YearToSave, int[] Data)
        {
            IEnumerable<FrozenDB> Frozen = FrozenController.Load_year(YearToSave);

            if (Frozen.Count() == 0)
            {
                var NewRow = new FrozenDB();
                PrepareData(NewRow, Data);
                NewRow.Year = YearToSave;
                FrozenController.AddValue(NewRow);
            }
            else
            {
                PrepareData(Frozen.First(), Data);
                FrozenController.UpdateValue(Frozen.First());
            }
        }

        private void PrepareData(FrozenDB Lista, int[] data)
        {
            Lista.BU = data[0];
            Lista.EA1 = data[1];
            Lista.EA2 = data[2];
            Lista.EA3 = data[3];
            Lista.January = data[4];
            Lista.February = data[5];
            Lista.March = data[6];
            Lista.April = data[7];
            Lista.May = data[8];
            Lista.June = data[9];
            Lista.July = data[10];
            Lista.August = data[11];
            Lista.September = data[12];
            Lista.October = data[13];
            Lista.November = data[14];
            Lista.December = data[15];
            Lista.ElectronicApprove = data[16];
            Lista.MechanicApprove = data[17];
            Lista.NVRApprove = data[18];
        }
    }
}
