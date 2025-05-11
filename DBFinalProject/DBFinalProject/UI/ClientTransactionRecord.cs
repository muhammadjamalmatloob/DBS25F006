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
    public partial class ClientTransactionRecord : UserControl
    {
        public ClientTransactionRecord()
        {
            InitializeComponent();
            string username = DL.LoginDL.user.getUsername();
            int user_id = DL.UserDL.get_user_id(username);
            int client_id = DL.ClientDL.getClientIdbyUserId(user_id);
            DL.TransactionRecordDL.getRecords(client_id);
            DL.TransactionRecordDL.LoadDataGrid(DL.TransactionRecordDL.transactionRecords, kryptonDataGridView1);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = true;
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            GrpBox.Visible =false;
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            GrpBox.Visible = false;
        }
    }
}
