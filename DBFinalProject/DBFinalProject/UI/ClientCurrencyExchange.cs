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
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.DL;
using Org.BouncyCastle.Asn1.X509;

namespace DBFinalProject.UI
{
    public partial class ClientCurrencyExchange : UserControl
    {
        public ClientCurrencyExchange()
        {
            InitializeComponent();
            grpReciept.Visible = false;
        }

        private void kryptonComboBox3_Enter(object sender, EventArgs e)
        {
            
        }

        private void kryptonComboBox3_Leave(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox4_Enter(object sender, EventArgs e)
        {
            if (kryptonComboBox4.Text == "Target Currency")
            {
                kryptonComboBox4.Text = "";
            }
        }

        private void kryptonComboBox4_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox4.Text == "")
            {
                kryptonComboBox4.Text = "Target Currency";
            }
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Account Number")
            {
                kryptonTextBox1.Text = "";
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Account Number";
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            reset_reciept();
            string account_number = "";
            string base_currency = "";
            string target_currency = "";
            string amount = "";
            string pin = "";
            
            try
            {
                try
                {
                    account_number = kryptonTextBox1.Text.Trim();
                    amount = kryptonTextBox2.Text.Trim();
                    pin = kryptonTextBox4.Text.Trim();
                    target_currency = kryptonComboBox4.SelectedItem.ToString();
                    base_currency = "Rupees";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;

                }
                string username = DL.LoginDL.user.getUsername();
                int user_id = DL.UserDL.get_user_id(username);
                int client_id = DL.ClientDL.getClientIdbyUserId(user_id);
                int acc_id = DL.AccountDL.getAccountIdByNumber(account_number);
                if (DL.AccountDL.isAccountOfClient(account_number, client_id))
                {
                    CurrencyExchangeBL exchange = new CurrencyExchangeBL();
                    exchange.setBaseCurrency("Rupees");
                    exchange.setTargetCurrency(target_currency);
                    exchange.setAmountBase(Convert.ToDecimal(amount));
                    exchange.setExchangeRate("Rupees", target_currency);
                    exchange.setAmountTarget(exchange.getExchangeRate() * exchange.getAmountBase());

                    exchange.setClientId(AccountDL.getCleintIdByNumber(account_number));
                    exchange.setDate(DateTime.Now);
                    exchange.setTransactionType(9);   // exchange ki id from lookup
                    exchange.setCharges(exchange.getAmountBase());

                    if (pin == AccountDL.getPinByNumber(account_number))
                    {
                        try
                        {
                            if (AccountBL.isSufficientBalance(account_number, exchange.getAmountBase(), exchange.getCharges()))
                            {
                                if (CurrencyExchangeDL.exchangeAmmount(exchange,acc_id))
                                {
                                    MessageBox.Show("Exchange successful.");
                                    generate_reciept(exchange, account_number);
                                }
                                else
                                {
                                    MessageBox.Show("Exchange failed.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Insufficient balance.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void generate_reciept(CurrencyExchangeBL currency, string account_number)
        {

            grpReciept.Visible = true;
            int user_id = ClientDL.getUserIdByClientId(currency.getClientId());
            string user_name = UserDL.getUserNameById(user_id);
            name.Text = user_name;
            account_num.Text = account_number;
            amount.Text = currency.getAmountBase().ToString();
            charges.Text = currency.getCharges().ToString();
            date.Text = currency.getDate().ToString();
        }

        private void reset_reciept()
        {

            grpReciept.Visible = false;
            name.Text = "NAME";
            account_num.Text = "NUM";
            amount.Text = "amount";
            charges.Text = "charges";
            date.Text = "date";
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

        private void kryptonTextBox4_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox4.Text == "PIN")
            {
                kryptonTextBox4.Text = "";
            }
        }

        private void kryptonTextBox4_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox4.Text == "")
            {
                kryptonTextBox4.Text = "PIN";
            }
        }
    }
}
