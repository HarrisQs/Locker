﻿namespace LockerAnnouncer
{
    partial class LockerAnnouncer
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockerAnnouncer));
            this.ConnectStatus = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.GroupNameComboBox = new System.Windows.Forms.ComboBox();
            this.GroupNameLabel = new System.Windows.Forms.Label();
            this.ComputerNameLabel = new System.Windows.Forms.Label();
            this.ComputerNameComboBox = new System.Windows.Forms.ComboBox();
            this.actionLabel = new System.Windows.Forms.Label();
            this.ActionComboBox = new System.Windows.Forms.ComboBox();
            this.CMDlabel = new System.Windows.Forms.Label();
            this.CMDtextBox = new System.Windows.Forms.TextBox();
            this.EnterButton = new System.Windows.Forms.Button();
            this.Reconnect = new System.Windows.Forms.Timer(this.components);
            this.IsConnect = new System.Windows.Forms.Timer(this.components);
            this.ResetButton = new System.Windows.Forms.Button();
            this.ConnectStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectStatus
            // 
            this.ConnectStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.ConnectStatus.Location = new System.Drawing.Point(0, 139);
            this.ConnectStatus.Name = "ConnectStatus";
            this.ConnectStatus.Size = new System.Drawing.Size(407, 22);
            this.ConnectStatus.TabIndex = 0;
            this.ConnectStatus.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(81, 17);
            this.Status.Text = "Connecting...";
            this.Status.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            // 
            // GroupNameComboBox
            // 
            this.GroupNameComboBox.FormattingEnabled = true;
            this.GroupNameComboBox.Items.AddRange(new object[] {
            "圖書館",
            "電腦教室"});
            this.GroupNameComboBox.Location = new System.Drawing.Point(138, 14);
            this.GroupNameComboBox.Name = "GroupNameComboBox";
            this.GroupNameComboBox.Size = new System.Drawing.Size(121, 20);
            this.GroupNameComboBox.TabIndex = 1;
            this.GroupNameComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupNameComboBox_SelectedIndexChanged);
            // 
            // GroupNameLabel
            // 
            this.GroupNameLabel.AutoSize = true;
            this.GroupNameLabel.Font = new System.Drawing.Font("微軟正黑體", 9.25F, System.Drawing.FontStyle.Bold);
            this.GroupNameLabel.Location = new System.Drawing.Point(24, 17);
            this.GroupNameLabel.Name = "GroupNameLabel";
            this.GroupNameLabel.Size = new System.Drawing.Size(87, 17);
            this.GroupNameLabel.TabIndex = 2;
            this.GroupNameLabel.Text = "Group Name";
            // 
            // ComputerNameLabel
            // 
            this.ComputerNameLabel.AutoSize = true;
            this.ComputerNameLabel.Font = new System.Drawing.Font("微軟正黑體", 9.25F, System.Drawing.FontStyle.Bold);
            this.ComputerNameLabel.Location = new System.Drawing.Point(14, 48);
            this.ComputerNameLabel.Name = "ComputerNameLabel";
            this.ComputerNameLabel.Size = new System.Drawing.Size(110, 17);
            this.ComputerNameLabel.TabIndex = 3;
            this.ComputerNameLabel.Text = "Computer Name";
            // 
            // ComputerNameComboBox
            // 
            this.ComputerNameComboBox.FormattingEnabled = true;
            this.ComputerNameComboBox.Items.AddRange(new object[] {
            "5002",
            "5003",
            "5006",
            "60406"});
            this.ComputerNameComboBox.Location = new System.Drawing.Point(138, 48);
            this.ComputerNameComboBox.Name = "ComputerNameComboBox";
            this.ComputerNameComboBox.Size = new System.Drawing.Size(121, 20);
            this.ComputerNameComboBox.TabIndex = 4;
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Font = new System.Drawing.Font("微軟正黑體", 9.25F, System.Drawing.FontStyle.Bold);
            this.actionLabel.Location = new System.Drawing.Point(39, 78);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(49, 17);
            this.actionLabel.TabIndex = 5;
            this.actionLabel.Text = "Action";
            // 
            // ActionComboBox
            // 
            this.ActionComboBox.FormattingEnabled = true;
            this.ActionComboBox.Items.AddRange(new object[] {
            "Pass",
            "Restart",
            "Shutdown"});
            this.ActionComboBox.Location = new System.Drawing.Point(138, 78);
            this.ActionComboBox.Name = "ActionComboBox";
            this.ActionComboBox.Size = new System.Drawing.Size(121, 20);
            this.ActionComboBox.TabIndex = 6;
            // 
            // CMDlabel
            // 
            this.CMDlabel.AutoSize = true;
            this.CMDlabel.Font = new System.Drawing.Font("微軟正黑體", 9.25F, System.Drawing.FontStyle.Bold);
            this.CMDlabel.Location = new System.Drawing.Point(14, 106);
            this.CMDlabel.Name = "CMDlabel";
            this.CMDlabel.Size = new System.Drawing.Size(107, 17);
            this.CMDlabel.TabIndex = 7;
            this.CMDlabel.Text = "CMD Command";
            // 
            // CMDtextBox
            // 
            this.CMDtextBox.Location = new System.Drawing.Point(138, 106);
            this.CMDtextBox.Name = "CMDtextBox";
            this.CMDtextBox.Size = new System.Drawing.Size(121, 22);
            this.CMDtextBox.TabIndex = 8;
            this.CMDtextBox.TextChanged += new System.EventHandler(this.CMDtextBox_TextChanged);
            // 
            // EnterButton
            // 
            this.EnterButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EnterButton.Location = new System.Drawing.Point(281, 20);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(100, 45);
            this.EnterButton.TabIndex = 9;
            this.EnterButton.Text = "Enter";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // Reconnect
            // 
            this.Reconnect.Interval = 5000;
            this.Reconnect.Tick += new System.EventHandler(this.Reconnect_Tick);
            // 
            // IsConnect
            // 
            this.IsConnect.Interval = 300000;
            this.IsConnect.Tick += new System.EventHandler(this.IsConnect_Tick);
            // 
            // ResetButton
            // 
            this.ResetButton.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ResetButton.Location = new System.Drawing.Point(281, 78);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(100, 45);
            this.ResetButton.TabIndex = 10;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // LockerAnnouncer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 161);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.CMDtextBox);
            this.Controls.Add(this.CMDlabel);
            this.Controls.Add(this.ActionComboBox);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.ComputerNameComboBox);
            this.Controls.Add(this.ComputerNameLabel);
            this.Controls.Add(this.GroupNameLabel);
            this.Controls.Add(this.GroupNameComboBox);
            this.Controls.Add(this.ConnectStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LockerAnnouncer";
            this.Text = "Locker Announcer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LockerAnnouncer_FormClosing);
            this.ConnectStatus.ResumeLayout(false);
            this.ConnectStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ConnectStatus;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.ComboBox GroupNameComboBox;
        private System.Windows.Forms.Label GroupNameLabel;
        private System.Windows.Forms.Label ComputerNameLabel;
        private System.Windows.Forms.ComboBox ComputerNameComboBox;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.ComboBox ActionComboBox;
        private System.Windows.Forms.Label CMDlabel;
        private System.Windows.Forms.TextBox CMDtextBox;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Timer Reconnect;
        private System.Windows.Forms.Timer IsConnect;
        private System.Windows.Forms.Button ResetButton;
    }
}

