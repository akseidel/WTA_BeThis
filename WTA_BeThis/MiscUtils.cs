using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace AAA_WTA_BeThis {
    class MiscUtils {
        public static WorksetId WhatIsThisWorkSetIDByName(string wsName, Document doc) {
            if (wsName == null) {
                return null;
            }
            // Find all user worksets 
            FilteredWorksetCollector worksets = new FilteredWorksetCollector(doc).OfKind(WorksetKind.UserWorkset);
            foreach (Workset ws in worksets) {
                if (wsName == ws.Name) {
                    return ws.Id;
                }
            }
            return null;
        }

        public static void SayMsg(string _title, string _msg) {
            TaskDialog thisDialog = new TaskDialog(_title);
            thisDialog.TitleAutoPrefix = false;
            thisDialog.MainIcon = TaskDialogIcon.TaskDialogIconWarning;
            thisDialog.MainInstruction = _msg;
            thisDialog.MainContent = "";
            TaskDialogResult tResult = thisDialog.Show();
        }
    }
}
