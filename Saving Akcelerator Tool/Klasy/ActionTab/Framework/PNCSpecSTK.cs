using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    class PNCSpecSTK
    {
        private static List<STKDB> STKList;
        public static bool Find(DataTable PNCList)
        {
            DataRow PNCRow;
            decimal Year;
            STKList = new List<STKDB>();
            PNCRow = PNCList.NewRow();

            Year = MainProgram.Self.actionView.stateView.GetYear();

            foreach (DataRow Row in PNCList.Rows)
            {
                if (Row["PNC"].ToString() != string.Empty)
                {
                    PNCRow = Row;
                }
                else
                {
                    if (Row["OLD ANC"].ToString() != string.Empty)
                    {
                        if (!STKList.Any(x => x.ANC == Row["OLD ANC"].ToString()))
                        {
                            STKDB FindSTK = STKController.Load(Convert.ToInt32(Year), Row["OLD ANC"].ToString());
                            if (FindSTK != null)
                                STKList.Add(FindSTK);
                        }
                        if (STKList.Any(x => x.ANC == Row["OLD ANC"].ToString()))
                        {
                            STKDB STK = STKList.Find(u => u.ANC == Row["OLD ANC"].ToString());
                            double Value = STK.Value * Convert.ToDouble(Row["OLD Q"].ToString());
                            Value = Math.Round(Value, 4, MidpointRounding.AwayFromZero);
                            Row["OLD STK"] = Value.ToString();
                            if (PNCRow["OLD STK"].ToString() != string.Empty)
                                PNCRow["OLD STK"] = (Convert.ToDouble(PNCRow["OLD STK"].ToString()) + Value).ToString();
                            else
                                PNCRow["OLD STK"] = Value.ToString();
                        }
                    }

                    if (Row["NEW ANC"].ToString() != string.Empty)
                    {
                        if (!STKList.Any(x => x.ANC == Row["NEW ANC"].ToString()))
                        {
                            STKDB FindSTK = STKController.Load(Convert.ToInt32(Year), Row["NEW ANC"].ToString());
                            if (FindSTK != null)
                                STKList.Add(FindSTK);
                        }
                        if (STKList.Any(x => x.ANC == Row["NEW ANC"].ToString()))
                        {
                            STKDB STK = STKList.Find(u => u.ANC == Row["NEW ANC"].ToString());
                            double Value = STK.Value * Convert.ToDouble(Row["NEW Q"].ToString());
                            Value = Math.Round(Value, 4, MidpointRounding.AwayFromZero);
                            Row["NEW STK"] = Value.ToString();
                            if (PNCRow["NEW STK"].ToString() != string.Empty)
                                PNCRow["NEW STK"] = (Convert.ToDouble(PNCRow["NEW STK"].ToString()) + Value).ToString();
                            else
                                PNCRow["NEW STK"] = Value.ToString();
                        }
                    }

                    double Delta = 0;
                    if (Row["OLD STK"].ToString() != string.Empty)
                    {
                        Delta = Convert.ToDouble(Row["OLD STK"].ToString());
                    }
                    if (Row["NEW STK"].ToString() != string.Empty)
                    {
                        Delta -= Convert.ToDouble(Row["NEW STK"].ToString());
                    }
                    Delta = Math.Round(Delta, 4, MidpointRounding.AwayFromZero);
                    Row["Delta"] = Delta.ToString();
                    if (PNCRow["Delta"].ToString() != string.Empty)
                        PNCRow["Delta"] = (Convert.ToDouble(PNCRow["Delta"].ToString()) + Delta).ToString();
                    else
                        PNCRow["Delta"] = Delta.ToString();
                }
            }

            MainProgram.Self.actionView.PNCListView.SetPNCSpecial(PNCList);
            foreach(STKDB STK in STKList)
            {
                MainProgram.Self.actionView.PNCListView.AddIDCOValue(STK.ANC, STK.IDCO);
            }

            return true;

        }
    }
}
