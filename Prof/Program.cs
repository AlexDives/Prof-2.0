using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace Prof
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hwnd, WinStyle style);

        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);


        enum WinStyle
        {
            Hide = 0,
            ShowNormal = 1,
            ShowMinimized = 2,
            ShowMaximized = 3
        }
        static Mutex mutex = new Mutex(false, "Prof");
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!mutex.WaitOne(500, false))
            {
                IntPtr wndHandle = FindWindowByCaption(IntPtr.Zero, "Профсоюз");
                ShowWindow(wndHandle, WinStyle.ShowMaximized);
                return;
            }
            Application.Run(new f_DBLogin());
        }
    }
}
