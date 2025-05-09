using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFinalProject.BL;
using DBFinalProject.Utility;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DBFinalProject.DL
{
    internal class UserDL
    {
        public static List<UserBL> users = new List<UserBL>();

        public static void AddUser(UserBL user)
        {
            users.Add(user);
        }


        public static int get_role_id(string role_name)
        {
            //string query = $"SELECT lookup_id FROM lookup WHERE value = '{role_name}'";
            string stored_procedure = $"CALL sp_GetRoleId('{role_name}')";
            int role_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(stored_procedure))
            {
                if (reader.Read())
                {
                    role_id = Convert.ToInt32(reader["lookup_id"].ToString());
                }
            }
            return role_id;
        }
        public static string get_role(int role_id)
        {
            //string query = $"SELECT value FROM lookup WHERE lookup_id = '{role_id}'";
            string stored_procedure = $"CALL sp_GetRoleName({role_id})";
            string role_name = "";
            using (var reader = DatabaseHelper.Instance.getData(stored_procedure))
            {
                if (reader.Read())
                {
                    role_name = (reader["value"].ToString());
                }
            }
            return role_name;
        }


  
        


        public static int get_user_id(string username)
        {
            //string query = $"SELECT user_id FROM users WHERE username = '{username}'";
            string stored_procedure = $"CALL sp_GetUserIdByUserName('{username}')";
            int user_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(stored_procedure))
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
            //string query = $"SELECT user_id FROM users WHERE email = '{email}'";
            string stored_procedure = $"CALL sp_GetUserIdByEmail('{email}')";
            int user_id = 0;
            using (var reader = DatabaseHelper.Instance.getData(stored_procedure))
            {
                if (reader.Read())
                {
                    user_id = Convert.ToInt32(reader["user_id"].ToString());
                }
            }
            return user_id;
        }

        public static bool isDublicateUserName(string user_name)
        {
            string query = $"SELECT * FROM users WHERE username = '{user_name}'";
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

        public static bool isDublicateEmail(string email)
        {
            string query = $"SELECT * FROM users WHERE email = '{email}'";
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

        public static string getUserNameById(int user_id)
        {
            string query = $"SELECT username FROM users WHERE user_id = '{user_id}'";
            string user_name = "";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    user_name = (reader["username"].ToString());
                }
            }
            return user_name;
        }
    }
}
