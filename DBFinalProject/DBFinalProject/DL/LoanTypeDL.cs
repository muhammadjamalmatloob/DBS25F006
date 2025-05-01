using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class LoanTypeDL
    {
        public static List<LoanTypeBL> loanTypeList = new List<LoanTypeBL>();

        public static bool addLoanType(LoanTypeBL loanType)
        {
            try
            {
                string query = $"INSERT INTO loan_type (type_name,description,loan_terms,interest_rate,repayment_frequency,eligibilty) VALUES ('{loanType.get_type_name()}','{loanType.get_descryptions()}','{loanType.get_loan_terms()}',{loanType.get_interest_rate()},'{loanType.get_repayment_frequency()}','{loanType.get_eligibility()}')";
                int result = DatabaseHelper.Instance.Update(query);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool UpdateLoanTypeInDb(int loan_type_id, LoanTypeBL loanType)
        {
            string query = $"UPDATE loan_type SET type_name = '{loanType.get_type_name()}', description = '{loanType.get_descryptions()}', loan_terms = '{loanType.get_loan_terms()}', interest_rate = {loanType.get_interest_rate()}, repayment_frequency = '{loanType.get_repayment_frequency()}', eligibilty = '{loanType.get_eligibility()}' WHERE loan_type_id = {loan_type_id}";
            return DatabaseHelper.Instance.Update(query) > 0;
        }

        public static string getNameByID(int type_id)
        {
            string query = $"SELECT type_name FROM loan_type WHERE loan_type_id = {type_id}";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            else
            {
                return "";
            }
        }

        public static bool DeleteLoanTypeInDb(int loan_type_id)
        {
            string query = $"DELETE FROM loan_type WHERE loan_type_id = {loan_type_id}";
            return DatabaseHelper.Instance.Update(query) > 0;
        }

        public static string getRepaymentFrequencyByID(int type_id)
        {
            string query = $"SELECT repayment_frequency FROM loan_type WHERE loan_type_id = {type_id}";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                return reader.GetString(0);
            }
            else
            {
                return null;
            }
        }

        public static int getIdByName(string type_name)
        {
            string query = $"SELECT loan_type_id FROM loan_type WHERE type_name = '{type_name}'";
            var reader = DatabaseHelper.Instance.getData(query);
            if (reader.Read())
            {
                return reader.GetInt32(0);
            }
            else
            {
                return 0;
            }

        }

        public static void LoadLoanTypeInComboBox(KryptonComboBox comboBox)
        {
            comboBox.Items.Clear();
            
            foreach (var loanType in loanTypeList)
            {
                comboBox.Items.Add(loanType.get_type_name());
            }
        }

        public static void LoadDataGrid(List<LoanTypeBL> loanTypes, KryptonDataGridView dgvLoan)
        {
            dgvLoan.Rows.Clear();
            foreach (var loanType in loanTypes)
            {
                dgvLoan.Rows.Add(
                    loanType.get_loan_type_id(),
                    loanType.get_type_name(),
                    loanType.get_descryptions(),
                    loanType.get_loan_terms(),
                    loanType.get_interest_rate(),
                    loanType.get_repayment_frequency(),
                    loanType.get_eligibility()
                );
            }
        }

       
        public static void LoadAllLoanTypes()
        {
            string query = "SELECT * FROM loan_type";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                loanTypeList.Clear();
                while (reader.Read())
                {
                    loanTypeList.Add(new LoanTypeBL

                        (
                        Convert.ToInt32(reader["loan_type_id"]),
                        reader["type_name"].ToString(),
                        reader["description"].ToString(),
                        reader["loan_terms"].ToString(),
                        Convert.ToInt32(reader["interest_rate"]),
                        (reader["repayment_frequency"]).ToString(),
                        reader["eligibilty"].ToString()
                    ));
                }
            }
        }
    }
}
