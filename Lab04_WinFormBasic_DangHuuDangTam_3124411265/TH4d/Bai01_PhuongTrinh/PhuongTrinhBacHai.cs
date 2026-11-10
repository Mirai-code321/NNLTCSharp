using System;

namespace Bai01_PhuongTrinh
{
    public class PhuongTrinhBacHai
    {
        // Các hệ số của phương trình.
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public PhuongTrinhBacHai()
        {
            A = B = C = 0;
        }

        public PhuongTrinhBacHai(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        private static string DinhDang(double so)
        {
            return so.ToString("G10");
        }

        // Giải ax + b = 0.
        public string GiaiBacNhat()
        {
            if (A == 0)
            {
                return B == 0
                    ? "Phương trình có vô số nghiệm."
                    : "Phương trình vô nghiệm.";
            }

            double x = -B / A;

            if (!double.IsFinite(x))
                return "Nghiệm vượt phạm vi tính toán.";

            return $"Phương trình có nghiệm x = {DinhDang(x)}";
        }

        // Giải ax² + bx + c = 0 trên tập số thực.
        public string GiaiBacHai()
        {
            // Khi a = 0, phương trình trở thành bx + c = 0.
            if (A == 0)
            {
                PhuongTrinhBacHai bacNhat =
                    new PhuongTrinhBacHai(B, C, 0);

                return bacNhat.GiaiBacNhat();
            }

            // Chuẩn hóa hệ số để giảm nguy cơ tràn
            // khi tính bình phương và tích.
            double tiLe = Math.Max(
                Math.Abs(A),
                Math.Max(Math.Abs(B), Math.Abs(C)));

            double a = A / tiLe;
            double b = B / tiLe;
            double c = C / tiLe;

            if (a == 0)
                return "Các hệ số chênh lệch quá lớn để tính chính xác.";

            double delta = b * b - 4 * a * c;

            if (delta < 0)
                return "Phương trình vô nghiệm trong tập số thực.";

            if (delta == 0)
            {
                double x = -b / (2 * a);

                if (!double.IsFinite(x))
                    return "Nghiệm vượt phạm vi tính toán.";

                return $"Phương trình có nghiệm kép:\r\n" +
                       $"x₁ = x₂ = {DinhDang(x)}";
            }

            double canDelta = Math.Sqrt(delta);

            // Công thức hạn chế mất độ chính xác
            // khi trừ hai số gần bằng nhau.
            double q = -0.5 * (b + Math.CopySign(canDelta, b));

            double x1 = q / a;
            double x2 = c / q;

            if (!double.IsFinite(x1) || !double.IsFinite(x2))
                return "Nghiệm vượt phạm vi tính toán.";

            // Sắp xếp để hiển thị nghiệm nhỏ trước.
            if (x1 > x2)
                (x1, x2) = (x2, x1);

            return $"Phương trình có hai nghiệm phân biệt:\r\n" +
                   $"x₁ = {DinhDang(x1)}\r\n" +
                   $"x₂ = {DinhDang(x2)}";
        }
    }
}