#region Namespaces
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
#endregion

namespace AAA_WTA_BeThis {
    class AppWTABeThis : IExternalApplication {
        static string _path = typeof(Application).Assembly.Location;
        SplitButton sbOffSet; /// Singleton external application class instance.
        internal static AppWTABeThis _app = null;
        public string docsPath = "N:\\CAD\\BDS PRM 2016\\WTA Common\\Revit Resources\\WTAAddins\\SourceCode\\Docs";
        /// Provide access to singleton class instance.
        public static AppWTABeThis Instance {
            get { return _app; }
        }

        ///// Provide access to the radio button state
        //internal static string _pb_state = String.Empty;
        //public static string PB_STATE {
        //    get { return _pb_state; }
        //}
        ///// Provide access to the offset state
        //internal static XYZ _pOffSet = new XYZ(1, 1, 0);
        //public static XYZ POFFSET {
        //    get { return _pOffSet; }
        //}

        public Result OnStartup(UIControlledApplication a) {
            _app = this;
            AddBeThisTo_WTA_Ribbon(a);

            /// Subscribe to doc open event so that a user set default workset can be set
            a.ControlledApplication.DocumentOpened += new EventHandler<DocumentOpenedEventArgs>(a_DocumentOpened);
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a) {
            a.ControlledApplication.DocumentOpened -= new EventHandler<DocumentOpenedEventArgs>(a_DocumentOpened);
            return Result.Succeeded;
        }

        public void AddBeThisTo_WTA_Ribbon(UIControlledApplication a) {
            string ExecutingAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string ExecutingAssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            // create ribbon tab 
            String thisTabNameWTA = "WTA";
            try {
                a.CreateRibbonTab(thisTabNameWTA);
            } catch (Autodesk.Revit.Exceptions.ArgumentException) {
                // Assume error generated is due to "WTA" already existing
            }

            String thisPanelNamBe = "Be This";
            RibbonPanel thisRibbonPanelBe = a.CreateRibbonPanel(thisTabNameWTA, thisPanelNamBe);

            #region EntireSplitButtonSection
            PushButtonData bNADA = new PushButtonData("NADA", "NADA", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdBeNADAWorkSet");
            PushButtonData bMMVAC = new PushButtonData("MECH HVAC", "HVAC", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdBeMECH_HVACWorkSet");
            PushButtonData bEPWR = new PushButtonData("ELEC POWER", "E Power", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdBePowerWorkSet");
            PushButtonData bEL = new PushButtonData("ELEC LIGHTING", "E Lighting", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdBeLightingWorkSet");
            PushButtonData bEAUX = new PushButtonData("ELEC AUXILIARY", "Auxiliary", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdBeAuxiliaryWorkSet");
            PushButtonData bTCOM = new PushButtonData("TCOM", "TCOM", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdBeTComWorkSet");
            PushButtonData bTCOMEN = new PushButtonData("TCOM ENLARGED", "TCOM Enlarged", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdBeTComEnlargedPlanWorkSet");
            PushButtonData bTCOMSite = new PushButtonData("TCOM SITE", "TCOM Site", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdBeTComSiteWorkSet");
            PushButtonData bPLMB = new PushButtonData("PLUMBING", "Plumbing", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdBePlumbingWorkSet");
            PushButtonData bFireP = new PushButtonData("FIRE PROTECTION", "Fire Protection", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdBeFirePWorkSet");

            bNADA.LargeImage = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".BeThis.PNG");
            bMMVAC.LargeImage = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".BeThisHVAC.PNG");
            bEPWR.LargeImage = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".BeThisEPWR.PNG");
            bEL.LargeImage = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".BeThisEL.PNG");
            bEAUX.LargeImage = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".BeThisEAUX.PNG");
            bTCOM.LargeImage = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".BeThisTCOM.PNG");
            bTCOMEN.LargeImage = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".BeThisTCOMEN.PNG");
            bTCOMSite.LargeImage = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".BeThisTCOMSite.PNG");
            bPLMB.LargeImage = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".BeThisPLMB.PNG");
            bFireP.LargeImage = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".BeThisFP.PNG");

            bNADA.ToolTip = "Removes user prefered workset.";
            string msg = "Sets the workset and also sets a user prefered workset.";
            bMMVAC.ToolTip = msg;
            bEPWR.ToolTip = msg;
            bEL.ToolTip = msg;
            bEAUX.ToolTip = msg;
            bTCOM.ToolTip = msg;
            bTCOMEN.ToolTip = msg;
            bTCOMSite.ToolTip = msg;
            bPLMB.ToolTip = msg;
            bFireP.ToolTip = msg;


            SplitButtonData sbOffSetData = new SplitButtonData("splitOffSets", "Loc");
            //SplitButton sbOffSet = thisRibbonPanelBe.AddItem(sbOffSetData) as SplitButton;
            sbOffSet = thisRibbonPanelBe.AddItem(sbOffSetData) as SplitButton;
            sbOffSet.AddPushButton(bNADA);
            sbOffSet.AddPushButton(bMMVAC);
            sbOffSet.AddPushButton(bEPWR);
            sbOffSet.AddPushButton(bEL);
            sbOffSet.AddPushButton(bEAUX);
            sbOffSet.AddPushButton(bTCOM);
            sbOffSet.AddPushButton(bTCOMEN);
            sbOffSet.AddPushButton(bTCOMSite);
            sbOffSet.AddPushButton(bPLMB);
            sbOffSet.AddPushButton(bFireP);
            #endregion

            #region WsP Button
            /// Create a push button in the ribbon panel 
            /// WSPicker.RequiresRevit2015.WorksetByPick
            PushButtonData pbWsPData = new PushButtonData("WsP?", "WsP?", ExecutingAssemblyPath, ExecutingAssemblyName + ".WorksetByPick");
            /// add button to ribbon panel
            PushButton pushButtonWsP = thisRibbonPanelBe.AddItem(pbWsPData) as PushButton;
            /// Set the large image shown on button
            /// Note that the full image name is namespace_prefix + "." + the actual imageName);
            pushButtonWsP.LargeImage = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".WsP.png");
            // provide button tips
            pushButtonWsP.ToolTip = "WS Picker";
            msg = "WsP-O-Matic";
            pushButtonWsP.LongDescription = msg;
            #endregion

