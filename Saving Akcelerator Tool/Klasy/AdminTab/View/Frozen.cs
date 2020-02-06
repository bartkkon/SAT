using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    public partial class Frozen : UserControl
    {
        public Frozen()
        {
            InitializeComponent();
            InitiaizeData();
        }

        private void InitiaizeData()
        {
            num_Admin_FrozenYear.Value = DateTime.UtcNow.Year;
        }

        private void Pb_Admin_FrozenRefresh_Click(object sender, EventArgs e)
        {
            DataTable Frozen = new DataTable();
            DataRow Year;

            Cursor.Current = Cursors.WaitCursor;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");

            Year = Frozen.Select(string.Format("Year LIKE '%{0}%'", num_Admin_FrozenYear.Value.ToString())).FirstOrDefault();

            if (Year == null)
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
            else
            {
                Combo_AdminBU.SelectedIndex = CheckClose(Combo_AdminBU.Name.Replace("Combo_Admin", ""), Year);
                Combo_AdminEA1.SelectedIndex = CheckClose(Combo_AdminEA1.Name.Replace("Combo_Admin", ""), Year);
                Combo_AdminEA2.SelectedIndex = CheckClose(Combo_AdminEA2.Name.Replace("Combo_Admin", ""), Year);
                Combo_AdminEA3.SelectedIndex = CheckClose(Combo_AdminEA3.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin1.SelectedIndex = CheckClose(Combo_Admin1.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin2.SelectedIndex = CheckClose(Combo_Admin2.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin3.SelectedIndex = CheckClose(Combo_Admin3.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin4.SelectedIndex = CheckClose(Combo_Admin4.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin5.SelectedIndex = CheckClose(Combo_Admin5.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin6.SelectedIndex = CheckClose(Combo_Admin6.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin7.SelectedIndex = CheckClose(Combo_Admin7.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin8.SelectedIndex = CheckClose(Combo_Admin8.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin9.SelectedIndex = CheckClose(Combo_Admin9.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin10.SelectedIndex = CheckClose(Combo_Admin10.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin11.SelectedIndex = CheckClose(Combo_Admin11.Name.Replace("Combo_Admin", ""), Year);
                Combo_Admin12.SelectedIndex = CheckClose(Combo_Admin12.Name.Replace("Combo_Admin", ""), Year);
                Combo_AdminEleApp.SelectedIndex = CheckClose(Combo_AdminEleApp.Name.Replace("Combo_Admin", ""), Year);
                Combo_AdminMechApp.SelectedIndex = CheckClose(Combo_AdminMechApp.Name.Replace("Combo_Admin", ""), Year);
                Combo_AdminNVRApp.SelectedIndex = CheckClose(Combo_AdminNVRApp.Name.Replace("Combo_Admin", ""), Year);
            }


            Cursor.Current = Cursors.Default;
        }

        private int CheckClose(string What, DataRow Year)
        {
            switch (Year[What].ToString())
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

        private void Pb_Admin_FrozenSave_Click(object sender, EventArgs e)
        {
            DataTable Frozen = new DataTable();
            DataRow FoundRow;

            Cursor.Current = Cursors.WaitCursor;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");

            FoundRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", num_Admin_FrozenYear.Value.ToString())).FirstOrDefault();
            if(FoundRow == null)
            {
                FoundRow = Frozen.NewRow();
                FoundRow["Year"] = num_Admin_FrozenYear.Value.ToString();
                Frozen.Rows.Add(FoundRow);
            }

            FoundRow["BU"] = Combo_AdminBU.GetItemText(Combo_AdminBU.SelectedItem);
            FoundRow["EA1"] = Combo_AdminEA1.GetItemText(Combo_AdminEA1.SelectedItem);
            FoundRow["EA2"] = Combo_AdminEA2.GetItemText(Combo_AdminEA2.SelectedItem);
            FoundRow["EA3"] = Combo_AdminBU.GetItemText(Combo_AdminEA3.SelectedItem);
            FoundRow["1"] = Combo_Admin1.GetItemText(Combo_Admin1.SelectedItem);
            FoundRow["2"] = Combo_Admin2.GetItemText(Combo_Admin2.SelectedItem);
            FoundRow["3"] = Combo_Admin3.GetItemText(Combo_Admin3.SelectedItem);
            FoundRow["4"] = Combo_Admin4.GetItemText(Combo_Admin4.SelectedItem);
            FoundRow["5"] = Combo_Admin5.GetItemText(Combo_Admin5.SelectedItem);
            FoundRow["6"] = Combo_Admin6.GetItemText(Combo_Admin6.SelectedItem);
            FoundRow["7"] = Combo_Admin7.GetItemText(Combo_Admin7.SelectedItem);
            FoundRow["8"] = Combo_Admin8.GetItemText(Combo_Admin8.SelectedItem);
            FoundRow["9"] = Combo_Admin9.GetItemText(Combo_Admin9.SelectedItem);
            FoundRow["10"] = Combo_Admin10.GetItemText(Combo_Admin10.SelectedItem);
            FoundRow["11"] = Combo_Admin11.GetItemText(Combo_Admin11.SelectedItem);
            FoundRow["12"] = Combo_Admin12.GetItemText(Combo_Admin12.SelectedItem);
            FoundRow["EleApp"] = Combo_AdminEleApp.GetItemText(Combo_AdminEleApp.SelectedItem);
            FoundRow["MechApp"] = Combo_AdminMechApp.GetItemText(Combo_AdminMechApp.SelectedItem);
            FoundRow["NVRApp"] = Combo_AdminNVRApp.GetItemText(Combo_AdminNVRApp.SelectedItem);

            Data_Import.Singleton().Save_DataTableToTXT2(ref Frozen, "Frozen");

            Cursor.Current = Cursors.Default;
        }
    }
}
