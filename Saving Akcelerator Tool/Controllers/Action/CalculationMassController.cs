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
            var List = context.CalculationMass.Where(u => u.ActionID == ActionID && u.Active == true).ToList();

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

        public static void Update(int OldID, int NewID, CalculationMassDB NewRow)
        {
            var context = new DataBaseConnectionContext();
            var OldList = context.CalculationMass.Where(u => u.ActionID == OldID && u.Active == true).ToList();
            int Revision = 0;

            foreach (var Old in OldList)
            {
                Old.Active = false;
                Revision = Old.Rev;
                context.CalculationMass.Update(Old);
            }

            NewRow.ActionID = NewID;
            NewRow.Active = true;
            context.CalculationMass.Add(NewRow);
            context.SaveChanges();
        }



        public static void Deactivation(int  OldID)
        {
            var context = new DataBaseConnectionContext();
            var List = context.CalculationMass.Where(u => u.ActionID == OldID && u.Active == true).ToList();

            foreach (var one in List)
            {
                one.Active = false;
                context.CalculationMass.Update(one);
            }
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
