using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform.View
{
    public class SpecificationView
    {
        private readonly TabPage _platformTab;
        private GroupBox _SpecificationGourpBox;
        public SpecificationView(TabPage PlatformTab)
        {
            _platformTab = PlatformTab;

            CreateGroupBox();
            TopLable();
            PNC();
            Brand();
            Master();
            Denomination();
            Platform();
            Installation();
            FlowDevice();
            Motor();
            Class();
            Noise();
            EDW();
            EDWColor();
            PB();
            Voltage();
            Frequency();
            OffMode();
        }

        private void CreateGroupBox()
        {
            GroupBox Specification = new GroupBox
            {
                Location = new Point(270, 90),
                Size = new Size(450, 600),
                Name = "Gb_SpecifivationView",
                Text = "Specification",
            };
            _platformTab.Controls.Add(Specification);
            _SpecificationGourpBox = Specification;
        }

        private void OffMode()
        {
            CreateRowSpec("OffMode", 16);
        }

        private void Frequency()
        {
            CreateRowSpec("Frequency", 15);
        }

        private void Voltage()
        {
            CreateRowSpec("Voltage", 14);
        }

        private void EDWColor()
        {
            CreateRowSpec("Color", 13);
        }

        private void PB()
        {
            CreateRowSpec("PB", 12);
        }

        private void EDW()
        {
            CreateRowSpec("EDW", 11);
        }

        private void Noise()
        {
            CreateRowSpec("Noise", 10);
        }

        private void Class()
        {
            CreateRowSpec("Class", 9);
        }

        private void Motor()
        {
            CreateRowSpec("Motor", 8);
        }

        private void FlowDevice()
        {
            CreateRowSpec("FlowDevice", 7);
        }

        private void Installation()
        {
            CreateRowSpec("Instalation", 6);
        }

        private void Platform()
        {
            CreateRowSpec("Platform", 5);
        }

        private void Denomination()
        {
            CreateRowSpec("Denomination", 4);
        }

        private void Master()
        {
            CreateRowSpec("Master", 3);
        }

        private void Brand()
        {
            CreateRowSpec("Brand", 2);
        }

        private void PNC()
        {
            CreateRowSpec("PNC", 1);
        }

        private void TopLable()
        {
            Label Actual = new Label
            {
                Location = new Point(150, 20),
                Size = new Size(10, 100),
                AutoSize = true,
                Name = "lab_Platform_Actual",
                Text = "Actual",
                Font = new Font("Arial", 16, FontStyle.Bold),
            };
            _SpecificationGourpBox.Controls.Add(Actual);

            Label Predecessor = new Label
            {
                Location = new Point(250, 20),
                Size = new Size(10, 10),
                AutoSize = true,
                Name = "lab_Platform_Predecessor",
                Text = "Predecessor",
                Font = new Font("Arial", 16, FontStyle.Bold),
            };
            _SpecificationGourpBox.Controls.Add(Predecessor);
        }

        private void CreateRowSpec(string Name, int Position)
        {
            Label Header = new Label
            {
                Location = new Point(20, (60 + ((Position - 1) * 25))),
                Size = new Size(10, 10),
                AutoSize = true,
                Name = "lab_Platform_" + Name,
                Text = Name + ":",
            };
            Header.Font = new Font(Header.Font, FontStyle.Bold);
            _SpecificationGourpBox.Controls.Add(Header);

            Label New = new Label
            {
                Location = new Point(130, (55 + ((Position - 1) * 25))),
                Size = new Size(120, 20),
                Name = "lab_Platform_" + Name + "Actual",
                Text = "",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            _SpecificationGourpBox.Controls.Add(New);

            Label Old = new Label
            {
                Location = new Point(260, (55 + ((Position - 1) * 25))),
                Size = new Size(120, 20),
                Name = "lab_Platform_" + Name + "Precedessor",
                Text = "",
                TextAlign = ContentAlignment.MiddleCenter,
            };
            _SpecificationGourpBox.Controls.Add(Old);
        }
    }
}
