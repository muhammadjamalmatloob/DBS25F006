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

namespace DBFinalProject.UI
{
    public partial class WithdrawReport : Form
    {
        public WithdrawReport()
        {
            InitializeComponent();
            this.withdrawReportBLBindingSource.DataSource = new WithdrawReportBL(
                "Umar Javed",
                "1234567890",
                "20000",
                "Rupee");
        }

        private void WithdrawReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
