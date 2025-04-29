using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFinalProject
{
    public partial class SendMoney : UserControl
    {
        bool isVerified=false;
        public SendMoney()
        {
            InitializeComponent();
            GrpSender.Visible = false;
            GrpVerify.Visible = false;
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            isVerified = true;
            if (isVerified)
            {
                GrpSender.Visible = true;
                GrpVerify.Visible = true;
            }
            else
            {
                MessageBox.Show("Please verify your account first.");
            }
        }

        private void SendMoney_Load(object sender, EventArgs e)
        {
            isVerified = false;
            GrpSender.Visible = false;
            GrpVerify.Visible = false;
        }

        private void kryptonComboBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonComboBox1.Text == "Select Branch")
            {
                kryptonComboBox1.Text = "";
            }
        }

        private void kryptonComboBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text == "")
            {
                kryptonComboBox1.Text = "Select Branch";
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox2.Text == "Enter Account Number")
            {
                kryptonTextBox2.Text = "";
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Enter Account Number";
            }
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox1.Text == "Enter Account Number")
            {
                kryptonTextBox1.Text = "";
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Enter Account Number";
            }
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
    }
}
