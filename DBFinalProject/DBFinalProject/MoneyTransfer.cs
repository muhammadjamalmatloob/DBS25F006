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

namespace DBFinalProject
{
    public partial class MoneyTransfer : KryptonForm
    {
        public MoneyTransfer()
        {
            InitializeComponent();
            GrpSender.Visible = false;
            GrpVerify.Visible = false;
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            CashierDashboard cashierDashboard = new CashierDashboard();
            cashierDashboard.Show();
            this.Hide();
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            bool isVarified = true;
            if (isVarified)
            {
                GrpSender.Visible = true;
                GrpVerify.Visible = true;
            }
            else
            {
                MessageBox.Show("Please verify your account first.");
            }
            
        }
    }
}
