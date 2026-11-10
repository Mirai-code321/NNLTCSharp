namespace Bai02Point;

public class Point
{
    // Field luu toa do cua diem.
    private double x;
    private double y;

    // Property cho phep doc va thay doi toa do x.
    public double X
    {
        get => x;
        set => x = value;
    }

    // Property cho phep doc va thay doi toa do y.
    public double Y
    {
        get => y;
        set => y = value;
    }

    // Constructor mac dinh tao diem O(0, 0).
    public Point()
    {
        x = 0;
        y = 0;
    }

    // Constructor co tham so.
    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    // Constructor sao chep.
    public Point(Point point)
    {
        // Khong cho phep doi tuong point bi null.
        ArgumentNullException.ThrowIfNull(point);

        x = point.x;
        y = point.y;
    }

    // Nhap toa do cua diem.
    public void Input()
    {
        X = NhapSoThuc("Nhap toa do x: ");
        Y = NhapSoThuc("Nhap toa do y: ");
    }

    private static double NhapSoThuc(string thongBao)
    {
        while (true)
        {
            Console.Write(thongBao);
            string? duLieu = Console.ReadLine();

            // TryParse giup chuong trinh khong bi dung
            // khi nguoi dung nhap sai kieu du lieu.
            if (double.TryParse(duLieu, out double giaTri))
            {
                return giaTri;
            }

            Console.WriteLine(
                "Loi: Toa do phai la mot so thuc."
            );
        }
    }

    // Xuat toa do cua diem.
    public void Output()
    {
        Console.WriteLine(ToString());
    }

    // Chuyen doi tuong Point thanh chuoi co dang (x, y).
    public override string ToString()
    {
        return $"({X:0.##}, {Y:0.##})";
    }

    // Cong toa do tuong ung cua hai diem.
    public static Point operator +(Point a, Point b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);

        return new Point(
            a.X + b.X,
            a.Y + b.Y
        );
    }

    // Tru toa do tuong ung cua hai diem.
    public static Point operator -(Point a, Point b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);

        return new Point(
            a.X - b.X,
            a.Y - b.Y
        );
    }

    // Doi dau ca hai toa do cua mot diem.
    public static Point operator -(Point point)
    {
        ArgumentNullException.ThrowIfNull(point);

        return new Point(
            -point.X,
            -point.Y
        );
    }

    // Phuong thuc thanh vien:
    // Doi tuong hien tai tinh khoang cach den diem con lai.
    public double KhoangCachDen(Point pointKhac)
    {
        ArgumentNullException.ThrowIfNull(pointKhac);

        double deltaX = pointKhac.X - X;
        double deltaY = pointKhac.Y - Y;

        return Math.Sqrt(
            deltaX * deltaX + deltaY * deltaY
        );
    }

    // Phuong thuc tinh:
    // Nhan hai diem tu ben ngoai roi tinh khoang cach.
    public static double KhoangCach(Point a, Point b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);

        double deltaX = b.X - a.X;
        double deltaY = b.Y - a.Y;

        return Math.Sqrt(
            deltaX * deltaX + deltaY * deltaY
        );
    }

    // Phuong thuc thanh vien:
    // Tim trung diem giua doi tuong hien tai va diem con lai.
    public Point TrungDiemVoi(Point pointKhac)
    {
        ArgumentNullException.ThrowIfNull(pointKhac);

        return new Point(
            (X + pointKhac.X) / 2,
            (Y + pointKhac.Y) / 2
        );
    }

    // Phuong thuc tinh:
    // Tim trung diem cua hai diem duoc truyen vao.
    public static Point TrungDiem(Point a, Point b)
    {
        ArgumentNullException.ThrowIfNull(a);
        ArgumentNullException.ThrowIfNull(b);

        return new Point(
            (a.X + b.X) / 2,
            (a.Y + b.Y) / 2
        );
    }
}