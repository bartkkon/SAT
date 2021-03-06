﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;
using Saving_Accelerator_Tool.Klasy.User;
using Saving_Accelerator_Tool.Klasy.StatisticTab;
using Saving_Accelerator_Tool.Klasy.Platform;

namespace Saving_Accelerator_Tool
{
    class BuildForm
    {

        private DataRow Person;


        public void Tab_Control_Add(DataTable Access, MainProgram mainProgram, Action action, SummaryDetails summaryDetails, Admin admin, Data_Import ImportData)
        {
            Person = Access.Rows[0];

            Users User = Users.Singleton();
            
            // 
            // Tab_Action
            // 
            if (User.ActionTab)
            {

                TabPage tab_Action = new TabPage();
                mainProgram.TabControl.Controls.Add(tab_Action);
                tab_Action.Location = new System.Drawing.Point(4, 22);
                tab_Action.Name = "tab_Action";
                tab_Action.Padding = new Padding(3);
                tab_Action.Size = new System.Drawing.Size(1826, 877);
                tab_Action.TabIndex = 0;
                tab_Action.Text = "Action";
                tab_Action.UseVisualStyleBackColor = true;

                //Tab_Action_Comp();
                _ = new ActionForm(action);
                action.Action_NoChangeInAction();
            }
            // 
            // tab_SummaryDetail
            // 
            if (User.SummaryTab)
            {
                TabPage tab_SummaryDetail = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_Summary",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 1,
                    Text = "Summary Detail",
                    UseVisualStyleBackColor = true
                };

                mainProgram.TabControl.Controls.Add(tab_SummaryDetail);
            
                TabPage tab_Summary = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_SummaryS",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 2,
                    Text = "Summary",
                    UseVisualStyleBackColor = true
                };

                mainProgram.TabControl.Controls.Add(tab_Summary);
                _ = new SummaryDetailsForm(Person, summaryDetails);

            }

            //
            // Tab Statistic- dane statystyczne
            //
            if(User.StatisticTab)
            {
                _ = new StatisticTabGenerator();
            }

            //
            // Tab Platform Savings - dane statystyczne
            //
            if (User.PlatformTab)
            {
                _ = new PlatformTabGenerator();
            }
            // 
            // tab_STK
            // 
            if (User.STKTab)
            {
                TabPage tab_STK = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_STK",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 5,
                    Text = "STK3",
                    UseVisualStyleBackColor = true
                };

                mainProgram.TabControl.Controls.Add(tab_STK);

                Tab_STK_Comp();
            }
            // 
            // tab_Quantity
            // 
            if (User.QuantityTab)
            {
                TabPage tab_Quantity = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_Quantity",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 6,
                    Text = "Quantity",
                    UseVisualStyleBackColor = true
                };

                mainProgram.TabControl.Controls.Add(tab_Quantity);

                Tab_Quantity_Comp();
            }
            // 
            // tab_Admin
            // 
            if (User.AdminTab)
            {
                TabPage tab_Admin = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_Admin",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 7,
                    Text = "Administration ",
                    UseVisualStyleBackColor = true
                };

                mainProgram.TabControl.Controls.Add(tab_Admin);

                _ = new AdminForm(mainProgram, action, admin, ImportData);

                TabPage tab_AdminAction = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_AdminAction",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 8,
                    Text = "Action Admin",
                    UseVisualStyleBackColor = true,
                };

                mainProgram.TabControl.Controls.Add(tab_AdminAction);

                _ = new ModifiActionForm(tab_AdminAction);
            }
        }

        private void Tab_STK_Comp()
        {

        }

        private void Tab_Quantity_Comp()
        {

        }

 
    }
}
