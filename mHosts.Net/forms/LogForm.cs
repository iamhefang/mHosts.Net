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
    public enum LogLevel
    {
        ERROR,
        LOG,
        WARNING,
        NOTICE,
        DEBUG
    }

    public partial class LogForm : Form
    {
        private static string _log;
        private static LogForm _form;

        private LogForm()
        {
            InitializeComponent();
        }

        public static void ShowForm()
        {
            _form ??= new LogForm();
            _form.Show();
        }

        public static void Log(string log, LogLevel level)
        {
            _log += $"[{DateTime.Now}]({level}) {log}{Environment.NewLine}";
            if (_form != null)
            {
                _form.logTextarea.Text = _log;
            }
        }

        public static void Error(string log)
        {
            Log(log, LogLevel.ERROR);
        }

        public static void Warning(string log)
        {
            Log(log, LogLevel.WARNING);
        }

        public static void Notice(string log)
        {
            Log(log, LogLevel.NOTICE);
        }

        public static void Debug(string log)
        {
#if DEBUG
            Log(log, LogLevel.DEBUG);
#endif
        }

        private void OnLogFormLoad(object sender, EventArgs e)
        {
            logTextarea.Text = _log;
        }

        private void OnLogFormClosed(object sender, FormClosedEventArgs e)
        {
            _form = null;
        }
    }
}