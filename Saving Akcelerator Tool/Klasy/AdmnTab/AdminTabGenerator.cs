using Saving_Accelerator_Tool.Klasy.AdmnTab.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdmnTab
{
    class AdminTabGenerator
    {
        private readonly TabPage _adminTab;

        public AdminTabGenerator(TabPage AdminTab)
        {
            _adminTab = AdminTab;

            AdminViewGenerator();
        }

        private void AdminViewGenerator()
        {
            //Ładowanie do bazy zrzutu z IDB;
            _ = new IDBView(_adminTab);
        }
    }
}
