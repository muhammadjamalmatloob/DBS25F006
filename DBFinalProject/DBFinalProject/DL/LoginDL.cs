using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    public class LoginDL : password
    {
        public static LoginBL user;
        public static bool LoadData(string username, string password)
        {
            string query = $"Select username, password_hash, email, value as role FROM users join lookup ON role_id = lookup_id WHERE username = '{username}' AND password_hash = '{HashPassword(password)}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            if (reader.HasRows)
            {
                user = new LoginBL(reader["username"].ToString(), reader["password_hash"].ToString(), reader["role"].ToString(), reader["email"].ToString());
            }
            return reader.HasRows;
        }

        public static string GetPosition(string username)
        {
            string query = $"CALL GetEmployeePositionByUsername('{username}', @position);" +
                $"SELECT @position AS employee_position;";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return reader["employee_position"].ToString();
            
        }
    }
}
