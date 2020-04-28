using System.Drawing;
using System.Linq;
using mHosts.Net.Properties;
using System.Windows.Forms;

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
                    Enabled = !host.AlwaysApply
                };
                item.Click += (sender, e) =>
                {
                    ApplyHosts2System(host);
                };
                items[i] = item;
            }

            return items;
        }

        private void InitHostsTree()
        {
            hostsTree.Nodes.Clear();
            hostsTree.ImageList = new ImageList();
            foreach (var bitmap in Helpers.ImgMap)
            {
                hostsTree.ImageList.Images.Add(bitmap.Key, bitmap.Value);
            }
            hostsTree.Nodes.Add("system-hosts", "当前系统", "windows");
            codeEditor.Text = Helpers.ReadText(Settings.Default.hostsPath);
            foreach (var node in from host in Settings.Default.hosts let node = hostsTree.Nodes.Add(host.Id, host.Name,"logo") where host.Active || host.AlwaysApply select node)
            {
                node.NodeFont = new Font(hostsTree.Font.FontFamily, hostsTree.Font.Size, FontStyle.Bold);
                node.ForeColor = Color.CornflowerBlue;
            }
            statusLabelHostsCount.Text = $@"当前共有{Settings.Default.hosts.Count}个规则";
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

    }
}
