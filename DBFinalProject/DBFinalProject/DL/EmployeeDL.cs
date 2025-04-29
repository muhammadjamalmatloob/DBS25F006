using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.BL;
using DBFinalProject.Utility;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DBFinalProject.DL
{
    internal class EmployeeDL
    {
        public static List<EmployeeBL> employees = new List<EmployeeBL>();

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
        //public static void DeleteEmployee(EmployeeBL employee)
        //{
        //    string query = $"DELETE FROM employees WHERE username = '{employee.getUsername()}'";
        //    DatabaseHelper.Instance.Update(query);
        //}
    }
}
