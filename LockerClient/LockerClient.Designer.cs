namespace LockerClient
{
    partial class LockerClient
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
            this.Login_pictureBox = new System.Windows.Forms.PictureBox();
            this.ConnectFailed_pictureBox = new System.Windows.Forms.PictureBox();
            this.Loading_pictureBox = new System.Windows.Forms.PictureBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.Account_label = new System.Windows.Forms.Label();
            this.Account_textBox = new System.Windows.Forms.TextBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.EnterTempPassword_button = new System.Windows.Forms.Button();
            this.Term_Checkbox = new System.Windows.Forms.CheckBox();
            this.TemporaryPassword_textBox = new System.Windows.Forms.TextBox();
            this.WarningMessage_label = new System.Windows.Forms.Label();
            this.Login_button = new System.Windows.Forms.Button();
            this.Detail_label = new System.Windows.Forms.Label();
            this.Reconnect = new System.Windows.Forms.Timer(this.components);
            this.IsConnect = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Login_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectFailed_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Loading_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Login_pictureBox
            // 
            this.Login_pictureBox.Image = global::LockerClient.Properties.Resources.login;
            this.Login_pictureBox.Location = new System.Drawing.Point(12, 21);
            this.Login_pictureBox.Name = "Login_pictureBox";
            this.Login_pictureBox.Size = new System.Drawing.Size(100, 50);
            this.Login_pictureBox.TabIndex = 1;
            this.Login_pictureBox.TabStop = false;
            // 
            // ConnectFailed_pictureBox
            // 
            this.ConnectFailed_pictureBox.Image = global::LockerClient.Properties.Resources.login_failed;
            this.ConnectFailed_pictureBox.Location = new System.Drawing.Point(12, 90);
            this.ConnectFailed_pictureBox.Name = "ConnectFailed_pictureBox";
            this.ConnectFailed_pictureBox.Size = new System.Drawing.Size(100, 74);
            this.ConnectFailed_pictureBox.TabIndex = 10;
            this.ConnectFailed_pictureBox.TabStop = false;
            this.ConnectFailed_pictureBox.Visible = false;
            // 
            // Loading_pictureBox
            // 
            this.Loading_pictureBox.BackColor = System.Drawing.Color.White;
            this.Loading_pictureBox.Image = global::LockerClient.Properties.Resources.loading;
            this.Loading_pictureBox.Location = new System.Drawing.Point(12, 182);
            this.Loading_pictureBox.Name = "Loading_pictureBox";
            this.Loading_pictureBox.Size = new System.Drawing.Size(128, 15);
            this.Loading_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Loading_pictureBox.TabIndex = 11;
            this.Loading_pictureBox.TabStop = false;
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.BackColor = System.Drawing.Color.White;
            this.Password_label.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Password_label.ForeColor = System.Drawing.Color.Black;
            this.Password_label.Location = new System.Drawing.Point(25, 274);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(98, 48);
            this.Password_label.TabIndex = 12;
            this.Password_label.Text = "密碼\r\nPassword";
            // 
            // Account_label
            // 
            this.Account_label.AutoSize = true;
            this.Account_label.BackColor = System.Drawing.Color.White;
            this.Account_label.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Account_label.ForeColor = System.Drawing.Color.Black;
            this.Account_label.Location = new System.Drawing.Point(25, 210);
            this.Account_label.Name = "Account_label";
            this.Account_label.Size = new System.Drawing.Size(87, 48);
            this.Account_label.TabIndex = 13;
            this.Account_label.Text = "帳號\r\nAccount";
            // 
            // Account_textBox
            // 
            this.Account_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Account_textBox.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Account_textBox.Location = new System.Drawing.Point(138, 225);
            this.Account_textBox.Name = "Account_textBox";
            this.Account_textBox.Size = new System.Drawing.Size(100, 33);
            this.Account_textBox.TabIndex = 14;
            this.Account_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Account_textBox_KeyDown);
            // 
            // Password_textBox
            // 
            this.Password_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password_textBox.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Password_textBox.Location = new System.Drawing.Point(138, 289);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(100, 33);
            this.Password_textBox.TabIndex = 15;
            this.Password_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Password_textBox_KeyDown);
            // 
            // EnterTempPassword_button
            // 
            this.EnterTempPassword_button.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EnterTempPassword_button.ForeColor = System.Drawing.Color.Black;
            this.EnterTempPassword_button.Location = new System.Drawing.Point(52, 328);
            this.EnterTempPassword_button.Name = "EnterTempPassword_button";
            this.EnterTempPassword_button.Size = new System.Drawing.Size(172, 57);
            this.EnterTempPassword_button.TabIndex = 16;
            this.EnterTempPassword_button.Text = "Enter";
            this.EnterTempPassword_button.UseVisualStyleBackColor = true;
            this.EnterTempPassword_button.Visible = false;
            this.EnterTempPassword_button.Click += new System.EventHandler(this.EnterTempPassword_button_Click);
            // 
            // Term_Checkbox
            // 
            this.Term_Checkbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Term_Checkbox.AutoSize = true;
            this.Term_Checkbox.BackColor = System.Drawing.SystemColors.Window;
            this.Term_Checkbox.Checked = true;
            this.Term_Checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Term_Checkbox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Term_Checkbox.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Term_Checkbox.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Term_Checkbox.Location = new System.Drawing.Point(12, 422);
            this.Term_Checkbox.Name = "Term_Checkbox";
            this.Term_Checkbox.Size = new System.Drawing.Size(353, 20);
            this.Term_Checkbox.TabIndex = 17;
            this.Term_Checkbox.Text = "Yes,I have read this Agreement and agree to the terms.";
            this.Term_Checkbox.UseVisualStyleBackColor = false;
            this.Term_Checkbox.CheckedChanged += new System.EventHandler(this.Term_Checkbox_CheckedChanged);
            this.Term_Checkbox.Click += new System.EventHandler(this.Term_Checkbox_Click);
            // 
            // TemporaryPassword_textBox
            // 
            this.TemporaryPassword_textBox.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.TemporaryPassword_textBox.Location = new System.Drawing.Point(254, 250);
            this.TemporaryPassword_textBox.Name = "TemporaryPassword_textBox";
            this.TemporaryPassword_textBox.Size = new System.Drawing.Size(100, 33);
            this.TemporaryPassword_textBox.TabIndex = 18;
            this.TemporaryPassword_textBox.Visible = false;
            this.TemporaryPassword_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TemporaryPassword_textBox_KeyDown);
            // 
            // WarningMessage_label
            // 
            this.WarningMessage_label.AutoSize = true;
            this.WarningMessage_label.BackColor = System.Drawing.Color.White;
            this.WarningMessage_label.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.WarningMessage_label.ForeColor = System.Drawing.Color.DarkRed;
            this.WarningMessage_label.Location = new System.Drawing.Point(250, 225);
            this.WarningMessage_label.Name = "WarningMessage_label";
            this.WarningMessage_label.Size = new System.Drawing.Size(0, 24);
            this.WarningMessage_label.TabIndex = 19;
            // 
            // Login_button
            // 
            this.Login_button.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Login_button.ForeColor = System.Drawing.Color.Black;
            this.Login_button.Location = new System.Drawing.Point(274, 328);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(172, 57);
            this.Login_button.TabIndex = 20;
            this.Login_button.Text = "登入   Login";
            this.Login_button.UseVisualStyleBackColor = true;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // Detail_label
            // 
            this.Detail_label.AutoSize = true;
            this.Detail_label.Cursor = System.Windows.Forms.Cursors.No;
            this.Detail_label.Dock = System.Windows.Forms.DockStyle.Right;
            this.Detail_label.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Detail_label.ForeColor = System.Drawing.Color.Silver;
            this.Detail_label.Location = new System.Drawing.Point(437, 0);
            this.Detail_label.Name = "Detail_label";
            this.Detail_label.Size = new System.Drawing.Size(64, 24);
            this.Detail_label.TabIndex = 21;
            this.Detail_label.Text = "label1";
            // 
            // Reconnect
            // 
            this.Reconnect.Interval = 5000;
            this.Reconnect.Tick += new System.EventHandler(this.ReconnectCountdown_Tick);
            // 
            // IsConnect
            // 
            this.IsConnect.Interval = 300000;
            this.IsConnect.Tick += new System.EventHandler(this.IsConnect_Tick);
            // 
            // LockerClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 474);
            this.Controls.Add(this.Detail_label);
            this.Controls.Add(this.Login_button);
            this.Controls.Add(this.WarningMessage_label);
            this.Controls.Add(this.TemporaryPassword_textBox);
            this.Controls.Add(this.Term_Checkbox);
            this.Controls.Add(this.EnterTempPassword_button);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Account_textBox);
            this.Controls.Add(this.Account_label);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Loading_pictureBox);
            this.Controls.Add(this.ConnectFailed_pictureBox);
            this.Controls.Add(this.Login_pictureBox);
            this.Name = "LockerClient";
            this.Text = "Locker Clinet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LockerClient_FormClosing);
            this.Load += new System.EventHandler(this.LockerClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Login_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectFailed_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Loading_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Login_pictureBox;
        private System.Windows.Forms.PictureBox ConnectFailed_pictureBox;
        private System.Windows.Forms.PictureBox Loading_pictureBox;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.Label Account_label;
        private System.Windows.Forms.TextBox Account_textBox;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Button EnterTempPassword_button;
        private System.Windows.Forms.CheckBox Term_Checkbox;
        private System.Windows.Forms.TextBox TemporaryPassword_textBox;
        private System.Windows.Forms.Label WarningMessage_label;
        private System.Windows.Forms.Button Login_button;
        private System.Windows.Forms.Label Detail_label;
        private System.Windows.Forms.Timer Reconnect;
        private System.Windows.Forms.Timer IsConnect;




    }
}

