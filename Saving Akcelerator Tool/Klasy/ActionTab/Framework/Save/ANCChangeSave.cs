using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Save
{
    class ANCChangeSave
    {
        public static IEnumerable<ANCChangeDB> ANCSave()
        {
            List<ANCChangeDB> ListANC = new List<ANCChangeDB>();
            int VisibleANC;
            var ANC = MainProgram.Self.actionView.ANCChangeView;
            var STK = MainProgram.Self.actionView.StkChange;
            var Next = MainProgram.Self.actionView.NextANC;
            var Calcby = MainProgram.Self.actionView.CalculationGroup;

            VisibleANC = ANC.GetVisibleNumber();

            for (int counter = 1; counter <= VisibleANC; counter++)
            {
                if (ANC.GetOldANC(counter) != string.Empty && ANC.GetNewANC(counter) != string.Empty)
                {
                    ANCChangeDB NewANCChange = new ANCChangeDB
                    {
                        Old_ANC = ANC.GetOldANC(counter),
                        Old_Quant_ANC = ANC.GetOldANCQ(counter),
                        OLD_IDCO = ANC.GetOldIDCO(counter),
                        New_ANC = ANC.GetNewANC(counter),
                        New_Quant_ANC = ANC.GetNewANCQ(counter),
                        New_IDCO = ANC.GetNewIDCO(counter),
                        Old_STK = STK.GetSTKOld(counter),
                        New_STK = STK.GetSTKNew(counter),
                        Delta = STK.GetDelta(counter),
                        Estimation = STK.GetEstimation(counter),
                        Percent = STK.GetPercent(counter),
                        Calculation = STK.GetCalculation(counter),
                        ANC_Calculation = Calcby.GetANCCalc(counter),
                        Next_ANC_1 = Next.GetANCNext1(counter),
                        Next_ANC_2 = Next.GetANCNext2(counter),

                        Active = true,
                        ChangeBy = Environment.UserName.ToLower(),
                        ChangeTime = DateTime.UtcNow
                    };
                    ListANC.Add(NewANCChange);
                }
            }


            return ListANC;
        }
    }
}
