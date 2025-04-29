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
    public partial class ResetPassword01 : KryptonForm
    {
        public ResetPassword01()
        {
            InitializeComponent();
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                pass.PasswordChar = '\0';
            }
            else
            {
                pass.PasswordChar = '•';
            }
        }

        private void pass_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                pass.PasswordChar = '\0';
            }
            else
            {
                pass.PasswordChar = '•';
            }
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
