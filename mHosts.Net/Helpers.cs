using mHosts.Net.entities;
using mHosts.Net.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace mHosts.Net
{
    internal static class Helpers
    {
        public static Host[] ParseOldHosts(string json)
        {
            var obj = JsonConvert.DeserializeObject(json);
            if (!(obj is JObject))
            {
                return new Host[0];
            }

            var hosts = (obj as JObject)["hosts"] as JArray;

            return (hosts ?? throw new InvalidOperationException()).Select(host => new Host
            {
                Id = Guid.NewGuid().ToString(),
                Name = host["name"]!.Value<string>(),
                ReadOnly = host["readOnly"]!.Value<bool>(),
                AlwaysApply = host["alwaysApply"]!.Value<bool>(),
                Url = host["url"]!.Value<string>(),
                Content = host["content"]!.Value<string>(),
                Icon = host["icon"]!.Value<string>()
            }).ToArray();
        }

        public static readonly Dictionary<string, Bitmap> ImgMap = new Dictionary<string, Bitmap>
        {
            {"logo", Resources.logo},
            {"aliyun", Resources.aliyun},
            {"chrome", Resources.chrome},
            {"darwin", Resources.darwin},
            {"database", Resources.database},
            {"edge", Resources.edge},
            {"firefox", Resources.firefox},
            {"java", Resources.java},
            {"linux", Resources.linux},
            {"mysql", Resources.mysql},
            {"postgresql", Resources.postgresql},
            {"python", Resources.python},
            {"qq", Resources.qq},
            {"windows", Resources.windows}
        };

        public static string[] MergeHosts(Host host2Merge)
        {
            var ass = Assembly.GetExecutingAssembly().GetName();

            var hosts = Settings.Default.hosts;
            var lines = new List<string>(hosts.Count * 2)
            {
                $"# Hosts Apply by {ass.Name} v{ass.Version} {DateTime.Now}"
            };
            foreach (var host in hosts.Where(host => host.AlwaysApply))
            {
                lines.InsertRange(1, host.Content.Split('\n'));
                lines.Insert(1, $"\n#----------- {host.Name} -----------");
            }

            lines.Add($"\n#----------- {host2Merge.Name} -----------");
            lines.AddRange(host2Merge.Content.Split('\n'));

            for (var i = 0; i < lines.Count; i++)
            {
                lines[i] = lines[i].Trim();
            }

            lines.Reverse();
            return new HashSet<string>(lines).Reverse().ToArray();
        }

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
            using var stream = File.OpenText(path);
            return stream.ReadToEnd();//.Replace("\n", Environment.NewLine);
        }
    }
}