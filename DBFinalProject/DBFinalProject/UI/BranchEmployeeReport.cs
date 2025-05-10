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
using DBFinalProject.DL;

namespace DBFinalProject.UI
{
    public partial class BranchEmployeeReport : KryptonForm
    {
        public BranchEmployeeReport()
        {
            InitializeComponent();
        }

        private void BranchEmployeeReport_Load(object sender, EventArgs e)
        {
            EmployeesReportDL.AddIntoList();
            this.employeesReportBindingSource.DataSource = EmployeesReportDL.employees_rep;
            this.reportViewer1.RefreshReport();
        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
