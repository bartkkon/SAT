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
            List<PNCSpecialDB> PNCList = new List<PNCSpecialDB>();
            DataGridView PNCTable = MainProgram.Self.actionView.PNCListView.GetTable();
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
                        Old_Quant_ANC = Convert.ToDouble(TableRow.Cells["OLD Q"].Value.ToString()),
                        New_ANC = TableRow.Cells["NEW ANC"].Value.ToString(),
                        New_Quant_ANC = Convert.ToDouble(TableRow.Cells["NEW Q"].Value.ToString()),
                        Old_STK = Convert.ToDouble(TableRow.Cells["OLD STK"].Value.ToString()),
                        New_STK = Convert.ToDouble(TableRow.Cells["NEW STK"].Value.ToString()),
                        Delta = Convert.ToDouble(TableRow.Cells["Delta"].Value.ToString()),
                    };
                    PNCList.Add(NewRow);
                }

            }

            return PNCList;
        }
    }
}