            #region BottomSlideOutSection
            /// Once there is a slideout, all new items go in it.
            /// It is not possbile to get back to the panel panel. 
            thisRibbonPanelBe.AddSlideOut();
            ///
            #region BeThis Info
            PushButtonData bInfoBe = new PushButtonData("InfoBe", "Info BeThis", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdOpenBeThisDoc");
            bInfoBe.ToolTip = "See the help document regarding BeThis.";
            bInfoBe.Image = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".InfoSm.png");
            #endregion

            #region WspInfo
            PushButtonData bInfoWsp = new PushButtonData("InfoWs", "Info WSP", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdOpenWSPDoc");
            bInfoWsp.ToolTip = "See the help document regarding the Workset picker.";
            bInfoWsp.Image = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".InfoSm.png");
            #endregion

            PushButtonData pbWsPMakeMat = new PushButtonData("WSMkr", "WS Make-O-Matic", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdWSMakeOMatic");
            pbWsPMakeMat.Image = NewBitmapImage(System.Reflection.Assembly.GetExecutingAssembly(), ExecutingAssemblyName + ".WsPSm.png");
            pbWsPMakeMat.ToolTip = "Workset Make-O-Matic creates WTA Worksets in their standardized form.";
            msg = "I can telll you want to parrrty harrrdy.";
            pbWsPMakeMat.LongDescription = msg;

            PushButtonData pbWTATabCntl = new PushButtonData("WTATab", "WTA Tabs", ExecutingAssemblyPath, ExecutingAssemblyName + ".CmdWTATabControl");
            pbWTATabCntl.ToolTip = "Control the WTA- tab visibilty.";
            msg = "Now you see it, now you do not see it.";
            pbWTATabCntl.LongDescription = msg;


            List<RibbonItem> slideOutPanelButtons = new List<RibbonItem>();
            slideOutPanelButtons.AddRange(thisRibbonPanelBe.AddStackedItems(bInfoBe, bInfoWsp));
            slideOutPanelButtons.AddRange(thisRibbonPanelBe.AddStackedItems(pbWTATabCntl, pbWsPMakeMat));
            #endregion

        } // end AddBeThisTo_WTA_Ribbon

