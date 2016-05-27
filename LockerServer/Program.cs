using System;
using System.Windows.Forms;

namespace LockerServer
{
    public static class Program
    {
        internal static LockerServer MainForm { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new LockerServer();
            Application.Run(MainForm);
        }
    }
}
