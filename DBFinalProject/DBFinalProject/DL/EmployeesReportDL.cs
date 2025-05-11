using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class EmployeesReportDL
    {
        public static List<EmployeesReport> employees_rep = new List<EmployeesReport>() ;
        public static List<AllEmployeeRepBL> all_employees = new List<AllEmployeeRepBL>() ;
        public static void AddIntoList()
        {
            employees_rep.Clear();
            
            string query = $"SELECT e.first_name, e.last_name," +
                $" l.value AS position, e.gender, e.contact, e.salary" +
                $" FROM employees e JOIN lookup l ON e.position = l.lookup_id" +
                $" WHERE e.branch_id = (SELECT branch_id FROM employees WHERE" +
                $" user_id = (SELECT user_id FROM users WHERE username = '{MainInterface.username}'))" +
                $" AND l.category = 'position'";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                
                while (reader.Read())
                {
                    employees_rep.Add(
                        new EmployeesReport(
                        reader["first_name"].ToString() + " " +
                        reader["last_name"].ToString(),
                        reader["gender"].ToString(),
                        reader["position"].ToString(),
                        reader["salary"].ToString(),
                        reader["contact"].ToString()
                        ));
                }
            }

        }

        public static void AddAllIntoList()
        {
            all_employees.Clear();
            

            string query = $"SELECT e.first_name, e.last_name," +
                $" l.value AS position, e.gender, e.contact, e.salary, b.branch_name" +
                $" FROM employees e JOIN lookup l ON e.position = l.lookup_id " +
                $" Join branches b On e.branch_id = b.branch_id" +
                $" WHERE" +
                $" l.category = 'position'";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {

                while (reader.Read())
                {
                    all_employees.Add(
                        new AllEmployeeRepBL(
                        reader["first_name"].ToString() + " " +
                        reader["last_name"].ToString(),
                        reader["gender"].ToString(),
                        reader["position"].ToString(),
                        reader["salary"].ToString(),
                        reader["contact"].ToString(),
                        reader["branch_name"].ToString()
                        ));
                }
            }

        }
    }
}
