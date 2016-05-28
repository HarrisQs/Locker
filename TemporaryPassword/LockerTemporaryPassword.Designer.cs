namespace TemporaryPassword
{
    partial class TemporaryPasswordForm
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
            this.Get_Button = new System.Windows.Forms.Button();
            this.RichTextBoxConsole = new System.Windows.Forms.RichTextBox();
            this.ChooseDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // Get_Button
            // 
            this.Get_Button.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Get_Button.Location = new System.Drawing.Point(259, 12);
            this.Get_Button.Name = "Get_Button";
            this.Get_Button.Size = new System.Drawing.Size(175, 31);
            this.Get_Button.TabIndex = 2;
            this.Get_Button.Text = "取得臨時密碼";
            this.Get_Button.UseVisualStyleBackColor = true;
            this.Get_Button.Click += new System.EventHandler(this.Get_Button_Click);
            // 
            // RichTextBoxConsole
            // 
            this.RichTextBoxConsole.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold);
            this.RichTextBoxConsole.Location = new System.Drawing.Point(2, 51);
            this.RichTextBoxConsole.Name = "RichTextBoxConsole";
            this.RichTextBoxConsole.ReadOnly = true;
            this.RichTextBoxConsole.Size = new System.Drawing.Size(445, 278);
            this.RichTextBoxConsole.TabIndex = 5;
            this.RichTextBoxConsole.Text = "";
            // 
            // ChooseDate
            // 
            this.ChooseDate.CalendarFont = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ChooseDate.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ChooseDate.Location = new System.Drawing.Point(26, 12);
            this.ChooseDate.Name = "ChooseDate";
            this.ChooseDate.Size = new System.Drawing.Size(200, 33);
            this.ChooseDate.TabIndex = 6;
            // 
            // TemporaryPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 325);
            this.Controls.Add(this.ChooseDate);
            this.Controls.Add(this.RichTextBoxConsole);
            this.Controls.Add(this.Get_Button);
            this.Name = "TemporaryPasswordForm";
            this.Text = "Temporary Password";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Get_Button;
        private System.Windows.Forms.RichTextBox RichTextBoxConsole;
        private System.Windows.Forms.DateTimePicker ChooseDate;
    }
}

