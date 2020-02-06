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
    public partial class CoinsView : UserControl
    {
        public CoinsView()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            num_Admin_ValueYear.Value = DateTime.UtcNow.Year;
        }

        private void Pb_Admin_ValueRefresh_Click(object sender, EventArgs e)
        {
            DataTable Kurs = new DataTable();
            DataRow Year;

            Cursor.Current = Cursors.WaitCursor;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Kurs, "Kurs");

            Year = Kurs.Select(string.Format("Year LIKE '%{0}%'", num_Admin_ValueYear.Value.ToString())).FirstOrDefault();

            if (Year == null)
            {
                tb_AdminECCC.Text = string.Empty;
                tb_AdminEuro.Text = string.Empty;
                tb_AdminDolars.Text = string.Empty;
                tb_AdminSek.Text = string.Empty;
            }
            else
            {
                tb_AdminECCC.Text = Year["ECCC"].ToString();
                tb_AdminEuro.Text = Year["EURO"].ToString();
                tb_AdminDolars.Text = Year["USD"].ToString();
                tb_AdminSek.Text = Year["SEK"].ToString();
            }

            Cursor.Current = Cursors.Default;
        }

        private void Pb_Admin_ValueSave_Click(object sender, EventArgs e)
        {
            DataTable Kurs = new DataTable();
            DataRow Year;
            Cursor.Current = Cursors.WaitCursor;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Kurs, "Kurs");

            Year = Kurs.Select(string.Format("Year LIKE '%{0}%'", num_Admin_ValueYear.Value.ToString())).FirstOrDefault();

            if (Year == null)
            {
                Year = Kurs.NewRow();
                Year["Year"] = num_Admin_ValueYear.Value.ToString();
                Year["DM"] = "/////";
                Year["PC"] = "/////";
                Year["Ele"] = "/////";
                Year["Mech"] = "/////";
                Year["NVR"] = "/////";
                Kurs.Rows.Add(Year);
            }

            Year["ECCC"] = tb_AdminECCC.Text;
            Year["EURO"] = tb_AdminEuro.Text;
            Year["USD"] = tb_AdminDolars.Text;
            Year["SEK"] = tb_AdminSek.Text;

            Data_Import.Singleton().Save_DataTableToTXT2(ref Kurs, "Kurs");

            Cursor.Current = Cursors.Default;
        }

        private void Tb_Value_TextChange(object sender, EventArgs e)
        {
            string[] Estyma;
            TextBox TextBoxChange = sender as TextBox;

            //Sprawdenie czy dana jest kropka czy przeciek. Jak kropka to ma zmienić na przecinek - dla wpisywania Estymacji
            Estyma = TextBoxChange.Text.Split('.');
            if (Estyma.Length == 2)
            {
                TextBoxChange.Text = TextBoxChange.Text.Replace('.', ',');
                TextBoxChange.Focus();
                TextBoxChange.SelectionStart = TextBoxChange.Text.Length;
            }
            //Sprawdza czy za dużo razy nie ma przecinka wstawionego w text. Jak tak to usuwa ostatni znak który jest przecinkiem - Dla Estymacji
            Estyma = TextBoxChange.Text.Split(',');
            if (Estyma.Length == 3)
            {
                TextBoxChange.Text = TextBoxChange.Text.Substring(0, TextBoxChange.Text.Length - 1);
                TextBoxChange.Focus();
                TextBoxChange.SelectionStart = TextBoxChange.Text.Length;
            }
        }
    }
}
