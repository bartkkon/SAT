using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers
{
    class ANCRevisionQuantity
    {
        public static IEnumerable<ANCRevisionDB> LoadByYear(int FindYear)
        {
            var context = new DataBaseConnectionContext();

            var ANCListDB = context.ANCRevision.Where(u => u.Year == FindYear).ToList();

            return ANCListDB;
        }

        public static IEnumerable<ANCRevisionDB> LoadByYear_Month(int FindYear, int FindMonth)
        {
            var context = new DataBaseConnectionContext();

            var ANCListDB = context.ANCRevision.Where(u => u.Year == FindYear && u.Month == FindMonth).ToList();

            return ANCListDB;
        }

        public static IEnumerable<ANCRevisionDB> LoadByYear_Month_Revision(int FindYear, int FindMonth, string FindRevision)
        {
            var context = new DataBaseConnectionContext();

            var ANCListDB = context.ANCRevision.Where(u => u.Year == FindYear && u.Month == FindMonth && u.Revision == FindRevision).ToList();

            return ANCListDB;
        }

        public static IEnumerable<ANCRevisionDB> LoadByYear_Revision(int FindYear, string FindRevision)
        {
            var context = new DataBaseConnectionContext();

            var ANCListDB = context.ANCRevision.Where(u => u.Year == FindYear && u.Revision == FindRevision).ToList();

            return ANCListDB;
        }

        public static void RemoveList(IEnumerable<ANCRevisionDB> ListANC)
        {
            var context = new DataBaseConnectionContext();

            foreach(ANCRevisionDB ANC in ListANC)
            {
                context.Remove(ANC);
            }
            context.SaveChanges();
        }
    }
}
