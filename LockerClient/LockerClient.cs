﻿/**
 * 撰寫時間:2016/05/27
 * 作者:張弘瑜
 * 目標:做一個SignalR的登入客戶端(包含:斷線、重新連線、臨時密碼等情況)
 **/ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;
using System.Net.Http;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Diagnostics;

namespace LockerClient
{
    public partial class LockerClient : Form
    {
        private const string ServerURI = "http://localhost:8080/signalr";
        private IHubProxy HubProxy { get; set; }
        private HubConnection Connection { get; set; }
        private ToolTip CheckWarning = new ToolTip();//小提示
        //記錄Login畫面和螢幕的中心位置
        private int _LoginX = 0;
        private int _LoginY = 0;
        private int _ScreenCenterX = 0;
        private int _ScreenCenterY = 0;
        //使用者資訊
        private string _Memo;
        private string _IP;
        private string _Group;
        private string _HostName;
        private string _TockenID;

        internal LockerClient()
        {
            InitializeComponent();
            //UI設定
            //this.FormBorderStyle = FormBorderStyle.None;//把上放的列關掉
            this.Location = new Point(0, 0);//Form 出現在左上角
            this.BackColor = System.Drawing.Color.Black;//背景黑色
            this.Height = Screen.PrimaryScreen.Bounds.Height;//Form 的高
            this.Width = Screen.PrimaryScreen.Bounds.Width;//Form 的寬
            Login_pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;//Login AutoSize
            ConnectFailed_pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;//Success AutoSize
            ConnectFailed_pictureBox.Visible = false;
            Loading_pictureBox.Visible = false;
            Loading_pictureBox.BackColor = System.Drawing.Color.White;
            Account_textBox.Height = 33;
            Account_textBox.Width = 250;
            Password_textBox.Height = 33;
            Password_textBox.Width = 250;
            TemporaryPassword_textBox.Height = 33;
            TemporaryPassword_textBox.Width = 150;
            WarningMessage_label.Visible = false;
            Login_button.ForeColor = System.Drawing.Color.Silver;
            Detail_label.Text = "";
        }

        private void LockerClient_Load(object sender, EventArgs e)
        {
            //LOGIN畫面 的位置
            _ScreenCenterX = Screen.PrimaryScreen.Bounds.Width / 2;
            _ScreenCenterY = Screen.PrimaryScreen.Bounds.Height / 2;
            _LoginX = _ScreenCenterX - Login_pictureBox.Size.Width / 2;
            _LoginY = _ScreenCenterY - Login_pictureBox.Size.Height / 2;
            Login_pictureBox.Location = new Point(_LoginX, _LoginY);
            //帳號密碼登入的位置
            Account_label.Location = new Point(_ScreenCenterX - 211, _ScreenCenterY - 42);
            Password_label.Location = new Point(_ScreenCenterX - 211, _ScreenCenterY + 38);
            Account_textBox.Location = new Point(_ScreenCenterX - 97, _ScreenCenterY - 24);
            Password_textBox.Location = new Point(_ScreenCenterX - 97, _ScreenCenterY + 44);
            Login_button.Location = new Point(_ScreenCenterX - 78, _ScreenCenterY + 130);
            //載入畫面的位置
            Loading_pictureBox.Location = new Point(_ScreenCenterX - 65, _ScreenCenterY + 95);
            Loading_pictureBox.Visible = true;
            //登入失敗訊息的位置 
            WarningMessage_label.Location = new Point(_ScreenCenterX - 90, _ScreenCenterY + 95);
            // show services term
            Term_Checkbox.Location = new Point(_ScreenCenterX - 150, _ScreenCenterY + 200);
            ConnectServerandGetInfo();//取得電腦資訊 開始連線
        }

        private async void ConnectServerandGetInfo()//這裡使用同步 所以裡面的東西要先有才會繼續
        {
            string ResponseText;
            HttpClient client = new HttpClient();
            AccessCommand();//一些連線的初始化，和指令的接收
            try
            {
                await Connection.Start();//開始與Server連線
                _TockenID = Connection.ConnectionId;
                HttpResponseMessage response = await client.GetAsync("http://vls.yzu.edu.tw/cmd-utf8.asp");
                response.EnsureSuccessStatusCode();
                ResponseText = await response.Content.ReadAsStringAsync();
                dynamic ResponseJOSN = JObject.Parse(ResponseText);
                
                //電腦資訊
                _HostName = Dns.GetHostName();
                _IP = ResponseJOSN["yIP"];
                _Group = ResponseJOSN["yGroup"];
                _Memo = ResponseJOSN["yMemo"];
                Detail_label.Text = _HostName + "\n\r"
                                    + _IP + "\n\r"
                                    + _Group + "\n\r"
                                    + _TockenID + "\n\r"
                                    + _Memo ;
                if (CheckForInternetConnection())
                    Detail_label.Text += "Connecting";
                ConnectUI();
            }
            catch (Exception)//處理網路沒連上或是程式的利外狀況
            {
                DisconnectUI();
            }
         }

