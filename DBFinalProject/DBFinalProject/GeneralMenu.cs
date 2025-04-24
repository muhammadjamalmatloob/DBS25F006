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
    public partial class GeneralMenu : KryptonForm
    {
        bool sidebarExpand;
        public GeneralMenu()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                sidebar.Width -= 10;
                if(sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if(sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }

            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Closebtn_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            commonInterface1.Visible = false;
            depositMoney1.Visible = true;
            purchase1.Visible = false;
            sendMoney1.Visible = false;
            currencyExchange1.Visible = false;
            applyLoan1.Visible = false;
            withdrawMoney1.Visible = false;
        }

        private void Closebtn_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            withdrawMoney1.Visible = true;
            commonInterface1.Visible = false;
            depositMoney1.Visible = false;
            purchase1.Visible = false;
            sendMoney1.Visible = false;
            currencyExchange1.Visible = false;
            applyLoan1.Visible = false;
        }

        private void kryptonPalette1_PalettePaint(object sender, ComponentFactory.Krypton.Toolkit.PaletteLayoutEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            commonInterface1.Visible = true;
            depositMoney1.Visible = false;
            purchase1.Visible = false;
            sendMoney1.Visible = false;
            applyLoan1.Visible = false;
            currencyExchange1.Visible = false;
            withdrawMoney1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            purchase1.Visible = true;
            commonInterface1.Visible = false;
            depositMoney1.Visible = false;
            sendMoney1.Visible = false;
            applyLoan1.Visible = false;
            currencyExchange1.Visible = false;
            withdrawMoney1.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sendMoney1.Visible = true;
            purchase1.Visible = false;
            commonInterface1.Visible = false;
            depositMoney1.Visible = false;
            applyLoan1.Visible = false;
            currencyExchange1.Visible = false;
            withdrawMoney1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            applyLoan1.Visible = true;
            sendMoney1.Visible = false;
            purchase1.Visible = false;
            commonInterface1.Visible = false;
            depositMoney1.Visible = false;
            currencyExchange1.Visible = false;
            withdrawMoney1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            currencyExchange1.Visible = true;
            applyLoan1.Visible = false;
            sendMoney1.Visible = false;
            purchase1.Visible = false;
            commonInterface1.Visible = false;
            depositMoney1.Visible = false;
            withdrawMoney1.Visible = false;
        }
    }
}
