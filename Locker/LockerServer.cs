using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;


[assembly: OwinStartup(typeof(Locker.LockerServer.Startup))]
namespace Locker
{
    public partial class LockerServer : Form
    {
        private IDisposable SignalR { get; set; }
        const string ServerURI = "http://127.0.0.1:8080";

        internal LockerServer()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            WriteToConsole("Starting server...");
            ButtonStart.Enabled = false;
            Task.Run(() => StartServer());
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            //SignalR will be disposed in the FormClosing event
            Close();
        }

        private void StartServer()
        {
            try
            {
                SignalR = WebApp.Start(ServerURI);
            }
            catch (TargetInvocationException)
            {
                WriteToConsole("Server failed to start. A server is already running on " + ServerURI);
                //Re-enable button to let user try to start server again
                this.Invoke((Action)(() => ButtonStart.Enabled = true));
                return;
            }
            this.Invoke((Action)(() => ButtonStop.Enabled = true));
            WriteToConsole("Server started at " + ServerURI);
        }

        internal void WriteToConsole(String message)
        {
            if (RichTextBoxConsole.InvokeRequired)
            {
                this.Invoke((Action)(() =>
                    WriteToConsole(message)
                ));
                return;
            }
            RichTextBoxConsole.AppendText(message + Environment.NewLine);
        }

       private void LockerServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SignalR != null)
            {
                SignalR.Dispose();
            }
        }

       public class Startup//啟動Server
       {
           public void Configuration(IAppBuilder app)
           {

               app.UseCors(CorsOptions.AllowAll);
               app.MapSignalR();
           }
       }
       
        public class MyHub : Hub//當別人連進來時所做的動作
        {
            public void Send(string name, string message)
            {
                Clients.All.addMessage(name, message);
            }
            public override Task OnConnected()
            {
                Program.MainForm.WriteToConsole("Client connected: " + Context.ConnectionId);
                return base.OnConnected();
            }
            public override Task OnDisconnected(bool stopCalled)
            {
                Program.MainForm.WriteToConsole("Client disconnected: " + Context.ConnectionId);
                return base.OnDisconnected(true);
            }
        }

        
    }
}
