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
    }
}
