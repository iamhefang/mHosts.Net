﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using mHosts.Net.entities;
using mHosts.Net.forms;

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
                    return RefreshDnsStatus.SUCCESS;
                }

                if (showTip)
                {
                    trayIcon.ShowBalloonTip(5000, "操作失败", "DNS缓存刷新失败", ToolTipIcon.Error);
                }
                return RefreshDnsStatus.FAILED;
            }
            catch (Exception)
            {
                if (showTip)
                {
                    trayIcon.ShowBalloonTip(5000, "出现错误", "刷新DNS缓存时出错", ToolTipIcon.Error);
                }
                return RefreshDnsStatus.ERROR;
            }
        }

        private void OnMenuRefreshDNSClick(object sender, EventArgs e)
        {
            var status = DoRefreshDns();
            switch (status)
            {
                case RefreshDnsStatus.SUCCESS:
                    trayIcon.ShowBalloonTip(5000, "操作成功", "DNS缓存刷新成功", ToolTipIcon.Info);
                    break;
                case RefreshDnsStatus.FAILED:
                    trayIcon.ShowBalloonTip(5000, "操作失败", "DNS缓存刷新失败", ToolTipIcon.Error);
                    break;
                case RefreshDnsStatus.ERROR:
                    trayIcon.ShowBalloonTip(5000, "出现错误", "刷新DNS缓存时出错", ToolTipIcon.Error);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
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
    }
}