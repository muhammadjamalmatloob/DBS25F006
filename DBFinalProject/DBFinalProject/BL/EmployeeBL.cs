using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.DL;

namespace DBFinalProject.BL
{
    internal class EmployeeBL : UserBL
    {
        private int employee_id;
        private string first_name;
        private string last_name;
        private string gender;
        private int position;
        private string department;
        private int branch_id;
        private float salary;
        private string contact;

        public EmployeeBL(string username,string email,string password_hash,int role_id,string first_name, string last_name, string gender, int position, string department, int branch_id, float salary, string contact) : base(username,email,password_hash,role_id)
        {
            this.username = username;
            this.email = email;
            this.password = password_hash;
            this.role_id = role_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.gender = gender;
            this.position = position;
            this.department = department;
            this.branch_id = branch_id;
            this.salary = salary;
            this.contact = contact;
        }

        public EmployeeBL(int employee_id, string first_name, string last_name, string gender, int position, string department, int branch_id, float salary, string contact)
        {
            this.employee_id = employee_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.gender = gender;
            this.position = position;
            this.department = department;
            this.branch_id = branch_id;
            this.salary = salary;
            this.contact = contact;
        }

        public EmployeeBL()
        {

        }

        public string get_employee_name()
        {
            return this.first_name + " " + this.last_name;
        }
        public void set_employee_id(int employee_id)
        {
            this.employee_id = employee_id;
        }
        public int get_employee_id()
        {
            return this.employee_id;
        }

        public void set_first_name(string f_name)
        {
            if (f_name.Length < 3)
            {
                throw new Exception("The First Name Must Be 3 Characters Long");
            }
            else if (f_name.Length > 50)
            {
                throw new Exception("The First Name should be less than 50 Characters long");
            }
            else if (f_name == "First Name")
            {
                throw new Exception("Please Enter a Valid First Name");
            }
            this.first_name= f_name;
        }
        public string get_first_name()
        {
            return this.first_name;
        }
        public string get_last_name()
        {
            
            return this.last_name;
        }
        public void set_last_name(string l_name)
        {
            if (l_name.Length < 3)
            {
                throw new Exception("The Last Name Must Be 3 Characters Long");
            }
            else if (l_name.Length > 50)
            {
                throw new Exception("The Last Name should be less than 50 Characters long");
            }
            else if (l_name == "Last Name")
            {
                throw new Exception("Please Enter a Valid Last Name");
            }
            this.last_name= l_name;
        }
        public void set_gender(string gender)
        {
            if (gender == "Select Gender")
            {
                throw new Exception("Please Select a Gender");
            }
            this.gender = gender;
        }
        public string get_gender()
        {
            return this.gender;
        }
        public void set_position(int position)
        {
            this.position = position;
        }
        public int get_position()
        {
            return this.position;
        }
        public void set_department(string department)
        {
            if (department == "Select Department")
            {
                throw new Exception("Please Select a Department");
            }
            this.department = department;
        }
        public string get_department()
        {
            return this.department;
        }
        public void set_branch_id(int branch_id)
        {
            this.branch_id = branch_id;
        }
        public int get_branch_id()
        {
            return this.branch_id;
        }
        public void set_salary(float salary)
        {
            if (salary < 0)
            {
                throw new Exception("Salary Cannot Be Negative");
            }
            else if (salary > 500000)
            {
                throw new Exception("Salary Cannot Be Greater Than 500000");
            }
            this.salary = salary;
        }
        public float get_salary()
        {
            return this.salary;
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
