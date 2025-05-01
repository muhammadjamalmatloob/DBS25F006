using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    internal class AccountTypeBL
    {

        private int account_type_id;
        private string type_name;
        private string descryprtion;
        private int min_balance;
        private int transaction_limit;
        private int withdrawl_limit;
        

        public AccountTypeBL(int account_type_id, string type_name, string descryprtion, int min_balance, int transaction_limit, int withdrawl_limit)
        {
            this.account_type_id = account_type_id;
            this.type_name = type_name;
            this.descryprtion = descryprtion;
            this.min_balance = min_balance;
            this.transaction_limit = transaction_limit;
            this.withdrawl_limit = withdrawl_limit;
        }

        public AccountTypeBL()
        {

        }

        public int get_account_type_id()
        {
            return account_type_id;
        }
        public string get_type_name()
        {
            return type_name;
        }
        public string get_descryprtion()
        {
            return descryprtion;
        }
        public int get_min_balance()
        {
            return min_balance;
        }
        public int get_transaction_limit()
        {
            return transaction_limit;
        }
        public int get_withdrawl_limit()
        {
            return withdrawl_limit;
        }
        public void set_account_type_id(int account_type_id)
        {
            this.account_type_id = account_type_id;
        }
        public void set_type_name(string type_name)
        {
            this.type_name = type_name;
        }
        public void set_descryprtion(string descryprtion)
        {
            this.descryprtion = descryprtion;
        }
        public void set_min_balance(int min_balance)
        {
            this.min_balance = min_balance;
        }
        public void set_transaction_limit(int transaction_limit)
        {
            this.transaction_limit = transaction_limit;
        }
        public void set_withdrawl_limit(int withdrawl_limit)
        {
            this.withdrawl_limit = withdrawl_limit;
        }
    }
}
