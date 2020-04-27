using mHosts.Net.entities;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace mHosts.Net
{
    class Helpers
    {

        public static ToolStripItem[] MakeToolMenu(Tool[] tools)
        {
            var menus = new ToolStripMenuItem[tools.Length];
            for (var i = 0; i < tools.Length; i++)
            {
                var tool = tools[i];
                var menu = new ToolStripMenuItem(tool.Name);
                if (tool.Children.Length > 0)
                {
                    menu.DropDownItems.AddRange(MakeToolMenu(tool.Children));
                }

                if (!string.IsNullOrWhiteSpace(tool.Cmd))
                {
                    menu.Click += (sender, e) =>
                    {
                        var args = (tool.Args ?? "").Replace("!!GUID!!", Guid.NewGuid().ToString());
                        Process.Start(tool.Cmd, args)?.Close();
                    };
                }

                menus[i] = menu;
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

        public static string ReadText(string path)
        {
            using (var stream = File.OpenText(path))
            {
                return stream.ReadToEnd().Replace("\n", Environment.NewLine);
            }
        }
    }
}
