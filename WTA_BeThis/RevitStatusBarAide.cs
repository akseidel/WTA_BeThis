﻿using System;
using System.Runtime.InteropServices;

namespace AAA_WTA_BeThis {
    class RevitStatusBarAide {
        [DllImport("USER32.DLL")]
        public static extern bool PostMessage(
          IntPtr hWnd, uint msg, uint wParam, uint lParam);

        #region StatusBarText helpers
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int SetWindowText(
          IntPtr hWnd,
          string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(
          IntPtr hwndParent,
          IntPtr hwndChildAfter,
          string lpszClass,
          string lpszWindow);

        public static void SetStatusBarText(IntPtr mainWindow, string text) {
            IntPtr mainWindowHandle = IntPtr.Zero;
            IntPtr statusBar = FindWindowEx(mainWindow, IntPtr.Zero, "msctls_statusbar32", "");
            if (statusBar != IntPtr.Zero) {
                SetWindowText(statusBar, text);
            }
        }
        #endregion
    }
}
