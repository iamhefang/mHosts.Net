using System;
using System.Drawing;
using mHosts.Net.Properties;
using System.Windows.Forms;
using mHosts.Net.entities;

namespace mHosts.Net
{
    sealed partial class MainForm
    {
        private ToolStripItem[] MakeHostMenu()
        {
            var items = new ToolStripItem[Settings.Default.hosts.Count];
            for (var i = 0; i < items.Length; i++)
            {
                var host = Settings.Default.hosts[i];
                var item = new ToolStripMenuItem
                {
                    Text = host.Name,
                    Checked = host.AlwaysApply || host.Active,
                    Enabled = !host.AlwaysApply,
                    Tag = host
                };
                item.Click += OnHostMenuItemClick;
                items[i] = item;
            }

            return items;
        }

        private void OnHostMenuItemClick(object sender, EventArgs e)
        {
            var menuItem = (ToolStripMenuItem) sender;
            var host = (Host) menuItem.Tag;
            host.Active = !host.Active;
            ApplyHosts2System();
        }

        private void InitHostsTree()
        {
            hostsTree.Nodes.Clear();
            hostsTree.ImageList = new ImageList();
            foreach (var bitmap in Helpers.ImgMap)
            {
                hostsTree.ImageList.Images.Add(bitmap.Key, bitmap.Value);
            }

            hostsTree.Nodes.Add("system-hosts", Resources.StrCurrentSystem, "windows");
            codeEditor.Text = Helpers.ReadText(Settings.Default.hostsPath);
            foreach (var host in Settings.Default.hosts)
            {
                var node = hostsTree.Nodes.Add(host.Id, host.Name, host.Icon ?? "logo");
                node.ContextMenuStrip = new ContextMenuStrip
                {
                    Tag = host,
                    Items =
                    {
                        new ToolStripMenuItem
                        {
                            Name = "active",
                            Text = Resources.StrSet2Current,
                            ShortcutKeyDisplayString = Resources.StrDoubleClick,
                            Tag = host
                        },
                        new ToolStripMenuItem
                        {
                            Name = "edit",
                            Text = Resources.StrEdit,
                            Tag = host
                        },
                        new ToolStripMenuItem
                        {
                            Name = "delete",
                            Text = Resources.StrDelete,
                            ShortcutKeys = Keys.Delete,
                            Tag = host
                        },
                        new ToolStripMenuItem
                        {
                            Name = "export",
                            Text = Resources.StrExport,
                            Tag = host
                        }
                    }
                };
                foreach (ToolStripItem menuItem in node.ContextMenuStrip.Items)
                {
                    menuItem.Click += OnTreeContextMenuClick;
                }

                node.Tag = host;
                if (!host.Active && !host.AlwaysApply) continue;
                node.NodeFont = new Font(hostsTree.Font.FontFamily, hostsTree.Font.Size, FontStyle.Bold);
                node.ForeColor = Color.CornflowerBlue;
            }

            statusLabelHostsCount.Text = string.Format(Resources.StrHostsCount, Settings.Default.hosts.Count);
        }

        private void OnTreeContextMenuClick(object sender, EventArgs e)
        {
            var menu = (ToolStripMenuItem) sender;
            var host = (Host) menu.Tag;
            switch (menu.Name)
            {
                case "active":
                    host.Active = !host.Active;
                    ApplyHosts2System();
                    break;
                case "delete":
                    break;
                case "edit":
                    break;
                case "export":
                    break;
            }
        }

        private void InitCodeEditor()
        {
            //var labelLineNumber = new Label
            //{
            //    Name = "labelLineNumber",
            //    Top = 0,
            //    TextAlign = ContentAlignment.TopRight,
            //    Width = 40,
            //    Text = "1",
            //    Font = codeEditor.Font,
            //    Height = codeEditor.Height,
            //    BackColor = Color.Gray,
            //    BorderStyle = BorderStyle.None
            //};
            //codeEditor.Controls.Add(labelLineNumber);
            //codeEditor.SelectionIndent = 40;
        }

        private void InitToolMenu()
        {
            toolMenu.DropDownItems.Clear();

            var refreshDns = new ToolStripMenuItem(@"刷新DNS缓存");
            refreshDns.Click += OnMenuRefreshDNSClick;

            toolMenu.DropDownItems.Add(refreshDns);
            toolMenu.DropDownItems.AddRange(Helpers.MakeToolMenu(Settings.Default.tools.ToArray()));

            var newTool = new ToolStripMenuItem("添加新工具(&A)");
            newTool.Click += OnNewToolMenuItemClick;

            toolMenu.DropDownItems.Add(newTool);
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

            var serverStatus = new ToolStripMenuItem(Server.IsBound ? "服务已启动" : "服务未启动")
            {
                Checked = Server.IsBound,
                Enabled = false
            };

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
                serverStatus,
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
    }
}