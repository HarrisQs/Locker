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

namespace LockerClient
{
    public partial class LockerClient : Form
    {
        private const string ServerURI = "http://localhost:8080/signalr";
        private IHubProxy HubProxy { get; set; }
        private HubConnection Connection { get; set; }

        //記錄Login畫面和螢幕的中心位置
        private int Login_X = 0;
        private int Login_Y = 0;
        private int ScreenCenter_X = 0;
        private int ScreenCenter_Y = 0;

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
            LoginFailed_label.Visible = false;
            Login_button.ForeColor = System.Drawing.Color.Silver;
            Detail_label.Text = "";

        }

        private void LockerClient_Load(object sender, EventArgs e)
        {
            //LOGIN畫面 的位置
            ScreenCenter_X = Screen.PrimaryScreen.Bounds.Width / 2;
            ScreenCenter_Y = Screen.PrimaryScreen.Bounds.Height / 2;
            Login_X = ScreenCenter_X - Login_pictureBox.Size.Width / 2;
            Login_Y = ScreenCenter_Y - Login_pictureBox.Size.Height / 2;
            Login_pictureBox.Location = new Point(Login_X, Login_Y);
            //帳號密碼登入的位置
            Account_label.Location = new Point(ScreenCenter_X - 211, ScreenCenter_Y - 42);
            Password_label.Location = new Point(ScreenCenter_X - 211, ScreenCenter_Y + 38);
            Account_textBox.Location = new Point(ScreenCenter_X - 97, ScreenCenter_Y - 24);
            Password_textBox.Location = new Point(ScreenCenter_X - 97, ScreenCenter_Y + 44);
            Login_button.Location = new Point(ScreenCenter_X - 78, ScreenCenter_Y + 130);
            //載入畫面的位置
            Loading_pictureBox.Location = new Point(ScreenCenter_X - 65, ScreenCenter_Y + 95);
            Loading_pictureBox.Visible = true;
            //登入失敗訊息的位置 
            LoginFailed_label.Location = new Point(ScreenCenter_X - 90, ScreenCenter_Y + 95);
            // show services term
            Term_Checkbox.Location = new Point(ScreenCenter_X - 150, ScreenCenter_Y + 200);

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
        private async void ConnectAsync()
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
            }
            catch (HttpRequestException)
            {
                //Fail connection
                return;
            }

        }

    }
}
