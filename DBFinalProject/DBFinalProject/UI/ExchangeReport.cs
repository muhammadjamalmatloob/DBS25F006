using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBFinalProject.BL;

namespace DBFinalProject.Reports
{
    public partial class ExchangeReport : Form
    {
        public ExchangeReport()
        {
            
            InitializeComponent();
            this.exchangeReportBLBindingSource.DataSource = new ExchangeReportBL(
                "Jamal Matloob",
                "0123456789",
                "100000",
                "5000",
                "Rupee",
                "Dollar");
        }

        private void ExchangeReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
