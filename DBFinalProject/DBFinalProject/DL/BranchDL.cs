using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class BranchDL
    {
        public static List<BranchBL> branchList = new List<BranchBL>();





        public static bool AddBranchInDb(BranchBL branch)
        {
            string query = $"INSERT INTO branches (branch_name, branch_code, address, contact, city, country) VALUES ('{branch.get_branch_name()}', 0, '{branch.get_address()}', '{branch.get_contact()}', '{branch.get_city()}', '{branch.get_country()}')";
            return DatabaseHelper.Instance.Update(query) > 0;
        }

        public static int getCodeById(int branch_id)
        {
            string query = $"SELECT branch_code FROM branches WHERE branch_id = {branch_id}";
            int branch_code = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    branch_code = Convert.ToInt32(reader["branch_code"].ToString());
                }
            }
            return branch_code;
        }


        public static int GetBranchIdByCode(int branch_code)
        {
            string query = $"SELECT branch_id FROM branches WHERE branch_code = {branch_code}";
            return DatabaseHelper.Instance.Update(query);
        }

        public static void LoadAllDataInList()
        {
            branchList.Clear();
            string query = "SELECT * FROM branches";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                branchList.Clear();
                while (reader.Read())
                {
                    branchList.Add(new BranchBL(
                        Convert.ToInt32(reader["branch_id"]),
                        reader["branch_name"].ToString(),
                        Convert.ToInt32(reader["branch_code"]),
                        reader["address"].ToString(),
                        reader["contact"].ToString(),
                        reader["city"].ToString(),
                        reader["country"].ToString()
                    ));
                }
            }
        }

        public static bool DeleteBranchInDb(int branch_id)
        {
            string query = $"DELETE FROM branches WHERE branch_id = {branch_id}";
            int rowsAffected = DatabaseHelper.Instance.Update(query);
            return rowsAffected > 0;

        }

        public static bool UpdateBranchInDb(BranchBL branch)
        {
            string query = $"UPDATE branches SET  address = '{branch.get_address()}', contact = '{branch.get_contact()}', city = '{branch.get_city()}', country = '{branch.get_country()}' WHERE branch_id = {branch.get_branch_id()}";
            int rowsAffected = DatabaseHelper.Instance.Update(query);
            return rowsAffected > 0;
        }

        public static void LoadAllBranchesInComboBox(KryptonComboBox comboBox)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add("Select Branch");
            foreach (var branch in branchList)
            {
                comboBox.Items.Add(branch.get_branch_name());
            }
        }

        public static int GetBranchIdByName(string branch_name)
        {
            string query = $"SELECT branch_id FROM branches WHERE branch_name = '{branch_name}'";
            int branch_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    branch_id = Convert.ToInt32(reader["branch_id"].ToString());
                }
            }
            return branch_id;

        }

        public static string GetBranchNameById(int branch_id)
        {
            string query = $"SELECT branch_name FROM branches WHERE branch_id = {branch_id}";
            string branch_name = "";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    branch_name = reader["branch_name"].ToString();
                }
            }
            return branch_name;
        }
        public static BranchBL GetBranchById(int branch_id)
        {
            string query = $"SELECT * FROM branches WHERE branch_id = {branch_id}";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    return new BranchBL(
                        Convert.ToInt32(reader["branch_id"]),
                        reader["branch_name"].ToString(),
                        Convert.ToInt32(reader["branch_code"]),
                        reader["address"].ToString(),
                        reader["contact"].ToString(),
                        reader["city"].ToString(),
                        reader["country"].ToString()
                    );
                }
            }
            return null;
        }

        public static void LoadDataGrid(List<BranchBL> branchList, KryptonDataGridView dvgBranch)
        {
            //foreach (DataGridViewRow row in dvgBranch.Rows)
            //{
            //    row.Height = 50;
            //}
            foreach (var branch in branchList)
            {
                dvgBranch.Rows.Add(
                    branch.get_branch_id(),
                    branch.get_branch_name(),
                    branch.get_branch_code(),
                    branch.get_address(),
                    branch.get_contact(),
                    branch.get_city(),
                    branch.get_country()
                );
            }
        }

        public static bool isDublicateBranch(string name)
        {
            string query = $"SELECT * FROM branches WHERE branch_name = '{name}'";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool isDublicateContact(string contact)
        {
            string query = $"SELECT * FROM branches WHERE contact = '{contact}'";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    

        public static BranchBL GetManagerBranch()
        {
            string query = $"SELECT * FROM " +
                $"users u JOIN employees e " +
                $"ON u.user_id = e.user_id " +
                $"JOIN  branches b ON e.branch_id = b.branch_id " +
                $"WHERE u.username = '{MainInterface.username}'";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    return new BranchBL(
                        Convert.ToInt32(reader["branch_id"]),
                        reader["branch_name"].ToString(),
                        Convert.ToInt32(reader["branch_code"]),
                        reader["address"].ToString(),
                        reader["contact"].ToString(),
                        reader["city"].ToString(),
                        reader["country"].ToString()
                    );
                }
            }
            return null;
        }
    }
}
