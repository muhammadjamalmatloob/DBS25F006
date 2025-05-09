using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.DL;

namespace DBFinalProject.BL
{
    public class BranchBL
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
            if (branch_name.Length < 5)
            {
                throw new Exception("The Branch Name Must Be 5 Characters Long");
            }
            else if (branch_name.Length > 50)
            {
                throw new Exception("The Branch Name should be less than 50 Characters long");
            }
            else if (branch_name == "Branch Name")
            {
                throw new Exception("The Branch Name should not be empty");
            }
            else if (BranchDL.isDublicateBranch(branch_name))
            {
                throw new Exception("The Branch Name already exists");
            }
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
            if (address.Length < 5)
            {
                throw new Exception("The Address should be 5 Characters long");
            }
            else if (address.Length > 50)
            {
                throw new Exception("The Address should be less than 50 Characters long");
            }
            this.address = address;
        }

        public string get_address()
        {
            return this.address;
        }

        public void set_contact(string contact)
        {
            if (contact.Length != 11)
            {
                throw new Exception("Contact Number must be 11 Characters long!!!");
            }
            else if (contact == "Contact")
            {
                throw new Exception("Fill Contact Number");
            }
            else if (!IsAllDigits(contact))
            {
                throw new Exception("Contact Number can not be a string");
            }
            else if (BranchDL.isDublicateContact(contact))
            {
                throw new Exception("The Contact Number already exists");
            }
            else if (contact[0] != '0' && contact[1] != '3')
            {
                throw new Exception("Invalid Format !!! 03XX XXXXXXX");
            }
            this.contact = contact;
        }

        public string get_contact()
        {
            return this.contact;
        }

        public void set_city(string city)
        {
            if (city.Length < 3)
            {
                throw new Exception("The City Name should be 3 Characters long");
            }
            else if (city.Length > 50)
            {
                throw new Exception("The City Name should be less than 50 Characters long");
            }
            else if (city == "City")
            {
                throw new Exception("Fill City Name");
            }
            this.city = city;
        }

        public string get_city()
        {
            return this.city;
        }

        public void set_country(string country)
        {
            if (country.Length < 3)
            {
                throw new Exception("The Country Name should be 3 Characters long");
            }
            else if (country.Length > 50)
            {
                throw new Exception("The Country Name should be less than 50 Characters long");
            }
            else if (country == "City")
            {
                throw new Exception("Fill Country Name");
            }
            this.country = country;
        }

        public string get_country()
        {

            return this.country;
        }
        public bool IsAllDigits(string contact)
        {
            foreach (char c in contact)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

    }
}
