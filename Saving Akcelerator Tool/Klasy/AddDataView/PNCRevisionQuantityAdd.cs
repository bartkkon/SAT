using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.AddDataView
{
    class PNCRevisionQuantityAdd
    {
        public PNCRevisionQuantityAdd(string Revision, int AddYear, string[] DataToAdd)
        {
            var PNCList = PNCRevisionQuantity.LoadByYear_Revision(AddYear, Revision);
            int StartMonth = 0;

            if (Revision == "BU")
                StartMonth = 1;
            else if (Revision == "EA1")
                StartMonth = 3;
            else if (Revision == "EA2")
                StartMonth = 6;
            else if (Revision == "EA3")
                StartMonth = 9;

            if (StartMonth == 0)
                return;

            if (PNCList != null)
            {
                PNCRevisionQuantity.RemoveList(PNCList);
            }
            List<PNCRevisionDB> ListPNC = new List<PNCRevisionDB>();


            foreach (string Data in DataToAdd)
            {
                string[] AddData = Data.Split('\t');
                if (AddData.Length != 1)
                {
                    int StringCount = 1;

                    for (int counter = StartMonth; counter < 13; counter++)
                    {
                        var NewRow = new PNCRevisionDB
                        {
                            PNC = AddData[0].ToString(),
                            Year = AddYear,
                            Month = counter,
                            Revision = Revision,
                            Value = Convert.ToDouble(AddData[StringCount]),
                        };
                        StringCount++;
                        ListPNC.Add(NewRow);
                    }
                }
            }

            if (ListPNC != null)
            {
                PNCRevisionQuantity.AddList(ListPNC);
            }
        }
    }
}
