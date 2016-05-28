/**
 * 撰寫時間:2016/05/28
 * 作者:張弘瑜
 * 目標:做一個SignalR的發號司令客戶端(包含:自動通過、關機等情況)
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
using System.Net.Http;
using Microsoft.AspNet.SignalR.Client;

namespace LockerAnnouncer
{
    public partial class LockerAnnouncer : Form
    {
        private IHubProxy HubProxy { get; set; }
        const string ServerURI = "http://localhost:8080/signalr";
        private HubConnection Connection { get; set; }
        public LockerAnnouncer()//初始化視窗
        {
            InitializeComponent();
            ConnectServer();
        }

        private async void ConnectServer()//與伺服器連線
        {
            Connection = new HubConnection(ServerURI);
            HubProxy = Connection.CreateHubProxy("MyHub");
            try
            {
                await Connection.Start();
                ConnectUI();
            }
            catch (HttpRequestException)
            {
                DisconnectUI();
            }
        }
        private void ConnectUI()//處理網路沒連上時UI的動作
        {
            Status.Text = "Connected";
            Reconnect.Enabled = false;//連上線後不用在繼續重新連了
            IsConnect.Enabled = true;//判斷有無斷線
        }
        private void DisconnectUI()//處理網路沒連上時UI的動作
        {
            Status.Text = "Disconnected";
            Reconnect.Enabled = true;//每五秒重新連線
            IsConnect.Enabled = false;//停止判斷有無斷線
        }
        private void Reconnect_Tick(object sender, EventArgs e)//每五秒重新連線的倒數
        {
            ConnectServer();
        }

        private void IsConnect_Tick(object sender, EventArgs e)
        {
            //每五分鍾確認一次是否有斷線
            ConnectServer();
        }

        private void LockerAnnouncer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //視窗關閉後，斷線
            Connection.Stop();
            Connection.Dispose();
        }
    }
}
