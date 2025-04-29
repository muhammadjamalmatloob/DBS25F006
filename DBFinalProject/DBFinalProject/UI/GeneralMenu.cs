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
        public GeneralMenu()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {

        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
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
            clientDepositMoney1.Visible = true;
            sendMoney1.Visible = false;
            withdraw1.Visible = false;
            clientLoan1.Visible = false;
            clientCurrencyExchange1.Visible = false;
            clientBill1.Visible = false;
        }

        private void Closebtn_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            withdraw1.Visible = true;
            commonInterface1.Visible = false;
            clientDepositMoney1.Visible = false;
            sendMoney1.Visible = false;
            clientLoan1.Visible = false;
            clientCurrencyExchange1.Visible = false;
            clientBill1.Visible = false;
        }

        private void kryptonPalette1_PalettePaint(object sender, ComponentFactory.Krypton.Toolkit.PaletteLayoutEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            commonInterface1.Visible = true;
            clientDepositMoney1.Visible = false;
            sendMoney1.Visible = false;
            withdraw1.Visible = false;
            clientLoan1.Visible = false;
            clientCurrencyExchange1.Visible = false;
            clientBill1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sendMoney1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            sendMoney1.Visible = true;
            commonInterface1.Visible = false;
            clientDepositMoney1.Visible = false;
            withdraw1.Visible = false;
            clientLoan1.Visible = false;
            clientCurrencyExchange1.Visible = false;
            clientBill1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainInterface mi = new MainInterface();
            mi.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clientLoan1.Visible = true;
            sendMoney1.Visible = false;
            commonInterface1.Visible = false;
            clientDepositMoney1.Visible = false;
            withdraw1.Visible = false;
            clientCurrencyExchange1.Visible = false;
            clientBill1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            clientCurrencyExchange1.Visible = true;
            clientLoan1.Visible = false;
            sendMoney1.Visible = false;
            commonInterface1.Visible = false;
            clientDepositMoney1.Visible = false;
            withdraw1.Visible = false;
            clientBill1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clientBill1.Visible = true;
            clientCurrencyExchange1.Visible = false;
            clientLoan1.Visible = false;
            sendMoney1.Visible = false;
            commonInterface1.Visible = false;
            clientDepositMoney1.Visible = false;
            withdraw1.Visible = false;
        }
    }
}
