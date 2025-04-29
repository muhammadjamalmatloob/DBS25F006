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
    public partial class BranchEmployees : KryptonForm
    {
        public BranchEmployees()
        {
            InitializeComponent();
            GrpNme.Visible = false;
            grptype.Visible = false;
            GrpBox.Visible = false;
            GrpDep.Visible = false;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            ManagerDashboard managerDashboard = new ManagerDashboard();
            managerDashboard.Show();
            this.Hide();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            GrpNme.Visible = true;
            grptype.Visible = false;
            GrpBox.Visible = false;
            GrpDep.Visible = false;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpNme.Visible = false;
            grptype.Visible = false;
            GrpBox.Visible = true;
            GrpDep.Visible = false;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            GrpNme.Visible = false;
            grptype.Visible = false;
            GrpBox.Visible = false;
            GrpDep.Visible = true;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            GrpNme.Visible = false;
            grptype.Visible = true;
            GrpBox.Visible = false;
            GrpDep.Visible = false;
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            GrpNme.Visible = false;
        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            grptype.Visible = false;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            GrpDep.Visible = false;
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
