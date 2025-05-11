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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace DBFinalProject
{
    public partial class BranchManagement : KryptonForm
    {
        AdminDashboard admin;
        public BranchManagement(AdminDashboard admin)
        {
            InitializeComponent();

            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox2);
            BranchDL.LoadDataGrid(BranchDL.branchList, dgvBranch);
            kryptonComboBox1.SelectedIndex = 0;
            kryptonComboBox2.SelectedIndex = 0;


            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpAdd.Visible = false;
            GrpDelete.Visible = false;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            this.admin = admin;
            this.kryptonManager1.GlobalPalette = Theme.theme;
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin.Show();
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
            clear_grp();
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpAdd.Visible = true;
            GrpDelete.Visible = false;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            clear_grp();
            GrpBox.Visible = false;
            GrpUpdate.Visible = true;
            GrpAdd.Visible = false;
            GrpDelete.Visible = false;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            clear_grp();
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
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Black;
            }
        }
        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Branch Name";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Gray;
            }
        }


        // add branch
        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            BranchBL branch = new BranchBL();

            try
            {
                branch.set_branch_name(kryptonTextBox2.Text);
                //branch.set_branch_code(Convert.ToInt32(kryptonTextBox3.Text));
                branch.set_address(kryptonTextBox4.Text);
                branch.set_contact(kryptonTextBox5.Text);
                branch.set_city(kryptonTextBox6.Text);
                branch.set_country(kryptonTextBox9.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (BranchDL.AddBranchInDb(branch))
                {
                    MessageBox.Show("Branch Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BranchDL.LoadAllDataInList();
                }
                else
                {
                    MessageBox.Show("Failed to Add Branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Failed to Add Branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            apply_filters();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox2);
            GrpAdd.Visible = false;
        }

        private void kryptonButton2_Enter(object sender, EventArgs e)
        {

        }



        private void kryptonTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox4_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox4.Text == "Address ")
            {
                kryptonTextBox4.Text = "";

                kryptonTextBox4.StateCommon.Content.Color1 = Color.Black;

            }
        }

        private void kryptonTextBox4_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox4.Text == "")
            {
                kryptonTextBox4.Text = "Address ";
                kryptonTextBox4.StateCommon.Content.Color1 = Color.Gray;
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

            try
            {
                if (BranchDL.DeleteBranchInDb(branch_id))
                {
                    MessageBox.Show("Branch Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BranchDL.LoadAllDataInList();


                }
                else
                {
                    MessageBox.Show("Failed to Delete Branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            apply_filters();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox2);
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

            try
            {
                branch.set_address(kryptonTextBox11.Text);
                branch.set_city(kryptonTextBox10.Text);
                branch.set_contact(kryptonTextBox8.Text);
                branch.set_country(kryptonTextBox7.Text);
            


            if (BranchDL.UpdateBranchInDb(branch))
            {
                MessageBox.Show("Branch Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BranchDL.LoadAllDataInList();
            }
            else
            {
                MessageBox.Show("Failed to Update Branch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            apply_filters();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox2);
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

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void kryptonTextBox5_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox5.Text == "Contact")
            {
                kryptonTextBox5.Text = "";
                kryptonTextBox5.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox5_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox5.Text == "")
            {
                kryptonTextBox5.Text = "Contact";
                kryptonTextBox5.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox9_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox9.Text == "Country")
            {
                kryptonTextBox9.Text = "";
                kryptonTextBox9.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox9_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox9.Text == "")
            {
                kryptonTextBox9.Text = "Country";
                kryptonTextBox9.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox6_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox6.Text == "City")
            {
                kryptonTextBox6.Text = "";
                kryptonTextBox6.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox6_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox6.Text == "")
            {
                kryptonTextBox6.Text = "City";
                kryptonTextBox6.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox11_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox11.Text == "Address ")
            {
                kryptonTextBox11.Text = "";
                kryptonTextBox11.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox11_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox11.Text == "")
            {
                kryptonTextBox11.Text = "Address ";
                kryptonTextBox11.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox10_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox10.Text == "City")
            {
                kryptonTextBox10.Text = "";
                kryptonTextBox10.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox10_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox10.Text == "")
            {
                kryptonTextBox10.Text = "City";
                kryptonTextBox10.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox8_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox8.Text == "Contact")
            {
                kryptonTextBox8.Text = "";
                kryptonTextBox8.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox8_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox8.Text == "")
            {
                kryptonTextBox8.Text = "Contact";
                kryptonTextBox8.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox7_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox7.Text == "Country")
            {
                kryptonTextBox7.Text = "";
                kryptonTextBox7.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox7_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox7.Text == "")
            {
                kryptonTextBox7.Text = "Country";
                kryptonTextBox7.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Search Branch")
            {
                kryptonTextBox1.Text = "";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Search Branch";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            string search = kryptonTextBox1.Text.Trim();
            if (string.IsNullOrEmpty(search)  || search == "Search Branch")
            {
                return;
            }

            var filteredList = BranchDL.branchList.Where(b => b.get_branch_name().ToLower().Contains(search)).ToList();
            BranchDL.LoadDataGrid(filteredList, dgvBranch);
        }
        private void clear_grp()
        {
            kryptonTextBox7.Text = "Country";
            kryptonTextBox8.Text = "Contact";
            kryptonTextBox10.Text = "City";
            kryptonTextBox11.Text = "Address ";
            kryptonTextBox2.Text = "Branch Name";
            kryptonComboBox1.SelectedIndex = 0;
            kryptonComboBox2.SelectedIndex = 0;
        }
            
    }
}
