using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    public abstract class UserBL
    {
        protected int user_id;

        protected string username;

        protected string email;

        protected string password_hash;

        protected int role_id;


        public UserBL()
        {
            user_id = 0;
            username = "";
            email = "";
            password_hash = "";
            role_id = 0;
        }
        public UserBL(string username, string email, string password_hash, int role_id)
        {
            this.username = username;
            this.email = email;
            this.password_hash = password_hash;
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

        public void set_username(string username)
        {
            this.username = username;
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

        public void set_password_hash(string password_hash)
        {
            this.password_hash = password_hash;
        }
        public string get_password_hash()
        {
            return this.password_hash;
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
