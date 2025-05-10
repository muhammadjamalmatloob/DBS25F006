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
using DBFinalProject.DL;
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class ManagerDashboard : KryptonForm
    {
        public ManagerDashboard()
        {
            InitializeComponent();
            if (Theme.theme == myPallet || Theme.theme == GreenTheme || Theme.theme == PurpleTheme)
            {

                kryptonManager1.GlobalPalette = Theme.theme;
            }
            else
            {
                Theme.theme = myPallet;
                kryptonManager1.GlobalPalette = Theme.theme;
            }

            GetAllTotals();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewBranchInfo viewBranchInfo = new ViewBranchInfo(this);
            viewBranchInfo.Show();

        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BranchEmployees branchEmployees = new BranchEmployees(this);
            branchEmployees.Show();

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoanApplications application = new LoanApplications(this);
            application.Show();

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            CurrencyExchange currencyExchange = new CurrencyExchange(this);
            currencyExchange.Show();

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            BillPayments billPayments = new BillPayments(this);
            billPayments.Show();

        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            TransactionRecord transactionRecord = new TransactionRecord(this);
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

        private void kryptonButton7_Click_1(object sender, EventArgs e)
        {
            ThemeMenu.Visible = true;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            kryptonManager1.GlobalPalette = Theme.theme;
            ThemeMenu.Visible = false;
        }

        private void GreenTheme_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void GetAllTotals()
        {
            try
            {
                label19.Text += " " + EmployeeDL.TotalEmployees();
                label18.Text += " " + EmployeeDL.TotalCashiers();
                label17.Text += " " + EmployeeDL.TotalManagers();
                label9.Text += " " + ClientDL.TotalClients();
                label10.Text += " " + TransactionDL.TotalTransactions();
                label11.Text += " " + LoanApplicationDL.TotalLoanApplications();
                label12.Text += " " + PaymentDL.TotalPayments();
                label16.Text += " " + AccountDL.TotalAccount();
                label15.Text += " " + AccountDL.TotalCurrentAccount();
                label14.Text += " " + AccountDL.TotalSavingAccount();
                label7.Text += " " + AccountApplicationDL.TotalAccountApplications();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
            
    }
}
