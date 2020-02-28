using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework
{
    class UpdateOptions
    {
        public UpdateOptions()
        {


        }
    }

    class UpdateOptionsYear
    {
        public UpdateOptionsYear(decimal Year)
        {
            MainProgram.Self.sdOptions1.SetYear(Year);
            MainProgram.Self.sdOptions2.SetYear(Year);
        }
    }

    class UpdateOptionsLeader
    {
        public UpdateOptionsLeader(int Index)
        {
            MainProgram.Self.sdOptions1.SetLeader(Index);
            MainProgram.Self.sdOptions2.SetLeader(Index);
        }
    }

    class UpdateOptionsDevision
    {
        public UpdateOptionsDevision(int Index)
        {
            MainProgram.Self.sdOptions1.SetDevision(Index);
            MainProgram.Self.sdOptions2.SetDevision(Index);
        }
    }
    class UpdateOptionsPositive
    {
        public UpdateOptionsPositive(bool Value)
        {
            MainProgram.Self.sdOptions1.SetPositiveAction(Value);
            MainProgram.Self.sdOptions2.SetPositiveAction(Value);
        }
    }

    class UpdateOptionsNegative
    {
        public UpdateOptionsNegative(bool Value)
        {
            MainProgram.Self.sdOptions1.SetNegativeAction(Value);
            MainProgram.Self.sdOptions2.SetNegativeAction(Value);
        }
    }

    class UpdateOptionsActive
    {
        public UpdateOptionsActive(bool Value)
        {
            MainProgram.Self.sdOptions1.SetActiveAction(Value);
            MainProgram.Self.sdOptions2.SetActiveAction(Value);
        }
    }

    class UpdateOptionsIdea
    {
        public UpdateOptionsIdea(bool Value)
        {
            MainProgram.Self.sdOptions1.SetIdeaAction(Value);
            MainProgram.Self.sdOptions2.SetIdeaAction(Value);
        }
    }

}
