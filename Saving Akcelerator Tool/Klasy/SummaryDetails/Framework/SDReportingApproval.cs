using Saving_Accelerator_Tool.Klasy.Email;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework
{
    class SDReportingApproval
    {
        public SDReportingApproval(string Devision)
        {
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            decimal Year = MainProgram.Self.sdOptions1.GetYear();
            string MailTo;
            string ToReject;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");
            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

            ToReject = WhatIsToApprove(FrozenRow);

            if (FrozenRow != null)
            {
                if (Devision == "Electronic Rejected")
                {
                    FrozenRow["EleApp"] = "Close";
                    MailTo = new SentTo(true, false, false, false).SentToList();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().ReportRejected_Devision_Topic(), new MailInfo().ReportRejected_Devision_Body(ToReject));
                }
                else if (Devision == "Mechanic Rejected")
                {
                    FrozenRow["MechApp"] = "Close";
                    MailTo = new SentTo(false, true, false, false).SentToList();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().ReportRejected_Devision_Topic(), new MailInfo().ReportRejected_Devision_Body(ToReject));
                }
                else if (Devision == "NVR Rejected")
                {
                    FrozenRow["NVRApp"] = "Close";
                    MailTo = new SentTo(false, false, true, false).SentToList();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().ReportRejected_Devision_Topic(), new MailInfo().ReportRejected_Devision_Body(ToReject));
                }
                else if (Devision == "Electronic Approve")
                {
                    FrozenRow["EleApp"] = "Approve";
                    MailTo = new SentTo().SentToAdmin();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().RaportApprove_Devision_Topic("Electronic"), new MailInfo().RaportApprove_Devision_Body("Electronic", ToReject));
                    CheckIfAllDevisionApprove(FrozenRow, ToReject);
                }
                else if (Devision == "Mechanic Approve")
                {
                    FrozenRow["MechApp"] = "Approve";
                    MailTo = new SentTo().SentToAdmin();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().RaportApprove_Devision_Topic("Electronic"), new MailInfo().RaportApprove_Devision_Body("Electronic", ToReject));
                    CheckIfAllDevisionApprove(FrozenRow, ToReject);
                }
               else if (Devision == "NVR Approve")
                {
                    FrozenRow["NVRApp"] = "Approve";
                    MailTo = new SentTo().SentToAdmin();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().RaportApprove_Devision_Topic("Electronic"), new MailInfo().RaportApprove_Devision_Body("Electronic", ToReject));
                    CheckIfAllDevisionApprove(FrozenRow, ToReject);
                }
                else if (Devision == "Product Care Approve")
                {
                    FrozenRow["EleApp"] = "Close";
                    FrozenRow["MechApp"] = "Close";
                    FrozenRow["NVRApp"] = "Close";
                    FrozenRow[ToReject] = "Approve";
                    MailTo = new SentTo(true, true, true, true).SentToList();
                    SentEmail.Instance.Sent_Email(MailTo, new MailInfo().RaportApprove_PC_Topic(ToReject), new MailInfo().RaportApprove_PC_Body(ToReject));
                }
            }
            Data_Import.Singleton().Save_DataTableToTXT2(ref Frozen, "Frozen");
        }

        private string WhatIsToApprove(DataRow frozenRow)
        {

            if (frozenRow["BU"].ToString() == "Open")
            {
                return "BU";
            }
            if (frozenRow["EA1"].ToString() == "Open")
            {
                return "EA1";
            }
            if (frozenRow["EA2"].ToString() == "Open")
            {
                return "EA2";
            }
            if (frozenRow["EA3"].ToString() == "Open")
            {
                return "EA3";
            }
            for (int counter = 1; counter <= 12; counter++)
            {
                if (frozenRow[counter.ToString()].ToString() == "Open")
                {
                    return counter.ToString();
                }
            }

            return string.Empty;
        }

        private void CheckIfAllDevisionApprove(DataRow frozenRow, string ToApprove)
        {
            if (frozenRow["EleApp"].ToString() == "Approve" && frozenRow["MechApp"].ToString() == "Approve" && frozenRow["NVRApp"].ToString() == "Approve")
            {
                string MailTo = new SentTo(false, false, false, true).SentToList();
                SentEmail.Instance.Sent_Email(MailTo, new MailInfo().RaportApprove_AllDevision_Topic(), new MailInfo().RaportApprove_AllDevison_Body(ToApprove));
            }
        }
    }
}
