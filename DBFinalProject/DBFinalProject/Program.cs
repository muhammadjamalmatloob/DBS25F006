using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

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
<<<<<<< HEAD

            KryptonManager kryptonManager = new KryptonManager();
            kryptonManager.GlobalPaletteMode = PaletteModeManager.Custom;

            //MainInterface mainForm = new MainInterface();
            //kryptonManager.GlobalPalette = mainForm.myPallet;

=======
>>>>>>> 0ece54309b7b6eb9b2dd69cae107a702401643c3
            Application.Run(new GeneralMenu());
        }
    }
}
