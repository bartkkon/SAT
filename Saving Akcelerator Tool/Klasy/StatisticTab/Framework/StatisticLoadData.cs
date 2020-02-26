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
            //Ładoawnie danych do porównania danych DM
            _ = new StatisticDMLoad(MainProgram.Self.dmView.ObjectTable());

            //Ładowanie danych do prównania ilości produkowanych PNC w danym roku
            _ = new StatisticQuantityLoad(MainProgram.Self.productionQuantityView.ObjectTable());

            //Ładowanie danych do porównania ilości produkcyjnych PNC w poszczególnych miesiącahc
            _ = new StatisticQuantityMonthLoad(MainProgram.Self.productionQuantityMonthView1.ObjectTable());
        }
    }
}
