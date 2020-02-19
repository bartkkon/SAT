using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.ActionTab.Framework;
using Saving_Accelerator_Tool.Klasy.Acton;
using Saving_Accelerator_Tool.Klasy.User;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View.Action
{
    public partial class StateView : UserControl
    {
        public StateView()
        {
            InitializeComponent();
            
        }

        public void InitializeData()
        {
            cb_Active.Checked = true;
            comBox_Factory.SelectedIndex = 0;
            comBox_Month.SelectedIndex = DateTime.UtcNow.Month - 1;
            num_Action_YearAction.Value = DateTime.UtcNow.Year;
//#if DEBUG
            _ = new LoadEmployees(comBox_Leader, false);
           _ = new LoadDevision(comBox_Devision, false);
//#endif
        }
        public void SetActive()
        {
            cb_Active.Checked = true;
        }

        public bool GetActive()
        {
            return cb_Active.Checked;
        }
        public void SetIdea()
        {
            cb_Idea.Checked = true;
        }
        public bool GetIdea()
        {
            return cb_Idea.Checked;
        }

        public void SetYear(decimal Year)
        {
            num_Action_YearAction.Value = Year;
        }

        public decimal GetYear()
        {
            return num_Action_YearAction.Value;
        }

        public void SetFactory(string Factory)
        {
            if(comBox_Factory.Items.Contains(Factory))
            {
                comBox_Factory.SelectedIndex = comBox_Factory.FindString(Factory);
            }
        }

        public string GetFactory()
        {
            return comBox_Factory.SelectedItem.ToString();
        }

        public void SetLeader(string Leader)
        {
            if (comBox_Leader.Items.Contains(Leader))
            {
                comBox_Leader.SelectedIndex = comBox_Leader.FindString(Leader);
            }
        }

        public string GetLeader()
        {
            return comBox_Leader.SelectedItem.ToString();
        }

        public void SetDevision(string Devision)
        {
            if (comBox_Devision.Items.Contains(Devision))
            {
                comBox_Devision.SelectedIndex = comBox_Devision.FindString(Devision);
            }
        }
        public string GetDevison()
        {
            return comBox_Devision.SelectedItem.ToString();
        }

        public void SetStartMonth(string Month)
        {
            if (comBox_Month.Items.Contains(Month))
            {
                comBox_Month.SelectedIndex = comBox_Month.FindString(Month);
            }
        }

        public void Clear()
        {
            cb_Active.Checked = true;
            SetFactory("PLV");
            num_Action_YearAction.Value = DateTime.UtcNow.Year;
            comBox_Month.SelectedIndex = DateTime.UtcNow.Month;
            SetLeader(Users.Singleton.Name);
            comBox_Devision.SelectedIndex = 1;
        }

        public string GetStartMonth()
        {
            return comBox_Month.SelectedItem.ToString();
        }

        private void Cb_Active_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as CheckBox).Text == "Active")
            {
                cb_Idea.CheckedChanged -= Cb_Active_CheckedChanged;
                cb_Idea.Checked = false;
                cb_Idea.CheckedChanged += Cb_Active_CheckedChanged;
            }
            else if((sender as CheckBox).Text == "Idea")
            {
                cb_Active.CheckedChanged -= Cb_Active_CheckedChanged;
                cb_Active.Checked = false;
                cb_Active.CheckedChanged += Cb_Active_CheckedChanged;
            }
        }
    }
}
