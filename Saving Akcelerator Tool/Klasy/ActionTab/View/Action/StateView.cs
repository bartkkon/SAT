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

        public string GetActionIdea()
        {
            if (cb_Active.Checked)
                return "Active";
            else
                return "Idea";
        }

        public void SetActionIdea(string What)
        {
            cb_Active.CheckedChanged -= Cb_Active_CheckedChanged;
            cb_Idea.CheckedChanged -= Cb_Active_CheckedChanged;
            if (What == "Active")
            {
                cb_Active.Checked = true;
                cb_Idea.Checked = false;
            }
            else if (What == "Idea")
            {
                cb_Active.Checked = false;
                cb_Idea.Checked = true;
            }
            cb_Active.CheckedChanged += Cb_Active_CheckedChanged;
            cb_Idea.CheckedChanged += Cb_Active_CheckedChanged;
        }

        public void SetYear(decimal Year)
        {
            num_Action_YearAction.ValueChanged -= ChangeSomenthing_Change;
            num_Action_YearAction.Value = Year;
            num_Action_YearAction.ValueChanged += ChangeSomenthing_Change;
        }

        public decimal GetYear()
        {
            return num_Action_YearAction.Value;
        }

        public void SetFactory(string Factory)
        {
            comBox_Factory.SelectedIndexChanged -= ChangeSomenthing_Change;
            if (comBox_Factory.Items.Contains(Factory))
            {
                comBox_Factory.SelectedIndex = comBox_Factory.FindString(Factory);
            }
            comBox_Factory.SelectedIndexChanged += ChangeSomenthing_Change;
        }

        public string GetFactory()
        {
            return comBox_Factory.SelectedItem.ToString();
        }

        public void SetLeader(string Leader)
        {
            comBox_Leader.SelectedIndexChanged -= ChangeSomenthing_Change;
            if (comBox_Leader.Items.Contains(Leader))
            {
                comBox_Leader.SelectedIndex = comBox_Leader.FindString(Leader);
            }
            comBox_Leader.SelectedIndexChanged += ChangeSomenthing_Change;
        }

        public string GetLeader()
        {
            return comBox_Leader.SelectedItem.ToString();
        }

        public void SetDevision(string Devision)
        {
            comBox_Devision.SelectedIndexChanged -= ChangeSomenthing_Change;
            if (comBox_Devision.Items.Contains(Devision))
            {
                comBox_Devision.SelectedIndex = comBox_Devision.FindString(Devision);
            }
            comBox_Devision.SelectedIndexChanged += ChangeSomenthing_Change;
        }
        public string GetDevison()
        {
            return comBox_Devision.SelectedItem.ToString();
        }

        public void SetStartMonth(string Month)
        {
            comBox_Month.SelectedIndexChanged -= ChangeSomenthing_Change;
            if (comBox_Month.Items.Contains(Month))
            {
                comBox_Month.SelectedIndex = comBox_Month.FindString(Month);
            }
            comBox_Month.SelectedIndexChanged += ChangeSomenthing_Change;
        }

        public void Clear()
        {
            cb_Active.CheckedChanged -= Cb_Active_CheckedChanged;
            cb_Idea.CheckedChanged -= Cb_Active_CheckedChanged;
            comBox_Devision.SelectedIndexChanged -= ChangeSomenthing_Change;

            cb_Active.Checked = true;
            cb_Idea.Checked = false;
            SetFactory("PLV");
            SetYear(DateTime.UtcNow.Year) ;
            SetStartMonth(DateTime.UtcNow.Month.ToString("MMMM"));
            SetLeader(Users.Singleton.Name);
            comBox_Devision.SelectedIndex = 0;

            comBox_Devision.SelectedIndexChanged += ChangeSomenthing_Change;
            cb_Active.CheckedChanged += Cb_Active_CheckedChanged;
            cb_Idea.CheckedChanged += Cb_Active_CheckedChanged;
        }

        public string GetStartMonth()
        {
            return comBox_Month.SelectedItem.ToString();
        }

        public int GetStartMonthInt()
        {
            return comBox_Month.SelectedIndex + 1;
        }

        private void Cb_Active_CheckedChanged(object sender, EventArgs e)
        {
            if((sender as CheckBox).Text == "Active")
            {
                cb_Idea.CheckedChanged -= Cb_Active_CheckedChanged;
                cb_Idea.Checked = false;
                ActionID.Singleton.ActionModification = true;
                cb_Idea.CheckedChanged += Cb_Active_CheckedChanged;
            }
            else if((sender as CheckBox).Text == "Idea")
            {
                cb_Active.CheckedChanged -= Cb_Active_CheckedChanged;
                cb_Active.Checked = false;
                ActionID.Singleton.ActionModification = true;
                cb_Active.CheckedChanged += Cb_Active_CheckedChanged;
            }
        }
        private void ChangeSomenthing_Change(object sender, EventArgs e)
        {
            ActionID.Singleton.ActionModification = true;
        }
    }
}
