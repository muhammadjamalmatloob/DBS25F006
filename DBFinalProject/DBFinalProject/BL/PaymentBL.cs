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
        private string method { get; set; }
        private int status { get; set; }
        private int payment_type { get; set; }
        private string currency { get; set; }

        public PaymentBL() { }

        public void setMethod(string method)
        {
            this.method = method;
        }
        public void setStatus(int status)
        {
            this.status = status;
        }
        public void setType(int payment_type)
        {
            this.payment_type = payment_type;
        }
        public void setCurrency(string currency)
        {
            this.currency = currency;
        }
        public int getPaymentId()
        {
            return this.payment_id;
        }
        public string getMethod()
        {
            return this.method;
        }
        public int getStatus()
        {
            return this.status;
        }
        public int getPaymentType()
        {
            return this.payment_type;
        }
        public string getCurrency()
        {
            return this.currency;
        }
    }
}
