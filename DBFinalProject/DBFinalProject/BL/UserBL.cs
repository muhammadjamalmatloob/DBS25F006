using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DBFinalProject.DL;

namespace DBFinalProject.BL
{
    public abstract class UserBL
    {
        protected int user_id;

        protected string username;

        protected string email;

        protected string password;

        protected int role_id;


        public UserBL()
        {
            user_id = 0;
            username = "";
            email = "";
            password = "";
            role_id = 0;
        }
        public UserBL(string username, string email, string password, int role_id)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.role_id = role_id;
        }

        public void set_user_id(int user_id)
        {
            this.user_id = user_id;
        }
        public int get_user_id()
        {
            return this.user_id;
        }

        public (bool isValid, string errorMessage) set_username(string username)
        {
            if (string.IsNullOrEmpty(username) || username == "Enter Username")
            {
                return (false, "Username cannot be empty.");
            }
            else if (username.Length < 8)
            {
                return (false, $"Username must be at least 8 characters long.");
            }
            else if (!Regex.IsMatch(username, "[a-z]") && !Regex.IsMatch(username, "[A-Z]"))
            {
                return (false, "Username must contain at least one letter.");
            }
            else if (Regex.IsMatch(username[0].ToString(), "[0-9]"))
            {
                return (false, "Username can't start with a digit.");
            }
            if (!Regex.IsMatch(username, "[0-9]"))
            {
                return (false, "Username must contain at least one digit.");
            }
            if (Regex.IsMatch(username, "[^a-zA-Z0-9]"))
            {
                return (false, "Username can't contain special character.");
            }
            this.username = username;
            return (true, "");
        }
        public string get_username()
        {
            return this.username;
        }

        public void set_email(string email)
        {
            this.email = email;
        }

        public string get_email()
        {
            return this.email;
        }

        public (bool isValid, string errorMessage) set_password_hash(string password)
        {
            if (string.IsNullOrEmpty(password) || password == "Enter Password" )
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
            this.password = password;
            return (true, "");
        }
        public string get_password_hash()
        {
            return this.password;
        }
        public void set_role_id(int role_id)
        {
            this.role_id = role_id;
        }
        public int get_role_id()
        {
            return this.role_id;
        }
    }
}
