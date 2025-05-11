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
    public partial class TransactionRecord : KryptonForm
    {
        ManagerDashboard manager;
        public TransactionRecord(ManagerDashboard manager)
        {
            InitializeComponent();
            GrpBox.Visible = false;
            this.manager = manager;
            kryptonManager1.GlobalPalette = Theme.theme;
            TransactionDL.LoadAllBranchTransactionsInList();
            TransactionDL.LoadBranchTransactionsToGrid(kryptonDataGridView1, 0, "");
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = true;
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
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

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            if (!(kryptonTextBox1.Text == "Search" || string.IsNullOrEmpty(kryptonTextBox1.Text)))
            {
                TransactionDL.LoadBranchTransactionsToGrid(kryptonDataGridView1, 0, kryptonTextBox1.Text);
            }
            else
            {
                TransactionDL.LoadBranchTransactionsToGrid(kryptonDataGridView1, 0, "");
            }
        }

        private void apply_transaction_filters()
        {

            if (radioButton2.Checked)
            {
                TransactionDL.LoadBranchTransactionsToGrid(kryptonDataGridView1, 5000, "");
            }
            else if (radioButton1.Checked)
            {
                TransactionDL.LoadBranchTransactionsToGrid(kryptonDataGridView1, 10000, "");
            }
            else if (radioButton3.Checked)
            {
                TransactionDL.LoadBranchTransactionsToGrid(kryptonDataGridView1, 20000, "");
            }
            else if (radioButton4.Checked)
            {
                TransactionDL.LoadBranchTransactionsToGrid(kryptonDataGridView1, 50000, "");
            }

            else if (radioButton5.Checked)
            {
                TransactionDL.LoadBranchTransactionsToGrid(kryptonDataGridView1, 100000, "");
            }

            GrpBox.Visible = false;
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            apply_transaction_filters();
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

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            TransactionDL.LoadBranchTransactionsToGrid(kryptonDataGridView1, 0, "");
        }
    }
}
