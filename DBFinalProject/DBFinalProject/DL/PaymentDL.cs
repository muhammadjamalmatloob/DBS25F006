using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class PaymentDL
    {
        public static List<PaymentBL> payments = new List<PaymentBL>();

        public static void AddPayment(PaymentBL payment)
        {
            string query = $"INSERT INTO payments VALUES ('{payment.getPaymentId()}','{payment.getDate()}', '{payment.getAmount()}','{payment.getStatus()}','{payment.getPaymentType()}','{payment.getTransactionId()}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void DeletePayment(PaymentBL payment)
        {
            string query = $"DELETE FROM payments WHERE client_id = '{payment.getClientId()}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static string TotalPayments()
        {
            string query = "SELECT COUNT(*) FROM payments";
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

        public static bool payAmmount(PaymentBL payment)
        {
            string query = $"Start Transaction" +
                $"Insert into transactions VALUES (null,{payment.getClientId()},{payment.getTransactionType()},'{payment.getDate()}',{payment.getCharges()})" +
                $"Insert into deposits VALUES (null,{payment.getAccountId()},{payment.getAmount()},{TransactionDL.getTransactionIdByDate(payment.getDate(), payment.getClientId())})" +
                $"UPDATE accounts SET balance = balance - {payment.getAmount()}  - {payment.getCharges()}  WHERE account_id = {payment.getAccountId()}" +
            $"Commit";
            return DatabaseHelper.Instance.Update(query) > 0;
        }
    }
}
