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
                MessageBox.Show(@"Hosts名称不能为空", @"保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioOnlineHosts.Checked && string.IsNullOrWhiteSpace(inputHostsUrl.Text))
            {
                MessageBox.Show(@"请输入在线Hosts地址", @"保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Settings.Default.hosts.FindIndex(item => item.Name == inputHostsName.Text) > -1)
            {
                MessageBox.Show($@"Hosts名称'{inputHostsName.Text}'已存在", @"保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (radioOnlineHosts.Checked && Settings.Default.hosts.FindIndex(item => item.Url == inputHostsUrl.Text) > -1)
            {
                MessageBox.Show($@"在线Hosts地址'{inputHostsUrl.Text}'已存在", @"保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var host = new Host
            {
                Id = Guid.NewGuid().ToString(),
                Name = inputHostsName.Text,
                Url = radioOnlineHosts.Checked ? inputHostsUrl.Text : null,
                LastUpdateTime = DateTime.Now
            };
            Settings.Default.hosts.Add(host);
            Settings.Default.Save();
            Console.WriteLine(Settings.Default.hosts.Count);
            Close();
        }
    }
}
