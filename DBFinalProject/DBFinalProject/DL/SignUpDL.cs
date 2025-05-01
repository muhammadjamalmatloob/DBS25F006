using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DBFinalProject.BL;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    public class SignUpDL : PasswordFunc 
    {
        public static ClientBL client = new ClientBL();
        public static int AddClient()
        {
            string query = $"Insert Into users (username, email, password_hash, role_id) values ({client.get_username()},{client.get_email()},{PasswordFunc.HashPassword(client.get_password_hash()),3})";
            int rows = DatabaseHelper.Instance.Update(query);
            return rows;
        }
        public static bool IsPresent(string username)
        {
            string query = $"Select username FROM users WHERE username = '{username}'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return reader.HasRows;
        }
        public static bool EmailPresent(string email)
        {
            string query = $"Select * From account_application Where email = '{email}' and status = 'Verified'";
            var reader = DatabaseHelper.Instance.getData(query);
            reader.Read();
            return reader.HasRows;
        }
        public static (bool isValid, string errorMessage) IsPasswordValidWithErrors(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return (false, "Password cannot be empty.");
            }

            if (password.Length < 8)
            {
                return (false, $"Password must be at least 8 characters long.");
            }

            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                return (false, "Password must contain at least one uppercase letter.");
            }

            if (!Regex.IsMatch(password, "[a-z]"))
            {
                return (false, "Password must contain at least one lowercase letter.");
            }

            if (!Regex.IsMatch(password, "[0-9]"))
            {
                return (false, "Password must contain at least one digit.");
            }

            if (!Regex.IsMatch(password, "[^a-zA-Z0-9]"))
            {
                return (false, "Password must contain at least one special character.");
            }

            return (true, "");
        }
    }
}
