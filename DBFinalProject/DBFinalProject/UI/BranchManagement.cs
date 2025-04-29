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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace DBFinalProject
{
    public partial class BranchManagement : KryptonForm
    {
        public BranchManagement()
        {
            InitializeComponent();

            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox2);
            BranchDL.LoadDataGrid(BranchDL.branchList,dgvBranch);



            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpAdd.Visible = false;
            GrpDelete.Visible = false;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = true;
            GrpUpdate.Visible = false;
            GrpAdd.Visible = false;
            GrpDelete.Visible = false;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpAdd.Visible = true;
            GrpDelete.Visible = false;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
            GrpUpdate.Visible = true;
            GrpAdd.Visible = false;
            GrpDelete.Visible = false;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpAdd.Visible = false;
            GrpDelete.Visible = true;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
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

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            GrpDelete.Visible = false;
        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {
         
        }
        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "Branch Name")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.ForeColor = Color.Black;
            }
        }
        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Branch Name";
                kryptonTextBox2.ForeColor = Color.Gray;
            }
        }


        // add branch
        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            BranchBL branch = new BranchBL();

            branch.set_branch_name(kryptonTextBox2.Text);
            branch.set_branch_code(Convert.ToInt32(kryptonTextBox3.Text));
            branch.set_address(kryptonTextBox4.Text);
            branch.set_contact(kryptonTextBox5.Text);
            branch.set_city(kryptonTextBox6.Text);
            branch.set_country(kryptonTextBox9.Text);

            

            if (BranchDL.AddBranchInDb(branch))
            {
                MessageBox.Show("Branch Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                branch.set_branch_id(BranchDL.GetBranchIdByName(branch.get_branch_name()));
                BranchDL.AddBranch(branch);
            }
            else
            {
                MessageBox.Show("Failed to Add Branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            apply_filters();
            GrpAdd.Visible = false;
        }

        private void kryptonButton2_Enter(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "Branch Code ")
            {
                kryptonTextBox3.Text = "";
                kryptonTextBox3.ForeColor = Color.Black;
            }
        }

        private void kryptonTextBox3_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "")
            {
                kryptonTextBox3.Text = "Branch Code ";
                kryptonTextBox3.ForeColor = Color.Black;
            }
        }

        private void kryptonTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox4_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox4.Text == "Address ")
            {
                kryptonTextBox4.Text = "";
                
                kryptonButton4.StateCommon.Content.ShortText.Color1 = Color.Black;

            }
        }

        private void kryptonTextBox4_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "")
            {
                kryptonTextBox3.Text = "Address ";
                kryptonButton4.StateCommon.Content.ShortText.Color1 = Color.Black;
            }
        }


        // delete branch
        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            string selectedBranchName = kryptonComboBox1.Text.Trim();
            if (kryptonComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a branch first.");
                return;
            }
            BranchBL branch = new BranchBL();
            int branch_id = Convert.ToInt32(BranchDL.GetBranchIdByName(selectedBranchName));
            branch.set_branch_id(branch_id);

            BranchBL b = BranchDL.GetBranchById(branch_id);
            if (BranchDL.DeleteBranchInDb(branch_id))
            {
                MessageBox.Show("Branch Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"{BranchDL.branchList.Count}");
                BranchDL.RemoveBranch(b, branch_id);
                MessageBox.Show($"{BranchDL.branchList.Count}");
            }
            else
            {
                MessageBox.Show("Failed to Delete Branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            apply_filters();
            GrpDelete.Visible = false;
        }

        // update 
        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            string selectedBranchName = kryptonComboBox2.Text.Trim();
            if (kryptonComboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a branch first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int branch_id = Convert.ToInt32(BranchDL.GetBranchIdByName(selectedBranchName));
            BranchBL branch = new BranchBL();
            branch.set_branch_id(branch_id);

            branch.set_address(kryptonTextBox11.Text);
            branch.set_city(kryptonTextBox10.Text);
            branch.set_contact(kryptonTextBox8.Text);
            branch.set_country(kryptonTextBox7.Text);

            if (BranchDL.UpdateBranchInDb(branch))
            {
                MessageBox.Show("Branch Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BranchDL.UpdateBranch(branch_id,branch);
            }
            else
            {
                MessageBox.Show("Failed to Update Branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            apply_filters();
            GrpUpdate.Visible = false;

        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            apply_filters();
        }

        public void apply_filters()
        {
            dgvBranch.Rows.Clear();
            List<BranchBL> branchList = BranchDL.branchList;

            if (radioButton1.Checked && radioButton4.Checked)
            {
                branchList = branchList.OrderBy(branch => branch.get_branch_id()).ToList();
            }
            else if (radioButton1.Checked && radioButton2.Checked)
            {
                branchList = branchList.OrderByDescending(branch => branch.get_branch_id()).ToList();
            }
            else if (radioButton3.Checked && radioButton4.Checked)
            {
                branchList = branchList.OrderBy(branch => branch.get_branch_name()).ToList();
            }
            else if (radioButton3.Checked && radioButton2.Checked)
            {
                branchList = branchList.OrderByDescending(branch => branch.get_branch_name()).ToList();
            }

            BranchDL.LoadDataGrid(branchList, dgvBranch);
            GrpBox.Visible = false;
        }
    }
}
