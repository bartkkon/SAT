using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers
{
    class PNCRevisionQuantity
    {
        public static IEnumerable<PNCRevisionDB> LoadByYear(int FindYear)
        {
            var context = new DataBaseConnectionContext();

            var PNCListDB = context.PNCRevision.Where(u => u.Year == FindYear).ToList();

            return PNCListDB;
        }

        public static IEnumerable<PNCRevisionDB> LoadByYear_Month(int FindYear, int FindMonth)
        {
            var context = new DataBaseConnectionContext();

            var PNCListDB = context.PNCRevision.Where(u => u.Year == FindYear && u.Month == FindMonth).ToList();

            return PNCListDB;
        }

        public static IEnumerable<PNCRevisionDB> LoadByYear_Month_Revision(int FindYear, int FindMonth, string FindRevision)
        {
            var context = new DataBaseConnectionContext();

            var PNCListDB = context.PNCRevision.Where(u => u.Year == FindYear && u.Month == FindMonth && u.Revision == FindRevision).ToList();

            return PNCListDB;
        }

        public static IEnumerable<PNCRevisionDB> LoadByYear_Revision(int FindYear, string FindRevision)
        {
            var context = new DataBaseConnectionContext();

            var PNCListDB = context.PNCRevision.Where(u => u.Year == FindYear && u.Revision == FindRevision).ToList();

            return PNCListDB;
        }

        public static void RemoveList(IEnumerable<PNCRevisionDB> ListPNC)
        {
            var context = new DataBaseConnectionContext();
            foreach (var PNC in ListPNC)
            {
                context.Remove(PNC);
            }

            context.SaveChanges();
        }

        public static void AddList(IEnumerable<PNCRevisionDB> ListaPNC)
        {
            var context = new DataBaseConnectionContext();

            foreach (var PNC in ListaPNC)
            {
                context.Add(PNC);
            }

            context.SaveChanges();
        }
    }
}
