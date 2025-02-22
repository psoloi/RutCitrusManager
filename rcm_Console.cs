using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace RutCitrusManager
{
    internal class rcm_Console
    {
        public static void TGui_OnlyMode_Settings()
        {
            #region 初始界面

            Application.Init();
            var menu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_Quit", "", () => {
                    Application.RequestStop ();
                })
            }),});

            var win = new Window("OnlyMode Settings")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 1
            };

            Application.Top.Add(menu, win);
            Application.Run();
            Application.Shutdown();

            #endregion
        }

        // Import the necessary functions from user32.dll and kernel32.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        const int SW_MAXIMIZE = 3;

        public static void Test()
        {
            // Get the handle of the console window
            IntPtr hWnd = GetConsoleWindow();
            // Maximize the console window
            ShowWindow(hWnd, SW_MAXIMIZE);
            Console.ReadKey();
        }
    }
}
