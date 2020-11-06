using Saving_Accelerator_Tool.Controllers.Action;
using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Load
{
    class PNCSpecialLoad
    {
        private static DataTable PNCTable;
        private static Dictionary<string, string> IDCO = new Dictionary<string, string>();
        public static void Load(int ActionID)
        {
            List<string> PNC = new List<string>();

            PNCTable = new DataTable();
            IEnumerable<PNCSpecialDB> PNCLoad = PNCSpecialController.Load(ActionID);

            CreateTable();

            if (PNCLoad.Count() != 0)
            {
                foreach (PNCSpecialDB OnePNC in PNCLoad)
                    if (!PNC.Contains(OnePNC.PNC))
                        PNC.Add(OnePNC.PNC);

                foreach (string PNCToAdd in PNC)
                {
                    IEnumerable<PNCSpecialDB> OnePNCList = PNCLoad.Where(u => u.PNC == PNCToAdd).ToList();
                    DataRow SumPNCRow = PNCTable.NewRow();
                    SumPNCRow["PNC"] = PNCToAdd;
                    PNCTable.Rows.Add(SumPNCRow);


                    foreach (PNCSpecialDB OnePNC in OnePNCList)
                    {
                        if (OnePNC.ECCC != 0)
                            SumPNCRow["OLD ANC"] = "ECCC(" + OnePNC.ECCC + ")";

                        DataRow NewRow = PNCTable.NewRow();
                        NewRow["OLD ANC"] = OnePNC.Old_ANC;
                        NewRow["OLD Q"] = OnePNC.Old_Quant_ANC;
                        NewRow["NEW ANC"] = OnePNC.New_ANC;
                        NewRow["NEW Q"] = OnePNC.New_Quant_ANC;
                        NewRow["OLD STK"] = OnePNC.Old_STK;
                        NewRow["NEW STK"] = OnePNC.New_STK;
                        NewRow["Delta"] = OnePNC.Delta;

                        SumaPNC(SumPNCRow, OnePNC.Old_STK, OnePNC.New_STK, OnePNC.Delta);

                        AddIDCO(OnePNC.Old_ANC, OnePNC.Old_IDCO, OnePNC.New_ANC, OnePNC.New_IDCO);

                        PNCTable.Rows.Add(NewRow);
                    }
                }
            }

            if (PNCTable.Rows.Count != 0)
            {
                MainProgram.Self.actionView.PNCListView.SetPNCSpecial(PNCTable);
            }
        }

        private static void SumaPNC(DataRow sumPNCRow, double old_STK, double new_STK, double delta)
        {
            if (sumPNCRow["OLD STK"].ToString() != string.Empty)
                sumPNCRow["OLD STK"] = Convert.ToDouble(sumPNCRow["OLD STK"].ToString()) + old_STK;
            else
                sumPNCRow["OLD STK"] = old_STK;

            if (sumPNCRow["NEW STK"].ToString() != string.Empty)
                sumPNCRow["NEW STK"] = Convert.ToDouble(sumPNCRow["NEW STK"].ToString()) + new_STK;
            else
                sumPNCRow["NEW STK"] = new_STK;

            if (sumPNCRow["Delta"].ToString() != string.Empty)
                sumPNCRow["Delta"] = Convert.ToDouble(sumPNCRow["Delta"].ToString()) + delta;
            else
                sumPNCRow["Delta"] = delta;
        }

        private static void AddIDCO(string old_ANC, string old_IDCO, string new_ANC, string new_IDCO)
        {
            if (old_ANC != string.Empty)
            {
                if (!IDCO.ContainsKey(old_ANC))
                    IDCO.Add(old_ANC, old_IDCO);
            }

            if (new_ANC != string.Empty)
            {
                if (!IDCO.ContainsKey(new_ANC))
                    IDCO.Add(new_ANC, new_IDCO);
            }
        }

        private static void CreateTable()
        {
            PNCTable.Columns.Add("PNC");
            PNCTable.Columns.Add("OLD ANC");
            PNCTable.Columns.Add("OLD Q");
            PNCTable.Columns.Add("NEW ANC");
            PNCTable.Columns.Add("NEW Q");
            PNCTable.Columns.Add("OLD STK");
            PNCTable.Columns.Add("NEW STK");
            PNCTable.Columns.Add("Delta");
        }
    }
}
