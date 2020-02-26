using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.User;
using Saving_Accelerator_Tool.Klasy.ActionTab.Framework;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View
{
    public partial class MainFilter : UserControl
    {
        public MainFilter()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            if (Users.Singleton.Action != "Developer")
                but_Action_NewAction.Visible = false;
        }

        public bool ActionActiveComboboxCheck()
        {
            return cb_ActionActive.Checked;
        }

        private void But_Action_NewAction_Click(object sender, EventArgs e)
        {
            _ = new ClearForm();
            _ = new ActionVerificationEnabled();
            MainProgram.Self.actionView.SetActionName("New Action");
        }

        private void Active_Idea_CheckedChange(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if((sender as CheckBox).Text == "Active Action")
            {
                cb_ActionIdea.CheckedChanged -= Active_Idea_CheckedChange;
                cb_ActionIdea.Checked = false;
                cb_ActionIdea.CheckedChanged += Active_Idea_CheckedChange;
            }
            else if((sender as CheckBox).Text == "Idea Action")
            {
                cb_ActionActive.CheckedChanged -= Active_Idea_CheckedChange;
                cb_ActionActive.Checked = false;
                cb_ActionActive.CheckedChanged += Active_Idea_CheckedChange;
            }

            TreeView ActionTree = (TreeView)MainProgram.Self.TabControl.Controls.Find("tree_Action", true).First();
            NumericUpDown Year = (NumericUpDown)MainProgram.Self.TabControl.Controls.Find("num_Action_YearOption", true).First();
            ComboBox Leader = (ComboBox)MainProgram.Self.TabControl.Controls.Find("comBox_FilterBy", true).First();

            _ = new LoadActionToTree(ActionTree, Year.Value, Leader.SelectedItem.ToString());

            Cursor.Current = Cursors.Default;
        }
    }
}
