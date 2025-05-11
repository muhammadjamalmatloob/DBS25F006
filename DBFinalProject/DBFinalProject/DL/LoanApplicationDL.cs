using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.Utility;
using Google.Protobuf.WellKnownTypes;

namespace DBFinalProject.DL
{
    internal class LoanApplicationDL
    {
        public static List<LoanApplicationBL> applications = new List<LoanApplicationBL>();

        public static void AddApplication(LoanApplicationBL application)
        {
            string query = $"INSERT INTO loan_application VALUES ({application.getLoanApplicationId()},{application.getClientId()},{application.getLoanTypeId()},{application.getAccountId()}, {application.getAmountRequested()},'{application.getPurpose()}',{application.getEmploymentStatus()},'{application.getLoanStatus()}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',null,null,null)";
            DatabaseHelper.Instance.Update(query);
        }

        public static void DeleteApplication(LoanApplicationBL application)
        {
            string query = $"DELETE FROM loan_application WHERE client_id = '{application.getClientId()}'";
            DatabaseHelper.Instance.Update(query);
        }


        public static void LoadAllBranchLoansInList()
        {
            applications.Clear();
            string query = $"SELECT la.loan_application_id, a.first_name, a.last_name, l.value as loan_status, " +
                $"lt.type_name, la.requested_amount, la.apply_date, la.purpose " +
                $"From loan_application la " +
                $"join lookup l On l.lookup_id = la.loan_status " +
                $"join clients c On c.client_id = la.client_id " +
                $"join account_application a ON c.application_id = a.application_id " +
                $"join loan_type lt On lt.loan_type_id = la.loan_type_id " +
                $"WHERE a.branch_id = (SELECT branch_id FROM account_application aa " +
                $"join clients cc ON cc.application_id = aa.application_id WHERE " +
                $"user_id = (SELECT user_id FROM users WHERE username = '{MainInterface.username}')) " +
                $"AND l.category = 'loan_status' " +
                $"AND l.value = 'Pending'";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                applications.Clear();
                while (reader.Read())
                {
                    
                    applications.Add(
                        new LoanApplicationBL(Convert.ToInt32(reader["loan_application_id"]),
                        Convert.ToDecimal(reader["requseted_amount"]),
                        reader["purpose"].ToString(),
                        reader["loan_status"].ToString(),
                        (DateTime)reader["apply_date"],
                        reader["first_name"].ToString() + "" + reader["last_name"].ToString(),
                        reader["type_name"].ToString()
                        ));
                }
            }
        }



        public static void LoadBranchLoansToGrid(KryptonDataGridView Grid, int condition, string match)
        {
            Grid.Rows.Clear();
            
            foreach (var application in applications)
            {
                if (application.getAmountRequested() > condition && Regex.IsMatch(application.GetClientName(), match))
                {
                Grid.Rows.Add(
                    application.getLoanApplicationId(),
                    application.GetClientName(),
                    application.GetLoanType(),
                    application.getAmountRequested(),
                    application.getApplyDate(),
                    application.getPurpose(),
                    "Approve",
                    "Reject"
                    );
                }
            }
            foreach (DataGridViewRow row in Grid.Rows)
            {
                row.Height = 50;
            }
        }

        public static string TotalLoanApplications()
        {
            string query = "SELECT COUNT(*) FROM loan_application";
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


        public static bool Accept(int rowidx, KryptonDataGridView grid)
        {
            string query = $"Update loan_application set loan_status = 'Approved'" +
                $" Where loan_application_id = '{grid.Rows[rowidx].Cells[0].Value}'";
            int row = DatabaseHelper.Instance.Update(query);
            return row > 0;
        }

        public static bool Reject(int rowidx, KryptonDataGridView grid)
        {
            string query = $"Update loan_application set loan_status = 'Rejected'" +
                $" Where loan_application_id = '{grid.Rows[rowidx].Cells[0].Value}'";
            int row = DatabaseHelper.Instance.Update(query);
            return row > 0;
        }

    }
}
