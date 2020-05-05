namespace mHosts.Net.forms
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.logTextarea = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // logTextarea
            // 
            this.logTextarea.BackColor = System.Drawing.Color.Black;
            this.logTextarea.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logTextarea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTextarea.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logTextarea.ForeColor = System.Drawing.Color.ForestGreen;
            this.logTextarea.Location = new System.Drawing.Point(0, 0);
            this.logTextarea.Multiline = true;
            this.logTextarea.Name = "logTextarea";
            this.logTextarea.ReadOnly = true;
            this.logTextarea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextarea.Size = new System.Drawing.Size(800, 450);
            this.logTextarea.TabIndex = 0;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logTextarea);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日志";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnLogFormClosed);
            this.Load += new System.EventHandler(this.OnLogFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logTextarea;
    }
}