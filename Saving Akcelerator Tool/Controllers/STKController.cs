using Saving_Accelerator_Tool.Data;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Controllers
{
    class STKController
    {
        public static IEnumerable<STKDB> Load_By_Year(int FindYear)
        {
            var context = new DataBaseConnectionContext();

            var STKList = context.STK.Where(u => u.Year == FindYear).ToList();

            return STKList;
        }

        public static STKDB Load (int FindYear, string FindANC)
        {
            var context = new DataBaseConnectionContext();

            var STK = context.STK.Where(u => u.Year == FindYear && u.ANC == FindANC).FirstOrDefault();

            return STK;
        }

        public static void AddNewValue(STKDB ToAdd)
        {
            var context = new DataBaseConnectionContext();

            context.Add(ToAdd);
            context.SaveChanges();
        }

        public static void UpdateValue(STKDB UpdateRow)
        {
            var context = new DataBaseConnectionContext();

            context.Update(UpdateRow);
            context.SaveChanges();
        }

        public static void Remove_Year(int YearToRemove)
        {
            var context = new DataBaseConnectionContext();

            var FindList = context.STK.Where(u => u.Year == YearToRemove).ToList();

            context.Remove(FindList);
            context.SaveChanges();
        }

        public static void AddManualUpdate(IEnumerable<STKDB> ListToAdd)
        {
            var context = new DataBaseConnectionContext();

            context.Add(ListToAdd);
            context.SaveChanges();
        }

    }
}
