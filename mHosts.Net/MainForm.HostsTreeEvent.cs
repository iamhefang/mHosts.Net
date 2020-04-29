using mHosts.Net.Properties;
using System.Windows.Forms;

namespace mHosts.Net
{
    sealed partial class MainForm
    {
        private void OnTreeNodeSelect(object sender, TreeViewEventArgs e)
        {
            codeEditor.ReadOnly = e.Node.Index == 0;
            codeEditor.Text = e.Node.Index == 0
                ? Helpers.ReadText(Settings.Default.hostsPath)
                : Settings.Default.hosts[e.Node.Index - 1].Content;
        }

        private void OnHostDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var host = Settings.Default.hosts[e.Node.Index - 1];
            if (host.AlwaysApply)
            {
                MessageBox.Show(
                    @"该Hosts是共公Hosts，在设置其他Hosts时总会生效，无需手动设置",
                    @"无需手动设置",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            var res = ApplyHosts2System(host);
            if (res)
            {
                hostsTree.SelectedNode = hostsTree.Nodes[0];
            }
        }
    }
}