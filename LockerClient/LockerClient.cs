/**
 * 撰寫時間:2015/02/07
 * 作者:張弘瑜
 * 目標:做一個SignalR的登入客戶端
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

            ConnectAsync();//開始連線
            /**  找IP
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());

            //show IP 

            foreach (IPAddress addr in localIPs)
            {

                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    Detail_label.Text = Detail_label.Text + addr.ToString();
                }
            }
             * */

        }
        private async void ConnectAsync()//與Server連線
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("MyHub");
            //Handle incoming event from server: use Invoke to write to console from SignalR's thread
            /*HubProxy.On<string, string>("AddMessage", (name, message) =>
                this.Invoke((Action)(() =>
                    RichTextBoxConsole.AppendText(String.Format("{0}: {1}" + Environment.NewLine, name, message))
                ))
            );*/
            try
            {
                await Connection.Start();
                Login_button.ForeColor = System.Drawing.Color.Black;
                Loading_pictureBox.Visible = false;
            }
            catch (HttpRequestException)
            {
                //Fail connection
                return;
            }

        }

        private void Login_button_Click(object sender, EventArgs e)
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

            //if (Password_textBox.Text == "%3F")//如果密碼輸入問號 出現一些關於這台電腦的資訊
            //{

            //    DateTime fileCreatedDate = File.GetCreationTime(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            //    //DateTime fileCreatedDate = File.GetCreationTime(@"LoginForm.exe");
            //    //String strHostName2 = Dns.GetHostName();//
            //    // 取得本機的 IpHostEntry 類別實體
            //    //IPHostEntry iphostentry = Dns.GetHostEntry(strHostName2);

            //    label1.Text = "";
            //    label1.Text = _strHostName;
            //    label1.Text += "\n\r" + DateTime.Now;
            //    label1.Text += "\n\r" + tmpURI;//
            //    label1.Text += "\n\r" + fileCreatedDate.ToString();
            //    label1.Text += "\n\r" + _strTmpTKID;//

            //    if (CheckForInternetConnection())
            //    {
            //        label1.Text += "\n\r" + "Google ok";
            //    }

            //}

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
                CheckFunction();
            }

        }

        private void Term_Checkbox_CheckedChanged(object sender, EventArgs e)
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

        private void CheckFunction()
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
                    //Check = true;

             //   AdditionalCheckFunction(Check);
            }
            catch (WebException)
            {
                //// if is Network is ok but Auth isdown 
                //Account_textBox.Text = "";
                //Password_textBox.Text = "";
                //LoginFailed_label.Visible = false;
                //TemporaryPassword_textBox.Visible = true;
                //TemporaryPassword_textBox.Location = new Point(_ScreenCenterX - 25, _ScreenCenterY + 44);
                //Enter_button.Visible = true;
                //Enter_button.Location = new Point(_ScreenCenterX - 78, _ScreenCenterY + 130);
                //ConnectFailed_pictureBox.Visible = true;
                //ConnectFailed_pictureBox.Location = new Point(_LoginX, _LoginY);
                //timer1.Enabled = true;
                //return;
            }

        }
    }
}
