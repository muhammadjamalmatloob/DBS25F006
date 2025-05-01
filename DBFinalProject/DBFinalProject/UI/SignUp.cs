using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.DL;

namespace DBFinalProject
{
    public partial class SignUp : KryptonForm
    {
        
        SignUp02 signUp02;
        public SignUp(SignUp02 signUp02 = null)
        {
            this.signUp02 = signUp02;
            InitializeComponent();
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true || pass.Text == "Enter Password")
            {
                pass.PasswordChar = '\0';
            }
            else
            {
                pass.PasswordChar = '•';
            }
        }
        private void pass_Focus(object sender, EventArgs e)
        {
            if (pass.Text == "Enter Password")
            {
                pass.Text = "";
                pass.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }

        private void user_name_Focus(object sender, EventArgs e)
        {
            if (user_name.Text == "Enter Username")
            {
                user_name.Text = "";
                user_name.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }
        private void pass_LostFocus(object sender, EventArgs e)
        {
            if (pass.Text == "")
            {
                pass.Text = "Enter Password";
                pass.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
                pass.PasswordChar = '\0';
            }

        }

        private void user_name_LostFocus(object sender, EventArgs e)
        {
            if (user_name.Text == "")
            {
                user_name.Text = "Enter Username";
                user_name.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
                user_name.PasswordChar = '\0';
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = user_name.Text.Trim();
            string password = pass.Text.Trim();

            

            try
            {
                if (SignUpDL.IsPresent(username))
                {
                    MessageBox.Show("Username not available. Please try another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!SignUpDL.client.set_username(username).isValid)
                {
                    MessageBox.Show(SignUpDL.client.set_username(username).errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!SignUpDL.client.set_password_hash(password).isValid)
                {
                    MessageBox.Show(SignUpDL.client.set_password_hash(password).errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (signUp02 == null)
                    {
                        new SignUp02(this).Show();
                        this.Hide();
                    }
                    else
                    {
                        signUp02.Show();
                        this.Hide();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
