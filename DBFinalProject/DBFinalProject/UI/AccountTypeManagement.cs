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

namespace DBFinalProject.UI
{
    public partial class AccountTypeManagement : KryptonForm
    {
        AdminDashboard admin;
        public AccountTypeManagement(AdminDashboard admin)
        {
            InitializeComponent();
            AccountTypeDL.LoadAllDataInList();
            AccountTypeDL.LoadDataGrid(AccountTypeDL.accountTypes, dgvAccount);
            AccountTypeDL.LoadAccountTypeInComboBox(kryptonComboBox2);
            AccountTypeDL.LoadAccountTypeInComboBox(kryptonComboBox3);
            kryptonComboBox3.SelectedIndex = 0;
            kryptonComboBox2.SelectedIndex = 0;

            GrpAdd.Visible = false;
            GrpBox.Visible = false;
            GrpUpdate.Visible = false;
            GrpDelete.Visible = false;
            radioButton1.Checked = true;
            radioButton4.Checked = true;
            this.admin = admin;
            this.kryptonManager1.GlobalPalette = Theme.theme;
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
            this.Hide();
            admin.Show();
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

            try
            {
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
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Failed to Delete Account Type ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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

        private void kryptonTextBox12_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox12.Text == "Descryption")
            {
                kryptonTextBox12.Text = "";
                kryptonTextBox12.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void kryptonTextBox12_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox12.Text == "")
            {
                kryptonTextBox12.Text = "Descryption";
                kryptonTextBox12.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox10_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox10.Text == "Minimum Balance")
            {
                kryptonTextBox10.Text = "";
                kryptonTextBox10.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox10_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox10.Text == "")
            {
                kryptonTextBox10.Text = "Minimum Balance";
                kryptonTextBox10.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox11_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox11.Text == "Transaction Limit")
            {
                kryptonTextBox11.Text = "";
                kryptonTextBox11.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox11_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox11.Text == "")
            {
                kryptonTextBox11.Text = "Transaction Limit";
                kryptonTextBox11.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox6_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox6.Text == "Withdrawl Limit")
            {
                kryptonTextBox6.Text = "";
                kryptonTextBox6.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox6_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox6.Text == "")
            {
                kryptonTextBox6.Text = "Withdrawl Limit";
                kryptonTextBox6.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "Type Name")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Type Name";
                kryptonTextBox2.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox7_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox7.Text == "Transaction Limit")
            {
                kryptonTextBox7.Text = "";
                kryptonTextBox7.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox7_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox7.Text == "")
            {
                kryptonTextBox7.Text = "Transaction Limit";
                kryptonTextBox7.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox3_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "Minimum Balance")
            {
                kryptonTextBox3.Text = "";
                kryptonTextBox3.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox3_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox3.Text == "")
            {
                kryptonTextBox3.Text = "Minimum Balance";
                kryptonTextBox3.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox5_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox5.Text == "Descryption")
            {
                kryptonTextBox5.Text = "";
                kryptonTextBox5.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox5_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox5.Text == "")
            {
                kryptonTextBox5.Text = "Descryption";
                kryptonTextBox5.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox9_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox9.Text == "Withdrawl Limit")
            {
                kryptonTextBox9.Text = "";
                kryptonTextBox9.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox9_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox9.Text == "")
            {
                kryptonTextBox9.Text = "Withdrawl Limit";
                kryptonTextBox9.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            
            if (kryptonButton1.Text.Trim() == "Search Account Type")
            {
                kryptonTextBox1.Text = "";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Search Account Type";
                kryptonTextBox1.StateCommon.Content.Color1 = Color.Gray;
            }
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            string search = kryptonTextBox1.Text.Trim();

            if (string.IsNullOrEmpty(search) || search == "Search Account Type")
            {
                return;
            }

            var filteredList = AccountTypeDL.accountTypes.Where(a => a.get_type_name().ToLower().Contains(search)).ToList();
            AccountTypeDL.LoadDataGrid(filteredList, dgvAccount);
        }

        private void clear_grp()
        {
            kryptonTextBox9.Text = "Withdrawl Limit";
            kryptonTextBox5.Text = "Descryption";
            kryptonTextBox3.Text = "Minimum Balance";
            kryptonTextBox2.Text = "Type Name";

            kryptonTextBox10.Text = "Minimum Balance";
            kryptonTextBox12.Text = "Descryption";
            kryptonTextBox10.Text = "Minimum Balance";

            kryptonComboBox3.SelectedIndex = 0;
            kryptonComboBox2.SelectedIndex = 0;
        }
    }
}
