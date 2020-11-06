using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.AddDataView
{
    class PNCQuantityAdd
    {
        public PNCQuantityAdd(int AddMonth, int AddYear, string[] DataToAdd)
        {
            var PNCList = PNCMonthlyQuantity.LoadByYear_Month(AddYear, AddMonth);

            if (PNCList != null)
            {
                PNCMonthlyQuantity.RemoveList(PNCList);
            }

            List<PNCMonthlyDB> ListPNC = new List<PNCMonthlyDB>();

            foreach (string Data in DataToAdd)
            {
                string[] AddData = Data.Split('\t');

                if (AddData.Length != 1)
                {
                    var NewRow = new PNCMonthlyDB
                    {
                        PNC = AddData[0].ToString(),
                        Year = AddYear,
                        Month = AddMonth,
                        Value = Convert.ToDouble(AddData[1])
                    };
                    ListPNC.Add(NewRow);
                }
            }

            if(ListPNC != null)
            {
                PNCMonthlyQuantity.AddList(ListPNC);
                
            }
        }
    }
}
