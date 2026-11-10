using System;

namespace Bai9_TimMaxMin
{
    // Lop xu ly nghiep vu tim gia tri lon nhat va nho nhat cua 3 so thuc, khong dinh Console
    public class TimMaxMin
    {
        // Dung out vi can tra ra CUNG LUC 2 ket qua (lon nhat va nho nhat).
        // Khac voi ref: bien truyen vao out KHONG can khoi tao gia tri truoc do,
        // nhung ben trong phuong thuc BAT BUOC phai gan gia tri cho moi bien out
        // truoc khi ham ket thuc (trinh bien dich se bao loi CS0177 neu thieu).
        public void TimGiaTriLonNhoNhat(double a, double b, double c, out double gtLon, out double gtNho)
        {
            // Gia su a vua la lon nhat vua la nho nhat, roi so sanh dan voi b, c
            gtLon = a;
            gtNho = a;

            if (b > gtLon) gtLon = b;
            if (b < gtNho) gtNho = b;

            if (c > gtLon) gtLon = c;
            if (c < gtNho) gtNho = c;
        }
    }
}