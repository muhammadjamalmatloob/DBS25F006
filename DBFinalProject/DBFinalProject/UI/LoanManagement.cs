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
    public partial class LoanManagement : KryptonForm
    {
        public LoanManagement()
        {
            InitializeComponent();
            GrpBox.Visible = false;
            GrpDelete.Visible = false;
            GrpAdd.Visible = false;
            GrpUpdate.Visible = false;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
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

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = true;
            GrpDelete.Visible = false;
            GrpAdd.Visible = false;
            GrpUpdate.Visible = false;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
            GrpDelete.Visible = false;
            GrpAdd.Visible = true;
            GrpUpdate.Visible = false;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
            GrpDelete.Visible = false;
            GrpAdd.Visible = false;
            GrpUpdate.Visible = true;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
            GrpDelete.Visible = true;
            GrpAdd.Visible = false;
            GrpUpdate.Visible = false;
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
        }

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            GrpAdd.Visible = false;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            GrpUpdate.Visible = false;
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            GrpDelete.Visible = false;
        }
    }
}
