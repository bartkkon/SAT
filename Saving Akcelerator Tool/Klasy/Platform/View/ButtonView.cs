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
    public class ButtonView : ButtonHandler
    {
        private readonly TabPage _platformTab;
        private GroupBox _ButtonActionGroupBox;

        public ButtonView(TabPage PlatformTab)
        {
            _platformTab = PlatformTab;

            CreateGroupBox();
            ActionButtons();
        }

        private void CreateGroupBox()
        {
            GroupBox gb_ButtonAction = new GroupBox
            {
                Location = new Point(270, 10),
                Size = new Size(800, 70),
                Name = "gb_Platform_ButtonAction",
                Text = "",
                TabStop = false,
            };
            _platformTab.Controls.Add(gb_ButtonAction);
            _ButtonActionGroupBox = gb_ButtonAction;
        }

        private void ActionButtons()
        {
            Button NewPNC = new Button
            {
                Location = new Point(20, 15),
                Size = new Size(100, 40),
                Name = "pb_Platform_NewPNC",
                Text = "Add PNC",
            };
            NewPNC.Click += new EventHandler(Pb_NewPNC_Click);
            _ButtonActionGroupBox.Controls.Add(NewPNC);

            Button DeletePNC = new Button
            {
                Location = new Point(140, 15),
                Size = new Size(100, 40),
                Name = "pb_Platform_DeletePNC",
                Text = "Delete PNC",
            };
            DeletePNC.Click += new EventHandler(Pb_DeletePNC_Click);
            _ButtonActionGroupBox.Controls.Add(DeletePNC);

            Button ChangePNC = new Button
            {
                Location = new Point(260, 15),
                Size = new Size(100, 40),
                Name = "pb_Platform_ChangePNC",
                Text = "Change PNC",
            };
            ChangePNC.Click += new EventHandler(Pb_ChangePNC_Click);
            _ButtonActionGroupBox.Controls.Add(ChangePNC);
        }
    }
}
