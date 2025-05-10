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
    internal class AccountTypeDL
    {
        public static List<AccountTypeBL> accountTypes = new List<AccountTypeBL>();

        public static bool AddAccountTypeInDb(AccountTypeBL accountType)
        {
            try
            {
                string query = $"INSERT INTO account_type (type_name, description, min_balance, transaction_limit, withdrawl_limit) VALUES ('{accountType.get_type_name()}', '{accountType.get_descryprtion()}', {accountType.get_min_balance()}, {accountType.get_transaction_limit()}, {accountType.get_withdrawl_limit()})";
                return DatabaseHelper.Instance.Update(query) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool DeleteAccountTypeInDb(int account_type_id)
        {
            try
            {
                string query = $"DELETE FROM account_type WHERE account_type_id = {account_type_id}";
                return DatabaseHelper.Instance.Update(query) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool UpdateAccountTypeInDb(AccountTypeBL accountType, int account_type_id)
        {
            try
            {
                string query = $"UPDATE account_type SET type_name = '{accountType.get_type_name()}', description = '{accountType.get_descryprtion()}', min_balance = {accountType.get_min_balance()}, transaction_limit = {accountType.get_transaction_limit()}, withdrawl_limit = {accountType.get_withdrawl_limit()} WHERE account_type_id = {account_type_id}";
                return DatabaseHelper.Instance.Update(query) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public static void LoadAllDataInList()
        {
            string query = "SELECT * FROM account_type";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                accountTypes.Clear();
                while (reader.Read())
                {
                    accountTypes.Add(new AccountTypeBL(
                        Convert.ToInt32(reader["account_type_id"]),
                        reader["type_name"].ToString(),
                        reader["description"].ToString(),
                        Convert.ToInt32(reader["min_balance"]),
                        Convert.ToInt32(reader["transaction_limit"]),
                        Convert.ToInt32(reader["withdrawl_limit"])
                    ));
                }
            }
        }

        public static int getIdByName(string name)
        {
            string query = $"SELECT account_type_id FROM account_type WHERE type_name = '{name}'";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["account_type_id"]);
                }
                else
                {
                    return 0;
                }
            }
        }



        public static void LoadDataGrid(List<AccountTypeBL> accountTypes,KryptonDataGridView dgvAccount)
        {
            dgvAccount.Rows.Clear();
            foreach (var accountType in accountTypes)
            {
                dgvAccount.Rows.Add(
                    accountType.get_account_type_id(),
                    accountType.get_type_name(),
                    accountType.get_descryprtion(),
                    accountType.get_min_balance(),
                    accountType.get_transaction_limit(),
                    accountType.get_withdrawl_limit()
                    );
            }
        }

        public static void LoadAccountTypeInComboBox(KryptonComboBox comboBox)
        {
            comboBox.Items.Clear();
            foreach (var accountType in accountTypes)
            {
                comboBox.Items.Add(accountType.get_type_name());
            }
        }

        public static string TotalActiveAccounts()
        {
            string query = "SELECT COUNT(*) from accounts where status = 23";
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

        public static string TotalInActiveAccounts()
        {
            string query = "SELECT COUNT(*) from accounts where status = 24";
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

        public static string TotalClosedAccounts()
        {
            string query = "SELECT COUNT(*) from accounts where status = 25";
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

        public static int getTransactionLimit(int account_type_id)
        {
            string query = $"SELECT transaction_limit FROM account_type WHERE account_type_id = {account_type_id}";
            int transactionLimit = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    transactionLimit = Convert.ToInt32(reader["transaction_limit"]);
                }
            }
            return transactionLimit;
        }

        public static int getWithdrawlLimit(int account_type_id)
        {
            string query = $"SELECT withdrawl_limit FROM account_type WHERE account_type_id = {account_type_id}";
            int withdrawlLimit = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    withdrawlLimit = Convert.ToInt32(reader["withdrawl_limit"]);
                }
            }
            return withdrawlLimit;
        }

        public static int getMinBalance(int account_type_id)
        {
            string query = $"SELECT min_balance FROM account_type WHERE account_type_id = {account_type_id}";
            int minBalance = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    minBalance = Convert.ToInt32(reader["min_balance"]);
                }
            }
            return minBalance;
        }
    }
}
