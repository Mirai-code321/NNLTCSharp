using System;
using System.Windows.Forms;

namespace Bai01_UocSo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Mở form bài tập ước số.
            Application.Run(new frmUocSo());
        }
    }
}