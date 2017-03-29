#region Namespaces
using System;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace AAA_WTA_BeThis {

    [Transaction(TransactionMode.Manual)]
    class CmdBeNADAWorkSet : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {
            AAA_WTA_BeThis.Properties.Settings.Default.PreferedWS = "";
            AAA_WTA_BeThis.Properties.Settings.Default.Save();
            IntPtr revitHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            RevitStatusBarAide.SetStatusBarText(revitHandle, "Got it. There is no Prefered workset now.");
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class CmdBeMECH_HVACWorkSet : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {

            string _wsName = "MECH HVAC";
            HelperA beThis = new HelperA();
            beThis.BeWorkset(_wsName, commandData);
            AAA_WTA_BeThis.Properties.Settings.Default.PreferedWS = _wsName;
            AAA_WTA_BeThis.Properties.Settings.Default.Save();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class CmdBeLightingWorkSet : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {

            string _wsName = "ELEC LIGHTING";
            HelperA beThis = new HelperA();
            beThis.BeWorkset(_wsName, commandData);
            AAA_WTA_BeThis.Properties.Settings.Default.PreferedWS = _wsName;
            AAA_WTA_BeThis.Properties.Settings.Default.Save();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class CmdBeAuxiliaryWorkSet : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {

            string _wsName = "ELEC AUXILIARY";
            HelperA beThis = new HelperA();
            beThis.BeWorkset(_wsName, commandData);
            AAA_WTA_BeThis.Properties.Settings.Default.PreferedWS = _wsName;
            AAA_WTA_BeThis.Properties.Settings.Default.Save();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class CmdBePowerWorkSet : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {

            string _wsName = "ELEC POWER";
            HelperA beThis = new HelperA();
            beThis.BeWorkset(_wsName, commandData);
            AAA_WTA_BeThis.Properties.Settings.Default.PreferedWS = _wsName;
            AAA_WTA_BeThis.Properties.Settings.Default.Save();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class CmdBeTComWorkSet : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {


            string _wsName = "TCOM";
            HelperA beThis = new HelperA();
            beThis.BeWorkset(_wsName, commandData);
            AAA_WTA_BeThis.Properties.Settings.Default.PreferedWS = _wsName;
            AAA_WTA_BeThis.Properties.Settings.Default.Save();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class CmdBeTComEnlargedPlanWorkSet : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {

            string _wsName = "TCOM ENLARGED PLAN";
            HelperA beThis = new HelperA();
            beThis.BeWorkset(_wsName, commandData);
            AAA_WTA_BeThis.Properties.Settings.Default.PreferedWS = _wsName;
            AAA_WTA_BeThis.Properties.Settings.Default.Save();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class CmdBeTComSiteWorkSet : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {

            string _wsName = "TCOM SITE";
            HelperA beThis = new HelperA();
            beThis.BeWorkset(_wsName, commandData);
            AAA_WTA_BeThis.Properties.Settings.Default.PreferedWS = _wsName;
            AAA_WTA_BeThis.Properties.Settings.Default.Save();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class CmdBePlumbingWorkSet : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {

            string _wsName = "PLUMBING";
            HelperA beThis = new HelperA();
            beThis.BeWorkset(_wsName, commandData);
            AAA_WTA_BeThis.Properties.Settings.Default.PreferedWS = _wsName;
            AAA_WTA_BeThis.Properties.Settings.Default.Save();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    class CmdBeFirePWorkSet : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {

            string _wsName = "FIRE PROTECTION";
            HelperA beThis = new HelperA();
            beThis.BeWorkset(_wsName, commandData);
            AAA_WTA_BeThis.Properties.Settings.Default.PreferedWS = _wsName;
            AAA_WTA_BeThis.Properties.Settings.Default.Save();
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
     class CmdOpenBeThisDoc : IExternalCommand {
        public Result Execute(ExternalCommandData commandData,
                              ref string message,
                              ElementSet elements) {

            string docFile = System.IO.Path.Combine(AppWTABeThis._app.docsPath, "WTA_BeThis_Docs.pdf");
            if (System.IO.File.Exists(docFile)) {
                System.Diagnostics.Process.Start("explorer.exe", docFile);
            } else {
                System.Diagnostics.Process.Start("explorer.exe", AppWTABeThis._app.docsPath);
            }
            return Result.Succeeded;
        }
    }

    class HelperA {
        public void BeWorkset(string _wsName, ExternalCommandData commandData) {
            UIApplication _uiapp = commandData.Application;
            UIDocument _uidoc = _uiapp.ActiveUIDocument;
            Autodesk.Revit.ApplicationServices.Application _app = _uiapp.Application;
            Autodesk.Revit.DB.Document _doc = _uidoc.Document;
            IntPtr revitHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            if (_doc.IsWorkshared) {
                WorksetTable wst = _doc.GetWorksetTable();
                WorksetId wsID = MiscUtils.WhatIsThisWorkSetIDByName(_wsName, _doc);
                if (wsID != null) {
                    using (Transaction trans = new Transaction(_doc, "WillChangeWorkset")) {
                        trans.Start();
                        wst.SetActiveWorksetId(wsID);
                        trans.Commit();
                        RevitStatusBarAide.SetStatusBarText(revitHandle, "Active and Prefered workset will be " + _wsName);
                    }
                } else {
                    System.Windows.Forms.MessageBox.Show("Sorry but there is no workset " + _wsName + " to switch to.",
                        "Trouble Ahead, Trouble Behind",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                    RevitStatusBarAide.SetStatusBarText(revitHandle, "No can do! Workset " + _wsName + " is not defined in this project.");
                }
            } else {
                RevitStatusBarAide.SetStatusBarText(revitHandle, "Prefered workset is " + _wsName + " , but its not active here. Worksets do not exist in a non-shared revit file.");
            }
        }
        public void BeWorksetDoc(string _wsName, Autodesk.Revit.DB.Document _doc, out bool _notSet) {
            _notSet = true;
            if (_doc.IsWorkshared) {
                WorksetTable wst = _doc.GetWorksetTable();
                WorksetId wsID = MiscUtils.WhatIsThisWorkSetIDByName(_wsName, _doc);
                IntPtr revitHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
                if (wsID != null) {
                    using (Transaction trans = new Transaction(_doc, "WillChangeWorkset")) {
                        trans.Start();
                        wst.SetActiveWorksetId(wsID);
                        trans.Commit();
                        _notSet = false;
                        RevitStatusBarAide.SetStatusBarText(revitHandle, "Active workset will be " + _wsName);
                    }
                } else {
                    _notSet = true;
                    System.Windows.Forms.MessageBox.Show("Sorry but there is no workset " + _wsName + " to switch to.",
                        "Trouble Ahead, Trouble Behind",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
            }
        }

    }

}
