﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.BL;
using DBFinalProject.DL;
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class Withdraw : UserControl
    {
        
        public Withdraw()
        {
            
            InitializeComponent();
            grpReciept.Visible = false;
            
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            reset_reciept();
            string account_number = "";
            string amount = "";
            string pin = "";
            string username = DL.LoginDL.user.getUsername();
            int user_id = DL.UserDL.get_user_id(username);
            int client_id = DL.ClientDL.getClientIdbyUserId(user_id);
            try
            {
                account_number = kryptonTextBox1.Text.Trim();
                amount = kryptonTextBox3.Text.Trim();
                pin = kryptonTextBox4.Text.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }

            if (AccountDL.isAccountOfClient(account_number,client_id))
            {

                WithdrawalBL withdrawal = new WithdrawalBL();
                int acc_id = AccountDL.getAccountIdByNumber(account_number);
                withdrawal.setFromAccID(AccountDL.getAccountIdByNumber(account_number));
                withdrawal.setClientId(AccountDL.getCleintIdByNumber(account_number));
                withdrawal.setAmount(Convert.ToDecimal(amount));
                withdrawal.setCharges(withdrawal.getAmount());
                withdrawal.setDate(DateTime.Now);
                withdrawal.setTransactionType(6);
                int acc_type_id = DL.AccountDL.getAccountTypeIdByNumber(account_number);
                int max_amount = AccountTypeDL.getWithdrawlLimit(acc_type_id);
                int current_balance = AccountDL.getBalanceById(acc_id);
                if (Convert.ToInt64(amount) > max_amount)
                {
                    MessageBox.Show($"Withdrawal Limit is {max_amount}.");
                    return;
                }
                if (pin == AccountDL.getPinByNumber(account_number))
                {
                    try
                    {
                        if (AccountBL.isSufficientBalance(account_number, withdrawal.getAmount(), withdrawal.getCharges()))
                        {
                            if (WithdrawalDL.withdrawlAmmount(withdrawal))
                            {

                                MessageBox.Show("Withdrawal successful.");
                                generate_reciept(withdrawal, account_number);
                            }
                            else
                            {
                                MessageBox.Show("Withdrawal failed.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Insufficient balance.");
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid PIN");
                }
            }
            else
            {
                MessageBox.Show("Account not found in this branch.");
                return;
            }
        }

        private void generate_reciept(WithdrawalBL withdrawal, string account_number)
        {

            grpReciept.Visible = true;
            int user_id = ClientDL.getUserIdByClientId(withdrawal.getClientId());
            string user_name = UserDL.getUserNameById(user_id);
            name.Text = user_name;
            account_num.Text = account_number;
            amount.Text = withdrawal.getAmount().ToString();
            charges.Text = withdrawal.getCharges().ToString();
            date.Text = withdrawal.getDate().ToString();

        }

        private void reset_reciept()
        {
            grpReciept.Visible = false;
            name.Text = "NAME";
            account_num.Text = "NUM";
            amount.Text = "AMOUNT";
            charges.Text = "CHARGES";
            date.Text = "DATE";

        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox3.Text == "Amount")
            {
                kryptonTextBox3.Text = "";
            }
        }

        private void kryptonTextBox3_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "")
            {
                kryptonTextBox3.Text = "Amount";
            }
        }

        private void kryptonTextBox4_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox4.Text == "PIN")
            {
                kryptonTextBox4.Text = "";
                kryptonTextBox4.PasswordChar = '*';
            }
        }

        private void kryptonTextBox4_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox4.Text == "")
            {
                kryptonTextBox4.Text = "PIN";
                kryptonTextBox4.PasswordChar = '\0';
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox1.Text == "Account Number")
            {
                kryptonTextBox1.Text = "";
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Account Number";
            }
        }
    }
}
