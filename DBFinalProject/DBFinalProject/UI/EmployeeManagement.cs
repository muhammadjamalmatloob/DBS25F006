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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace DBFinalProject
{
    
    public partial class EmployeeManagement : KryptonForm
    {
        AdminDashboard admin;
        public EmployeeManagement(AdminDashboard admin)
        {
            InitializeComponent();
            GrpAdd.Visible = false;
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpDelete.Visible = false;
            GrpAccount.Visible = false;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            BranchDL.LoadAllDataInList();
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox1);
            BranchDL.LoadAllBranchesInComboBox(kryptonComboBox3);

            EmployeeDL.LoadAllEmployeeInList();
            EmployeeDL.LoadEmployeeCombobox(kryptonComboBox5);
            EmployeeDL.LoadEmployeeCombobox(kryptonComboBox6);
            EmployeeDL.LoadDataGrid(dataGrid);

            kryptonComboBox1.SelectedIndex = 0;
            kryptonComboBox2.SelectedIndex = 0;
            kryptonComboBox8.SelectedIndex = 0;
            this.admin = admin;
            this.kryptonManager1.GlobalPalette = Theme.theme;
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            GrpAdd.Visible = true;
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpDelete.Visible = false;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = true;
            GrpAdd.Visible = false;
            GrpUpdate.Visible = false;
            GrpDelete.Visible = false;
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
        }


        // add employee
        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            GrpAdd.Visible = false;
            GrpAccount.Visible = true;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            GrpUpdate.Visible = true;
            GrpAdd.Visible = false;
            GrpBox.Visible = false;
            GrpDelete.Visible = false;
        }


        // update employee
        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            string selectedItem = "";
            try
            {
                selectedItem = kryptonComboBox5.SelectedItem.ToString();
            }
            catch 
            {
                MessageBox.Show("Please select an employee to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] parts = selectedItem.Split(' ');
            int employee_Id = Convert.ToInt32(parts[0]);

            EmployeeBL employee = new EmployeeBL();

            try
            {
                employee.set_salary(float.Parse(kryptonTextBox7.Text));
                employee.set_contact(kryptonTextBox8.Text);
                employee.set_department(kryptonComboBox4.Text);
                employee.set_branch_id(BranchDL.GetBranchIdByName(kryptonComboBox3.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EmployeeDL.updateEmployeeInDb(employee, employee_Id))
            {
                
                EmployeeDL.LoadDataGrid(dataGrid);
                //EmployeeDL.UpdateEmployee(employee_Id, employee);
                EmployeeDL.LoadAllEmployeeInList();
                MessageBox.Show("Employee Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to Update Employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                
            }
            GrpUpdate.Visible = false;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            GrpDelete.Visible = true;
            GrpAdd.Visible = false;
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            GrpDelete.Visible = false;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            GrpUpdate.Visible = false;
        }

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            GrpAdd.Visible = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            admin.Show();
        }

        private void kryptonButton13_Click_1(object sender, EventArgs e)
        {
            GrpAdd.Visible = false;
        }


        // create account 
        private void kryptonButton16_Click(object sender, EventArgs e)
        {
            EmployeeBL employee = new EmployeeBL();


            try
            {
                employee.set_first_name(kryptonTextBox2.Text);
                employee.set_last_name(kryptonTextBox3.Text);
                employee.set_department(kryptonComboBox8.Text);
                employee.set_branch_id(BranchDL.GetBranchIdByName(kryptonComboBox1.Text));
                employee.set_gender(kryptonComboBox2.Text);
                employee.set_salary(float.Parse(kryptonTextBox6.Text));
                employee.set_contact(kryptonTextBox5.Text);
                employee.set_position(UserDL.get_role_id(kryptonComboBox7.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                employee.set_role_id(UserDL.get_role_id(kryptonComboBox7.Text));
                employee.set_username(kryptonTextBox9.Text);
                employee.set_email(kryptonTextBox10.Text);
                employee.set_password_hash(kryptonTextBox11.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (EmployeeDL.AddEmployeeAccountInDb(employee))
            {
                employee.set_user_id(UserDL.get_user_id(employee.get_username()));
                if (EmployeeDL.AddEmployeeInDb(employee))
                {
                    EmployeeDL.LoadAllEmployeeInList();
                    EmployeeDL.LoadEmployeeCombobox(kryptonComboBox5);
                    EmployeeDL.LoadEmployeeCombobox(kryptonComboBox6);
                    EmployeeDL.LoadDataGrid(dataGrid);
                    //employee.set_employee_id(EmployeeDL.get_employee_id(employee.get_contact()));
                    //EmployeeDL.AddEmployeeToList(employee);

                    MessageBox.Show("Employee Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show("Failed to Add Employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

                MessageBox.Show("Failed to Add Employee Account", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            GrpAccount.Visible = false;
        }

        private void kryptonButton15_Click(object sender, EventArgs e)
        {
            GrpAccount.Visible = false;
            GrpAdd.Visible = true;
        }


        // delete employee
        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            string selectedItem = "";
            try
            {
                selectedItem = kryptonComboBox6.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Please select an employee to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] parts = selectedItem.Split(' ');
            int employee_Id = Convert.ToInt32(parts[0]);

            if (EmployeeDL.deleteEmployee(employee_Id))
            {
                EmployeeDL.LoadAllEmployeeInList();
                //EmployeeDL.RemoveEmployee(employee_Id);
                EmployeeDL.LoadDataGrid(dataGrid);
                
                EmployeeDL.LoadEmployeeCombobox(kryptonComboBox5);
                EmployeeDL.LoadEmployeeCombobox(kryptonComboBox6);
                MessageBox.Show("Employee Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to Delete Employee", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GrpDelete.Visible = false;
        }

        public void apply_employee_filters()
        {
            dataGrid.Rows.Clear(); 

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

            EmployeeDL.ApplyFilter(orderBy,dataGrid);
            GrpBox.Visible = false;
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            apply_employee_filters();
        }
    }
}
