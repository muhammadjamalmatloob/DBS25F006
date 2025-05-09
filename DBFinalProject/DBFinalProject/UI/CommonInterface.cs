using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFinalProject
{
    public partial class CommonInterface : UserControl
    {
        public CommonInterface()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string username="";
            string account_num = "";
            decimal balance = 0;
            username = MainInterface.UserName;
            label1.Text = username;
            label6.Text = account_num;
            balance = DL.AccountDL.getBalanceByNumber(account_num);
            label2.Text = balance.ToString();
            Thread.Sleep(2000);
            label1.Text = "*******";
            label6.Text = "*******";
            label2.Text = "*******";
        }
    }
}
