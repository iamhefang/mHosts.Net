using mHosts.Net.Properties;
using System;
using System.IO;
using System.Reflection;
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


        private void ApplyHosts2System(Host host)
        {
            try
            {
                if (File.GetAttributes(Settings.Default.hostsPath) == FileAttributes.ReadOnly)
                {
                    MessageBox.Show(@"请尝试以管理员身份重新打开本软件后重试", @"Hosts文件不可写", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // File.GetAccessControl(Settings.Default.hostsPath).GetAccessRules()
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
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    $@"写hosts文件时出错，错误信息：{e.Message}",
                    @"写文件时出错",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
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

        private void OnEditorContextMenuSelectAllClick(object sender, EventArgs e)
        {
            codeEditor.SelectAll();
        }

        private void OnEditorContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            codeEditorContextMenu.Items[1].Enabled = codeEditor.SelectionLength != 0;
            codeEditorContextMenu.Items[2].Enabled = !codeEditor.ReadOnly && codeEditor.SelectionLength != 0;
            codeEditorContextMenu.Items[3].Enabled = codeEditor.CanPaste(DataFormats.GetFormat(DataFormats.Text));
        }

        private void OnEditorContextMenuCopyClick(object sender, EventArgs e)
        {
            codeEditor.Copy();
        }

        private void OnEditorContextMenuCutClick(object sender, EventArgs e)
        {
            codeEditor.Cut();
        }

        private void OnEditorContextMenuPasteClick(object sender, EventArgs e)
        {
            codeEditor.Paste();
        }
    }
}