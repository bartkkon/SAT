using Saving_Accelerator_Tool.Klasy.Platform.Handlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform.View
{
    public class OptionView : OptionHandler
    {
        private readonly TabPage _PlatformTab;
        private GroupBox _Option;
        public OptionView(TabPage PlatformTab)
        {
            _PlatformTab = PlatformTab;

            GroupBoxCreate();
            Settings();
        }

        private void GroupBoxCreate()
        {
            GroupBox gb_Option = new GroupBox
            {
                Location = new Point(10, 10),
                Size = new Size(250, 100),
                Name = "gb_PlatformOption",
                Text = "Option",
                TabStop = false,
            };
            _PlatformTab.Controls.Add(gb_Option);
            _Option = gb_Option;
        }

        private void Settings()
        {
            Year();
            Projects();
        }

        private void Projects()
        {
            Label lab_Project = new Label
            {
                Location = new Point(15, 47),
                Size = new Size(10, 10),
                AutoSize = true,
                Text = "Project Name:",
            };
            _Option.Controls.Add(lab_Project);

            ComboBox comb_Project = new ComboBox
            {
                Location = new Point(120, 45),
                Size = new Size(90, 21),
                Name = "combo_Project",
                FormattingEnabled = true,
            };
            comb_Project.SelectedIndexChanged += new EventHandler(comb_Project_SelectedIndexChange);
            _Option.Controls.Add(comb_Project);
        }

        private void Year()
        {
            Label lab_Year = new Label
            {
                Location = new Point(15, 17),
                Size = new Size(10, 10),
                AutoSize = true,
                Text = "Project start Year:",
            };
            _Option.Controls.Add(lab_Year);

            NumericUpDown num_Year = new NumericUpDown
            {
                Location = new Point(120, 15),
                Size = new Size(78, 20),
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
                Name = "num_Platform_YearOption",
                Value = DateTime.UtcNow.Year,
            };
            num_Year.ValueChanged += new EventHandler(num_Year_ValueChange);
            _Option.Controls.Add(num_Year);
        }
    }
}
