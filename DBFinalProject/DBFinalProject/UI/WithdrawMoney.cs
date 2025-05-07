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

namespace DBFinalProject.UI
{
    public partial class WithdrawMoney : KryptonForm
    {
        public WithdrawMoney()
        {
            InitializeComponent();
            grpReciept.Visible = false;
            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            kryptonComboBox1.SelectedIndex = 0;
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
            string account_number = kryptonTextBox3.Text.Trim();
            string amount = kryptonTextBox1.Text.Trim();
            string pin = kryptonTextBox2.Text.Trim();

            if (AccountDL.isAccount(account_number, branch_id))
            {

                WithdrawalBL withdrawal = new WithdrawalBL();
                withdrawal.setFromAccID(AccountDL.getAccountIdByNumber(account_number));
                withdrawal.setClientId(AccountDL.getCleintIdByNumber(account_number));
                withdrawal.setAmount(Convert.ToDecimal(amount));
                withdrawal.setCharges(withdrawal.getAmount());
                withdrawal.setDate(DateTime.Now);
                withdrawal.setTransactionType(6);   // withraw ki id from lookup  


                if (pin == AccountDL.getPinByNumber(account_number))
                {
                    try
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

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Account not found in this branch.");
                return;
            }
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
    }
}
