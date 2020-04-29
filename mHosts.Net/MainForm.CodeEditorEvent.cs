using mHosts.Net.Properties;
using System;
using System.Windows.Forms;

namespace mHosts.Net
{
    sealed partial class MainForm
    {
        private void OnEditorContextMenuSelectAllClick(object sender, EventArgs e)
        {
            codeEditor.SelectAll();
        }

        private void OnEditorContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            codeEditorContextMenu.Items[1].Enabled = codeEditor.SelectionLength != 0;
            codeEditorContextMenu.Items[2].Enabled = !codeEditor.ReadOnly && codeEditor.SelectionLength != 0;
            codeEditorContextMenu.Items[3].Enabled = codeEditor.CanPaste(DataFormats.GetFormat(DataFormats.Text));
        }

        private void OnEditorContextMenuCopyClick(object sender, EventArgs e)
        {
            codeEditor.Copy();
        }

        private void OnEditorContextMenuCutClick(object sender, EventArgs e)
        {
            codeEditor.Cut();
        }

        private void OnEditorContextMenuPasteClick(object sender, EventArgs e)
        {
            codeEditor.Paste();
        }
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
