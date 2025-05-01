using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using DBFinalProject.BL;
using DBFinalProject.DL;
using Google.Protobuf.WellKnownTypes;

namespace DBFinalProject
{
    public partial class ClientDepositMoney : UserControl
    {
        public int client_id;
        public string acc_num;
        public decimal balance;
        public ClientDepositMoney(int client_id, string acc_num,decimal balance)
        {
            InitializeComponent();
            this.client_id = client_id;
            this.acc_num = acc_num;
            this.balance = balance;
        }

        private void ClientDepositMoney_Load(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox1_Enter(object sender, EventArgs e)
        {
        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void kryptonTextBox3_Leave(object sender, EventArgs e)
        {
            
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Amount")
            {
                kryptonTextBox1.Text = "";
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Amount";
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox2.Text == "PIN")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.PasswordChar = '*';
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "PIN";
                kryptonTextBox2.PasswordChar = '\0';
            }
        }

        private void kryptonTextBox4_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox4.Text == "Description")
            {
                kryptonTextBox4.Text = "";
            }
        }

        private void kryptonTextBox4_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox4.Text == "")
            {
                kryptonTextBox4.Text = "Description";
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string PIN = kryptonTextBox2.Text;
            try
            {
                TransactionBL t = new TransactionBL();
                t.setClientId(client_id);
                //int acc_id = GetAccIDFromAccNum(acc_num); //ye function abi bnana ha
                t.setFromAccountID(0);
                t.setToAccountID(0);
                int type_id = TransactionDL.GetTransactionTypeIDFromLookup("Deposit");
                t.setTransactionType(type_id);
                t.setAmount(Convert.ToDecimal(kryptonTextBox1.Text));
                t.setDescription(kryptonTextBox4.Text);
                t.setDate(DateTime.Now);
                t.setCharges(t.getAmount());
                TransactionDL.AddTransaction(t);
                MessageBox.Show("Money Deposited Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Invalid Entry", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
