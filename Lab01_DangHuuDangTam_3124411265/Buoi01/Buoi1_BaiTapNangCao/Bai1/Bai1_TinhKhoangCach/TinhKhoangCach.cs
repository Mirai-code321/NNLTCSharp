namespace KhoangCach;

public class TinhKhoangCach
{
    // Ham tinh khoang cach giua 2 diem A(x1,y1) va B(x2,y2)
    // Cong thuc: d = can bac hai cua [(x2-x1)^2 + (y2-y1)^2]
    // Tra ve gia tri double (khong in truc tiep) de co the unit test duoc
    public static double TinhKC(double x1, double y1, double x2, double y2)
    {
        // Tinh binh phuong hieu toa do x va toa do y
        double hieuX = Math.Pow(x2 - x1, 2);
        double hieuY = Math.Pow(y2 - y1, 2);

        // Lay can bac hai cua tong 2 binh phuong (dinh ly Pythagoras)
        double khoangCach = Math.Sqrt(hieuX + hieuY);

        return khoangCach;
    }
}

