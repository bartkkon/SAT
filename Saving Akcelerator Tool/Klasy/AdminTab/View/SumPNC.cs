﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Saving_Accelerator_Tool.Klasy.AdmnTab.Framework;

namespace Saving_Accelerator_Tool.Klasy.AdminTab.View
{
    public partial class SumPNC : UserControl
    {
        public SumPNC()
        {
            InitializeComponent();
            InitializeData();
        }

        private void InitializeData()
        {
            if(DateTime.UtcNow.Month != 1)
            {
                num_Admin_SumPNC_Month.Value = DateTime.UtcNow.Month;
                num_Admin_SumPNC_Year.Value = DateTime.UtcNow.Year;
            }
            else
            {
                num_Admin_SumPNC_Month.Value = 12;
                num_Admin_SumPNC_Year.Value = DateTime.UtcNow.Year -1;
            }

        }

        private void Pb_Admin_SumPNC_Month_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GroupingPNC PNC = new GroupingPNC(num_Admin_SumPNC_Year.Value, num_Admin_SumPNC_Month.Value);
            PNC.GrupingPNC_Month();
            Cursor.Current = Cursors.Default;
        }

        private void Pb_Admin_SumPNC_Revision_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            GroupingPNC PNC = new GroupingPNC(num_Admin_SumPNC_Year.Value, comb_Admin_SumPNC_Rev.SelectedItem.ToString());
            PNC.GrupingPNC_Revision();
            Cursor.Current = Cursors.Default;
        }
    }
}
