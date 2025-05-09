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
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class TransactionRecord : KryptonForm
    {
        ManagerDashboard manager;
        public TransactionRecord(ManagerDashboard manager)
        {
            InitializeComponent();
            GrpBox.Visible = false;
            this.manager = manager;
            kryptonManager1.GlobalPalette = Theme.theme;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = true;
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            manager.Show();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
