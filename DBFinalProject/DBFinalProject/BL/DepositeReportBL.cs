using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    public class DepositeReportBL
    {
        public string customer {  get; set; }
        public string account_number { get; set; }
        public string amount {  get; set; }
        public string currency { get; set; }

        public DepositeReportBL(string customer, string account_number, string amount, string currency)
        {
            this.customer = customer;
            this.account_number = account_number;
            this.amount = amount;
            this.currency = currency;
        }
    }
}
