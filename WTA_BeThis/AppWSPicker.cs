
/// There is some interesting ribbon stuff here, but in the end it
/// is not practical to write to another existing tab.


//#region Namespaces
//using System;
//using System.IO;
//using System.Collections.Generic;
//using Autodesk.Revit.ApplicationServices;
//using Autodesk.Revit.Attributes;
//using Autodesk.Revit.DB;
//using Autodesk.Revit.UI;
//using System.Windows.Media.Imaging;
//#endregion

//namespace AAA_WTA_BeThis {
//    class AppWSPicker : IExternalApplication
   
//    {
//        public Result OnStartup(UIControlledApplication a) {
//            // Add ViewManager to WTA Ribbon
//            AddWSPickerTo_WTA_Ribbon(a);
//            return Result.Succeeded;
//        }

//        public Result OnShutdown(UIControlledApplication a) {
//            return Result.Succeeded;
//        }

//        public void AddWSPickerTo_WTA_Ribbon(UIControlledApplication a) {
//            string ExecutingAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
//            string ExecutingAssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
//            // create ribbon tab 
//            String thisWTATab = "WTA";
//            try {
//                a.CreateRibbonTab(thisWTATab);
//            } catch (Autodesk.Revit.Exceptions.ArgumentException) {
//                // Assume error generated is due to "WTA" already existing
//            }
//            /// At this point the WTA ribbon Tab exists. That is the target Tab
//            /// Now need to establish the Panel in this Tab
//            /// Add new ribbon panel or us existing. 
//            String thisBeThisPanelName = "Be This";
//            RibbonPanel thisBeThisRibbonPanel = null;
//            /// Get a list of the panels in the target Tab
//            List<RibbonPanel> existingRibbonPanels = a.GetRibbonPanels(thisWTATab);
//            foreach (RibbonPanel rb in existingRibbonPanels) {
//                //System.Windows.MessageBox.Show(rb.Name);
//                if (rb.Name.Equals(thisBeThisPanelName)) {
//                    thisBeThisRibbonPanel = rb;
//                    break;
//                }
//            }
//            /// if panel is null then we can safely create it
//            if (thisBeThisRibbonPanel == null) {
//                thisBeThisRibbonPanel = a.CreateRibbonPanel(thisWTATab, thisBeThisPanelName);
//            }
//            /// Now we have the panel

//            //IList<RibbonItem> ri = thisBeThisRibbonPanel.GetItems();
//            //foreach (RibbonItem rii in ri) {
//            //    System.Windows.MessageBox.Show(rii.Name);
//            //}

      
//    }
//}
