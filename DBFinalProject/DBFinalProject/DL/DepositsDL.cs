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
            string query = $@"
                    START TRANSACTION;
                    INSERT INTO transactions 
                        VALUES (
                            null,
                            {deposits.getClientId()},
                            {deposits.getTransactionType()},
                            '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}',
                            {deposits.getCharges()}
                        );
                    INSERT INTO deposits 
                        VALUES (
                            null,
                            {deposits.getToAccountId()},
                            {deposits.getAmount()},
                            LAST_INSERT_ID()
                        );
                    UPDATE accounts 
                        SET balance = balance + {deposits.getAmount()} - {deposits.getCharges()}
                        WHERE account_id = {deposits.getToAccountId()};
                    COMMIT;";
            return DatabaseHelper.Instance.Update(query) > 0;
        }

       
    }
}
