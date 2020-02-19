using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class NameView : UserControl
    {
        public static UserControl control;
        public NameView()
        {
            InitializeComponent();
            control = this;
        }
        public void ActionNameChange (string Name)
        {
            Tb_Name.Text = Name;
        }

        public void Description(string Des)
        {
            Tb_Description.Text = Des;
        }

        public void Clear()
        {
            Tb_Description.Text = "";
            Tb_Name.Text = "";
        }

        private void Tb_Name_TextChanged(object sender, EventArgs e)
        {
            int Index = Tb_Name.SelectionStart;
            int Start;
            int End;
            if (Tb_Name.Text != "")
            {
                Start = Tb_Name.Text.Length;

                Tb_Name.Text = Tb_Name.Text.Replace(";", "");
                Tb_Name.Text = Tb_Name.Text.Replace("|", "");
                Tb_Name.Text = Tb_Name.Text.Replace("@", "");
                Tb_Name.Text = Tb_Name.Text.Replace(":", "");

                End = Tb_Name.Text.Length;
                if (Index != 0)
                {
                    if (Start == End)
                    {
                        return;
                    }
                    if (Start > End)
                    {
                        Tb_Name.SelectionStart = Index - 1;
                    }
                }
            }
        }

        private void Tb_Name_Leave(object sender, EventArgs e)
        {
            Tb_Name.Text = Tb_Name.Text.Trim();
        }

        private void Tb_Description_TextChanged(object sender, EventArgs e)
        {
            Lab_MaxLength.Text = Tb_Description.Text.Length.ToString() + "/1000";
        }
    }
}
