using mHosts.Net.forms;
using mHosts.Net.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace mHosts.Net
{
    public partial class MainForm : Form
    {
        private readonly AssemblyName _assemblyName = Assembly.GetExecutingAssembly().GetName();
        public MainForm()
        {
            InitializeComponent();
            Program.InitSettings();
            InitTrayMenu(trayIconMenu);
            InitToolMenu();
            Text = $@"{_assemblyName.Name} - v{_assemblyName.Version}";
            RefreshHosts();
        }

        private void InitToolMenu()
        {
            toolMenu.DropDownItems.Clear();

            var refreshDns = new ToolStripMenuItem(@"刷新DNS缓存");
            refreshDns.Click += OnMenuRefreshDNSClick;

            toolMenu.DropDownItems.Add(refreshDns);
            toolMenu.DropDownItems.AddRange(Helpers.MakeToolMenu(Settings.Default.tools.ToArray()));
        }

        private void InitTrayMenu(ToolStrip menu)
        {
            menu.Items.Clear();
            menu.Items.Add(new ToolStripMenuItem
            {
                Text = $@"{_assemblyName.Name} v{_assemblyName.Version}",
                Enabled = false

            });

            var toggle = new ToolStripMenuItem(@"显示/隐藏主窗口");
            toggle.Click += OnToggleMenuItemClick;

            var newHosts = new ToolStripMenuItem(@"新建Hosts");
            newHosts.Click += OnMenuItemNewHostsClick;

            var refreshDns = new ToolStripMenuItem(@"刷新DNS缓存");
            refreshDns.Click += OnMenuRefreshDNSClick;

            var about = new ToolStripMenuItem(@"关于");
            about.Click += OnAboutMenuItemClick;

            var exit = new ToolStripMenuItem(@"退出");
            exit.Click += OnExitMenuItemClick;

            menu.Items.AddRange(new ToolStripItem[]
            {
                toggle,
                new ToolStripSeparator()
            });
            menu.Items.AddRange(MakeHostMenu());
            menu.Items.AddRange(new ToolStripItem[]
            {
                newHosts,
                new ToolStripSeparator(),
                refreshDns
            });
            menu.Items.AddRange(Helpers.MakeToolMenu(Settings.Default.tools.ToArray()));
            menu.Items.AddRange(new ToolStripItem[]
            {
                new ToolStripSeparator(),
                about,
                exit
            });
        }
        private static ToolStripItem[] MakeHostMenu()
        {
            var items = new ToolStripItem[Settings.Default.hosts.Count];
            for (var i = 0; i < items.Length; i++)
            {
                var host = Settings.Default.hosts[i];
                var item = new ToolStripMenuItem
                {
                    Text = host.Name,
                    Checked = host.AlwaysApply || host.Active,
                    Enabled = !host.AlwaysApply
                };
                items[i] = item;
            }

            return items;
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

        private void OnMenuRefreshDNSClick(object sender, EventArgs e)
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
            if (hostsTree.SelectedNode == null || hostsTree.SelectedNode.Index == 0) return;
            var host = Settings.Default.hosts[hostsTree.SelectedNode.Index - 1];
            host.Content = codeEditor.Text;
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
            statusLabelHostsCount.Text = $@"当前共有{Settings.Default.hosts.Count}个规则";
        }

        private void OnHostDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var host = Settings.Default.hosts[e.Node.Index - 1];
            try
            {
                File.WriteAllText(Settings.Default.hostsPath, host.Content);
            }
            catch (Exception)
            {
                MessageBox.Show(@"请以管理员身份重新打开本软件", @"权限不足", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnCodeEditorKeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control || e.KeyCode != Keys.OemQuestion) return;
            if (codeEditor.ReadOnly) return;
            var start = codeEditor.SelectionStart;
            var length = codeEditor.SelectionLength;
            var lineStart = codeEditor.GetLineFromCharIndex(start);
            var lineEnd = codeEditor.GetLineFromCharIndex(start + codeEditor.SelectionLength - 1);
            var lines = codeEditor.Lines;

            var comment = false;
            for (var i = lineStart; i <= lineEnd; i++)
            {
                if (lines[i].StartsWith("#")) continue;
                comment = true;
                break;
            }

            for (var i = lineStart; i <= lineEnd; i++)
            {
                var line = lines[i];
                if (comment)
                {
                    lines[i] = "#" + line;
                    length += 1;
                }
                else if (line.StartsWith("#"))
                {
                    lines[i] = line.Substring(1);
                    length -= 1;
                }
            }
            codeEditor.Lines = lines;
            codeEditor.Select(start, length);
        }
    }
}
