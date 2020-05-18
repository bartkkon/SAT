using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Controllers.Excptions
{
    class NoConnection
    {
        public static void Info()
        {
            string Button1 = "Retry";
            string Button2 = "Cancel";

            if(CultureInfo.CurrentCulture.Name == "pl-PL")
            {
                Button1 = "Ponów próbę";
                Button2 = "Anuluj";
            }
            else if(CultureInfo.CurrentCulture.Name == "en-EN")
            {
                Button1 = "Retry";
                Button2 = "Cancel";
            }

            DialogResult Result = MessageBox.Show("Problem with connection to Company Network. Please check connection." +
                       Environment.NewLine + Environment.NewLine +
                       "To try again, please press '" + Button1 + "' button," +
                       Environment.NewLine +
                       "To close application, please press '" + Button2 + "' button."
                       , "Connection Error!", MessageBoxButtons.RetryCancel);

            if (Result == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }
        }
    }
}
