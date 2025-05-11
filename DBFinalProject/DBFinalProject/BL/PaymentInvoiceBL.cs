using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    public class PaymentInvoiceBL
    {
        public string customer { get; set; }
        public string currency { get; set; }
        public string type { get; set; }
        public decimal amount { get; set; }

        public PaymentInvoiceBL() 
        { }
        public PaymentInvoiceBL(string customer, string currency, string type, decimal amount)
        {
            this.customer = customer;
            this.currency = currency;
            this.type = type;
            this.amount = amount;
        }
    }
}
