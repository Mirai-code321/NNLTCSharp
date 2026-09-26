using System.Collections;
using Bai02Point;

namespace Bai06ArrayPoint;

public class ArrayPoint
{
    // ArrayList dung de luu cac doi tuong Point.
    private readonly ArrayList points;

    // Tra ve so luong diem dang co trong danh sach.
    public int Count => points.Count;

    // Constructor mac dinh tao mot danh sach rong.
    public ArrayPoint()
    {
        points = new ArrayList();
    }

    // Constructor sao chep.
    public ArrayPoint(ArrayPoint arrayPoint)
    {
        ArgumentNullException.ThrowIfNull(arrayPoint);

        points = new ArrayList();

        // Tao doi tuong Point moi cho tung phan tu.
        // Cach nay giup hai danh sach khong dung chung doi tuong.
        foreach (Point point in arrayPoint.points)
        {
            points.Add(new Point(point));
        }
    }

    // Indexer cho phep truy cap bang cu phap arrayPoint[index].
    public Point this[int index]
    {
        get
        {
            KiemTraChiSo(index);

            return (Point)points[index]!;
        }

        set
        {
            KiemTraChiSo(index);
            ArgumentNullException.ThrowIfNull(value);

            points[index] = value;
        }
    }

    public void Add(Point point)
    {
        ArgumentNullException.ThrowIfNull(point);

        points.Add(point);
    }

    public void RemoveAt(int index)
    {
        KiemTraChiSo(index);

        points.RemoveAt(index);
    }

    public void Clear()
    {
        points.Clear();
    }

    private void KiemTraChiSo(int index)
    {
        // Chi so hop le nam trong khoang tu 0 den Count - 1.
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException(
                $"Chi so {index} khong hop le. " +
                $"Chi so phai nam trong khoang 0 den {Count - 1}."
            );
        }
    }

    public void Input()
    {
        int soLuong = NhapSoLuong();

        // Xoa du lieu cu truoc khi nhap danh sach moi.
        points.Clear();

        for (int i = 0; i < soLuong; i++)
        {
            Console.WriteLine($"\nNhap diem thu {i + 1}:");

            Point point = new Point();
            point.Input();

            points.Add(point);
        }
    }

    private static int NhapSoLuong()
    {
        while (true)
        {
            Console.Write("Nhap so luong diem: ");
            string? duLieu = Console.ReadLine();

            if (int.TryParse(duLieu, out int soLuong) &&
                soLuong >= 0)
            {
                return soLuong;
            }

            Console.WriteLine(
                "Loi: So luong diem phai la so nguyen khong am."
            );
        }
    }

    public void Output()
    {
        if (Count == 0)
        {
            Console.WriteLine("Danh sach diem dang rong.");
            return;
        }

        Console.WriteLine("DANH SACH DIEM");

        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine(
                $"Diem thu {i + 1}: {this[i]}"
            );
        }
    }
}