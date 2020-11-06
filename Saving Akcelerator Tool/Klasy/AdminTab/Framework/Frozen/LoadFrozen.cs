using Saving_Accelerator_Tool.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Frozen
{
    class LoadFrozen
    {
        public LoadFrozen(int Year)
        {
            int[] Value = new int[19];

            MainProgram.Self.FrozenView.Clear();

            var Lista = FrozenController.Load_year(Year);

            if (Lista.Count() == 0)
                return;

            Value[0] = Lista.First().BU;
            Value[1] = Lista.First().EA1;
            Value[2] = Lista.First().EA2;
            Value[3] = Lista.First().EA3;
            Value[4] = Lista.First().January;
            Value[5] = Lista.First().February;
            Value[6] = Lista.First().March;
            Value[7] = Lista.First().April;
            Value[8] = Lista.First().May;
            Value[9] = Lista.First().June;
            Value[10] = Lista.First().July;
            Value[11] = Lista.First().August;
            Value[12] = Lista.First().September;
            Value[13] = Lista.First().October;
            Value[14] = Lista.First().November;
            Value[15] = Lista.First().December;
            Value[16] = Lista.First().ElectronicApprove; 
            Value[17] = Lista.First().MechanicApprove;
            Value[18] = Lista.First().NVRApprove;

            MainProgram.Self.FrozenView.SetValue(Value);
        }
    }
}
