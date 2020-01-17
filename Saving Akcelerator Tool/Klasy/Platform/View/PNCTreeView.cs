using Saving_Accelerator_Tool.Klasy.Platform.Handlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform.View
{
    public class PNCTreeView : PNCTreeHandler
    {
        private readonly TabPage _PlatformTab;
        private GroupBox _tree;
        public PNCTreeView(TabPage PlatformTab)
        {
            _PlatformTab = PlatformTab;

            GroupBoxCreate();
            TreeCreate();
        }

        private void GroupBoxCreate()
        {
            GroupBox gb_Tree = new GroupBox
            {
                Location = new Point(10, 120),
                Size = new Size(250, 850),
                Name = "gb_Platform_Tree",
                Text = "PNC List:",
                TabStop = false,
            };
            _PlatformTab.Controls.Add(gb_Tree);
            _tree = gb_Tree;
        }

        private void TreeCreate()
        {
            TreeView Tree_PNC = new TreeView
            {
                Location = new Point(0, 20),
                Size = new Size(250, 830),
                Name = "Tree_PlatformPNC",
                TabIndex = 0,
                HideSelection = true,
            };
            Tree_PNC.AfterSelect += new TreeViewEventHandler(Tree_PNC_AfterSelect);
            _tree.Controls.Add(Tree_PNC);
        }

    }
}
