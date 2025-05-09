using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;

namespace DBFinalProject.Utility
{
    public class Theme
    {
        public static KryptonPalette theme = new KryptonPalette();
        public Theme(KryptonPalette theme) 
        {
            Theme.theme = theme;
        }

        public void SetPallete(KryptonPalette palette)
        {
            theme = palette;
        }
    }
}
