using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mHosts.Net.Properties;

namespace mHosts.Net.forms
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            ckAllowMutiHosts.Checked = Settings.Default.allowMutiHosts;
        }

        private void OnSettingFormLoad(object sender, EventArgs e)
        {
        }

        private void OnAllowMultipleHostsChanged(object sender, EventArgs e)
        {
            Settings.Default.allowMutiHosts = ckAllowMutiHosts.Checked;
        }
    }
}
