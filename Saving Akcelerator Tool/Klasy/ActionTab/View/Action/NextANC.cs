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
    public partial class NextANC : UserControl
    {
        private readonly List<TextBox> Next1;
        private readonly List<TextBox> Next2;

        public bool Save;

        public NextANC()
        {
            Next1 = new List<TextBox>();
            Next2 = new List<TextBox>();

            InitializeComponent();

            AddComponetsToList();
            Save = true;
        }

        public void SetVisisble(int Row, bool ifVisible)
        {
            Next1[Row].Visible = ifVisible;
            Next1[Row].Text = "";
            Next2[Row].Visible = ifVisible;
            Next2[Row].Text = "";
        }

        private void CheckIfCanSave()
        {
            bool CanSave = true;

            foreach(TextBox N1 in Next1)
            {
                if (N1.Text.Length != 9 && N1.Text.Length != 0)
                    CanSave = false;
            }
            foreach(TextBox N2 in Next2)
            {
                if (N2.Text.Length != 9 && N2.Text.Length != 0)
                    CanSave = false;
            }

            Save = CanSave;
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

        public void SetNext(int Count, string Next_1, string Next_2)
        {
            Next1[Count].Text = Next_1;
            Next2[Count].Text = Next_2;
        }

        public string[] GetNext1(int Ilosc)
        {
            string[] Next = new string[Ilosc];

            for(int counter =0; counter<Ilosc; counter++)
            {
                Next[counter] = Next1[counter].Text;
            }
            return Next;
        }

        public string[] GetNext2(int Ilosc)
        {
            string[] Next = new string[Ilosc];

            for (int counter = 0; counter < Ilosc; counter++)
            {
                Next[counter] = Next2[counter].Text;
            }
            return Next;
        }

        public string GetANCNext1(int Count)
        {
            return Next1[Count - 1].Text;
        }

        public string GetANCNext2(int Count)
        {
            return Next2[Count - 1].Text;
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

        private void Tb_NextANC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != 'A') && (e.KeyChar != 'a'))
                e.Handled = true;

            if ((e.KeyChar == 'A') && ((sender as TextBox).Text.IndexOf('A') > -1))
                e.Handled = true;

            if ((e.KeyChar == 'a') && ((sender as TextBox).Text.IndexOf('a') > -1))
                e.Handled = true;

            if ((e.KeyChar == 'A') && ((sender as TextBox).Text.IndexOf('A') == -1) && ((sender as TextBox).SelectionStart != 0))
                e.Handled = true;

            if ((e.KeyChar == 'a') && ((sender as TextBox).Text.IndexOf('a') == -1) && ((sender as TextBox).SelectionStart != 0))
                e.Handled = true;
        }

        private void Tb_NextANC_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).Text.Replace('a', 'A');

            if((sender as TextBox).Text.Length <9)
            {
                (sender as TextBox).ForeColor = Color.Red;
            }
            else if((sender as TextBox).Text.Length ==9)
            {
                (sender as TextBox).ForeColor = Color.Black;
            }

            CheckIfCanSave();
            ActionID.Singleton.ANCModification = true;
        }
    }
}
