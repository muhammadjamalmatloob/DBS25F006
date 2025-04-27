using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static bool AddBranchInDb(BranchBL branch)
        {
            string query = $"INSERT INTO branches (branch_name, branch_code, address, contact, city, country) VALUES ('{branch.get_branch_name()}', {branch.get_branch_code()}, '{branch.get_address()}', '{branch.get_contact()}', '{branch.get_city()}', '{branch.get_country()}')";
            return DatabaseHelper.Instance.Update(query) > 0;
        }
    }
}
