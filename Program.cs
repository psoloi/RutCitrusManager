using RutCitrusManager.Modules;
using Spectre.Console;
using System.Diagnostics;
using System.Reflection;
using YamlDotNet.Serialization;
using static RutCitrusManager.Program;

namespace RutCitrusManager
{
    internal class Program
    {

        public class UISettings
        {
            public double rcmWindowPercent { get; set; }
        }

        static void Main(string[] args)
        {

            #region 基础设置

            Console.Title = "RutCitrusManager";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 用户设置控制台窗口大小
            var filePath = "UI_Settings.yaml";
            double windowPercent = 0.75;

            if (File.Exists(filePath))
            {
                try
                {
                    var fileContent = File.ReadAllText(filePath);
                    var deserializer = new DeserializerBuilder().Build();
                    var uiSettings = deserializer.Deserialize<UISettings>(fileContent);

                    if (uiSettings.rcmWindowPercent >= 0.2 && uiSettings.rcmWindowPercent <= 1.0)
                    {
                        windowPercent = uiSettings.rcmWindowPercent;
                    }
                    else
                    {
                        Output.Text("[yellow]UI_Settings配置文件中rcmWindowPercent项不属于范围值[/]", 2);
                    }
                }
                catch (Exception ex)
                {
                    Output.Text("[red]读取或解析UI_Settings配置文件时发生错误:[/]", 3);
                    AnsiConsole.WriteException(ex);
                }
            }
            else
            {
                // 使用默认值0.75
            }

            // 获取屏幕大小
            int screenWidth = GetScreenWidth();
            int screenHeight = GetScreenHeight();

            // 设置窗口大小为屏幕大小的百分比
            int windowWidth = (int)(screenWidth * windowPercent);
            int windowHeight = (int)(screenHeight * windowPercent);
            Console.SetWindowSize(windowWidth, windowHeight);
            

            #endregion

            // 计时器

            Output.Text("[white]Loading RutCitrusManager...[/]", 1);

            // FigletText
            var figletText = new FigletText("RutCitrusManager")
                .Centered() // 居中对齐
                .Color(Color.LightGreen);
            AnsiConsole.Write(figletText);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Output.Text("[white]RutCitrusSDK - Made by psoloi[/]", 1);

            // 加载一些步骤

            #region 运行检查

            Checker.CheckFile();
            Checker.CheckWindowsVersion();
            Checker.CheckVM();


            #endregion

            #region 加载扩展

            Output.Text_Time("[yellow]加载扩展(扩展包含插件、Shell与Python、预设配置文件、可执行程序)... [[当前扩展功能关闭]] [/]", 2);


            #endregion

            // 计时器完成
            stopwatch.Stop();
            Output.Text_Time($"[white]RutCitrusManager Loaded in[/] [green]{stopwatch.ElapsedMilliseconds}[/] [white]ms[/]", 1);

            #region 运行模式选择

            Output.Text("[white]按下 [[Enter]] 显示功能菜单,按下 [[ESC]] 程序完全退出,按下 [[TAB]] 程序重载.[/]", 1);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Output.Text("[white]显示功能菜单(zhcn)[/]", 1);
                // 显示功能菜单
                FunctionMenu();
            }
            if (keyInfo.Key == ConsoleKey.F1)
            {
                Console.Clear();
                Output.Text("[white]打开OnlyMode设置[/]", 1);
                // 打开OnlyMode设置
                rcm_Console.TGui_OnlyMode_Settings();
            }
            if (keyInfo.Key == ConsoleKey.Spacebar)
            {
                Console.Clear();
                Output.Text("[white]打开特殊Test工具包[/]", 1);
                // Test
                rcm_Console.Test();
            }
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Output.Text("[white]程序完全退出...[/]", 1);
                Environment.Exit(0);
            }
            if (keyInfo.Key == ConsoleKey.Tab)
            {
                Console.Clear();
                Output.Text("[white]程序重新加载...[/]", 1);
                Reload.Rest();
            }
            else
            {
                Output.Text("[white]程序退出或重载...[/]", 1);
                return;
            }

