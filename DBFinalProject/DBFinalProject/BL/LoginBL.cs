using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    public class LoginBL
    {
        private string username;
        private string password;
        private string role;
        private string email;
        public LoginBL ()
        { }
        public LoginBL (string username, string password, string role, string email)
        {
            this.username = username;
            this.password = password;
            this.role = role;
            this.email = email;
        }
        public string getRole()
        {
            return this.role;
        }
        public string getUsername()
        {
            return this.username;
        }
        public string getemail()
        {
            return this.email;
        }
    }
}
