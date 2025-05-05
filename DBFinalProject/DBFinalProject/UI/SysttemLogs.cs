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
using DBFinalProject.DL;

namespace DBFinalProject.UI
{
    public partial class SysttemLogs : KryptonForm
    {
        public SysttemLogs()
        {
            InitializeComponent();
            SystemLogsDL.LoadDataGrid(dgvSystem);
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
