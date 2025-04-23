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
    }
}
