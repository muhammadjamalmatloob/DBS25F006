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
    internal class CurrencyExchangeDL
    {
        public static List<CurrencyExchangeBL> exchanges = new List<CurrencyExchangeBL>();

        //public static void AddExchange(CurrencyExchangeBL exchange)
        //{
        //    string query = $"INSERT INTO currency_exchange VALUES ('{exchange.getExchangeId()}','{exchange.getClientId()}', '{exchange.getBaseCurrency()}','{exchange.getTargetCurrency()}','{exchange.getExchangeRate()}','{exchange.getAmountBase()}','{exchange.getAmountTarget()}','{exchange.getDate()}')";
        //    DatabaseHelper.Instance.Update(query);
        //}

        //public static void DeleteExchange(CurrencyExchangeBL exchange)
        //{
        //    string query = $"DELETE FROM payments WHERE client_id = '{exchange.getClientId()}'";
        //    DatabaseHelper.Instance.Update(query);
        //}

        public static bool exchangeAmmount(CurrencyExchangeBL exchange)
        {
            string query = $@"
                    START TRANSACTION;
    
                    INSERT INTO transactions 
                        VALUES (
                            null,
                            {exchange.getClientId()},
                            {exchange.getTransactionType()},
                            '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',
                            {exchange.getCharges()}
                        );
    
                    INSERT INTO currency_exchange 
                        VALUES (
                            null,
                            '{exchange.getBaseCurrency()}',
                            '{exchange.getTargetCurrency()}',
                            {exchange.getExchangeRate()},
                            {exchange.getAmountBase()},
                            {exchange.getAmountTarget()},
                            LAST_INSERT_ID()
                        );
    
                    UPDATE accounts 
                        SET balance = balance - ({exchange.getAmountBase()} + {exchange.getCharges()})
                        WHERE account_id = {exchange.getClientId()};
    
                    COMMIT;
                ";
            return DatabaseHelper.Instance.Update(query) > 0;
        }


        public static void LoadAllBranchExchangesInList()
        {
            exchanges.Clear();
            string query = $"Select ce.exchange_id, ce.base_currency, ce.target_currency, " +
                $"ce.exchange_rate, ce.amount_base_currency, ce.amount_target_currency, " +
                $"a.first_name, a.last_name " +
                $"From currency_exchange ce " +
                $"Natural Join transactions " +
                $"Natural Join clients " +
                $"Natural Join account_application a " +
                $"WHERE a.branch_id = (SELECT branch_id FROM account_application aa " +
                $"join clients cc ON cc.application_id = aa.application_id WHERE " +
                $"user_id = (SELECT user_id FROM users WHERE username = '{MainInterface.username}')) ";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                
                while (reader.Read())
                {

                    exchanges.Add(
                        new CurrencyExchangeBL(
                        Convert.ToInt32(reader["exchange_id"]),
                        reader["base_amount"].ToString(),
                        reader["target_amount"].ToString(),
                        Convert.ToDecimal(reader["exchange_rate"]),
                        Convert.ToDecimal(reader["amount_base_currency"]),
                        Convert.ToDecimal(reader["amount_target_currency"]),
                        reader["first_name"].ToString() + " " + reader["last_name"].ToString()
                        ));
                }
            }
        }

        public static void LoadBranchExchangesToGrid(KryptonDataGridView Grid, int condition, string match)
        {
            Grid.Rows.Clear();
            int a1 = 100, a2 = 5000, a3 = 10033, a4 = 20000;
            int b1 = 100, b2 = 50, b3 = 100, b4 = 200;
            int c1 = 100000, c2 = 500000, c3 = 1300, c4 = 2000000;
            string n1 = "Jamal", n2 = "Umer", n3 = "Rumman", n4 = "Apex Bank";
            if (a1 > condition && Regex.IsMatch(n1, match))
            {
                Grid.Rows.Add(
                    1,
                    n1,
                    "Rupees",
                    "Dollar",
                    b1,
                    c1,
                    a1
                    );
            }
            if (a2 > condition && Regex.IsMatch(n2, match))
            {
                Grid.Rows.Add(
                2,
                n2,
                "Rupees",
                "Dollar",
                b2,
                c2,
                a2
                );
            }
            if (a3 > condition && Regex.IsMatch(n3, match))
            {
                Grid.Rows.Add(
                3,
                n3,
                "Rupees",
                "Dollar",
                b3,
                c3,
                a3
                
                );
            }
            if (a4 > condition && Regex.IsMatch(n4, match))
            {
                Grid.Rows.Add(
                4,
                n4,
                "Rupees",
                "Dollar",
                b4,
                c4,
                a4
                
                );
            }
            foreach (var exchange in exchanges)
            {
                if (exchange.getAmountTarget() > condition && Regex.IsMatch(exchange.getCustomerName(), match))
                {
                    Grid.Rows.Add(
                        exchange.getExchangeId(),
                        exchange.getCustomerName(),
                        exchange.getBaseCurrency(),
                        exchange.getTargetCurrency(),
                        exchange.getAmountBase(),
                        exchange.getAmountTarget()
                        );
                }
            }
            foreach (DataGridViewRow row in Grid.Rows)
            {
                row.Height = 50;
            }
        }

        public static bool exchangeAmmount(CurrencyExchangeBL exchange,int acc_id)
        {
            string query = $@"
                    START TRANSACTION;
    
                    INSERT INTO transactions 
                        VALUES (
                            null,
                            {exchange.getClientId()},
                            {exchange.getTransactionType()},
                            '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',
                            {exchange.getCharges()}
                        );
    
                    INSERT INTO currency_exchange 
                        VALUES (
                            null,
                            '{exchange.getBaseCurrency()}',
                            '{exchange.getTargetCurrency()}',
                            {exchange.getExchangeRate()},
                            {exchange.getAmountBase()},
                            {exchange.getAmountTarget()},
                            LAST_INSERT_ID()
                        );
    
                    UPDATE accounts 
                        SET balance = balance - ({exchange.getAmountBase()} + {exchange.getCharges()})
                        WHERE account_id = {acc_id};
    
                    COMMIT;
                ";
            return DatabaseHelper.Instance.Update(query) > 0;

        }
    }
}
