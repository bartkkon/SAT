using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers.AdminTab
{
    class SumMonthlyController
    {
        public static IEnumerable<SumQuantityDB> LoadByMonth(int YearToFind, int MonthToFind)
        {
            var context = new DataBaseConnectionContext();
            var List = context.SumQuantity.Where(u => u.Year == YearToFind && u.Month == MonthToFind).ToList();
            return List;
        }

        public static IEnumerable<SumQuantityDB> LoadByYear(int YearToFind)
        {
            var context = new DataBaseConnectionContext();
            var List = context.SumQuantity.Where(u => u.Year == YearToFind).ToList();
            return List;
        }

        public static void RemoveData(IEnumerable<SumQuantityDB> ListToRemove)
        {
            var context = new DataBaseConnectionContext();
            foreach (var ToRemove in ListToRemove)
            {
                context.Remove(ToRemove);
            }
            context.SaveChanges();
        }

        public static void AddData(List<SumQuantityDB> ListToAdd)
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
