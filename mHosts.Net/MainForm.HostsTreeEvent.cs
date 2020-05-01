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
            e.Node.Checked = host.Active = !host.Active;
            ApplyHosts2System();
        }
    }
}