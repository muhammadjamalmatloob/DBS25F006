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
using DBFinalProject.Utility;

namespace DBFinalProject.UI
{
    public partial class WithdrawMoney : KryptonForm
    {
        CashierDashboard cashier;
        public WithdrawMoney(CashierDashboard cashier)
        {
            this.cashier = cashier;
            InitializeComponent();
            grpReciept.Visible = false;
            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            kryptonComboBox1.SelectedIndex = 0;
            kryptonManager1.GlobalPalette = Theme.theme;
        }

        // withraw button
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
            string amount = "";
            string pin = "";
            try
            {
                account_number = kryptonTextBox3.Text.Trim();
                amount = kryptonTextBox1.Text.Trim();
                pin = kryptonTextBox2.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }

            if (AccountDL.isAccount(account_number, branch_id))
            {

                WithdrawalBL withdrawal = new WithdrawalBL();
                int acc_id = AccountDL.getAccountIdByNumber(account_number);
                try
                {
                    withdrawal.setFromAccID(acc_id);
                    withdrawal.setClientId(AccountDL.getCleintIdByNumber(account_number));
                    withdrawal.setAmount(Convert.ToDecimal(amount));
                    withdrawal.setCharges(withdrawal.getAmount());
                    withdrawal.setDate(DateTime.Now);
                    withdrawal.setTransactionType(6);   // withraw ki id from lookup
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return;
                }



                int max_amount = AccountTypeDL.getWithdrawlLimit(acc_id);
                int current_balance = AccountDL.getBalanceById(acc_id);
                if (Convert.ToInt64(amount) > max_amount)
                {
                    MessageBox.Show($"Withdrawl Limit is {max_amount}.");
                    return;
                }

                if (pin == AccountDL.getPinByNumber(account_number))
                {
                    try
                    {
                        if (AccountBL.isSufficientBalance(account_number, withdrawal.getAmount(), withdrawal.getCharges()))
                        {
                            if (WithdrawalDL.withdrawlAmmount(withdrawal))
                            {

                                MessageBox.Show("Withrawl successful.");
                                // jab confirm Withrawl ho jaye ga phr 
                                generate_reciept(withdrawal, account_number);
                            }
                            else
                            {
                                MessageBox.Show("Withrawl failed.");
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
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid PIN.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Account not found in this branch.");
                return;
            }
        }

        private void prepare_invoice()
        {
            WithdrawReportBL ReportBL = new WithdrawReportBL();
            ReportBL.customer = name.Text;
            ReportBL.account_number = account_num.Text;
            ReportBL.amount = amount.Text;
            ReportBL.currency = "Rupees";

            WithdrawReport withdraw = new WithdrawReport();
            withdraw.withdrawReportBL = ReportBL;
            withdraw.Show();

        }
        private void generate_reciept(WithdrawalBL withdrawal, string account_number)
        {

            grpReciept.Visible = true;
            int user_id = ClientDL.getUserIdByClientId(withdrawal.getClientId());
            string user_name = UserDL.getUserNameById(user_id);
            name.Text = user_name;
            account_num.Text = account_number;
            amount.Text = withdrawal.getAmount().ToString();
            charges.Text = withdrawal.getCharges().ToString();
            date.Text = withdrawal.getDate().ToString();

        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            cashier.Show();
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
            if (kryptonTextBox1.Text == "Amount")
            {
                kryptonTextBox1.Text = "";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Amount";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "ENTER PIN")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.PasswordChar = '*';
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "ENTER PIN";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {
            kryptonTextBox2.PasswordChar = '*';
            kryptonTextBox2.StateCommon.Content.Color1 = Color.Black;
        }

        // Generate invoice
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            prepare_invoice();
        }
    }
}
