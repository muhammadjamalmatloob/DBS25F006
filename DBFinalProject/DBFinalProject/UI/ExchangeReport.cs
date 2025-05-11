using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Security.Cryptography.X509Certificates;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFinalProject.BL;

namespace DBFinalProject.Reports
{
    public partial class ExchangeReport : Form
    {

        public ExchangeReportBL ExchangeReportBL { get; set; }
        public ExchangeReport()
        {
            ExchangeReportBL = new ExchangeReportBL();

            InitializeComponent();

        }

        private void ExchangeReport_Load(object sender, EventArgs e)
        {

            this.exchangeReportBLBindingSource.DataSource = ExchangeReportBL;
            this.reportViewer1.RefreshReport();
        }
    }
}
