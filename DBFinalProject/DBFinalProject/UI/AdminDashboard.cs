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
using DBFinalProject.DL;
using DBFinalProject.UI;
using DBFinalProject.Utility;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BranchManagement branchManagement = new BranchManagement(this);
            branchManagement.Show();

        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeManagement employeeManagement = new EmployeeManagement(this);
            employeeManagement.Show();

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountTypeManagement accountType = new AccountTypeManagement(this);
            accountType.Show();

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Audit audit = new Audit();
            audit.Show();

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoanManagement loanManagement = new LoanManagement(this);
            loanManagement.Show();

        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            ThemeMenu.Visible = true;
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

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            if (Blue.Checked)
            {
                kryptonManager1.GlobalPalette = this.myPallet;
                Theme.theme = myPallet;
            }
            else if (Purple.Checked)
            {
                kryptonManager1.GlobalPalette = this.PurpleTheme;
                Theme.theme = PurpleTheme;
            }
            else if (Green.Checked)
            {
                kryptonManager1.GlobalPalette = this.GreenTheme;
                Theme.theme = GreenTheme;
            }
            MessageBox.Show("Theme applied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThemeMenu.Visible = false;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            kryptonManager1.GlobalPalette = Theme.theme;
            ThemeMenu.Visible = false;
        }

        private void kryptonPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainInterface().Show();
        }

        private void kryptonButton16_Click(object sender, EventArgs e)
        {
            this.Hide();
            SysttemLogs systtemLogs = new SysttemLogs();
            systtemLogs.Show();
        }

        private void load_data()
        {
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

            totalAccountsActive.Text = AccountTypeDL.TotalAccounts(23);
            totalAccountsInactive.Text = AccountTypeDL.TotalAccounts(24);
            totalAccountsClosed.Text = AccountTypeDL.TotalAccounts(25);
            TotalAccountApplications.Text = AccountApplicationDL.TotalAccountApplications();
            totalAccounts.Text = (int.Parse(totalAccountsActive.Text) + int.Parse(totalAccountsInactive.Text) + int.Parse(totalAccountsClosed.Text)).ToString();
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

            kryptonButton6.Visible = false;
        }
        private void show_branch()
        {
            panel4.Visible = false;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;

            totalCashier.Visible = true;
            totalManager.Visible = true;
            totalEmployee.Visible = true;

            kryptonButton6.Visible = true;
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

            kryptonButton10.Visible = false;
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

            kryptonButton10.Visible = true;
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

            kryptonButton14.Visible = false;
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

            kryptonButton14.Visible = true;
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            show_branch();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            hide_branch();
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            show_client();
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            hide_client();
        }

        private void kryptonButton15_Click(object sender, EventArgs e)
        {
            show_accounts();
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            hide_accounts();
        }
    }
}
