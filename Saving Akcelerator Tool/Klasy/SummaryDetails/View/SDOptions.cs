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
using Saving_Accelerator_Tool.Klasy.SummaryDetails.Framework;

namespace Saving_Accelerator_Tool.Klasy.SummaryDetails.View
{
    public partial class SDOptions : UserControl
    {
        public SDOptions()
        {
            InitializeComponent();
        }

        public void InitiazlizeData()
        {
            num_SummaryDetailYear.ValueChanged -= Num_SummaryDetailYear_ValueChanged;
            Comb_SummDetLeader.SelectedIndexChanged -= Comb_SummDetLeader_SelectedIndexChanged;
            Comb_SummDetDevision.SelectedIndexChanged -= Comb_SummDetDevision_SelectedIndexChanged;

            num_SummaryDetailYear.Value = DateTime.UtcNow.Year;
            _ = new LoadEmployees(Comb_SummDetLeader, true);
            _ = new LoadDevision(Comb_SummDetDevision, true);

            num_SummaryDetailYear.ValueChanged += Num_SummaryDetailYear_ValueChanged;
            Comb_SummDetLeader.SelectedIndexChanged += Comb_SummDetLeader_SelectedIndexChanged;
            Comb_SummDetDevision.SelectedIndexChanged += Comb_SummDetDevision_SelectedIndexChanged;
        }

        public void SetYear(decimal Year)
        {
            num_SummaryDetailYear.ValueChanged -= Num_SummaryDetailYear_ValueChanged;
            num_SummaryDetailYear.Value = Year;
            num_SummaryDetailYear.ValueChanged += Num_SummaryDetailYear_ValueChanged;
        }

        public void SetLeader(int index)
        {
            Comb_SummDetLeader.SelectedIndexChanged -= Comb_SummDetLeader_SelectedIndexChanged;
            Comb_SummDetLeader.SelectedIndex = index;
            Comb_SummDetLeader.SelectedIndexChanged += Comb_SummDetLeader_SelectedIndexChanged;
        }

        public void SetDevision(int index)
        {
            Comb_SummDetDevision.SelectedIndexChanged -= Comb_SummDetDevision_SelectedIndexChanged;
            Comb_SummDetDevision.SelectedIndex = index;
            Comb_SummDetDevision.SelectedIndexChanged += Comb_SummDetDevision_SelectedIndexChanged;
        }

        public void SetPositiveAction(bool Value)
        {
            CB_Positive.CheckedChanged -= CB_Positive_CheckedChanged;
            CB_Positive.Checked = Value;
            CB_Positive.CheckedChanged += CB_Positive_CheckedChanged;
        }

        public void SetNegativeAction(bool Value)
        {
            CB_Negative.CheckedChanged -= CB_Negative_CheckedChanged;
            CB_Negative.Checked = Value;
            CB_Negative.CheckedChanged += CB_Negative_CheckedChanged;
        }

        public void SetActiveAction(bool Value)
        {
            CB_Active.CheckedChanged -= CB_Active_CheckedChanged;
            CB_Active.Checked = Value;
            CB_Active.CheckedChanged += CB_Active_CheckedChanged;
        }

        public void SetIdeaAction(bool Value)
        {
            CB_Idea.CheckedChanged -= CB_Idea_CheckedChanged;
            CB_Idea.Checked = Value;
            CB_Idea.CheckedChanged += CB_Idea_CheckedChanged;
        }

        public decimal GetYear()
        {
            return num_SummaryDetailYear.Value;
        }

        public bool GetActive()
        {
            return CB_Active.Checked;
        }

        public bool GetIdea()
        {
            return CB_Idea.Checked;
        }

        public bool GetPositive()
        {
            return CB_Positive.Checked;
        }

        public bool GetNegative()
        {
            return CB_Negative.Checked;
        }

        public string GetLeader()
        {
            return Comb_SummDetLeader.SelectedItem.ToString();
        }

        public string GetDevision()
        {
            return Comb_SummDetDevision.SelectedItem.ToString();
        }

        private void CB_Positive_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new UpdateOptionsPositive((sender as CheckBox).Checked);
            _ = new LoadAllSummary();
            Cursor.Current = Cursors.Default;
        }

        private void CB_Negative_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new UpdateOptionsNegative((sender as CheckBox).Checked);
            _ = new LoadAllSummary();
            Cursor.Current = Cursors.Default;
        }

        private void CB_Active_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new UpdateOptionsActive((sender as CheckBox).Checked);
            _ = new LoadAllSummary();
            Cursor.Current = Cursors.Default;
        }

        private void CB_Idea_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new UpdateOptionsIdea((sender as CheckBox).Checked);
            _ = new LoadAllSummary();
            Cursor.Current = Cursors.Default;
        }

        private void Comb_SummDetDevision_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new UpdateOptionsDevision((sender as ComboBox).SelectedIndex);
            _ = new LoadAllSummary();
            Cursor.Current = Cursors.Default;
        }

        private void Comb_SummDetLeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new UpdateOptionsLeader((sender as ComboBox).SelectedIndex);
            _ = new LoadAllSummary();
            Cursor.Current = Cursors.Default;
        }

        private void Num_SummaryDetailYear_ValueChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new UpdateOptionsYear((sender as NumericUpDown).Value);
            _ = new LoadAllSummary();
            MainProgram.Self.sdReporting1.UpdateReporting(null);
            Cursor.Current = Cursors.Default;
        }

        private void Pb_SummDet_Show_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            _ = new LoadAllSummary();
            MainProgram.Self.sdReporting1.UpdateReporting(null);
            Cursor.Current = Cursors.Default;
        }
    }
}
