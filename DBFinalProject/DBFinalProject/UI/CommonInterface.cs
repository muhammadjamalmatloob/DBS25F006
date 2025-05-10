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
            string total_acc = "";
            decimal balance = 0;
            username = MainInterface.UserName;
            int user_id = DL.UserDL.get_user_id(username);
            int client_id = DL.ClientDL.getClientIdbyUserId(user_id);
            total_acc = DL.AccountDL.TotalAccountForSpecificClient(client_id);
            label1.Text = username;
            label6.Text = total_acc;
            Thread.Sleep(2000);
            label1.Text = "*******";
            label6.Text = "*******";
        }

        private void kryptonComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox1.Text == "Enter Account Number")
            {
                kryptonTextBox1.Text = "";
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Enter Account Number";
            }
        }

        private void CommonInterface_Load(object sender, EventArgs e)
        {

        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            GrpDep.Visible = false;
        }

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            try
            {
                string acc_num = kryptonTextBox1.Text;
                decimal balance = DL.AccountDL.getBalanceByNumber(acc_num);
                kryptonTextBox2.Text += balance.ToString();
                Thread.Sleep(2000);
                kryptonTextBox1.Text = "Enter Account Number";
                kryptonTextBox2.Text = "balance: ";

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            GrpDep.Visible = true;
        }
    }
}
