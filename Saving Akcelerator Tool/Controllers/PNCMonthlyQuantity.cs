using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers
{
    class PNCMonthlyQuantity
    {
        public static IEnumerable<PNCMonthlyDB> LoadByYear(int FindYear)
        {
            var context = new DataBaseConnectionContext();

            var PNCListDB = context.PNCMonthly.Where(u => u.Year == FindYear).ToList();

            return PNCListDB;
        }

        public static IEnumerable<PNCMonthlyDB> LoadByYear_Month(int FindYear, int FindMonth)
        {
            var context = new DataBaseConnectionContext();

            var PNCListDB = context.PNCMonthly.Where(u => u.Year == FindYear && u.Month == FindMonth).ToList();

            return PNCListDB;
        }

        public static void RemoveList(IEnumerable<PNCMonthlyDB> ListaPNC)
        {
            var context = new DataBaseConnectionContext();

            foreach (PNCMonthlyDB PNC in ListaPNC)
            {
                context.Remove(PNC);
            }
            context.SaveChanges();
        }

        public static void AddList(IEnumerable<PNCMonthlyDB> ListaPNC)
        {
            var context = new DataBaseConnectionContext();

            foreach (PNCMonthlyDB PNC in ListaPNC)
            {
                context.Add(PNC);
            }
            context.SaveChanges();
        }
    }
}
