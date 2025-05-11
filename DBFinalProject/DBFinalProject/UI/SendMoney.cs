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
using DBFinalProject.BL;
using DBFinalProject.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DBFinalProject
{
    public partial class SendMoney : UserControl
    {
        bool isVerified=false;
        public SendMoney()
        {
            InitializeComponent();
            GrpSender.Visible = false;
            GrpVerify.Visible = false;

            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            string selectedBranchName = kryptonComboBox1.Text.Trim();
            if ((selectedBranchName == null)  || (selectedBranchName == "Select Branch"))
            {
                MessageBox.Show("Please select a branch first.");
                return;
            }
            int to_branch_id = Convert.ToInt32(DL.BranchDL.GetBranchIdByName(selectedBranchName));
            string to_account_number = kryptonTextBox2.Text;

            if (DL.AccountDL.isAccount(to_account_number, to_branch_id))
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
            label3.Text = username;
        }

        private void SendMoney_Load(object sender, EventArgs e)
        {
            isVerified = false;
            GrpSender.Visible = false;
            GrpVerify.Visible = false;
        }

        private void kryptonComboBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonComboBox1.Text == "Select Branch")
            {
                kryptonComboBox1.Text = "";
            }
        }

        private void kryptonComboBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text == "")
            {
                kryptonComboBox1.Text = "Select Branch";
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox2.Text == "Enter Account Number")
            {
                kryptonTextBox2.Text = "";
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Enter Account Number";
            }
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

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox3.Text == "Amount")
            {
                kryptonTextBox3.Text = "";
            }
        }

        private void kryptonTextBox3_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "")
            {
                kryptonTextBox3.Text = "Amount";
            }
        }

        private void kryptonTextBox4_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox4.Text == "PIN")
            {
                kryptonTextBox4.Text = "";
                kryptonTextBox4.PasswordChar = '*';
            }
        }

        private void kryptonTextBox4_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox4.Text == "")
            {
                kryptonTextBox4.Text = "PIN";
                kryptonTextBox4.PasswordChar = '\0';
            }
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            string username = DL.LoginDL.user.getUsername();
            int user_id = DL.UserDL.get_user_id(username);
            int client_id = DL.ClientDL.getClientIdbyUserId(user_id);
            string to_account_number = "";
            string from_account_number = "";
            decimal amount = 0;
            string pin = "";
            try
            {
                to_account_number = kryptonTextBox2.Text.Trim();
                from_account_number = kryptonTextBox1.Text.Trim();
                amount = Convert.ToDecimal(kryptonTextBox3.Text.Trim());
                pin = kryptonTextBox4.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }
            if(from_account_number != to_account_number)
            {
                if (AccountDL.isAccountOfClient(from_account_number, client_id))
                {
                    if (pin == AccountDL.getPinByNumber(from_account_number))
                    {
                        TransferBL transfer = new TransferBL();
                        transfer.setClientId(AccountDL.getCleintIdByNumber(from_account_number));
                        transfer.setTransactionType(7);
                        transfer.setDate(DateTime.Now);
                        transfer.setCharges(amount);
                        transfer.setAmount(amount);
                        int acc_id = AccountDL.getAccountIdByNumber(from_account_number);
                        int acc_type_id = AccountDL.getAccountTypeIdByNumber(from_account_number);
                        transfer.setFromAccID(acc_id);
                        transfer.setToAccID(AccountDL.getAccountIdByNumber(to_account_number));
                        int max_amount = AccountTypeDL.getTransactionLimit(acc_type_id);
                        if (amount > max_amount)
                        {
                            MessageBox.Show($"Transaction Limit is {max_amount}.");
                            return;
                        }
                        else
                        {
                            if (AccountBL.isSufficientBalance(from_account_number,transfer.getAmount(),transfer.getCharges()))
                            {
                                try
                                {
                                    TransferDL.transferAmmount(transfer);
                                    MessageBox.Show("Transfer successful.");
                                    Thread.Sleep(5000);
                                    GrpSender.Visible = false;
                                    GrpVerify.Visible = false;
                                    label3.Text = "NAME";
                                    kryptonTextBox1.Text = "Enter Account Number";
                                    kryptonTextBox3.Text = "Amount";
                                    kryptonTextBox4.PasswordChar = '\0';
                                    kryptonTextBox4.Text = "PIN";
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
                                MessageBox.Show("Insufficient Balance");
                            }
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
            else
            {
                MessageBox.Show("No Money Transfer Between Same Accounts");
            }
        }
    }
}
