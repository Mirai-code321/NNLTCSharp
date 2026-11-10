using System;
using System.Windows.Forms;

namespace VeNha01_QuanLyCuaHang
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
        }
    }
}