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
                Status.Text = "Connected";
            }
            catch (HttpRequestException)
            {     
            }
        }

        private void Reconnect_Tick(object sender, EventArgs e)//每五秒重新連線的倒數
        {
            ConnectServer();
        }

        private void IsConnect_Tick(object sender, EventArgs e)
        {
            //每五分鍾確認一次是否有斷線
            ConnectServerandGetInfo();
        }
    }
}
