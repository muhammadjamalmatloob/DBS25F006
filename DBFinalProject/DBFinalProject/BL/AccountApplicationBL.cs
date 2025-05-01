using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace DBFinalProject.BL
{
    public class AccountApplicationBL
    {

        private byte[] ProfilePic { get; set; }

        private byte[] CnicFront { get; set; }

        private byte[] CnicBack { get; set; }

        private string FirstName { get; set; }

        private string LastName { get; set; }

        private Gender gender { get; set; }

        private string Contact { get; set; }

        private string Email { get; set; }

        private string Nationality { get; set; }


        private string City { get; set; }

        private string Country { get; set; }


        private string Address { get; set; }

        private string Cnic { get; set; }

        private ApplicationStatus Status { get; set; }

        private DateTime? ApplicationDate { get; set; } = DateTime.Now;

        private BranchBL branch { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum ApplicationStatus
    {
        Pending,
        Verified,
        Rejected
    }
}

