using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    internal class WithdrawalBL : TransactionBL
    {
        private int withdrawal_id {  get; set; }
        private int from_account_id { get; set; }
        private decimal amount { get; set; }

        public WithdrawalBL() { }

        public void setFromAccID(int accID)
        {
            from_account_id = accID;
        }
        public void setAmount(decimal amount)
        {
            this.amount = amount;
        }
        public int getwithdrawal_id()
        {
            return withdrawal_id;
        }
        public int getfrom_account_id()
        {
            return from_account_id;
        }
        public decimal getAmount()
        {
            return amount;
        }
        public override void setCharges(decimal amount)
        {
            if (amount > 0)
            {
                this.charges = amount * 0.02m; // 2% charges
            }
            else
            {
                this.charges = 0;
            }
        }
    }
}
