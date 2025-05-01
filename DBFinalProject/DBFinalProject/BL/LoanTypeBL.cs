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
        public LoanTypeBL(int id,string type_name, string descryptions, string loan_terms, int interest_rate, string repayment_frequency, string eligibility)
        {
            this.loan_type_id = id;
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
            if (type_name.Length < 5)
            {
                throw new Exception("Loan Type Name must be atleast 5 characters long");
            }
            else if (type_name.Length > 15)
            {
                throw new Exception("Loan Type Name must be atmost 15 characters long");
            }
            else if (type_name == "Type Name"  || type_name == "")
            {
                throw new Exception("Please Enter Loan Type name");
            }
            this.type_name = type_name;
        }
        public string get_descryptions()
        {
            return this.descryptions;
        }
        public void set_descryptions(string descryptions)
        {
            if (descryptions.Length < 5)
            {
                throw new Exception("Descryption must be atleast 5 characters long");
            }
            else if (descryptions.Length > 100)
            {
                throw new Exception("Descryption must be atmost 100 characters long");
            }
            else if (descryptions == "Descryption" || descryptions == "")
            {
                throw new Exception("Please Enter Descryption");
            }
            this.descryptions = descryptions;
        }
        public string get_loan_terms()
        {
            
            return this.loan_terms;
        }
        public void set_loan_terms(string loan_terms)
        {
            if (loan_terms.Length < 5)
            {
                throw new Exception("Loan Terms must be atleast 5 characters long");
            }
            else if (loan_terms.Length > 100)
            {
                throw new Exception("Loan Terms must be atmost 100 characters long");
            }
            else if (loan_terms == "Loan Terms" || loan_terms == "")
            {
                throw new Exception("Please Enter Loan Terms ");
            }
            this.loan_terms = loan_terms;
        }
        public int get_interest_rate()
        {
            return this.interest_rate;
        }
        public void set_interest_rate(int interest_rate)
        {
            if (interest_rate < 0)
            {
                throw new Exception("Interest Rate can not be negative");
            }
            else if (interest_rate > 10000)
            {
                throw new Exception("Interest Rate can not be more than 10000");
            }
            this.interest_rate = interest_rate;
        }
        public string get_repayment_frequency()
        {
            return this.repayment_frequency;
        }
        public void set_repayment_frequency(string repayment_frequency)
        {
            if (loan_terms.Length < 5)
            {
                throw new Exception("Repayment Frequency must be atleast 5 characters long");
            }
            else if (repayment_frequency.Length > 100)
            {
                throw new Exception("Repayment Frequency must be atmost 100 characters long");
            }
            else if (repayment_frequency == "Repayment Frequency" || repayment_frequency == "")
            {
                throw new Exception("Please Enter Repayment Frequency ");
            }
            this.repayment_frequency = repayment_frequency;
        }
        public string get_eligibility()
        {
            

            return this.eligibility;
        }
        public void set_eligibility(string eligibility)
        {
            if (eligibility.Length < 5)
            {
                throw new Exception("Eligibility must be atleast 5 characters long");
            }
            else if (eligibility.Length > 100)
            {
                throw new Exception("Eligibility must be atmost 100 characters long");
            }
            else if (eligibility == "Eligibility" || eligibility == "")
            {
                throw new Exception("Please Enter Eligibility ");
            }
            this.eligibility = eligibility;
        }
        
    }
}