        private void Login_button_Click(object sender, EventArgs e)//送出帳號密碼時
        {
            WarningMessage_label.Visible = true;
            string s = Password_textBox.Text;
            s = s.Replace("%", "%25");
            s = s.Replace("+", "%2B");
            s = s.Replace(" ", "%20");
            s = s.Replace("/", "%2F");
            s = s.Replace("?", "%3F");
            s = s.Replace("#", "%23");
            s = s.Replace("&", "%26");
            s = s.Replace("=", "%3D");
            Password_textBox.Text = s;

            if (Account_textBox.Text == "" || (!Regex.IsMatch(Account_textBox.Text, @"^[_@.a-zA-Z0-9]*$")))//判斷是否有輸入帳號和是否有特殊自元
            {
                WarningMessage_label.Text = "Please enter your account.";
                Account_textBox.Text = "";
                Password_textBox.Text = "";
                Account_textBox.Focus();

            }
            else if (Password_textBox.Text == "")
            {

                WarningMessage_label.Text = "Please enter your password.";
                Password_textBox.Focus();

            }
            else
            {
                Account_textBox.Text = ClearString(Account_textBox.Text.ToString());
                Password_textBox.Text = ClearString(Password_textBox.Text.ToString());
                ValidateAccount();
            }

        }

        private void Term_Checkbox_CheckedChanged(object sender, EventArgs e)//更改CheckBox時給予警告
        { 
            if (!Term_Checkbox.Checked)//如果沒有同意條約的話
            { 
                CheckWarning.ToolTipTitle = "Warning";
                CheckWarning.ToolTipIcon = ToolTipIcon.Warning;
                CheckWarning.IsBalloon = true;
                CheckWarning.SetToolTip(Term_Checkbox, "This field is required.");
                CheckWarning.Show("This field is required.", Term_Checkbox, 5, Term_Checkbox.Height - 5);
            }
            else
            {
                CheckWarning.Hide(Term_Checkbox);
            }
        }

        private string ClearString(string originalString)//清理String
        {
            string pattern = "^(\r\n\t)*";
            string replacement = "";
            Regex rgx = new Regex(pattern);
            string result = rgx.Replace(originalString, replacement);
            return result;
        }

        private void ValidateAccount()//確認帳號是否正確
        {
            try
            {
                //去下列網站認證帳號密碼
                WebRequest request = WebRequest.Create("https://vls.yzu.edu.tw/auth-utf8.asp ");
                request.Method = "POST";
                string postData = "acc=" + Account_textBox.Text + 
                    "&pwd=" + Password_textBox.Text + 
                    "&tkid=" + _TockenID + 
                    "&gpn=" + _Group + 
                    "&cpn=" + _HostName;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                JObject json = JObject.Parse(responseFromServer);
                reader.Close();
                dataStream.Close();
                response.Close();
                //判斷是否驗證成功
                if (json["authentic"].ToString() == "1")
                {
                    this.Hide();
                }
                else 
                {
                    WarningMessage_label.Text = "登入失敗  Login Failed";
                    Loading_pictureBox.Visible = false;
                    Login_button.ForeColor = System.Drawing.Color.Black;
                    Account_textBox.Enabled = true;
                    Password_textBox.Enabled = true;
                    Account_textBox.ResetText();
                    Password_textBox.ResetText();
                    Account_textBox.Focus();
                }
            }
            catch (WebException)//無法認證帳號
            { 
                DisconnectUI();
            }

        }

        private void Account_textBox_KeyDown(object sender, KeyEventArgs e)//避免使用者一直按"Enter"
        {   
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                Password_textBox.Focus();
            }
        }

