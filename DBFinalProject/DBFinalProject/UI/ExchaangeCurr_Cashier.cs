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
using DBFinalProject.UI;

namespace DBFinalProject
{
    public partial class ExchaangeCurr_Cashier : KryptonForm
    {
        string base_currency;
        string target_currency;
        string base_amount;
        string target_amount;
        public ExchaangeCurr_Cashier()
        {
            InitializeComponent();
            grpReciept.Visible = false;
            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            kryptonComboBox1.SelectedIndex = 0;
            kryptonComboBox4.SelectedIndex = 0;
        }

        private void kryptonComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            CashierDashboard cashierDashboard = new CashierDashboard();
            cashierDashboard.Show();
            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // exchage btn
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string selectedBranchName = kryptonComboBox1.Text.Trim();
            if (selectedBranchName == null || selectedBranchName == "Select Branch")
            {
                MessageBox.Show("Please select a branch first.");
                return;
            }
            int branch_id = Convert.ToInt32(BranchDL.GetBranchIdByName(selectedBranchName));
            string account_number = "";
            
            
            string pin = "";
            try
            {
                account_number = kryptonTextBox3.Text.Trim();
                base_amount = kryptonTextBox1.Text.Trim();
                pin = kryptonTextBox2.Text.Trim();
                target_currency = kryptonComboBox4.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;

            }

            if (AccountDL.isAccount(account_number,branch_id))
            {
                CurrencyExchangeBL exchange = new CurrencyExchangeBL();
                exchange.setBaseCurrency("Rupees");
                exchange.setTargetCurrency(target_currency);
                exchange.setAmountBase(Convert.ToDecimal(amount));
                exchange.setExchangeRate("Rupees", target_currency);
                exchange.setAmountTarget(exchange.getExchangeRate() * exchange.getAmountBase());
                target_currency = exchange.getTargetCurrency();
                target_amount = exchange.getAmountTarget().ToString();

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
                            if (CurrencyExchangeDL.exchangeAmmount(exchange))
                            {
                                MessageBox.Show("Exchange successful.");
                                // jab confirm Withrawl ho jaye ga phr 
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


        private void prepare_invoice()
        {
            ExchangeReportBL ReportBL = new ExchangeReportBL();
            ReportBL.customer = name.Text;
            ReportBL.account_number = account_num.Text;
            ReportBL.base_currency = base_currency;
            ReportBL.target_currency = target_currency;
            ReportBL.base_amount = base_amount;
            ReportBL.target_amount = target_amount;

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

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "Account Number")
            {
                kryptonTextBox3.Text = "";
                kryptonTextBox3.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox3_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "")
            {
                kryptonTextBox3.Text = "Account Number";
                kryptonTextBox3.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Amount Paid")
            {
                kryptonTextBox3.Text = "";
                kryptonTextBox3.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Amount Paid";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "PIN")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "PIN";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {
            kryptonTextBox2.PasswordChar = '*';
            kryptonTextBox2.StateCommon.Content.Color1 = Color.Black;
        }
    }
}
