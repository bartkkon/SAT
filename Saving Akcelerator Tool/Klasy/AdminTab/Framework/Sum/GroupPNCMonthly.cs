using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Controllers.AdminTab;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Sum
{
    class GroupPNCMonthly
    {
        public GroupPNCMonthly(int Year, int Month)
        {
            IEnumerable<PNCMonthlyDB> AllQuantity = PNCMonthlyQuantity.LoadByYear_Month(Year, Month);
            IEnumerable<SumQuantityDB> SumQuantity = SumMonthlyController.LoadByMonth(Year, Month);
            List<SumQuantityDB> SumToAdd = new List<SumQuantityDB>();

            if (AllQuantity.Count() == 0)
            {
                MessageBox.Show("No Data To Sum!");
                return;
            }

            if (SumQuantity.Count() != 0)
            {
                SumMonthlyController.RemoveData(SumQuantity);
            }

            double DMD_FS = 0;
            double DMD_FI = 0;
            double DMD_BI = 0;
            double DMD_FSBU = 0;
            double D45_FS = 0;
            double D45_FI = 0;
            double D45_BI = 0;
            double D45_FSBU = 0;

            foreach (PNCMonthlyDB PNC in AllQuantity)
            {
                if (PNC.PNC.Remove(0, 3).Remove(1, 5) == "5")
                {
                    switch (PNC.PNC.Remove(0, 4).Remove(1, 4))
                    {
                        case "1":
                            DMD_FS += PNC.Value;
                            break;
                        case "2":
                            DMD_BI += PNC.Value;
                            break;
                        case "3":
                            DMD_FI += PNC.Value;
                            break;
                        case "4":
                            DMD_FSBU += PNC.Value;
                            break;
                        default:
                            break;
                    }
                }
                else if(PNC.PNC.Remove(0, 3).Remove(1, 5) == "0")
                {
                    switch (PNC.PNC.Remove(0, 4).Remove(1, 4))
                    {
                        case "5":
                            D45_FS += PNC.Value;
                            break;
                        case "6":
                            D45_BI += PNC.Value;
                            break;
                        case "7":
                            D45_FI += PNC.Value;
                            break;
                        case "8":
                            D45_FSBU += PNC.Value;
                            break;
                        default:
                            break;
                    }
                }
            }

            var DMDFS = new SumQuantityDB
            {
                Platform = "DMD",
                Installation = "FS",
                Year = Year,
                Month = Month,
                Value = DMD_FS,
            };
            var DMDFI = new SumQuantityDB
            {
                Platform = "DMD",
                Installation = "FI",
                Year = Year,
                Month = Month,
                Value = DMD_FI,
            };
            var DMDBI = new SumQuantityDB
            {
                Platform = "DMD",
                Installation = "BI",
                Year = Year,
                Month = Month,
                Value = DMD_BI,
            };
            var DMDFSBU = new SumQuantityDB
            {
                Platform = "DMD",
                Installation = "FSBU",
                Year = Year,
                Month = Month,
                Value = DMD_FSBU,
            };
            var D45FS = new SumQuantityDB
            {
                Platform = "D45",
                Installation = "FS",
                Year = Year,
                Month = Month,
                Value = D45_FS,
            };
            var D45FI = new SumQuantityDB
            {
                Platform = "D45",
                Installation = "FI",
                Year = Year,
                Month = Month,
                Value = D45_FI,
            };
            var D45BI = new SumQuantityDB
            {
                Platform = "D45",
                Installation = "BI",
                Year = Year,
                Month = Month,
                Value = D45_BI,
            };
            var D45FSBU = new SumQuantityDB
            {
                Platform = "D45",
                Installation = "FSBU",
                Year = Year,
                Month = Month,
                Value = D45_FSBU,
            };

            SumToAdd.Add(DMDFS);
            SumToAdd.Add(DMDFI);
            SumToAdd.Add(DMDBI);
            SumToAdd.Add(DMDFSBU);
            SumToAdd.Add(D45FS);
            SumToAdd.Add(D45FI);
            SumToAdd.Add(D45BI);
            SumToAdd.Add(D45FSBU);

            SumMonthlyController.AddData(SumToAdd);
        }
    }
}
