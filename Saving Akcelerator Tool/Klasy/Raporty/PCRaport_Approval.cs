using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Saving_Accelerator_Tool
{
    class PCRaport_Approval
    {
        private readonly Dictionary<string, string> Dewizje = new Dictionary<string, string>
        {
            {"Electronic Approve", "Electronic" },
            {"Mechanic Approve","Mechanic" },
            {"NVR Approve", "NVR" },
        };
        private readonly Dictionary<string, int> MonthStart = new Dictionary<string, int>()
        {
            {"January", 1},
            {"February", 2},
            {"March", 3},
            {"April", 4},
            {"May", 5},
            {"June",6},
            {"July", 7},
            {"August",8},
            {"September",9},
            {"October",10},
            {"November",11},
            {"December",12},
        };
        private readonly Dictionary<string, int> RevisionStartMonth = new Dictionary<string, int>()
        {
            {"BU", 1},
            {"EA1", 3},
            {"EA2", 6},
            {"EA3", 9},
        };

        public void Approve_Info(string Devision, string Rewizion, decimal Year, Data_Import data_Import)
        {
            DataTable Action = new DataTable();
            DataTable ANC = new DataTable();
            DataTable PNC = new DataTable();
            DataTable Kurs = new DataTable();

            string Link;
            string DevisionFinal = Dewizje[Devision];
            decimal Euro;

            Link = data_Import.Load_Link("Action");
            data_Import.Load_TxtToDataTable(ref Action, Link);

            Link = data_Import.Load_Link("Kurs");
            data_Import.Load_TxtToDataTable(ref Kurs, Link);

            Link = data_Import.Load_Link("ANC");
            data_Import.Load_TxtToDataTable(ref ANC, Link);

            Link = data_Import.Load_Link("PNC");
            data_Import.Load_TxtToDataTable(ref PNC, Link);

            Euro = decimal.Parse((Kurs.Select(string.Format("Year LIKE '%{0}%'", Year)).FirstOrDefault())["EURO"].ToString());

            foreach (DataRow Row in Action.Rows)
            {
                if (Row["Group"].ToString() == DevisionFinal && Row["StartYear"].ToString() == Year.ToString())
                {
                    //Row.ItemArray = CalcSpecjal(Row, Rewizion, Euro, ref ANC, ref PNC).ItemArray;
                }
            }

            Link = data_Import.Load_Link("Action");
            data_Import.Save_DataTableToTXT(ref Action, Link);

        }

        private DataRow CalcSpecjal(DataRow Action, string Rewizja, decimal Euro, ref DataTable ANC, ref DataTable PNC)
        {
            int Month = MonthStart[Action["StartMonth"].ToString()];
            int RewizjaMonth = RevisionStartMonth[Rewizja];
            decimal Delta;
            decimal SteadyQuantity;
            decimal SteadySaving = 0;
            decimal FiscalQunatity =0;
            decimal FiscalSavings =0;
            decimal Probalility = 100;
            string Quantity;
            string Saving;
            string ECCC;

            ECCC = Action["Calc" + Rewizja + "ECCC"].ToString();
            Quantity = Action["Calc" + Rewizja + "Quantity"].ToString();
            Saving = Action["Calc" + Rewizja + "Saving"].ToString();

            if ((Saving.Split('/'))[12].ToString() != "")
                FiscalSavings = decimal.Parse((Saving.Split('/'))[12].ToString());
            if ((ECCC.Split('/'))[12].ToString() != "")
            {
                FiscalSavings = FiscalSavings + decimal.Parse((ECCC.Split('/'))[12].ToString());
            }
            if((Quantity.Split('/'))[12].ToString() != "")
            FiscalQunatity = decimal.Parse((Quantity.Split('/'))[12].ToString());

            FiscalSavings = FiscalSavings / Euro;
            FiscalSavings = Math.Round(FiscalSavings, 0, MidpointRounding.AwayFromZero);

            Delta = FiscalSavings / FiscalQunatity;
            Delta = Math.Round(Delta, 4, MidpointRounding.AwayFromZero);

            FiscalSavings = FiscalSavings / 1000;

            SteadyQuantity = SteadyQuantityBring(Action, Rewizja, ref ANC, ref PNC);


            Action[Rewizja] = Month.ToString() + "|";
            Action[Rewizja] = Action[Rewizja].ToString() + Delta.ToString() + "|";
            Action[Rewizja] = Action[Rewizja].ToString() + SteadyQuantity.ToString() + "|";
            Action[Rewizja] = Action[Rewizja].ToString() + SteadySaving.ToString() + "|";
            Action[Rewizja] = Action[Rewizja].ToString() + FiscalQunatity.ToString() + "|";
            Action[Rewizja] = Action[Rewizja].ToString() + Probalility.ToString() + "|";
            Action[Rewizja] = Action[Rewizja].ToString() + FiscalSavings.ToString() + "|";

            return Action;
        }

        private decimal SteadyQuantityBring(DataRow Action, string Rewizja, ref DataTable ANC, ref DataTable PNC)
        {
            decimal Steady = 0;

            if (Action["Calculate"].ToString() == "ANC")
            {

            }

            return Steady;
        }
    }
}
