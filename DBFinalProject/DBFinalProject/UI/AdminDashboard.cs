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
    }
}
