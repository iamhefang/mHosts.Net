using mHosts.Net.Properties;
using System;
using System.Windows.Forms;

namespace mHosts.Net
{
    sealed partial class MainForm
    {
        private void OnCodeChanged(object sender, EventArgs e)
        {

            Helpers.SetRichTextHighlight(codeEditor);
            if (hostsTree.SelectedNode == null || hostsTree.SelectedNode.Index == 0) return;
            var host = Settings.Default.hosts[hostsTree.SelectedNode.Index - 1];
            host.Content = codeEditor.Text;
        }

        private void OnCodeEditorKeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Control || e.KeyCode != Keys.OemQuestion) return;
            if (codeEditor.ReadOnly) return;
            var start = codeEditor.SelectionStart;
            var length = codeEditor.SelectionLength;
            var lineStart = codeEditor.GetLineFromCharIndex(start);
            var lineEnd = codeEditor.GetLineFromCharIndex(start + codeEditor.SelectionLength - 1);
            var lines = codeEditor.Lines;

            var comment = false;
            for (var i = lineStart; i <= lineEnd; i++)
            {
                if (lines[i].StartsWith("#")) continue;
                comment = true;
                break;
            }

            for (var i = lineStart; i <= lineEnd; i++)
            {
                var line = lines[i];
                if (comment)
                {
                    lines[i] = "#" + line;
                    length += 1;
                }
                else if (line.StartsWith("#"))
                {
                    lines[i] = line.Substring(1);
                    length -= 1;
                }
            }
            codeEditor.Lines = lines;
            codeEditor.Select(start, length);
        }
    }
}
