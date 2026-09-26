using System;

namespace Bai8_HoanVi
{
    // Lop xu ly nghiep vu hoan vi hai so thuc, khong dinh Console
    public class HoanVi
    {
        // Dung ref vi can thay doi truc tiep bien goc ben ngoai (tham chieu),
        // khac voi tham tri se khong lam thay doi gia tri sau khi ham ket thuc
        public void ThucHienHoanVi(ref double a, ref double b)
        {
            double tam = a;
            a = b;
            b = tam;
        }
    }
}