        /// <summary>
        /// Load a new icon bitmap from embedded resources.
        /// For the BitmapImage, make sure you reference WindowsBase
        /// and PresentationCore, and import the System.Windows.Media.Imaging namespace. 
        /// </summary>
        BitmapImage NewBitmapImage(System.Reflection.Assembly a, string imageName) {
            Stream s = a.GetManifestResourceStream(imageName);
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.StreamSource = s;
            img.EndInit();
            return img;
        }

        /// <summary>
        /// some call back event examples
        /// </summary>
        ////public void SetAs_STD() {
        ////    _pb_state = "STD";
        ////    //System.Windows.MessageBox.Show(_pb_state,"_pb_state was set to");
        ////}
        ////public void SetAs_EC() {
        ////    _pb_state = "EC";
        ////    //System.Windows.MessageBox.Show(_pb_state, "_pb_state was set to");
        ////}

        // used for testing
        PushButton SplitButtonForName(string _Name) {
            IList<PushButton> sbList = sbOffSet.GetItems();
            foreach (PushButton pb in sbList) {
                if (pb.Name.Equals(_Name)) {
                    return pb;
                }
            }
            return sbList[0];
        }

        void a_DocumentOpened(object sender, DocumentOpenedEventArgs e) {
            string _wsName = AAA_WTA_BeThis.Properties.Settings.Default.PreferedWS;
            bool _notSet;
            if (_wsName != "") {
                HelperA beThis = new HelperA();
                // get document from event args.
                Document doc = e.Document;
                if (doc.IsWorkshared) {
                    beThis.BeWorksetDoc(_wsName, doc, out _notSet);
                    IntPtr revitHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
                    FormMsgWPF WsMsg = new FormMsgWPF(revitHandle);
                    if (_notSet) {
                        WsMsg.SetMsg("No workset " + _wsName + " to be set active.");
                    } else {
                        WsMsg.SetMsg(_wsName + "  is active.");
                    }
                    WsMsg.Show();
                }
                IList<PushButton> sbList = sbOffSet.GetItems();
                foreach (PushButton pb in sbList) {
                    if (pb.Name.Equals(_wsName)) {
                        sbOffSet.CurrentButton = pb;
                        break;
                    }
                }
            } else {
                IList<PushButton> sbList = sbOffSet.GetItems();
                sbOffSet.CurrentButton = sbList[0];
            }

            Autodesk.Windows.RibbonControl revitRibbon = Autodesk.Windows.ComponentManager.Ribbon;
            Autodesk.Windows.RibbonTab rRibTab;
            if (revitRibbon != null) {
                bool WTA_ELEC = AAA_WTA_BeThis.Properties.Settings.Default.WTA_ELEC;
                bool WTA_TCOM = AAA_WTA_BeThis.Properties.Settings.Default.WTA_TCOM;
                bool WTA_MECH = AAA_WTA_BeThis.Properties.Settings.Default.WTA_MECH;
                bool WTA_PLMB = AAA_WTA_BeThis.Properties.Settings.Default.WTA_PLMB;
                bool WTA_FP = AAA_WTA_BeThis.Properties.Settings.Default.WTA_FP;

                if (WTA_ELEC != null) {
                    rRibTab = revitRibbon.FindTab("WTA-ELEC");
                    if (rRibTab != null) {
                        rRibTab.IsVisible = WTA_ELEC;
                    }
                }
                if (WTA_TCOM != null) {
                    rRibTab = revitRibbon.FindTab("WTA-TCOM");
                    if (rRibTab != null) {
                        rRibTab.IsVisible = WTA_TCOM;
                    }
                }
                if (WTA_MECH != null) {
                    rRibTab = revitRibbon.FindTab("WTA-MECH");
                    if (rRibTab != null) {
                        rRibTab.IsVisible = WTA_MECH;
                    }
                }
                if (WTA_PLMB != null) {
                    rRibTab = revitRibbon.FindTab("WTA-PLMB");
                    if (rRibTab != null) {
                        rRibTab.IsVisible = WTA_PLMB;
                    }
                }
                if (WTA_FP != null) {
                    rRibTab = revitRibbon.FindTab("WTA-FP");
                    if (rRibTab != null) {
                        rRibTab.IsVisible = WTA_FP;
                    }
                }

            }
        }
    }
}

