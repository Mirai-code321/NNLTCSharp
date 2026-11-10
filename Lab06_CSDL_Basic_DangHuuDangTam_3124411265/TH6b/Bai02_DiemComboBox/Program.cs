using System;
using System.Windows.Forms;

namespace Bai02_DiemComboBox
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmDiemComboBox());
        }
    }
}