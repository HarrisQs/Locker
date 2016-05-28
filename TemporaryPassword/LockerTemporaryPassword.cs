using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemporaryPassword
{
    public partial class TemporaryPasswordForm : Form
    {
        //string source = Convert.ToString(DateTime.Today);
        public TemporaryPasswordForm()
        {
            InitializeComponent();
        }

        private void Get_Button_Click(object sender, EventArgs e)//取得所選擇日期的臨時密碼
        {
            RichTextBoxConsole.AppendText(Convert.ToString(ChooseDate.Value.Date)
                + " : " + GetTemporaryPassword() + "\n");
        }

        private string GetTemporaryPassword()//計算臨時密碼
        {
            String source = Convert.ToString(ChooseDate.Value.Date);
            using (MD5 md5Hash = MD5.Create())
            {
                //創造臨時密碼
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(source));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 10; i < 14; i += 2)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}
