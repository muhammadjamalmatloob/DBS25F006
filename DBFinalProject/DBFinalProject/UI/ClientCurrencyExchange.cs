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
    public partial class ClientCurrencyExchange : UserControl
    {
        public ClientCurrencyExchange()
        {
            InitializeComponent();
        }

        private void kryptonComboBox2_Enter(object sender, EventArgs e)
        {
            if(kryptonComboBox2.Text == "Select Base Currency")
            {
                kryptonComboBox2.Text = "";
            }
        }

        private void kryptonComboBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox2.Text == "")
            {
                kryptonComboBox2.Text = "Select Base Currency";
            }
        }

        private void kryptonComboBox1_Enter(object sender, EventArgs e)
        {
            if(kryptonComboBox1.Text == "Select Target Currency")
            {
                kryptonComboBox1.Text = "";
            }
        }

        private void kryptonComboBox1_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox1.Text == "")
            {
                kryptonComboBox1.Text = "Select Target Currency";
            }
        }

        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {
            if(kryptonTextBox2.Text == "Amount")
            {
                kryptonTextBox2.Text = "";
            }
        }

        private void kryptonTextBox2_Leave(object sender, EventArgs e)
        {
            if (kryptonTextBox2.Text == "")
            {
                kryptonTextBox2.Text = "Amount";
            }
        }
    }
}
