using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFinalProject.DL;

namespace DBFinalProject.BL
{
    internal class AccountBL
    {
        private int account_id { get; set; }
        private int client_id { get; set; }
        private int account_type_id { get; set; }
        private string account_number { get; set; }
        private decimal balance { get; set; }
        private string currency { get; set; }
        private int status { get; set; }
        private DateTime opening_date { get; set; }
        private int branch_id { get; set; }
        private string PIN { get; set; }
        public AccountBL() { }
        public void setAccountId(int account_id)
        {
            this.account_id = account_id;
        }
        public void setAccountType(int account_type_id)
        {
            this.account_type_id = account_type_id;
        }
        public void setAccountNumber(string account_number)
        {
            this.account_number = account_number;
        }
        public void setBalance(decimal balance)
        {
            this.balance = balance;
        }
        public void setBranchId(int branch_id)
        {
            this.branch_id = branch_id;
        }
        public int getAccountId()
        {
            return this.account_id;
        }
        public int getAccountType()
        {
            return this.account_type_id;
        }
        public string getAccountNumber()
        {
            return this.account_number;
        }
        public decimal getBalance()
        {
            return this.balance;
        }
        public int getBranchId()
        {
            return this.branch_id;
        } 

        public static bool isSufficientBalance(string account_number,decimal amount,decimal charges)
        {
            decimal balance = AccountDL.getBalanceByNumber(account_number);
            if (balance >= amount + charges)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
