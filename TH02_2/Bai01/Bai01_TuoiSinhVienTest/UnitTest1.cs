using Bai01TinhTuoiSinhVien;

namespace Bai01_TuoiSinhVien.Tests;

public class SinhVienTests
{
    [Fact]
    public void Constructor_ThongTinHopLe_GanDungDuLieu()
    {
        // Arrange và Act
        SinhVien sinhVien = new SinhVien(
            "Đặng Hữu Đăng Tâm",
            2006
        );

        // Assert
        Assert.Equal("Đặng Hữu Đăng Tâm", sinhVien.HoTen);
        Assert.Equal(2006, sinhVien.NamSinh);
    }

    [Fact]
    public void TinhTuoi_NamSinhHopLe_TraVeTuoiDung()
    {
        // Arrange
        int namSinh = 2006;
        SinhVien sinhVien = new SinhVien(
            "Đặng Hữu Đăng Tâm",
            namSinh
        );

        int tuoiMongDoi = DateTime.Now.Year - namSinh;

        // Act
        int tuoiThucTe = sinhVien.TinhTuoi();

        // Assert
        Assert.Equal(tuoiMongDoi, tuoiThucTe);
    }

    [Fact]
    public void HoTen_Rong_NemArgumentException()
    {
        // Arrange
        SinhVien sinhVien = new SinhVien();

        // Act
        Action hanhDong = () => sinhVien.HoTen = "";

        // Assert
        Assert.Throws<ArgumentException>(hanhDong);
    }

    [Fact]
    public void NamSinh_LonHonNamHienTai_NemArgumentException()
    {
        // Arrange
        SinhVien sinhVien = new SinhVien();
        int namTuongLai = DateTime.Now.Year + 1;

        // Act
        Action hanhDong = () =>
            sinhVien.NamSinh = namTuongLai;

        // Assert
        Assert.Throws<ArgumentException>(hanhDong);
    }

    [Fact]
    public void Xuat_ThongTinSinhVien_HienThiDayDuDuLieu()
    {
        // Arrange
        SinhVien sinhVien = new SinhVien(
            "Đặng Hữu Đăng Tâm",
            2006
        );

        // Lưu Console.Out hiện tại để khôi phục sau khi test.
        TextWriter consoleCu = Console.Out;

        using StringWriter output = new StringWriter();

        try
        {
            // Chuyển dữ liệu Console.WriteLine vào biến output.
            Console.SetOut(output);

            // Act
            sinhVien.Xuat();

            string ketQua = output.ToString();

            // Assert
            Assert.Contains("Đặng Hữu Đăng Tâm", ketQua);
            Assert.Contains("2006", ketQua);
            Assert.Contains(
                sinhVien.TinhTuoi().ToString(),
                ketQua
            );
        }
        finally
        {
            // Khôi phục Console.Out để không ảnh hưởng test khác.
            Console.SetOut(consoleCu);
        }
    }
}