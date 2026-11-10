using System;
using System.Windows.Forms;

namespace VeNha01_TuDien
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmTuDien());
        }
    }
}