using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutCitrusManager.Modules
{
    internal class Reload
    {
        public static void Rest()
        {
            try
            {
                Console.Clear();
                System.Reflection.Assembly.GetEntryAssembly();
                string startpath = Directory.GetCurrentDirectory();
                System.Diagnostics.Process.Start(startpath + "\\RutCitrusManager.exe");
            }
            catch (Exception ex)
            {
                Output.Text_Time("出现错误： ", 3);
                AnsiConsole.WriteException(ex);
            }
        }
    }
}
