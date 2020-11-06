using Saving_Accelerator_Tool.Controllers;
using Saving_Accelerator_Tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Coins
{
    class SaveCoins
    {
        public SaveCoins(int _Year, double _ECCC, double _Euro, double _Dolars, double _Sek)
        {
            IEnumerable<Targets_CoinsDB> List = TargetsCoinsController.Load_Year(_Year);

            if (List.Count() == 0)
            {
                var NewRow = new Targets_CoinsDB
                {
                    Year = _Year,
                    ECCC = _ECCC,
                    Euro = _Euro,
                    USD = _Dolars,
                    SEK = _Sek,
                };
                TargetsCoinsController.AddValue(NewRow);
            }
            else
            {
                List.First().ECCC = _ECCC;
                List.First().Euro = _Euro;
                List.First().USD = _Dolars;
                List.First().SEK = _Sek;
                TargetsCoinsController.UpdateValue(List.First());
            }
        }
    }
}
