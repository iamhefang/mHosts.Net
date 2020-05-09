using System;
using System.Diagnostics;
using mHosts.Net.Properties;
using System.Reflection;
using System.Windows.Forms;

namespace mHosts.Net
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();

            var assemblyName = Assembly.GetExecutingAssembly().GetName();
            webBrowser1.Document?.Write(string.Empty);
            webBrowser1.DocumentText = string.Format(Resources.About, assemblyName.Name, assemblyName.Version);
        }

        private void OnNavigateToNewUrl(object sender, WebBrowserNavigatingEventArgs e)
        {
            e.Cancel = e.Url.AbsoluteUri.Contains("://");
            if (e.Cancel)
            {
                Process.Start(e.Url.AbsoluteUri);
            }
        }

        private void OnAboutDialogLoad(object sender, EventArgs e)
        {

        }
    }
}
