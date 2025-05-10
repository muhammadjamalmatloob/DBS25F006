using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFinalProject.Utility;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DBFinalProject.DL
{
    internal class AccountDL
    {
        public static int getAccountIdByNumber(string account_number)
        {
            string query = $"SELECT account_id FROM accounts WHERE account_number = '{account_number}'";
            int id = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["account_id"].ToString());
                }
            }
            return id;
        }
        public static int getCleintIdByNumber(string account_number)
        {
            string query = $"SELECT client_id FROM accounts WHERE account_number = '{account_number}'";
            int id = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["client_id"].ToString());
                }
            }
            return id;
        }
        public static decimal getBalanceByNumber(string account_number)
        {
            string query = $"SELECT balance FROM accounts WHERE account_number = '{account_number}'";
            decimal balance = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    balance = Convert.ToDecimal(reader["balance"].ToString());
                }
            }
            return balance;
        }

        public static bool isAccount(string account_number, int branch_id)
        {
            string query = $"SELECT COUNT(*) AS COUNT FROM accounts WHERE account_number = '{account_number}' AND branch_id = {branch_id}";
            int count = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    count = Convert.ToInt32(reader[0]);
                }
            }
            return (count > 0);
        }

        public static bool isAccount(string account_number)
        {
            string query = $"SELECT COUNT(*) AS COUNT FROM accounts WHERE account_number = '{account_number}'";
            int count = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    count = Convert.ToInt32(reader["COUNT"].ToString());
                }
            }
            return (count > 0);
        }
        public static string getPinByNumber(string account_number)
        {
            string query = $"SELECT PIN FROM accounts WHERE account_number = '{account_number}'";
            string pin = "";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    pin = reader["PIN"].ToString();
                }
            }
            return pin;
        }
        public static string TotalAccount()
        {
            string query = $"SELECT COUNT(*) AS COUNT FROM accounts";
            string count = "";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    count = reader["COUNT"].ToString();
                }
            }
            return count;
        }

        public static string TotalAccountForSpecificClient(int client_id)
        {
            string query = $"SELECT COUNT(*) FROM accounts WHERE client_id = {client_id}";
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
        public static string TotalSavingAccount()
        {
            string query = $"SELECT COUNT(*) AS COUNT FROM accounts a " +
                $"Natural join account_type " +
                $"Where type_name like 'Saving%'";
            string count = "";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    count = reader["COUNT"].ToString();
                }
            }
            return count;
        }
        public static string TotalCurrentAccount()
        {
            string query = $"SELECT COUNT(*) AS COUNT FROM accounts a " +
                $"Natural join account_type " +
                $"Where type_name like 'Current%'";
            string count = "";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    count = reader["COUNT"].ToString();
                }
            }
            return count;
        }
        public static int getBalanceById(int account_id)
        {
            string query = $"SELECT balance FROM accounts WHERE account_id = {account_id}";
            int balance = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    balance = Convert.ToInt32(reader["balance"].ToString());
                }
            }
            return balance;
        }
    }
}
