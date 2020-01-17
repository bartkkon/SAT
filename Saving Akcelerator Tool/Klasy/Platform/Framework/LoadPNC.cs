using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform.Framework
{
    public class LoadPNC
    {
        private readonly ComboBox _project;
        private readonly TreeView _tree;
        public LoadPNC()
        {
            _project = (ComboBox)MainProgram.Self.TabControl.Controls.Find("combo_Project", true).First();
            _tree = (TreeView)MainProgram.Self.TabControl.Controls.Find("Tree_PlatformPNC", true).First();

            ClearTree();
            LoadPNCToTree();
            ExpandAllNodes();
        }

        private void ExpandAllNodes()
        {
            _tree.ExpandAll();
        }

        private void ClearTree()
        {
            _tree.Nodes.Clear();
        }

        private void LoadPNCToTree()
        {
            DataTable PNCTable = new DataTable();
            DataRow[] ProjectPNC;

            Data_Import.Singleton().Load_TxtToDataTable2(ref PNCTable, "PlatformPNCList");

            ProjectPNC = PNCTable.Select(string.Format("Project LIKE '%{0}%'", _project.SelectedItem.ToString())).ToArray();

            AddTreeNodes(_project.SelectedItem.ToString());

            if(ProjectPNC != null)
            {
                foreach(DataRow Row in ProjectPNC)
                {
                    string PNCtoAdd = Row["NewPNC"].ToString() + "   (" + Row["OldPNC"].ToString() + ")";
                    AddToTreeNodes(_project.SelectedItem.ToString(), PNCtoAdd);
                }
            }
        }

        private void AddTreeNodes(string Name)
        {
            TreeNode NewNode = new TreeNode(Name)
            {
                Name = Name,
            };
            _tree.Nodes.Add(NewNode);
        }

        private void AddToTreeNodes(string NodeName, string Object)
        {
            _tree.Nodes[NodeName].Nodes.Add(Object);
        }
    }
}
