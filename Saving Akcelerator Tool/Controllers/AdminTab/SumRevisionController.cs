using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers.AdminTab
{
    class SumRevisionController
    {
        public static IEnumerable<SumRevisionQuantityDB> LoadByRervision(int YearToFind, string RevisionToFind)
        {
            var context = new DataBaseConnectionContext();
            var List = context.SumRevisionQuantity.Where(u => u.Year == YearToFind && u.Revision == RevisionToFind).ToList();
            return List;
        }

        public static IEnumerable<SumRevisionQuantityDB> LoadByYear(int YearToFind)
        {
            var context = new DataBaseConnectionContext();
            var List = context.SumRevisionQuantity.Where(u => u.Year == YearToFind).ToList();
            return List;
        }

        public static void RemoveData(IEnumerable<SumRevisionQuantityDB> ListToRemove)
        {
            var context = new DataBaseConnectionContext();
            foreach (var ToRemove in ListToRemove)
            {
                context.Remove(ToRemove);
            }
            context.SaveChanges();
        }

        public static void AddData(IEnumerable<SumRevisionQuantityDB> ListToAdd)
        {
            var context = new DataBaseConnectionContext();
            foreach (var ToAdd in ListToAdd)
            {
                context.Add(ToAdd);
            }

            context.SaveChanges();
        }
    }
}
