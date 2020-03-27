using System;
using System.Collections.Generic;
using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model.Action;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers.Action
{
    class CalculationMassController
    {
        public static IEnumerable<CalculationMassDB> Load(int ActionID)
        {
            var context = new DataBaseConnectionContext();
            var List = context.CalculationMass.Where(u => u.ActionID == ActionID).ToList();

            return List;
        }

        public static void Remove(IEnumerable<CalculationMassDB> ListToRemove)
        {
            var context = new DataBaseConnectionContext();
            foreach (var Row in ListToRemove)
            {
                context.CalculationMass.Remove(Row);
            }

            context.SaveChanges();
        }

        public static void Add(CalculationMassDB ToAdd)
        {
            var context = new DataBaseConnectionContext();
                context.CalculationMass.Add(ToAdd);

            context.SaveChanges();
        }

        //public static void Update(CalculationMassDB ListToUpdate)
        //{
        //    var context = new DataBaseConnectionContext();

        //    foreach (var Row in ListToUpdate)
        //    {
        //        if (Row.ID != 0)
        //        {
        //            context.CalculationMass.Update(Row);
        //        }
        //        else
        //        {
        //            context.CalculationMass.Add(Row);
        //        }
        //    }

        //    context.SaveChanges();
        //}
    }
}
