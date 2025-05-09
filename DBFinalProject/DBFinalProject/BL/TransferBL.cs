using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{

    internal class TransferBL : TransactionBL
    {
        private int transfer_id {  get; set; }
        private int from_account_id {  get; set; }
        private int to_account_id { get; set;}
        private decimal amount { get; set; }
        public TransferBL() { }
        public void setFromAccID(int accID)
        {
            from_account_id = accID;
        }
        public void setToAccID(int accID)
        {
            to_account_id = accID;
        }
        public void setAmount(decimal amount)
        {
            this.amount = amount;
        }
        public int getTransfer_id()
        {
            return transfer_id;
        }
        public int getFromAccountId()
        {
            return from_account_id;
        }
        public int getToAccounId()
        {
            return to_account_id;
        }
        public decimal getAmount()
        {
            return amount;
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
            else
            {
                this.charges = 220;
            }
        }
    }
}
