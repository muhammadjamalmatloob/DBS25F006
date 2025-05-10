using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.Utility;
using Org.BouncyCastle.Asn1.Mozilla;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DBFinalProject.DL
{
    internal class EmployeeDL
    {
        public static List<EmployeeBL> employees = new List<EmployeeBL>();
        public static List<string> departments = new List<string>();

        public static bool AddEmployeeInDb(EmployeeBL employee)
        {
            string query = $"INSERT INTO employees (user_id,first_name,last_name,gender,department,position,branch_id,salary,contact,email)VALUES ({employee.get_user_id()},'{employee.get_first_name()}','{employee.get_last_name()}','{employee.get_gender()}','{employee.get_department()}',{employee.get_position()},{employee.get_branch_id()},{employee.get_salary()},'{employee.get_contact()}','{employee.get_email()}')";
            return DatabaseHelper.Instance.Update(query) > 0;
        }
        public static bool AddEmployeeAccountInDb(EmployeeBL employee)
        {
            string query = $"INSERT INTO users (username,email,password_hash,role_id) VALUES ('{employee.get_username()}','{employee.get_email()}','{employee.get_password_hash()}',{employee.get_role_id()})";
            return DatabaseHelper.Instance.Update(query) > 0;
        }

        public static bool AddEmployeeWithTransaction(EmployeeBL employee)
        {
            string transaction = $@"
                    START TRANSACTION;" +
                    $"INSERT INTO users (username, email, password_hash, role_id)" +
                    $"VALUES ('{employee.get_username()}', '{employee.get_email()}', '{employee.get_password_hash()}', {employee.get_role_id()});"+

                    $"INSERT INTO employees (user_id, first_name, last_name, gender, department, position, branch_id, salary, contact, email)" +
                   $" VALUES (LAST_INSERT_ID(), '{employee.get_first_name()}', '{employee.get_last_name()}', '{employee.get_gender()}', '{employee.get_department()}', {employee.get_position()}, {employee.get_branch_id()}, {employee.get_salary()}, '{employee.get_contact()}', '{employee.get_email()}'); " +
                    $"COMMIT;";
            return DatabaseHelper.Instance.Update(transaction) > 0;
        }

        public static bool DeleteEmployeeWithTransaction(int employee_id,int user_id)
        {
            string transaction = $@"
                                START TRANSACTION;
                                DELETE FROM users WHERE user_id = {user_id};
                                DELETE FROM employees WHERE employee_id = {employee_id};
                                COMMIT;";
            return DatabaseHelper.Instance.Update(transaction) > 0;
        }

        public static void AddEmployeeToList(EmployeeBL employee)
        {
            employees.Add(employee);
        }
        public static void UpdateEmployee(int employee_id_to_update, EmployeeBL updatedEmployee)
        {
            foreach (EmployeeBL employee in employees)
            {
                if (employee.get_employee_id() == employee_id_to_update)
                {
                    employee.set_salary(updatedEmployee.get_salary());
                    employee.set_contact(updatedEmployee.get_contact());
                    employee.set_department(updatedEmployee.get_department());
                    employee.set_branch_id(updatedEmployee.get_branch_id());
                }
            }
        }
        

        public static bool updateEmployeeInDb(EmployeeBL employee, int id_to_update)
        {
            string query = $"UPDATE employees SET salary = {employee.get_salary()}, contact = '{employee.get_contact()}', department = '{employee.get_department()}', branch_id = {employee.get_branch_id()} WHERE employee_id = {id_to_update}";
            return DatabaseHelper.Instance.Update(query) > 0;
        }

        public static bool deleteEmployee(int employee_id)
        {
            string query = $"DELETE FROM employees WHERE employee_id = {employee_id}";
            return DatabaseHelper.Instance.Update(query) > 0;
        }
        public static void LoadDataGrid(KryptonDataGridView dgvEmployee,string search)
        {
            string query = $@"
        SELECT 
            e.employee_id,
            e.first_name,
            e.last_name,
            e.position,
            e.department,
            e.branch_id,
            e.salary,
            u.username,
            u.email
        FROM Employees e
        INNER JOIN Users u ON e.user_id = u.user_id
        WHERE e.first_name like '%{search}%' OR e.last_name like '%{search}%';
    ";

            dgvEmployee.Rows.Clear();

            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    int employee_id = Convert.ToInt32(reader["employee_id"]);
                    string full_name = reader["first_name"] + " " + reader["last_name"];
                    string username = reader["username"].ToString();
                    string email = reader["email"].ToString();
                    string department = reader["department"].ToString();
                    int position = Convert.ToInt32(reader["position"]);
                    int branch_id = Convert.ToInt32(reader["branch_id"]);
                    float salary = float.Parse(reader["salary"].ToString());

                    dgvEmployee.Rows.Add(
                        employee_id,
                        full_name,
                        username,
                        email,
                        department,
                        UserDL.get_role(position),
                        BranchDL.GetBranchNameById(branch_id),
                        salary
                    );
                }
            }
        }



        public static bool isDublicateContact(string contact)
        {
            string query = $"SELECT * FROM employees WHERE contact = '{contact}'";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int get_employee_id(string contact)
        {
            string query = $"SELECT employee_id FROM employees WHERE contact = '{contact}'";
            int employee_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    employee_id = Convert.ToInt32(reader["employee_id"].ToString());
                }
            }
            return employee_id;
        }

        public static void LoadEmployeeCombobox(KryptonComboBox comboBox)
        {
            LoadAllEmployeeInList();
            comboBox.Items.Clear();
            comboBox.Items.Add("Select Employee");
            foreach (var employee in employees)
            {
                comboBox.Items.Add(employee.get_employee_id() + "  " + employee.get_employee_name());
            }
        }

        public static void ApplyFilter(string condition, KryptonDataGridView dataGrid)
        {
            string query = $@"
                SELECT 
                    e.employee_id,
                    CONCAT(e.first_name, ' ', e.last_name) AS employee_name,
                    u.username,
                    u.email,
                    e.department,
                    e.position,
                    e.branch_id,
                    e.salary
                FROM employees e
                JOIN users u ON e.user_id = u.user_id
                {condition};";

            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    dataGrid.Rows.Add(
                        Convert.ToInt32(reader["employee_id"]),
                        reader["employee_name"].ToString(),
                        reader["username"].ToString(),
                        reader["email"].ToString(),
                        reader["department"].ToString(),
                        UserDL.get_role(Convert.ToInt32(reader["position"])),
                        BranchDL.GetBranchNameById(Convert.ToInt32(reader["branch_id"])),
                        float.Parse(reader["salary"].ToString())
                    );
                }
            }
        }

        

        public static void LoadAllEmployeeInList()
        {
            employees.Clear();
            string query = "SELECT * FROM employees";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                employees.Clear();
                while (reader.Read())
                {
                    employees.Add(new EmployeeBL(
                    Convert.ToInt32(reader["employee_id"]),
                    reader["first_name"].ToString(),
                    reader["last_name"].ToString(),
                    reader["gender"].ToString(),
                    Convert.ToInt32(reader["position"]),
                    reader["department"].ToString(),
                    Convert.ToInt32(reader["branch_id"]),
                    Convert.ToSingle(reader["salary"]),
                    reader["contact"].ToString()
                ));
                }
            }
        }

        public static void LoadAllBranchEmployeeInList()
        {
            employees.Clear();
            string query = $"SELECT e.employee_id, e.first_name, e.last_name," +
                $" l.value AS position, e.department, e.email, e.gender, e.contact" +
                $" FROM employees e JOIN lookup l ON e.position = l.lookup_id" +
                $" WHERE e.branch_id = (SELECT branch_id FROM employees WHERE" +
                $" user_id = (SELECT user_id FROM users WHERE username = '{MainInterface.username}'))" +
                $" AND l.category = 'position'";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                employees.Clear();
                while (reader.Read())
                {
                    employees.Add(new EmployeeBL(
                    Convert.ToInt32(reader["employee_id"]),
                    reader["first_name"].ToString(),
                    reader["last_name"].ToString(),
                    reader["email"].ToString(),
                    reader["position"].ToString(),
                    reader["department"].ToString(),
                    reader["contact"].ToString(),
                    reader["gender"].ToString()
                ));
                }
            }
        }
        public static void LoadBranchEmployeeGrid(KryptonDataGridView BranchEmployees)
        {
            BranchEmployees.Rows.Clear();
            foreach (EmployeeBL employee in employees)
            {
                BranchEmployees.Rows.Add(
                    employee.get_employee_id(),
                    employee.get_first_name() + " " + employee.get_last_name(),
                    employee.get_position_name(),
                    employee.get_department(),
                    employee.get_email(),
                    employee.get_gender(),
                    employee.get_contact());
            }
        }

        public static void ApplyBranchFilters(string condition)
        {
            
            string query = $"SELECT e.employee_id, e.first_name, e.last_name," +
                $" l.value AS position, e.department, e.email, e.gender, e.contact" +
                $" FROM employees e JOIN lookup l ON e.position = l.lookup_id" +
                $" WHERE e.branch_id = (SELECT branch_id FROM employees WHERE" +
                $" user_id = (SELECT user_id FROM users WHERE username = '{MainInterface.username}'))" +
                $" AND l.category = 'position' {condition}";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                employees.Clear();
                while (reader.Read())
                {
                    employees.Add(new EmployeeBL(
                    Convert.ToInt32(reader["employee_id"]),
                    reader["first_name"].ToString(),
                    reader["last_name"].ToString(),
                    reader["email"].ToString(),
                    reader["position"].ToString(),
                    reader["department"].ToString(),
                    reader["contact"].ToString(),
                    reader["gender"].ToString()
                ));
                }
            }
        }

        public static void LoadDepartmentCombobox(KryptonComboBox comboBox)
        {
            
            comboBox.Items.Clear();
            GetDepartments();
            comboBox.Items.Add("Select Department");
            comboBox.SelectedIndex = 0;
            foreach (var department in departments)
            {
                if (department != null)
                {
                    comboBox.Items.Add(department);
                }
            }
        }

        public static void LoadBranchEmployeeCombobox(KryptonComboBox comboBox)
        {
            LoadAllEmployeeInList();
            
            comboBox.Items.Clear();
            comboBox.Items.Add("Select Employee");
            comboBox.SelectedIndex = 0;
            foreach (var employee in employees)
            {
                comboBox.Items.Add(employee.get_employee_name());
            }
        }

        public static void GetDepartments()
        {
            departments.Clear();
            string query = $"SELECT department FROM employees";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    departments.Add(reader["department"].ToString());
                }
            }
        }

        public static bool isDublicateEmail(string email)
        {
            string query = $"SELECT * FROM users WHERE email = '{email}'";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool isDublicateUsername(string username)
        {
            string query = $"SELECT * FROM users WHERE username = '{username}'";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int getUserIdByEmpId(int employee_id)
        {
            string query = $"SELECT user_id FROM employees WHERE employee_id = {employee_id}";
            int user_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    user_id = Convert.ToInt32(reader["user_id"].ToString());
                }
            }
            return user_id;
        }


        public static bool isDoublicateRole(int employee_type, int branch_id)
        {
            string query = $"SELECT COUNT(*) FROM employees WHERE position = {employee_type} AND branch_id = {branch_id}";

            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    int count = Convert.ToInt32(reader[0]);


                    if (employee_type == 2 && count >= 1)
                    {
                        // Only 1 manager allowed per branch
                        return false;
                    }

                    if (employee_type == 3 && count >= 8)
                    {
                        // Max 8 cashiers allowed per branch
                        return false;
                    }
                }
            }

            return true;
        }

        public static int get_position_by_id(int emp_id)
        {
            string query = $"SELECT position FROM employees WHERE employee_id = {emp_id}";
            int position = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    position = Convert.ToInt32(reader["position"].ToString());
                }
            }
            return position;

        }


        public static string TotalEmployees()
        {
            string query = "SELECT COUNT(*) FROM employees";
            int total = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    total = Convert.ToInt32(reader[0]);
                }
            }
            return total.ToString();
        }

        public static string TotalManagers()
        {
            string query = "SELECT COUNT(*) FROM employees WHERE position = 3";// manager ki id
            int total = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    total = Convert.ToInt32(reader[0]);
                }
            }
            return total.ToString();
        }

        public static string TotalCashiers()
        {
            string query = "SELECT COUNT(*) FROM employees WHERE position = 2";// cashier ki id
            int total = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    total = Convert.ToInt32(reader[0]);
                }
            }
            return total.ToString();

        }
    }
}
