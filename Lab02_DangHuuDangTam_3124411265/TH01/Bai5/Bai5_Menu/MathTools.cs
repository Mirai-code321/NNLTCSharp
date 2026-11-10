using System;

namespace Bai5_Menu
{
    // Lop rieng chi lo tinh toan, khong dinh gi den Console (de de test)
    public class MathTools
    {
        // Tinh x^y voi x, y la so thuc
        // Dung Math.Pow vi de bai yeu cau so thuc, khac voi bai 3/4
        // (bai 3/4 la so nguyen nen phai tu viet vong lap, khong dung Math.Pow)
        public static double TinhLuyThua(double x, double y)
        {
            return Math.Pow(x, y);
        }

        // Tinh can bac 2 cua 1 so thuc
        // Tra ve kieu double? (nullable) de bao hieu "khong tinh duoc"
        // khi gap so am, thay vi tra ve NaN kho hieu cho nguoi dung
        public static double? TinhCanBac2(double soThuc)
        {
            if (soThuc < 0)
            {
                return null; // so am khong co can bac 2 trong tap so thuc
            }

            return Math.Sqrt(soThuc);
        }
    }
}