using Saving_Accelerator_Tool.Klasy.Platform.Framework;
using Saving_Accelerator_Tool.Klasy.Platform.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform
{
    public class PlatformTabGenerator
    {
        private TabPage _PlatformTab;
        public PlatformTabGenerator()
        {
            CreateTab();
            PlatformViewGenerator();
            LoadDeflautData();
        }

        

        private void CreateTab()
        {
            TabPage tab_Platform = new TabPage
            {
                Location = new Point(4, 22),
                Name = "tab_Platform",
                Size = new Size(1826, 877),
                TabIndex = 4,
                Text = "Platform",
                UseVisualStyleBackColor = true
            };
            MainProgram.Self.TabControl.Controls.Add(tab_Platform);
            _PlatformTab = tab_Platform;
        }

        private void PlatformViewGenerator()
        {
            //Ładowanie opcji dla Platform 
            _ = new  OptionView(_PlatformTab);

            //Ładowanie Drzwa PNC dla wybranego Projektu
            _ = new PNCTreeView(_PlatformTab);

            //Ładowanie przycisków akcji
            _ = new ButtonView(_PlatformTab);

            //Ładowanie Specyfikacji dla PNC i jego predecessora
            _ = new SpecificationView(_PlatformTab);
        }

        private void LoadDeflautData()
        {
            //Ładowanie listy projektów które są w aktualnym roku
            _ = new LoadProjects();
        }
    }
}
