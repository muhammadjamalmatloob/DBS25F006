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
    public partial class BranchManagement : KryptonForm
    {
        public BranchManagement()
        {
            InitializeComponent();
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
            if (kryptonButton2.Text == "Branch Name")
            {
                kryptonButton2.Text = "";
                kryptonButton2.ForeColor = Color.Black;
            }
        }
        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonButton2.Text == "")
            {
                kryptonButton2.Text = "Branch Name";
                kryptonButton2.ForeColor = Color.Gray;
            }
        }


        // add branch
        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            BranchBL branch = new BranchBL();

            branch.set_branch_name(kryptonButton2.Text);
            branch.set_branch_code(Convert.ToInt32(kryptonTextBox3.Text));
            branch.set_address(kryptonTextBox4.Text);
            branch.set_contact(kryptonTextBox5.Text);
            branch.set_city(kryptonTextBox6.Text);
            branch.set_country(kryptonTextBox9.Text);

            BranchDL.AddBranch(branch);

            if (BranchDL.AddBranchInDb(branch))
            {
                MessageBox.Show("Branch Added Successfully");
            }
            else
            {
                MessageBox.Show("Failed to Add Branch");
            }

                GrpAdd.Visible = false;
        }
    }
}
