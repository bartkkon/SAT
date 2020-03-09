using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View.AdminTabTable.View
{
    public partial class OptionsView : UserControl
    {

        public decimal GetYear()
        {
            return num_Year.Value;
        }

        public decimal GetMonth()
        {
            return num_OptionMonth.Value;
        }

        public string GetRevision()
        {
            if (comb_Revision.SelectedItem == null)
                return "";

            return comb_Revision.SelectedItem.ToString();
        }

        public OptionsView()
        {
            InitializeComponent();
        }
    }
}
