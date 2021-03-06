﻿namespace mHosts.Net.forms
{
    partial class NewHostsForm
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
            System.Windows.Forms.Label label3;
            this.radioLocalHosts = new System.Windows.Forms.RadioButton();
            this.radioOnlineHosts = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.inputHostsName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputHostsUrl = new System.Windows.Forms.TextBox();
            this.btnSaveHosts = new System.Windows.Forms.Button();
            this.chkAlwaysApply = new System.Windows.Forms.CheckBox();
            this.selectHostIcon = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radioLocalHosts
            // 
            this.radioLocalHosts.AutoSize = true;
            this.radioLocalHosts.Checked = true;
            this.radioLocalHosts.Location = new System.Drawing.Point(90, 25);
            this.radioLocalHosts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioLocalHosts.Name = "radioLocalHosts";
            this.radioLocalHosts.Size = new System.Drawing.Size(102, 24);
            this.radioLocalHosts.TabIndex = 0;
            this.radioLocalHosts.TabStop = true;
            this.radioLocalHosts.Text = "本地Hosts";
            this.radioLocalHosts.UseVisualStyleBackColor = true;
            this.radioLocalHosts.CheckedChanged += new System.EventHandler(this.OnHostsTypeChanged);
            // 
            // radioOnlineHosts
            // 
            this.radioOnlineHosts.AutoSize = true;
            this.radioOnlineHosts.Location = new System.Drawing.Point(273, 25);
            this.radioOnlineHosts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioOnlineHosts.Name = "radioOnlineHosts";
            this.radioOnlineHosts.Size = new System.Drawing.Size(102, 24);
            this.radioOnlineHosts.TabIndex = 1;
            this.radioOnlineHosts.Text = "在线Hosts";
            this.radioOnlineHosts.UseVisualStyleBackColor = true;
            this.radioOnlineHosts.CheckedChanged += new System.EventHandler(this.OnHostsTypeChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "名称";
            // 
            // inputHostsName
            // 
            this.inputHostsName.Location = new System.Drawing.Point(98, 90);
            this.inputHostsName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputHostsName.Name = "inputHostsName";
            this.inputHostsName.Size = new System.Drawing.Size(352, 27);
            this.inputHostsName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(45, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "URL";
            // 
            // inputHostsUrl
            // 
            this.inputHostsUrl.Enabled = false;
            this.inputHostsUrl.Location = new System.Drawing.Point(98, 146);
            this.inputHostsUrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputHostsUrl.Name = "inputHostsUrl";
            this.inputHostsUrl.Size = new System.Drawing.Size(352, 27);
            this.inputHostsUrl.TabIndex = 5;
            // 
            // btnSaveHosts
            // 
            this.btnSaveHosts.Location = new System.Drawing.Point(366, 264);
            this.btnSaveHosts.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveHosts.Name = "btnSaveHosts";
            this.btnSaveHosts.Size = new System.Drawing.Size(84, 31);
            this.btnSaveHosts.TabIndex = 6;
            this.btnSaveHosts.Text = "保存";
            this.btnSaveHosts.UseVisualStyleBackColor = true;
            this.btnSaveHosts.Click += new System.EventHandler(this.OnBtnSaveHostsClick);
            // 
            // chkAlwaysApply
            // 
            this.chkAlwaysApply.AutoSize = true;
            this.chkAlwaysApply.Location = new System.Drawing.Point(98, 264);
            this.chkAlwaysApply.Name = "chkAlwaysApply";
            this.chkAlwaysApply.Size = new System.Drawing.Size(91, 24);
            this.chkAlwaysApply.TabIndex = 7;
            this.chkAlwaysApply.Text = "总是生效";
            this.chkAlwaysApply.UseVisualStyleBackColor = true;
            // 
            // selectHostIcon
            // 
            this.selectHostIcon.AutoCompleteCustomSource.AddRange(new string[] {
            "logo",
            "aliyun",
            "chrome",
            "darwin",
            "database",
            "edge",
            "firefox",
            "java",
            "linux",
            "mysql",
            "postgresql",
            "python",
            "qq",
            "windows"});
            this.selectHostIcon.FormattingEnabled = true;
            this.selectHostIcon.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.selectHostIcon.Location = new System.Drawing.Point(98, 200);
            this.selectHostIcon.Name = "selectHostIcon";
            this.selectHostIcon.Size = new System.Drawing.Size(352, 28);
            this.selectHostIcon.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(45, 203);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(39, 20);
            label3.TabIndex = 9;
            label3.Text = "图标";
            // 
            // NewHostsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 324);
            this.Controls.Add(label3);
            this.Controls.Add(this.selectHostIcon);
            this.Controls.Add(this.chkAlwaysApply);
            this.Controls.Add(this.btnSaveHosts);
            this.Controls.Add(this.inputHostsUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputHostsName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioOnlineHosts);
            this.Controls.Add(this.radioLocalHosts);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewHostsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建Hosts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnSaveHosts;
        private System.Windows.Forms.CheckBox chkAlwaysApply;
        private System.Windows.Forms.TextBox inputHostsName;
        private System.Windows.Forms.TextBox inputHostsUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioLocalHosts;
        private System.Windows.Forms.RadioButton radioOnlineHosts;

        #endregion

        private System.Windows.Forms.ComboBox selectHostIcon;
    }
}