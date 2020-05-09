using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using mHosts.Net.entities;
using mHosts.Net.forms;
using mHosts.Net.Properties;
using Newtonsoft.Json;

namespace mHosts.Net
{
    sealed partial class MainForm
    {
        private void ToggleVisible()
        {
            Visible = !Visible;
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
            InitHostsTree();
        }

        private RefreshDnsStatus DoRefreshDns(bool showTip = false)
        {
            try
            {
                processRefreshDNS.Start();
                processRefreshDNS.WaitForExit();
                var errorOutput = processRefreshDNS.StandardError.ReadToEnd();
                processRefreshDNS.Close();

                if (string.IsNullOrEmpty(errorOutput))
                {
                    if (showTip)
                    {
                        trayIcon.ShowBalloonTip(5000, "操作成功", "DNS缓存刷新成功", ToolTipIcon.Info);
                    }

                    LogForm.Notice("DNS缓存刷新成功");
                    return RefreshDnsStatus.Success;
                }

                if (showTip)
                {
                    trayIcon.ShowBalloonTip(5000, "操作失败", "DNS缓存刷新失败", ToolTipIcon.Error);
                }

                LogForm.Error("DNS缓存刷新成功: " + errorOutput);

                return RefreshDnsStatus.Failed;
            }
            catch (Exception e)
            {
                if (showTip)
                {
                    trayIcon.ShowBalloonTip(5000, "出现错误", "刷新DNS缓存时出错", ToolTipIcon.Error);
                }

                LogForm.Error("DNS缓存刷新成功: " + e.Message);
                return RefreshDnsStatus.Error;
            }
        }

        private void OnMenuRefreshDNSClick(object sender, EventArgs e)
        {
            var status = DoRefreshDns();
            switch (status)
            {
                case RefreshDnsStatus.Success:
                    trayIcon.ShowBalloonTip(5000, "操作成功", "DNS缓存刷新成功", ToolTipIcon.Info);
                    break;
                case RefreshDnsStatus.Failed:
                    trayIcon.ShowBalloonTip(5000, "操作失败", "DNS缓存刷新失败", ToolTipIcon.Error);
                    break;
                case RefreshDnsStatus.Error:
                    trayIcon.ShowBalloonTip(5000, "出现错误", "刷新DNS缓存时出错", ToolTipIcon.Error);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void OnMenuItemCheckUpdateClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/iamhefang/mHosts.Net/releases")?.Close();
        }

        private void OnMenuItemDocClick(object sender, EventArgs e)
        {
            Process.Start("https://github.com/iamhefang/mHosts.Net/wiki")?.Close();
        }

        private void OnExitMenuItemClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            InitHostsTree();
        }

        private void OnAboutMenuItemClick(object sender, EventArgs e)
        {
            var dialog = new AboutDialog
            {
                Text = string.Format(Resources.StrAboutSoftware, _assemblyName.Name, _assemblyName.Version)
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

        private void OnNewToolMenuItemClick(object sender, EventArgs e)
        {
            var dialog = new SettingForm {tabs = {SelectedIndex = 1}};
            dialog.ShowDialog(this);
        }

        private void OnFileMenuExportClick(object sender, EventArgs e)
        {
            var result = exportHostDialog.ShowDialog(this);
            if (result != DialogResult.Yes && result != DialogResult.OK) return;
            try
            {
                using var stream = exportHostDialog.OpenFile();
                using var writer = new StreamWriter(stream, Encoding.UTF8);
                writer.Write(JsonConvert.SerializeObject(Settings.Default.hosts));
                MessageBox.Show(
                    string.Format(Resources.StrExportFileAt, exportHostDialog.FileName),
                    Resources.StrExportSuccess,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception exception)
            {
                LogForm.Error("导出文件出现错误:" + exception.Message);
                MessageBox.Show(
                    exception.Message,
                    Resources.StrExportFileError,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}