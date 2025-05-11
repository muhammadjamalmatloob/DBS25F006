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
using DBFinalProject.UI;
using DBFinalProject.Utility;
using Mysqlx.Crud;

namespace DBFinalProject
{
    public partial class BranchEmployees : KryptonForm
    {
        ManagerDashboard manager;
        public BranchEmployees(ManagerDashboard manager)
        {
            this.manager = manager;
            InitializeComponent();
            GrpNme.Visible = false;
            grptype.Visible = false;
            GrpBox.Visible = false;
            GrpDep.Visible = false;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            kryptonManager1.GlobalPalette = Theme.theme;
            EmployeeDL.LoadAllBranchEmployeeInList();
            EmployeeDL.LoadBranchEmployeeGrid(dataGrid);
            EmployeeDL.LoadBranchEmployeeCombobox(kryptonComboBox7);
            EmployeeDL.LoadDepartmentCombobox(kryptonComboBox2);
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            manager.Show();
            
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            GrpNme.Visible = true;
            grptype.Visible = false;
            GrpBox.Visible = false;
            GrpDep.Visible = false;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpNme.Visible = false;
            grptype.Visible = false;
            GrpBox.Visible = true;
            GrpDep.Visible = false;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            GrpNme.Visible = false;
            grptype.Visible = false;
            GrpBox.Visible = false;
            GrpDep.Visible = true;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            GrpNme.Visible = false;
            grptype.Visible = true;
            GrpBox.Visible = false;
            GrpDep.Visible = false;
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            GrpNme.Visible = false;
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            grptype.Visible = false;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            GrpDep.Visible = false;
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void apply_employee_filters()
        {

            string orderBy = "";

            if (radioButton1.Checked && radioButton4.Checked)
            {
                orderBy = "ORDER BY e.employee_id ASC";
            }
            else if (radioButton1.Checked && radioButton2.Checked)
            {
                orderBy = "ORDER BY e.employee_id DESC";
            }
            else if (radioButton3.Checked && radioButton4.Checked)
            {
                orderBy = "ORDER BY e.first_name ASC";
            }
            else if (radioButton3.Checked && radioButton2.Checked)
            {
                orderBy = "ORDER BY e.first_name DESC";
            }
            
            EmployeeDL.ApplyBranchFilters(orderBy);
            GrpBox.Visible = false;
        }
        private void Search()
        {
            string search = kryptonTextBox1.Text;
            if (!string.IsNullOrEmpty(search) && search != "Search")
            {
                string condition = $"and (first_name like '{search}%' or last_name like '{search}%')";
                EmployeeDL.ApplyBranchFilters(condition);
                GrpBox.Visible = false;
                EmployeeDL.LoadBranchEmployeeGrid(dataGrid);

            }
            else
            {
                EmployeeDL.LoadAllBranchEmployeeInList();
                EmployeeDL.LoadBranchEmployeeGrid(dataGrid);
            }
            
            
        }
        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {
            string search = kryptonTextBox1.Text;
            if (string.IsNullOrEmpty(search) && search == "Search")
            {
                EmployeeDL.LoadAllBranchEmployeeInList();
                EmployeeDL.LoadBranchEmployeeGrid(dataGrid);
            }
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
            Search();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            apply_employee_filters();
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox7.SelectedIndex > 0)
            {
                kryptonComboBox1.SelectedIndex = 0;
                kryptonComboBox2.SelectedIndex = 0;
                string condition = $"and concat(first_name, ' ', last_name) = '{kryptonComboBox7.Text}'";
                EmployeeDL.ApplyBranchFilters(condition);
                EmployeeDL.LoadBranchEmployeeGrid(dataGrid);
            }
            GrpNme.Visible = false;
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox1.SelectedIndex > 0)
            {
                kryptonComboBox7.SelectedIndex = 0;
                kryptonComboBox2.SelectedIndex = 0;
                string condition = $"and l.value = '{kryptonComboBox1.Text}'";
                EmployeeDL.ApplyBranchFilters(condition);
                EmployeeDL.LoadBranchEmployeeGrid(dataGrid);
            }
            grptype.Visible = false;
        }

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            if (kryptonComboBox2.SelectedIndex > 0)
            {
                kryptonComboBox7.SelectedIndex = 0;
                kryptonComboBox1.SelectedIndex = 0;
                string condition = $"and department = '{kryptonComboBox2.Text}'";
                EmployeeDL.ApplyBranchFilters(condition);
                EmployeeDL.LoadBranchEmployeeGrid(dataGrid);
            }
            GrpDep.Visible = false;
        }

        private void kryptonButton15_Click(object sender, EventArgs e)
        {
            new BranchEmployeeReport().Show();
        }
    }
}
