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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.tabs = new System.Windows.Forms.TabControl();
            this.settingTabGeneral = new System.Windows.Forms.TabPage();
            this.settingTabTools = new System.Windows.Forms.TabPage();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.settingTabGeneral);
            this.tabs.Controls.Add(this.settingTabTools);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (134)));
            this.tabs.Location = new System.Drawing.Point(0, 0);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(713, 508);
            this.tabs.TabIndex = 0;
            // 
            // settingTabGeneral
            // 
            this.settingTabGeneral.Location = new System.Drawing.Point(4, 29);
            this.settingTabGeneral.Name = "settingTabGeneral";
            this.settingTabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.settingTabGeneral.Size = new System.Drawing.Size(705, 475);
            this.settingTabGeneral.TabIndex = 0;
            this.settingTabGeneral.Text = "通用";
            this.settingTabGeneral.UseVisualStyleBackColor = true;
            // 
            // settingTabTools
            // 
            this.settingTabTools.Location = new System.Drawing.Point(4, 29);
            this.settingTabTools.Name = "settingTabTools";
            this.settingTabTools.Padding = new System.Windows.Forms.Padding(3);
            this.settingTabTools.Size = new System.Drawing.Size(705, 475);
            this.settingTabTools.TabIndex = 1;
            this.settingTabTools.Text = "工具设置";
            this.settingTabTools.UseVisualStyleBackColor = true;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 508);
            this.Controls.Add(this.tabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.OnSettingFormLoad);
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabPage settingTabGeneral;
        private System.Windows.Forms.TabPage settingTabTools;
        internal System.Windows.Forms.TabControl tabs;

        #endregion
    }
}