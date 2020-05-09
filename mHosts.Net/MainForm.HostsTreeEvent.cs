using System.Drawing;
using mHosts.Net.Properties;
using System.Windows.Forms;
using mHosts.Net.entities;

namespace mHosts.Net
{
    sealed partial class MainForm
    {
        private void OnTreeNodeSelect(object sender, TreeViewEventArgs e)
        {
            codeEditor.ReadOnly = e.Node.Name == "system-hosts";
            if (e.Node.Name == "system-hosts")
            {
                codeEditor.Text = Helpers.ReadText(Settings.Default.hostsPath);
            }
            else if (e.Node.Tag is Host host)
            {
                codeEditor.Text = host.Content;
            }
        }

        private void OnHostDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!(e.Node.Tag is Host host)) return;
            ApplyHosts2System(host);
        }
    }
}