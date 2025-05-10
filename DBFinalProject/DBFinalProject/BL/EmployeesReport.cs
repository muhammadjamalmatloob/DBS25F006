using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFinalProject.BL
{
    public class EmployeesReport
    {
        public string name { get; set;}
        public string gender { get; set;}
        public string position { get; set;}
        public string salary {  get; set;}
        public string contact { get; set; }

        public EmployeesReport(string name, string gender, string position, string salary, string contact)
        {
            this.name = name;
            this.gender = gender;
            this.position = position;
            this.salary = salary;
            this.contact = contact;
        }
    }
}
