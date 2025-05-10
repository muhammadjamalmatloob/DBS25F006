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
using DBFinalProject.BL;
using DBFinalProject.DL;
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class ViewBranchInfo : KryptonForm
    {
        ManagerDashboard manager;
        private BranchBL managerBranch =  new BranchBL();
        public ViewBranchInfo(ManagerDashboard manager)
        {
            this.manager = manager;
            InitializeComponent();
            kryptonManager1.GlobalPalette = Theme.theme;
            
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void ViewBranch()
        {
            label16.Text = managerBranch.get_branch_name();
            label15.Text = managerBranch.get_branch_code().ToString();
            label14.Text = managerBranch.get_address();
            label13.Text = managerBranch.get_city();
        }

        private void ViewBranchLoad(object sender, EventArgs e)
        {
            try
            {
                
                managerBranch = BranchDL.GetManagerBranch();
                ViewBranch();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
