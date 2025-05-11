using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    internal class CurrencyExchangeBL : TransactionBL
    {
        private int exchange_id {  get; set; }
        private string base_currency {  get; set; }
        private string target_currency { get; set; }
        private decimal exchange_rate { get; set; }
        private decimal amount_base { get; set; }
        private decimal amount_target { get; set; }

        private string client_name { get; set; }


        public CurrencyExchangeBL() { }

        public CurrencyExchangeBL(int exchange_id, string base_currency, string target_currency,
            decimal exchange_rate, decimal amount_base, decimal amount_target, string client_name)
        {
            this.amount_base = amount_base;
            this.exchange_id = exchange_id;
            this.base_currency = base_currency;
            this.target_currency = target_currency;
            this.exchange_rate = exchange_rate;
            this.amount_base = amount_base;
            this.amount_target = amount_target;
            this.client_name = client_name;
        }
        

  
        public void setBaseCurrency(string base_currency)
        {
            this.base_currency = base_currency;
        }
        public void setTargetCurrency(string target_currency)
        {
            this.target_currency = target_currency;
        }
        public void setAmountBase(decimal amount_base)
        {
            this.amount_base = amount_base;
        }
        public void setAmountTarget(decimal amount_target)
        {
            this.amount_target = amount_target;
        }
     
        public int getExchangeId()
        {
            return this.exchange_id;
        }
        public string getBaseCurrency()
        {
            return this.base_currency;
        }
        public string getTargetCurrency()
        {
            return this.target_currency;
        }
        public decimal getExchangeRate()
        {
            return this.exchange_rate;
        }
        public decimal getAmountBase()
        {
            return this.amount_base;
        }
        public decimal getAmountTarget()
        {
            return this.amount_target;
        }

        public string getCustomerName()
        {
            return this.client_name;
        }

        public void setCustomerName(string name)
        {
            client_name = name;
        }

        public void setExchangeRate(string bcurrency,string tcurrency)
        {
            if (bcurrency == "Rupees" && tcurrency == "Dollars")
            {
                this.exchange_rate = 0.0036m;
            }
            else if (bcurrency == "Rupees" && tcurrency == "Pounds")
            {
                this.exchange_rate = 0.0027m;
            }
            else if (bcurrency == "Rupees" && tcurrency == "Euros")
            {
                this.exchange_rate = 0.0031m;
            }
        }

        public override void setCharges(decimal amount)
        {
            if (amount > 0)
            {
                this.charges = amount * 0.02m; 
            }
            else
            {
                this.charges = 0;
            }
        }
    }
}
