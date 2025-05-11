using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    internal class ClientLoanApplicationBL
    {
        private int loan_application_id {  get; set; }
        private string loan_type { get; set; }
        private string acc_num { get; set; }
        private decimal amount { get; set; }
        private string loan_status { get; set; }
        private DateTime apply_date { get; set; }
        private DateTime approve_date { get; set; }

        public ClientLoanApplicationBL(int loan_application_id, string loan_type, string acc_num, decimal amount, string loan_status, DateTime apply_date, DateTime approve_date)
        {
            this.loan_application_id = loan_application_id;
            this.loan_type = loan_type;
            this.acc_num = acc_num;
            this.amount = amount;
            this.loan_status = loan_status;
            this.apply_date = apply_date;
            this.approve_date = approve_date;
        }
        public void setApplicationId(int loan_application_id)
        {
            this.loan_application_id=loan_application_id;
        }
        public int getApplicationId()
        {
            return loan_application_id;
        }
        public void setLoanType(string loan_type)
        {
            this.loan_type = loan_type;
        }
        public string getLoanType()
        {
            return loan_type;
        }
        public void setAccNum(string acc_num)
        {
            this.acc_num = acc_num;
        }
        public string getAccNum()
        {
            return acc_num;
        }
        public void setAmount(decimal amount)
        {
            this.amount = amount;
        }
        public decimal getAmount()
        {
            return amount;
        }
        public void setLoanStatus(string loan_status)
        {
            this.loan_status = loan_status;
        }
        public string getStatus()
        {
            return loan_status;
        }
        public void setApplyDate(DateTime apply_date)
        {
            this.apply_date = apply_date;
        }
        public DateTime getApplyDate()
        {
            return apply_date;
        }
        public void setApproveDate(DateTime approve_date)
        {
            this.approve_date = approve_date;
        }
        public DateTime getApproveDate()
        {
            return approve_date;
        }
    }

}
