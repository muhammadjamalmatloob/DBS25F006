﻿using System;
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
using DBFinalProject.BL;
using DBFinalProject.DL;
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class SignUp02 : KryptonForm
    {
        SignUp signUp;
        ClientBL client;
        string otp;
        public static string email;
        private int timeLeft = 120;
        int numberOfverification = 0;
        public SignUp02(SignUp signUp)
        {
            
            InitializeComponent();
            this.signUp = signUp;
        }


        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            signUp.Show();
            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void login_btn_Click(object sender, EventArgs e)
        {
            email = kryptonTextBox1.Text;
            if (!Regex.IsMatch(email, "[@]"))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!SignUpDL.EmailPresent(email))
            {
                MessageBox.Show("No Client with this email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void kryptonTextBox1_LostFocus(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Enter Email";
                kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
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

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            numberOfverification++;
            string entered_otp = kryptonTextBox2.Text;
            if (numberOfverification >= 3)
            {
                MessageBox.Show("No more option left. Invalid attempt to access an account.");
            }
            else if (entered_otp == otp)
            {
                SignUpDL.AddClient();
                MessageBox.Show("OTP verified. Signed Up Successfully.");
                new MainInterface().Show();
                this.Close();
                otp = null;
            }
            else
            {
                MessageBox.Show($"Incorrect OTP.{3 - numberOfverification} more option(s) left. Please try again.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;


            timerLabel.Text = $"Time left: {timeLeft / 60:D2}:{timeLeft % 60:D2}";

            if (timeLeft <= 0 && otp != null)
            {
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

        private void timerLabel_Click(object sender, EventArgs e)
        {

        }
        
    }
}
