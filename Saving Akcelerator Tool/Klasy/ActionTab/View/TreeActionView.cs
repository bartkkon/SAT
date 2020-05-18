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
using Saving_Accelerator_Tool.Klasy.User;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.View
{
    public partial class TreeActionView : UserControl
    {
        public TreeActionView()
        {
            InitializeComponent();
        }

        public void InitializeData()
        {
            num_Action_YearOption.ValueChanged -= Num_Action_YearOption_ValueChanged;
            num_Action_YearOption.Value = DateTime.UtcNow.Year;
            num_Action_YearOption.ValueChanged += Num_Action_YearOption_ValueChanged;

            _ = new LoadEmployees(comBox_FilterBy, true);
        }

        public decimal GetYear()
        {
            return num_Action_YearOption.Value;
        }

        private void Num_Action_YearOption_ValueChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new LoadActionToTree(tree_Action, num_Action_YearOption.Value, comBox_FilterBy.SelectedItem.ToString());
            Cursor.Current = Cursors.WaitCursor;
        }

        private void ComBox_FilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new LoadActionToTree(tree_Action, num_Action_YearOption.Value, comBox_FilterBy.SelectedItem.ToString());

            if (Users.Singleton.Action == "Developer")
                MainProgram.Self.actionView.Enabled = true;

            Cursor.Current = Cursors.WaitCursor;
        }

        private void Tree_Action_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Text !="Electronic" && e.Node.Text != "Mechanic" && e.Node.Text != "NVR" && e.Node.Text != "Electronic Carry Over" && e.Node.Text != "Mechanic Carry Over" && e.Node.Text != "NVR Carry Over")
            {
                _ = new Framework.LoadAction(e.Node.Text, num_Action_YearOption.Value);
            }
        }
    }
}
