using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFinalProject.BL;

namespace DBFinalProject
{
    public partial class ClientCurrencyExchange : UserControl
    {
        public int client_id;
        public string acc_num;
        public decimal balance;
        public ClientCurrencyExchange(int client_id, string acc_num, decimal balance)
        {
            InitializeComponent();
            this.client_id = client_id;
            this.acc_num = acc_num;
            this.balance = balance;
        }

        private void kryptonComboBox2_Enter(object sender, EventArgs e)
        {
            if(kryptonComboBox2.Text == "Select Base Currency")
            {
                kryptonComboBox2.Text = "";
            }
        }

        private void kryptonComboBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox2.Text == "")
            {
                kryptonComboBox2.Text = "Select Base Currency";
            }
        }

        private void kryptonComboBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonComboBox1.Text == "Select Target Currency")
            {
                kryptonComboBox1.Text = "";
            }
        }

        private void kryptonComboBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text == "")
            {
                kryptonComboBox1.Text = "Select Target Currency";
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox2.Text == "Amount")
            {
                kryptonTextBox2.Text = "";
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Amount";
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            CurrencyExchangeBL ce = new CurrencyExchangeBL();
            ce.setClientId(client_id);
            ce.setBaseCurrency(kryptonComboBox2.SelectedItem.ToString());
            ce.setTargetCurrency(kryptonComboBox1.SelectedItem.ToString());
            ce.setExchangeRate(kryptonComboBox2.SelectedItem.ToString(), kryptonComboBox1.SelectedItem.ToString());
            ce.setAmountBase(Convert.ToDecimal(kryptonTextBox2.Text));
            decimal tamount = Convert.ToDecimal(kryptonTextBox2.Text)/ce.getExchangeRate();
            ce.setAmountTarget(tamount);
            ce.setDate(DateTime.Now);


        }
    }
}