        private void Password_textBox_KeyDown(object sender, KeyEventArgs e)//避免使用者一直按"Enter"
        {
            if (Login_button.Visible == true)
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    Login_button.Focus();
                    Login_button_Click(sender, e);
                }
            }
        }

        private void DisconnectUI()//處理網路沒連上時UI的動作
        {
            //要隱藏和清除的東西
            Account_textBox.Text = "";
            Account_textBox.Visible = false;
            Account_label.Visible = false;
            Password_textBox.Text = "";
            Password_textBox.Visible = false;
            Password_label.Visible = false;
            WarningMessage_label.Visible = false;
            Login_button.Visible = false;
            Loading_pictureBox.Visible = false;
            //要出現的
            TemporaryPassword_textBox.Visible = true;
            TemporaryPassword_textBox.Location = new Point(_ScreenCenterX - 25, _ScreenCenterY + 44);
            EnterTempPassword_button.Visible = true;
            EnterTempPassword_button.Location = new Point(_ScreenCenterX - 78, _ScreenCenterY + 130);
            ConnectFailed_pictureBox.Visible = true;
            ConnectFailed_pictureBox.Location = new Point(_LoginX, _LoginY);
            this.BackColor = System.Drawing.Color.Orange;
            //每五秒重新連線
            Reconnect.Enabled = true;
            IsConnect.Enabled = false;
            if (Connection != null)
            {
                Connection.Stop();
                Connection.Dispose();
            }
        }

        private void ConnectUI()//處理網路沒連上時UI的動作
        {
            Reconnect.Enabled = false;//連上線後不用在繼續重新連了
            IsConnect.Enabled = true;//判斷有無斷線
            ConnectFailed_pictureBox.Visible = false;
            TemporaryPassword_textBox.Visible = false;
            EnterTempPassword_button.Visible = false;
            Login_button.ForeColor = System.Drawing.Color.Black;
            Login_button.Visible = true;
            Account_textBox.Enabled = true;
            Account_textBox.Visible = true;
            Account_label.Visible = true;
            Password_textBox.Enabled = true;
            Password_textBox.Visible = true;
            Password_label.Visible = true;
            Loading_pictureBox.Visible = false;
            this.BackColor = System.Drawing.Color.Black;
        }

        private bool ValidateTemporaryPassword(String UserEnter)//驗證臨時密碼
        {
            string source = Convert.ToString(DateTime.Today);
            using (MD5 md5Hash = MD5.Create())
            {
                //創造臨時密碼
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 10; i < 14; i += 2)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                //驗證臨時密碼
                if (sBuilder.ToString() == UserEnter)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void EnterTempPassword_button_Click(object sender, EventArgs e)//輸入臨時密碼
        {
            if (ValidateTemporaryPassword(ClearString(TemporaryPassword_textBox.Text))
                && TemporaryPassword_textBox.Text != "")
                this.Hide();
            else
            {
                WarningMessage_label.Visible = true;
                WarningMessage_label.Text = "Wrong Temporary Password.";
            }               
            TemporaryPassword_textBox.ResetText();
        }

        private void TemporaryPassword_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter && TemporaryPassword_textBox.Text != "")
                EnterTempPassword_button_Click(sender, e);
        }

        private void Term_Checkbox_Click(object sender, EventArgs e)
        {
            TermBox term = new TermBox();
            term.Show(); 
        }

        public static bool CheckForInternetConnection()//確認是否有連線
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void ReconnectCountdown_Tick(object sender, EventArgs e)
        {
            ConnectServerandGetInfo();
        }

        private void LockerClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            //視窗關閉後，斷線
            if (Connection != null)
            {
                Connection.Stop();
                Connection.Dispose();
            }
        }

        private void IsConnect_Tick(object sender, EventArgs e)
        {
            //每五分鍾確認一次是否有斷線
            ConnectServerandGetInfo();
        }

        private void AccessCommand()//一些連線的初始化，和指令的接收
        {
            //指令要在他連線的時候就跑過，以後才會執行
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("MyHub");
            HubProxy.On<String, String>("Pass", (GroupName, ComputerName) =>
                this.Invoke((Action)(() =>
                    ClientReceiving("Pass", "", GroupName, ComputerName)
                 ))
            );
            HubProxy.On<String, String>("Restart", (GroupName, ComputerName) =>
                this.Invoke((Action)(() =>
                    ClientReceiving("Restart", "", GroupName, ComputerName)
                 ))
            );
            HubProxy.On<String, String>("Shutdown", (GroupName, ComputerName) =>
                this.Invoke((Action)(() =>
                    ClientReceiving("Shutdown", "", GroupName, ComputerName)
                 ))
            );
            HubProxy.On<String, String, String>("CMDCommand", (CMD, GroupName, ComputerName) =>
                this.Invoke((Action)(() =>
                    ClientReceiving("CMDCommand", CMD, GroupName, ComputerName)
                 ))
            );
        
        }
        
        private void ClientReceiving(String action, String CMD, String GroupName, String ComputerName)
        {
            switch (action)
            {
                case "Pass":
                    if (GroupName == _Group && _HostName.IndexOf(ComputerName) >= 0)
                    {
                        Account_label.Text = "Pass";
                    }
                    break;
                case "Restart":
                    if (GroupName == _Group && _HostName.IndexOf(ComputerName) >= 0)
                    {
                        Process.Start("cmd.exe", @"/c shutdown -r -t 0");
                    }
                    break;
                case "Shutdown":
                    if (GroupName == _Group && _HostName.IndexOf(ComputerName) >= 0)
                    {
                        Process.Start("cmd.exe", @"/c shutdown -s -t 0");
                    }
                    break;
                case "CMDCommand":
                    if (GroupName == _Group && _HostName.IndexOf(ComputerName) >= 0)
                    {
                        Process.Start("cmd.exe", @CMD);
                    }
                    break;
            }

        }
    }
}
