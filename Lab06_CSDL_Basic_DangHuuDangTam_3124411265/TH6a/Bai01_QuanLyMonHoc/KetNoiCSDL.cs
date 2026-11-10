namespace Bai01_QuanLyMonHoc
{
    public static class KetNoiCSDL
    {
        // Thay TEN_SERVER bằng Server name đang dùng trong SSMS.
        // Dùng Windows Authentication.
        //
        // TrustServerCertificate=True dành cho môi trường
        // thực hành SQL Server cục bộ.
        public static string ChuoiKetNoi =
            @"Server=localhost;"
            + "Database=QLSinhVien;"
            + "Integrated Security=True;"
            + "Encrypt=True;"
            + "TrustServerCertificate=True;"
            + "Connect Timeout=10;";
    }
}