using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Windows;
using System.ComponentModel;


namespace AAA_WTA_BeThis {
    /// <summary>
    /// Interaction logic for WPF_WTATabControler.xaml
    /// </summary>
    public partial class WPF_WTATabControler : Window {
        Autodesk.Revit.UI.UIApplication uiapp ;
        Autodesk.Revit.UI.UIDocument uidoc;
        Autodesk.Revit.ApplicationServices.Application app;
        Autodesk.Revit.DB.Document doc ;
        List<wtaTabState> wtaTStates = new List<wtaTabState>();

        public WPF_WTATabControler(ExternalCommandData commandData) {
            InitializeComponent();
            uiapp = commandData.Application;
             uidoc = uiapp.ActiveUIDocument;
            app = uiapp.Application;
            doc = uidoc.Document;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            FillTabStateGrid();
        }
       
        private void FillTabStateGrid() {
            Autodesk.Windows.RibbonControl revitRibbon = Autodesk.Windows.ComponentManager.Ribbon;
            foreach (Autodesk.Windows.RibbonTab tab in revitRibbon.Tabs) {
                string tabName = tab.Title;
                //System.Windows.Forms.MessageBox.Show(tabName);
                if (tabName.Contains("WTA-")) {
                    wtaTabState wtaTabState = new wtaTabState();
                    wtaTabState.MyTabName = tabName;
                    wtaTabState.MyTabVisBool = tab.IsVisible;
                    wtaTStates.Add(wtaTabState);
                }
            }
            TabsControlGrid.ItemsSource = wtaTStates;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Autodesk.Windows.RibbonControl revitRibbon = Autodesk.Windows.ComponentManager.Ribbon;
            //string msg = string.Empty;
            foreach (wtaTabState wtaTabState in wtaTStates) {
                Autodesk.Windows.RibbonTab rRibTab = revitRibbon.FindTab(wtaTabState.MyTabName);
                rRibTab.IsVisible = wtaTabState.MyTabVisBool;
                SaveUserPref(wtaTabState); 
                //msg += wtaTabState.MyTabName + " " + wtaTabState.MyTabVisBool.ToString() + "\n";
            }
            //System.Windows.Forms.MessageBox.Show(msg);
            AAA_WTA_BeThis.Properties.Settings.Default.Save();
        }

        public void SaveUserPref(wtaTabState wtaTabState) {
            switch (wtaTabState.MyTabName) {
                case "WTA-ELEC":
                    AAA_WTA_BeThis.Properties.Settings.Default.WTA_ELEC = wtaTabState.MyTabVisBool;
                    break;
                case "WTA-TCOM":
                    AAA_WTA_BeThis.Properties.Settings.Default.WTA_TCOM = wtaTabState.MyTabVisBool;
                    break;
                case "WTA-FP":
                    AAA_WTA_BeThis.Properties.Settings.Default.WTA_FP = wtaTabState.MyTabVisBool;
                    break;
                case "WTA-MECH":
                    AAA_WTA_BeThis.Properties.Settings.Default.WTA_MECH = wtaTabState.MyTabVisBool;
                    break;
                case "WTA-PLMB":
                    AAA_WTA_BeThis.Properties.Settings.Default.WTA_PLMB = wtaTabState.MyTabVisBool;
                    break;
                default:
                    break;
            }
        }

        public void DragWindow(object sender, MouseButtonEventArgs args) {
            // Watch out. Fatal error if not primary button!
            if (args.LeftButton == MouseButtonState.Pressed) { DragMove(); }
        }

        private void Quit_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void BotLine_MouseEnter(object sender, MouseEventArgs e) {
            BotLine.FontWeight = FontWeights.SemiBold;
        }

        private void BotLine_MouseLeave(object sender, MouseEventArgs e) {
            BotLine.FontWeight = FontWeights.Normal;
        }

        private void BotLine_MouseDown(object sender, MouseButtonEventArgs e) {
            Close();
        }
}

    public class wtaTabState : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public string MyTabName { get; set; }
        public bool MyTabVisBool { get; set; }
    }
}
