using System;
using System.Windows.Forms;

namespace Bai01_SinhVienComboBox
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmSinhVienComboBox());
        }
    }
}