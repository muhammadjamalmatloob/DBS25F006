using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.DL;
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class ResetPassword : KryptonForm
    {
        string otp;
        public static string email;
        private int timeLeft = 120;
        int numberOfverification = 0;
        public ResetPassword()
        {
            
            InitializeComponent();
            
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {
            
        }

        private void kryptonTextBox1_LostFocus(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Enter Email";
                kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
                kryptonTextBox1.PasswordChar = '\0';
            }

        }

        private void kryptonTextBox1_Focus(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Enter Email")
            {
                kryptonTextBox1.Text = "";
                kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }
        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            email = kryptonTextBox1.Text;
            if (!Regex.IsMatch(email, "[@]"))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SystemLogsDL.AddLog(27, "Password Reset Failed", "Invalid Information Entered");
            }
            else if (!ResetPasswordDL.EmailPresent(email))
            {
                SystemLogsDL.AddLog(27, "Password Reset Failed", "Invalid Information Entered");
                MessageBox.Show("No user with this email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                otp = GenerateRandomOtp();
                string subject = "Password Reset OTP";
                string body = $"Your OTP is {otp}." +
                    $"\nPlease don't share it with anyone. It will expire in 2 minutes.";
                Task<bool> result = EmailSender.SendEmailAsync(email, subject, body);
                kryptonButton1.Text = "Sending...";
                kryptonButton1.Enabled = false;
                kryptonTextBox1.Enabled = false;
                System.Threading.Thread.Sleep(100);
                if (await result)
                {
                    kryptonButton1.Text = "Send OTP";
                    MessageBox.Show("OTP sent to your email.");
                    kryptonLabel1.Visible = true;
                    kryptonTextBox1.Text = "";
                    kryptonTextBox2.Visible = true;
                    kryptonButton2.Visible = true;
                    timerLabel.Visible = true;
                    timeLeft = 120;
                    timer1.Start();

                }
                else
                {
                    SystemLogsDL.AddLog(28, "Password Reset Failed", "Failed to send OTP");
                    MessageBox.Show("Failed to send OTP. Please check your email and try again.");
                    ResetOtpFields();
                }
                
            }
            
        }
        private string GenerateRandomOtp()
        {
            Random random = new Random();
            return random.Next(10000, 99999).ToString();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            numberOfverification++;
            string entered_otp = kryptonTextBox2.Text;
            if(numberOfverification >= 3)
            {
                SystemLogsDL.AddLog(29, "Password Reset Failed", "Wrong Password entered many times");
                MessageBox.Show("No more option left. Invalid attempt to access an account.");
            }
            else if (entered_otp == otp)
            {
                SystemLogsDL.AddLog(26, "Password Reset", "OTP verified");
                MessageBox.Show("OTP verified. You can now reset your password.");
                new ResetPassword01().Show();
                this.Hide();
                otp = null;
            }
            else
            {
                SystemLogsDL.AddLog(27, "Password Reset Failed", "Invalid Information Entered");
                MessageBox.Show($"Incorrect OTP.{3 - numberOfverification} more option(s) left. Please try again.");
            }
        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;

            
            timerLabel.Text = $"Time left: {timeLeft / 60:D2}:{timeLeft % 60:D2}";

            if (timeLeft <= 0 && otp != null)
            {
                SystemLogsDL.AddLog(27, "Password Reset Failed", "OTP expired");
                timer1.Stop();
                MessageBox.Show("OTP has expired. Please request a new one.", "OTP Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetOtpFields();
            }
        }
        private void ResetOtpFields()
        {
            kryptonTextBox2.Visible = false;
            kryptonButton2.Visible = false;
            timerLabel.Visible = false;
            kryptonLabel1.Visible = false;
            kryptonTextBox1.Enabled = true;
            kryptonTextBox1.Text = "Enter Email";
            kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            kryptonButton1.Enabled = true;
            kryptonButton1.Text = "Resend OTP";
            numberOfverification = 0;
            timeLeft = 120; 
            otp = null; 
        }
    }
}
