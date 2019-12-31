using Saving_Accelerator_Tool.Klasy.StatisticTab.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Saving_Accelerator_Tool.Klasy.StatisticTab.View
{
    class StatisticOptionView : StatisticOptionHandler
    {
        private TabPage _StatisticTab;
        private GroupBox _gb_Option;

        public StatisticOptionView(TabPage StatisticTab): base()
        {
            _StatisticTab = StatisticTab;

            GroupBoxCreate();
            YearOptionAdd();
            ButtonToLoadData();
        }

        //GrupBox dla Opcji w tabie Statystyka
        private void GroupBoxCreate()
        {
            GroupBox gb_Option = new GroupBox
            {
                Location = new Point(0, 5),
                Size = new Size(200, 300),
                Text = "Option:",
                Name = "gb_StatisticOption",
                TabStop = false,
            };
            _StatisticTab.Controls.Add(gb_Option);

            _gb_Option = gb_Option;
        }

        //Wybranie roku jakie ma ją być pokazane dane 
        private void YearOptionAdd()
        {
            Label YearLabel = new Label
            {
                Location = new Point(10, 20),
                AutoSize = true,
                Size = new Size(5, 5),
                Text = "Year:"
            };
            _gb_Option.Controls.Add(YearLabel);

            NumericUpDown Year = new NumericUpDown
            {
                Location = new Point(80, 20),
                Size = new Size(80, 25),
                Name = "num_StatisticYearOption",
                Maximum = new decimal(new int[] {
                    2100,
                    0,
                    0,
                    0 }),
                Minimum = new decimal(new int[] {
                    2018,
                    0,
                    0,
                    0 }),
                Value = DateTime.UtcNow.Year,
            };
            _gb_Option.Controls.Add(Year);
        }

        //przycisk do odświerzenia danych
        private void ButtonToLoadData()
        {
            Button LoadButton = new Button
            {
                Location = new Point(50, 100),
                Size = new Size(100, 30),
                Name = "pb_StatisticLoadButton",
                Text = "Load Data",
            };
            LoadButton.Click += new EventHandler(LoadButton_Click);
            _gb_Option.Controls.Add(LoadButton);
        }
    }
}
