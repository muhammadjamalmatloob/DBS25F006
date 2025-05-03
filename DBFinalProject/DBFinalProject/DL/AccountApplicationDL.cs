using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class AccountApplicationDL
    {

        public static string TotalAccountApplications()
        {
            string query = "SELECT COUNT(*) from account_application";
            int total = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    total = Convert.ToInt32(reader[0]);
                }
            }
            return total.ToString();
        }
    }
}
