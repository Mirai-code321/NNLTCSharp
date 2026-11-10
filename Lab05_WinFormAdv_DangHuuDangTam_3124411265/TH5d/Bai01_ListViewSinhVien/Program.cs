using System;
using System.Windows.Forms;

namespace Bai01_ListViewSinhVien
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmListViewSinhVien());
        }
    }
}