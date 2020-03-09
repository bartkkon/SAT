using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers.AdminTab
{
    class ConvertTXTtoDB
    {
        public static void Upload()
        {
            var context = new DataBaseConnectionContext();

            foreach(PNCRevisionDB pNCRevisionDB in context.PNCRevision)
            {
                if(pNCRevisionDB.Revision == null)
                {
                    context.Remove(pNCRevisionDB);
                }
            }
            context.SaveChanges();

            //DataTable ANC = new DataTable();

            //Data_Import.Singleton().Load_TxtToDataTable2(ref ANC, "PNCMonth");

            //foreach(DataRow Row in ANC.Rows)
            //{
            //    string ANCRow = Row["PNC"].ToString();
            //    foreach(DataColumn column in ANC.Columns)
            //    {
            //        if(column.ColumnName != "PNC")
            //        {
            //            if(Row[column].ToString() != "")
            //            {
            //                string[] Date = column.ColumnName.Split('/');
            //                var NewRow = new PNCMonthlyDB
            //                {
            //                    PNC = ANCRow,
            //                    Value = Convert.ToDouble(Row[column]),
            //                    //Revision = Date[0],
            //                    Year = Convert.ToInt32(Date[1]),
            //                    Month = Convert.ToInt32(Date[0]),
            //                };
            //                context.Add(NewRow);
            //            }
            //        }
            //    }
            //}

        }
    }
}
