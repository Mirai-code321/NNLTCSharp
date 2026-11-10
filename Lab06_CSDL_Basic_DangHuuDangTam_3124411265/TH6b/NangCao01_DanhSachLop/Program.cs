using System;
using System.Windows.Forms;

namespace NangCao01_DanhSachLop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmDanhSachLop());
        }
    }
}