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
using DBFinalProject.BL;

namespace DBFinalProject.UI
{
    public partial class PaymentReciept : Form
    {

        public PaymentInvoiceBL paymentInvoiceBL { get; set; }
        public PaymentReciept()
        {
            InitializeComponent();
            paymentInvoiceBL = new PaymentInvoiceBL();
            List<PaymentInvoiceBL> invoice = new List<PaymentInvoiceBL>();
            
            //this.paymentInvoiceBLBindingSource.DataSource = new PaymentInvoiceBL("Rumman Ahmad",
            //    "Dollar",
            //    "Bill Payment",
            //    1000);
        }

        private void PaymentReciept_Load(object sender, EventArgs e)
        {
            this.paymentInvoiceBLBindingSource.DataSource = paymentInvoiceBL;
            this.reportViewer1.RefreshReport();

            //this.reportViewer1.RefreshReport();
        }
    }
}
