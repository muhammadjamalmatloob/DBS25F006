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
    public partial class ManagerDashboard : KryptonForm
    {
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            ViewBranchInfo viewBranchInfo = new ViewBranchInfo();
            viewBranchInfo.Show();
            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
