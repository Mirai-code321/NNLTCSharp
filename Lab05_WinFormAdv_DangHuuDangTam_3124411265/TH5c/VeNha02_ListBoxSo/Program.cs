using System;
using System.Windows.Forms;

namespace VeNha02_ListBoxSo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmListBoxSo());
        }
    }
}