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
            MainProgram.Self.DMView.ClearDataGridView();
            _ = new StatisticDMLoad(MainProgram.Self.DMView.ObjectTable(), MainProgram.Self.DMView.GetExchangeRate());

            //Ładowanie danych do prównania ilości produkowanych PNC w danym roku
            MainProgram.Self.productionQuantityView.ClearDataGridView();
            _ = new StatisticQuantityLoad(MainProgram.Self.productionQuantityView.ObjectTable());

            //Ładowanie danych do porównania ilości produkcyjnych PNC w poszczególnych miesiącahc
            _ = new StatisticQuantityMonthLoad(MainProgram.Self.ProductionQuantityMonthView.ObjectTable());
        }
    }
}
