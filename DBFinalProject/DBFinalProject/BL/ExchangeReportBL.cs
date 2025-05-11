using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    public class ExchangeReportBL
    {
        public string customer { get; set; }
        public string account_number { get; set; }
        public string base_amount { get; set; }
        public string target_amount { get; set; }
        public string base_currency { get; set; }
        public string target_currency { get; set; }

        public ExchangeReportBL() { }
        public ExchangeReportBL(string customer, string account_number, string base_amount, string target_amount, string base_currency, string target_currency)
        {
            this.customer = customer;
            this.account_number = account_number;
            this.base_amount = base_amount;
            this.target_amount = target_amount;
            this.base_currency = base_currency;
            this.target_currency = target_currency;
        }
    }
}
