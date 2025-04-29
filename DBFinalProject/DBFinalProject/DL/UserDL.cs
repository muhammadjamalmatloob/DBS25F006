using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class UserDL
    {

        
        public static int get_role_id(string role_name)
        {
            string query = $"SELECT lookup_id FROM lookup WHERE value = '{role_name}'";
            int role_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    role_id = Convert.ToInt32(reader["lookup_id"].ToString());
                }
            }
            return role_id;
        }
        public static int get_user_id(string username)
        {
            string query = $"SELECT user_id FROM users WHERE username = '{username}'";
            int user_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    user_id = Convert.ToInt32(reader["user_id"].ToString());
                }
            }
            return user_id;
        }
        public static int get_user_id_by_email(string email)
        {
            string query = $"SELECT user_id FROM users WHERE email = '{email}'";
            int user_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    user_id = Convert.ToInt32(reader["user_id"].ToString());
                }
            }
            return user_id;
        }
    }
}
