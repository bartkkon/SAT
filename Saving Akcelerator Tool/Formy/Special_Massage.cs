using Saving_Accelerator_Tool.Klasy.Email;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Formy
{
    public partial class Special_Massage : Form
    {
        private readonly bool _Electronic;
        private readonly bool _Mechanic;
        private readonly bool _NVR;
        private readonly bool _PC;

        public Special_Massage(bool Electronic, bool Mechanic, bool NVR, bool PC)
        {
            _Electronic = Electronic;
            _Mechanic = Mechanic;
            _NVR = NVR;
            _PC = PC;

            InitializeComponent();
        }

        private void Pb_AdminSpecialMessage_Send_Click(object sender, EventArgs e)
        {
            if(tb_AdminSpecialMassage_Subject.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Subject can't be Empty!");
                return;
            }
            if(tb_AdminSpecialMassage_Body.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Body can't be Empty!");
                return;
            }

            string MailTo = new SentTo(_Electronic, _Mechanic, _NVR, _PC).SentToList();
            SentEmail.Instance.Sent_Email(MailTo, tb_AdminSpecialMassage_Subject.Text, tb_AdminSpecialMassage_Body.Text);

            this.Close();
        }
    }
}
