using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    public class TransferReportBL
    {
        public string customer { get; set; }
        public string from_account_number { get; set; }
        public string to_account_number { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }

        public TransferReportBL() { }
        public TransferReportBL(string customer, string from_account_number, string to_account_number, string amount, string currency)
        {
            this.customer = customer;
            this.from_account_number = from_account_number;
            this.to_account_number = to_account_number;
            this.amount = amount;
            this.currency = currency;
        }
    }
}
