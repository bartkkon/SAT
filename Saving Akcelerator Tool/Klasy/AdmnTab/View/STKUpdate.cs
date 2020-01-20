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
    public class STKUpdate : STKUpdateHandlers
    {
        private readonly TabPage _AdminTab;
        private GroupBox _StkUpdateGroupBox;

        public STKUpdate(TabPage AdminTab)
        {
            _AdminTab = AdminTab;

            GroupBoxCreate();
            UpdateSTKDataBase();
            ClearYear();
            ManualUpdate();
        }

        private void ManualUpdate()
        {
            Button pb_Admin_ManualUpdate = new Button
            {
                Location = new Point(45, 95),
                Name = "pb_Admin_ManualUpdate",
                Size = new Size(130, 25),
                Text = "Manual Update",
                UseVisualStyleBackColor = true,
            };
            pb_Admin_ManualUpdate.Click += new EventHandler(Pb_Admin_ManualUpdate_Click);
            _StkUpdateGroupBox.Controls.Add(pb_Admin_ManualUpdate);
        }

        private void ClearYear()
        {
            NumericUpDown pb_Admin_STKYearToClear = new NumericUpDown
            {
                Location = new Point(10, 64),
                Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0}),
                Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0}),
                Name = "pb_Admin_STKYearToClear",
                Size = new Size(78, 20),
                Value = DateTime.Now.Year + 1,
            };
            _StkUpdateGroupBox.Controls.Add(pb_Admin_STKYearToClear);

            Button pb_Admin_YearClear = new Button
            {
                Location = new Point(95, 60),
                Name = "pb_Admin_YearClear",
                Size = new Size(80, 25),
                Text = "Clear Year",
                UseVisualStyleBackColor = true,
            };
            pb_Admin_YearClear.Click += new EventHandler(Pb_Admin_YearClear_Click);
            _StkUpdateGroupBox.Controls.Add(pb_Admin_YearClear);
        }

        private void UpdateSTKDataBase()
        {
            Button pb_Admin_UpdateSTK = new Button
            {
                Location = new Point(60, 25),
                Name = "pb_Admin_UpdateSTK",
                Size = new Size(80, 25),
                Text = "Update STK DataBase",
                UseVisualStyleBackColor = true,
            };
            pb_Admin_UpdateSTK.Click += new EventHandler(Pb_Admin_UpdateSTK_Click);
            _StkUpdateGroupBox.Controls.Add(pb_Admin_UpdateSTK);
        }

        private void GroupBoxCreate()
        {
            GroupBox gb_AdminUpdateSTK = new GroupBox
            {
                Location = new Point(425, 515),
                Name = "gb_AdminUpdateSTK",
                Size = new Size(200, 160),
                TabStop = false,
                Text = "Update STK",
            };
            _AdminTab.Controls.Add(gb_AdminUpdateSTK);
            _StkUpdateGroupBox = gb_AdminUpdateSTK;
        }
    }
}
