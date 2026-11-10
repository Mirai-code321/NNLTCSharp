namespace NangCao01_QuanLySinhVien
{
    public static class KetNoiCSDL
    {
        // Thay TEN_SERVER bằng đúng Server name trong SSMS.
        public static string ChuoiKetNoi =
            @"Server=localhost;"
            + "Database=QLSinhVien;"
            + "Integrated Security=True;"
            + "Encrypt=True;"
            + "TrustServerCertificate=True;"
            + "Connect Timeout=10;";
    }
}