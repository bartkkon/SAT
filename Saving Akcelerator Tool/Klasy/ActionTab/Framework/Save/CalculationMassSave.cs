using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Save
{
    class CalculationMassSave
    {
        public static CalculationMassDB Mass()
        {
            var Calc = MainProgram.Self.actionView.CalculationGroup;

            CalculationMassDB MassData = new CalculationMassDB
            {
                DMD_FS = Calc.GetDMD_FS(),
                DMD_FI = Calc.GetDMD_FI(),
                DMD_BI = Calc.GetDMD_BI(),
                DMD_FSBU = Calc.GetDMD_FSBU(),
                D45_FS = Calc.GetD45_FS(),
                D45_FI = Calc.GetD45_FI(),
                D45_BI = Calc.GetD45_BI(),
                D45_FSBU = Calc.GetD45_FSBU(),
                Active = true,
                ChangeBy = Environment.UserName.ToLower(),
                ChangeTime = DateTime.UtcNow,
            };

            return MassData;
        }
    }
}
