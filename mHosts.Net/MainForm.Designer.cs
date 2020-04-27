namespace mHosts.Net
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusTextHostsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.首选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.检查更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hostsTree = new System.Windows.Forms.TreeView();
            this.codeEditor = new System.Windows.Forms.RichTextBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuToggleMainForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuNewHosts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuChrome = new System.Windows.Forms.ToolStripMenuItem();
            this.googleChromeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microsoftEdgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuRefreshDNS = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.trayMenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.processRefreshDNS = new System.Diagnostics.Process();
            this.toolMenu = new System.Windows.Forms.ToolStripMenuItem();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.trayIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(223, 24);
            toolStripStatusLabel1.Text = "编辑自动保存，双击应用到系统";
            // 
            // statusBar
            // 
            this.statusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusBar.Location = new System.Drawing.Point(0, 578);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusBar.Size = new System.Drawing.Size(900, 22);
            this.statusBar.TabIndex = 0;
            // 
            // statusTextHostsCount
            // 
            this.statusTextHostsCount.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.statusTextHostsCount.Name = "statusTextHostsCount";
            this.statusTextHostsCount.Size = new System.Drawing.Size(114, 24);
            this.statusTextHostsCount.Text = "当前共几个规则";
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.helpMenu,
            this.toolMenu});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuBar.Size = new System.Drawing.Size(900, 30);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripMenuItem,
            this.导入IToolStripMenuItem,
            this.toolStripSeparator4,
            this.退出EToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(71, 24);
            this.fileMenu.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.新建NToolStripMenuItem.Text = "新建(&N)";
            this.新建NToolStripMenuItem.Click += new System.EventHandler(this.OnMenuItemNewHostsClick);
            // 
            // 导入IToolStripMenuItem
            // 
            this.导入IToolStripMenuItem.Name = "导入IToolStripMenuItem";
            this.导入IToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.导入IToolStripMenuItem.Text = "导入(&I)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            this.退出EToolStripMenuItem.Click += new System.EventHandler(this.OnExitMenuItemClick);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.首选项ToolStripMenuItem,
            this.menuItemDoc,
            this.检查更新ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(75, 24);
            this.helpMenu.Text = "帮助(&H)";
            // 
            // 首选项ToolStripMenuItem
            // 
            this.首选项ToolStripMenuItem.Name = "首选项ToolStripMenuItem";
            this.首选项ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.首选项ToolStripMenuItem.Text = "首选项";
            this.首选项ToolStripMenuItem.Click += new System.EventHandler(this.OnMenuItemConfigClick);
            // 
            // menuItemDoc
            // 
            this.menuItemDoc.Name = "menuItemDoc";
            this.menuItemDoc.Size = new System.Drawing.Size(152, 26);
            this.menuItemDoc.Text = "帮助文档";
            this.menuItemDoc.Click += new System.EventHandler(this.OnMenuItemDocClick);
            // 
            // 检查更新ToolStripMenuItem
            // 
            this.检查更新ToolStripMenuItem.Name = "检查更新ToolStripMenuItem";
            this.检查更新ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.检查更新ToolStripMenuItem.Text = "检查更新";
            this.检查更新ToolStripMenuItem.Click += new System.EventHandler(this.OnMenuItemCheckUpdateClick);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.OnAboutMenuItemClick);
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
            this.splitContainer1.Size = new System.Drawing.Size(900, 548);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.TabIndex = 2;
            // 
            // hostsTree
            // 
            this.hostsTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hostsTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hostsTree.HotTracking = true;
            this.hostsTree.Location = new System.Drawing.Point(0, 0);
            this.hostsTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hostsTree.Name = "hostsTree";
            this.hostsTree.Size = new System.Drawing.Size(299, 548);
            this.hostsTree.TabIndex = 0;
            this.hostsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnTreeNodeSelect);
            this.hostsTree.DoubleClick += new System.EventHandler(this.OnHostDoubleClick);
            // 
            // codeEditor
            // 
            this.codeEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEditor.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEditor.Location = new System.Drawing.Point(0, 0);
            this.codeEditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.codeEditor.Name = "codeEditor";
            this.codeEditor.Size = new System.Drawing.Size(597, 548);
            this.codeEditor.TabIndex = 0;
            this.codeEditor.Text = "";
            this.codeEditor.TextChanged += new System.EventHandler(this.OnCodeChanged);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayIconMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "mHosts.Net正在运行";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnTrayIconDoubleClick);
            // 
            // trayIconMenu
            // 
            this.trayIconMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.trayIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.trayMenuToggleMainForm,
            this.toolStripSeparator2,
            this.trayMenuNewHosts,
            this.toolStripSeparator1,
            this.trayMenuChrome,
            this.trayMenuRefreshDNS,
            this.toolStripSeparator3,
            this.trayMenuAbout,
            this.trayMenuExit});
            this.trayIconMenu.Name = "trayIconMenu";
            this.trayIconMenu.Size = new System.Drawing.Size(190, 190);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(189, 24);
            this.toolStripTextBox1.Text = "mHosts.Net";
            // 
            // trayMenuToggleMainForm
            // 
            this.trayMenuToggleMainForm.Name = "trayMenuToggleMainForm";
            this.trayMenuToggleMainForm.Size = new System.Drawing.Size(189, 24);
            this.trayMenuToggleMainForm.Text = "显示/隐藏主窗口";
            this.trayMenuToggleMainForm.Click += new System.EventHandler(this.OnToggleMenuItemClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(186, 6);
            // 
            // trayMenuNewHosts
            // 
            this.trayMenuNewHosts.Name = "trayMenuNewHosts";
            this.trayMenuNewHosts.Size = new System.Drawing.Size(189, 24);
            this.trayMenuNewHosts.Text = "新建Hosts规则";
            this.trayMenuNewHosts.Click += new System.EventHandler(this.OnMenuItemNewHostsClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // trayMenuChrome
            // 
            this.trayMenuChrome.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.googleChromeToolStripMenuItem,
            this.microsoftEdgeToolStripMenuItem});
            this.trayMenuChrome.Name = "trayMenuChrome";
            this.trayMenuChrome.Size = new System.Drawing.Size(189, 24);
            this.trayMenuChrome.Text = "启动调试浏览器";
            // 
            // googleChromeToolStripMenuItem
            // 
            this.googleChromeToolStripMenuItem.Name = "googleChromeToolStripMenuItem";
            this.googleChromeToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.googleChromeToolStripMenuItem.Text = "Google Chrome";
            // 
            // microsoftEdgeToolStripMenuItem
            // 
            this.microsoftEdgeToolStripMenuItem.Name = "microsoftEdgeToolStripMenuItem";
            this.microsoftEdgeToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.microsoftEdgeToolStripMenuItem.Text = "Microsoft Edge";
            this.microsoftEdgeToolStripMenuItem.Click += new System.EventHandler(this.OnLaunchBrowser);
            // 
            // trayMenuRefreshDNS
            // 
            this.trayMenuRefreshDNS.Name = "trayMenuRefreshDNS";
            this.trayMenuRefreshDNS.Size = new System.Drawing.Size(189, 24);
            this.trayMenuRefreshDNS.Text = "刷新DNS缓存";
            this.trayMenuRefreshDNS.Click += new System.EventHandler(this.OnTrayMenuRefreshClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(186, 6);
            // 
            // trayMenuAbout
            // 
            this.trayMenuAbout.Name = "trayMenuAbout";
            this.trayMenuAbout.Size = new System.Drawing.Size(189, 24);
            this.trayMenuAbout.Text = "关于";
            this.trayMenuAbout.Click += new System.EventHandler(this.OnAboutMenuItemClick);
            // 
            // trayMenuExit
            // 
            this.trayMenuExit.Name = "trayMenuExit";
            this.trayMenuExit.Size = new System.Drawing.Size(189, 24);
            this.trayMenuExit.Text = "退出";
            this.trayMenuExit.Click += new System.EventHandler(this.OnExitMenuItemClick);
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
            // toolMenu
            // 
            this.toolMenu.Name = "toolMenu";
            this.toolMenu.Size = new System.Drawing.Size(72, 24);
            this.toolMenu.Text = "工具(&T)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuBar);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mHosts.Net";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.trayIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView hostsTree;
        private System.Windows.Forms.RichTextBox codeEditor;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem 首选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemDoc;
        private System.Windows.Forms.ToolStripMenuItem 检查更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusTextHostsCount;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayIconMenu;
        private System.Windows.Forms.ToolStripMenuItem trayMenuToggleMainForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem trayMenuExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem trayMenuNewHosts;
        private System.Windows.Forms.ToolStripMenuItem trayMenuChrome;
        private System.Windows.Forms.ToolStripMenuItem googleChromeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microsoftEdgeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trayMenuRefreshDNS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem trayMenuAbout;
        private System.Diagnostics.Process processRefreshDNS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolMenu;
    }
}

