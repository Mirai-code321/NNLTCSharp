using System;
using System.Windows.Forms;

namespace NangCao02_QuanLyDiem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmQuanLyDiem());
        }
    }
}