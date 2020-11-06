using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Coins
{
    class RefreshCoins
    {
        public RefreshCoins(int Year)
        {
            IEnumerable<Targets_CoinsDB> List = TargetsCoinsController.Load_Year(Year);

            MainProgram.Self.CoinsView.Clear();

            if(List.Count() == 0)
            {
                return;
            }
            else if(List.Count() == 1)
            {
                if (List.First().Year == Year)
                {
                    MainProgram.Self.CoinsView.GetECCC(List.First().ECCC);
                    MainProgram.Self.CoinsView.GetEuro(List.First().Euro);
                    MainProgram.Self.CoinsView.GetUSD(List.First().USD);
                    MainProgram.Self.CoinsView.GetSEK(List.First().SEK);
                }
            }
            else
            {
                MessageBox.Show("Coś za dużo lat!");
            }
        }
    }
}
