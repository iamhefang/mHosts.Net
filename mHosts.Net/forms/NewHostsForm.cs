using mHosts.Net.entities;
using mHosts.Net.Properties;
using System;
using System.Windows.Forms;

namespace mHosts.Net.forms
{
    public partial class NewHostsForm : Form
    {
        public NewHostsForm()
        {
            InitializeComponent();
        }

        private void OnHostsTypeChanged(object sender, EventArgs e)
        {
            inputHostsUrl.Enabled = radioOnlineHosts.Checked;
        }

        private void OnBtnSaveHostsClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputHostsName.Text))
            {
                MessageBox.Show(
                    Resources.StrHostsNameCanNotEmpty,
                    Resources.StrSaveFailed,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (radioOnlineHosts.Checked && string.IsNullOrWhiteSpace(inputHostsUrl.Text))
            {
                MessageBox.Show(
                    Resources.StrPleaseInputOnlineHostUrl,
                    Resources.StrSaveFailed,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (Settings.Default.hosts.FindIndex(item => item.Name == inputHostsName.Text) > -1)
            {
                MessageBox.Show(
                    string.Format(Resources.StrHostsNameExist, inputHostsName.Text),
                    Resources.StrSaveFailed,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (radioOnlineHosts.Checked &&
                Settings.Default.hosts.FindIndex(item => item.Url == inputHostsUrl.Text) > -1)
            {
                MessageBox.Show(
                    string.Format(Resources.StrHostsUrlExist, inputHostsUrl.Text),
                    Resources.StrSaveFailed,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            var host = new Host
            {
                Id = Guid.NewGuid().ToString(),
                Name = inputHostsName.Text,
                Url = radioOnlineHosts.Checked ? inputHostsUrl.Text : null,
                LastUpdateTime = DateTime.Now,
                AlwaysApply = chkAlwaysApply.Checked,
                Icon = selectHostIcon.Text
            };
            Settings.Default.hosts.Add(host);
            Settings.Default.Save();
            Close();
        }
    }
}