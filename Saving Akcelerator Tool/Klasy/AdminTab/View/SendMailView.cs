using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.AdmnTab.Handlers;
using Saving_Accelerator_Tool.Klasy.Email;
using Saving_Accelerator_Tool.Klasy.AdmnTab.Mail;
using Saving_Accelerator_Tool.Formy;

namespace Saving_Accelerator_Tool.Klasy.AdmnTab.View
{
    public partial class SendMailView : UserControl
    {
        public SendMailView()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            if (DateTime.UtcNow.Month == 1)
                num_SentMailAdmin_Month.Value = 12;
            else
                num_SentMailAdmin_Month.Value = DateTime.UtcNow.Month - 1;

            num_SendMailAdmin_year.Value = DateTime.UtcNow.Year;

            if (DateTime.UtcNow.Month <= 3)
                comb_SendMailAdmin_Revision.SelectedIndex = 1;
            else if (DateTime.UtcNow.Month <= 6)
                comb_SendMailAdmin_Revision.SelectedIndex = 2;
            else if (DateTime.UtcNow.Month <= 9)
                comb_SendMailAdmin_Revision.SelectedIndex = 3;
            else
            {
                comb_SendMailAdmin_Revision.SelectedIndex = 0;
                num_SendMailAdmin_year.Value = DateTime.UtcNow.Year + 1;
            }

        }

        private void Pb_SendMail_NewCalc_Click(object sender, EventArgs e)
        {
            string MailTo;
            decimal Month = num_SentMailAdmin_Month.Value;

            MailTo = new SentTo(cb_SendMailAdmin_Electronic.Checked, cb_SendMailAdmin_Mechanic.Checked, cb_SendMailAdmin_NVR.Checked, cb_SendMailAdmin_PC.Checked).SentToList();
            SentEmail.Instance.Sent_Email(MailTo, new SendMailInfo().Admin_NewDataAvailable_Month_Topic(Month), new SendMailInfo().Admin_NewDataAvailable_Month_Body(Month));
        }

        private void Pb_SendMailAdmin_NewData_Revsion_Click(object sender, EventArgs e)
        {
            string MailTo;
            decimal Year = num_SendMailAdmin_year.Value;
            string Revision = comb_SendMailAdmin_Revision.SelectedItem.ToString();

            MailTo = new SentTo(cb_SendMailAdmin_Electronic.Checked, cb_SendMailAdmin_Mechanic.Checked, cb_SendMailAdmin_NVR.Checked, cb_SendMailAdmin_PC.Checked).SentToList();
            SentEmail.Instance.Sent_Email(MailTo, new SendMailInfo().Admin_NewDataAvailable_Revision_Topic(Revision, Year), new SendMailInfo().Admin_NewDataAvailable_Revision_Body(Revision, Year));
        }

        private void Pb_Admin_SendMail_SpecialMassage_Click(object sender, EventArgs e)
        {
            Special_Massage SpecialMassage = new Special_Massage(cb_SendMailAdmin_Electronic.Checked, cb_SendMailAdmin_Mechanic.Checked, cb_SendMailAdmin_NVR.Checked, cb_SendMailAdmin_PC.Checked);
            SpecialMassage.ShowDialog();
        }
    }
}
