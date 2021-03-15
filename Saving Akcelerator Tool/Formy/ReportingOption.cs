using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Saving_Accelerator_Tool
{
    public partial class ReportingOption : Form
    {
        //Data_Import ImportData;
        // MainProgram mainProgram;

        private readonly Dictionary<string, bool> Preferencje = new Dictionary<string, bool>();
        private readonly Dictionary<string, bool> AkcjeApprove = new Dictionary<string, bool>();

        decimal Year;

        public ReportingOption(decimal YearToAdd)
        {
            InitializeComponent();

            this.Name = "Choose your Report";
            TopSummary();
            ((Label)this.Controls.Find("Lab_InfoTop", true).First()).Text = "Personalize your report";

            PersonalizeRaport(YearToAdd);
        }

        //Dodawanie Panelu Top w Oknie.
        private void TopSummary()
        {
            GroupBox TopSumm = new GroupBox
            {
                Size = new Size(100, 50),
                Location = new Point(0, 0),
                Dock = DockStyle.Top,
                Name = "GB_TopSummary",
            };
            this.Controls.Add(TopSumm);

            Label InformationInTop = new Label
            {
                Size = new Size(10, 10),
                AutoSize = true,
                Location = new Point(10, 30),
                Name = "Lab_InfoTop",
            };
            TopSumm.Controls.Add(InformationInTop);

            Button But_Next = new Button
            {
                Size = new Size(80, 30),
                Location = new Point(this.Size.Width - 100, 10),
                Name = "But_Next",
                Text = "Next",
            };
            But_Next.Click += new EventHandler(Button_Next_Click);
            TopSumm.Controls.Add(But_Next);

            CheckBox All = new CheckBox
            {
                Size = new Size(30, 30),
                Location = new Point(400, 10),
                Name = "All_CheckBox",
                Text = "All",
                Checked = true,
                Visible = false,
            };
            All.CheckedChanged += new EventHandler(All_CheckedChange);
            TopSumm.Controls.Add(All);

        }

        //Personalizwoanie raportu
        private void PersonalizeRaport(decimal YearToAdd)
        {
            GroupBox Personalize = new GroupBox
            {
                Size = new Size(this.Size.Width, this.Size.Height - 60),
                Location = new Point(0, 60),
                Name = "GB_Personalize",
                Text = "Personalize:",
            };
            this.Controls.Add(Personalize);

            Status(Personalize, YearToAdd);

            Devision(Personalize);

            ActiveIdea(Personalize);

            PositiveAction(Personalize);

            WorkSheety(Personalize);

            ActionList(Personalize);

            SummList(Personalize);

            ActionDes(Personalize);

            CalcBy(Personalize, YearToAdd);
        }

        // Wybranie roku i czy akcje mają być z danego roku plus carry over czy nie 
        private void Status(GroupBox Personalize, decimal YearToCalc)
        {
            GroupBox groupBox = new GroupBox
            {
                Size = new Size(320, 45),
                Location = new Point(10, 15),
                Text = "Main",
                Name = "Gb_MainFilter",
            };
            Personalize.Controls.Add(groupBox);

            Label labYear = new Label
            {
                Location = new Point(10, 15),
                Size = new Size(10, 10),
                AutoSize = true,
                Text = "Year:",
                Name = "Lab_Year",
            };
            groupBox.Controls.Add(labYear);

            NumericUpDown Year = new NumericUpDown
            {
                Location = new Point(45, 15),
                Size = new Size(55, 20),
                Name = "Num_Year",
                Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0}),
                Minimum = new decimal(new int[] {
            2018,
            0,
            0,
            0}),
                Value = YearToCalc,
            };
            groupBox.Controls.Add(Year);

            CheckBox NewAction = new CheckBox
            {
                Location = new Point(110, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "ActionYear",
                Text = "Current Action",
                Checked = true,
            };
            groupBox.Controls.Add(NewAction);

            CheckBox CarryOverAction = new CheckBox
            {
                Location = new Point(205, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CarryOver",
                Text = "Carry Over Action",
                Checked = true,
            };
            groupBox.Controls.Add(CarryOverAction);
        }

        // Wybranie jakie Działy mają być dostępne do Generowania
        private void Devision(GroupBox Personalize)
        {
            GroupBox groupBox = new GroupBox
            {
                Size = new Size(320, 45),
                Location = new Point(10, 60),
                Text = "Devision",
                Name = "Gb_Devision",
            };
            Personalize.Controls.Add(groupBox);

            CheckBox Electronic = new CheckBox
            {
                Location = new Point(10, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Electronic",
                Text = "Electronic",
                Checked = false,
                Visible = false,
            };
            groupBox.Controls.Add(Electronic);

            CheckBox Mechanic = new CheckBox
            {
                Location = new Point(110, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Mechanic",
                Text = "Mechanic",
                Checked = false,
                Visible = false,
            };
            groupBox.Controls.Add(Mechanic);

            CheckBox NVR = new CheckBox
            {
                Location = new Point(190, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_NVR",
                Text = "NVR",
                Checked = false,
                Visible = false,
            };
            groupBox.Controls.Add(NVR);

            DataTable Access;
            Access = Data_Import.Singleton().Load_Access();
            DataRow Person = Access.Rows[0];

            if (Person["Role"].ToString() == "Admin" || Person["Role"].ToString() == "PCMenager")
            {
                Electronic.Checked = true;
                Electronic.Visible = true;
                NVR.Checked = true;
                NVR.Visible = true;
                Mechanic.Checked = true;
                Mechanic.Visible = true;
            }
            else if (Person["Role"].ToString() == "EleMenager")
            {
                Electronic.Checked = true;
                Electronic.Visible = true;
            }
            else if (Person["Role"].ToString() == "MechMenager")
            {
                Mechanic.Checked = true;
                Mechanic.Visible = true;
            }
            else if (Person["Role"].ToString() == "NVRMenager")
            {
                NVR.Checked = true;
                NVR.Visible = true;
            }

            //Person = Access.Select(string.Format(""))

        }

        //Jakie akcje mają być brane do kalkulacji Avtive czy Idea
        private void ActiveIdea(GroupBox Personalize)
        {
            GroupBox groupBox = new GroupBox
            {
                Size = new Size(320, 45),
                Location = new Point(10, 105),
                Text = "Active Action/Idea:",
                Name = "Gb_ActiveIdea",
            };
            Personalize.Controls.Add(groupBox);

            CheckBox Positive_Action = new CheckBox
            {
                Location = new Point(10, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Active",
                Text = "Active",
                Checked = true,
            };
            groupBox.Controls.Add(Positive_Action);

            CheckBox Negative_Action = new CheckBox
            {
                Location = new Point(110, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Idea",
                Text = "Idea",
                Checked = false,
            };
            groupBox.Controls.Add(Negative_Action);
        }

        //Wybranie czy akcje mają być pozytywne czy negatywne
        private void PositiveAction(GroupBox Personalize)
        {
            GroupBox groupBox = new GroupBox
            {
                Size = new Size(320, 45),
                Location = new Point(10, 150),
                Text = "Positive or Negativ Action:",
                Name = "Gb_Positive",
            };
            Personalize.Controls.Add(groupBox);

            CheckBox Positive_Action = new CheckBox
            {
                Location = new Point(10, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Positive",
                Text = "Positive Action",
                Checked = true,
            };
            groupBox.Controls.Add(Positive_Action);

            CheckBox Negative_Action = new CheckBox
            {
                Location = new Point(110, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Negative",
                Text = "Negative Action",
                Checked = true,
            };
            groupBox.Controls.Add(Negative_Action);
        }

        //Jakie workSheety będą generowane w Excelu
        private void WorkSheety(GroupBox Personalize)
        {
            GroupBox groupBox = new GroupBox
            {
                Size = new Size(320, 45),
                Location = new Point(10, 195),
                Text = "What Genereted:",
                Name = "Gb_Genereted",
            };
            Personalize.Controls.Add(groupBox);

            CheckBox ActionList = new CheckBox
            {
                Location = new Point(10, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_ActionList",
                Text = "Action List",
                Checked = true,
            };
            ActionList.CheckedChanged += new EventHandler(ActionList_CheckedChange);
            groupBox.Controls.Add(ActionList);

            CheckBox SummaryList = new CheckBox
            {
                Location = new Point(110, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_SummaryList",
                Text = "Summary",
                Checked = true,
            };
            SummaryList.CheckedChanged += new EventHandler(SummList_CheckedChange);
            groupBox.Controls.Add(SummaryList);
        }

        //Co ma być w worksheetcie a ActionList
        private void ActionList(GroupBox Personalization)
        {
            GroupBox Action = new GroupBox
            {
                Location = new Point(340, 15),
                Size = new Size(100, 400),
                Text = "Inside Action:",
                Name = "GB_Action",
            };
            Personalization.Controls.Add(Action);

            CheckBox Description = new CheckBox
            {
                Location = new Point(10, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Description",
                Text = "Description",
                Checked = true,
            };
            Action.Controls.Add(Description);

            CheckBox Status = new CheckBox
            {
                Location = new Point(10, 35),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Status",
                Text = "Status",
                Checked = true,
            };
            Action.Controls.Add(Status);

            CheckBox Platform = new CheckBox
            {
                Location = new Point(10, 55),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Platform",
                Text = "Platform",
                Checked = true,
            };
            Action.Controls.Add(Platform);

            CheckBox OldANC = new CheckBox
            {
                Location = new Point(10, 75),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_OldANC",
                Text = "OldANC",
                Checked = true,
                Enabled = false,
            };
            OldANC.CheckedChanged += new EventHandler(OLDANC_CheckedChange);
            Action.Controls.Add(OldANC);

            CheckBox ANCOLD = new CheckBox
            {
                Location = new Point(20, 95),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_ANCOLD",
                Text = "ANC",
                Checked = true,
                Enabled = false,
            };
            Action.Controls.Add(ANCOLD);

            CheckBox IDCOOLD = new CheckBox
            {
                Location = new Point(20, 115),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_IDCOOLD",
                Text = "IDCO",
                Checked = true,
                Enabled = false,
            };
            Action.Controls.Add(IDCOOLD);

            CheckBox STKOLD = new CheckBox
            {
                Location = new Point(20, 135),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_STKOLD",
                Text = "STK",
                Checked = true,
                Enabled = false,
            };
            Action.Controls.Add(STKOLD);

            CheckBox NewANC = new CheckBox
            {
                Location = new Point(10, 155),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_NewANC",
                Text = "NewANC",
                Checked = true,
                Enabled = false,
            };
            NewANC.CheckedChanged += new EventHandler(NewANC_CheckedChange);
            Action.Controls.Add(NewANC);

            CheckBox ANCNEW = new CheckBox
            {
                Location = new Point(20, 175),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_ANCNEW",
                Text = "ANC",
                Checked = true,
                Enabled = false,
            };
            Action.Controls.Add(ANCNEW);

            CheckBox IDCONEW = new CheckBox
            {
                Location = new Point(20, 195),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_IDCONEW",
                Text = "IDCO",
                Checked = true,
                Enabled = false,
            };
            Action.Controls.Add(IDCONEW);

            CheckBox STKNEW = new CheckBox
            {
                Location = new Point(20, 215),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_STKNEW",
                Text = "STK",
                Checked = true,
                Enabled = false,
            };
            Action.Controls.Add(STKNEW);

            CheckBox Delta = new CheckBox
            {
                Location = new Point(10, 235),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Delta",
                Text = "Delta",
                Checked = true,
            };
            Action.Controls.Add(Delta);

            CheckBox Quantity = new CheckBox
            {
                Location = new Point(10, 255),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Quantity",
                Text = "Quantity",
                Checked = true,
            };
            Action.Controls.Add(Quantity);

            CheckBox Savings = new CheckBox
            {
                Location = new Point(10, 275),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Savings",
                Text = "Savings",
                Checked = true,
            };
            Action.Controls.Add(Savings);

            CheckBox ECCC = new CheckBox
            {
                Location = new Point(10, 295),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_ECCC",
                Text = "ECCC",
                Checked = false,
            };
            Action.Controls.Add(ECCC);

        }

        //Co ma być w worksheetcie z Podsumowaniem 
        private void SummList(GroupBox Personalization)
        {
            GroupBox Action = new GroupBox
            {
                Location = new Point(450, 15),
                Size = new Size(100, 120),
                Text = "Inside Summary:",
                Name = "GB_SummList",
            };
            Personalization.Controls.Add(Action);

            CheckBox BU = new CheckBox
            {
                Location = new Point(10, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_BU",
                Text = "BU",
                Checked = true,
            };
            Action.Controls.Add(BU);

            CheckBox EA1 = new CheckBox
            {
                Location = new Point(10, 35),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_EA1",
                Text = "EA1",
                Checked = true,
            };
            Action.Controls.Add(EA1);

            CheckBox EA2 = new CheckBox
            {
                Location = new Point(10, 55),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_EA2",
                Text = "EA2",
                Checked = true,
            };
            Action.Controls.Add(EA2);

            CheckBox EA3 = new CheckBox
            {
                Location = new Point(10, 75),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_EA3",
                Text = "EA3",
                Checked = true,
            };
            Action.Controls.Add(EA3);

            CheckBox USE = new CheckBox
            {
                Location = new Point(10, 95),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_USE",
                Text = "USE",
                Checked = true,
            };
            Action.Controls.Add(USE);
        }

        //Jaki poziom akcji ma być generowany
        private void ActionDes(GroupBox Personalize)
        {
            GroupBox groupBox = new GroupBox
            {
                Size = new Size(320, 45),
                Location = new Point(10, 240),
                Text = "Action Level:",
                Name = "Gb_ActionLevel",
            };
            Personalize.Controls.Add(groupBox);

            CheckBox Minimum = new CheckBox
            {
                Location = new Point(10, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Minimum",
                Text = "Minimum",
                Checked = false,
                Enabled = false,
            };
            Minimum.CheckedChanged += new EventHandler(ActionDec_CheckedChange);
            groupBox.Controls.Add(Minimum);

            CheckBox Medium = new CheckBox
            {
                Location = new Point(110, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Medium",
                Text = "Medium",
                Checked = true,
            };
            Medium.CheckedChanged += new EventHandler(ActionDec_CheckedChange);
            groupBox.Controls.Add(Medium);

            CheckBox Maximum = new CheckBox
            {
                Location = new Point(190, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Maximum",
                Text = "Maximum",
                Checked = false,
                Enabled = false,
            };
            Maximum.CheckedChanged += new EventHandler(ActionDec_CheckedChange);
            groupBox.Controls.Add(Maximum);
        }

        //Jak mają być brane dane do Kalkulacji
        private void CalcBy(GroupBox Personalize, decimal YearToCalc)
        {
            GroupBox groupBox = new GroupBox
            {
                Size = new Size(320, 70),
                Location = new Point(10, 285),
                Text = "Calculation By:",
                Name = "Gb_CalcBy",
            };
            Personalize.Controls.Add(groupBox);

            CheckBox Actual = new CheckBox
            {
                Location = new Point(10, 15),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_Actual",
                Text = "Actual",
                Checked = true,
            };
            Actual.CheckedChanged += new EventHandler(CalcBy_Rewizion_CheckedChange);
            groupBox.Controls.Add(Actual);

            CheckBox BU = new CheckBox
            {
                Location = new Point(10, 45),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_CalcBU",
                Text = "BU",
                Checked = false,
            };
            BU.CheckedChanged += new EventHandler(CalcBy_Rewizion_CheckedChange);
            groupBox.Controls.Add(BU);

            CheckBox EA1 = new CheckBox
            {
                Location = new Point(70, 45),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_CalcEA1",
                Text = "EA1",
                Checked = false,
            };
            EA1.CheckedChanged += new EventHandler(CalcBy_Rewizion_CheckedChange);
            groupBox.Controls.Add(EA1);

            CheckBox EA2 = new CheckBox
            {
                Location = new Point(130, 45),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_CalcEA2",
                Text = "EA2",
                Checked = false,
            };
            EA2.CheckedChanged += new EventHandler(CalcBy_Rewizion_CheckedChange);
            groupBox.Controls.Add(EA2);

            CheckBox EA3 = new CheckBox
            {
                Location = new Point(190, 45),
                Size = new Size(40, 20),
                AutoSize = true,
                Name = "CB_CalcEA3",
                Text = "EA3",
                Checked = false,
            };
            EA3.CheckedChanged += new EventHandler(CalcBy_Rewizion_CheckedChange);
            groupBox.Controls.Add(EA3);

            if (YearToCalc > DateTime.Now.Year)
            {
                BU.Checked = true;
            }
            else if (YearToCalc < DateTime.Now.Year)
            {
                Actual.Checked = true;
            }
        }

        //Zapamiętanie do Dictionary wyborów użytkowaika
        private void Genereted_Dictionary()
        {
            Year = ((NumericUpDown)this.Controls.Find("Num_Year", true).First()).Value;

            Preferencje.Add("Current Action", ((CheckBox)this.Controls.Find("ActionYear", true).First()).Checked);
            Preferencje.Add("Carry Action", ((CheckBox)this.Controls.Find("CarryOver", true).First()).Checked);
            Preferencje.Add("Electronic", ((CheckBox)this.Controls.Find("CB_Electronic", true).First()).Checked);
            Preferencje.Add("Mechanic", ((CheckBox)this.Controls.Find("CB_Mechanic", true).First()).Checked);
            Preferencje.Add("NVR", ((CheckBox)this.Controls.Find("CB_NVR", true).First()).Checked);
            Preferencje.Add("Active", ((CheckBox)this.Controls.Find("CB_Active", true).First()).Checked);
            Preferencje.Add("Idea", ((CheckBox)this.Controls.Find("CB_Idea", true).First()).Checked);
            Preferencje.Add("Positive", ((CheckBox)this.Controls.Find("CB_Positive", true).First()).Checked);
            Preferencje.Add("Negative", ((CheckBox)this.Controls.Find("CB_Negative", true).First()).Checked);
            Preferencje.Add("WS Action", ((CheckBox)this.Controls.Find("CB_ActionList", true).First()).Checked);
            Preferencje.Add("WS Summ", ((CheckBox)this.Controls.Find("CB_SummaryList", true).First()).Checked);
            Preferencje.Add("Minimum", ((CheckBox)this.Controls.Find("CB_Minimum", true).First()).Checked);
            Preferencje.Add("Medium", ((CheckBox)this.Controls.Find("CB_Medium", true).First()).Checked);
            Preferencje.Add("Maximum", ((CheckBox)this.Controls.Find("CB_Maximum", true).First()).Checked);
            Preferencje.Add("Actual", ((CheckBox)this.Controls.Find("CB_Actual", true).First()).Checked);
            Preferencje.Add("BU", ((CheckBox)this.Controls.Find("CB_CalcBU", true).First()).Checked);
            Preferencje.Add("EA1", ((CheckBox)this.Controls.Find("CB_CalcEA1", true).First()).Checked);
            Preferencje.Add("EA2", ((CheckBox)this.Controls.Find("CB_CalcEA2", true).First()).Checked);
            Preferencje.Add("EA3", ((CheckBox)this.Controls.Find("CB_CalcEA3", true).First()).Checked);
            Preferencje.Add("Description", ((CheckBox)this.Controls.Find("CB_Description", true).First()).Checked);
            Preferencje.Add("Status", ((CheckBox)this.Controls.Find("CB_Status", true).First()).Checked);
            Preferencje.Add("Platform", ((CheckBox)this.Controls.Find("CB_Platform", true).First()).Checked);
            Preferencje.Add("Old ANC", ((CheckBox)this.Controls.Find("CB_OldANC", true).First()).Checked);
            Preferencje.Add("ANC Old", ((CheckBox)this.Controls.Find("CB_ANCOLD", true).First()).Checked);
            Preferencje.Add("Old IDCO", ((CheckBox)this.Controls.Find("CB_IDCOOLD", true).First()).Checked);
            Preferencje.Add("Old STK", ((CheckBox)this.Controls.Find("CB_STKOLD", true).First()).Checked);
            Preferencje.Add("New ANC", ((CheckBox)this.Controls.Find("CB_NewANC", true).First()).Checked);
            Preferencje.Add("ANC New", ((CheckBox)this.Controls.Find("CB_ANCNEW", true).First()).Checked);
            Preferencje.Add("New IDCO", ((CheckBox)this.Controls.Find("CB_IDCONEW", true).First()).Checked);
            Preferencje.Add("New STK", ((CheckBox)this.Controls.Find("CB_STKNEW", true).First()).Checked);
            Preferencje.Add("Delta", ((CheckBox)this.Controls.Find("CB_Delta", true).First()).Checked);
            Preferencje.Add("Quantity", ((CheckBox)this.Controls.Find("CB_Quantity", true).First()).Checked);
            Preferencje.Add("Savings", ((CheckBox)this.Controls.Find("CB_Savings", true).First()).Checked);
            Preferencje.Add("ECCC", ((CheckBox)this.Controls.Find("CB_ECCC", true).First()).Checked);
            Preferencje.Add("Sum USE", ((CheckBox)this.Controls.Find("CB_USE", true).First()).Checked);
            Preferencje.Add("Sum BU", ((CheckBox)this.Controls.Find("CB_BU", true).First()).Checked);
            Preferencje.Add("Sum EA1", ((CheckBox)this.Controls.Find("CB_EA1", true).First()).Checked);
            Preferencje.Add("Sum EA2", ((CheckBox)this.Controls.Find("CB_EA2", true).First()).Checked);
            Preferencje.Add("Sum EA3", ((CheckBox)this.Controls.Find("CB_EA3", true).First()).Checked);

        }

        //Wybranie akcji które mają być ujęte w zestawieniu
        private void Action_Selected()
        {
            GroupBox Personaliza = (GroupBox)this.Controls.Find("GB_Personalize", true).First();

            this.Controls.Remove(Personaliza);

            SelectedAction();
        }

        //Dodanie GroupBoxa dla dla wybrania akcji których mamy wybrać do raportu
        private void SelectedAction()
        {
            this.Size = new Size(this.Width, this.Size.Height + 260);

            GroupBox Selected = new GroupBox
            {
                Size = new Size(this.Size.Width - 15, this.Size.Height - 100),
                Location = new Point(0, 60),
                Name = "GB_Selected",
                Text = "Selected Action:",
            };
            this.Controls.Add(Selected);

            DataGridView Action = new DataGridView
            {
                Location = new Point(0, 0),
                Size = new Size(10, 10),
                Dock = DockStyle.Fill,
                Name = "DGV_SelectedAction",
            };
            Selected.Controls.Add(Action);

            DataGridViewCheckBoxColumn ColumnCheckBox = new DataGridViewCheckBoxColumn
            {
                Name = "Check",
                HeaderText = "",
                Width = 50,
                ReadOnly = false
            };

            Action.Columns.Add(ColumnCheckBox);

            Action.Columns.Add("Name", "Action Name");
            Action.Columns[1].ReadOnly = true;
            Action.Columns[1].Width = 285;
            Action.Columns.Add("Devision", "Devision");
            Action.Columns[2].ReadOnly = true;
            Action.Columns.Add("Pozitiv", "+/-");
            Action.Columns[3].ReadOnly = true;
            Action.Columns.Add("Idea", "Active/Idea");
            Action.Columns[4].ReadOnly = true;
            Action.Columns.Add("Current", "Actual/Carry Over");
            Action.Columns[5].ReadOnly = true;
            Action.AllowUserToAddRows = false;

            AddActionToDataGrid(Action);
        }

        //Dodanie do DataGridView akcji które były wybrane podczas zaznaczania
        private void AddActionToDataGrid(DataGridView Actions)
        {
            DataRow[] AllAction;
            DataTable Action = new DataTable();
            DataTable Frozen = new DataTable();
            DataRow FrozenRow;
            DataGridViewRow AllActionRow;
            int Index;
            int Month = 0;

            Data_Import.Singleton().Load_TxtToDataTable2(ref Action, "History");

            Data_Import.Singleton().Load_TxtToDataTable2(ref Frozen, "Frozen");

            FrozenRow = Frozen.Select(string.Format("Year LIKE '%{0}%'", Year.ToString())).First();

            for (int counter = 12; counter >= 1; counter--)
            {
                if (FrozenRow[counter.ToString()].ToString() == "Approve")
                {
                    Month = counter;
                    break;
                }
            }

            if (Preferencje["Actual"])
            {
                if (Month != 0)
                {
                    AllAction = Action.Select(string.Format("History LIKE '%{0}%'", Month + "/" + Year.ToString())).ToArray();
                }
                else
                {
                    AllAction = null;
                }
            }
            else
            {
                if (Preferencje["BU"])
                {
                    AllAction = Action.Select(string.Format("History LIKE '%{0}%'", "BU/" + Year.ToString())).ToArray();
                }
                else if (Preferencje["EA1"])
                {
                    AllAction = Action.Select(string.Format("History LIKE '%{0}%'", "EA1/" + Year.ToString())).ToArray();
                }
                else if (Preferencje["EA2"])
                {
                    AllAction = Action.Select(string.Format("History LIKE '%{0}%'", "EA2/" + Year.ToString())).ToArray();
                }
                else if (Preferencje["EA3"])
                {
                    AllAction = Action.Select(string.Format("History LIKE '%{0}%'", "EA3/" + Year.ToString())).ToArray();
                }
                else
                {
                    AllAction = null;
                }
            }

            if (AllAction != null)
            {
                foreach (DataRow ActionRow in AllAction)
                {
                    if (Preferencje["Current Action"])
                    {
                        if ((ActionRow["StartYear"].ToString() == Year.ToString()) || (ActionRow["StartYear"].ToString() == "BU/" + Year.ToString()) || (ActionRow["StartYear"].ToString() == ("SA/" + Year).ToString()))
                        {
                            if (Preferencje["Electronic"] && ActionRow["Group"].ToString() == "Electronic")
                            {
                                if (Preferencje["Active"] && ActionRow["Status"].ToString() == "Active")
                                {
                                    if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual");
                                    }
                                    else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual");
                                    }
                                }
                                else if (Preferencje["Idea"] && ActionRow["Status"].ToString() == "Idea")
                                {
                                    if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual");
                                    }
                                    else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual");
                                    }
                                }
                            }
                            if (Preferencje["Mechanic"] && ActionRow["Group"].ToString() == "Mechanic")
                            {
                                if (Preferencje["Active"] && ActionRow["Status"].ToString() == "Active")
                                {
                                    if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual");
                                    }
                                    else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual");
                                    }
                                }
                                else if (Preferencje["Idea"] && ActionRow["Status"].ToString() == "Idea")
                                {
                                    if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual");
                                    }
                                    else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual");
                                    }
                                }
                            }
                            if (Preferencje["NVR"] && ActionRow["Group"].ToString() == "NVR")
                            {
                                if (Preferencje["Active"] && ActionRow["Status"].ToString() == "Active")
                                {
                                    if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual");
                                    }
                                    else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual");
                                    }
                                }
                                else if (Preferencje["Idea"] && ActionRow["Status"].ToString() == "Idea")
                                {
                                    if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual"); ;
                                    }
                                    else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                    {
                                        Index = Actions.Rows.Add();
                                        AllActionRow = Actions.Rows[Index];
                                        AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Actual");
                                    }
                                }
                            }
                        }
                    }

                    if (Preferencje["Carry Action"])
                    {
                        if (ActionRow["StartYear"].ToString() == (Year - 1).ToString())
                        {
                            if (ActionRow["StartMonth"].ToString() != "January")
                            {
                                if (Preferencje["Electronic"] && ActionRow["Group"].ToString() == "Electronic")
                                {
                                    if (Preferencje["Active"] && ActionRow["Status"].ToString() == "Active")
                                    {
                                        if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                        {
                                            Index = Actions.Rows.Add();
                                            AllActionRow = Actions.Rows[Index];
                                            AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Carry Over");
                                        }
                                        else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                        {
                                            Index = Actions.Rows.Add();
                                            AllActionRow = Actions.Rows[Index];
                                            AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Carry Over");
                                        }
                                    }
                                }
                                if (Preferencje["Mechanic"] && ActionRow["Group"].ToString() == "Mechanic")
                                {
                                    if (Preferencje["Active"] && ActionRow["Status"].ToString() == "Active")
                                    {
                                        if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                        {
                                            Index = Actions.Rows.Add();
                                            AllActionRow = Actions.Rows[Index];
                                            AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Carry Over");
                                        }
                                        else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                        {
                                            Index = Actions.Rows.Add();
                                            AllActionRow = Actions.Rows[Index];
                                            AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Carry Over");
                                        }
                                    }
                                }
                                if (Preferencje["NVR"] && ActionRow["Group"].ToString() == "NVR")
                                {
                                    if (Preferencje["Active"] && ActionRow["Status"].ToString() == "Active")
                                    {
                                        if (Preferencje["Positive"] && ActionRow["+ czy -"].ToString() == "Pozytywna")
                                        {
                                            Index = Actions.Rows.Add();
                                            AllActionRow = Actions.Rows[Index];
                                            AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Carry Over");
                                        }
                                        else if (Preferencje["Negative"] && ActionRow["+ czy -"].ToString() == "Negatywna")
                                        {
                                            Index = Actions.Rows.Add();
                                            AllActionRow = Actions.Rows[Index];
                                            AllActionRow = AddRowToTable(AllActionRow, ActionRow, "Carry Over");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        //Dodanie do Dictionary akcji aby łatwo się pracowało na tym
        private void ActionToDictionary()
        {
            DataGridView DG = (DataGridView)this.Controls.Find("DGV_SelectedAction", true).First();

            foreach (DataGridViewRow Row in DG.Rows)
            {
                AkcjeApprove.Add(Row.Cells["Name"].Value.ToString(), Convert.ToBoolean(Row.Cells[0].Value));
            }
        }

        private DataGridViewRow AddRowToTable(DataGridViewRow ActionRow, DataRow AllActionRow, string What)
        {
            ActionRow.Cells["Check"].Value = true;
            ActionRow.Cells["Name"].Value = AllActionRow["Name"].ToString();
            ActionRow.Cells["Devision"].Value = AllActionRow["Group"].ToString();
            ActionRow.Cells["Pozitiv"].Value = AllActionRow["+ czy -"].ToString();
            ActionRow.Cells["Idea"].Value = AllActionRow["Status"].ToString();
            ActionRow.Cells["Current"].Value = What;

            return ActionRow;
        }

        ////////////////////////////////////////////////////////////
        //Przerwania

        private void OLDANC_CheckedChange(object sender, EventArgs e)
        {
            ((CheckBox)this.Controls.Find("CB_ANCOLD", true).First()).Enabled = (sender as CheckBox).Checked;
            ((CheckBox)this.Controls.Find("CB_IDCOOLD", true).First()).Enabled = (sender as CheckBox).Checked;
            ((CheckBox)this.Controls.Find("CB_STKOLD", true).First()).Enabled = (sender as CheckBox).Checked;
        }

        private void NewANC_CheckedChange(object sender, EventArgs e)
        {
            ((CheckBox)this.Controls.Find("CB_ANCNEW", true).First()).Enabled = (sender as CheckBox).Checked;
            ((CheckBox)this.Controls.Find("CB_IDCONEW", true).First()).Enabled = (sender as CheckBox).Checked;
            ((CheckBox)this.Controls.Find("CB_STKNEW", true).First()).Enabled = (sender as CheckBox).Checked;
        }

        private void All_CheckedChange(object sender, EventArgs e)
        {
            DataGridView DG = (DataGridView)this.Controls.Find("DGV_SelectedAction", true).First();
            bool value = (sender as CheckBox).Checked;

            foreach (DataGridViewRow Row in DG.Rows)
            {
                Row.Cells[0].Value = value;
            }
        }

        private void ActionList_CheckedChange(object sender, EventArgs e)
        {
            ((GroupBox)this.Controls.Find("GB_Action", true).First()).Enabled = (sender as CheckBox).Checked;
            ((GroupBox)this.Controls.Find("Gb_ActionLevel", true).First()).Enabled = (sender as CheckBox).Checked;
        }

        private void SummList_CheckedChange(object sender, EventArgs e)
        {
            ((GroupBox)this.Controls.Find("GB_SummList", true).First()).Enabled = (sender as CheckBox).Checked;
        }

        private void ActionDec_CheckedChange(object sender, EventArgs e)
        {
            CheckBox Check = sender as CheckBox;

            ((CheckBox)this.Controls.Find("CB_Minimum", true).First()).CheckedChanged -= ActionDec_CheckedChange;
            ((CheckBox)this.Controls.Find("CB_Medium", true).First()).CheckedChanged -= ActionDec_CheckedChange;
            ((CheckBox)this.Controls.Find("CB_Maximum", true).First()).CheckedChanged -= ActionDec_CheckedChange;

            if (Check.Text == "Minimum")
            {
                ((CheckBox)this.Controls.Find("CB_Minimum", true).First()).Checked = true;
                ((CheckBox)this.Controls.Find("CB_Medium", true).First()).Checked = false;
                ((CheckBox)this.Controls.Find("CB_Maximum", true).First()).Checked = false;
            }
            else if (Check.Text == "Medium")
            {
                ((CheckBox)this.Controls.Find("CB_Minimum", true).First()).Checked = false;
                ((CheckBox)this.Controls.Find("CB_Medium", true).First()).Checked = true;
                ((CheckBox)this.Controls.Find("CB_Maximum", true).First()).Checked = false;
            }
            else if (Check.Text == "Maximum")
            {
                ((CheckBox)this.Controls.Find("CB_Minimum", true).First()).Checked = false;
                ((CheckBox)this.Controls.Find("CB_Medium", true).First()).Checked = false;
                ((CheckBox)this.Controls.Find("CB_Maximum", true).First()).Checked = true;
            }

            ((CheckBox)this.Controls.Find("CB_Minimum", true).First()).CheckedChanged += ActionDec_CheckedChange;
            ((CheckBox)this.Controls.Find("CB_Medium", true).First()).CheckedChanged += ActionDec_CheckedChange;
            ((CheckBox)this.Controls.Find("CB_Maximum", true).First()).CheckedChanged += ActionDec_CheckedChange;
        }

        private void Button_Next_Click(object sender, EventArgs e)
        {
            Button Click = sender as Button;

            if (Click.Text == "Next")
            {
                Click.Text = "Genereted";
                Genereted_Dictionary();
                Action_Selected();
                ((CheckBox)this.Controls.Find("All_CheckBox", true).First()).Visible = true;
                return;
            }
            else if (Click.Text == "Genereted")
            {
                Cursor.Current = Cursors.WaitCursor;
                ActionToDictionary();
                MultiRaport CreateRaport = new MultiRaport(AkcjeApprove, Preferencje, Year);
                CreateRaport.GeneretedMutliRaport();
                Cursor.Current = Cursors.Default;
                this.Close();
            }
        }

        private void CalcBy_Rewizion_CheckedChange(object sender, EventArgs e)
        {
            CheckBox Check = sender as CheckBox;
            CheckBox Actual = (CheckBox)this.Controls.Find("CB_Actual", true).First();
            CheckBox BU = (CheckBox)this.Controls.Find("CB_CalcBU", true).First();
            CheckBox EA1 = (CheckBox)this.Controls.Find("CB_CalcEA1", true).First();
            CheckBox EA2 = (CheckBox)this.Controls.Find("CB_CalcEA2", true).First();
            CheckBox EA3 = (CheckBox)this.Controls.Find("CB_CalcEA3", true).First();

            Actual.CheckedChanged -= CalcBy_Rewizion_CheckedChange;
            BU.CheckedChanged -= CalcBy_Rewizion_CheckedChange;
            EA1.CheckedChanged -= CalcBy_Rewizion_CheckedChange;
            EA2.CheckedChanged -= CalcBy_Rewizion_CheckedChange;
            EA3.CheckedChanged -= CalcBy_Rewizion_CheckedChange;

            if (Check.Text == "Actual")
            {
                BU.Checked = false;
                EA1.Checked = false;
                EA2.Checked = false;
                EA3.Checked = false;
            }
            if (Check.Text == "BU")
            {
                Actual.Checked = false;
                EA1.Checked = false;
                EA2.Checked = false;
                EA3.Checked = false;
            }
            else if (Check.Text == "EA1")
            {
                Actual.Checked = false;
                BU.Checked = false;
                EA2.Checked = false;
                EA3.Checked = false;
            }
            else if (Check.Text == "EA2")
            {
                Actual.Checked = false;
                BU.Checked = false;
                EA1.Checked = false;
                EA3.Checked = false;
            }
            else if (Check.Text == "EA3")
            {
                Actual.Checked = false;
                BU.Checked = false;
                EA1.Checked = false;
                EA2.Checked = false;
            }

            Actual.CheckedChanged += CalcBy_Rewizion_CheckedChange;
            BU.CheckedChanged += CalcBy_Rewizion_CheckedChange;
            EA1.CheckedChanged += CalcBy_Rewizion_CheckedChange;
            EA2.CheckedChanged += CalcBy_Rewizion_CheckedChange;
            EA3.CheckedChanged += CalcBy_Rewizion_CheckedChange;
        }
    }
}
