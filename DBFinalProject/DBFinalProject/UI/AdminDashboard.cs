using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.UI;
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class AdminDashboard : KryptonForm
    {
        public AdminDashboard()
        {
            InitializeComponent();
            if (Theme.theme == myPallet || Theme.theme == GreenTheme || Theme.theme == PurpleTheme)
            {

                kryptonManager1.GlobalPalette = Theme.theme;
            }
            else
            {
                Theme.theme = myPallet;
                kryptonManager1.GlobalPalette = Theme.theme;
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BranchManagement branchManagement = new BranchManagement(this);
            branchManagement.Show();

        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeManagement employeeManagement = new EmployeeManagement(this);
            employeeManagement.Show();

        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountTypeManagement accountType = new AccountTypeManagement(this);
            accountType.Show();

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientManagement clientManagement = new ClientManagement(this);
            clientManagement.Show();

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoanManagement loanManagement = new LoanManagement(this);
            loanManagement.Show();

        }

        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            ThemeMenu.Visible = true;
        }

        private void Blue_CheckedChanged(object sender, EventArgs e)
        {
            if (Blue.Checked)
            {
                kryptonManager1.GlobalPalette = this.myPallet;
            }
        }

        private void Purple_CheckedChanged(object sender, EventArgs e)
        {
            if (Purple.Checked)
            {
                kryptonManager1.GlobalPalette = this.PurpleTheme;
            }
        }

        private void Green_CheckedChanged(object sender, EventArgs e)
        {
            if (Green.Checked)
            {
                kryptonManager1.GlobalPalette = this.GreenTheme;
            }
        }

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            if (Blue.Checked)
            {
                kryptonManager1.GlobalPalette = this.myPallet;
                Theme.theme = myPallet;
            }
            else if (Purple.Checked)
            {
                kryptonManager1.GlobalPalette = this.PurpleTheme;
                Theme.theme = PurpleTheme;
            }
            else if (Green.Checked)
            {
                kryptonManager1.GlobalPalette = this.GreenTheme;
                Theme.theme = GreenTheme;
            }
            MessageBox.Show("Theme applied successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ThemeMenu.Visible = false;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            kryptonManager1.GlobalPalette = Theme.theme;
            ThemeMenu.Visible = false;
        }

        private void kryptonPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MainInterface().Show();
        }
    }
}
