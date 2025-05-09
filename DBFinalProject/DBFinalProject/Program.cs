using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DBFinalProject.UI;

namespace DBFinalProject
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            KryptonManager kryptonManager = new KryptonManager();
            kryptonManager.GlobalPaletteMode = PaletteModeManager.Custom;

            

            Application.Run(new ManagerDashboard());
        }
    }
}