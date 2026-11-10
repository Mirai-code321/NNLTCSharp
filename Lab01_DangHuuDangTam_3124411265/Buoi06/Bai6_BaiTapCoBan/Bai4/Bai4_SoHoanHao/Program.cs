using System;
using KiemTraSoHoanHao;

class Program
{
    static void Main(string[] args)
    {
        // Nhập số tự nhiên n
        Console.Write("Moi ban nhap n: ");
        int n = int.Parse(Console.ReadLine()!);

        // Tạo đối tượng kiểm tra số hoàn hảo
        SoHoanHao soHoanHao = new SoHoanHao();

        // Kiểm tra n có phải số hoàn hảo không
        bool ketQua = soHoanHao.KiemTra(n);

        if (ketQua)
        {
            // Lấy danh sách các ước không kể chính nó
            string danhSachUoc = soHoanHao.LayDanhSachUoc(n);

            // In đúng định dạng của đề
            // Ví dụ:
            // 6 = 1 + 2 + 3 la so hoan hao.
            Console.WriteLine(
                $"{n} = {danhSachUoc} la so hoan hao."
            );
        }
        else
        {
            // Nếu không phải số hoàn hảo
            Console.WriteLine(
                $"{n} khong la so hoan hao."
            );
        }
    }
}