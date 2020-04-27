using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using mHosts.Net.Properties;

namespace mHosts.Net
{
    class Helpers
    {
        public static ToolStripItem[] MakeToolMenu()
        {
            var menus = new ToolStripItem[Settings.Default.tools.Count];
            for (var i = 0; i < Settings.Default.tools.Count; i++)
            {
                var tool = Settings.Default.tools[i];
                menus[i] = new ToolStripMenuItem(tool.Name);
            }
            return menus;
        }
        public static void SetRichTextHighlight(RichTextBox editor)
        {
            if (editor.TextLength < 1)
            {
                return;
            }
            var lastSelectionStart = editor.SelectionStart;
            for (var line = 0; line < editor.Lines.Length; line++)
            {
                var lineStr = editor.Lines[line];
                var start = editor.GetFirstCharIndexFromLine(line);
                if (lineStr.StartsWith("#"))
                {
                    editor.Select(start, lineStr.Length);
                    editor.SelectionColor = Color.Gray;
                }
                else if (lineStr.Length > 0)
                {
                    var items = lineStr.Split(' ');
                    if (items.Length < 2) break;
                    editor.Select(start, items[0].Length);
                    editor.SelectionColor = Color.Blue;
                    start = start + items[0].Length + 1;
                    editor.Select(start, start + items[1].Length);
                    editor.SelectionColor = Color.FromArgb(0x7e, 0x00, 0x7e);
                }
            }

            editor.Select(lastSelectionStart, 0);
        }

        public static bool LaunchChrome()
        {
            return LaunchChrome("");
        }

        public static bool LaunchChrome(string args)
        {
            return LaunchChrome(args, "chrome");
        }

        public static bool LaunchChrome(string args, string cmd)
        {
            var info = new ProcessStartInfo(cmd, args)
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };
            var res = Process.Start(info);
            if (res == null) return false;
            using (res.StandardError)
            {
                return res.StandardError.ReadToEnd().Length == 0;
            }
        }

        public static string ReadText(string path)
        {
            using (var stream = File.OpenText(path))
            {
                return stream.ReadToEnd().Replace("\n", Environment.NewLine);
            }
        }
    }
}
