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
        public void ActionNameChange(string Name)
        {
            Tb_Name.TextChanged -= Tb_Name_TextChanged;
            Tb_Name.Text = Name;
            Tb_Name.TextChanged += Tb_Name_TextChanged;
        }

        public string GetActionName()
        {
            return Tb_Name.Text;
        }

        public string GetDescription()
        {
            return Tb_Description.Text.Replace(Environment.NewLine, "/n");
        }

        public void Description(string Des)
        {
            Tb_Description.TextChanged -= Tb_Description_TextChanged;
            Tb_Description.Text = Des.Replace("/n", Environment.NewLine);
            Lab_MaxLength.Text = Tb_Description.Text.Length.ToString() + "/1000";
            Tb_Description.TextChanged += Tb_Description_TextChanged;
        }

        public void Clear()
        {
            Tb_Name.TextChanged -= Tb_Name_TextChanged;
            Tb_Description.TextChanged -= Tb_Description_TextChanged;
            Tb_Description.Text = string.Empty;
            Tb_Name.Text = string.Empty;
            Lab_MaxLength.Text = Tb_Description.Text.Length.ToString() + "/1000";
            Tb_Description.TextChanged += Tb_Description_TextChanged;
            Tb_Name.TextChanged += Tb_Name_TextChanged;
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
            ActionID.Singleton.ActionModification = true;
        }

        private void Tb_Name_Leave(object sender, EventArgs e)
        {
            Tb_Name.Text = Tb_Name.Text.Trim();
        }

        private void Tb_Description_TextChanged(object sender, EventArgs e)
        {
            Lab_MaxLength.Text = Tb_Description.Text.Length.ToString() + "/1000";
            ActionID.Singleton.ActionModification = true;
        }
    }
}
