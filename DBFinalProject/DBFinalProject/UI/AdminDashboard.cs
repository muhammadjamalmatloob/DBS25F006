using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.UI;
using DBFinalProject.DL;

namespace DBFinalProject
{
    public partial class AdminDashboard : KryptonForm
    {
        public AdminDashboard()
        {
            InitializeComponent();
            hide_branch();
            hide_client();
            hide_accounts();

            username.Text = MainInterface.UserName;
            email.Text = MainInterface.Email;

            totalBranches.Text = BranchDL.TotalBranches();
            totalEmployee.Text = EmployeeDL.TotalEmployees();
            totalManager.Text = EmployeeDL.TotalManagers();
            totalCashier.Text = EmployeeDL.TotalCashiers();

            totalClients.Text = ClientDL.TotalClients();
            totalTrans.Text = TransactionDL.TotalTransactions();
            totalBill.Text = PaymentDL.TotalPayments();
            totalLoanReq.Text = LoanApplicationDL.TotalLoanApplications();

            totalAccountsActive.Text = AccountTypeDL.TotalActiveAccounts();
            totalAccountsInactive.Text = AccountTypeDL.TotalInActiveAccounts();
            totalAccountsClosed.Text = AccountTypeDL.TotalClosedAccounts();
            TotalAccountApplications.Text = AccountApplicationDL.TotalAccountApplications();
            totalAccounts.Text = (int.Parse(totalAccountsActive.Text) + int.Parse(totalAccountsInactive.Text) + int.Parse(totalAccountsClosed.Text)).ToString();


        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            BranchManagement branchManagement = new BranchManagement();
            branchManagement.Show();
            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            EmployeeManagement employeeManagement = new EmployeeManagement();
            employeeManagement.Show();
            this.Hide();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            //ApproveApplicationscs approveApplicationscs = new ApproveApplicationscs();
            //approveApplicationscs.Show();
            //this.Hide();

            AccountTypeManagement accountType = new AccountTypeManagement();
            accountType.Show();
            this.Hide();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            ClientManagement clientManagement = new ClientManagement();
            clientManagement.Show();
            this.Hide();
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            LoanManagement loanManagement = new LoanManagement();
            loanManagement.Show();
            this.Hide();
        }

        private void username_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click_1(object sender, EventArgs e)
        {
            SysttemLogs systemLogs = new SysttemLogs();
            systemLogs.Show();
            this.Hide();
        }


        // VIEW BRANCH 
        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            shoew_branch();
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

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            hide_branch();
        }


        // VIEW CLIENTS
        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            show_client();
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

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            hide_client();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        //view accounts
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

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            Audit audit = new Audit();
            audit.Show();
            this.Hide();
        }
    }
}
