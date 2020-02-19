using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class Gb_PNCEsty : UserControl
    {
        public Gb_PNCEsty()
        {
            InitializeComponent();
        }

        public void SetPNCEstymation(string Value)
        {
            if(Value != "")
            {
                TB_EstymacjaPNC.Text = Value;
            }
        }

        public decimal GetPNCEstymation()
        {
            if (TB_EstymacjaPNC.Text != "")
                return decimal.Parse(TB_EstymacjaPNC.Text);
            else
                return 0;
        }

        public void Clear()
        {
            TB_EstymacjaPNC.Text = "";
        }

        private void TB_EstymacjaPNC_TextChanged(object sender, EventArgs e)
        {
            string[] Estyma;
            int CursorPosition = TB_EstymacjaPNC.SelectionStart - 1;
            int LenghtText = TB_EstymacjaPNC.Text.Length;
            Regex GoodChar = new Regex("^[0-9,-]*$");
            Regex GoodChar2 = new Regex("^[0-9,]*$");
            string CharToCheck;

            TB_EstymacjaPNC.TextChanged -= TB_EstymacjaPNC_TextChanged;

            if (CursorPosition < 0)
            {
                CursorPosition = 0;
            }

            if (TB_EstymacjaPNC.Text.Length != 0)
            {
                Estyma = TB_EstymacjaPNC.Text.Split('.');
                if (Estyma.Length == 2)
                {
                    TB_EstymacjaPNC.Text = TB_EstymacjaPNC.Text.Replace('.', ',');
                    TB_EstymacjaPNC.Focus();
                    TB_EstymacjaPNC.SelectionStart = CursorPosition + 1;
                }

                Estyma = TB_EstymacjaPNC.Text.Split(',');
                if (Estyma.Length > 2)
                {
                    if (TB_EstymacjaPNC.SelectionStart == TB_EstymacjaPNC.Text.Length)
                    {
                        TB_EstymacjaPNC.Text = TB_EstymacjaPNC.Text.Substring(0, CursorPosition);
                    }
                    else
                    {
                        TB_EstymacjaPNC.Text = TB_EstymacjaPNC.Text.Substring(0, CursorPosition) + TB_EstymacjaPNC.Text.Substring(TB_EstymacjaPNC.SelectionStart, TB_EstymacjaPNC.Text.Length - TB_EstymacjaPNC.SelectionStart);
                    }

                    TB_EstymacjaPNC.Focus();
                    TB_EstymacjaPNC.SelectionStart = CursorPosition;
                }

                if (!GoodChar.IsMatch(TB_EstymacjaPNC.Text))
                {
                    TB_EstymacjaPNC.Text = Regex.Replace(TB_EstymacjaPNC.Text, @"[^0-9,-]+", "");
                    TB_EstymacjaPNC.Focus();
                    TB_EstymacjaPNC.SelectionStart = CursorPosition;
                }

                CharToCheck = TB_EstymacjaPNC.Text.Substring(1, TB_EstymacjaPNC.Text.Length - 1);
                if (!GoodChar2.IsMatch(CharToCheck))
                {
                    CharToCheck = Regex.Replace(CharToCheck, @"[^0-9,]+", "");
                    TB_EstymacjaPNC.Text = TB_EstymacjaPNC.Text.Substring(0, 1) + CharToCheck;
                    TB_EstymacjaPNC.Focus();
                    TB_EstymacjaPNC.SelectionStart = CursorPosition;
                }
            }

            TB_EstymacjaPNC.TextChanged += TB_EstymacjaPNC_TextChanged;
        }

        private void TB_EstymacjaPNC_Leave(object sender, EventArgs e)
        {
            decimal Convert = 0;

            if (TB_EstymacjaPNC.Text.Length != 0)
            {
                Convert = decimal.Parse(TB_EstymacjaPNC.Text);
                Convert = Math.Round(Convert, 4, MidpointRounding.AwayFromZero);
                TB_EstymacjaPNC.Text = Convert.ToString();
            }
            else
            {
                TB_EstymacjaPNC.Text = Convert.ToString();
            }

            if (Convert > 0)
            {
                TB_EstymacjaPNC.ForeColor = Color.Green;
            }
            else if (Convert < 0)
            {
                TB_EstymacjaPNC.ForeColor = Color.Red;
            }
            else
            {
                TB_EstymacjaPNC.ForeColor = Color.Black;
            }
        }
    }
}
