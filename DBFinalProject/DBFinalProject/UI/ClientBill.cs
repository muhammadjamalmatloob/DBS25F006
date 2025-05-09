using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.DL;
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
            string CheckPin = "";
            string pin = kryptonTextBox2.Text.Trim();
            string account_number = kryptonTextBox3.Text;
            CheckPin = DL.AccountDL.getPinByNumber(account_number);
            if (pin == CheckPin)
            {
                decimal amount = Convert.ToDecimal(kryptonTextBox1.Text);
                PaymentBL payment = new PaymentBL();
                payment.setAccountId(AccountDL.getAccountIdByNumber(account_number));
                payment.setClientId(AccountDL.getCleintIdByNumber(account_number));
                payment.setAmount(amount);
                payment.setCharges(payment.getAmount());
                payment.setDate(DateTime.Now);
                payment.setTransactionType(8);   // pay bill ki id from lookup
                string payment_type = kryptonComboBox1.SelectedItem.ToString();
                payment.setAmount(amount);
                //payment.setType(payment_type);
                /*if(balance - amount < 0)
                {
                    payment.setStatus();
                }
                else
                {
                    payment.setStatus();
                }*/
                //payment.setType(payment_type);
                try
                {
                    if (AccountBL.isSufficientBalance(account_number, payment.getAmount(), payment.getCharges()))
                    {
                        if (PaymentDL.payAmmount(payment))
                        {
                            MessageBox.Show("Payment successful.");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Payment failed.");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Insufficient balance.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Invalid PIN.");
            }









        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox3.Text =="Account Number")
            {
                kryptonTextBox3.Text = "";
            }
        }

        private void kryptonTextBox3_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "")
            {
                kryptonTextBox3.Text = "Account Number";
            }
        }
    }
}
