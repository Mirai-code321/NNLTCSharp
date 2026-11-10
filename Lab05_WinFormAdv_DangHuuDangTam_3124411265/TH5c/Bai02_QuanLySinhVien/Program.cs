using System;
using System.Windows.Forms;

namespace Bai02_QuanLySinhVien
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmQuanLySinhVien());
        }
    }
}