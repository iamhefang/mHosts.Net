using System.Windows.Forms;

namespace mHosts.Net
{
    sealed partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
            System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabelHostsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hostsTree = new System.Windows.Forms.TreeView();
            this.codeEditor = new System.Windows.Forms.RichTextBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.processRefreshDNS = new System.Diagnostics.Process();
            this.codeEditorContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editorContextMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.剪切ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBar.SuspendLayout();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.codeEditorContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(223, 24);
            toolStripStatusLabel1.Text = "编辑自动保存，双击应用到系统";
            // 
            // toolStripStatusLabel3
            // 
            toolStripStatusLabel3.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            toolStripStatusLabel3.Size = new System.Drawing.Size(313, 24);
            toolStripStatusLabel3.Text = "内容修复自动保存，双击左侧节点应用到系统";
            // 
            // statusBar
            // 
            this.statusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.statusLabelHostsCount, toolStripStatusLabel3});
            this.statusBar.Location = new System.Drawing.Point(0, 571);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusBar.Size = new System.Drawing.Size(900, 29);
            this.statusBar.TabIndex = 0;
            // 
            // statusLabelHostsCount
            // 
            this.statusLabelHostsCount.Name = "statusLabelHostsCount";
            this.statusLabelHostsCount.Size = new System.Drawing.Size(90, 24);
            this.statusLabelHostsCount.Text = "共0个Hosts";
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.fileMenu, this.toolMenu, this.helpMenu});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuBar.Size = new System.Drawing.Size(900, 30);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.新建NToolStripMenuItem, this.导入IToolStripMenuItem, this.toolStripSeparator4, this.退出EToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(69, 24);
            this.fileMenu.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.新建NToolStripMenuItem.Text = "新建(&N)";
            this.新建NToolStripMenuItem.Click += new System.EventHandler(this.OnMenuItemNewHostsClick);
            // 
            // 导入IToolStripMenuItem
            // 
            this.导入IToolStripMenuItem.Name = "导入IToolStripMenuItem";
            this.导入IToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.导入IToolStripMenuItem.Text = "导入(&I)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(133, 6);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(136, 26);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.OnExitMenuItemClick);
            // 
            // toolMenu
            // 
            this.toolMenu.Name = "toolMenu";
            this.toolMenu.Size = new System.Drawing.Size(70, 24);
            this.toolMenu.Text = "工具(&T)";
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.menuItemConfig, this.menuItemDoc, this.menuItemCheckUpdate, this.menuItemAbout});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(73, 24);
            this.helpMenu.Text = "帮助(&H)";
            // 
            // menuItemConfig
            // 
            this.menuItemConfig.Name = "menuItemConfig";
            this.menuItemConfig.Size = new System.Drawing.Size(165, 26);
            this.menuItemConfig.Text = "首选项(&P)";
            this.menuItemConfig.Click += new System.EventHandler(this.OnMenuItemConfigClick);
            // 
            // menuItemDoc
            // 
            this.menuItemDoc.Name = "menuItemDoc";
            this.menuItemDoc.Size = new System.Drawing.Size(165, 26);
            this.menuItemDoc.Text = "帮助文档(&D)";
            this.menuItemDoc.Click += new System.EventHandler(this.OnMenuItemDocClick);
            // 
            // menuItemCheckUpdate
            // 
            this.menuItemCheckUpdate.Name = "menuItemCheckUpdate";
            this.menuItemCheckUpdate.Size = new System.Drawing.Size(165, 26);
            this.menuItemCheckUpdate.Text = "检查更新(&C)";
            this.menuItemCheckUpdate.Click += new System.EventHandler(this.OnMenuItemCheckUpdateClick);
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(165, 26);
            this.menuItemAbout.Text = "关于(&A)";
            this.menuItemAbout.Click += new System.EventHandler(this.OnAboutMenuItemClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.hostsTree);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.codeEditor);
            this.splitContainer1.Panel2MinSize = 200;
            this.splitContainer1.Size = new System.Drawing.Size(900, 541);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 2;
            // 
            // hostsTree
            // 
            this.hostsTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hostsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostsTree.HideSelection = false;
            this.hostsTree.HotTracking = true;
            this.hostsTree.Location = new System.Drawing.Point(0, 0);
            this.hostsTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hostsTree.Name = "hostsTree";
            this.hostsTree.Size = new System.Drawing.Size(200, 541);
            this.hostsTree.TabIndex = 0;
            this.hostsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeNodeSelect);
            this.hostsTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OnHostDoubleClick);
            // 
            // codeEditor
            // 
            this.codeEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeEditor.ContextMenuStrip = this.codeEditorContextMenu;
            this.codeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditor.Font = new System.Drawing.Font("Consolas", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.codeEditor.Location = new System.Drawing.Point(0, 0);
            this.codeEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Size = new System.Drawing.Size(696, 541);
            this.codeEditor.TabIndex = 0;
            this.codeEditor.Text = "";
            this.codeEditor.WordWrap = false;
            this.codeEditor.TextChanged += new System.EventHandler(this.OnCodeChanged);
            this.codeEditor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnCodeEditorKeyUp);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon) (resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "mHosts.Net正在运行";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnTrayIconDoubleClick);
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.trayIconMenu.Name = "trayIconMenu";
            this.trayIconMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // processRefreshDNS
            // 
            this.processRefreshDNS.StartInfo.Arguments = "/flushdns";
            this.processRefreshDNS.StartInfo.CreateNoWindow = true;
            this.processRefreshDNS.StartInfo.Domain = "";
            this.processRefreshDNS.StartInfo.FileName = "ipconfig";
            this.processRefreshDNS.StartInfo.LoadUserProfile = false;
            this.processRefreshDNS.StartInfo.Password = null;
            this.processRefreshDNS.StartInfo.RedirectStandardError = true;
            this.processRefreshDNS.StartInfo.RedirectStandardOutput = true;
            this.processRefreshDNS.StartInfo.StandardErrorEncoding = null;
            this.processRefreshDNS.StartInfo.StandardOutputEncoding = null;
            this.processRefreshDNS.StartInfo.UserName = "";
            this.processRefreshDNS.StartInfo.UseShellExecute = false;
            this.processRefreshDNS.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            this.processRefreshDNS.SynchronizingObject = this;
            // 
            // codeEditorContextMenu
            // 
            this.codeEditorContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.codeEditorContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.editorContextMenuSelectAll, this.复制ToolStripMenuItem, this.剪切ToolStripMenuItem, this.粘贴ToolStripMenuItem});
            this.codeEditorContextMenu.Name = "codeEditorContextMenu";
            this.codeEditorContextMenu.Size = new System.Drawing.Size(166, 100);
            // 
            // editorContextMenuSelectAll
            // 
            this.editorContextMenuSelectAll.Name = "editorContextMenuSelectAll";
            this.editorContextMenuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.editorContextMenuSelectAll.Size = new System.Drawing.Size(165, 24);
            this.editorContextMenuSelectAll.Text = "全选";
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.复制ToolStripMenuItem.Text = "复制";
            // 
            // 剪切ToolStripMenuItem
            // 
            this.剪切ToolStripMenuItem.Name = "剪切ToolStripMenuItem";
            this.剪切ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.剪切ToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.剪切ToolStripMenuItem.Text = "剪切";
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys) ((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(165, 24);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (134)));
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mHosts.Net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.codeEditorContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RichTextBox codeEditor;
        private System.Windows.Forms.ContextMenuStrip codeEditorContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editorContextMenuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.TreeView hostsTree;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem menuItemCheckUpdate;
        private System.Windows.Forms.ToolStripMenuItem menuItemConfig;
        private System.Windows.Forms.ToolStripMenuItem menuItemDoc;
        private System.Diagnostics.Process processRefreshDNS;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelHostsCount;
        private System.Windows.Forms.ToolStripMenuItem toolMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem 导入IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 剪切ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;

        #endregion
    }
}

