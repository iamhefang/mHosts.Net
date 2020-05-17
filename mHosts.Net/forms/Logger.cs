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

    public partial class Logger : Form
    {
        private static string _log;
        private static Logger _form;

        private Logger()
        {
            InitializeComponent();
        }

        public static void ShowForm()
        {
            _form ??= new Logger();
            _form.Show();
        }

        public static void Log(string log, LogLevel level = LogLevel.LOG)
        {
            _log += $"[{DateTime.Now}]({level}) {log}{Environment.NewLine}";
            if (_form == null) return;
            _form.logTextarea.Text = _log;
            _form.logTextarea.SelectionLength = 0;
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
            logTextarea.SelectionLength = 0;
        }

        private void OnLogFormClosed(object sender, FormClosedEventArgs e)
        {
            _form = null;
        }
    }
}