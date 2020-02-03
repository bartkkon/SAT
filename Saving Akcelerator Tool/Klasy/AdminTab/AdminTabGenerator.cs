using Saving_Accelerator_Tool.Klasy.AdminTab.View;
using Saving_Accelerator_Tool.Klasy.AdmnTab.View;
using System;
using System.Collections.Generic;
using System.Drawing;
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

            //Wysyłanie Maili z Admina;
            SendMailView SendMail = new SendMailView
            {
                Location = new Point(1135, 85)
            };
            _adminTab.Controls.Add(SendMail);

            //Automatyczne przliczaie STK w akcjach Z tenego roku
            AutoUpdateSTKView AutoSTK = new AutoUpdateSTKView
            {
                Location = new Point(425, 680)
            };
            _adminTab.Controls.Add(AutoSTK);

            //Dodawania konta lub zmiany jego praw
            AddPersonView AccessView = new AddPersonView
            {
                Location = new Point(425, 15)
            };
            _adminTab.Controls.Add(AccessView);

            //Sumowanie ilości miesięcznych PNC do odpowiednich grup
            SumPNC Sum = new SumPNC
            {
                Location = new Point(15, 525),
            };
            _adminTab.Controls.Add(Sum);
        }
    }
}
