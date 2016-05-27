using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockerClient
{
    public partial class TermBox : Form
    {
        public TermBox()
        {
            InitializeComponent();
            this.Text = String.Format("{0}", "隱私權與資訊安全政策");
        }

        private void TermBox_Load(object sender, EventArgs e)//載入資訊安全政策
        {
            string tmpWebURL = @"http://vls.yzu.edu.tw/pim-utf8.asp";  //預設網址
            this.webBrowser1.Navigate(tmpWebURL);
        }

        private void okButton_Click(object sender, EventArgs e)//按OK
        {
            this.Close();
        }

        
    }
}
