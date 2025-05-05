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

namespace DBFinalProject.UI
{
    public partial class Audit : KryptonForm
    {
        public Audit()
        {
            InitializeComponent();

            load_all_audits();
            hide_all_groups();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            hide_all_groups();
            Application.Exit();
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            hide_all_groups();
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // branch audit
        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            hide_all_groups();
            GrpBranch.Visible = true;
        }


        // back branch
        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            hide_all_groups();
        }

        //back
        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            hide_all_groups();
        }

        //back
        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            hide_all_groups();
        }

        //back
        private void kryptonButton15_Click(object sender, EventArgs e)
        {
            hide_all_groups();
        }


        //back
        private void kryptonButton16_Click(object sender, EventArgs e)
        {
            hide_all_groups();
        }


        //loan type audit
        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            hide_all_groups();
            GrpLoanType.Visible = true;
        }


        //client
        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            hide_all_groups();
            GrpClient.Visible = true;
        }


        //employee
        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            hide_all_groups();
            GrpEmployee.Visible = true;
        }

        //trans
        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            hide_all_groups();
            GrpTransaction.Visible = true;
        }

        //payment
        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            hide_all_groups();
            GrpPayment.Visible = true;
        }

        //exchange
        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            hide_all_groups();
            GrpExchange.Visible = true;
        }


        // account
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            hide_all_groups();
            GrpAccount.Visible = true;
        }

        // back
        private void kryptonButton20_Click(object sender, EventArgs e)
        {
            hide_all_groups();

        }

        // back
        private void kryptonButton19_Click(object sender, EventArgs e)
        {
            hide_all_groups();
        }

        // back
        private void kryptonButton18_Click(object sender, EventArgs e)
        {
            hide_all_groups();

        }

        // back
        private void kryptonButton17_Click(object sender, EventArgs e)
        {
            hide_all_groups();
        }

        private void load_all_audits()
        {
            AuditDL.LoadDataGrid_branch(dgvBranch);
            AuditDL.LoadDataGrid_client(dgvClient);
            AuditDL.LoadDataGrid_employee(dgvEmployee);
            AuditDL.LoadDataGrid_transaction(dgvTransaction);
            AuditDL.LoadDataGrid_payment(dgvPayment);
            AuditDL.LoadDataGrid_exchange(dgvExchange);
            AuditDL.LoadDataGrid_account(dgvAccount);
        }
        private void hide_all_groups()
        {
            GrpBranch.Visible = false;
            GrpClient.Visible = false;
            GrpEmployee.Visible = false;
            GrpTransaction.Visible = false;
            GrpPayment.Visible = false;
            GrpExchange.Visible = false;
            GrpAccount.Visible = false;
            GrpLoanType.Visible = false;
        }

        //back
        private void kryptonButton16_Click_1(object sender, EventArgs e)
        {
            hide_all_groups();
        }

        private void kryptonButton11_Click1(object sender, EventArgs e)
        {
            hide_all_groups();
        }

        private void kryptonButton13_Click_1(object sender, EventArgs e)
        {
            hide_all_groups();
        }

        private void kryptonButton13_Click_2(object sender, EventArgs e)
        {
            hide_all_groups();
        }
    }
}
