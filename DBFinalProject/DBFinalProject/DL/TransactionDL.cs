using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class TransactionDL
    {
        public static List<TransactionBL> transactions = new List<TransactionBL>();

        public static void AddTransaction(TransactionBL transaction)
        {
            string query = $"INSERT INTO transactions VALUES ('{transaction.getTransactionId()}','{transaction.getClientId()}', '{transaction.getTransactionType()}','{transaction.getDate()}','{transaction.getCharges()}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void DeleteTransaction(TransactionBL transaction)
        {
            string query = $"DELETE FROM transactions WHERE client_id = '{transaction.getClientId()}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static int GetTransactionTypeIDFromLookup(string type)
        {
            string query = $"SELECT lookup_id FROM lookup WHERE category = 'transaction_type' AND value = '{type}'";
            int type_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    type_id = Convert.ToInt32(reader["lookup_id"].ToString());
                }
            }
            return type_id;
        }

        public static string TotalTransactions()
        {
            string query = "SELECT COUNT(*) FROM transactions";
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

        public static int getTransactionIdByDate(DateTime date,int client_id)
        {
            string query = $"SELECT transaction_id FROM transactions WHERE date_recorded = '{date}'  and client_id = {client_id}";
            int transaction_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    transaction_id = Convert.ToInt32(reader["transaction_id"].ToString());
                }
            }
            return transaction_id;
        }

        public static void LoadAllBranchTransactionsInList()
        {
            transactions.Clear();
            string query = $"Select t.transaction_id,  ac.account_number as from_account, " +
                $"CASE WHEN t.to_account_id IS NULL THEN 'Null' ELSE ac1.account_number END AS to_account, " +
                $"t.amount, l.value as type, t.date_recorded, " +
                $"a.first_name, a.last_name " +
                $"From  transactions t " +
                $"Join clients c On c.client_id = t.client_id " +
                $"Join account_application a On a.application_id = c.application_id " +
                $"join accounts ac On ac.client_id = c.client_id " +
                $"join accounts ac1 on t.from_account_id = ac1.account_id " +
                $"join lookup l On l.lookup_id = t.transaction_type " +
                $"WHERE a.branch_id = (SELECT branch_id FROM account_application aa " +
                $"join clients cc ON cc.application_id = aa.application_id WHERE " +
                $"user_id = (SELECT user_id FROM users WHERE username = '{MainInterface.username}')) ";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {

                while (reader.Read())
                {

                    transactions.Add(
                        new TransactionBL(
                        Convert.ToInt32(reader["transaction_id"]),
                        Convert.ToDateTime(reader["date_recorded"]),
                        reader["from_account"].ToString(),
                        reader["to_account"].ToString(),
                        reader["first_name"].ToString() + " " + reader["last_name"].ToString(),
                        reader["type"].ToString(),
                        reader["amount"].ToString()
                        ));
                }
            }
        }

        public static void LoadBranchTransactionsToGrid(KryptonDataGridView Grid, int condition, string match)
        {
            Grid.Rows.Clear();
            int a1 = 10000, a2 = 500000, a3 = 10033, a4 = 20000;
            string n1 = "Jamal", n2 = "Umer", n3 = "Rumman", n4 = "Apex Bank";
            if (a1 > condition && Regex.IsMatch(n1, match))
            {
                Grid.Rows.Add(
                    1,
                    n1,
                    "Widraw",
                    "1234567890",
                    "Null",
                    a1,
                    DateTime.Now
                    );
            }
            if (a2 > condition && Regex.IsMatch(n2, match))
            {
                Grid.Rows.Add(
                2,
                n2,
                "Transfer",
                "1234567890",
                "0123456789",
                a2,
                DateTime.Now
                );
            }
            if (a3 > condition && Regex.IsMatch(n3, match))
            {
                Grid.Rows.Add(
                3,
                n3,
                "Deposite",
                "1239267890",
                "Null",
                a3,
                DateTime.Now
                );
            }
            if (a4 > condition && Regex.IsMatch(n4, match))
            {
                Grid.Rows.Add(
                4,
                n4,
                "Widraw",
                "1234567890",
                "Null",
                a4,
                DateTime.Now
                );
            }
            foreach (var transaction in transactions)
            {
                if (Convert.ToDecimal(transaction.getAmount()) > condition && Regex.IsMatch(transaction.getCustomerName(), match))
                {
                    Grid.Rows.Add(
                        transaction.getTransactionId(),
                        transaction.getCustomerName(),
                        transaction.getType(),
                        transaction.getFromAccountNumber(),
                        transaction.getToAccountNumber(),
                        transaction.getAmount(),
                        transaction.getDate()
                        );
                }
            }
            foreach (DataGridViewRow row in Grid.Rows)
            {
                row.Height = 50;
            }
        }
    }
}
