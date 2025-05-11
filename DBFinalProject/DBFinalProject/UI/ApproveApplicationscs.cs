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
using DBFinalProject.Utility;

namespace DBFinalProject
{
    public partial class ApproveApplicationscs : KryptonForm
    {
        ManagerDashboard manager;
        public ApproveApplicationscs(ManagerDashboard manager)
        {
            
            InitializeComponent();
            this.manager = manager;
            this.kryptonManager1.GlobalPalette = Theme.theme;
            AccountApplicationDL.LoadAllApplicationsInList();
            AccountApplicationDL.LoadBranchTransactionsToGrid(kryptonDataGridView1);
            
            
            
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

        private async void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                try
                {
                    if (AccountApplicationDL.Reject(e.RowIndex))
                    {
                        Task <bool> result = EmailSender.SendEmailAsync(AccountApplicationDL.profiles[e.RowIndex].GetEmail(),
                            "Apex BankAccount Application",
                            "Your application for account to Apex Bank is rejected");
                        if (!await result)
                        {
                            MessageBox.Show("Cant Send Email", "Error");
                        }
                        AccountApplicationDL.LoadAllApplicationsInList();
                        AccountApplicationDL.LoadBranchTransactionsToGrid(kryptonDataGridView1);
                        MessageBox.Show("Application rejected successfully", "Error");
                        
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                try
                {
                    if (AccountApplicationDL.Accept(e.RowIndex))
                    {
                        AccountApplicationDL.AddClient(e.RowIndex);
                        AccountApplicationDL.AddAccount(e.RowIndex);
                        Task<bool> result = EmailSender.SendEmailAsync(AccountApplicationDL.profiles[e.RowIndex].GetEmail(),
                            "Apex BankAccount Application",
                            "Your application for account to Apex Bank is accepted");
                        if (!await result)
                        {
                            MessageBox.Show("Cant Send Email", "Error");
                        }
                        AccountApplicationDL.LoadAllApplicationsInList();
                        AccountApplicationDL.LoadBranchTransactionsToGrid(kryptonDataGridView1);
                        MessageBox.Show("Application accepted successfully", "Information");
                        

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void kryptonTextBox1_Focus(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Search")
            {
                kryptonTextBox1.Text = "";
                kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            }

        }

        private void kryptonTextBox1_LostFocus(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Search";
                kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            }

        }
    }
}
