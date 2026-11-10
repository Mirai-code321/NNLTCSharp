using System;
using System.Windows.Forms;

namespace Bai02_MangMotChieu
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMangMotChieu());
        }
    }
}