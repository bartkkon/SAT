using Saving_Accelerator_Tool.Klasy.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    public class LoadActionToTree
    {
        private readonly TreeView _actionTree;
        private readonly decimal _year;
        private readonly string _person;
        private string _status;

        public LoadActionToTree(TreeView ActionTree, decimal Year, string Person)
        {
            _actionTree = ActionTree;
            _year = Year;
            _person = Person;

            ActionStatus();
            ClearNode();
            AddNode();
            ActionLoad();
            TreeExpandAll();
        }

        private void TreeExpandAll()
        {
            _actionTree.ExpandAll();
            _actionTree.Nodes[0].EnsureVisible();
        }

        private void ActionLoad()
        {
            DataTable ActionList = new DataTable();

            Data_Import.Singleton().Load_TxtToDataTable2(ref ActionList, "Action");

            foreach (DataRow Action in ActionList.Rows)
            {
                //Elektronicy
                if (Users.Singleton.ActionEle && Action["Group"].ToString() == "Electronic" && Action["StartYear"].ToString() == _year.ToString() && Action["Status"].ToString() == _status)
                {
                    AddAction("Electronic", Action["Name"].ToString(), Action["Leader"].ToString());
                }
                else if (Users.Singleton.ActionEle && Action["Group"].ToString() == "Electronic" && Action["StartYear"].ToString() == "SA/" + _year.ToString() && Action["Status"].ToString() == _status)
                {
                    AddAction("Electronic", Action["Name"].ToString(), Action["Leader"].ToString());
                }
                else if (Users.Singleton.ActionEle && Action["Group"].ToString() == "Electronic" && Action["StartYear"].ToString() == (_year - 1).ToString() && Action["Status"].ToString() == _status)
                {
                    AddAction("Electronic Carry Over", Action["Name"].ToString(), Action["Leader"].ToString());
                }
                //Mechanicy
                else if (Users.Singleton.ActionMech && Action["Group"].ToString() == "Mechanic" && Action["StartYear"].ToString() == _year.ToString() && Action["Status"].ToString() == _status)
                {
                    AddAction("Mechanic", Action["Name"].ToString(), Action["Leader"].ToString());
                }
                else if (Users.Singleton.ActionEle && Action["Group"].ToString() == "Mechanic" && Action["StartYear"].ToString() == "SA/" + _year.ToString() && Action["Status"].ToString() == _status)
                {
                    AddAction("Mechanic", Action["Name"].ToString(), Action["Leader"].ToString());
                }
                else if (Users.Singleton.ActionEle && Action["Group"].ToString() == "Mechanic" && Action["StartYear"].ToString() == (_year - 1).ToString() && Action["Status"].ToString() == _status)
                {
                    AddAction("Mechanic Carry Over", Action["Name"].ToString(), Action["Leader"].ToString());
                }
                //NVR
                else if (Users.Singleton.ActionMech && Action["Group"].ToString() == "NVR" && Action["StartYear"].ToString() == _year.ToString() && Action["Status"].ToString() == _status)
                {
                    AddAction("NVR", Action["Name"].ToString(), Action["Leader"].ToString());
                }
                else if (Users.Singleton.ActionEle && Action["Group"].ToString() == "NVR" && Action["StartYear"].ToString() == "SA/" + _year.ToString() && Action["Status"].ToString() == _status)
                {
                    AddAction("NVR", Action["Name"].ToString(), Action["Leader"].ToString());
                }
                else if (Users.Singleton.ActionEle && Action["Group"].ToString() == "NVR" && Action["StartYear"].ToString() == (_year - 1).ToString() && Action["Status"].ToString() == _status)
                {
                    AddAction("NVR Carry Over", Action["Name"].ToString(), Action["Leader"].ToString());
                }
            }
        }

        private void AddAction(string Node, string ActionName, string ActionLeader)
        {
            if (_person == "All")
                _actionTree.Nodes[Node].Nodes.Add(ActionName);
            else if (_person == ActionLeader)
                _actionTree.Nodes[Node].Nodes.Add(ActionName);
        }

        private void AddNode()
        {
            if (Users.Singleton.ActionEle)
            {
                _actionTree.Nodes.Add(new TreeNode("Electronic") { Name = "Electronic" });
                _actionTree.Nodes.Add(new TreeNode("Electronic Carry Over") { Name = "Electronic Carry Over" });
            }
            if (Users.Singleton.ActionMech)
            {
                _actionTree.Nodes.Add(new TreeNode("Mechanic") { Name = "Mechanic" });
                _actionTree.Nodes.Add(new TreeNode("Mechanic Carry Over") { Name = "Mechanic Carry Over" });
            }
            if (Users.Singleton.ActionNVR)
            {
                _actionTree.Nodes.Add(new TreeNode("NVR") { Name = "NVR" });
                _actionTree.Nodes.Add(new TreeNode("NVR Carry Over") { Name = "NVR Carry Over" });
            }
        }

        private void ClearNode()
        {
            _actionTree.Nodes.Clear();
        }

        private void ActionStatus()
        {
            if (MainProgram.Self.mainFilter.ActionActiveComboboxCheck())
                _status = "Active";
            else
                _status = "Idea";
        }
    }
}
