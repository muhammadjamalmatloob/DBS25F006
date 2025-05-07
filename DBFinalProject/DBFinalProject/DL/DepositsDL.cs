using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class DepositsDL
    {
        public static bool depositAmmount(DepositsBL deposits)
        {
            string query = $"Start Transaction" +
                $"Insert into transactions VALUES (null,{deposits.getClientId()},{deposits.getTransactionType()},'{deposits.getDate()}',{deposits.getCharges()})" +
                $"Insert into deposits VALUES (null,{deposits.getToAccountId()},{deposits.getAmount()},{TransactionDL.getTransactionIdByDate(deposits.getDate(), deposits.getClientId())})" +
                $"UPDATE accounts SET balance = balance + {deposits.getAmount()} - {deposits.getCharges()} WHERE account_id = {deposits.getToAccountId()}" + 
            $"Commit";
            return DatabaseHelper.Instance.Update(query) > 0;
        }

       
    }
}
