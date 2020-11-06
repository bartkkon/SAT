using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Calculation;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    class CalculationAction
    {
        private static FrozenDB FrozenYear;
        private static int StartCalc;
        private static int FinishCalc;
        private static int CalcRow;
        public CalculationAction()
        {
            var CalculationBy = MainProgram.Self.actionView.calculationByView;

            if (!CheckIfCanCalculate())
                return;

            if (CalculationBy.GetANC())
            {
               _ = new ANC_Calc(StartCalc, FinishCalc, CalcRow);
            }
            else if (CalculationBy.GetANCSpec())
            {

            }
            else if (CalculationBy.GetPNC())
            {

            }
            else if (CalculationBy.GetPNCSpec())
            {

            }
        }

        private bool CheckIfCanCalculate()
        {
            IEnumerable<FrozenDB> Year = FrozenController.Load_year(Convert.ToInt32(MainProgram.Self.actionView.stateView.GetYear()));

            if(Year.Count() == 1)
            {
                foreach(FrozenDB CalcYear in Year)
                {
                    FrozenYear = CalcYear;
                    CalcRow = 0;
                    if (CalcYear.BU == 1)
                    { 
                        StartCalc = 1;
                        FinishCalc = 12;
                        CalcRow = 4;
                        return true;
                    }
                    if (CalcYear.EA1 == 1)
                    {
                        StartCalc = 3;
                        FinishCalc = 12;
                        CalcRow = 3;
                        return true;
                    }
                    if (CalcYear.EA2 == 1)
                    {
                        StartCalc = 6;
                        FinishCalc = 12;
                        CalcRow = 2;
                        return true;
                    }
                    if (CalcYear.EA3 == 1)
                    {
                        StartCalc = 9;
                        FinishCalc = 12;
                        CalcRow = 1;
                        return true;
                    }
                    if (CalcYear.January == 1)
                    {
                        StartCalc = 1;
                        FinishCalc = 1;
                        return true;
                    }
                    if (CalcYear.February == 1)
                    {
                        StartCalc = 2;
                        FinishCalc = 2;
                        return true;
                    }
                    if (CalcYear.March == 1)
                    {
                        StartCalc = 3;
                        FinishCalc = 3;
                        return true;
                    }
                    if (CalcYear.April == 1)
                    {
                        StartCalc = 4;
                        FinishCalc = 4;
                        return true;
                    }
                    if (CalcYear.May == 1)
                    {
                        StartCalc = 5;
                        FinishCalc = 5;
                        return true;
                    }
                    if (CalcYear.June == 1)
                    {
                        StartCalc = 6;
                        FinishCalc = 6;
                        return true;
                    }
                    if (CalcYear.July == 1)
                    {
                        StartCalc = 7;
                        FinishCalc = 7;
                        return true;
                    }
                    if (CalcYear.August == 1)
                    {
                        StartCalc = 8;
                        FinishCalc = 8;
                        return true;
                    }
                    if (CalcYear.September == 1)
                    {
                        StartCalc = 9;
                        FinishCalc = 9;
                        return true;
                    }
                    if (CalcYear.November == 1)
                    {
                        StartCalc = 10;
                        FinishCalc = 10;
                        return true;
                    }
                    if (CalcYear.October == 1)
                    {
                        StartCalc = 11;
                        FinishCalc = 11;
                        return true;
                    }
                    if (CalcYear.December == 1)
                    {
                        StartCalc = 12;
                        FinishCalc = 12;
                        return true;
                    }
                }
                StartCalc = 0;
                FinishCalc = 0;
                return false;
            }
            else
            {
                FrozenYear = null;
                StartCalc = 0;
                FinishCalc = 0;
                return false;
            }
                
        }
    }
}
