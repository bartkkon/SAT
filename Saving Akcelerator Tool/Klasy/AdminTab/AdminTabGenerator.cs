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
        private  TabPage _adminTab;

        public AdminTabGenerator()
        {
            GeneretedTab();


            ColumnFirst(15);

            ColumnSecond(220);

            ColumnThird(425);

            ColumnFourth(830);

            ColumnFifth(1135);

            ColumnSixth(1290);
        }

        private void GeneretedTab()
        {
            TabPage tab_Admin = new TabPage
            {
                Location = new Point(4, 22),
                Name = "tab_Admin",
                Size = new Size(1826, 877),
                TabIndex = 7,
                Text = "Administration",
                UseVisualStyleBackColor = true
            };
            MainProgram.Self.TabControl.Controls.Add(tab_Admin);
            _adminTab = tab_Admin;
        }

        private void ColumnSixth(int StartColumn)
        {
            int Row = 15;

            //Wysyłanie Maili z Admina;
            SendMailView SendMail = new SendMailView
            {
                Location = new Point(StartColumn, Row)
            };
            _adminTab.Controls.Add(SendMail);
        }

        private void ColumnFifth(int StartColumn)
        {
            int Row = 15;

            //Ładowanie Baz Danych 
            DataBaseView DataBase = new DataBaseView
            {
                Location = new Point(StartColumn, Row),
            };
            _adminTab.Controls.Add(DataBase);

        }

        private void ColumnFourth(int StartColumn)
        {
            int Row = 15;

            //Sprawdzania i dodawanie Targetów dla poszczególnych działów i łacznie dla całego PC
            TargetView Target = new TargetView
            {
                Location = new Point(StartColumn, Row),
            };
            _adminTab.Controls.Add(Target);

            Row += Target.Size.Height;

            //Waluty dostępne w programie (EURO, USD, SEK) plus ECCC(na sek)
            CoinsView Coins = new CoinsView
            {
                Location = new Point(StartColumn, Row),
            };
            _adminTab.Controls.Add(Coins);
        }

        private void ColumnThird(int StartColumn)
        {
            int Row = 15;

            //Dodawania konta lub zmiany jego praw
            AddPersonView AccessView = new AddPersonView
            {
                Location = new Point(StartColumn, Row)
            };
            _adminTab.Controls.Add(AccessView);

            Row += AccessView.Size.Height;

            //Wszystko co z STK związane
            AutoUpdateSTKView AutoSTK = new AutoUpdateSTKView
            {
                Location = new Point(StartColumn, Row)
            };
            _adminTab.Controls.Add(AutoSTK);

        }

        private void ColumnSecond(int StartColumn)
        {
            int Row = 15;
            //Forzen sprawdzanie który miesiąc można kalkulowac a który nie 
            Frozen frozen = new Frozen
            {
                Location = new Point(StartColumn, Row),
            };
            _adminTab.Controls.Add(frozen);

            Row += frozen.Size.Height;

            ActionActivatorView ActionActivator = new ActionActivatorView
            {
                Location = new Point(StartColumn, Row)
            };
            _adminTab.Controls.Add(ActionActivator);
        }

        private void ColumnFirst(int StartColumn)
        {
            int Row = 15;
            //Dodawanie ilości dla Rewizji
            QuantityRevAddView RevQuantity = new QuantityRevAddView
            {
                Location = new Point(StartColumn, Row),
            };
            _adminTab.Controls.Add(RevQuantity);

            Row += RevQuantity.Size.Height;

            QuantityMonthAddView MonthQuantity = new QuantityMonthAddView
            {
                Location = new Point(StartColumn, Row),
            };
            _adminTab.Controls.Add(MonthQuantity);

            Row += MonthQuantity.Size.Height;

            //Sumowanie ilości miesięcznych PNC do odpowiednich grup
            SumPNC Sum = new SumPNC
            {
                Location = new Point(StartColumn, Row),
            };
            _adminTab.Controls.Add(Sum);
        }
    }
}
