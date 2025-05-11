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
using static System.Net.Mime.MediaTypeNames;

namespace DBFinalProject
{
    public partial class ApplicationForm2 : KryptonForm
    {
        ApplicationForm form;
        ApplicationForm03 form3;
        public ApplicationForm2(ApplicationForm form)
        {
            InitializeComponent();
            this.form = form;
            AccountApplicationDL.GetAccountTypes();
            AccountApplicationDL.GetBranches();
            AccountApplicationDL.LoadBranchesComboBox(kryptonComboBox1);
            AccountApplicationDL.LoadAccountTypeComboBox(kryptonComboBox2);

        }

        private void kryptonComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Show();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string branch = kryptonComboBox1.Text;
            string accountType = kryptonComboBox2.Text;
            if (kryptonComboBox1.SelectedIndex == 0 ||
                kryptonComboBox2.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            if (!ApplicationForm.application.SetBranch(branch).valid)
            {
                MessageBox.Show(ApplicationForm.application.SetBranch(branch).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            if (!ApplicationForm.application.SetAccountType(accountType).valid)
            {
                MessageBox.Show(ApplicationForm.application.SetAccountType(accountType).message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Hide();
            if (form3 == null)
            {
                form3 = new ApplicationForm03(this);
            }
            form3.Show();
        }
    }
}
