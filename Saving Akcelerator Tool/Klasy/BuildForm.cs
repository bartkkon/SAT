using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.ComponentModel;

namespace Saving_Accelerator_Tool
{
    class BuildForm
    {
        Action action;
        MainProgram mainProgram;
        Admin admin;
        DataRow Person;
        SummaryDetails summaryDetails;
        Data_Import ImportData;

        public void Tab_Control_Add(DataTable Access, MainProgram mainProgram, Action action, SummaryDetails summaryDetails, Admin admin, Data_Import ImportData)
        {
            Person = Access.Rows[0];
            this.action = action;
            this.mainProgram = mainProgram;
            this.summaryDetails = summaryDetails;
            this.admin = admin;
            this.ImportData = ImportData;
            
            // 
            // Tab_Action
            // 
            if (Person["tab_Action"].ToString() == "true")
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
                ActionForm actionForm = new ActionForm(mainProgram, action, summaryDetails, admin, ImportData, Person);
            }
            // 
            // tab_SummaryDetail
            // 
            if (Person["tab_Summary"].ToString() == "true")
            {
                TabPage tab_SummaryDetail = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_Summary",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 3,
                    Text = "Summary Detail",
                    UseVisualStyleBackColor = true
                };

                mainProgram.TabControl.Controls.Add(tab_SummaryDetail);
            
                TabPage tab_Summary = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_SummaryS",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 3,
                    Text = "Summary",
                    UseVisualStyleBackColor = true
                };

                mainProgram.TabControl.Controls.Add(tab_Summary);

                SummaryDetailsForm summaryDetailsForm = new SummaryDetailsForm(mainProgram, Person, summaryDetails,ImportData);

            }
            // 
            // tab_STK
            // 
            if (Person["tab_STK"].ToString() == "true")
            {
                TabPage tab_STK = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_STK",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 1,
                    Text = "STK3",
                    UseVisualStyleBackColor = true
                };

                mainProgram.TabControl.Controls.Add(tab_STK);

                Tab_STK_Comp(Person, mainProgram);
            }
            // 
            // tab_Quantity
            // 
            if (Person["tab_Quantity"].ToString() == "true")
            {
                TabPage tab_Quantity = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_Quantity",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 2,
                    Text = "Quantity",
                    UseVisualStyleBackColor = true
                };

                mainProgram.TabControl.Controls.Add(tab_Quantity);

                Tab_Quantity_Comp(Person, mainProgram);
            }
            // 
            // tab_Admin
            // 
            if (Person["tab_Admin"].ToString() == "true")
            {
                //admin = new Admin(mainProgram);
                TabPage tab_Admin = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_Admin",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 4,
                    Text = "Administration ",
                    UseVisualStyleBackColor = true
                };

                mainProgram.TabControl.Controls.Add(tab_Admin);

                AdminForm adminForm = new AdminForm(mainProgram, action, summaryDetails, admin, ImportData, Person);

                TabPage tab_AdminAction = new TabPage
                {
                    Location = new System.Drawing.Point(4, 22),
                    Name = "tab_AdminAction",
                    Size = new System.Drawing.Size(1826, 877),
                    TabIndex = 5,
                    Text = "Action Admin",
                    UseVisualStyleBackColor = true,
                };

                mainProgram.TabControl.Controls.Add(tab_AdminAction);

                ModifiActionForm modifiActionForm = new ModifiActionForm(mainProgram, tab_AdminAction, ImportData);
                //Tab_Admin_Comp(Person, mainProgram);
                
            }
        }

        private void Tab_STK_Comp(DataRow Person, MainProgram mainProgram)
        {

        }

        private void Tab_Quantity_Comp(DataRow Person, MainProgram mainProgram)
        {

        }

 
    }
}
