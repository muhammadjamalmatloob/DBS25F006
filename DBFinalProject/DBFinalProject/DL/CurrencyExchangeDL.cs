using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string query = $"Start Transaction" +
                $"Insert into transactions VALUES (null,{exchange.getClientId()},{exchange.getTransactionType()},'{exchange.getDate()}',{exchange.getCharges()})" +
                $"Insert into currency_exchange VALUES (null,{exchange.getBaseCurrency()},{exchange.getTargetCurrency()},{exchange.getExchangeRate()},{exchange.getAmountBase()},{exchange.getAmountTarget()},{TransactionDL.getTransactionIdByDate(exchange.getDate(), exchange.getClientId())})" +
                $"UPDATE accounts SET balance = balance - {exchange.getAmountBase()}  - {exchange.getCharges()}  WHERE account_id = {exchange.getClientId()}" +
            $"Commit";
            return DatabaseHelper.Instance.Update(query) > 0;
        }
    }
}
