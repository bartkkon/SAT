using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab.Framework
{
    public class StatisticLoadData
    {
        public StatisticLoadData()
        {

        }

        public void LoadData()
        {
            //Ładoawnie danych do porównania danych DM
            _ =  new StatisticDMLoad();

            //Ładowanie danych do prównania ilości produkowanych PNC w danym roku
            _ = new StatisticQuantityLoad();

            //Ładowanie danych do porównania ilości produkcyjnych PNC w poszczególnych miesiącahc
            _ = new StatisticQuantityMonthLoad();
        }
    }
}
