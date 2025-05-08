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

namespace DBFinalProject
{
    public partial class ExchaangeCurr_Cashier : KryptonForm
    {
        public ExchaangeCurr_Cashier()
        {
            InitializeComponent();
            grpReciept.Visible = false;
            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            kryptonComboBox1.SelectedIndex = 0;
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
            string target_currency = "";
            string amount = "";
            string pin = "";
            try
            {
                account_number = kryptonTextBox3.Text.Trim();
                amount = kryptonTextBox1.Text.Trim();
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
    }
}
