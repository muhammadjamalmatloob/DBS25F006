using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.UI;
using DBFinalProject.DL;
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class CashierDashboard : KryptonForm
    {
        public CashierDashboard()
        {
            InitializeComponent();
            hide_accounts();
            hide_client();
            load_data();
            Blue.Checked = true;
            if (Theme.theme == myPallet || Theme.theme == GreenTheme || Theme.theme == PurpleTheme)
            {

                kryptonManager1.GlobalPalette = Theme.theme;
            }
            else
            {
                Theme.theme = myPallet;
                kryptonManager1.GlobalPalette = Theme.theme;
            }
        }

        private void load_data()
        {
            username.Text = MainInterface.UserName;
            email.Text = MainInterface.Email;
            int user_id = UserDL.get_user_id(MainInterface.UserName);
            int branch_id = EmployeeDL.getBranchIdByUserId(user_id);

            totalAccounts.Text = AccountTypeDL.TotalAccounts(branch_id);
            totalAccountsActive.Text = AccountTypeDL.TotalAccounts(23,branch_id);
            totalAccountsInactive.Text = AccountTypeDL.TotalAccounts(24, branch_id);
            totalAccountsClosed.Text = AccountTypeDL.TotalAccounts(25, branch_id);
            TotalAccountApplications.Text = AccountApplicationDL.TotalAccountApplications(branch_id);

            totalClients.Text = ClientDL.TotalClients();
            totalTrans.Text = TransactionDL.TotalTransactions();
            totalBill.Text = PaymentDL.TotalPayments();
            totalLoanReq.Text = LoanApplicationDL.TotalLoanApplications();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MoneyTransfer moneyTransfer = new MoneyTransfer(this);
            moneyTransfer.Show();
            
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            DepositMoney depositMoney = new DepositMoney(this);
            depositMoney.Show();
            
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            PayBill payBill = new PayBill();
            payBill.Show();
            
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExchaangeCurr_Cashier exchangeCurr_Cashier = new ExchaangeCurr_Cashier();
            exchangeCurr_Cashier.Show();
            
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApplyLoan applyLoan = new ApplyLoan();
            applyLoan.Show();
            
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainInterface mainInterface = new MainInterface();
            mainInterface.Show();
            
        }

       

        private void hide_client()
        {
            panel5.Visible = true;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;

            totalTrans.Visible = false;
            totalBill.Visible = false;
            totalLoanReq.Visible = false;

            kryptonButton9.Visible = false;
        }
        private void show_client()
        {
            panel5.Visible = false;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;

            totalTrans.Visible = true;
            totalBill.Visible = true;
            totalLoanReq.Visible = true;

            kryptonButton9.Visible = true;
        }

        private void hide_accounts()
        {
            panel6.Visible = true;
            label16.Visible = false;
            label15.Visible = false;
            label12.Visible = false;
            label7.Visible = false;

            totalAccountsActive.Visible = false;
            totalAccountsInactive.Visible = false;
            totalAccountsClosed.Visible = false;
            TotalAccountApplications.Visible = false;

            kryptonButton11.Visible = false;
        }
        private void show_accounts()
        {
            panel6.Visible = false;
            label16.Visible = true;
            label15.Visible = true;
            label12.Visible = true;
            label7.Visible = true;

            totalAccountsActive.Visible = true;
            totalAccountsInactive.Visible = true;
            totalAccountsClosed.Visible = true;
            TotalAccountApplications.Visible = true;

            kryptonButton11.Visible = true;
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            show_client();
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            hide_client();
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            show_accounts();
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            hide_accounts();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            WithdrawMoney withdraw = new WithdrawMoney(this);
            withdraw.Show();
        }


        // theme
        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            ThemeMenu.Visible = true;
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            if (Blue.Checked)
            {
                kryptonManager1.GlobalPalette = this.myPallet;
                Theme.theme = myPallet;
            }
            else if (Green.Checked)
            {
                kryptonManager1.GlobalPalette = this.GreenTheme;
                Theme.theme = GreenTheme;
            }
            else if (Purple.Checked)
            {
                kryptonManager1.GlobalPalette = this.PurpleTheme; ;
                Theme.theme = PurpleTheme;
            }
            MessageBox.Show("Theme applied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThemeMenu.Visible = false;
        }

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            kryptonManager1.GlobalPalette = Theme.theme;
            ThemeMenu.Visible = false;
        }

        private void Blue_CheckedChanged(object sender, EventArgs e)
        {
            if (Blue.Checked)
            {
                kryptonManager1.GlobalPalette = this.myPallet;
            }
        }

        private void Purple_CheckedChanged(object sender, EventArgs e)
        {
            if (Purple.Checked)
            {
                kryptonManager1.GlobalPalette = this.PurpleTheme;
            }
        }

        private void Green_CheckedChanged(object sender, EventArgs e)
        {
            if (Green.Checked)
            {
                kryptonManager1.GlobalPalette = this.GreenTheme;
            }
        }
    }
}
