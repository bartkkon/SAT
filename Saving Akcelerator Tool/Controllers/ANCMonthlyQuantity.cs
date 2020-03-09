using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers
{
    class ANCMonthlyQuantity
    {
        public static IEnumerable<ANCMonthlyDB> LoadByYear(int FindYear)
        {
            var context = new DataBaseConnectionContext();

            var ANCListDB = context.ANCMonthly.Where(u => u.Year == FindYear).ToList();

            return ANCListDB;
        }

        public static IEnumerable<ANCMonthlyDB> LoadByYear_Month(int FindYear, int FindMonth)
        {
            var context = new DataBaseConnectionContext();

            var ANCListDB = context.ANCMonthly.Where(u => u.Year == FindYear && u.Month == FindMonth).ToList();

            return ANCListDB;
        }

        public static void RemoveList(IEnumerable<ANCMonthlyDB> ListaANC)
        {
            var context = new DataBaseConnectionContext();

            foreach (ANCMonthlyDB ANC in ListaANC)
            {
                context.Remove(ANC);
            }
            context.SaveChanges();
        }

        public static void AddList(IEnumerable<ANCMonthlyDB> ListaANC)
        {
            var context = new DataBaseConnectionContext();

            foreach(ANCMonthlyDB AddOne in ListaANC)
            {
                context.Add(AddOne);
            }
            context.SaveChanges();
        }
    }
}
