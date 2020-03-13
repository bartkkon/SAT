using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View.AdminTabTable
{
    public partial class AdminTableView : UserControl
    {
        public AdminTableView()
        {
            InitializeComponent();
        }



        public DataGridView ReturnDataGridView()
        {
            return DGV_AdminTable;
        }
    }
}
