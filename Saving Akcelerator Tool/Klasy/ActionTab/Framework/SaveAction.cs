using Saving_Accelerator_Tool.Controllers.Action;
using Saving_Accelerator_Tool.Klasy.ActionTab.Framework.Save;
using Saving_Accelerator_Tool.Klasy.Acton;
using Saving_Accelerator_Tool.Model;
using Saving_Accelerator_Tool.Model.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Saving_Accelerator_Tool.Klasy.ActionTab.Framework
{
    class SaveAction
    {
        private readonly ActionDB OriginalAction;
        public SaveAction()
        {
            //Sprawdzamy czy wszystko jest dozwolone do zapisu i czy czegoś nie brakuje;
            if (!CheckPermisionToSave())
                return;

            if (ActionID.Singleton.ID != 0)
            {
                ActionDB NewAction;
                OriginalAction = ActionController.Load_ID(ActionID.Singleton.ID);
                NewAction = ActionSave.Save();

                if (ActionID.Singleton.ActionModification)
                {
                    ActionController.ModificationAction(OriginalAction, NewAction);
                    //ActionID.Delete();
                    ActionID.Singleton.ID = NewAction.ID;
                }

                //Jeśli zmianie ulegają ANC to tedy ma działać
                if (ActionID.Singleton.ANCModification)
                {
                    IEnumerable<ANCChangeDB> ANCs = ANCChangeSave.ANCSave();
                    if (OriginalAction.ID != NewAction.ID && NewAction.ID != 0)
                    {
                        ANCChangeController.UpdateANC(OriginalAction.ID, NewAction.ID, ANCs);
                    }
                    else
                    {
                        ANCChangeController.UpdateANC(OriginalAction.ID, OriginalAction.ID, ANCs);
                    }
                }
                else
                {
                    //Update tylko ID akcji
                    if (OriginalAction.ID != NewAction.ID && NewAction.ID != 0)
                    {
                        ANCChangeController.UpdateActionID(OriginalAction.ID, NewAction.ID);
                    }
                }

                //Jeśli jest zmiana w Mass Calculation to ma coś zmienić
                if (ActionID.Singleton.MassModification)
                {
                    if (NewAction.Group_Calc && OriginalAction.Group_Calc)
                    {
                        CalculationMassDB Mass = CalculationMassSave.Mass();
                        if (OriginalAction.ID != NewAction.ID && NewAction.ID != 0)
                        {
                            CalculationMassController.Update(OriginalAction.ID, NewAction.ID, Mass);
                        }
                        else
                        {
                            CalculationMassController.Update(OriginalAction.ID, OriginalAction.ID, Mass);
                        }
                    }
                    else if (NewAction.Group_Calc && !OriginalAction.Group_Calc)
                    {
                        CalculationMassDB Mass = CalculationMassSave.Mass();

                        Mass.ActionID = NewAction.ID;
                        CalculationMassController.Add(Mass);
                    }
                    else if (!NewAction.Group_Calc && OriginalAction.Group_Calc)
                    {
                        CalculationMassController.Deactivation(OriginalAction.ID);
                    }
                }
                else
                {
                    if (OriginalAction.Group_Calc)
                    {
                        //Update tylko ID akcji
                        if (OriginalAction.ID != NewAction.ID && NewAction.ID != 0)
                        {
                            ANCChangeController.UpdateActionID(OriginalAction.ID, NewAction.ID);
                        }
                    }
                }

                //Jeśli jest zmiania w liście PNC to ma zmienic
                if (ActionID.Singleton.PNCModification)
                {
                    if (NewAction.PNC && OriginalAction.PNC)
                    {
                        IEnumerable<PNCListDB> PNCList = PNCSave.Save();
                        if (OriginalAction.ID != NewAction.ID && NewAction.ID != 0)
                        {
                            PNCListController.UpatePNCList(OriginalAction.ID, NewAction.ID, PNCList);
                        }
                        else
                        {
                            PNCListController.UpatePNCList(OriginalAction.ID, OriginalAction.ID, PNCList);
                        }
                    }
                    else if (NewAction.PNC && !OriginalAction.PNC)
                    {
                        IEnumerable<PNCListDB> PNCList = PNCSave.Save();
                        foreach (PNCListDB PNC in PNCList)
                            PNC.ActionID = NewAction.ID;

                        PNCListController.Add(PNCList);
                    }
                    else if (!NewAction.PNC && OriginalAction.PNC)
                    {
                        PNCListController.Deactivation(OriginalAction.ID);

                    }
                }
                else
                {
                    //Update tylko ID akcji
                    if (OriginalAction.ID != NewAction.ID && NewAction.ID != 0)
                    {
                        PNCListController.UpdateID(OriginalAction.ID, NewAction.ID);
                    }
                }

                if (ActionID.Singleton.PNCSpecModification)
                {
                    if (NewAction.PNCSpec && OriginalAction.PNCSpec)
                    {//Update
                        IEnumerable<PNCSpecialDB> List = PNCSpecialSave.Save();
                        if (OriginalAction.ID != NewAction.ID && NewAction.ID != 0)
                        {
                            PNCSpecialController.UpdateList(List, OriginalAction.ID, NewAction.ID);
                        }
                        else
                        {
                            PNCSpecialController.UpdateList(List, OriginalAction.ID, OriginalAction.ID);
                        }
                    }
                    else if (NewAction.PNCSpec && !OriginalAction.PNCSpec)
                    {//Nowe
                        IEnumerable<PNCSpecialDB> List = PNCSpecialSave.Save();
                        foreach (PNCSpecialDB PNC in List)
                            PNC.ActionID = NewAction.ID;
                        PNCSpecialController.Add(List);
                    }
                    else if (!NewAction.PNCSpec && OriginalAction.PNCSpec)
                    {//Usuwamy
                        PNCSpecialController.Deactivation(OriginalAction.ID);
                    }
                }
            }
            else
            {
                ActionDB ActionToSave = ActionSave.Save();
                ActionToSave.Rev = 1;
                ActionToSave.ActionIDOriginal = 0;
                ActionController.NewAction(ActionToSave);
                OriginalAction = ActionController.FindAction(ActionToSave.Name, ActionToSave.StartYear);

                //IEnumerable<ANCChangeDB> ListANC = ANCChangeSave.ANCSave();
                //foreach(var ANC in ListANC)
                //{
                //    ANC.ActionID = OriginalAction.ID;
                //    ANC.Rev = 1;
                //}
                //ANCChangeController.Add(ListANC);

                //if (OriginalAction.ANCSpec)
                //{
                //    CalculationMassDB MassList = CalculationMassSave.Mass();
                //    MassList.ActionID = OriginalAction.ID;
                //    MassList.Rev = 1;
                //    CalculationMassController.Add(MassList);
                //}
                //else if(OriginalAction.PNC)
                //{
                //    IEnumerable<PNCListDB> PNCList = PNCSave.Save();
                //    foreach(var Row in PNCList)
                //    {
                //        Row.ActionID = OriginalAction.ID;
                //        Row.Rev = 1;
                //    }
                //}
                //else if(OriginalAction.PNCSpec)
                //{
                //    IEnumerable<PNCSpecialDB> PNCSpecialList = PNCSpecialSave.Save();
                //    foreach(var Row in PNCSpecialList)
                //    {
                //        Row.ActionID = OriginalAction.ID;
                //        Row.Rev = 1;
                //    }
                //}
            }
        }

        private bool CheckPermisionToSave()
        {
            var Action = MainProgram.Self.actionView;
            //Sprawdzenie czy Nazwa Akcji jest poprawna i czy nie jest już używana w histori - Sprawdzenie tylko dla nowych akcji
            if (!CheckNameNewAction())
                return false;

            //Sprawdzenie czy Wszystkie ANC w ANCChange są poprawnie wpisane
            if (!Action.ANCChangeView.Save)
            {
                MessageBox.Show("Please correct all ANC in Color RED!", "Warning!");
                return false;
            }

            //Sprawdzenie czy Wszystkie ANC w NextANC są poprawnie wpisane
            if (!Action.NextANC.Save)
            {
                MessageBox.Show("Please correct all ANC in Color RED!", "Warning!");
                return false;
            }

            //Sprawdzenie czy ANC by lub Group jest wybrane aby zapisać akcje
            if (Action.calculationByView.GetANCSpec())
            {
                if (!Action.CalculationGroup.Save_ANC)
                {
                    MessageBox.Show("Please select ANC what will be used for calculation!", "Warning!");
                    return false;
                }
                if (!Action.CalculationGroup.Save_Group)
                {
                    MessageBox.Show("Please select Group what will be used for calculation!", "Warning!");
                    return false;
                }
            }

            return true;
        }

        private bool CheckNameNewAction()
        {
            var Action = MainProgram.Self.actionView.nameView;

            if (ActionID.Singleton.ID == 0)
            {
                if (Action.GetActionName() == string.Empty)
                {
                    MessageBox.Show("Action Name can't be EMPTY!", "Warning!");
                    return false;
                }
                if (Action.GetActionName().Length <= 10)
                {
                    MessageBox.Show("Action Name can't be shorter than 10 characters.", "Warning!");
                    return false;
                }
                if (!ActionController.CheckIfNameExist(Action.GetActionName()))
                {
                    MessageBox.Show("Action Name exist, Please change!", "Warning!");
                    return false;
                }
            }
            return true;
        }
    }
}
