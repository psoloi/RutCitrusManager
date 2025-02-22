using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutCitrusManager.Modules
{
    public class Output
    {
        static string c_info = "[white]|[/][green]INFO[/][white]| [/]";
        static string c_error = "[white]|[/][red]EROR[/][white]| [/]";
        static string c_warn = "[white]|[/][yellow]WARN[/][white]| [/]";
        static string c_info_cn = "[white]|[/][green]信息[/][white]| [/]";
        static string c_error_cn = "[white]|[/][red]错误[/][white]| [/]";
        static string c_warn_cn = "[white]|[/][yellow]警告[/][white]| [/]";

        // 为基础中文信息输出
        public static void Log(string msg, int msg_type)
        {
            string info = "[信息] ";
            string error = "[错误] ";
            string warn = "[警告] ";
            if (msg_type == 1)
            {
                Console.WriteLine(info + msg);
            }
            if (msg_type == 2)
            {
                Console.WriteLine(warn + msg);
            }
            if (msg_type == 3)
            {
                Console.WriteLine(error + msg);
            }
        }
        // 为基础颜色信息输出
        public static void LogColor(string msg, int msg_type)
        {
            string info = "[white][[[/][green]信息[/][white]]][/] ";
            string error = "[white][[[/][red]错误[/][white]]][/] ";
            string warn = "[white][[[/][yellow]警告[/][white]]][/] ";
            if (msg_type == 1)
            {
                AnsiConsole.Markup(info + msg + "\n");
            }
            if (msg_type == 2)
            {
                AnsiConsole.Markup(warn + msg + "\n");
            }
            if (msg_type == 3)
            {
                AnsiConsole.Markup(error + msg + "\n");
            }
        }
        // 类似Web控制台程序的输出
        public static void TextBit(string msg, int msg_type)
        {
            string info = "[green]info[/][white]:[/] ";
            string error = "[red]error[/][white]:[/] ";
            string warn = "[yellow]warn[/][white]:[/] ";
            if (msg_type == 1)
            {
                AnsiConsole.Markup(info + msg + "\n");
            }
            if (msg_type == 2)
            {
                AnsiConsole.Markup(warn + msg + "\n");
            }
            if (msg_type == 3)
            {
                AnsiConsole.Markup(error + msg + "\n");
            }
        }
        // 似方块的输出
        public static void TextBlock(string msg, int msg_type)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string info = $"[white on dodgerblue2]{time}[/]" + "[black on green]信息:[/] ";
            string error = $"[white on dodgerblue2]{time}[/]" + "[black on red]错误:[/] ";
            string warn = $"[white on dodgerblue2]{time}[/]" + "[black on gold1]警告:[/] ";
            if (msg_type == 1)
            {
                AnsiConsole.Markup(info + msg + "\n");
            }
            if (msg_type == 2)
            {
                AnsiConsole.Markup(warn + msg + "\n");
            }
            if (msg_type == 3)
            {
                AnsiConsole.Markup(error + msg + "\n");
            }
        }

        // 为基础的颜色信息输出
        public static void Text(string msg, int msg_type)
        {
            if (msg_type == 1)
            {
                AnsiConsole.Markup(c_info + msg + "\n");
            }
            if (msg_type == 2)
            {
                AnsiConsole.Markup(c_warn + msg + "\n");
            }
            if (msg_type == 3)
            {
                AnsiConsole.Markup(c_error + msg + "\n");
            }
        }
        // 为基础的中文颜色信息输出
        public static void TextCN(string msg, int msg_type)
        {
            if (msg_type == 1)
            {
                AnsiConsole.Markup(c_info_cn + msg + "\n");
            }
            if (msg_type == 2)
            {
                AnsiConsole.Markup(c_warn_cn + msg + "\n");
            }
            if (msg_type == 3)
            {
                AnsiConsole.Markup(c_error_cn + msg + "\n");
            }
        }
        // 为信息和时间的输出 格式(时;分;秒)
        public static void Text_Time(string msg, int msg_type)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            if (msg_type == 1)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_info + msg + "\n");
            }
            if (msg_type == 2)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_warn + msg + "\n");
            }
            if (msg_type == 3)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_error + msg + "\n");
            }
        }
        // 为信息和时间的输出 格式(年;月;日 时;分;秒)
        public static void Text_AllTime(string msg, int msg_type)
        {
            string time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (msg_type == 1)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_info + msg + "\n");
            }
            if (msg_type == 2)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_warn + msg + "\n");
            }
            if (msg_type == 3)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_error + msg + "\n");
            }
        }
        // 为信息和时间的中文输出 格式(时;分;秒)
        public static void TextCN_Time(string msg, int msg_type)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            if (msg_type == 1)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_info_cn + msg + "\n");
            }
            if (msg_type == 2)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_warn_cn + msg + "\n");
            }
            if (msg_type == 3)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_error_cn + msg + "\n");
            }
        }
        // 为信息和时间的中文输出 格式(年;月;日 时;分;秒)
        public static void TextCN_AllTime(string msg, int msg_type)
        {
            string time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (msg_type == 1)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_info_cn + msg + "\n");
            }
            if (msg_type == 2)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_warn_cn + msg + "\n");
            }
            if (msg_type == 3)
            {
                AnsiConsole.Markup($"[white]{time}[/] " + c_error_cn + msg + "\n");
            }
        }
    }
}
