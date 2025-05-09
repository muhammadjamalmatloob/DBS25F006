using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DBFinalProject.BL;
using DBFinalProject.Utility;


namespace DBFinalProject.DL
{
    internal class TransferDL
    {

        public static List<TransferBL> transfers = new List<TransferBL>();

        public static void AddTransfer(TransferBL transfer)
        {
            string query = $"INSERT INTO transfers VALUES ('{transfer.getTransfer_id()}','{transfer.getFromAccountId()}', '{transfer.getToAccounId()}','{transfer.getAmount()}','{transfer.getTransactionId()}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void DeleteTransfer(TransferBL transfer)
        {
            string query = $"DELETE FROM transfers WHERE transfer_id = '{transfer.getTransfer_id()}'";
            DatabaseHelper.Instance.Update(query);
        }

        public static void transferAmmount(TransferBL transfer)
        {
            string query = $@"
            START TRANSACTION;
    
            INSERT INTO transactions 
                VALUES (
                    null,
                    {transfer.getClientId()},
                    {transfer.getTransactionType()},
                    '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',
                    {transfer.getCharges()}
                );
    
            INSERT INTO transfers 
                VALUES (
                    null,
                    {transfer.getFromAccountId()},
                    {transfer.getToAccounId()},
                    LAST_INSERT_ID(),
                    {transfer.getClientId()}
                );
    
            UPDATE accounts 
                SET balance = balance + {transfer.getAmount()}
                WHERE account_id = {transfer.getToAccounId()};
    
            UPDATE accounts 
                SET balance = balance - ({transfer.getAmount()} + {transfer.getCharges()})
                WHERE account_id = {transfer.getFromAccountId()};
    
            COMMIT;
        ";
            DatabaseHelper.Instance.Update(query);
        }
    }
}
