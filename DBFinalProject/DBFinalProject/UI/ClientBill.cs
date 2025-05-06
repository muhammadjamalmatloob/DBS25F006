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
using MySqlConnector;

namespace DBFinalProject
{
    public partial class ClientBill : UserControl
    {
        public ClientBill()
        {
            InitializeComponent();
        }

        private void kryptonComboBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonComboBox1.Text == "Select Payment Type")
            {
                kryptonComboBox1.Text = "";
            }
        }

        private void kryptonComboBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text == "")
            {
                kryptonComboBox1.Text = "Select Payment Type";
            }
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox1.Text == "Amount")
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

        private void kryptonComboBox2_Enter(object sender, EventArgs e)
        {
        }

        private void kryptonComboBox2_Leave(object sender, EventArgs e)
        {
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

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            DateTime date_recorded = DateTime.Now;
            decimal amount = Convert.ToDecimal(kryptonTextBox1.Text);
            string payment_type = kryptonComboBox1.SelectedItem.ToString();
            TransactionBL transaction = new TransactionBL();
            //transaction.setClientId();
            //transaction.setTransactionType();
            transaction.setDate(date_recorded);
            transaction.setCharges(amount);
            PaymentBL payment = new PaymentBL();
            payment.setAmount(amount);
            /*if(balance - amount < 0)
            {
                payment.setStatus();
            }
            else
            {
                payment.setStatus();
            }*/
            //payment.setType(payment_type);
        }
    }
}
