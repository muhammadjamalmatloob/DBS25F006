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
    public partial class AllEmployeesReport : KryptonForm
    {
        public AllEmployeesReport()
        {
            InitializeComponent();
            EmployeesReportDL.AddAllIntoList();
            this.allEmployeeRepBLBindingSource.DataSource = EmployeesReportDL.all_employees;
        }

        private void AllEmployeesReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
