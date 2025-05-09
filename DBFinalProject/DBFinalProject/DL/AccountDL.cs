using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.Utility;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DBFinalProject.DL
{
    internal class AccountDL
    {
        public static int getAccountIdByNumber(string account_number)
        {
            string query = $"SELECT account_id FROM accounts WHERE account_number = '{account_number}'";
            return DatabaseHelper.Instance.Update(query);
        }
        public static int getCleintIdByNumber(string account_number)
        {
            string query = $"SELECT client_id FROM accounts WHERE account_number = '{account_number}'";
            return DatabaseHelper.Instance.Update(query);
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
                    count = Convert.ToInt32(reader["COUNT"].ToString());
                }
            }
            return count > 0;
        }

        public static bool isAccount(string account_number)
        {
            string query = $"SELECT COUNT(*) AS COUNT FROM accounts WHERE account_number = '{account_number}' AND branch_id = {branch_id}";
            int count = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    count = Convert.ToInt32(reader["COUNT"].ToString());
                }
            }
            return count > 0;
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

        

        }
}
