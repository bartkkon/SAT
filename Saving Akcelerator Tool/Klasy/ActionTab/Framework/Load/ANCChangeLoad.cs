using Saving_Accelerator_Tool.Controllers.Action;
using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Load
{
    class ANCChangeLoad
    {
        public ANCChangeLoad(int ActionID)
        {
            IEnumerable<ANCChangeDB> ANCList;

            ANCList = ANCChangeController.Load(ActionID);

            if (ANCList != null)
            {
                var Action = MainProgram.Self.actionView;
                int Count = 0;

                foreach (ANCChangeDB ANC in ANCList)
                {
                    Action.ANCChangeView.SetOldANC(Count, ANC.Old_ANC);
                    Action.ANCChangeView.SetOldANCQ(Count, ANC.Old_Quant_ANC);
                    Action.ANCChangeView.SetOldANC_IDCO(Count, ANC.OLD_IDCO);

                    Action.ANCChangeView.SetNewANC(Count, ANC.New_ANC);
                    Action.ANCChangeView.SetNewANCQ(Count, ANC.New_Quant_ANC);
                    Action.ANCChangeView.SetNewANC_IDCO(Count, ANC.New_IDCO);

                    Action.StkChange.SetOldSTK(Count, ANC.Old_STK.ToString());
                    Action.StkChange.SetNewSTK(Count, ANC.New_STK.ToString());
                    Action.StkChange.SetDelta(Count, ANC.Delta.ToString());
                    Action.StkChange.SetEstimation(Count, ANC.Estimation.ToString());
                    Action.StkChange.SetPercent(Count, ANC.Percent.ToString());

                    Count++;
                }
            }
        }
    }
}
