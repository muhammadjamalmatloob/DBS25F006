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
    public partial class ApproveApplicationscs : KryptonForm
    {
        public ApproveApplicationscs()
        {
            
            InitializeComponent();
            foreach (DataGridViewRow row in kryptonDataGridView1.Rows) 
            {
                row.Height = 50;
            }
            kryptonDataGridView1.Rows.Add(1, "Ali", "ali@gmail.com", "03214220667", "Pakistani", "35210-7889331-7", "Lahore, Pakistan", "Submitted");
            
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

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 && e.RowIndex >= 0) 
            {
                GrpDocs.Visible = true;
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpDocs.Visible = false;
        }

        private void ApproveApplicationscs_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.RefreshReport();
        }
    }
}
