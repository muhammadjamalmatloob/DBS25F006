using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    internal class PaymentBL : TransactionBL
    {
        private int payment_id {  get; set; }

        private int account_id { get; set; }
        private int status { get; set; }
        private decimal amount { get; set; }
        private int payment_type { get; set; }

        public PaymentBL() { }

        public void setAccountId(int account_id)
        {
            this.account_id = account_id;
        }
        public int getAccountId()
        {
            return this.account_id;
        }
        public void setStatus(int status)
        {
            this.status = status;
        }
        public void setType(int payment_type)
        {
            this.payment_type = payment_type;
        }
        public void setAmount(decimal amount)
        {
            this.amount = amount;
        }
        public decimal getAmount()
        {
            return this.amount;
        }
        public int getPaymentId()
        {
            return this.payment_id;
        }
        public int getStatus()
        {
            return this.status;
        }
        public int getPaymentType()
        {
            return this.payment_type;
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
