using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Diagnostics;
using Autodesk.Revit.UI.Events;
using System.IO;




namespace AAA_WTA_BeThis
{
        [Transaction(TransactionMode.Manual)]
        public class WorksetByPick : IExternalCommand
        {
            public Result Execute(
               ExternalCommandData commandData,
               ref string message,
               ElementSet elements)
            {
                UIApplication uiapp = commandData.Application;
                UIDocument uidoc = uiapp.ActiveUIDocument;
                Document doc = uidoc.Document;
      
                try
                {
                    bool stay = true;
                    while (stay)
                    {
                        Reference refPick = uidoc.Selection.PickObject(ObjectType.Element, "Pick the element for the Workset.");
                        Element elem = doc.GetElement(refPick);

                        Transaction trans = new Transaction(doc);
                        trans.Start("MightChangeWorksetByPick");
                        WorksetTable wst = doc.GetWorksetTable();
                        RevitHelpers rH = new RevitHelpers();
                        string activeWS = rH.WhatWorksetNameIsThis(wst.GetActiveWorksetId(), doc);

                        WorksetId itemWS = elem.WorksetId;
                        trans.Commit();
                        string thisPickWS = rH.WhatWorksetNameIsThis(itemWS, doc);
                        TaskDialog thisDialog = new TaskDialog("Active Workset Is: " + activeWS);
                        thisDialog.TitleAutoPrefix = false;
                        thisDialog.MainIcon = TaskDialogIcon.TaskDialogIconWarning;
                        thisDialog.CommonButtons = TaskDialogCommonButtons.Close | TaskDialogCommonButtons.Retry;
                        thisDialog.DefaultButton = TaskDialogResult.Retry;
                        thisDialog.FooterText = "Hiting Escape allows picking again.";

                        if ((thisPickWS != activeWS) && (!thisPickWS.Equals("")))
                        {
                            thisDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1,
                                    "Change Active Workset to: " + rH.WhatWorksetNameIsThis(itemWS, doc) + " ??");
                            thisDialog.FooterText = "Hiting Escape allows picking again.  (BTW: The question is a button.)";
                        }
                        if (thisPickWS != activeWS)
                        {
                            thisDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1,
                                    "Change Active Workset to: " + rH.WhatWorksetNameIsThis(itemWS, doc) + " ??");
                            thisDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink2,
                                    "OR Change this Pick to the Active Workset: " + activeWS + " ??");

                            thisDialog.FooterText = "Hiting Escape allows picking again.  (BTW: The question is a button.)";
                        }
                        if (thisPickWS == "") { thisPickWS = "Not Applicable to what you picked."; }
                        string msg = "Item Workset is:  " + thisPickWS ;
                        thisDialog.MainInstruction = msg;
                        thisDialog.MainContent = "";
                        TaskDialogResult tResult = thisDialog.Show();

                        if (TaskDialogResult.Close == tResult)
                        {
                            stay = false;
                        }

                        if (TaskDialogResult.CommandLink1 == tResult)
                        {
                            trans.Start("WillChangeWorksetByPick");
                            wst = doc.GetWorksetTable();
                            itemWS = elem.WorksetId;
                            wst.SetActiveWorksetId(itemWS);
                            trans.Commit();
                            stay = false;
                        }

                        if (TaskDialogResult.CommandLink2 == tResult)
                        {
                            trans.Start("WillChangePickToCurrentWorkset");
                            Parameter wsparam = elem.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM);
                            wsparam.Set(wst.GetActiveWorksetId().IntegerValue);
                            trans.Commit();
                            stay = true;
                        }
                    }
                    return Result.Succeeded;
                }

                // handle the exception for right-clicks or presses Esc
                catch (Autodesk.Revit.Exceptions.OperationCanceledException)
                {
                    return Result.Failed;
                }
                //Catch other errors
                catch (Exception ex)
                {
                    TaskDialog.Show("Error", ex.Message);
                    return Result.Failed;
                }

            }
        }

        [Transaction(TransactionMode.Manual)]
        class CmdOpenWSPDoc : IExternalCommand {
            public Result Execute(ExternalCommandData commandData,
                                  ref string message,
                                  ElementSet elements) {

                string docsPath = "N:\\CAD\\BDS PRM 2016\\WTA Common\\Revit Resources\\WTAAddins\\SourceCode\\Docs";
                System.Diagnostics.Process.Start("explorer.exe", Path.Combine(docsPath, "WTA_WsP_Docs.pdf"));
                return Result.Succeeded;
            }
        }
}
