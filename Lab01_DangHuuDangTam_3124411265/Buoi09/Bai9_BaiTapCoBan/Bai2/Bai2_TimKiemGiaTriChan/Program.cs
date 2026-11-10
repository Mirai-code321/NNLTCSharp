using System;

namespace Bai2_TimKiemGiaTriChan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TimKiemGiaTriChan xuLy = new TimKiemGiaTriChan();

            // Buoc 1: nhap so luong phan tu cua mang
            Console.Write("Moi ban nhap so luong phan tu: ");
            int n = int.Parse(Console.ReadLine()!);

            // Buoc 2: kiem tra dieu kien n (0 < n <= 500) theo de bai
            if (!xuLy.KiemTraSoPhanTuHopLe(n))
            {
                Console.WriteLine("So luong phan tu khong hop le (yeu cau 0 < n <= 500).");
                return;
            }

            // Buoc 3: nhap gia tri cho tung phan tu cua mang
            int[] mang = xuLy.NhapMang(n);

            // Buoc 4: tim chi so cua gia tri chan dau tien va cuoi cung
            int viTriDauTien = xuLy.TimChiSoChanDauTien(mang);
            int viTriCuoiCung = xuLy.TimChiSoChanCuoiCung(mang);

            // Buoc 5: in ket qua ra man hinh
            if (viTriDauTien == TimKiemGiaTriChan.KHONG_TIM_THAY)
            {
                Console.WriteLine("Day so khong co gia tri chan nao.");
            }
            else
            {
                Console.WriteLine($"Gia tri chan dau tien o vi tri {viTriDauTien} co gia tri {mang[viTriDauTien]}.");
                Console.WriteLine($"Gia tri chan cuoi cung o vi tri {viTriCuoiCung} co gia tri {mang[viTriCuoiCung]}.");
            }
        }
    }
}