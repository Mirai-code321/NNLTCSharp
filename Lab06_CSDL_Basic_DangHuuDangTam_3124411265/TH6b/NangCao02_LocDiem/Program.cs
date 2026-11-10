using System;
using System.Windows.Forms;

namespace NangCao02_LocDiem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmLocDiem());
        }
    }
}