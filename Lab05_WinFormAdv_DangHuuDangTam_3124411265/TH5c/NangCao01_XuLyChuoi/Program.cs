using System;
using System.Windows.Forms;

namespace NangCao01_XuLyChuoi
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmXuLyChuoi());
        }
    }
}