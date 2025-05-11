using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public static List<ApplicationProfile> profiles = new List<ApplicationProfile>();

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


        public static void LoadAllApplicationsInList()
        {
            profiles.Clear();
            string query = $"SELECT * from account_application a " +
                $"Join account_type at On at.account_type_id = a.account_type_id " +
                $"Join branches b ON b.branch_id = a.branch_id " +
                $"Where a.status = 'Pending'" +
                $" And a.branch_id = (SELECT branch_id From employees " +
                $"WHERE user_id = (SELECT user_id FROM users WHERE username = '{MainInterface.username}')) ";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {

                while (reader.Read())
                {

                    profiles.Add(new ApplicationProfile(
                        Convert.ToInt32(reader["application_id"]),
                        (byte[])reader["profile_pic"],
                        (byte[])reader["cnic_front"],
                        (byte[])reader["cnic_back"],
                        reader["first_name"].ToString(),
                        reader["last_name"].ToString(),
                        reader["gender"].ToString() == "Male" ? Gender.Male : Gender.Female,
                        reader["contact"].ToString(),
                        reader["email"].ToString(),
                        reader["country"].ToString(),
                        reader["address"].ToString(),
                        reader["cnic"].ToString(),
                        Convert.ToDateTime(reader["application_date"]),
                        reader["branch_name"].ToString(),
                        reader["type_name"].ToString()
                        ));
                }
            }
        }

        public static void LoadBranchTransactionsToGrid(KryptonDataGridView Grid)
        {
            Grid.Rows.Clear();
            
            
            foreach (var profile in profiles)
            {
                Grid.Rows.Add(
                      profile.GetID(),
                      profile.GetFirstName() + " " + profile.GetLastName(),
                      profile.GetEmail(),
                      profile.GetContact(),
                      profile.GetCountry(),
                      profile.GetCnic(),
                      profile.GetAddress()
                      );
                
            }
            foreach (DataGridViewRow row in Grid.Rows)
            {
                row.Height = 50;
            }
        }

        public static void GetDocuments(PictureBox CF,PictureBox CB, PictureBox Pro, int row)
        {
            try
            {
                
                if (profiles == null || row < 0 || row >= profiles.Count)
                {
                    MessageBox.Show("Invalid profile data or row index.");
                    return;
                }

                var profile = profiles[row];
                if (profile == null)
                {
                    MessageBox.Show("Profile not found.");
                    return;
                }

                
                byte[] cnicFront = profile.GetCnicFront();
                if (cnicFront != null && cnicFront.Length > 0)
                {
                    using (MemoryStream stream = new MemoryStream(cnicFront))
                    {
                        CF.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    CF.Image = null; 
                }

                
                byte[] profilePic = profile.GetProfilePic();
                if (profilePic != null && profilePic.Length > 0)
                {
                    using (MemoryStream stream = new MemoryStream(cnicFront))
                    {
                        Pro.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    Pro.Image = null;
                }

                
                byte[] cnicBack = profile.GetCnicBack();
                if (cnicBack != null && cnicBack.Length > 0)
                {
                    using (MemoryStream stream = new MemoryStream(cnicFront))
                    {
                        CB.Image = Image.FromStream(stream);
                    }
                }
                else
                {
                    CB.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading images: {ex.Message}");
            }
        }

        public static bool Accept(int row)
        {
            string query = "Update account_application set status = 'Rejected' " +
                $"Where application_id = {profiles[row].GetID()}";
            int rows = DatabaseHelper.Instance.Update(query);
            return rows > 0;
        }

        public static bool Reject(int row)
        {
            string query = "Update account_application set status = 'Rejected' " +
                $"Where application_id = {profiles[row].GetID()}";
            int rows = DatabaseHelper.Instance.Update(query);
            return rows > 0;
        }

        public static bool AddClient(int row)
        {
            string query = $"Insert into clients (application_id) values ({profiles[row].GetID()})";
            int rows = DatabaseHelper.Instance.Update(query);
            return rows > 0;
        }

        public static bool AddAccount(int row)
        {
            string query = $"Insert into accounts (client_id, account_type_id, balance, " +
                $"currency, opening_date, status, branch_id) values " +
                $"((Select client_id From clients Where application_id = {profiles[row].GetID()}), " +
                $"(Select account_type_id from account_type Where type_name = '{profiles[row].GetAccountType()}'), " +
                $"0,'Rupee',Now(),'Active', " +
                $"(Select branch_id From branches Where branch_name = '{profiles[row].GetBranch()}'))";
                int rows = DatabaseHelper.Instance.Update(query);
                return rows > 0;
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
