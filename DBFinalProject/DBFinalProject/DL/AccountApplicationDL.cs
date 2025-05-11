using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
using CountryData.Standard;
using DBFinalProject.BL;
using DBFinalProject.Utility;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace DBFinalProject.DL
{
    public class AccountApplicationDL
    {
        public static List<string> account_types = new List<string>();
        public static List<string> branches = new List<string>();

        public static void GetAccountTypes()
        {
            account_types.Clear();
            string query = $"Select type_name From account_type";
            var reader = DatabaseHelper.Instance.getData(query);
            while (reader.Read())
            {
                account_types.Add(reader["type_name"].ToString());
            }
        }

        public static void GetBranches()
        {
            branches.Clear();
            string query = $"Select branch_name From branches";
            var reader = DatabaseHelper.Instance.getData(query);
            while (reader.Read())
            {
                branches.Add(reader["branch_name"].ToString());
            }
        }

        public static void LoadBranchesComboBox(KryptonComboBox branch)
        {
            branch.Items.Clear();
            branch.Items.Add("-- Select Branch --");
            foreach (string s in branches)
            {
                branch.Items.Add(s);
            }

            branch.SelectedIndex = 0;



        }
        public static void LoadAccountTypeComboBox(KryptonComboBox account)
        {
            account.Items.Clear();
            account.Items.Add("-- Select Account Type --");
            
            foreach (string s in account_types)
            {
                account.Items.Add(s);
            }
            account.SelectedIndex = 0;
        }

        public static int Apply()
        {
            string query = $"INSERT INTO account_application (account_type_id, branch_id, profile_pic, cnic_front, cnic_back, " +
                $"first_name, last_name, gender, contact, email,country, address, cnic, status) VALUES " +
                $"((Select account_type_id from account_type Where type_name = '{ApplicationForm.application.GetAccountType()}'), " +
                $"(Select branch_id from branches Where branch_name = '{ApplicationForm.application.GetBranch()}'), " +
                $"'{ApplicationForm.application.GetProfilePic()}', " +
                $"'{ApplicationForm.application.GetCnicFront()}', " +
                $"'{ApplicationForm.application.GetCnicBack()}'," +
                $"'{ApplicationForm.application.GetFirstName()}', " +
                $"'{ApplicationForm.application.GetLastName()}', " +
                $"'{ApplicationForm.application.GetGender()}', " +
                $"'{ApplicationForm.application.GetContact()}', " +
                $"'{ApplicationForm.application.GetEmail()}', " +
                $"'{ApplicationForm.application.GetCountry()}', " +
                $"'{ApplicationForm.application.GetAddress()}', " +
                $"' {ApplicationForm.application.GetCnic()} ', " +
                $" '{ApplicationStatus.Pending}' ) ";
            int rows = DatabaseHelper.Instance.Update(query);
            return rows;
        }


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
        public static string TotalAccountApplications(int branch_id)
        {
            string query = $"SELECT COUNT(*) from account_application  WHERE branch_id = {branch_id}";
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
