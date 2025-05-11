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
using DBFinalProject.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBFinalProject
{
    public partial class ResetPassword01 : KryptonForm
    {
        public ResetPassword01()
        {
            InitializeComponent();
        }

        
        private void pass_Focus(object sender, EventArgs e)
        {
            if (pass.Text == "Enter Password")
            {
                pass.Text = "";
                pass.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }
            
        }

        private void kryptonTextBox1_Focus(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Confirm Password")
            {
                kryptonTextBox1.Text = "";
                kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Black;
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

        private void kryptonTextBox1_LostFocus(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Confirm Password";
                kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
                kryptonTextBox1.PasswordChar = '\0';
            }

        }
        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (pass.Text != "Enter Password")
            {
                if (checkBox1.Checked == true)
                {
                    pass.PasswordChar = '\0';
                }
                else
                {
                    pass.PasswordChar = '•';
                }
            }
            if (kryptonTextBox1.Text != "Confirm Password")
            {
                if (checkBox1.Checked == true)
                {
                    kryptonTextBox1.PasswordChar = '\0';
                }
                else
                {
                    kryptonTextBox1.PasswordChar = '•';
                }
            }
                
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            string p1 = pass.Text;
            string p2 = kryptonTextBox1.Text;
            if (string.IsNullOrEmpty(p1) || string.IsNullOrEmpty(p2))
            {
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemLogsDL.AddLog(27, "Password Reset Failed", "Invalid Information Entered");
                return;
            }
            else if (p1 != p2)
            {
                MessageBox.Show("Enter same password in both fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemLogsDL.AddLog(27, "Password Reset Failed", "Invalid Information Entered");
                return;
            }
            else if (!ResetPasswordDL.IsPasswordValidWithErrors(p1).isValid)
            {
                MessageBox.Show(ResetPasswordDL.IsPasswordValidWithErrors(p1).errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemLogsDL.AddLog(27, "Password Reset Failed", "Invalid Information Entered");
                return;
            }
            try
            {
                int r = ResetPasswordDL.UpdatePassword(p1, ResetPassword.email);
                if (r > 0)
                {
                    SystemLogsDL.AddLog(26, "Password Reset", "Successfull");
                    MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    SystemLogsDL.AddLog(28, "Password Reset", "An error occured");
                    MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Hide();
                new MainInterface().Show();
            }
            catch (Exception ex)
            {
                SystemLogsDL.AddLog(28, "Password Reset", "An error occured");
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            if (pass.Text != "Enter Password")
            {
                if (checkBox1.Checked == true)
                {
                    pass.PasswordChar = '\0';
                }
                else
                {
                    pass.PasswordChar = '•';
                }
            }
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text != "Confirm Password")
            {
                if (checkBox1.Checked == true)
                {
                    kryptonTextBox1.PasswordChar = '\0';
                }
                else
                {
                    kryptonTextBox1.PasswordChar = '•';
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasswordInstructions.Visible = true;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            PasswordInstructions.Visible = false;
        }
    }
}
