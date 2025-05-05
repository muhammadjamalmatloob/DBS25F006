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

namespace DBFinalProject
{
    public partial class ManagerDashboard : KryptonForm
    {
        public ManagerDashboard()
        {
            InitializeComponent();
            hide_accounts();
            hide_branch();
            hide_client();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            ViewBranchInfo viewBranchInfo = new ViewBranchInfo();
            viewBranchInfo.Show();
            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            BranchEmployees branchEmployees = new BranchEmployees();
            branchEmployees.Show();
            this.Hide();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            LoanApplications application = new LoanApplications();
            application.Show();
            this.Hide();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            CurrencyExchange currencyExchange = new CurrencyExchange();
            currencyExchange.Show();
            this.Hide();
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            BillPayments billPayments = new BillPayments();
            billPayments.Show();
            this.Hide();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            TransactionRecord transactionRecord = new TransactionRecord();
            transactionRecord.Show();
            this.Hide();

        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            MainInterface mainInterface = new MainInterface();
            mainInterface.Show();
            this.Hide();
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            ApproveApplicationscs approveApplicationscs = new ApproveApplicationscs();
            approveApplicationscs.Show();
            this.Hide();
        }

        private void hide_branch()
        {
            panel4.Visible = true;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;

            totalCashier.Visible = false;
            totalManager.Visible = false;
            totalEmployee.Visible = false;

            kryptonButton7.Visible = false;
        }
        private void shoew_branch()
        {
            panel4.Visible = false;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;

            totalCashier.Visible = true;
            totalManager.Visible = true;
            totalEmployee.Visible = true;

            kryptonButton7.Visible = true;
        }

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            shoew_branch();
        }

        private void kryptonButton7_Click_1(object sender, EventArgs e)
        {
            hide_branch();
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

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            hide_accounts();
        }
    }
}
