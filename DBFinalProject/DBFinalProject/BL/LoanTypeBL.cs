using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    internal class LoanTypeBL
    {
        private int loan_type_id;
        private string type_name;
        private string descryptions;
        private string loan_terms;
        private int interest_rate;
        private string repayment_frequency;
        private string eligibility;
        public LoanTypeBL(string type_name, string descryptions, string loan_terms, int interest_rate, string repayment_frequency, string eligibility)
        {
            this.type_name = type_name;
            this.descryptions = descryptions;
            this.loan_terms = loan_terms;
            this.interest_rate = interest_rate;
            this.repayment_frequency = repayment_frequency;
            this.eligibility = eligibility;
        }
        public LoanTypeBL()
        {
        }

        public int get_loan_type_id()
        {
            return this.loan_type_id;
        }

        public void set_loan_type_id(int loan_type_id)
        {
            this.loan_type_id = loan_type_id;
        }

        public string get_type_name()
        {
            return this.type_name;
        }
        public void set_type_name(string type_name)
        {
            this.type_name = type_name;
        }
        public string get_descryptions()
        {
            return this.descryptions;
        }
        public void set_descryptions(string descryptions)
        {
            this.descryptions = descryptions;
        }
        public string get_loan_terms()
        {
            return this.loan_terms;
        }
        public void set_loan_terms(string loan_terms)
        {
            this.loan_terms = loan_terms;
        }
        public int get_interest_rate()
        {
            return this.interest_rate;
        }
        public void set_interest_rate(int interest_rate)
        {
            this.interest_rate = interest_rate;
        }
        public string get_repayment_frequency()
        {
            return this.repayment_frequency;
        }
        public void set_repayment_frequency(string repayment_frequency)
        {
            this.repayment_frequency = repayment_frequency;
        }
        public string get_eligibility()
        {
            return this.eligibility;
        }
        public void set_eligibility(string eligibility)
        {
            this.eligibility = eligibility;
        }
        
    }
}
