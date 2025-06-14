﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFinalProject.BL;
using DBFinalProject.DL;
using DBFinalProject.UI;

namespace DBFinalProject
{
    public partial class ClientLoan : UserControl
    {
        public ClientLoan()
        {
            InitializeComponent();
            LoanTypeDL.LoadAllLoanTypes();
            LoanTypeDL.LoadLoanTypeInComboBox(kryptonComboBox2);
        }

        private void kryptonTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonComboBox2.Text == "Select Loan Type")
            {
                kryptonComboBox2.Text = "";
            }
        }

        private void kryptonComboBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox2.Text == "")
            {
                kryptonComboBox2.Text = "Select Loan Type";
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "Purpose")
            {
                kryptonComboBox2.Text = "";
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if(kryptonTextBox2.Text == "")
            {
                kryptonComboBox2.Text = "Purpose";
            }
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox1.Text == "Amount Request")
            {
                kryptonTextBox1.Text = "";
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Amount Request";
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = DL.LoginDL.user.getUsername();
                string account_num = kryptonTextBox3.Text;
                string loan_type = kryptonComboBox2.SelectedItem.ToString();
                if (loan_type == null || loan_type == "Select Loan Type")
                {
                    MessageBox.Show("Please Select Loan Type");
                }
                string purpose = kryptonTextBox2.Text;
                decimal amount = Convert.ToDecimal(kryptonTextBox1.Text);
                int user_id = DL.UserDL.get_user_id(username);
                int client_id = DL.ClientDL.getClientIdbyUserId(user_id);
                int acc_id = DL.AccountDL.getAccountIdByNumber(account_num);
                int LTID = DL.LoanTypeDL.getIdByName(loan_type);
                string status = kryptonComboBox1.SelectedItem.ToString();
                if(DL.AccountDL.isAccountOfClient(account_num,client_id))
                {

                    LoanApplicationBL application = new LoanApplicationBL();
                    application.setClientId(client_id);
                    application.setLoanTypeId(LTID);
                    application.setAccountId(acc_id);
                    application.SetRequestAmount(amount);
                    application.setPurpose(purpose);
                    int e_status = 0;
                    if (status == "Employed")
                    {
                        e_status = 1;
                    }
                    application.setEmployementStatus(e_status);
                    application.setLoanStatus(18);
                    application.setApplyDate(DateTime.Now);
                    DL.LoanApplicationDL.AddApplication(application);
                    MessageBox.Show("Application Submitted");
                }
                else
                {
                    MessageBox.Show("Invalid Account");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


        }

        private void kryptonComboBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonComboBox1.Text == "Employment Status")
            {
                kryptonComboBox1.Text = "";
            }
        }

        private void kryptonComboBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text == "")
            {
                kryptonComboBox1.Text = "Employment Status";
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox3.Text == "Account Number")
            {
                kryptonTextBox3.Text = "";
            }
        }

        private void kryptonTextBox3_Leave(object sender, EventArgs e)
        {
            if(kryptonTextBox3.Text == "")
            {
                kryptonTextBox3.Text = "Account Number";
            }
        }
    }
}