using Saving_Accelerator_Tool.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    class FindSTK
    {
        public FindSTK(int Count, string NewOld, string ANC, double Quantity)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (ANC == "n/a" || ANC == string.Empty)
            {
                if (NewOld == "New")
                {
                    MainProgram.Self.actionView.StkChange.SetNewSTK(Count, ANC);
                }
                else if (NewOld == "Old")
                {
                    MainProgram.Self.actionView.StkChange.SetOldSTK(Count, ANC);
                }
            }
            else
            {
                decimal ActionYear = MainProgram.Self.actionView.stateView.GetYear();

                var ANCSTK = STKController.Load(Convert.ToInt32(ActionYear), ANC);

                if(ANCSTK == null)
                {
                    if (NewOld == "New")
                    {
                        MainProgram.Self.actionView.StkChange.SetNewSTK(Count, "n/a");
                    }
                    else if (NewOld == "Old")
                    {
                        MainProgram.Self.actionView.StkChange.SetOldSTK(Count, "n/a");
                    }
                }
                else
                {
                    if (NewOld == "New")
                    {
                        double Suma = ANCSTK.Value * Quantity;
                        Suma = Math.Round(Suma, 4, MidpointRounding.AwayFromZero);
                        MainProgram.Self.actionView.StkChange.SetNewSTK(Count, Suma.ToString());
                    }
                    else if (NewOld == "Old")
                    {
                        double Suma = ANCSTK.Value * Quantity;
                        Suma = Math.Round(Suma, 4, MidpointRounding.AwayFromZero);
                        MainProgram.Self.actionView.StkChange.SetOldSTK(Count, Suma.ToString());
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
