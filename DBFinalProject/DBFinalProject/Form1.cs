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
    public partial class MainInterface : KryptonForm
    {
        public KryptonPalette kryptonPalette1;

        public MainInterface()
        {
            InitializeComponent();
            KryptonManager kryptonManager = new KryptonManager();
            this.kryptonManager1.GlobalPalette = myPallet;
            this.kryptonManager1.GlobalPaletteMode = PaletteModeManager.Custom;

        }

        private void login_Click(object sender, EventArgs e)
        {

        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void MainInterface_Load(object sender, EventArgs e)
        {
            KryptonManager kryptonManager = new KryptonManager();
            this.kryptonManager1.GlobalPalette = myPallet;
            this.kryptonManager1.GlobalPaletteMode = PaletteModeManager.Custom;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                pass.PasswordChar = '\0';
            }
            else
            {
                pass.PasswordChar = '•';
            }
        }

        private void pass_Click(object sender, EventArgs e)
        {
            pass.Text = "";
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            //ClientManagement clientManagement = new ClientManagement();
            //clientManagement.Show();
            //this.Hide();

            //AdminDashboard adminDashboard = new AdminDashboard();
            //adminDashboard.Show();
            //this.Hide();

            ManagerDashboard managerDashboard = new ManagerDashboard();
            managerDashboard.Show();
            this.Hide();
        }
    }
}
