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
    public partial class DepositeReport : Form
    {
        public DepositeReport()
        {
            InitializeComponent();
            this.depositeReportBLBindingSource.DataSource = new DepositeReportBL(
                "Umer",
                "123456789",
                "100000",
                "Euro");
        }

        private void DepositeReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
