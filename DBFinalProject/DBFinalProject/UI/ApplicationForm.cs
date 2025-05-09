using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using CountryData.Standard;
using DBFinalProject.DL;

namespace DBFinalProject
{

    public partial class ApplicationForm : KryptonForm
    {
        public static bool emailVerification = true;
        public static ApplicationProfile application = new ApplicationProfile();
        ApplicationForm2 form2;
        
        public ApplicationForm()
        {
            InitializeComponent();
            kryptonComboBox1.SelectedIndex = 0;
            kryptonComboBox2.SelectedIndex = 0;
            
        }

        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            
            string firstname = kryptonTextBox1.Text;
            string lastname = kryptonTextBox2.Text;
            string contact = kryptonTextBox3.Text;
            string gender = kryptonComboBox1.Text;
            string cnic = kryptontextbox5.Text;
            string country = kryptonComboBox2.Text;
            string address = kryptonTextBox4.Text;
            string mail = kryptonTextBox6.Text;
            var (Email_Valid, Email_message) = await application.SetEmail(mail);
            if (firstname == "Enter First Name" || lastname == "Enter Last Name" ||
                contact == "Enter Contact Number" || cnic == "Enter CNIC"
                || address == "Enter Address" || mail == "Enter Email"
                || kryptonComboBox1.SelectedIndex == 0
                || kryptonComboBox2.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!application.SetFirstName(firstname).valid)
            {
                MessageBox.Show(application.SetFirstName(firstname).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!application.SetLastName(lastname).valid)
            {
                MessageBox.Show(application.SetLastName(lastname).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!application.SetContact(contact).valid)
            {
                MessageBox.Show(application.SetContact(contact).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!application.SetCnic(cnic).valid)
            {
                MessageBox.Show(application.SetCnic(cnic).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!application.SetAddress(address).valid)
            {
                MessageBox.Show(application.SetAddress(address).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!application.SetCountry(country).valid)
            {
                MessageBox.Show(application.SetCountry(country).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            else if (!Email_Valid)
            {
                MessageBox.Show(Email_message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            emailVerification = true;
            if (kryptonComboBox2.SelectedIndex == 1)
            {
                application.SetGender(Gender.Male);
            }
            else
            {
                application.SetGender(Gender.Female);
            }
            if (form2 == null)
            {
                form2 = new ApplicationForm2(this);
            }
            form2.Show();
            this.Hide();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            MainInterface mainInterface = new MainInterface();
            mainInterface.Show();
            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonTextBox2_Focus(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "Enter Last Name")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }

        private void kryptonTextBox1_Focus(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Enter First Name")
            {
                kryptonTextBox1.Text = "";
                kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }
        private void kryptonTextBox1_LostFocus(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Enter First Name";
                kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            }

        }
        private void kryptonTextBox2_LostFocus(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Enter Last Name";
                kryptonTextBox2.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            }

        }

        

        private void kryptonTextBox3_Focus(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "Enter Contact Number")
            {
                kryptonTextBox3.Text = "";
                kryptonTextBox3.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }
        private void kryptonTextBox3_LostFocus(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "")
            {
                kryptonTextBox3.Text = "Enter Contact Number";
                kryptonTextBox3.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            }

        }

        private void kryptonTextBox5_Focus(object sender, EventArgs e)
        {
            if (kryptontextbox5.Text == "Enter CNIC")
            {
                kryptontextbox5.Text = "";
                kryptontextbox5.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }
        private void kryptonTextBox5_LostFocus(object sender, EventArgs e)
        {
            if (kryptontextbox5.Text == "")
            {
                kryptontextbox5.Text = "Enter CNIC";
                kryptontextbox5.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            }

        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox5_TextChanged(object sender, EventArgs e)
        {

            if (kryptontextbox5.Text != "Enter CNIC")
            {
                string currentText = kryptontextbox5.Text.Replace("-", "");
                int cursorPos = kryptontextbox5.SelectionStart;


                if (currentText.Length > 5)
                {
                    currentText = currentText.Insert(5, "-");
                }
                if (currentText.Length > 13)
                {
                    currentText = currentText.Insert(13, "-");
                }

                if (kryptontextbox5.Text != currentText)
                {
                    kryptontextbox5.Text = currentText;


                    if (cursorPos == 6 || cursorPos == 14)
                    {
                        kryptontextbox5.SelectionStart = cursorPos + 1;
                    }
                    else
                    {
                        kryptontextbox5.SelectionStart = cursorPos;
                    }
                }
            }
        }

        private void kryptonTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            string currentText = kryptontextbox5.Text;
            int selectionStart = kryptontextbox5.SelectionStart;

            
            if (e.KeyChar == '\b' && selectionStart > 0)
            {
                
                if (currentText.Length > selectionStart - 1 &&
                    currentText[selectionStart - 1] == '-')
                {
                    kryptontextbox5.SelectionStart = selectionStart - 1;
                }
                return;
            }

            
            if (e.KeyChar == '-')
            {
                e.Handled = true;
                return;
            }

        }

        private void kryptonTextBox4_Focus(object sender, EventArgs e)
        {
            if (kryptonTextBox4.Text == "Enter Address")
            {
                kryptonTextBox4.Text = "";
                kryptonTextBox4.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }
        private void kryptonTextBox4_LostFocus(object sender, EventArgs e)
        {
            if (kryptonTextBox4.Text == "")
            {
                kryptonTextBox4.Text = "Enter Address";
                kryptonTextBox4.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            }

        }
        private void kryptonTextBox6_Focus(object sender, EventArgs e)
        {
            if (kryptonTextBox6.Text == "Enter Email")
            {
                kryptonTextBox6.Text = "";
                kryptonTextBox6.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }
        private void kryptonTextBox6_LostFocus(object sender, EventArgs e)
        {
            if (kryptonTextBox6 .Text == "")
            {
                kryptonTextBox6.Text = "Enter Email";
                kryptonTextBox6.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            }

        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Application_Load(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox6_TextChanged(object sender, EventArgs e)
        {
            emailVerification = false;
        }
    }

}
