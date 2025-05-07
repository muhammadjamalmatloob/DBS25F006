using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class WithdrawalDL
    {
        public static List<WithdrawalBL> withdrawals = new List<WithdrawalBL>();

        public static void AddWithdrawal(WithdrawalBL withdrawalBL)
        {
            string query = $"INSERT INTO withdrawals VALUES ('{withdrawalBL.getwithdrawal_id()}','{withdrawalBL.getfrom_account_id()}', '{withdrawalBL.getAmount()}','{withdrawalBL.getTransactionId()}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void DeleteWithdrawal(WithdrawalBL withdrawalBL)
        {
            string query = $"DELETE FROM withdrawals WHERE withdrawal_id = '{withdrawalBL.getwithdrawal_id()}'";
            DatabaseHelper.Instance.Update(query);
        }
    }
}
