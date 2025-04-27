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
    public partial class ExchaangeCurr_Cashier : KryptonForm
    {
        public ExchaangeCurr_Cashier()
        {
            InitializeComponent();
        }

        private void kryptonComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox4_SelectedIndexChanged(object sender, EventArgs e)
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
