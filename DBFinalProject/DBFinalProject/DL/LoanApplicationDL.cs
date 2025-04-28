using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class LoanApplicationDL
    {
        public static List<LoanApplicationBL> applications = new List<LoanApplicationBL>();

        public static void AddApplication(LoanApplicationBL application)
        {
            string query = $"INSERT INTO loan_application VALUES ('{application.getLoanApplicationId()}','{application.getAccountId()}', '{application.getAmountRequested()}','{application.getPurpose()}','{application.getEmploymentStatus()}','{application.getLoanStatus()}','{application.getApplyDate()}','{application.getApproveDate()}','{application.getReviewedBy()}','{application.getReviewedDate()}')";
            DatabaseHelper.Instance.Update(query);
        }

        public static void DeleteApplication(LoanApplicationBL application)
        {
            string query = $"DELETE FROM loan_application WHERE client_id = '{application.getClientId()}'";
            DatabaseHelper.Instance.Update(query);
        }
    }
}
