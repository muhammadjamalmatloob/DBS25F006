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
    public partial class DepositMoney : KryptonForm
    {
        public DepositMoney()
        {
            InitializeComponent();
            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            kryptonComboBox1.SelectedIndex = 0;
            
            grpReciept.Visible = false;
        }

         

        private void DepositMoney_Load(object sender, EventArgs e)
        {

        }

        private void GrpRecieve_Panel_Paint(object sender, PaintEventArgs e)
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

        // deposit button
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string selectedBranchName = kryptonComboBox1.Text.Trim();
            if (kryptonComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a branch first.");
                return;
            }
            int branch_id = Convert.ToInt32(BranchDL.GetBranchIdByName(selectedBranchName));
            string account_number = "";
            string amount = "";
            string pin = "";
            int amount_int = 0; 
            try
            {
                account_number = kryptonTextBox3.Text.Trim();
                amount = kryptonTextBox1.Text.Trim();
                pin = kryptonTextBox2.Text.Trim();
                amount_int = Convert.ToInt32(amount);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }

            if (AccountDL.isAccount(account_number, branch_id))
            {
                
                DepositsBL deposits = new DepositsBL();
                int acc_id = AccountDL.getAccountIdByNumber(account_number);
                deposits.setToAccountId(acc_id);

                deposits.setClientId(AccountDL.getCleintIdByNumber(account_number));
                
                deposits.setAmount(Convert.ToDecimal(amount));
                deposits.setCharges(deposits.getAmount());
                //string formattedDate = DateTime.Now.ToString("yyyy-MM-dd");
                deposits.setDate(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
                deposits.setTransactionType(5);   // deposit ki id from lookup  

                int min_amount = AccountTypeDL.getMinBalance(acc_id);
                int current_balance = AccountDL.getBalanceById(acc_id);
                if (amount_int + current_balance < min_amount)
                {
                    MessageBox.Show($"Minimum Balance should be {min_amount}.");
                    return;
                }

                if (pin == AccountDL.getPinByNumber(account_number))
                {
                    try
                    {
                        if (DepositsDL.depositAmmount(deposits))
                        {
                            MessageBox.Show("Deposit successful.");
                            // jab confirm deposit ho jaye ga phr 
                            generate_reciept(deposits,account_number);
                        }
                        else
                        {
                            MessageBox.Show("Deposit failed.");
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
                
                
            }
            else
            {
                MessageBox.Show("Account number is not valid.");
                return;
            }
        }

        private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void generate_reciept(DepositsBL deposits,string account_number)
        {

            grpReciept.Visible = true;
            int user_id = ClientDL.getUserIdByClientId(deposits.getClientId());
            string user_name = UserDL.getUserNameById(user_id);
            name.Text = user_name;
            account_num.Text = account_number;
            amount.Text = deposits.getAmount().ToString();
            charges.Text = deposits.getCharges().ToString();
            date.Text = deposits.getDate().ToString();

        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "Enter Account Number")
            {
                kryptonTextBox3.Text = "";
                kryptonTextBox3.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Enter Amount")
            {
                kryptonTextBox1.Text = "";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox3_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "")
            {
                kryptonTextBox3.Text = "Enter Account Number";
                kryptonTextBox3.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Enter Amount";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "Enter PIN")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Enter PIN";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Gray;
            }
        }
    }
}
