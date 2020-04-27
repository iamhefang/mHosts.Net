using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using mHosts.Net.entities;
using mHosts.Net.Properties;

namespace mHosts.Net
{
    static class Program
    {
        public static EventWaitHandle ProgramStarted;
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
            // 尝试创建一个命名事件
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, Resources.SingleInstanceKey, out var noInstanceNow);
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
                Settings.Default.hosts = new List<Host>();
            }

            if (Settings.Default.tools == null)
            {
                Settings.Default.tools = new List<Tool>
                {
                    new Tool
                    {
                        Id = "sfsdfsdf",Name = "sdfjlskdjfl"
                    }
                };
            }
        }
    }
}
