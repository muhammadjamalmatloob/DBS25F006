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
using DBFinalProject.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            if (checkBox1.Checked == true || pass.Text == "Enter Password")
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


            string username = user_name.Text.Trim();
            string password = pass.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            try
            {

                if (LoginDL.LoadData(username, password))
                {

                    string role = LoginDL.user.getRole();


                    switch (role)
                    {
                        case "Admin":
                            MessageBox.Show("Login successful! Admin Dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AdminDashboard adminDashboard = new AdminDashboard();
                            adminDashboard.Show();
                            this.Hide();
                            break;
                        case "Employee":
                            string position = LoginDL.GetPosition(username);
                            switch (position)
                            {
                                case "Cashier":
                                    MessageBox.Show("Login successful! Opening Manager Dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CashierDashboard cashierDashboard = new CashierDashboard();
                                    cashierDashboard.Show();
                                    this.Hide();
                                    break;
                                case "Manager":
                                    MessageBox.Show("Login successful! Opening Cashier Dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ManagerDashboard managerDashboard = new ManagerDashboard();
                                    managerDashboard.Show();
                                    this.Hide();
                                    break;
                            }
                            break;
                        case "Client":
                            MessageBox.Show("Login successful! Opening Administrative Staff Dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClientManagement clientManagement = new ClientManagement();
                            clientManagement.Show();
                            this.Hide();
                            break;
                        default:
                            MessageBox.Show("Invalid role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pass.PasswordChar = '•';
        }

        private void forgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new ResetPassword().Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new SignUpORApply().Show();
        }

        private void pass_Focus(object sender, EventArgs e)
        {
            if (pass.Text == "Enter Password")
            {
                pass.Text = "";
                pass.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }

        private void user_name_Focus(object sender, EventArgs e)
        {
            if (user_name.Text == "Enter Username")
            {
                user_name.Text = "";
                user_name.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }
        private void pass_LostFocus(object sender, EventArgs e)
        {
            if (pass.Text == "")
            {
                pass.Text = "Enter Password";
                pass.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
                pass.PasswordChar = '\0';
            }

        }

        private void user_name_LostFocus(object sender, EventArgs e)
        {
            if (user_name.Text == "")
            {
                user_name.Text = "Enter Username";
                user_name.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
                user_name.PasswordChar = '\0';
            }

        }
    }
}
