
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Linq;
using System.Text;



namespace AAA_WTA_BeThis
{
    class RevitHelpers
    {
        public void ShowBasicLinkInfo(Element elem, Document doc)
        {
            string s = "You Picked: " + "\n" + "\n";
            s += "Class = " + elem.GetType().Name + "\n";
            s += "Category = " + elem.Category.Name + "\n";
            s += "Workset = " + WhatWorksetNameIsThis(elem.WorksetId, doc) + "\n" + "\n";

            if (elem.IsMonitoringLinkElement())
            {
                s += "Link:" + "\n";
                IList<ElementId> linkIds = elem.GetMonitoredLinkElementIds();
                s += ((RevitLinkInstance)doc.GetElement(linkIds[0])).Name + "\n";
            }
            else
            {
                s += "Element monitors nothing." + "\n";
            }
            s += "\n";
            TaskDialog thisMsgDialog = new TaskDialog("Linked Element Info");
            thisMsgDialog.TitleAutoPrefix = false;
            thisMsgDialog.MainContent = s;
            thisMsgDialog.MainInstruction = "Linked Element Info";
            TaskDialogResult tResult = thisMsgDialog.Show();
        }

        // Returns the workset name for the workset id thiswid
        public string WhatWorksetNameIsThis(WorksetId thiswid, Document doc)
        {
            if (thiswid == null)
            {
                return String.Empty;
            }
            // Find all user worksets 
            FilteredWorksetCollector worksets
                = new FilteredWorksetCollector(doc)
                .OfKind(WorksetKind.UserWorkset);
            foreach (Workset ws in worksets)
            {
                if (thiswid == ws.Id)
                {
                    return ws.Name.ToString();
                }
            }
            return String.Empty;
        }

    }
}
