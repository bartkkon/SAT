using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Save
{
    class PNCSpecialSave
    {
        public static IEnumerable<PNCSpecialDB> Save ()
        {
            var PNCView = MainProgram.Self.actionView.PNCListView;
            List<PNCSpecialDB> PNCList = new List<PNCSpecialDB>();
            DataGridView PNCTable = PNCView.GetTable();
            
            string PNC = string.Empty;
            double ECCC = 0;

            foreach(DataGridViewRow TableRow in PNCTable.Rows)
            {
                if (TableRow.Cells["PNC"].Value != null && TableRow.Cells["PNC"].Value.ToString() != "")
                {
                    PNC = TableRow.Cells["PNC"].Value.ToString();
                    ECCC = 0;
                    if (TableRow.Cells["OLD ANC"].Value != null && TableRow.Cells["OLD ANC"].Value.ToString() != "")
                    {
                        string ECCCString = TableRow.Cells["OLD ANC"].Value.ToString().Replace("ECCC(", "").Replace(")", "");
                        if (ECCCString != string.Empty)
                            ECCC = Convert.ToDouble(ECCCString);
                    }
                }
                else
                {
                    PNCSpecialDB NewRow = new PNCSpecialDB
                    {
                        PNC = PNC,
                        ECCC = ECCC,
                        Old_ANC = TableRow.Cells["OLD ANC"].Value.ToString(),
                        Old_IDCO = PNCView.GetIDCO(TableRow.Cells["OLD ANC"].Value.ToString()),
                        New_ANC = TableRow.Cells["NEW ANC"].Value.ToString(),
                        New_IDCO = PNCView.GetIDCO(TableRow.Cells["NEW ANC"].Value.ToString()),
                        Active = true,
                        ChangeBy = Environment.UserName.ToLower(),
                        
                    };

                    if (TableRow.Cells["OLD Q"].Value.ToString() != string.Empty)
                        NewRow.Old_Quant_ANC = Convert.ToDouble(TableRow.Cells["OLD Q"].Value.ToString());

                    if (TableRow.Cells["NEW Q"].Value.ToString() != string.Empty)
                        NewRow.New_Quant_ANC = Convert.ToDouble(TableRow.Cells["NEW Q"].Value.ToString());

                    if (TableRow.Cells["OLD STK"].Value.ToString() != string.Empty)
                        NewRow.Old_STK = Convert.ToDouble(TableRow.Cells["OLD STK"].Value.ToString());

                    if (TableRow.Cells["NEW STK"].Value.ToString() != string.Empty)
                        NewRow.New_STK = Convert.ToDouble(TableRow.Cells["NEW STK"].Value.ToString());

                    if (TableRow.Cells["Delta"].Value.ToString() != string.Empty)
                        NewRow.Delta = Convert.ToDouble(TableRow.Cells["Delta"].Value.ToString());

                    PNCList.Add(NewRow);
                }

            }

            return PNCList;
        }
    }
}
