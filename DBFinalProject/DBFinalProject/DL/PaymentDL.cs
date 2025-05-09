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
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string query = $@"
    START TRANSACTION;
    
    INSERT INTO transactions 
        VALUES (
            null,
            {payment.getClientId()},
            {payment.getTransactionType()},
            '{date}',
            {payment.getCharges()}
        );
    
    INSERT INTO payments 
        VALUES (
            null,
            {payment.getAmount()},
            {payment.getStatus()},
            {payment.getPaymentType()},
            LAST_INSERT_ID()
        );
    
    UPDATE accounts 
        SET balance = balance - ({payment.getAmount()} - {payment.getCharges()})
        WHERE account_id = {payment.getAccountId()};
    
    COMMIT;
";
            return DatabaseHelper.Instance.Update(query) > 0;
        }

        public static int getPaymentTypeId(string payment_type)
        {
            string query = $"SELECT lookup_id FROM lookup WHERE value = '{payment_type}'";
            int payment_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    payment_id = Convert.ToInt32(reader[0]);
                }
            }
            return payment_id;
        }
    }
}
