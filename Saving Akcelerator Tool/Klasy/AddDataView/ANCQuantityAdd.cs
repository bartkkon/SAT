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
    public class ANCQuantityAdd
    {
        public ANCQuantityAdd(int AddMonth, int AddYear, string[] DataToAdd)
        {
            var ANCList = ANCMonthlyQuantity.LoadByYear_Month(AddYear, AddMonth);

            if (ANCList != null)
            {
                ANCMonthlyQuantity.RemoveList(ANCList);
            }

            List<ANCMonthlyDB> ListANC = new List<ANCMonthlyDB>();

            foreach (string Data in DataToAdd)
            {
                string[] AddData = Data.Split('\t');

                if (AddData.Length != 1)
                {
                    var NewRow = new ANCMonthlyDB
                    {
                        ANC = AddData[0].ToString(),
                        Year = AddYear,
                        Month = AddMonth,
                        Value = Convert.ToDouble(AddData[1])
                    };
                    ListANC.Add(NewRow);
                }
            }


            if (ListANC != null)
            {
                ANCMonthlyQuantity.AddList(ListANC);
            }
        }
    }
}
