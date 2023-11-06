namespace AddinRibbon.Ctr
{
    partial class UcUpdate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btUpdate = new System.Windows.Forms.Button();
            this.cbAutoUpdate = new System.Windows.Forms.CheckBox();
            this.cbPause = new System.Windows.Forms.CheckBox();
            this.btClearLog = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btUpdate
            // 
            this.btUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.btUpdate.Location = new System.Drawing.Point(0, 0);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(369, 23);
            this.btUpdate.TabIndex = 0;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.button1_Click);
            this.btUpdate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btUpdate_MouseUp);
            // 
            // cbAutoUpdate
            // 
            this.cbAutoUpdate.AutoSize = true;
            this.cbAutoUpdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbAutoUpdate.Location = new System.Drawing.Point(0, 23);
            this.cbAutoUpdate.Name = "cbAutoUpdate";
            this.cbAutoUpdate.Size = new System.Drawing.Size(369, 17);
            this.cbAutoUpdate.TabIndex = 1;
            this.cbAutoUpdate.Text = "Auto Update";
            this.cbAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // cbPause
            // 
            this.cbPause.AutoSize = true;
            this.cbPause.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbPause.Location = new System.Drawing.Point(0, 40);
            this.cbPause.Name = "cbPause";
            this.cbPause.Size = new System.Drawing.Size(369, 17);
            this.cbPause.TabIndex = 2;
            this.cbPause.Text = "Pause";
            this.cbPause.UseVisualStyleBackColor = true;
            this.cbPause.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // btClearLog
            // 
            this.btClearLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btClearLog.Location = new System.Drawing.Point(0, 528);
            this.btClearLog.Name = "btClearLog";
            this.btClearLog.Size = new System.Drawing.Size(369, 23);
            this.btClearLog.TabIndex = 4;
            this.btClearLog.Text = "Clear Log";
            this.btClearLog.UseVisualStyleBackColor = true;
            this.btClearLog.Click += new System.EventHandler(this.button1_Click_1);
            this.btClearLog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btClearLog_MouseUp);
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(0, 57);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.Size = new System.Drawing.Size(369, 471);
            this.tbLog.TabIndex = 5;
            this.tbLog.Text = "Monitoring models....\r\n";
            // 
            // UcUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btClearLog);
            this.Controls.Add(this.cbPause);
            this.Controls.Add(this.cbAutoUpdate);
            this.Controls.Add(this.btUpdate);
            this.Name = "UcUpdate";
            this.Size = new System.Drawing.Size(369, 551);
            this.Load += new System.EventHandler(this.UcUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.CheckBox cbAutoUpdate;
        private System.Windows.Forms.CheckBox cbPause;
        private System.Windows.Forms.Button btClearLog;
        private System.Windows.Forms.TextBox tbLog;
    }
}
