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
    public partial class NextANC : UserControl
    {
        private readonly List<TextBox> Next1;
        private readonly List<TextBox> Next2;

        public NextANC()
        {
            Next1 = new List<TextBox>();
            Next2 = new List<TextBox>();

            InitializeComponent();

            AddComponetsToList();
        }

        public void SetVisisble(int Row, bool ifVisible)
        {
            Next1[Row].Visible = ifVisible;
            Next1[Row].Text = "";
            Next2[Row].Visible = ifVisible;
            Next2[Row].Text = "";
        }

        public void SetData(string[] NextANC1, string[] NextANC2)
        {
            if (NextANC1 != null)
            {
                for (int counter = 0; counter < NextANC1.Length; counter++)
                {
                    Next1[counter].Text = NextANC1[counter];
                }
            }
            if (NextANC2 != null)
            {
                for (int counter = 0; counter < NextANC2.Length; counter++)
                {
                    Next2[counter].Text = NextANC2[counter];
                }
            }
        }

        public void Clear()
        {
            for (int counter = 0; counter < 10; counter++)
            {
                Next1[counter].Text = "";
                Next2[counter].Text = "";
                Next1[counter].Visible = false;
                Next2[counter].Visible = false;
            }
        }

        private void AddComponetsToList()
        {
            Next1.Add(tb_NextANC1);
            Next1.Add(tb_NextANC2);
            Next1.Add(tb_NextANC3);
            Next1.Add(tb_NextANC4);
            Next1.Add(tb_NextANC5);
            Next1.Add(tb_NextANC6);
            Next1.Add(tb_NextANC7);
            Next1.Add(tb_NextANC8);
            Next1.Add(tb_NextANC9);
            Next1.Add(tb_NextANC10);
            Next2.Add(tb_Next2ANC1);
            Next2.Add(tb_Next2ANC2);
            Next2.Add(tb_Next2ANC3);
            Next2.Add(tb_Next2ANC4);
            Next2.Add(tb_Next2ANC5);
            Next2.Add(tb_Next2ANC6);
            Next2.Add(tb_Next2ANC7);
            Next2.Add(tb_Next2ANC8);
            Next2.Add(tb_Next2ANC9);
            Next2.Add(tb_Next2ANC10);
        }

        private void Tb_NextANC_TextChanged(object sender, EventArgs e)
        {
            TextBox TextToCheck = sender as TextBox;
            Regex GoodChar = new Regex("^[aA0-9]*$");
            Regex OnlyNumber = new Regex("^[0-9]*$");
            Regex SmallChar = new Regex("^[a]");
            int CursorPosition = TextToCheck.SelectionStart - 1;
            if (CursorPosition < 0)
            {
                CursorPosition = 0;
            }

            if (TextToCheck.Text.Length > 1)
            {
                string Check = TextToCheck.Text.Remove(0, 1);
                if (!OnlyNumber.IsMatch(Check))
                {
                    Check = Regex.Replace(Check, @"[^0-9]+", "");

                    TextToCheck.Text = TextToCheck.Text.Remove(1, TextToCheck.Text.Length - 1) + Check;
                    TextToCheck.Focus();
                    TextToCheck.SelectionStart = CursorPosition;
                }

                Check = TextToCheck.Text.Remove(1, TextToCheck.Text.Length - 1);
                if (!GoodChar.IsMatch(Check))
                {
                    TextToCheck.Text = TextToCheck.Text.Remove(0, 1);
                    TextToCheck.Focus();
                    TextToCheck.SelectionStart = 0;
                }
                else if (Check == "a")
                {
                    TextToCheck.Text = "A" + TextToCheck.Text.Remove(0, 1);
                    TextToCheck.Focus();
                    TextToCheck.SelectionStart = CursorPosition + 1;
                }

            }
            else if (TextToCheck.Text.Length == 1)
            {
                if (!GoodChar.IsMatch(TextToCheck.Text))
                {
                    TextToCheck.Text = TextToCheck.Text.Substring(0, TextToCheck.Text.Length - 1);
                    TextToCheck.Focus();
                    TextToCheck.SelectionStart = TextToCheck.Text.Length;
                }
                if (SmallChar.IsMatch(TextToCheck.Text))
                {
                    TextToCheck.Text = "A";
                    TextToCheck.Focus();
                    TextToCheck.SelectionStart = TextToCheck.Text.Length;
                }
            }
            if (TextToCheck.Text.Length < 9)
            {
                TextToCheck.ForeColor = Color.Red;
            }
            else if (TextToCheck.Text.Length == 9)
            {
                TextToCheck.ForeColor = Color.Black;
            }
        }
    }
}
