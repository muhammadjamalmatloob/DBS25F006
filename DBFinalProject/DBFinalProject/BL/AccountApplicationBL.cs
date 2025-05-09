using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBFinalProject.Utility;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace DBFinalProject.BL
{
    public class ApplicationProfile
    {
        private byte[] _profilePic;
        private byte[] _cnicFront;
        private byte[] _cnicBack;
        private string _firstName;
        private string _lastName;
        private Gender _gender;
        private string _contact;
        private string _email;
        private string _country;
        private string _address;
        private string _cnic;
        private ApplicationStatus _status;
        private DateTime _applicationDate;
        private string _branch;
        private string account_type;

        public byte[] GetProfilePic() => _profilePic;
        public (bool valid, string message) SetProfilePic(byte[] value)
        {
            if (value == null || value.Length == 0)
                return (false, "Profile picture cannot be empty.");

            _profilePic = value;
            return (true, "Profile picture set successfully.");
        }

        
        public byte[] GetCnicFront() => _cnicFront;
        public (bool valid, string message) SetCnicFront(byte[] value)
        {
            if (value == null || value.Length == 0)
                return (false, "CNIC front image cannot be empty.");

            _cnicFront = value;
            return (true, "CNIC front image set successfully.");
        }

        
        public byte[] GetCnicBack() => _cnicBack;
        public (bool valid, string message) SetCnicBack(byte[] value)
        {
            if (value == null || value.Length == 0)
                return (false, "CNIC back image cannot be empty.");

            _cnicBack = value;
            return (true, "CNIC back image set successfully.");
        }

       
        public string GetFirstName() => _firstName;
        public (bool valid, string message) SetFirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (false, "First name cannot be empty.");

            if (value.Length > 50)
                return (false, "First name cannot exceed 50 characters.");

            _firstName = value;
            return (true, "First name set successfully.");
        }

        
        public string GetLastName() => _lastName;
        public (bool valid, string message) SetLastName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (false, "Last name cannot be empty.");

            if (value.Length > 50)
                return (false, "Last name cannot exceed 50 characters.");

            _lastName = value;
            return (true, "Last name set successfully.");
        }

        
        public Gender GetGender() => _gender;
        public (bool valid, string message) SetGender(Gender value)
        {
            if (!Enum.IsDefined(typeof(Gender), value))
                return (false, "Invalid gender value.");

            _gender = value;
            return (true, "Gender set successfully.");
        }

        
        public string GetContact() => _contact;
        public (bool valid, string message) SetContact(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (false, "Contact number cannot be empty.");

            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[0-9+]+$"))
                return (false, "Contact number can only contain digits and '+'.");

            _contact = value;
            return (true, "Contact number set successfully.");
        }

        
        public string GetEmail() => _email;
        public async Task<(bool valid, string message)> SetEmail(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (false, "Email cannot be empty.");

            try
            {
                var addr = new System.Net.Mail.MailAddress(value);
                if (addr.Address != value)
                    return (false, "Invalid email format.");
            }
            catch
            {
                return (false, "Invalid email format.");
            }
            if (!ApplicationForm.emailVerification)
            {
                try
                {
                    Task<bool> status = EmailSender.SendEmailAsync(value, "Email Verification", "You are opening an account with this email.");
                    if (!(await status))
                        return (false, "Make sure the email you are trying to enter is correct and your internet connection is not lost.");
                }

                catch
                {

                    return (false, "Error in sending email.");
                }
            }
            _email = value;
            return (true, "Email set successfully.");
        }

        public string GetCnic() => _cnic;
        public (bool valid, string message) SetCnic(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (false, "CNIC cannot be empty.");

            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[0-9]{5}-[0-9]{7}-[0-9]{1}$"))
                return (false, "CNIC must be in the format 12345-1234567-1.");

            _cnic = value;
            return (true, "CNIC set successfully.");
        }

        public DateTime GetApplicationDate() => _applicationDate;
        public (bool valid, string message) SetApplicationDate(DateTime value)
        {
            if (value == null)
                return (false, "Application date cannot be null.");

            if (value > DateTime.Now)
                return (false, "Application date cannot be in the future.");

            _applicationDate = value;
            return (true, "Application date set successfully.");
        }
        public ApplicationStatus GetStatus() => _status;
        public (bool valid, string message) SetStatus(ApplicationStatus value)
        {
            if (!Enum.IsDefined(typeof(ApplicationStatus), value))
                return (false, "Invalid application status.");

            _status = value;
            return (true, "Application status set successfully.");
        }

        public string GetCountry() => _country;
        public (bool valid, string message) SetCountry(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (false, "Country cannot be empty.");

            if (value.Length > 100)
                return (false, "Country name cannot exceed 100 characters.");

            _country = value;
            return (true, "Country set successfully.");
        }

        public string GetAddress() => _address;
        public (bool valid, string message) SetAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (false, "Address cannot be empty.");

            if (value.Length > 200)
                return (false, "Address cannot exceed 200 characters.");

            _address = value;
            return (true, "Address set successfully.");
        }
        public string GetBranch() => _branch;
        public (bool valid, string message) SetBranch(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (false, "Branch cannot be empty.");

            _branch = value;
            return (true, "Branch set successfully.");
        }

        public string GetAccountType() => account_type;
        public (bool valid, string message) SetAccountType(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return (false, "Account type cannot be empty.");

            account_type = value;
            return (true, "Account type set successfully.");
        }

    }

    public enum Gender { Male, Female }
    public enum ApplicationStatus { Pending, Verified, Rejected }
}