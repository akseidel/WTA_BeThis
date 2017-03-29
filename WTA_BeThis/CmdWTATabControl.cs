using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace AAA_WTA_BeThis {
    [Transaction(TransactionMode.Manual)]
    class CmdWTATabControl : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {

            WPF_WTATabControler WTATabControler = new WPF_WTATabControler(commandData);
            WTATabControler.ShowDialog();
            IntPtr revitHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            RevitStatusBarAide.SetStatusBarText(revitHandle, "Got it. Saved the WTA- tab visibility you indicated.");
            return Result.Succeeded;
        }
    }

}
