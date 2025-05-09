using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public static bool withdrawlAmmount(WithdrawalBL withdrawal)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string query = $@"
        START TRANSACTION;
        
        INSERT INTO transactions 
            VALUES (
                null,
                {withdrawal.getClientId()},
                {withdrawal.getTransactionType()},
                '{date}',
                {withdrawal.getCharges()}
            );
        
        INSERT INTO withdrawals 
            VALUES (
                null,
                {withdrawal.getfrom_account_id()},
                {withdrawal.getAmount()},
                LAST_INSERT_ID()
            );
        
        UPDATE accounts 
            SET balance = balance - ({withdrawal.getAmount()} + {withdrawal.getCharges()})
            WHERE account_id = {withdrawal.getfrom_account_id()};
        
        COMMIT;
    ";

            return DatabaseHelper.Instance.Update(query) > 0;
        }
    }
}
