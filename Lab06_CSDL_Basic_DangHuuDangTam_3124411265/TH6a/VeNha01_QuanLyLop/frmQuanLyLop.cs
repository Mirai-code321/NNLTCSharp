using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace VeNha01_QuanLyLop
{
    public class frmQuanLyLop : Form
    {
        private readonly TextBox txtMaKhoa;
        private readonly TextBox txtMaLop;
        private readonly TextBox txtTenLop;

        public frmQuanLyLop()
        {
            Text = "TH6a - Quản lý lớp";
            ClientSize = new Size(600, 310);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ThemLabel("Mã khoa", 25, 35);
            txtMaKhoa = ThemTextBox(200, 32, 360, 20);

            ThemLabel("Mã lớp", 25, 95);
            txtMaLop = ThemTextBox(200, 92, 360, 20);

            ThemLabel("Tên lớp", 25, 155);
            txtTenLop = ThemTextBox(200, 152, 360, 100);

            ThemButton("&Thêm", 35, 235, ThemLop);
            ThemButton("&Xóa", 225, 235, XoaLop);
            ThemButton("&Sửa", 415, 235, SuaLop);

            Shown += (_, _) => txtMaKhoa.Focus();
        }

        private void ThemLabel(
            string noiDung,
            int x,
            int y)
        {
            Label label = new Label();
            label.Text = noiDung;
            label.SetBounds(x, y, 160, 30);
            Controls.Add(label);
        }

        private TextBox ThemTextBox(
            int x,
            int y,
            int rong,
            int doDaiToiDa)
        {
            TextBox textBox = new TextBox();
            textBox.MaxLength = doDaiToiDa;
            textBox.SetBounds(x, y, rong, 30);
            Controls.Add(textBox);

            return textBox;
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

        private bool BatBuocNhap(
            TextBox textBox,
            string tenTruong)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                return true;
            }

            ThongBao(tenTruong + " không được để trống.");
            textBox.Focus();

            return false;
        }

        private bool KiemTraMa(
            TextBox textBox,
            string tenTruong)
        {
            if (!BatBuocNhap(textBox, tenTruong))
            {
                return false;
            }

            string ma = textBox.Text.Trim();

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
                        tenTruong
                        + " chỉ gồm chữ không dấu, chữ số, "
                        + "dấu _ hoặc dấu -."
                    );

                    textBox.Focus();
                    return false;
                }
            }

            return true;
        }

        private void XoaOInput()
        {
            txtMaKhoa.Clear();
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtMaKhoa.Focus();
        }

        private void ThucHienLenh(
            string sql,
            string thaoTac,
            Action<SqlCommand> themThamSo)
        {
            try
            {
                using SqlConnection ketNoi =
                    new SqlConnection(KetNoiCSDL.ChuoiKetNoi);

                using SqlCommand lenh =
                    new SqlCommand(sql, ketNoi);

                themThamSo(lenh);

                ketNoi.Open();

                int soDong = lenh.ExecuteNonQuery();

                if (soDong == 0)
                {
                    ThongBao(
                        "Không tìm thấy lớp có mã đã nhập."
                    );

                    return;
                }

                MessageBox.Show(
                    this,
                    thaoTac + " lớp thành công.",
                    "Kết quả",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                XoaOInput();
            }
            catch (SqlException ex)
                when (ex.Number == 2627 || ex.Number == 2601)
            {
                ThongBao(
                    "Mã lớp đã tồn tại. Hãy nhập mã khác."
                );

                txtMaLop.Focus();
                txtMaLop.SelectAll();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                if (thaoTac == "Xóa")
                {
                    ThongBao(
                        "Không thể xóa lớp vì đang có "
                        + "sinh viên thuộc lớp này."
                    );
                }
                else
                {
                    ThongBao(
                        "Mã khoa chưa tồn tại trong bảng Khoa. "
                        + "Hãy kiểm tra lại mã khoa."
                    );

                    txtMaKhoa.Focus();
                }
            }
            catch (SqlException ex)
            {
                ThongBao(
                    "Lỗi SQL Server. Hãy kiểm tra kết nối "
                    + "và cấu trúc dữ liệu.\n\n"
                    + ex.Message
                );
            }
            catch (InvalidOperationException ex)
            {
                ThongBao("Lỗi kết nối: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                ThongBao(
                    "Thông tin kết nối chưa hợp lệ: "
                    + ex.Message
                );
            }
        }

        private void ThemLop()
        {
            if (!KiemTraMa(txtMaKhoa, "Mã khoa")
                || !KiemTraMa(txtMaLop, "Mã lớp")
                || !BatBuocNhap(txtTenLop, "Tên lớp"))
            {
                return;
            }

            string sql = @"
                INSERT INTO dbo.Lop
                    (MaLop, TenLop, MaKhoa)
                VALUES
                    (@MaLop, @TenLop, @MaKhoa);";

            ThucHienLenh(sql, "Thêm", lenh =>
            {
                lenh.Parameters.Add(
                    "@MaLop",
                    SqlDbType.VarChar,
                    20
                ).Value = txtMaLop.Text.Trim();

                lenh.Parameters.Add(
                    "@TenLop",
                    SqlDbType.NVarChar,
                    100
                ).Value = txtTenLop.Text.Trim();

                lenh.Parameters.Add(
                    "@MaKhoa",
                    SqlDbType.VarChar,
                    20
                ).Value = txtMaKhoa.Text.Trim();
            });
        }

        private void XoaLop()
        {
            if (!KiemTraMa(txtMaLop, "Mã lớp"))
            {
                return;
            }

            // Theo đề: khi xóa chỉ nhập mã lớp.
            if (!string.IsNullOrWhiteSpace(txtMaKhoa.Text)
                || !string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                ThongBao(
                    "Khi xóa, chỉ nhập mã lớp. "
                    + "Để trống mã khoa và tên lớp."
                );

                return;
            }

            DialogResult luaChon = MessageBox.Show(
                this,
                $"Bạn có muốn xóa lớp "
                    + $"{txtMaLop.Text.Trim()}?",
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
                DELETE FROM dbo.Lop
                WHERE MaLop = @MaLop;";

            ThucHienLenh(sql, "Xóa", lenh =>
            {
                lenh.Parameters.Add(
                    "@MaLop",
                    SqlDbType.VarChar,
                    20
                ).Value = txtMaLop.Text.Trim();
            });
        }

        private void SuaLop()
        {
            if (!KiemTraMa(txtMaLop, "Mã lớp"))
            {
                return;
            }

            string maKhoa = txtMaKhoa.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();

            if (maKhoa.Length == 0 && tenLop.Length == 0)
            {
                ThongBao(
                    "Hãy nhập ít nhất một thông tin cần sửa: "
                    + "mã khoa hoặc tên lớp."
                );

                return;
            }

            if (maKhoa.Length > 0
                && !KiemTraMa(txtMaKhoa, "Mã khoa"))
            {
                return;
            }

            // Tham số NULL nghĩa là giữ nguyên giá trị cũ.
            string sql = @"
                UPDATE dbo.Lop
                SET MaKhoa = COALESCE(@MaKhoa, MaKhoa),
                    TenLop = COALESCE(@TenLop, TenLop)
                WHERE MaLop = @MaLop;";

            ThucHienLenh(sql, "Sửa", lenh =>
            {
                lenh.Parameters.Add(
                    "@MaLop",
                    SqlDbType.VarChar,
                    20
                ).Value = txtMaLop.Text.Trim();

                lenh.Parameters.Add(
                    "@MaKhoa",
                    SqlDbType.VarChar,
                    20
                ).Value = maKhoa.Length == 0
                    ? (object)DBNull.Value
                    : maKhoa;

                lenh.Parameters.Add(
                    "@TenLop",
                    SqlDbType.NVarChar,
                    100
                ).Value = tenLop.Length == 0
                    ? (object)DBNull.Value
                    : tenLop;
            });
        }
    }
}