using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    internal class DepositsBL : TransactionBL
    {
        private int deposit_id { get; set; }

        private int to_account_id { get; set; }
        private decimal amount { get; set; }

        public DepositsBL() { }

        public void setDepositId(int deposit_id)
        {
            this.deposit_id = deposit_id;
        }

        public void setToAccountId(int to_account_id)
        {
            this.to_account_id = to_account_id;
        }
        public void setAmount(decimal amount)
        {
            this.amount = amount;
        }
        public int getDepositId()
        {
            return this.deposit_id;
        }
        public int getToAccountId()
        {
            return this.to_account_id;
        }
        public decimal getAmount()
        {
            return this.amount;
        }

        public override void setCharges(decimal amount)
        {
            if (amount >= 1 && amount <= 1000)
            {
                this.charges = 44;
            }
            else if (amount > 1000 && amount <= 2500)
            {
                this.charges = 88;
            }
            else if (amount > 2500 && amount <= 4000)
            {
                this.charges = 132;
            }
            else if (amount > 4000 && amount <= 6000)
            {
                this.charges = 176;
            }
            else if (amount > 6000 && amount <= 8000)
            {
                this.charges = 220;
            }
            else if (amount > 8000 && amount <= 10000)
            {
                this.charges = 264;
            }
            else if (amount > 10000)
            {
                this.charges = 300;
            }
            this.charges = charges;
        }
    }
}
