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
            ApplyHosts2System(host);
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
            var nodeCommon = hostsTree.Nodes.Add("common-hosts", Resources.StrCommon, "logo");
            var nodeCustom = hostsTree.Nodes.Add("custom-hosts", Resources.StrCustom, "logo");
            codeEditor.Text = Helpers.ReadText(Settings.Default.hostsPath);
            foreach (var host in Settings.Default.hosts)
            {
                var node = (host.AlwaysApply ? nodeCommon : nodeCustom).Nodes.Add(
                    host.Id, 
                    host.Name,
                    host.Icon ?? "logo"
                );
                node.Checked = host.Active || host.AlwaysApply;
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
                            Enabled = !host.AlwaysApply,
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
            hostsTree.ExpandAll();
        }

        private void OnTreeContextMenuClick(object sender, EventArgs e)
        {
            var menu = (ToolStripMenuItem) sender;
            var host = (Host) menu.Tag;
            switch (menu.Name)
            {
                case "active":
                    ApplyHosts2System(host);
                    break;
                case "delete":
                    break;
                case "edit":
                    break;
                case "export":
                    break;
            }
        }

        private void InitToolMenu()
        {
            toolMenu.DropDownItems.Clear();

            var refreshDns = new ToolStripMenuItem(Resources.StrRefreshDNS);
            refreshDns.Click += OnMenuRefreshDNSClick;

            toolMenu.DropDownItems.Add(refreshDns);
            toolMenu.DropDownItems.AddRange(Helpers.MakeToolMenu(Settings.Default.tools.ToArray()));

            var newTool = new ToolStripMenuItem(Resources.StrAddNewTool);
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

            var toggle = new ToolStripMenuItem(Resources.StrToggleMainForm);
            toggle.Click += OnToggleMenuItemClick;

            var serverStatus =
                new ToolStripMenuItem(Server.IsBound ? Resources.StrServiceIsBound : Resources.StrServiceNotBound)
                {
                    Checked = Server.IsBound,
                    Enabled = false
                };

            var newHosts = new ToolStripMenuItem(Resources.StrNewHosts);
            newHosts.Click += OnMenuItemNewHostsClick;

            var refreshDns = new ToolStripMenuItem(Resources.StrRefreshDNS);
            refreshDns.Click += OnMenuRefreshDNSClick;

            var about = new ToolStripMenuItem(Resources.StrAbout);
            about.Click += OnAboutMenuItemClick;

            var exit = new ToolStripMenuItem(Resources.StrExit);
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