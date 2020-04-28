using mHosts.Net.entities;
using mHosts.Net.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace mHosts.Net
{
    static class Program
    {
        private enum ProcessDpiAwareness
        {
            DPI_UNAWARE = 0,
            SYSTEM_DPI_AWARE = 1,
            PER_MONITOR_DPI_AWARE = 2
        }
        [DllImport("SHCore.dll", SetLastError = true)]
        private static extern bool SetProcessDpiAwareness(ProcessDpiAwareness awareness);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetProcessDpiAwareness(ProcessDpiAwareness.PER_MONITOR_DPI_AWARE);
            #if DEBUG
            var singleInstanceKey = Resources.DebugSingleInstanceKey;
            #else
            var singleInstanceKey = Resources.SingleInstanceKey;
            #endif
            
            // 尝试创建一个命名事件
            var eventWaitHandle = new EventWaitHandle(false, EventResetMode.AutoReset, singleInstanceKey, out var noInstanceNow);
            if (!noInstanceNow)
            {
                MessageBox.Show(@"当前应用有在运行中，无需重复打开", @"应用已在运行", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new MainForm());
        }

        public static void InitSettings()
        {
            if (Settings.Default.hosts == null)
            {
                InitHost();
            }

            if (Settings.Default.tools == null)
            {
                InitTools();
            }
            
        }

        private static void InitHost()
        {
            //Settings.Default.hosts = new List<Host>
            //{
            //    new Host
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Name = "公共",
            //        Active = true,
            //        AlwaysApply = true,
            //        Content = "# 公共\n",
            //        LastUpdateTime = DateTime.Now,
            //        ReadOnly = false,
            //        Url = null
            //    },
            //    new Host
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Name = "开发环境",
            //        Active = false,
            //        AlwaysApply = false,
            //        Content = "# 开发环境\n",
            //        LastUpdateTime = DateTime.Now,
            //        ReadOnly = false,
            //        Url = null
            //    },
            //    new Host
            //    {
            //        Id = Guid.NewGuid().ToString(),
            //        Name = "生产环境",
            //        Active = false,
            //        AlwaysApply = false,
            //        Content = "# 生产环境\n",
            //        LastUpdateTime = DateTime.Now,
            //        ReadOnly = false,
            //        Url = null
            //    }
            //};
        }

        private static void InitTools()
        {
            Settings.Default.tools = new List<Tool>();

            var chromePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)}\\Google\\Chrome\\Application\\chrome.exe";
            if (!File.Exists(chromePath))
            {
                chromePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Google\\Chrome\\Application\\chrome.exe";
            }

            if (File.Exists(chromePath))
            {
                Settings.Default.tools.Add(new Tool
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "启动 Chrome 浏览器",
                    Cmd = $"\"{chromePath}\"",
                    Children = new[]
                    {
                        new Tool
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "禁用安全检查",
                            Cmd = $"\"{chromePath}\"",
                            Args = $"--disable-web-security --user-data-dir={Environment.GetEnvironmentVariable("TMP")}\\mHostsDotNetChromeTmpDir\\!!GUID!!"
                        },
                        new Tool
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "禁用所有插件",
                            Cmd = $"\"{chromePath}\"",
                            Args = "--disable-plugins --disable-extensions"
                        }
                    }
                });
            }


            var edgePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)}\\Microsoft\\Edge\\Application\\msedge.exe";
            if (!File.Exists(edgePath))
            {
                edgePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}\\Microsoft\\Edge\\Application\\msedge.exe";
            }

            if (File.Exists(edgePath))
            {
                Settings.Default.tools.Add(new Tool
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "启动 Edge 浏览器",
                    Cmd = $"\"{edgePath}\"",
                    Children = new[]
                    {
                        new Tool
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "禁用安全检查",
                            Cmd = $"\"{edgePath}\"",
                            Args = $"--disable-web-security --user-data-dir={Environment.GetEnvironmentVariable("TMP")}\\mHostsDotNetMsEdgeTmpDir\\!!GUID!!"
                        },
                        new Tool
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "禁用所有插件",
                            Cmd = $"\"{edgePath}\"",
                            Args = "--disable-plugins --disable-extensions"
                        }
                    }
                });
            }
        }
    }
}
