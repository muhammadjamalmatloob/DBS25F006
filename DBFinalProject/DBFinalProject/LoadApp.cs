using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.ReportingServices.Diagnostics.Internal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBFinalProject
{
    public partial class LoadApp : KryptonForm
    {
        public LoadApp()
        {
            InitializeComponent();
            Thread.Sleep(1000);
            //Task load = Loading();
        }

        private void AppLoad(object sender, EventArgs e)
        {
            

        }
        //private async Task Loading()
        //{
        //    label1.Location = new Point(55, label1.Location.Y);
        //    label1.Text = "Loading Features ...";
        //    Thread.Sleep(2000);
        //    label1.Location = new Point(84, label1.Location.Y);
        //    label1.Text = "Processing ...";
        //    Thread.Sleep(2000);
        //    label1.Location = new Point(32, label1.Location.Y);
        //    label1.Text = "Connecting to Server ...";
        //    Thread.Sleep(1000);
        //    label1.Location = new Point(32, label1.Location.Y);
        //    label1.Text = "Initializing ...";
        //    Thread.Sleep(2000);
        //    this.Hide();
        //    new MainInterface().Show();
        //}
    }
}
