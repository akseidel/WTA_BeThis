using System;
using System.Windows;
using System.Windows.Threading;

namespace AAA_WTA_BeThis {
    /// <summary>
    /// Interaction logic for FormMsg.xaml
    /// </summary>
    public partial class FormMsgWPF : Window {
        DispatcherTimer timeOut = new DispatcherTimer();
        string thisUsersInitials;
        IntPtr _revitHandle;

        public FormMsgWPF(IntPtr revitHandle) {
            InitializeComponent();
            _revitHandle = revitHandle;
            thisUsersInitials = Environment.UserName.ToString();
        }
        public void SetMsg(string _msg) {
            MsgTextBlockMainMsg.Text = _msg;
            UserName.Text = thisUsersInitials;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            WindowStyle = WindowStyle.None;
            timeOut.Tick += new EventHandler(timeOut_Tick);
            timeOut.Interval = new TimeSpan(0, 0, 1);
            timeOut.Start();
            RevitStatusBarAide.SetStatusBarText(_revitHandle, "Hello " + thisUsersInitials);
        }
        private void timeOut_Tick(object sender, EventArgs e) {
            timeOut.Stop();
            Close();
        }
     
        /// <summary>
        /// Used to convert system drawing colors to WPF brush
        /// </summary>
        public static class ColorExt {
            public static System.Windows.Media.Brush ToBrush(System.Drawing.Color color) {
                return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
            }
        }
    }
}
