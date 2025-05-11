using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class ClientLoanApplicationDL
    {
        public static List<ClientLoanApplicationBL> applications = new List<ClientLoanApplicationBL>();
        public static void getApplications(int client_id)
        {
            applications.Clear();
            string query = $"SELECT la.loan_application_id,l.type_name as loan_type,a.account_number,la.requested_amount,l1.value AS loan_status,la.apply_date,la.approve_date FROM loan_application la JOIN accounts a ON la.account_id = a.account_id JOIN loan_type l ON la.loan_type_id = l.loan_type_id JOIN lookup l1 ON la.loan_status = l1.lookup_id WHERE la.client_id = {client_id}";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    applications.Add(new ClientLoanApplicationBL(
                    Convert.ToInt32(reader["loan_application_id"]),
                    reader["loan_type"].ToString(),
                    reader["account_number"].ToString(),
                    Convert.ToDecimal(reader["requested_amount"]),
                    reader["loan_status"].ToString(),
                    Convert.ToDateTime(reader["apply_date"]),
                    reader["approve_date"] == DBNull.Value
                        ? DateTime.MinValue
                        : Convert.ToDateTime(reader["approve_date"])
                    ));
                }
            }
        }

        public static void LoadDataGrid(List<ClientLoanApplicationBL> applications, KryptonDataGridView dgv)
        {

            dgv.Rows.Clear();
            foreach (var app in applications)
            {
                dgv.Rows.Add(
                    app.getApplicationId(),
                    app.getLoanType(),
                    app.getAccNum(),
                    app.getAmount(),
                    app.getStatus(),
                    app.getApplyDate(),
                    app.getApproveDate()
                );
            }
        }
    }
}
