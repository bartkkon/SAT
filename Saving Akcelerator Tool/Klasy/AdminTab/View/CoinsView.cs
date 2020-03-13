using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.AdminTab.Framework.Coins;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    public partial class CoinsView : UserControl
    {
        public CoinsView()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            num_Admin_ValueYear.Value = DateTime.UtcNow.Year;
        }

        public void Clear()
        {
            tb_AdminDolars.Text = string.Empty;
            tb_AdminECCC.Text = string.Empty;
            tb_AdminEuro.Text = string.Empty;
            tb_AdminSek.Text = string.Empty;
        }

        public void GetEuro(double Euro)
        {
            tb_AdminEuro.Text = Euro.ToString();
        }
        public double SetEuro ()
        {
            if (tb_AdminEuro.Text != "")
                return Convert.ToDouble(tb_AdminEuro.Text);
            else
                return 0;
        }

        public void GetUSD(double USD)
        {
            tb_AdminDolars.Text = USD.ToString();
        }
        public double SetUSD()
        {
            if (tb_AdminDolars.Text != "")
                return Convert.ToDouble(tb_AdminDolars.Text);
            else
                return 0;
        }
        public void GetSEK(double SEK)
        {
            tb_AdminSek.Text = SEK.ToString();
        }
        public double SetSEK()
        {
            if (tb_AdminSek.Text != "")
                return Convert.ToDouble(tb_AdminSek.Text);
            else
                return 0;
        }

        public void GetECCC(double ECCC)
        {
            tb_AdminECCC.Text = ECCC.ToString();
        }
        public double SetECCC()
        {
            if (tb_AdminECCC.Text != "")
                return Convert.ToDouble(tb_AdminECCC.Text);
            else
                return 0;
        }

        private void Pb_Admin_ValueRefresh_Click(object sender, EventArgs e)
        {
            //DataTable Kurs = new DataTable();
            //DataRow Year;

            Cursor.Current = Cursors.WaitCursor;
            _ = new RefreshCoins(Convert.ToInt32(num_Admin_ValueYear.Value));

            //Data_Import.Singleton().Load_TxtToDataTable2(ref Kurs, "Kurs");

            //Year = Kurs.Select(string.Format("Year LIKE '%{0}%'", num_Admin_ValueYear.Value.ToString())).FirstOrDefault();

            //if (Year == null)
            //{
            //    tb_AdminECCC.Text = string.Empty;
            //    tb_AdminEuro.Text = string.Empty;
            //    tb_AdminDolars.Text = string.Empty;
            //    tb_AdminSek.Text = string.Empty;
            //}
            //else
            //{
            //    tb_AdminECCC.Text = Year["ECCC"].ToString();
            //    tb_AdminEuro.Text = Year["EURO"].ToString();
            //    tb_AdminDolars.Text = Year["USD"].ToString();
            //    tb_AdminSek.Text = Year["SEK"].ToString();
            //}

            Cursor.Current = Cursors.Default;
        }

        private void Pb_Admin_ValueSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            double _ECCC = 0;
            double _EURO = 0;
            double _USD = 0;
            double _SEK = 0;

            if(tb_AdminECCC.Text != string.Empty)
                _ECCC = Convert.ToDouble(tb_AdminECCC.Text);

            if (tb_AdminEuro.Text != string.Empty)
                _EURO = Convert.ToDouble(tb_AdminEuro.Text);

            if (tb_AdminDolars.Text != string.Empty)
                _USD = Convert.ToDouble(tb_AdminDolars.Text);

            if (tb_AdminSek.Text != string.Empty)
                _SEK = Convert.ToDouble(tb_AdminSek.Text);

            _ = new SaveCoins(Convert.ToInt32(num_Admin_ValueYear.Value), _ECCC, _EURO, _USD, _SEK);

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
