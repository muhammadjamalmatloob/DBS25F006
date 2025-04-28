using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class TransactionDL
    {
        public static List<TransactionBL> transactions = new List<TransactionBL>();

        public static void AddTransaction(TransactionBL transaction)
        {
            string query = $"INSERT INTO transactions VALUES ('{transaction.getTransactionId()}','{transaction.getClientId()}', '{transaction.getFromAccount()}','{transaction.getToAccount()}','{transaction.getTransactionType()}','{transaction.getAmount()}','{transaction.getDate()}','{transaction.getdescription()}','{transaction.getCharges()}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void DeleteTransaction(TransactionBL transaction)
        {
            string query = $"DELETE FROM transactions WHERE client_id = '{transaction.getClientId()}'";
            DatabaseHelper.Instance.Update(query);
        }
    }
}
