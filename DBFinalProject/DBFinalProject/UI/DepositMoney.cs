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
            kryptonButton2.Visible = false;
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
            string account_number = kryptonTextBox3.Text.Trim();
            string amount = kryptonTextBox1.Text.Trim();
            string pin = kryptonTextBox2.Text.Trim();

            if (AccountDL.isAccount(account_number, branch_id))
            {
                DepositsBL deposits = new DepositsBL();
                deposits.setToAccountId(AccountDL.getAccountIdByNumber(account_number));
                deposits.setClientId(AccountDL.getCleintIdByNumber(account_number));
                deposits.setAmount(Convert.ToDecimal(amount));
                deposits.setCharges(deposits.getAmount());
                deposits.setDate(DateTime.Now);
                deposits.setTransactionType(5);   // deposit ki id from lookup  


                if (pin == AccountDL.getPinByNumber(account_number))
                {
                    try
                    {
                        if (DepositsDL.depositAmmount(deposits))
                        {
                            MessageBox.Show("Deposit successful.");
                            // jab confirm deposit ho jaye ga phr 
                            kryptonButton2.Visible = true;
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
    }
}
