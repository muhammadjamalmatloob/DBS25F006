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
    public partial class LoanApplications : KryptonForm
    {
        ManagerDashboard manager;
        public LoanApplications(ManagerDashboard manager)
        {
            this.manager = manager;
            InitializeComponent();
            GrpBox.Visible = false;
            kryptonManager1.GlobalPalette = Theme.theme;
            LoanApplicationDL.LoadAllBranchLoansInList();
            LoanApplicationDL.LoadBranchLoansToGrid(kryptonDataGridView1,0,"");
            SetButtonText();
            
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

        private void SetButtonText()
        {
            if (kryptonDataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                {
                    row.Cells["Column6"].Value = "Approve";
                    row.Cells["Column7"].Value = "Reject";
                }
                
            }
        }

        private void apply_loan_filters()
        {

            if (radioButton2.Checked)
            {
                LoanApplicationDL.LoadBranchLoansToGrid(kryptonDataGridView1, 5000, "");
            }
            else if (radioButton1.Checked)
            {
                LoanApplicationDL.LoadBranchLoansToGrid(kryptonDataGridView1, 10000, "");
            }
            else if (radioButton3.Checked)
            {
                LoanApplicationDL.LoadBranchLoansToGrid(kryptonDataGridView1, 20000, "");
            }
            else if (radioButton4.Checked)
            {
                LoanApplicationDL.LoadBranchLoansToGrid(kryptonDataGridView1, 50000, "");
            }

            else if (radioButton5.Checked)
            {
                LoanApplicationDL.LoadBranchLoansToGrid(kryptonDataGridView1, 100000, "");
            }
            SetButtonText();
            GrpBox.Visible = false;
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            apply_loan_filters();
        }

        private void remove_filter()
        {
            LoanApplicationDL.LoadBranchLoansToGrid(kryptonDataGridView1, 0, "");
            SetButtonText();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            remove_filter();
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            if (!(kryptonTextBox1.Text == "Search" || string.IsNullOrEmpty(kryptonTextBox1.Text)))
            {
                LoanApplicationDL.LoadBranchLoansToGrid(kryptonDataGridView1, 0, kryptonTextBox1.Text);
            }
            else
            {
                LoanApplicationDL.LoadBranchLoansToGrid(kryptonDataGridView1, 0, "");
            }
            SetButtonText();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                try
                {
                    if (LoanApplicationDL.Accept(e.RowIndex, kryptonDataGridView1))
                    {
                        LoanApplicationDL.LoadAllBranchLoansInList();
                        LoanApplicationDL.LoadBranchLoansToGrid(kryptonDataGridView1, 0, "");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Not able to accept loan application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured: " +ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                try
                {
                    if (LoanApplicationDL.Reject(e.RowIndex, kryptonDataGridView1))
                    {
                        LoanApplicationDL.LoadAllBranchLoansInList();
                        LoanApplicationDL.LoadBranchLoansToGrid(kryptonDataGridView1, 0, "");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Not able to reject loan application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occured: " + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Cell_Value_Changed(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
