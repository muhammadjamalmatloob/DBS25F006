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
    public partial class AdminDashboard : KryptonForm
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            BranchManagement branchManagement = new BranchManagement();
            branchManagement.Show();
            this.Hide();

            //ApplicationForm applicationForm = new ApplicationForm();
            //applicationForm.Show();
            //this.Hide();
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
    }
}
