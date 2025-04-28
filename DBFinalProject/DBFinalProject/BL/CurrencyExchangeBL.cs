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

        public CurrencyExchangeBL() { }
        public void setBaseCurrency(string base_currency)
        {
            this.base_currency = base_currency;
        }
        public void setTargetCurrency(string target_currency)
        {
            this.target_currency = target_currency;
        }
        public void setExchangeRate(decimal exchange_rate)
        {
            this.exchange_rate = exchange_rate;
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
    }
}
