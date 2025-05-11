using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    internal class TransactionRecordBL
    {
        private int transaction_id {  get; set; }
        private string transaction_type { get; set; }
        private decimal amount { get; set; }
        private decimal charges { get; set; }
        private DateTime date_recorded { get; set; }

        public TransactionRecordBL(int transaction_id,string transaction_type,decimal amount,decimal charges,DateTime date_recorded)
        {
            this.transaction_id = transaction_id;
            this.transaction_type = transaction_type;
            this.amount = amount;
            this.charges = charges;
            this.date_recorded = date_recorded;
        }
        public TransactionRecordBL() { }

        public void setTransactionId(int transaction_id)
        {
            this.transaction_id = transaction_id;
        }
        public int getTransactionId()
        {
            return this.transaction_id;
        }
        public void setTransactionType(string transaction_type)
        {
            this.transaction_type = transaction_type;
        }
        public string getTransactionType()
        {
            return transaction_type;
        }
        public void setAmount(decimal amount)
        {
            this.amount = amount;
        }
        public decimal getAmount()
        {
            return amount;
        }
        public void setCharges(decimal charges)
        {
            this.charges = charges;
        }
        public decimal getCharges()
        {
            return charges;
        }
        public void setDate(DateTime date_recorded)
        {
            this.date_recorded = date_recorded;
        }
        public DateTime getDate()
        {
            return date_recorded;
        }
    }
}
