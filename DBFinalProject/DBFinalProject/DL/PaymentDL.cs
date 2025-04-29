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
            string query = $"INSERT INTO payments VALUES ('{payment.getPaymentId()}','{payment.getDate()}', '{payment.getAmount()}','{payment.getMethod()}','{payment.getStatus()}','{payment.getPaymentType()}','{payment.getTransactionId()}','{payment.getCurrency()}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void DeletePayment(PaymentBL payment)
        {
            string query = $"DELETE FROM payments WHERE client_id = '{payment.getClientId()}'";
            DatabaseHelper.Instance.Update(query);
        }
    }
}
