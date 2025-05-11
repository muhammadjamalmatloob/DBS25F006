using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace DBFinalProject.BL
{
    public class TransactionBL
    {
        protected int transaction_id { get; set; }
        protected int client_id { get; set; }
        protected int transaction_type { get; set; }
        protected DateTime date_recorded { get; set; }
        protected decimal charges { get; set; }
        private string from_account_number { get; set; }
        private string to_account_number { get; set; }
        private string customer_name { get; set; }
        private string type { get; set; }
        private string amount { get; set; }

        public TransactionBL() { }

        public TransactionBL(int transaction_id, DateTime date_recorded, string from_account_number, string to_account_number, string customer_name, string type, string amount)
        {
            this.transaction_id = transaction_id;
            this.date_recorded = date_recorded;
            this.from_account_number = from_account_number;
            this.to_account_number = to_account_number;
            this.customer_name = customer_name;
            this.type = type;
            this.amount = amount;
        }

        public void setTransactionId(int transaction_id)
        {
            this.transaction_id = transaction_id;
        }
     
        public void setClientId(int clientId)
        {
            this.client_id = clientId;
        }
        public void setTransactionType(int transaction_type)
        {
            this.transaction_type = transaction_type;
        }
        public void setDate(DateTime date_recorded)
        {
            this.date_recorded = date_recorded;
        }
        public virtual void setCharges(decimal amount)
        {
            
        }
        public void setAmount(string amount)
        {
            this.amount = amount;
        }
        public void setType(string type)
        {
            this.type = type;
        }
        public void setFromAccountNumber(string account)
        {
            from_account_number = account;
        }
        public void setToAccountNumber(string account)
        {
            to_account_number = account;
        }
        public void setCustomer(string customer)
        {
            this.customer_name = customer;
        }
        public int getTransactionId()
        {
            return this.transaction_id;
        }
        public int getClientId()
        {
            return this.client_id;
        }
        public int getTransactionType()
        {
            return this.transaction_type;
        }
        public DateTime getDate()
        {
            return this.date_recorded;
        }
        public decimal getCharges()
        {
            return this.charges;
        }
        public string getType()
        {
            return this.type;
        }
        public string getFromAccountNumber()
        {
            return this.from_account_number;
        }

        public string getToAccountNumber()
        {
            return this.to_account_number;
        }

        public string getCustomerName()
        {
            return this.customer_name;
        }

        public string getAmount()
        {
            return this.amount;
        }

    }
}

