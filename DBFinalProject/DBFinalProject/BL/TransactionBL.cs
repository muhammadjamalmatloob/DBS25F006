using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace DBFinalProject.BL
{
    public   class TransactionBL
    {
        protected int transaction_id { get; set; }
        protected int client_id { get; set; }
        protected int transaction_type { get; set; }
        protected DateTime date_recorded { get; set; }
        protected decimal charges { get; set; }

        public TransactionBL() { }

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

