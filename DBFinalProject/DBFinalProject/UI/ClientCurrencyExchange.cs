using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Org.BouncyCastle.Asn1.X509;

namespace DBFinalProject.UI
{
    public partial class ClientCurrencyExchange : UserControl
    {
        public ClientCurrencyExchange()
        {
            InitializeComponent();
        }

        private void kryptonComboBox3_Enter(object sender, EventArgs e)
        {
            if(kryptonComboBox3.Text == "Base Currency")
            {
                kryptonComboBox3.Text = "";
            }
        }

        private void kryptonComboBox3_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox3.Text == "")
            {
                kryptonComboBox3.Text = "Base Currency";
            }
        }

        private void kryptonComboBox4_Enter(object sender, EventArgs e)
        {
            if (kryptonComboBox4.Text == "Target Currency")
            {
                kryptonComboBox4.Text = "";
            }
        }

        private void kryptonComboBox4_Leave(object sender, EventArgs e)
        {
            if (kryptonComboBox4.Text == "")
            {
                kryptonComboBox4.Text = "Target Currency";
            }
        }

        private void kryptonTextBox1_Enter(object sender, EventArgs e)
        {
            if (kryptonTextBox1.Text == "Amount")
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
    }
}
