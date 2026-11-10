using System;
using System.Windows.Forms;

namespace VeNha03_DanhBa
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmDanhBa());
        }
    }
}