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

        public static void AddIntoList()
        {
            employees_rep.Clear();
            employees_rep.Add(new EmployeesReport(
                "Jamal",
                "Male",
                "Manager",
                "100000",
                "03224122066")) ;
            employees_rep.Add(new EmployeesReport(
                "Rumman",
                "Male",
                "Cashier",
                "1000000",
                "03222222222"));
            employees_rep.Add(new EmployeesReport(
                "Umer",
                "Male",
                "Cashier",
                "5000000",
                "03222222333"));
            
            string query = $"SELECT e.first_name, e.last_name," +
                $" l.value AS position, e.gender, e.contact, e.salary" +
                $" FROM employees e JOIN lookup l ON e.position = l.lookup_id" +
                $" WHERE e.branch_id = (SELECT branch_id FROM employees WHERE" +
                $" user_id = (SELECT user_id FROM users WHERE username = 'manager'))" +
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
    }
}
