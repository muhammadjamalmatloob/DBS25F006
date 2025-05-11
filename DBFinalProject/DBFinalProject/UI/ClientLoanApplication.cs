using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFinalProject.UI
{
    public partial class ClientLoanApplication : UserControl
    {
        public ClientLoanApplication()
        {
            InitializeComponent();
            string username = DL.LoginDL.user.getUsername();
            int user_id = DL.UserDL.get_user_id(username);
            int client_id = DL.ClientDL.getClientIdbyUserId(user_id);
            DL.ClientLoanApplicationDL.getApplications(client_id);
            DL.ClientLoanApplicationDL.LoadDataGrid(DL.ClientLoanApplicationDL.applications, kryptonDataGridView1);
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
        }
    }
}
