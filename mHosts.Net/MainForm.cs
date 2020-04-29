using mHosts.Net.Properties;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using mHosts.Net.entities;

namespace mHosts.Net
{
    public sealed partial class MainForm : Form
    {
        private readonly AssemblyName _assemblyName = Assembly.GetExecutingAssembly().GetName();

        public MainForm()
        {
            InitializeComponent();
            InitCodeEditor();
            Program.InitSettings();
            InitTrayMenu(trayIconMenu);
            InitToolMenu();
            Text = $@"{_assemblyName.Name} - v{_assemblyName.Version}";
#if DEBUG
            Text += @" 调试版";
#else
            Text += @" 正式版";
#endif
            InitHostsTree();
        }


        private bool ApplyHosts2System(Host host)
        {
            try
            {
                var hostLines = Helpers.MergeHosts(host);
                Console.WriteLine(hostLines);
                File.WriteAllText(Settings.Default.hostsPath, string.Join("\n", hostLines));
                Settings.Default.hosts.ForEach(item =>
                {
                    if (!item.AlwaysApply)
                    {
                        item.Active = false;
                    }
                });
                host.Active = true;
                var res = DoRefreshDns();
                var msg = "Hosts已成功应用到系统";

                switch (res)
                {
                    case RefreshDnsStatus.Success:
                        msg += "\n刷新DNS缓存成功";
                        break;
                    case RefreshDnsStatus.Error:
                        msg += "\n刷新DNS缓存出错";
                        break;
                    case RefreshDnsStatus.Failed:
                        break;
                    default:
                        msg += "\n刷新DNS缓存失败";
                        break;
                }

                trayIcon.ShowBalloonTip(2000, "操作成功", msg, ToolTipIcon.Info);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $@"写hosts文件时出错，错误信息：{e.Message}",
                    @"写文件时出错",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                return false;
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing) return;
            e.Cancel = true;
            Visible = false;
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.Save();
            trayIcon.Visible = false;
            trayIcon.Dispose();
            Environment.Exit(0);
        }

        private void OnImportMenuItemClick(object sender, EventArgs e)
        {
            try
            {
                var result = importHostDialog.ShowDialog();
                if (result != DialogResult.OK) return;
                var count = 0;
                if (importHostDialog.FileName.EndsWith("settings.json"))
                {
                    using var stream = importHostDialog.OpenFile();
                    using var reader = new StreamReader(stream, Encoding.UTF8);
                    var json = reader.ReadToEnd();
                    var hosts = Helpers.ParseOldHosts(json);
                    count = hosts.Length;
                    Settings.Default.hosts.AddRange(hosts);
                }
                else if (importHostDialog.FileName.EndsWith("hosts"))
                {
                    using var stream = importHostDialog.OpenFile();
                    using var reader = new StreamReader(stream, Encoding.UTF8);
                    Settings.Default.hosts.Add(new Host
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "导入的Hosts",
                        Active = false,
                        AlwaysApply = false,
                        Content = reader.ReadToEnd(),
                        LastUpdateTime = DateTime.Now,
                        Url = null,
                        Icon = "logo"
                    });
                    count = 1;
                }
                MessageBox.Show(
                    @$"成功导入{count}个Hosts",
                    @"导入成功",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                InitHostsTree();
            }
            catch (Exception)
            {
                MessageBox.Show(@"请检查导入的文件是否是mHosts导出的文件", @"导入Hosts出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}