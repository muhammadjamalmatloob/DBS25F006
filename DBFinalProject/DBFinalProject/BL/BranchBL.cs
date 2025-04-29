using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    internal class BranchBL
    {
        private int branch_id;
        private string branch_name;
        private int branch_code;
        private string address;
        private string contact;
        private string city;
        private string country;

        public BranchBL()
        {
            this.branch_name = "";
            this.branch_code = 0;
            this.address = "";
            this.contact = "";
            this.city = "";
            this.country = "";
        }

        public BranchBL(int branch_id,string branch_name, int branch_code, string address, string contact, string city, string country)
        {
            this.branch_id = branch_id;
            this.branch_name = branch_name;
            this.branch_code = branch_code;
            this.address = address;
            this.contact = contact;
            this.city = city;
            this.country = country;
        }

        public void set_branch_id(int branch_id)
        {
            this.branch_id = branch_id;
        }
        public int get_branch_id()
        {
            return this.branch_id;
        }

        public void set_branch_name(string branch_name)
        {
            this.branch_name = branch_name;
        }
        public string get_branch_name()
        {
            return this.branch_name;
        }

        public void set_branch_code(int branch_code)
        {
            this.branch_code = branch_code;
        }
        public int get_branch_code()
        {
            return this.branch_code;
        }

        public void set_address(string address)
        {
            this.address = address;
        }

        public string get_address()
        {
            return this.address;
        }

        public void set_contact(string contact)
        {
            this.contact = contact;
        }

        public string get_contact()
        {
            return this.contact;
        }

        public void set_city(string city)
        {
            this.city = city;
        }

        public string get_city()
        {
            return this.city;
        }

        public void set_country(string country)
        {
            this.country = country;
        }

        public string get_country()
        {
            return this.country;
        }


    }
}
