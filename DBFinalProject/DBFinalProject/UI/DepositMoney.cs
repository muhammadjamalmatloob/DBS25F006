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
    public partial class DepositMoney : KryptonForm
    {
        public DepositMoney()
        {
            InitializeComponent();
        }

        private void DepositMoney_Load(object sender, EventArgs e)
        {

        }

        private void GrpRecieve_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            CashierDashboard cashierDashboard = new CashierDashboard();
            cashierDashboard.Show();
            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
