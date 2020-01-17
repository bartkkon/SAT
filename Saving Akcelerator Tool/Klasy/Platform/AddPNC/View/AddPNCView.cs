using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform.AddPNC.View
{
    class AddPNCView
    {
        private readonly Platform_AddPNC _forma;
        private readonly string _project;
        public AddPNCView(Platform_AddPNC Forma, string Project)
        {
            _forma = Forma;
            _project = Project;

            PNC();
        }

        private void PNC()
        {
            Label PNC = new Label
            {
                Location = new Point(10, 30),
                AutoSize = true,
                Size = new Size(10, 10),
                Text = "PNC:",
            };
            _forma.Controls.Add(PNC);

            TextBox NewPNC = new TextBox
            {
                Location = new Point(80, 25),
                Size = new Size(70, 20),
                Name = "TB_AddPNC_NewPNC",
            };
            _forma.Controls.Add(NewPNC);

            Label PNClab = new Label
            {
                Location = new Point(10, 70),
                AutoSize = true,
                Size = new Size(10, 10),
                Text = "Predecessor:",
            };
            _forma.Controls.Add(PNClab);

            TextBox OldPNC = new TextBox
            {
                Location = new Point(80, 65),
                Size = new Size(70, 20),
                Name = "TB_AddPNC_OldPNC",
            };
            _forma.Controls.Add(OldPNC);
        }
    }
}
