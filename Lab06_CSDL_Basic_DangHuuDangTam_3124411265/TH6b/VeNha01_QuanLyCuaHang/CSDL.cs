using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace VeNha01_QuanLyCuaHang
{
    public static class CSDL
    {
        public static string ChuoiKetNoi =
            @"Server=localhost;"
            + "Database=QLCuaHang;"
            + "Integrated Security=True;"
            + "Encrypt=True;"
            + "TrustServerCertificate=True;"
            + "Connect Timeout=10;";

        // Đọc dữ liệu cho các bảng hiển thị và ComboBox.
        public static DataTable Doc(
            string sql,
            int? maHD = null)
        {
            using SqlConnection cn =
                new SqlConnection(ChuoiKetNoi);

            using SqlCommand cmd = new SqlCommand(sql, cn);

            if (maHD.HasValue)
            {
                cmd.Parameters.Add(
                    "@MaHD", SqlDbType.Int
                ).Value = maHD.Value;
            }

            cn.Open();

            using SqlDataReader reader = cmd.ExecuteReader();

            DataTable bang = new DataTable();
            bang.Load(reader);

            return bang;
        }

        // Gọi thủ tục xử lý, các tham số đều có kiểu rõ ràng.
        public static int ThucHien(
            string tacVu,
            int? maHD = null,
            int? maSP = null,
            int? soLuong = null,
            string? tenSP = null)
        {
            using SqlConnection cn =
                new SqlConnection(ChuoiKetNoi);

            using SqlCommand cmd =
                new SqlCommand("dbo.ThucHienCuaHang", cn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(
                "@TacVu", SqlDbType.VarChar, 20
            ).Value = tacVu;

            cmd.Parameters.Add(
                "@MaHD", SqlDbType.Int
            ).Value = (object?)maHD ?? DBNull.Value;

            cmd.Parameters.Add(
                "@MaSP", SqlDbType.Int
            ).Value = (object?)maSP ?? DBNull.Value;

            cmd.Parameters.Add(
                "@SoLuong", SqlDbType.Int
            ).Value = (object?)soLuong ?? DBNull.Value;

            cmd.Parameters.Add(
                "@TenSP", SqlDbType.NVarChar, 100
            ).Value = (object?)tenSP ?? DBNull.Value;

            cn.Open();

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static DataTable TonHomNay()
        {
            return Doc(@"
                SELECT
                    sp.MaSP,
                    sp.TenSP,
                    tk.NgayTon,
                    tk.SLDau,
                    tk.SLNhap,
                    tk.SLBan,
                    CAST(tk.SLDau AS BIGINT)
                        + tk.SLNhap - tk.SLBan AS ConLai
                FROM dbo.SANPHAM AS sp
                INNER JOIN dbo.TONKHO AS tk
                    ON sp.MaSP = tk.MaSP
                WHERE tk.NgayTon = CONVERT(DATE, GETDATE())
                ORDER BY sp.MaSP;");
        }
    }
}