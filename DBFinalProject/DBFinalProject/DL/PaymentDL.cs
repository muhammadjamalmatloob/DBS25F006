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

        public static void LoadAllBranchPaymentInList()
        {
            payments.Clear();
            string query = $"Select p.payment_id, p.amount, p.currency, l.value as type," +
                $"a.first_name, a.last_name " +
                $"From payments p " +
                $"Natural Join transactions " +
                $"Natural Join clients " +
                $"Natural Join account_application a " +
                $"Join lookup l On lookup_id = payment_type " +
                $"WHERE a.branch_id = (SELECT branch_id FROM account_application aa " +
                $"join clients cc ON cc.application_id = aa.application_id WHERE " +
                $"user_id = (SELECT user_id FROM users WHERE username = '{MainInterface.username}')) ";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {

                while (reader.Read())
                {

                    payments.Add(
                        new PaymentBL(
                        Convert.ToInt32(reader["payment_id"]),
                        Convert.ToDecimal(reader["amount"]),
                        reader["currency"].ToString(),
                        reader["type"].ToString(),
                        reader["first_name"].ToString() + " " + reader["lastst_name"].ToString()
                        ));
                }
            }
        }

        public static void LoadBranchPaymentsToGrid(KryptonDataGridView Grid, int condition, string match)
        {
            Grid.Rows.Clear();
            int a1 = 1000, a2 = 5000, a3 = 10033, a4 = 20000;
            
            string n1 = "Jamal", n2 = "Umer", n3 = "Rumman", n4 = "Apex Bank";
            if (a1 > condition && Regex.IsMatch(n1, match))
            {
                Grid.Rows.Add(
                    1,
                    n1,
                    "Rupees",
                    "Electricity Bill",
                    a1
                    );
            }
            if (a2 > condition && Regex.IsMatch(n2, match))
            {
                Grid.Rows.Add(
                2,
                n2,
                
                "Dollar",
                "Gas Bill",
                a2
                );
            }
            if (a3 > condition && Regex.IsMatch(n3, match))
            {
                Grid.Rows.Add(
                3,
                n3,
                "Rupees",
                "Water Bill",
                a3

                );
            }
            if (a4 > condition && Regex.IsMatch(n4, match))
            {
                Grid.Rows.Add(
                4,
                n4,
                "Rupees",
                "Uet Fee",
                a4

                );
            }
            foreach (var payment in payments)
            {
                if (payment.getAmount() > condition && Regex.IsMatch(payment.getCustomer(), match))
                {
                    Grid.Rows.Add(
                        payment.getPaymentId(),
                        payment.getCustomer(),
                        payment.getCurrency(),
                        payment.getType(),
                        payment.getAmount()
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
