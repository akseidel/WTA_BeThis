#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace AAA_WTA_BeThis {
    [Transaction(TransactionMode.Manual)]
    public class CmdWSMakeOMatic : IExternalCommand {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements) {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            WorksetMakeOMatic thisWrkSetOMatic = new WorksetMakeOMatic(uidoc);
            thisWrkSetOMatic.ShowDialog();
            return Result.Succeeded;
        }
    }
}
