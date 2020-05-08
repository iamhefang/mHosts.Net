using mHosts.Net.Properties;
using System.Windows.Forms;
using mHosts.Net.entities;

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
            var node = (TreeView) sender;
            if (node.Tag is Host host) ApplyHosts2System(host);
        }
    }
}