using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFinalProject.BL;

namespace DBFinalProject
{
    public partial class Withdraw : UserControl
    {
        public Withdraw()
        {
            InitializeComponent();
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            decimal amount = Convert.ToDecimal(kryptonTextBox3.Text);
            WithdrawalBL withdrawal = new WithdrawalBL();
            //withdrawal.setFromAccID();
            withdrawal.setAmount(amount);
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
