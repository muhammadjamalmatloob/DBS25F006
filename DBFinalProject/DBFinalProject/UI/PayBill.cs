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
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class PayBill : KryptonForm
    {
        CashierDashboard cashier;
        public PayBill(CashierDashboard cashier)
        {
            InitializeComponent();
            grpReciept.Visible = false;
            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox3);
            kryptonComboBox3.SelectedIndex = 0;
            kryptonComboBox1.SelectedIndex = 0;
            kryptonManager1.GlobalPalette = Theme.theme;
            this.cashier = cashier;
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            cashier.Show();
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
            if (payment_type == null || payment_type == "Select Payment Type")
            {
                MessageBox.Show("Please select a payment type first.");
                return;
            }
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
                payment.setStatus(15); // for pending status
                payment.setTransactionType(8); // pay bill ki id from lookup
                payment.setType(Convert.ToInt32(PaymentDL.getPaymentTypeId(payment_type)));
                


                if (pin == AccountDL.getPinByNumber(account_number))
                {
                    try
                    {
                        if (AccountBL.isSufficientBalance(account_number, payment.getAmount(), payment.getCharges()))
                        {
                            payment.setStatus(16);
                            if (PaymentDL.payAmmount(payment))
                            {
                                MessageBox.Show("Payment successful.");
                                generate_reciept(payment, account_number);
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
            else
            {
                MessageBox.Show("Account number is not valid.");
                return;
            }


        }
        private void generate_reciept(PaymentBL pay, string account_number)
        {

            grpReciept.Visible = true;
            int user_id = ClientDL.getUserIdByClientId(pay.getClientId());
            string user_name = UserDL.getUserNameById(user_id);
            name.Text = user_name;
            account_num.Text = account_number;
            amount.Text = pay.getAmount().ToString();
            charges.Text = pay.getCharges().ToString();
            date.Text = pay.getDate().ToString();

        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "Enter Pin")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Enter Pin";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Gray;
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

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Enter Amount";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "Enter Account Number")
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

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {
            kryptonTextBox2.PasswordChar = '*';
            kryptonTextBox2.StateCommon.Content.Color1 = Color.Black;
        }
    }
}
