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
    public partial class BillPayments : KryptonForm
    {
        ManagerDashboard manager;
        public BillPayments(ManagerDashboard manager)
        {
            InitializeComponent();
            GrpBox.Visible = false;
            radioButton2.Checked = true;
            this.manager = manager;
            kryptonManager1.GlobalPalette = Theme.theme;
            PaymentDL.LoadAllBranchPaymentInList();
            PaymentDL.LoadBranchPaymentsToGrid(kryptonDataGridView1, 0, "");
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            manager.Show();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = true;
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
        }

        private void apply_payment_filters()
        {

            if (radioButton2.Checked)
            {
                PaymentDL.LoadBranchPaymentsToGrid(kryptonDataGridView1, 5000, "");
            }
            else if (radioButton1.Checked)
            {
                PaymentDL.LoadBranchPaymentsToGrid(kryptonDataGridView1, 10000, "");
            }
            else if (radioButton3.Checked)
            {
                PaymentDL.LoadBranchPaymentsToGrid(kryptonDataGridView1, 20000, "");
            }
            else if (radioButton4.Checked)
            {
                PaymentDL.LoadBranchPaymentsToGrid(kryptonDataGridView1, 50000, "");
            }

            else if (radioButton5.Checked)
            {
                PaymentDL.LoadBranchPaymentsToGrid(kryptonDataGridView1, 100000, "");
            }

            GrpBox.Visible = false;
        }

        private void kryptonTextBox1_Focus(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Search")
            {
                kryptonTextBox1.Text = "";
                kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }

        private void kryptonTextBox1_LostFocus(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Search";
                kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            }

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            if (!(kryptonTextBox1.Text == "Search" || string.IsNullOrEmpty(kryptonTextBox1.Text)))
            {
                PaymentDL.LoadBranchPaymentsToGrid(kryptonDataGridView1, 0, kryptonTextBox1.Text);
            }
            else
            {
                PaymentDL.LoadBranchPaymentsToGrid(kryptonDataGridView1, 0, "");
            }
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            apply_payment_filters();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            PaymentDL.LoadBranchPaymentsToGrid(kryptonDataGridView1, 0, "");
        }
    }
}
