using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.Acton;
using System.Text.RegularExpressions;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class ANCChangeView : UserControl
    {
        private readonly List<TextBox> OldANCList;
        private readonly List<TextBox> OldANCQList;
        private readonly List<TextBox> NewANCList;
        private readonly List<TextBox> NewANCQList;
        private readonly List<Label> Arrows;

        public ANCChangeView()
        {
            OldANCList = new List<TextBox>();
            OldANCQList = new List<TextBox>();
            NewANCList = new List<TextBox>();
            NewANCQList = new List<TextBox>();
            Arrows = new List<Label>();


            InitializeComponent();

            AddComponentToList();
        }

        private void AddComponentToList()
        {
            OldANCList.Add(TB_OldANC1);
            OldANCList.Add(TB_OldANC2);
            OldANCList.Add(TB_OldANC3);
            OldANCList.Add(TB_OldANC4);
            OldANCList.Add(TB_OldANC5);
            OldANCList.Add(TB_OldANC6);
            OldANCList.Add(TB_OldANC7);
            OldANCList.Add(TB_OldANC8);
            OldANCList.Add(TB_OldANC9);
            OldANCList.Add(TB_OldANC10);
            OldANCQList.Add(TB_OldANCQ1);
            OldANCQList.Add(TB_OldANCQ2);
            OldANCQList.Add(TB_OldANCQ3);
            OldANCQList.Add(TB_OldANCQ4);
            OldANCQList.Add(TB_OldANCQ5);
            OldANCQList.Add(TB_OldANCQ6);
            OldANCQList.Add(TB_OldANCQ7);
            OldANCQList.Add(TB_OldANCQ8);
            OldANCQList.Add(TB_OldANCQ9);
            OldANCQList.Add(TB_OldANCQ10);
            NewANCList.Add(TB_NewANC1);
            NewANCList.Add(TB_NewANC2);
            NewANCList.Add(TB_NewANC3);
            NewANCList.Add(TB_NewANC4);
            NewANCList.Add(TB_NewANC5);
            NewANCList.Add(TB_NewANC6);
            NewANCList.Add(TB_NewANC7);
            NewANCList.Add(TB_NewANC8);
            NewANCList.Add(TB_NewANC9);
            NewANCList.Add(TB_NewANC10);
            NewANCQList.Add(TB_NewANCQ1);
            NewANCQList.Add(TB_NewANCQ2);
            NewANCQList.Add(TB_NewANCQ3);
            NewANCQList.Add(TB_NewANCQ4);
            NewANCQList.Add(TB_NewANCQ5);
            NewANCQList.Add(TB_NewANCQ6);
            NewANCQList.Add(TB_NewANCQ7);
            NewANCQList.Add(TB_NewANCQ8);
            NewANCQList.Add(TB_NewANCQ9);
            NewANCQList.Add(TB_NewANCQ10);
            Arrows.Add(Arrow1);
            Arrows.Add(Arrow2);
            Arrows.Add(Arrow3);
            Arrows.Add(Arrow4);
            Arrows.Add(Arrow5);
            Arrows.Add(Arrow6);
            Arrows.Add(Arrow7);
            Arrows.Add(Arrow8);
            Arrows.Add(Arrow9);
            Arrows.Add(Arrow10);
        }

        public void SetVisibleANC(int VisibleRows)
        {
            for (int counter = 0; counter < VisibleRows; counter++)
            {
                OldANCList[counter].Visible = true;
                OldANCQList[counter].Visible = true;
                OldANCQList[counter].Text = "0";
                NewANCList[counter].Visible = true;
                NewANCQList[counter].Visible = true;
                NewANCQList[counter].Text = "0";
                Arrows[counter].Visible = true;
                MainProgram.Self.actionView.StkChange.SetVisibleANC(counter, true);
                MainProgram.Self.actionView.NextANC.SetVisisble(counter, true);
                MainProgram.Self.actionView.CalculationGroup.SetVisible(counter, true);
            }
        }

        public void SetANC(string[] ANCList, int Rows, bool TrueifNew)
        {
            for (int counter = 0; counter < Rows; counter++)
            {
                if (TrueifNew)
                    NewANCList[counter].Text = ANCList[counter];
                else
                    OldANCList[counter].Text = ANCList[counter];
            }
        }

        public void SetANCQ(decimal[] QuantityList, int Rows, bool TrueIfNew)
        {
            for (int counter = 0; counter < Rows; counter++)
            {
                if (TrueIfNew)
                    NewANCQList[counter].Text = QuantityList[counter].ToString();
                else
                    OldANCQList[counter].Text = QuantityList[counter].ToString();
            }
        }

        public string[] GetANC(int Rows, bool New)
        {
            string[] ANCList = new string[Rows];

            for(int counter = 0; counter<Rows; counter++)
            {
                if (New)
                    ANCList[counter] = NewANCList[counter].Text;
                else
                    ANCList[counter] = OldANCList[counter].Text;
            }

            return ANCList;
        }

        public decimal[] GetQuantity(int Rows, bool New)
        {
            decimal[] QuantityList = new decimal[Rows];

            for (int counter = 0; counter < Rows; counter++)
            {
                if (New)
                    QuantityList[counter] = decimal.Parse(NewANCQList[counter].Text);
                else
                    QuantityList[counter] = decimal.Parse(OldANCQList[counter].Text);
            }

            return QuantityList;
        }

        public void Clear()
        {
            foreach (TextBox Box in OldANCList)
            {
                Box.Visible = false;
                Box.Text = "";
            }
            foreach (TextBox Box in OldANCQList)
            {
                Box.Visible = false;
                Box.Text = "";
            }
            foreach (TextBox Box in NewANCList)
            {
                Box.Visible = false;
                Box.Text = "";
            }
            foreach (TextBox Box in NewANCQList)
            {
                Box.Visible = false;
                Box.Text = "";
            }
            foreach (Label lab in Arrows)
            {
                lab.Visible = false;
            }
            MainProgram.Self.actionView.StkChange.Clear();
            MainProgram.Self.actionView.NextANC.Clear();
            MainProgram.Self.actionView.CalculationGroup.Clear();
        }

        private void Pb_Plus_Click(object sender, EventArgs e)
        {
            CopyAction.Value.IloscANC++;
            if (CopyAction.Value.IloscANC <= 10)
            {
                AddRow(CopyAction.Value.IloscANC);
            }
            else
            {
                CopyAction.Value.IloscANC--;
            }
        }

        private void Pb_Minus_Click(object sender, EventArgs e)
        {
            if (CopyAction.Value.IloscANC > 1)
            {
                RemoveRow(CopyAction.Value.IloscANC);
                CopyAction.Value.IloscANC--;
            }
            else
            {
                RemoveRow(1);
                AddRow(1);
            }
        }

        private void AddRow(int iloscANC)
        {
            OldANCList[iloscANC - 1].Visible = true;
            OldANCQList[iloscANC - 1].Visible = true;
            OldANCQList[iloscANC - 1].Text = "0";
            NewANCList[iloscANC - 1].Visible = true;
            NewANCQList[iloscANC - 1].Visible = true;
            NewANCQList[iloscANC - 1].Text = "0";
            Arrows[iloscANC - 1].Visible = true;
            MainProgram.Self.actionView.StkChange.SetVisibleANC(iloscANC-1, true);
            MainProgram.Self.actionView.NextANC.SetVisisble(iloscANC-1, true);
            MainProgram.Self.actionView.CalculationGroup.SetVisible(iloscANC - 1, true);
        }

        private void RemoveRow(int iloscANC)
        {
            OldANCList[iloscANC - 1].Visible = false;
            OldANCList[iloscANC - 1].Text = "";
            OldANCQList[iloscANC - 1].Visible = false;
            OldANCQList[iloscANC - 1].Text = "";
            NewANCList[iloscANC - 1].Visible = false;
            NewANCList[iloscANC - 1].Text = "";
            NewANCQList[iloscANC - 1].Visible = false;
            NewANCQList[iloscANC - 1].Text = "";
            Arrows[iloscANC - 1].Visible = false;
            MainProgram.Self.actionView.StkChange.SetVisibleANC(iloscANC-1, false);
            MainProgram.Self.actionView.NextANC.SetVisisble(iloscANC-1, false);
            MainProgram.Self.actionView.CalculationGroup.SetVisible(iloscANC - 1, false);
        }

        private void Tb_CheckifOK_TextChange(object sender, EventArgs e)
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
                int ElementNumber = Int32.Parse(TextToCheck.Name.Remove(0, 9));
                if (OldANCList.Contains(TextToCheck))
                {
                    if (OldANCQList[ElementNumber - 1].Text == "0")
                        OldANCQList[ElementNumber - 1].Text = "1";
                }
                else if (NewANCList.Contains(TextToCheck))
                {
                    if (NewANCQList[ElementNumber - 1].Text == "0")
                        NewANCQList[ElementNumber - 1].Text = "1";
                }
            }
        }

        private void Tb_CheckIfQuantity_TextChange(object sender, EventArgs e)
        {
            TextBox Quantity = sender as TextBox;
            Regex Good = new Regex("^[0-9,]*$");
            string[] Check;
            int CursorPosition = Quantity.SelectionStart - 1;

            if (!Good.IsMatch(Quantity.Text))
            {
                Quantity.Text = Quantity.Text.Substring(0, Quantity.Text.Length - 1);
                Quantity.Focus();
                Quantity.SelectionStart = Quantity.Text.Length;
            }

            Check = Quantity.Text.Split(',');
            if (Check.Length == 3)
            {
                Quantity.Text = Quantity.Text.Remove(Quantity.SelectionStart - 1, 1);
                Quantity.Focus();
                Quantity.SelectionStart = CursorPosition;
            }
        }

        private void Tb_Quantity_Leave(object sender, EventArgs e)
        {
            TextBox Quantity;
            TextBox ANCTB;

            Quantity = sender as TextBox;

            int ElementNumber = Int32.Parse((sender as TextBox).Name.Remove(0, 10));

            if ((sender as TextBox).Name.Substring(0, 10) == "TB_OldANCQ")
            {
                ANCTB = OldANCList[ElementNumber - 1];
            }
            else
            {
                ANCTB = NewANCList[ElementNumber - 1];
            }


            if (Quantity.Text.Length == 0)
            {
                if (ANCTB.Text == "")
                {
                    Quantity.Text = "0";
                }
                else
                {
                    Quantity.Text = "1";
                }
            }
            else
            {
                if (ANCTB.Text == "")
                {
                    Quantity.Text = "0";
                }
                else if (Quantity.Text == "0")
                {
                    Quantity.Text = "1";
                }
            }
        }
    }
}
