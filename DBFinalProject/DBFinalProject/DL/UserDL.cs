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
        public static string get_role(int role_id)
        {
            string query = $"SELECT value FROM lookup WHERE lookup_id = '{role_id}'";
            string role_name = "";
            using (var reader = DatabaseHelper.Instance.getData(query))
            {
                if (reader.Read())
                {
                    role_name = (reader["value"].ToString());
                }
            }
            return role_name;
        }


        //public static string get_role(int role_id)
        //{
        //    string query = "CALL GetRoleName(@role_id, @role_name); SELECT @role_name AS employee_position;";
        //    using (var connection = DatabaseHelper.Instance.getConnection())
        //    {
        //        if (connection.State == ConnectionState.Open)
        //        {
        //            connection.Close();
        //        }

        //        using (var command = new MySqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@role_id", role_id);
        //            command.Parameters.Add(new MySqlParameter("@role_name", MySqlDbType.VarChar) { Direction = ParameterDirection.Output });

        //            connection.Open();
        //            command.ExecuteNonQuery();
        //            return command.Parameters["@role_name"].Value.ToString();
        //        }
        //    }
        //}

        


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
    }
}
