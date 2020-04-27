namespace mHosts.Net.forms
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.settingTabGeneral = new System.Windows.Forms.TabPage();
            this.settingTabBrowser = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.settingTabGeneral);
            this.tabControl1.Controls.Add(this.settingTabBrowser);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(713, 508);
            this.tabControl1.TabIndex = 0;
            // 
            // settingTabGeneral
            // 
            this.settingTabGeneral.Location = new System.Drawing.Point(4, 25);
            this.settingTabGeneral.Name = "settingTabGeneral";
            this.settingTabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.settingTabGeneral.Size = new System.Drawing.Size(705, 479);
            this.settingTabGeneral.TabIndex = 0;
            this.settingTabGeneral.Text = "通用";
            this.settingTabGeneral.UseVisualStyleBackColor = true;
            // 
            // settingTabBrowser
            // 
            this.settingTabBrowser.Location = new System.Drawing.Point(4, 25);
            this.settingTabBrowser.Name = "settingTabBrowser";
            this.settingTabBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.settingTabBrowser.Size = new System.Drawing.Size(705, 479);
            this.settingTabBrowser.TabIndex = 1;
            this.settingTabBrowser.Text = "浏览器设置";
            this.settingTabBrowser.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 508);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage settingTabGeneral;
        private System.Windows.Forms.TabPage settingTabBrowser;
    }
}