            #endregion
        }


        public static void FunctionMenu()
        {
            // 功能菜单
            var table = new Table();
            table.AddColumn("[grey]编号[/]");
            table.AddColumn("[grey]模块[/]");
            table.AddColumn(new TableColumn("[grey]描述[/]").Centered());

            table.AddRow("1", "[white]功能设定[/]", "");
            table.AddRow("2", "[green]快速部署[/]", "");
            table.AddRow("3", "[blue]专家工具[/]", "");
            table.AddRow("4", "[white]网页部署[/]", "");
            table.AddRow("5", "[yellow]程序升级[/]", "");
            table.AddRow("6", "[white]程序信息[/]", "");
            table.AddRow("7", "[white]极域管理[/]", "附加功能");

            AnsiConsole.Write(table);
            Console.WriteLine("输入模块编号或(EPid)或命令:");
            string? selInput = null;
            selInput = Console.ReadLine();
            // 选择模块输入
            if (string.IsNullOrEmpty(selInput))
            {
                Output.Text("[yellow]不存在的模块！[/]", 2);
                return;
            }

            var actions = new Dictionary<string, Action>
            {
                { "1", () => { } },
                { "2", () => { /* Add functionality for option 2 */ } },
                { "3", () => { /* Add functionality for option 3 */ } },
                { "4", () => { /* Add functionality for option 4 */ } },
                { "5", () => { /* Add functionality for option 5 */ } },
                { "6", () =>
                    {
                        Console.Clear();
                        Output.Text_Time("[white]RCM 程序信息[/]", 1);
                        Output.Text("[white]版本: 2.0.2 作者: psoloi[/]", 1);
                        AnsiConsole.Markup("[white][[[/][green]所有程序版本[/][white]]] [/]"+"[white on blue]RCM|2.0.2  RCAPI|1.0  RCEditor|1.0  RCWeb|1.0.1  RCWebAssembly|1.0  RCSetup|1.0.5 [/] [white on blueviolet].NET(Core)|8.0[/]\n");

                        // 获取系统位数
                        bool is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
                        bool is64BitProcess = Environment.Is64BitProcess;

                        Console.WriteLine("操作系统位数: " + (is64BitOperatingSystem ? "64位" : "32位"));
                        Console.WriteLine("当前进程位数: " + (is64BitProcess ? "64位" : "32位"));

                        // 获取系统信息
                        string osVersion = Environment.OSVersion.VersionString;
                        string machineName = Environment.MachineName;
                        string frameworkDescription = Environment.Version.ToString();

                        Console.WriteLine("操作系统版本: " + osVersion);
                        Console.WriteLine("当前 .NET 版本: " + frameworkDescription);

                        Console.WriteLine("语音结构: \n");
                        AnsiConsole.Write(new BreakdownChart()
                            .Width(100)
                            .AddItem("C#", 80, Color.Green)
                            .AddItem("Python", 10, Color.Blue)
                            .AddItem("Shell", 6, Color.Aqua)
                            .AddItem("HTML", 3, Color.Red)
                            .AddItem("Other", 1, Color.Grey));

                        Console.WriteLine(" \n");
                        GetInfo();
                    }
                },
                { "7", () => { } }
            };

            if (actions.ContainsKey(selInput))
            {
                actions[selInput].Invoke();
            }
            else
            {
                Output.Text("[yellow]不存在的模块！[/]", 2);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Reload.Rest();
            }
        }


        static int GetScreenWidth()
        {
            return Console.LargestWindowWidth;
        }

        static int GetScreenHeight()
        {
            return Console.LargestWindowHeight;
        }

        public static void GetInfo()
        {
            Console.WriteLine("核心文件目录状态: \n");
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            List<string> fileNames = new List<string>
            {
                "RutCitrusManager.exe",
                "none2.txt",
                "none3.txt"
            };

            foreach (string fileName in fileNames)
            {
                string filePath = Path.Combine(baseDirectory, fileName);
                if (File.Exists(filePath))
                {
                    AnsiConsole.Markup("[[[green]存在[/]]]" + filePath + "\n");
                }
                else
                {
                    AnsiConsole.Markup("[[[red]不存在[/]]]" + filePath + "\n");
                }
            }
        }

        public static void RunCommand(string command)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {command}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process process = new Process
            {
                StartInfo = startInfo
            };
            process.Start();
            process.WaitForExit();
        }
    }
}
