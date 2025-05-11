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

namespace DBFinalProject
{
    public partial class MoneyTransfer : KryptonForm
    {
        CashierDashboard cashier;
        public MoneyTransfer(CashierDashboard cashier)
        {
            this.cashier = cashier;
            InitializeComponent();
            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox2);
            kryptonComboBox1.SelectedIndex = 0;
            kryptonComboBox2.SelectedIndex = 0;
            GrpSender.Visible = false;
            GrpVerify.Visible = false;
            kryptonManager1.GlobalPalette = Theme.theme;
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


        // verification wala btn
        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            string selectedBranchName = kryptonComboBox1.Text.Trim();
            if ((selectedBranchName == null)  || (selectedBranchName == "Select Branch"))
            {
                MessageBox.Show("Please select a branch first.");
                return;
            }
            int to_branch_id = Convert.ToInt32(BranchDL.GetBranchIdByName(selectedBranchName));
            string to_account_number = kryptonTextBox2.Text.Trim();

            
            if (AccountDL.isAccount(to_account_number, to_branch_id))
            {
                show_Username(to_account_number);
                
            }
            else
            {
                MessageBox.Show("Recipent's Account does not exists.");
                return;
            }
           
        }

        private void show_Username(string account_number)
        {
            GrpSender.Visible = true;
            GrpVerify.Visible = true;
            int client_id = AccountDL.getCleintIdByNumber(account_number);
            int user_id = ClientDL.getUserIdByClientId(client_id);
            string username = UserDL.getUserNameById(user_id);
            UserName.Text = username;
        }

        private void GrpRecieve_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "Enter Account Number")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(kryptonTextBox2.Text))
            {
                kryptonTextBox2.Text = "Enter Account Number";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Enter Account Number")
            {
                kryptonTextBox1.Text = "";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(kryptonTextBox1.Text))
            {
                kryptonTextBox1.Text = "Enter Account Number";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "Enter Amount")
            {
                kryptonTextBox3.Text = "";
                kryptonTextBox3.StateCommon.Content.Color1 = Color.Black;
            }
        }
        private void kryptonTextBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(kryptonTextBox3.Text))
            {
                kryptonTextBox3.Text = "Enter Amount";
                kryptonTextBox3.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {

        }

        // transfer wala btn
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            string selectedBranchName2 = kryptonComboBox2.Text.Trim();
            if ((selectedBranchName2 == null) || (selectedBranchName2 == "Select Branch"))
            {
                MessageBox.Show("Please select a branch first.");
                return;
            }
            string to_account_number = "";
            int from_branch_id = 0;
            string from_account_number = "";
            decimal amount = 0;
            string pin = "";
            try
            {
                to_account_number = kryptonTextBox2.Text.Trim();
                from_branch_id = Convert.ToInt32(BranchDL.GetBranchIdByName(selectedBranchName2));
                from_account_number = kryptonTextBox1.Text.Trim();
                amount = Convert.ToDecimal(kryptonTextBox3.Text.Trim());
                pin = kryptonTextBox4.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            if (AccountDL.isAccount(from_account_number, from_branch_id))
            {
                if (pin == AccountDL.getPinByNumber(from_account_number))
                {
                    TransferBL transfer = new TransferBL();
                    int acc_id = 0;
                    try
                    {
                        transfer.setClientId(AccountDL.getCleintIdByNumber(from_account_number));
                        transfer.setTransactionType(7); // transfer ki id from lookup
                        transfer.setDate(DateTime.Now);
                        transfer.setCharges(amount);

                        transfer.setAmount(amount);
                        acc_id = AccountDL.getAccountIdByNumber(from_account_number);
                        transfer.setFromAccID(acc_id);
                        transfer.setToAccID(AccountDL.getAccountIdByNumber(to_account_number));
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }

                    int max_amount = AccountTypeDL.getTransactionLimit(acc_id);
                    int current_balance = AccountDL.getBalanceById(acc_id);
                    if (amount  > max_amount)
                    {
                        MessageBox.Show($"Transaction Limit is {max_amount}.");
                        return;
                    }
                    try
                    {
                        TransferDL.transferAmmount(transfer);
                        MessageBox.Show("Transfer successful.");
                        return;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Your PIN is incorrect.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Your Account does not exists.");
                return;
            }
        }

        private void kryptonTextBox4_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox4.Text == "Enter Pin")
            {
                kryptonTextBox4.Text = "";
                kryptonTextBox4.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(kryptonTextBox4.Text))
            {
                kryptonTextBox4.Text = "Enter Pin";
                kryptonTextBox4.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox4_TextChanged(object sender, EventArgs e)
        {
            kryptonTextBox4.PasswordChar = '*';
            kryptonTextBox4.StateCommon.Content.Color1 = Color.Black;
        }
    }
}
