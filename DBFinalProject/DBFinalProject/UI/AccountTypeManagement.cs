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

namespace DBFinalProject.UI
{
    public partial class AccountTypeManagement : KryptonForm
    {
        public AccountTypeManagement()
        {
            InitializeComponent();
            AccountTypeDL.LoadAllDataInList();
            AccountTypeDL.LoadDataGrid(AccountTypeDL.accountTypes, dgvAccount);
            AccountTypeDL.LoadAccountTypeInComboBox(kryptonComboBox2);
            AccountTypeDL.LoadAccountTypeInComboBox(kryptonComboBox3);

            GrpAdd.Visible = false;
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpDelete.Visible = false;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
        }


        // add account type
        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            AccountTypeBL accountType = new AccountTypeBL();

            try
            {
                accountType.set_type_name(kryptonTextBox2.Text);
                accountType.set_descryprtion(kryptonTextBox5.Text);
                accountType.set_min_balance(Convert.ToInt32(kryptonTextBox3.Text));
                accountType.set_transaction_limit(Convert.ToInt32(kryptonTextBox7.Text));
                accountType.set_withdrawl_limit(Convert.ToInt32(kryptonTextBox6.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (AccountTypeDL.AddAccountTypeInDb(accountType))
            {
                AccountTypeDL.LoadAllDataInList();
                AccountTypeDL.LoadDataGrid(AccountTypeDL.accountTypes, dgvAccount);
                AccountTypeDL.LoadAccountTypeInComboBox(kryptonComboBox2);
                AccountTypeDL.LoadAccountTypeInComboBox(kryptonComboBox3);
                MessageBox.Show("Account Type Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to Add Account Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            GrpAdd.Visible = false;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            GrpAdd.Visible = true;
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpDelete.Visible = false;
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {
            GrpDelete.Visible = false;
        }

        private void kryptonButton12_Click(object sender, EventArgs e)
        {
            GrpUpdate.Visible = false;
        }

        private void kryptonButton13_Click(object sender, EventArgs e)
        {
            GrpAdd.Visible = false;
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            GrpAdd.Visible = false;
            GrpBox.Visible = false;
            GrpUpdate.Visible = true;
            GrpDelete.Visible = false;
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            GrpAdd.Visible = false;
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpDelete.Visible = true;
        }
        private void kryptonButton4_Click1(object sender, EventArgs e)
        {
            GrpAdd.Visible = false;
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpDelete.Visible = true;
        }

        private void kryptonButton14_Click(object sender, EventArgs e)
        {
            AdminDashboard admin = new AdminDashboard();
            admin.Show();
            this.Hide();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // update accout type 
        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            string selectedName = "";
            try
            {
                selectedName = kryptonComboBox3.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select Account Type first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            AccountTypeBL accountType = new AccountTypeBL();
            int account_type_id = AccountTypeDL.getIdByName(selectedName);

            

            try
            {
                accountType.set_type_name(selectedName);
                accountType.set_descryprtion(kryptonTextBox12.Text);
                accountType.set_min_balance(Convert.ToInt32(kryptonTextBox10.Text));
                accountType.set_transaction_limit(Convert.ToInt32(kryptonTextBox11.Text));
                accountType.set_withdrawl_limit(Convert.ToInt32(kryptonTextBox9.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (AccountTypeDL.UpdateAccountTypeInDb(accountType, account_type_id))
            {
                AccountTypeDL.LoadAllDataInList();
                AccountTypeDL.LoadDataGrid(AccountTypeDL.accountTypes, dgvAccount);
                AccountTypeDL.LoadAccountTypeInComboBox(kryptonComboBox2);
                AccountTypeDL.LoadAccountTypeInComboBox(kryptonComboBox3);
                MessageBox.Show("Account Type Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to Update Account Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            GrpUpdate.Visible = false;
        }


        // delete
        private void kryptonButton10_Click(object sender, EventArgs e)
        {

            string selectedName = "";
            try
            {
                selectedName = kryptonComboBox2.SelectedItem.ToString();
            }
            catch
            {
                MessageBox.Show("Select Account Type first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int account_type_id = AccountTypeDL.getIdByName(selectedName);
            if (AccountTypeDL.DeleteAccountTypeInDb(account_type_id))
            {
                AccountTypeDL.LoadAllDataInList();
                AccountTypeDL.LoadDataGrid(AccountTypeDL.accountTypes, dgvAccount);
                AccountTypeDL.LoadAccountTypeInComboBox(kryptonComboBox2);
                AccountTypeDL.LoadAccountTypeInComboBox(kryptonComboBox3);
                MessageBox.Show("Account Type Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to Delete Account Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            GrpDelete.Visible = false;
        }

        private void kryptonButton4_Clicked(object sender, EventArgs e)
        {
            GrpDelete.Visible = true;
            GrpAdd.Visible = false;
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpDelete.Visible = false;
            GrpAdd.Visible = false;
            GrpBox.Visible = true;
            GrpUpdate.Visible = false;
        }

        public void apply_filters()
        {

            dgvAccount.Rows.Clear();
            List<AccountTypeBL> accountTypes = AccountTypeDL.accountTypes;

            if (radioButton1.Checked && radioButton4.Checked)
            {
                 accountTypes = accountTypes.OrderBy(at => at.get_account_type_id()).ToList();
            }
            else if (radioButton1.Checked && radioButton2.Checked)
            {
                accountTypes = accountTypes.OrderByDescending(at => at.get_account_type_id()).ToList();
            }
            else if (radioButton3.Checked && radioButton4.Checked)
            {
                accountTypes = accountTypes.OrderBy(at => at.get_type_name()).ToList();
            }
            else if (radioButton3.Checked && radioButton2.Checked)
            {
                accountTypes = accountTypes.OrderByDescending(at => at.get_type_name()).ToList();
            }

            AccountTypeDL.LoadDataGrid(accountTypes, dgvAccount);
            GrpBox.Visible = false;
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            apply_filters();
            GrpBox.Visible = false;
        }

        private void myPallet_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }
    }
}
