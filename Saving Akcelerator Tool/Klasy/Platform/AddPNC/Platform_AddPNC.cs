using Saving_Accelerator_Tool.Klasy.Platform.AddPNC.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool.Klasy.Platform.AddPNC
{
    public partial class Platform_AddPNC : Form
    {
        public Platform_AddPNC(string Project)
        {
            InitializeComponent();
            _ = new AddPNCView(this, Project);
        }
    }
}
