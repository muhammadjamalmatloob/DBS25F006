using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace DBFinalProject.BL
{
    internal class LoanApplicationBL
    {
        private int loan_application_id {  get; set; }
        private int client_id { get; set; }
        private int loan_type_id { get; set; }
        private int account_id  { get; set; }
        private decimal requested_amount { get; set; }
        private string purpose {  get; set; }
        private int employment_status { get; set; }
        private int loan_status { get; set; }
        private DateTime apply_date { get; set; }
        private Timestamp approve_date { get; set; }
        private int reviewed_by { get; set; }
        private Timestamp review_date { get; set; }
        private string client_name { get; set; }
        private string loan_type { get; set; } 
        private string status { get; set; }
        

        public LoanApplicationBL(){ }

        public LoanApplicationBL(int loan_application_id, decimal requested_amount, string purpose, string status, DateTime apply_date, string client_name, string loan_type)
        {
            this.loan_application_id = loan_application_id;
            this.requested_amount = requested_amount;
            this.purpose = purpose;
            this.status = status;
            this.apply_date = apply_date;
            this.client_name = client_name;
            this.loan_type = loan_type;
        }

        public void setClientName(string client_name)
        {
            this.client_name = client_name;
        }

        public string GetClientName()
        {
            return client_name;
        }

        public void setStatus(string status)
        {
            this.status = status;
        }

        public string GetStatus()
        {
            return status;
        }


        public string GetLoanType()
        {
            return loan_type;
        }
        public void setLoanType(string loan_type)
        {
            this.loan_type = loan_type;
        }


        public void setClientId(int client_id)
        {
            this.client_id = client_id;
        }
        public void setLoanTypeId(int loan_type_id)
        {
            this.loan_type_id = loan_type_id;
        }
        public void setAccountId(int account_id)
        {
            this.account_id = account_id;
        }
        public void SetRequestAmount(decimal requested_amount)
        {
            this.requested_amount = requested_amount;
        }
        public void setPurpose(string purpose)
        {
            this.purpose = purpose;
        }
        public void setEmployementStatus(int employment_status)
        {
            this.employment_status = employment_status;
        }
        public void setLoanStatus(int loan_status)
        {
            this.loan_status = loan_status;
        }
        public void setApplyDate(DateTime apply_date)
        {
            this.apply_date = apply_date;
        }
        public void setApproveDate(Timestamp approve_date)
        {
            this.approve_date = approve_date;
        }
        public void setReviewedBy(int reviewed_by)
        {
            this.reviewed_by = reviewed_by;
        }
        public void setReviewDate(Timestamp reviewed_date)
        {
            this.review_date = reviewed_date;
        }
        public int getLoanApplicationId()
        {
            return this.loan_application_id;
        }
        public int getClientId()
        {
            return this.client_id;
        }
        public int getLoanTypeId()
        {
            return this.loan_type_id;
        }
        public int getAccountId()
        {
            return this.account_id;
        }
        public decimal getAmountRequested()
        {
            return this.requested_amount;
        }
        public string getPurpose()
        {
            return this.purpose;
        }
        public int getEmploymentStatus()
        {
            return this.employment_status;
        }
        public int getLoanStatus()
        {
            return this.loan_status;
        }
        public DateTime getApplyDate()
        {
            return this.apply_date;
        }
        public Timestamp getApproveDate()
        {
            return this.approve_date;
        }
        public int getReviewedBy()
        {
            return this.reviewed_by;
        }
        public Timestamp getReviewedDate()
        {
            return this.review_date;
        }
    }
}
