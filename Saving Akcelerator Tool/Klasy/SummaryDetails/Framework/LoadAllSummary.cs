using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework
{
    class LoadAllSummary
    {

        public LoadAllSummary()
        {
            _ = new SDTableLoad();
            Charts chart = new Charts(MainProgram.Self.SDSumAllAction.GetChart());
            chart.ChartSummary();
            MainProgram.Self.SDSumAllAction.ClearPlanTable();
            MainProgram.Self.SDSumAllAction.PlanTable();
            MainProgram.Self.SDSumAllAction.SumPlanTable();
        }

    }
}
