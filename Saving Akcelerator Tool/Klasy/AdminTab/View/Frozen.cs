using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Frozen;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    public partial class Frozen : UserControl
    {
        public Frozen()
        {
            InitializeComponent();
        }

        public void InitiaizeData()
        {
            num_Admin_FrozenYear.Value = DateTime.UtcNow.Year;
        }

        public void Clear()
        {
            Combo_AdminBU.SelectedIndex = 0;
            Combo_AdminEA1.SelectedIndex = 0;
            Combo_AdminEA2.SelectedIndex = 0;
            Combo_AdminEA3.SelectedIndex = 0;
            Combo_Admin1.SelectedIndex = 0;
            Combo_Admin2.SelectedIndex = 0;
            Combo_Admin3.SelectedIndex = 0;
            Combo_Admin4.SelectedIndex = 0;
            Combo_Admin5.SelectedIndex = 0;
            Combo_Admin6.SelectedIndex = 0;
            Combo_Admin7.SelectedIndex = 0;
            Combo_Admin8.SelectedIndex = 0;
            Combo_Admin9.SelectedIndex = 0;
            Combo_Admin10.SelectedIndex = 0;
            Combo_Admin11.SelectedIndex = 0;
            Combo_Admin12.SelectedIndex = 0;
            Combo_AdminEleApp.SelectedIndex = 0;
            Combo_AdminMechApp.SelectedIndex = 0;
            Combo_AdminNVRApp.SelectedIndex = 0;
        }

        public void SetValue(int[] Data)
        {
            Combo_AdminBU.SelectedIndex = Data[0];
            Combo_AdminEA1.SelectedIndex = Data[1];
            Combo_AdminEA2.SelectedIndex = Data[2];
            Combo_AdminEA3.SelectedIndex = Data[3];
            Combo_Admin1.SelectedIndex = Data[4];
            Combo_Admin2.SelectedIndex = Data[5];
            Combo_Admin3.SelectedIndex = Data[6];
            Combo_Admin4.SelectedIndex = Data[7];
            Combo_Admin5.SelectedIndex = Data[8];
            Combo_Admin6.SelectedIndex = Data[9];
            Combo_Admin7.SelectedIndex = Data[10];
            Combo_Admin8.SelectedIndex = Data[11];
            Combo_Admin9.SelectedIndex = Data[12];
            Combo_Admin10.SelectedIndex = Data[13];
            Combo_Admin11.SelectedIndex = Data[14];
            Combo_Admin12.SelectedIndex = Data[15];
            Combo_AdminEleApp.SelectedIndex = Data[16];
            Combo_AdminMechApp.SelectedIndex = Data[17];
            Combo_AdminNVRApp.SelectedIndex = Data[18];
        }

        public int[] GetValue()
        {
            int[] Data = new int[19];

            Data[0] = PrepareValue(Combo_AdminBU);
            Data[1] = PrepareValue(Combo_AdminEA1);
            Data[2] = PrepareValue(Combo_AdminEA2);
            Data[3] = PrepareValue(Combo_AdminEA3);
            Data[4] = PrepareValue(Combo_Admin1);
            Data[5] = PrepareValue(Combo_Admin2);
            Data[6] = PrepareValue(Combo_Admin3);
            Data[7] = PrepareValue(Combo_Admin4);
            Data[8] = PrepareValue(Combo_Admin5);
            Data[9] = PrepareValue(Combo_Admin6);
            Data[10] = PrepareValue(Combo_Admin7);
            Data[11] = PrepareValue(Combo_Admin8);
            Data[12] = PrepareValue(Combo_Admin9);
            Data[13] = PrepareValue(Combo_Admin10);
            Data[14] = PrepareValue(Combo_Admin11);
            Data[15] = PrepareValue(Combo_Admin12);
            Data[16] = PrepareValue(Combo_AdminEleApp);
            Data[17] = PrepareValue(Combo_AdminMechApp);
            Data[18] = PrepareValue(Combo_AdminNVRApp);

            return Data;
        }

        public int PrepareValue(ComboBox combo)
        {
            if (combo.SelectedIndex == -1)
                return 0;

            switch (combo.SelectedItem.ToString())
            {
                case "Close":
                    return 0;
                case "Open":
                    return 1;
                case "Approve":
                    return 2;
                default:
                    return 0;
            }
        }

        private void Pb_Admin_FrozenRefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new LoadFrozen(Convert.ToInt32(num_Admin_FrozenYear.Value));
            Cursor.Current = Cursors.Default;
        }

        private void Pb_Admin_FrozenSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new SaveFrozen(Convert.ToInt32(num_Admin_FrozenYear.Value), GetValue());
            Cursor.Current = Cursors.Default;
        }
    }
}
