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
        private DateTime approve_date { get; set; }
        private int reviewed_by { get; set; }
        private DateTime review_date { get; set; }

        public LoanApplicationBL(){ }

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
        public void setApproveDate(DateTime approve_date)
        {
            this.approve_date = approve_date;
        }
        public void setReviewedBy(int reviewed_by)
        {
            this.reviewed_by = reviewed_by;
        }
        public void setReviewDate(DateTime reviewed_date)
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
        public DateTime getApproveDate()
        {
            return this.approve_date;
        }
        public int getReviewedBy()
        {
            return this.reviewed_by;
        }
        public DateTime getReviewedDate()
        {
            return this.review_date;
        }
    }
}
