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
using DBFinalProject.BL;
using DBFinalProject.DL;
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class LoanManagement : KryptonForm
    {
        AdminDashboard admin;
        public LoanManagement(AdminDashboard admin)
        {
            InitializeComponent();
            GrpBox.Visible = false;
            GrpDelete.Visible = false;
            GrpAdd.Visible = false;
            GrpUpdate.Visible = false;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            kryptonComboBox3.SelectedIndex = 0;
            kryptonComboBox2.SelectedIndex = 0;

            LoanTypeDL.LoadAllLoanTypes();
            LoanTypeDL.LoadLoanTypeInComboBox(kryptonComboBox2);
            LoanTypeDL.LoadLoanTypeInComboBox(kryptonComboBox3);
            LoanTypeDL.LoadDataGrid(LoanTypeDL.loanTypeList, dgvLoan);
            this.admin = admin;
            this.kryptonManager1.GlobalPalette = Theme.theme;
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin.Show();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = true;
            GrpDelete.Visible = false;
            GrpAdd.Visible = false;
            GrpUpdate.Visible = false;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
            GrpDelete.Visible = false;
            GrpAdd.Visible = true;
            GrpUpdate.Visible = false;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
            GrpDelete.Visible = false;
            GrpAdd.Visible = false;
            GrpUpdate.Visible = true;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
            GrpDelete.Visible = true;
            GrpAdd.Visible = false;
            GrpUpdate.Visible = false;
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
        }

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            GrpAdd.Visible = false;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            GrpUpdate.Visible = false;
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            GrpDelete.Visible = false;
        }

        // add loan type
        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            LoanTypeBL loanTypeBL = new LoanTypeBL();

            try
            {
                loanTypeBL.set_type_name(kryptonTextBox2.Text);
                loanTypeBL.set_descryptions(kryptonTextBox5.Text);
                loanTypeBL.set_loan_terms(kryptonTextBox3.Text);
                loanTypeBL.set_interest_rate(Convert.ToInt32(kryptonTextBox7.Text));
                loanTypeBL.set_repayment_frequency(kryptonTextBox6.Text);
                loanTypeBL.set_eligibility(kryptonTextBox8.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (LoanTypeDL.addLoanType(loanTypeBL))
            {
                loanTypeBL.set_loan_type_id(LoanTypeDL.getIdByName(kryptonTextBox2.Text));
                LoanTypeDL.LoadAllLoanTypes();
                LoanTypeDL.LoadDataGrid(LoanTypeDL.loanTypeList, dgvLoan);
                LoanTypeDL.LoadLoanTypeInComboBox(kryptonComboBox2);
                LoanTypeDL.LoadLoanTypeInComboBox(kryptonComboBox3);
                MessageBox.Show("Loan Type Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to Add Loan Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            GrpAdd.Visible = false;
        }

        // update loan type
        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            string selectedItem = "";

                selectedItem = kryptonComboBox3.SelectedItem.ToString();
            
            
            int loan_type_id = LoanTypeDL.getIdByName(selectedItem);
            LoanTypeBL loanTypeBL = new LoanTypeBL();

            loanTypeBL.set_type_name(LoanTypeDL.getNameByID(loan_type_id));
            try
            {
                loanTypeBL.set_descryptions(kryptonTextBox12.Text);
                loanTypeBL.set_loan_terms(kryptonTextBox10.Text);
                loanTypeBL.set_interest_rate(Convert.ToInt32(kryptonTextBox11.Text));
                loanTypeBL.set_eligibility(kryptonTextBox9.Text);
                loanTypeBL.set_repayment_frequency(LoanTypeDL.getRepaymentFrequencyByID(loan_type_id));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (LoanTypeDL.UpdateLoanTypeInDb(loan_type_id, loanTypeBL))
            {
                LoanTypeDL.LoadAllLoanTypes();
                LoanTypeDL.LoadDataGrid(LoanTypeDL.loanTypeList, dgvLoan);
                LoanTypeDL.LoadLoanTypeInComboBox(kryptonComboBox2);
                LoanTypeDL.LoadLoanTypeInComboBox(kryptonComboBox3);
                MessageBox.Show("Loan Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to Update Loan Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // delete loan type
        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            string selectedItem = "";
            try
            {
                selectedItem = kryptonComboBox2.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select Loan Type first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int loan_type_id = LoanTypeDL.getIdByName(selectedItem);

            if (LoanTypeDL.DeleteLoanTypeInDb(loan_type_id))
            {
                LoanTypeDL.LoadAllLoanTypes();
                LoanTypeDL.LoadDataGrid(LoanTypeDL.loanTypeList, dgvLoan);
                LoanTypeDL.LoadLoanTypeInComboBox(kryptonComboBox2);
                LoanTypeDL.LoadLoanTypeInComboBox(kryptonComboBox3);
                MessageBox.Show("Loan Type Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to Delete Loan Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void apply_filters()
        {
            dgvLoan.Rows.Clear();
            List<LoanTypeBL> loanTypes = LoanTypeDL.loanTypeList;

            if (radioButton1.Checked && radioButton4.Checked)
            {
                loanTypes = loanTypes.OrderBy(lt => lt.get_loan_type_id()).ToList();
            }
            else if (radioButton1.Checked && radioButton2.Checked)
            {
                loanTypes = loanTypes.OrderByDescending(lt => lt.get_loan_type_id()).ToList();
            }
            else if (radioButton3.Checked && radioButton4.Checked)
            {
                loanTypes = loanTypes.OrderBy(lt => lt.get_type_name()).ToList();
            }
            else if (radioButton3.Checked && radioButton2.Checked)
            {
                loanTypes = loanTypes.OrderByDescending(lt => lt.get_type_name()).ToList();
            }

            LoanTypeDL.LoadDataGrid(loanTypes, dgvLoan);
            GrpBox.Visible = false;
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            apply_filters();
        }

        private void dgvLoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GrpBox_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
