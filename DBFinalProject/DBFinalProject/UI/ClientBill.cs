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
    public partial class ClientBill : UserControl
    {
        public ClientBill()
        {
            InitializeComponent();
        }

        private void kryptonComboBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonComboBox1.Text == "Select Payment Type")
            {
                kryptonComboBox1.Text = "";
            }
        }

        private void kryptonComboBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text == "")
            {
                kryptonComboBox1.Text = "Select Payment Type";
            }
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox1.Text == "Amount")
            {
                kryptonTextBox1.Text = "";
            }
        }

        private void kryptonTextBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "")
            {
                kryptonTextBox1.Text = "Amount";
            }
        }

        private void kryptonComboBox2_Enter(object sender, EventArgs e)
        {
            if(kryptonComboBox2.Text == "Select Method")
            {
                kryptonComboBox2.Text = "";
            }
        }

        private void kryptonComboBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox2.Text == "")
            {
                kryptonComboBox2.Text = "Select Method";
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox2.Text == "PIN")
            {
                kryptonTextBox2.Text = "";
                kryptonTextBox2.PasswordChar = '*';
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "PIN";
                kryptonTextBox2.PasswordChar = '\0';
            }
        }
    }
}
