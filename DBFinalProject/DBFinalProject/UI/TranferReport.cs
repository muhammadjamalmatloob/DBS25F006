﻿using System;
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
    public partial class TranferReport : Form
    {
        public TransferReportBL transferReportBL { get; set; }
        public TranferReport()
        {

            InitializeComponent();
            transferReportBL = new TransferReportBL();
            //this.transferReportBLBindingSource.DataSource = new TransferReportBL(
            //    "Jamal Matloob",
            //    "1234567890",
            //    "0987654321",
            //    "120000",
            //    "Riyal");
        }

        private void TranferReport_Load(object sender, EventArgs e)
        {
            this.transferReportBLBindingSource.DataSource = transferReportBL;
            this.reportViewer1.RefreshReport();
        }
    }
}
