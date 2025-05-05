using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class AuditDL
    {
        public static void LoadDataGrid_branch(KryptonDataGridView dgv)
        {
            string query = "SELECT audit_details FROM branch_audit";
            dgv.Rows.Clear();
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    string details = reader.GetString(0);
                    dgv.Rows.Add(details);
                }
            }
                
        }
        public static void LoadDataGrid_employee(KryptonDataGridView dgv)
        {
            string query = "SELECT audit_details FROM employee_audit";
            dgv.Rows.Clear();
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    string details = reader.GetString(0);
                    dgv.Rows.Add(details);
                }
            }

        }
        public static void LoadDataGrid_client(KryptonDataGridView dgv)
        {
            string query = "SELECT audit_details FROM clint_audit";
            dgv.Rows.Clear();
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    string details = reader.GetString(0);
                    dgv.Rows.Add(details);
                }
            }

        }
        public static void LoadDataGrid_loan(KryptonDataGridView dgv)
        {
            string query = "SELECT audit_details FROM loan_type_audit";
            dgv.Rows.Clear();
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    string details = reader.GetString(0);
                    dgv.Rows.Add(details);
                }
            }

        }
        public static void LoadDataGrid_account(KryptonDataGridView dgv)
        {
            string query = "SELECT audit_details FROM account_audit";
            dgv.Rows.Clear();
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    string details = reader.GetString(0);
                    dgv.Rows.Add(details);
                }
            }

        }
        public static void LoadDataGrid_transaction(KryptonDataGridView dgv)
        {
            string query = "SELECT audit_details FROM transaction_audit";
            dgv.Rows.Clear();
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    string details = reader.GetString(0);
                    dgv.Rows.Add(details);
                }
            }

        }
        public static void LoadDataGrid_payment(KryptonDataGridView dgv)
        {
            string query = "SELECT audit_details FROM payment_audit";
            dgv.Rows.Clear();
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    string details = reader.GetString(0);
                    dgv.Rows.Add(details);
                }
            }

        }
        public static void LoadDataGrid_exchange(KryptonDataGridView dgv)
        {
            string query = "SELECT audit_details FROM currency_exchange_audit";
            dgv.Rows.Clear();
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                while (reader.Read())
                {
                    string details = reader.GetString(0);
                    dgv.Rows.Add(details);
                }
            }

        }
    }
}
