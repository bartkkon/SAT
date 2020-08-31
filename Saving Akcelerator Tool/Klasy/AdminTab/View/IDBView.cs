using Saving_Accelerator_Tool.Klasy.AdmnTab.Handlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdmnTab.View
{
    class IDBView : IDBHandler
    {
        private readonly TabPage _adminTab;
        private GroupBox _IDBGroupBox;
        public IDBView(TabPage adminTab)
        {
            _adminTab = adminTab;

            GroupBoxCreate();
            UpdateDataBase();
        }

        private void GroupBoxCreate()
        {
            GroupBox gb_IDB = new GroupBox
            {
                Location = new Point(1135, 15),
                Size = new Size(150, 70),
                Name = "Gb_IDB",
                TabStop = false,
                Text = "IDB:"
            };
            _adminTab.Controls.Add(gb_IDB);
            _IDBGroupBox = gb_IDB;
        }

        private void UpdateDataBase()
        {
            Button pb_IDBUpdate = new Button
            {
                Location = new Point(15, 20),
                Size = new Size(120, 30),
                Name = "pb_IDBUpdateDataBase",
                Text = "Update IDB",
            };
            pb_IDBUpdate.Click += new EventHandler(PB_IDB_Update_DataBase_Click);
            _IDBGroupBox.Controls.Add(pb_IDBUpdate);
        }
    }
}
