using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBFinalProject
{
    public partial class SendMoney : UserControl
    {
        bool isVerified=false;
        public SendMoney()
        {
            InitializeComponent();
            GrpSender.Visible = false;
            GrpVerify.Visible = false;
        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            isVerified = true;
            if (isVerified)
            {
                GrpSender.Visible = true;
                GrpVerify.Visible = true;
            }
            else
            {
                MessageBox.Show("Please verify your account first.");
            }
        }

        private void SendMoney_Load(object sender, EventArgs e)
        {
            isVerified = false;
            GrpSender.Visible = false;
            GrpVerify.Visible = false;
        }
    }
}
