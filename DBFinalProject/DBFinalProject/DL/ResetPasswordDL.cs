using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DBFinalProject.Utility;

namespace DBFinalProject.DL
{
    internal class ResetPasswordDL : password
    {
        public static int UpdatePassword(string password, string email)
        {
            string query = $"Update users set password_hash = '{HashPassword(password)}' Where email = '{email}'";
            int row = DatabaseHelper.Instance.Update(query);
            return row;
        }
        public static bool EmailPresent(string email)
        {
            string query = $"Select * From users Where email = '{email}'";
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

