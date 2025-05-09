using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFinalProject.DL;
using DBFinalProject.BL;

namespace DBFinalProject
{
    public partial class PayBill : Form
    {
        public PayBill()
        {
            InitializeComponent();
            grpReciept.Visible = false;
            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox3);
            kryptonComboBox3.SelectedIndex = 0;
            kryptonComboBox1.SelectedIndex = 0;
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

        private void kryptonComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GrpRecieve_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // pay btn
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string selectedBranchName = kryptonComboBox3.Text.Trim();
            if (selectedBranchName == null || selectedBranchName == "Select Branch")
            {
                MessageBox.Show("Please select a branch first.");
                return;
            }
            int branch_id = Convert.ToInt32(BranchDL.GetBranchIdByName(selectedBranchName));
            string account_number = kryptonTextBox3.Text.Trim();
            string payment_type = kryptonComboBox1.Text.Trim();
            decimal amount = Convert.ToDecimal(kryptonTextBox1.Text.Trim());
            string pin = kryptonTextBox2.Text.Trim();

            if (AccountDL.isAccount(account_number, branch_id))
            {
                PaymentBL payment = new PaymentBL();
                payment.setAccountId(AccountDL.getAccountIdByNumber(account_number));
                payment.setClientId(AccountDL.getCleintIdByNumber(account_number));
                payment.setAmount(amount);
                payment.setCharges(payment.getAmount());
                payment.setDate(DateTime.Now);
                payment.setTransactionType(8);   // pay bill ki id from lookup

                if (pin == AccountDL.getPinByNumber(account_number))
                {
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


        }

        
    }
}
