using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bai01_QuanLyMonHoc
{
    public class frmQuanLyMonHoc : Form
    {
        private readonly TextBox txtMaMonHoc;
        private readonly TextBox txtTenMonHoc;

        public frmQuanLyMonHoc()
        {
            Text = "TH6a - Quản lý môn học";
            ClientSize = new Size(560, 260);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblMa = new Label();
            lblMa.Text = "Mã môn học";
            lblMa.SetBounds(25, 40, 140, 30);
            Controls.Add(lblMa);

            txtMaMonHoc = new TextBox();
            txtMaMonHoc.MaxLength = 20;
            txtMaMonHoc.SetBounds(175, 37, 350, 30);
            Controls.Add(txtMaMonHoc);

            Label lblTen = new Label();
            lblTen.Text = "Tên môn học";
            lblTen.SetBounds(25, 100, 140, 30);
            Controls.Add(lblTen);

            txtTenMonHoc = new TextBox();
            txtTenMonHoc.MaxLength = 100;
            txtTenMonHoc.SetBounds(175, 97, 350, 30);
            Controls.Add(txtTenMonHoc);

            ThemButton(
                "&Thêm", 35, 175, ThemMonHoc
            );

            ThemButton(
                "&Xóa", 205, 175, XoaMonHoc
            );

            ThemButton(
                "&Sửa", 375, 175, SuaMonHoc
            );

            Shown += (_, _) => txtMaMonHoc.Focus();
        }

        private void ThemButton(
            string noiDung,
            int x,
            int y,
            Action xuLy)
        {
            Button button = new Button();
            button.Text = noiDung;
            button.SetBounds(x, y, 150, 42);
            button.Click += (_, _) => xuLy();
            Controls.Add(button);
        }

        private void ThongBao(string noiDung)
        {
            MessageBox.Show(
                this,
                noiDung,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        private bool KiemTraMa()
        {
            string ma = txtMaMonHoc.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                ThongBao("Mã môn học không được để trống.");
                txtMaMonHoc.Focus();
                return false;
            }

            // Mã lưu bằng VARCHAR: quy định dùng chữ Latin,
            // chữ số, dấu gạch dưới hoặc gạch ngang.
            foreach (char c in ma)
            {
                bool hopLe =
                    (c >= 'A' && c <= 'Z')
                    || (c >= 'a' && c <= 'z')
                    || (c >= '0' && c <= '9')
                    || c == '_'
                    || c == '-';

                if (!hopLe)
                {
                    ThongBao(
                        "Mã môn học chỉ gồm chữ không dấu, "
                        + "chữ số, dấu _ hoặc dấu -."
                    );

                    txtMaMonHoc.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool KiemTraMaVaTen()
        {
            if (!KiemTraMa())
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenMonHoc.Text))
            {
                ThongBao("Tên môn học không được để trống.");
                txtTenMonHoc.Focus();
                return false;
            }

            return true;
        }

        private void ThucHienLenh(
            string cauLenh,
            bool coTen,
            string thongBaoThanhCong)
        {
            try
            {
                // using tự giải phóng kết nối và command,
                // kể cả khi xảy ra lỗi.
                using SqlConnection ketNoi =
                    new SqlConnection(KetNoiCSDL.ChuoiKetNoi);

                using SqlCommand lenh =
                    new SqlCommand(cauLenh, ketNoi);

                // Truyền tham số, không nối dữ liệu nhập
                // trực tiếp vào câu SQL.
                lenh.Parameters.Add(
                    "@MaMonHoc",
                    SqlDbType.VarChar,
                    20
                ).Value = txtMaMonHoc.Text.Trim();

                if (coTen)
                {
                    // NVARCHAR hỗ trợ tên tiếng Việt có dấu.
                    lenh.Parameters.Add(
                        "@TenMonHoc",
                        SqlDbType.NVarChar,
                        100
                    ).Value = txtTenMonHoc.Text.Trim();
                }

                ketNoi.Open();

                // INSERT, DELETE và UPDATE trả số dòng ảnh hưởng.
                int soDong = lenh.ExecuteNonQuery();

                if (soDong > 0)
                {
                    MessageBox.Show(
                        this,
                        thongBaoThanhCong,
                        "Kết quả",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    txtMaMonHoc.Clear();
                    txtTenMonHoc.Clear();
                    txtMaMonHoc.Focus();
                }
                else
                {
                    ThongBao(
                        "Không tìm thấy môn học có mã đã nhập."
                    );
                }
            }
            catch (SqlException ex)
                when (ex.Number == 2627 || ex.Number == 2601)
            {
                ThongBao(
                    "Mã môn học đã tồn tại. Hãy nhập mã khác."
                );

                txtMaMonHoc.Focus();
                txtMaMonHoc.SelectAll();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                // Không tự xóa điểm để xóa môn học.
                ThongBao(
                    "Không thể xóa môn học vì đang có "
                    + "dữ liệu điểm tham chiếu đến môn này."
                );
            }
            catch (SqlException ex)
            {
                ThongBao(
                    "Không thực hiện được thao tác SQL Server.\n"
                    + "Kiểm tra Server name, database "
                    + "và quyền kết nối.\n\n"
                    + ex.Message
                );
            }
            catch (InvalidOperationException ex)
            {
                ThongBao("Lỗi kết nối: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                ThongBao("Chuỗi kết nối chưa hợp lệ: " + ex.Message);
            }
        }

        private void ThemMonHoc()
        {
            if (!KiemTraMaVaTen())
            {
                return;
            }

            string sql = @"
                INSERT INTO dbo.MonHoc
                    (MaMonHoc, TenMonHoc)
                VALUES
                    (@MaMonHoc, @TenMonHoc);";

            ThucHienLenh(
                sql,
                true,
                "Thêm môn học thành công."
            );
        }

        private void XoaMonHoc()
        {
            if (!KiemTraMa())
            {
                return;
            }

            // Theo đề: khi xóa chỉ nhập mã,
            // ô tên môn học không nhập dữ liệu.
            if (!string.IsNullOrWhiteSpace(txtTenMonHoc.Text))
            {
                ThongBao(
                    "Khi xóa, chỉ nhập mã môn học "
                    + "và để trống tên môn học."
                );

                txtTenMonHoc.Focus();
                return;
            }

            DialogResult luaChon = MessageBox.Show(
                this,
                $"Bạn có muốn xóa môn học "
                    + $"{txtMaMonHoc.Text.Trim()}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (luaChon != DialogResult.Yes)
            {
                return;
            }

            string sql = @"
                DELETE FROM dbo.MonHoc
                WHERE MaMonHoc = @MaMonHoc;";

            ThucHienLenh(
                sql,
                false,
                "Xóa môn học thành công."
            );
        }

        private void SuaMonHoc()
        {
            if (!KiemTraMaVaTen())
            {
                return;
            }

            string sql = @"
                UPDATE dbo.MonHoc
                SET TenMonHoc = @TenMonHoc
                WHERE MaMonHoc = @MaMonHoc;";

            ThucHienLenh(
                sql,
                true,
                "Sửa tên môn học thành công."
            );
        }
    }
}