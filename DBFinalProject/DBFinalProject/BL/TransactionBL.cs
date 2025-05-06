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
        protected int transaction_type { get; set; }
        protected DateTime date_recorded { get; set; }
        protected decimal charges { get; set; }

        public TransactionBL() { }

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
        public void setCharges(decimal amount)
        {
            if(amount >= 1 && amount <= 1000)
            {
                this.charges = 44;
            }
            else if(amount > 1000 && amount<= 2500)
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
            else if(amount > 10000)
            {
                this.charges = 300;
            }
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


    }
}

