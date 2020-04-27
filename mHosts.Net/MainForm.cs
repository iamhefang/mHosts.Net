using mHosts.Net.forms;
using mHosts.Net.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace mHosts.Net
{
    public partial class MainForm : Form
    {
        private readonly AssemblyName _assemblyName;
        public MainForm()
        {
            InitializeComponent();
            Program.InitSettings();
            _assemblyName = Assembly.GetExecutingAssembly().GetName();
            Text = $@"{_assemblyName.Name} - v{_assemblyName.Version}";
            toolMenu.DropDownItems.AddRange(Helpers.MakeToolMenu());
            RefreshHosts();
        }

        private void ToggleVisible()
        {
            Visible = !Visible;
        }

        private void OnExitMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            RefreshHosts();
        }

        private void OnAboutMenuItemClick(object sender, EventArgs e)
        {
            var dialog = new AboutDialog
            {
                Text = $@"关于 {_assemblyName.Name} - v{_assemblyName.Version}"
            };
            dialog.ShowDialog(this);
        }

        private void OnTrayIconDoubleClick(object sender, MouseEventArgs e)
        {
            ToggleVisible();
        }

        private void OnToggleMenuItemClick(object sender, EventArgs e)
        {
            ToggleVisible();
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

        private void OnTrayMenuRefreshClick(object sender, EventArgs e)
        {
            try
            {
                processRefreshDNS.Start();
                processRefreshDNS.WaitForExit();
                var errorOutput = processRefreshDNS.StandardError.ReadToEnd();

                processRefreshDNS.Close();

                if (errorOutput.Length < 1)
                {
                    trayIcon.ShowBalloonTip(5000, "操作成功", "DNS缓存刷新成功", ToolTipIcon.Info);
                }
                else
                {
                    trayIcon.ShowBalloonTip(5000, "操作失败", "DNS缓存刷新失败", ToolTipIcon.Error);
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                trayIcon.ShowBalloonTip(5000, "出现错误", "刷新DNS缓存时出错", ToolTipIcon.Error);
            }
        }

        private void OnMenuItemCheckUpdateClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/iamhefang/mHosts/releases")?.Close();
        }

        private void OnMenuItemDocClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/iamhefang/mHosts/wiki")?.Close();
        }

        private void OnTreeNodeSelect(object sender, TreeViewEventArgs e)
        {
            codeEditor.ReadOnly = e.Node.Index == 0;
            foreach (TreeNode node in hostsTree.Nodes)
            {
                node.NodeFont = null;
            }
            e.Node.NodeFont = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
            codeEditor.Text = e.Node.Index == 0 ? Helpers.ReadText(Settings.Default.hostsPath) : Settings.Default.hosts[e.Node.Index - 1].Content;
        }

        private void OnCodeChanged(object sender, EventArgs e)
        {
            Helpers.SetRichTextHighlight(codeEditor);
        }

        private void OnHostDoubleClick(object sender, EventArgs e)
        {

        }

        private void OnLaunchBrowser(object sender, EventArgs e)
        {
            Helpers.LaunchChrome();
        }

        private void OnMenuItemConfigClick(object sender, EventArgs e)
        {
            var dialog = new SettingForm();
            dialog.ShowDialog(this);
        }

        private void OnMenuItemNewHostsClick(object sender, EventArgs e)
        {
            var dialog = new NewHostsForm();
            dialog.Closed += OnNewHostsDialogClosed;
            dialog.ShowDialog(this);
        }

        private void OnNewHostsDialogClosed(object sender, EventArgs e)
        {
            RefreshHosts();
        }

        private void RefreshHosts()
        {
            hostsTree.Nodes.Clear();
            hostsTree.Nodes.Add("system-hosts", "当前系统");
            codeEditor.Text = Helpers.ReadText(Settings.Default.hostsPath);
            foreach (var host in Settings.Default.hosts)
            {
                hostsTree.Nodes.Add(host.Id, host.Name);
            }
            statusTextHostsCount.Text = $@"当前共有{Settings.Default.hosts.Count}个规则";
        }
    }
}
