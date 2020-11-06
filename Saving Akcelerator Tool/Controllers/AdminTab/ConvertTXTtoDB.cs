using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using Saving_Accelerator_Tool.Model.Action;
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
            List<ANCChangeDB> Lista = new List<ANCChangeDB>();
            ANCChangeDB Jeden = new ANCChangeDB();
            ANCChangeDB Dwa = new ANCChangeDB();
            Jeden.ActionID = 1;
            Dwa.ActionID = 2;

            Lista.Add(Jeden);
            Lista.Add(Dwa);
            

        }

    }
}
