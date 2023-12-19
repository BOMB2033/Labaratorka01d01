using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Labaratorka01d01.AppData
{
    internal class Nav
    {
        public static Frame MainFrame;
        public static void GoBack()
        {
            MainFrame.GoBack();
        }
    }
}
