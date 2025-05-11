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
    public partial class ApplyLoan : KryptonForm
    {
        CashierDashboard cashier;
        public ApplyLoan(CashierDashboard cashier)
        {
            InitializeComponent();
            LoanTypeDL.LoadAllLoanTypes();
            LoanTypeDL.LoadLoanTypeInComboBox(kryptonComboBox2);
            this.cashier = cashier;
            kryptonManager1.GlobalPalette = Theme.theme;
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

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // apply loan
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string loan_type = kryptonComboBox2.SelectedItem.ToString();
                if (loan_type == ""  || loan_type == "Select Loan Type")
                {
                    MessageBox.Show("Select Loan Type First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string purpose = kryptonTextBox2.Text;
                decimal amount = Convert.ToDecimal(kryptonTextBox1.Text);
                LoanApplicationBL application = new LoanApplicationBL();
                int LTID = DL.LoanTypeDL.getIdByName(loan_type);
                application.setLoanTypeId(LTID);

                string account_num = kryptonTextBox3.Text;
                
                if (!AccountDL.isAccount(account_num))
                {
                    MessageBox.Show("Account Number is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }   
                int client_id = DL.AccountDL.getAccountIdByNumber(account_num);
                application.setClientId(client_id);
                int acc_id = DL.AccountDL.getAccountIdByNumber(account_num);
                application.setAccountId(acc_id);
                application.SetRequestAmount(amount);
                application.setPurpose(purpose);
                int e_status = 0;

                string status = kryptonComboBox1.SelectedItem.ToString();
                if (status == "Employed")
                {
                    e_status = 1;
                }
                if (status == "" || status == "Select Loan Type")
                {
                    MessageBox.Show("Select Employee Status First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                application.setEmployementStatus(e_status);
                application.setLoanStatus(18);
                application.setApplyDate(DateTime.Now);
                DL.LoanApplicationDL.AddApplication(application);
                MessageBox.Show("Application Submitted");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
