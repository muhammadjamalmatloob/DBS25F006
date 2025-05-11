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
        private int timeLeft = 15;
        public LoadApp()
        {

            InitializeComponent();
              
        }

        private void AppLoad(object sender, EventArgs e)
        {
            timer1.Start();

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            if (timeLeft == 0)
            {
                this.Hide();
                new MainMenu().Show();
            }
        }
    }
}
