using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    public class ClearForm
    {
        public ClearForm()
        {
            MainProgram.Self.actionView.nameView.Clear();
            MainProgram.Self.actionView.stateView.Clear();
            MainProgram.Self.actionView.platformView.Clear();
            MainProgram.Self.actionView.installationView.Clear();
            MainProgram.Self.actionView.ecccView.Clear();
            MainProgram.Self.actionView.calculationByView.Clear();
            MainProgram.Self.actionView.PNCSpecialEstymationView.Clear();
            MainProgram.Self.actionView.ANCChangeView.Clear();
            MainProgram.Self.actionView.ANCChangeView.SetVisibleANC(1);
            MainProgram.Self.actionView.QunatityPercent.Clear();
            MainProgram.Self.actionView.SavingsTable.Clear();
            MainProgram.Self.actionView.PNCListView.Clear();
        }
    }
}
