using Saving_Accelerator_Tool.Klasy.StatisticTab.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab
{
    public class StatisticTabGenerator
    {
        private TabPage _StatisticTab;

        public StatisticTabGenerator(TabPage StatisticTab)
        {
            _StatisticTab = StatisticTab;

            StatisticViewGenerator();
        }

        private void StatisticViewGenerator()
        {
            //Opcje do danych statystycznych
            _ = new StatisticOptionView(_StatisticTab);

            //Porównanie DM dla Wybranego roku
            _ = new StatisticDMView(_StatisticTab);

            //Porównanie ilości produkcyjnych wszstkich w danym roku po rewizjach
            _ = new StatisticQuantityView(_StatisticTab);

            //Porównanie ilości produkcyjnych w zależności do miesiąca z możliwością wybrou większej ilości szczegółów
            _ = new StatisticQuantityMonthView(_StatisticTab);
        }
    }
}
