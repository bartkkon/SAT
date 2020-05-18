using Saving_Accelerator_Tool.Controllers.Action;
using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Load
{
    class CalculationMassLoad
    {
        public static void Load(int ActionID)
        {
            IEnumerable<CalculationMassDB> Mass;
            var Action = MainProgram.Self.actionView.CalculationGroup;

            Mass = CalculationMassController.Load(ActionID);

            foreach(var One in Mass)
            {
                Action.SetMassGroup(true);
                Action.SetDMD_BI(One.DMD_BI);
                Action.SetDMD_FI(One.DMD_FI);
                Action.SetDMD_FS(One.DMD_FS);
                Action.SetDMD_FSBU(One.DMD_FSBU);
                Action.SetD45_BI(One.D45_BI);
                Action.SetD45_FI(One.D45_FI);
                Action.SetD45_FS(One.D45_FS);
                Action.SetD45_FSBU(One.D45_FSBU);
            }

            if(Mass.Count() == 0)
            {
                Action.SetANCbyGroup(true);
            }
        }
    }
}
