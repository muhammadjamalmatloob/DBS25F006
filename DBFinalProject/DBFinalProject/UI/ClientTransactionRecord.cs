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
