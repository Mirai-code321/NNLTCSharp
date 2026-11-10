using System.Text;

namespace Bai11_DaoChuoi
{
    internal class Program
    {
        // Bat nhap lai cho toi khi co chuoi hop le (khong rong, khong toan khoang trang)
        static string NhapChuoi()
        {
            while (true)
            {
                Console.Write("Nhap chuoi can dao: ");
                string? nhap = Console.ReadLine();   // string? vi ReadLine co the tra ve null

                if (!string.IsNullOrWhiteSpace(nhap))
                    return nhap;

                Console.WriteLine("Chuoi khong duoc de trong, moi nhap lai!");
            }
        }

        static void Main(string[] args)
        {
            // dat UTF-8 de nhap/xuat duoc chuoi co dau tieng Viet, khong bi loi font
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            string chuoi = NhapChuoi();

            // DaoChuoi la instance method nen phai new doi tuong moi goi duoc
            XuLyChuoi xuLy = new XuLyChuoi();
            string chuoiDao = xuLy.DaoChuoi(chuoi);

            Console.WriteLine("Chuoi ban dau  : " + chuoi);
            Console.WriteLine("Chuoi dao nguoc: " + chuoiDao);
        }
    }
}