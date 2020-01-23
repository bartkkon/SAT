using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.AdmnTab.Mail
{
    public class SendMailInfo
    {
        private readonly Dictionary<decimal, string> Month = new Dictionary<decimal, string>()
        {
            { 1,"January" },
            { 2,"February" },
            { 3,"March" },
            { 4,"April" },
            { 5,"May" },
            { 6,"June" },
            { 7,"July" },
            { 8,"August" },
            { 9,"September" },
            { 10,"October" },
            { 11,"November" },
            { 12,"Decembr" },
        };

        public string Admin_NewDataAvailable_Month_Topic(decimal MonthData)
        {
            string Header;

            Header = "New Data for " + Month[MonthData] + " - Available!";

            return Header;
        }

        public string Admin_NewDataAvailable_Revision_Topic(string Revision, decimal Year)
        {
            string Header;

            Header = "New Data for " + Revision + " " + Year.ToString() + " - Available!";

            return Header;
        }

        public string Admin_NewDataAvailable_Month_Body(decimal MonthData)
        {
            string Body;

            Body = "New Data for " + Month[MonthData] + " - Available!" + Environment.NewLine + Environment.NewLine + "Now your move!";

            return Body;
        }

        public string Admin_NewDataAvailable_Revision_Body(string Revision, decimal Year)
        {
            string Body;

            Body = "New Data for " + Revision + " " + Year.ToString() + " - Available!" + Environment.NewLine + Environment.NewLine + "Now your move!";

            return Body;
        }
    }
}
