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

namespace DBFinalProject
{
    public partial class LoanManagement : KryptonForm
    {
        public LoanManagement()
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
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
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

        private void kryptonTextBox12_Enter(object sender, EventArgs e)
        {
            if  (kryptonTextBox12.Text == "Descryption")
                {
                    kryptonTextBox12.Text = "";
                    kryptonTextBox12.StateCommon.Content.Color1 = Color.Black;
                }
        }

        private void kryptonTextBox12_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox12.Text == "")
            {
                kryptonTextBox12.Text = "Descryption";
                kryptonTextBox12.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox10_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox10.Text == "Loan Terms")
            {
                kryptonTextBox10.Text = "";
                kryptonTextBox10.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox10_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox10.Text == "")
            {
                kryptonTextBox10.Text = "Loan Terms";
                kryptonTextBox10.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox11_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox11.Text == "Interest Rate")
            {
                kryptonTextBox11.Text = "";
                kryptonTextBox11.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox11_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox11.Text == "")
            {
                kryptonTextBox11.Text = "Interest Rate";
                kryptonTextBox11.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox9_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox9.Text == "Eligibility")
            {
                kryptonTextBox9.Text = "";
                kryptonTextBox9.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox9_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox9.Text == "")
            {
                kryptonTextBox9.Text = "Eligibility";
                kryptonTextBox9.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "Type Name")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Type Name";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "Loan Terms")
            {
                kryptonTextBox3.Text = "";
                kryptonTextBox3.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox3_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "")
            {
                kryptonTextBox3.Text = "Loan Terms";
                kryptonTextBox3.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox7_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox7.Text == "Interest Rate")
            {
                kryptonTextBox7.Text = "";
                kryptonTextBox7.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox7_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox7.Text == "")
            {
                kryptonTextBox7.Text = "Interest Rate";
                kryptonTextBox7.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox6_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox6.Text == "Repayment Frequency")
            {
                kryptonTextBox6.Text = "";
                kryptonTextBox6.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox6_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox6.Text == "")
            {
                kryptonTextBox6.Text = "Repayment Frequency";
                kryptonTextBox6.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox5_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox5.Text == "Descryption")
            {
                kryptonTextBox5.Text = "";
                kryptonTextBox5.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox5_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox5.Text == "")
            {
                kryptonTextBox5.Text = "Descryption";
                kryptonTextBox5.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox8_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox8.Text == "Eligibility")
            {
                kryptonTextBox8.Text = "";
                kryptonTextBox8.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox8_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox8.Text == "")
            {
                kryptonTextBox8.Text = "Eligibility";
                kryptonTextBox8.StateCommon.Content.Color1 = Color.Gray;
            }
        }
    }
}
