using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Saving_Accelerator_Tool.Controllers.AdminTab
{
    class ConvertTXTtoDB
    {

        public static void Upload()
        {
            var context = new DataBaseConnectionContext();
            var Find = context.STK.Where(u => u.Year == 20).ToList();
            int Remove = 0;

            foreach (STKDB One in Find)
            {
                context.Remove(One);
                Remove++;
            }

            context.SaveChanges();
            MessageBox.Show("Usunięto: " + Remove.ToString());
        }

    }
}
