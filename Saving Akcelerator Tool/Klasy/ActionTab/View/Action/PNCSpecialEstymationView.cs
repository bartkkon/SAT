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
using Saving_Accelerator_Tool.Klasy.Acton;

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
            TB_EstymacjaPNC.TextChanged -= TB_Estymacja_TextChange;
            if (Value != "")
            {
                TB_EstymacjaPNC.Text = Value;
            }
            TB_EstymacjaPNC.TextChanged += TB_Estymacja_TextChange;
        }

        public void SetPNCEstimationValue(double Value)
        {
            TB_EstymacjaPNC.TextChanged -= TB_Estymacja_TextChange;
            if (Value !=0)
            {
                TB_EstymacjaPNC.Text = Value.ToString();
            }
            else
            {
                TB_EstymacjaPNC.Text = string.Empty;
            }
            TB_EstymacjaPNC.TextChanged += TB_Estymacja_TextChange;
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
            TB_EstymacjaPNC.TextChanged += TB_Estymacja_TextChange;
            TB_EstymacjaPNC.Text = "";
            TB_EstymacjaPNC.TextChanged += TB_Estymacja_TextChange;
        }

        private void TB_Estymacja_TextChange(object sender, EventArgs e)
        {
            ActionID.Singleton.ActionModification = true;
        }

        private void TB_EstymacjaPNC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && e.KeyChar != '-' )
                e.Handled = true;
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
                e.Handled = true;
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') == -1) && (sender as TextBox).SelectionStart == 0)
                e.Handled = true;
            if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf('-') > -1)
                e.Handled = true;
            if (e.KeyChar == '-' && (sender as TextBox).Text.IndexOf('-') == -1 && (sender as TextBox).SelectionStart != 0)
                e.Handled = true;
        }

        private void TB_EstymacjaPNC_Leave(object sender, EventArgs e)
        {
            decimal Convert = 0;

            if(TB_EstymacjaPNC.Text.IndexOf(',') ==0)
                TB_EstymacjaPNC.Text = 0 + TB_EstymacjaPNC.Text;
       
            if (TB_EstymacjaPNC.Text.IndexOf('-') == 0 && TB_EstymacjaPNC.Text.IndexOf(',') == 1)
                TB_EstymacjaPNC.Text = TB_EstymacjaPNC.Text.Replace("-,", "-0,");

            if (TB_EstymacjaPNC.Text.Length != 0)
            {
                Convert = decimal.Parse(TB_EstymacjaPNC.Text);
                Convert = Math.Round(Convert, 4, MidpointRounding.AwayFromZero);
                TB_EstymacjaPNC.Text = Convert.ToString();
            }
            else
                TB_EstymacjaPNC.Text = Convert.ToString();

            if (Convert > 0)
                TB_EstymacjaPNC.ForeColor = Color.Green;
            else if (Convert < 0)
                TB_EstymacjaPNC.ForeColor = Color.Red;
            else
                TB_EstymacjaPNC.ForeColor = Color.Black;
        }
    }
}
