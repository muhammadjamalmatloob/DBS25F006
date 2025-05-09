using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFinalProject.BL;
using DBFinalProject.Utility;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace DBFinalProject.DL
{
    public class LoginDL : PasswordFunc
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
            string query = $"SELECT l.value AS position FROM users u " +
                $"JOIN employees e ON u.user_id = e.user_id " +
                $"JOIN lookup l ON e.position = l.lookup_id " +
                $"WHERE u.username = '{username}' " +
                $"AND l.category = 'position'; ";
            
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return reader["position"].ToString();
            
        }
    }
}
