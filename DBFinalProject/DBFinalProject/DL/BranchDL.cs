using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class BranchDL
    {
        public static List<BranchBL> branchList = new List<BranchBL>();

        public static void AddBranch(BranchBL branch)
        {
            branchList.Add(branch);
        }

        public static void RemoveBranch(BranchBL branch)
        {
            branchList.Remove(branch);
        }
        public static bool AddBranchInDb(BranchBL branch)
        {
            string query = $"INSERT INTO branches (branch_name, branch_code, address, contact, city, country) VALUES ('{branch.get_branch_name()}', {branch.get_branch_code()}, '{branch.get_address()}', '{branch.get_contact()}', '{branch.get_city()}', '{branch.get_country()}')";
            return DatabaseHelper.Instance.Update(query) > 0;
        }

        public static int GetBranchIdByCode(int branch_code)
        {
            string query = $"SELECT branch_id FROM branches WHERE branch_code = {branch_code}";
            return DatabaseHelper.Instance.Update(query);
        }

        public static void LoadAllDataInList()
        {
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

        public static void LoadAllBranchesInComboBox(KryptonComboBox comboBox)
        {
            comboBox.Items.Clear();
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
    }
}
