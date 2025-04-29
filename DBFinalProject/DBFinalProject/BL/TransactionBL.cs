using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace DBFinalProject.BL
{
    internal class TransactionBL
    {
        protected int transaction_id { get; set; }
        protected int client_id { get; set; }
        protected int from_account_id { get; set; }
        protected int to_account_id { get; set; }
        protected int transaction_type { get; set; }
        protected decimal amount { get; set; }
        protected Timestamp date_recorded { get; set; }
        protected string description { get; set; }
        protected decimal charges { get; set; }

        public TransactionBL() { }

        public void setClientId(int clientId)
        {
            this.client_id = clientId;
        }
        public void setFromAccountID(int from_account_id)
        {
            this.from_account_id = from_account_id;
        }
        public void setToAccountID(int to_account_id)
        {
            this.to_account_id = to_account_id;
        }
        public void setTransactionType(int transaction_type)
        {
            this.transaction_type = transaction_type;
        }
        public void setAmount(decimal amount)
        {
            this.amount = amount;
        }
        public void setDate(Timestamp date_recorded)
        {
            this.date_recorded = date_recorded;
        }
        public void setDescription(string description)
        {
            this.description = description;
        }
        public void setCharges(decimal charges)
        {
            this.charges = charges;
        }
        public int getTransactionId()
        {
            return this.transaction_id;
        }
        public int getClientId()
        {
            return this.client_id;
        }
        public int getFromAccount()
        {
            return this.from_account_id;
        }
        public int getToAccount()
        {
            return this.to_account_id;
        }
        public int getTransactionType()
        {
            return this.transaction_type;
        }
        public decimal getAmount()
        {
            return this.amount;
        }
        public Timestamp getDate()
        {
            return this.date_recorded;
        }
        public string getdescription()
        {
            return this.description;
        }
        public decimal getCharges()
        {
            return this.charges;
        }


    }
}

