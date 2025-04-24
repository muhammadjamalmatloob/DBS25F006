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
    public partial class CashierDashboard : KryptonForm
    {
        public CashierDashboard()
        {
            InitializeComponent();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            MoneyTransfer moneyTransfer = new MoneyTransfer();
            moneyTransfer.Show();
            this.Hide();
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            DepositMoney depositMoney = new DepositMoney();
            depositMoney.Show();
            this.Hide();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            PayBill payBill = new PayBill();
            payBill.Show();
            this.Hide();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            ExchaangeCurr_Cashier exchangeCurr_Cashier = new ExchaangeCurr_Cashier();
            exchangeCurr_Cashier.Show();
            this.Hide();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            ApplyLoan applyLoan = new ApplyLoan();
            applyLoan.Show();
            this.Hide();
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            MainInterface mainInterface = new MainInterface();
            mainInterface.Show();
            this.Hide();
        }
    }
}
