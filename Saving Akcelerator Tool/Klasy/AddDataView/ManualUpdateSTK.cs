using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.AddDataView
{
    class ManualUpdateSTK
    {
        public ManualUpdateSTK(string[] STKData, int Year)
        {
            List<STKDB> NewSTKManual = new List<STKDB>();

            foreach (string OneRow in STKData)
            {
                string[] ToAdd = OneRow.Split('\t');

                if (ToAdd.Length != 1 && ToAdd.Length == 4)
                {
                    var NewRow = new STKDB
                    {
                        ANC = ToAdd[0],
                        Description = ToAdd[1],
                        IDCO = ToAdd[2],
                        Year = Year,
                        Month = 0,
                        Day = 0,
                        Value = Convert.ToDouble(ToAdd[3]),
                    };
                    NewSTKManual.Add(NewRow);
                }
            }

            if (NewSTKManual != null)
                STKController.AddManualUpdate(NewSTKManual);
        }
    }
}
