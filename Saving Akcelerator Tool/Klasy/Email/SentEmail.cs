using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Email
{
    class SentEmail
    {
        private static SentEmail _interface;
        private static object syncRoot = new object();

        private SentEmail()
        {
        }

        public void Sent_Email(string MailTo, string Topic, string Body)
        {
            sendmail(MailTo, Topic, Body);
        }

        public static SentEmail Instance
        {
            get
            {
                if (_interface == null)
                {
                    lock (syncRoot)
                    {
                        if (_interface == null)
                            _interface = new SentEmail();
                    }
                }
                return _interface;
            }
        }


        private void sendmail(string MailTo, string project, string status)
        {
            if (MailTo != null)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("10.26.10.85", 25);
                mail.From = new MailAddress("SavingAcceleratorTool@electrolux.com");
                mail.To.Add(MailTo);
                mail.Subject = project;
                mail.Body = status;


                SmtpServer.Credentials = new System.Net.NetworkCredential("SavingAcceleratorTool@electrolux.com", "");
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
            }
        }

    }
}
