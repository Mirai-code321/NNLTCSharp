using System.ComponentModel.DataAnnotations;

namespace Bai01TinhTuoiSinhVien;

public class SinhVien
{
    // Field: lưu trữ dữ liệu bên trong đối tượng.
    private string hoTen= string.Empty;
    private int namSinh;
    public string HoTen
    {
        get => hoTen;
        set
        {
            //khong cho phep ho ten null hoac chua khoang trang
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Ho ten khong duoc de trong.");
            }
            hoTen = value.Trim();
        }
    }

    //Property cho phep truy cap nam sinh va kiem tra tinh hop le

    public int NamSinh
    {
        get => namSinh;
        set
        {
            int namHienTai = DateTime.Now.Year;

            //Nam sinh phai duong va khong duoc lon honw nam hien tai
            if (value <= 0 || value > namHienTai)
            {
                throw new ArgumentException($"Nam sinh phai nam trong khoang 1 den {namHienTai}.");
            }
            namSinh = value;
        }
    }

    //Contructor mac dinh
    public SinhVien()
    {
        hoTen = "Chua xac dinh";
        namSinh = DateTime.Now.Year;
    }

    // Constructor co tham so
    public SinhVien(string hoTen, int namSinh)
    {
        //su dung property de du lieu duoc kiem tra truoc khi gan
        HoTen = hoTen;
        NamSinh = namSinh;
    }
    
    public void Nhap()
    {
        nhapHoTen();
        nhapNamSinh();
    }

    private void nhapHoTen()
    {
        //Lap lai cho den khi nhap duoc ten hop le
        while (true)
        {
            Console.Write("Nhap ho ten sinh vien: ");

            string? duLieuHoTen = Console.ReadLine();
            try
            {
                HoTen = duLieuHoTen ?? string.Empty;
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
        }


    }
    private void nhapNamSinh()
    {
        //lap lai cho den khi nhap duoc nam sinh hop le
        while (true)
        {
            Console.Write("Nhap nam sinh: ");
            string? duLieuNamSinh = Console.ReadLine();

            //tryParse giup chuong trinh khong bi dung khi nguoi dung nhap chu
            if (!int.TryParse(duLieuNamSinh, out int nam))
            {
                Console.WriteLine("Loi: Nam sinh phai la mot so nguyen");
                continue;
            }

            try
            {
                NamSinh = nam;
                break;
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
        }
        
    }

    public int TinhTuoi()
    {
        //tuoi duoc tinh dua tren nam hien tai cua he thong
        return DateTime.Now.Year - namSinh;
    }

    public void Xuat()
    {
        Console.WriteLine($"Ho ten: {hoTen}");
        Console.WriteLine($"Nam sinh: {namSinh}");
        Console.WriteLine($"Tuoi: {TinhTuoi()}");

    }
}