using Saving_Accelerator_Tool.Klasy.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.Email
{
    class MailInfo
    {
        private readonly Dictionary<int, string> Month = new Dictionary<int, string>()
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

        public string RaportApprove_Devision_Topic(string Devision)
        {
            string Header;

            Header = Devision + " data has been approved!";

            return Header;
        }

        public string RaportApprove_Devision_Body(string Devision, string WhatApprove)
        {
            string Body;

            if (WhatApprove == "BU" || WhatApprove == "EA1" || WhatApprove == "EA2" || WhatApprove == "EA3")
                Body = "User " + Users.Singleton().Name + " has approved " + Devision + " data for Revison " + WhatApprove + ".";
            else
                Body = "User " + Users.Singleton().Name + " has approved " + Devision + " data for Month: " + Month[int.Parse(WhatApprove)] + ".";

            return Body;
        }

        public string RaportApprove_AllDevision_Topic()
        {
            string Header;

            Header = "All Departments has approved Data!";

            return Header;
        }

        public string RaportApprove_AllDevison_Body(string WhatApprove)
        {
            string Body;
            if (WhatApprove == "BU" || WhatApprove == "EA1" || WhatApprove == "EA2" || WhatApprove == "EA3")
                Body = "All Departments has Aproved Data for Revison " + WhatApprove + "." + Environment.NewLine + Environment.NewLine + "Now your move !";
            else
                Body = "All Departments has Aproved Data for Month: " + Month[int.Parse(WhatApprove)] + "." + Environment.NewLine + Environment.NewLine + "Now your move !";

            return Body;
        }

        public string RaportApprove_ProductCare_Approve_Topic()
        {
            string Header;

            Header = "Congratulation !!!";

            return Header;
        }

        public string RaportApprove_ProductCare_Approve_Body(string WhatApprove)
        {
            string Body;

            if (WhatApprove == "BU" || WhatApprove == "EA1" || WhatApprove == "EA2" || WhatApprove == "EA3")
                Body = "Revison " + WhatApprove + " has been Approved!! " + Environment.NewLine + Environment.NewLine + "Congratulation !";
            else
                Body = "Savings for " + Month[int.Parse(WhatApprove)] + "has been Approved!"+ Environment.NewLine + Environment.NewLine + "Congratulation !";

            return Body;
        }

        public string ReportRejected_Devision_Topic()
        {
            string Header;

            Header = "Your Report has been REJECTED!";

            return Header;
        }

        public string ReportRejected_Devision_Body(string WhatReject)
        {
            string Body;
            if (WhatReject == "BU" || WhatReject == "EA1" || WhatReject == "EA2" || WhatReject == "EA3")
                Body = "Your raport for rewizion " + WhatReject + "has been REJECTED!!" + Environment.NewLine + Environment.NewLine + "Do something!";
            else
                Body = "Your raport for month " + WhatReject + "has been REJECTED!!" + Environment.NewLine + Environment.NewLine + "Do something!";

            return Body;
        }
    }
}
