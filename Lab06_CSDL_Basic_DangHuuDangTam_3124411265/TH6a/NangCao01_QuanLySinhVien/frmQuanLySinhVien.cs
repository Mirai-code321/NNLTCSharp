using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace NangCao01_QuanLySinhVien
{
    public class frmQuanLySinhVien : Form
    {
        private readonly TextBox txtMaLop;
        private readonly TextBox txtMaSV;
        private readonly TextBox txtHoTen;
        private readonly TextBox txtNgaySinh;

        public frmQuanLySinhVien()
        {
            Text = "TH6a - Quản lý sinh viên";
            ClientSize = new Size(600, 380);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ThemLabel("Mã lớp", 25, 35);
            txtMaLop = ThemTextBox(200, 32, 360, 20);

            ThemLabel("Mã sinh viên", 25, 95);
            txtMaSV = ThemTextBox(200, 92, 360, 20);

            ThemLabel("Họ tên", 25, 155);
            txtHoTen = ThemTextBox(200, 152, 360, 100);

            ThemLabel("Ngày sinh", 25, 215);
            txtNgaySinh = ThemTextBox(200, 212, 360, 10);

            Label lblHuongDan = new Label();
            lblHuongDan.Text = "Ngày sinh: dd/MM/yyyy";
            lblHuongDan.SetBounds(200, 250, 360, 28);
            Controls.Add(lblHuongDan);

            ThemButton("&Thêm", 35, 305, ThemSinhVien);
            ThemButton("&Xóa", 225, 305, XoaSinhVien);
            ThemButton("&Sửa", 415, 305, SuaSinhVien);

            Shown += (_, _) => txtMaLop.Focus();
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

        private bool DocNgaySinh(out DateTime ngaySinh)
        {
            bool hopLe = DateTime.TryParseExact(
                txtNgaySinh.Text.Trim(),
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out ngaySinh
            );

            if (!hopLe)
            {
                ThongBao(
                    "Ngày sinh không hợp lệ. "
                    + "Hãy nhập đúng dạng dd/MM/yyyy."
                );

                txtNgaySinh.Focus();
                return false;
            }

            if (ngaySinh.Date > DateTime.Today)
            {
                ThongBao("Ngày sinh không được ở tương lai.");
                txtNgaySinh.Focus();
                return false;
            }

            return true;
        }

        private void XoaOInput()
        {
            txtMaLop.Clear();
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();

            txtMaLop.Focus();
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
                        "Không tìm thấy sinh viên "
                        + "khớp với thông tin đã nhập."
                    );

                    return;
                }

                MessageBox.Show(
                    this,
                    thaoTac + " sinh viên thành công.",
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
                    "Mã sinh viên đã tồn tại. Hãy nhập mã khác."
                );

                txtMaSV.Focus();
                txtMaSV.SelectAll();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                if (thaoTac == "Xóa")
                {
                    ThongBao(
                        "Không thể xóa sinh viên vì đang có "
                        + "dữ liệu điểm tham chiếu."
                    );
                }
                else
                {
                    ThongBao(
                        "Mã lớp chưa tồn tại trong bảng Lop. "
                        + "Hãy kiểm tra lại mã lớp."
                    );

                    txtMaLop.Focus();
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

        private void ThemSinhVien()
        {
            if (!KiemTraMa(txtMaLop, "Mã lớp")
                || !KiemTraMa(txtMaSV, "Mã sinh viên")
                || !BatBuocNhap(txtHoTen, "Họ tên")
                || !BatBuocNhap(txtNgaySinh, "Ngày sinh"))
            {
                return;
            }

            if (!DocNgaySinh(out DateTime ngaySinh))
            {
                return;
            }

            string sql = @"
                INSERT INTO dbo.SinhVien
                    (MaSinhVien, HoTen, NgaySinh, MaLop)
                VALUES
                    (@MaSV, @HoTen, @NgaySinh, @MaLop);";

            ThucHienLenh(sql, "Thêm", lenh =>
            {
                lenh.Parameters.Add(
                    "@MaSV", SqlDbType.VarChar, 20
                ).Value = txtMaSV.Text.Trim();

                lenh.Parameters.Add(
                    "@HoTen", SqlDbType.NVarChar, 100
                ).Value = txtHoTen.Text.Trim();

                lenh.Parameters.Add(
                    "@NgaySinh", SqlDbType.Date
                ).Value = ngaySinh.Date;

                lenh.Parameters.Add(
                    "@MaLop", SqlDbType.VarChar, 20
                ).Value = txtMaLop.Text.Trim();
            });
        }

        private void XoaSinhVien()
        {
            if (!KiemTraMa(txtMaSV, "Mã sinh viên")
                || !BatBuocNhap(txtHoTen, "Họ tên"))
            {
                return;
            }

            // Theo đề: xóa chỉ nhập mã sinh viên và họ tên.
            if (!string.IsNullOrWhiteSpace(txtMaLop.Text)
                || !string.IsNullOrWhiteSpace(txtNgaySinh.Text))
            {
                ThongBao(
                    "Khi xóa, chỉ nhập mã sinh viên và họ tên. "
                    + "Để trống mã lớp và ngày sinh."
                );

                return;
            }

            DialogResult luaChon = MessageBox.Show(
                this,
                $"Xóa sinh viên {txtMaSV.Text.Trim()}"
                    + $" - {txtHoTen.Text.Trim()}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (luaChon != DialogResult.Yes)
            {
                return;
            }

            // Phải khớp đồng thời mã sinh viên và họ tên.
            string sql = @"
                DELETE FROM dbo.SinhVien
                WHERE MaSinhVien = @MaSV
                  AND HoTen = @HoTen;";

            ThucHienLenh(sql, "Xóa", lenh =>
            {
                lenh.Parameters.Add(
                    "@MaSV", SqlDbType.VarChar, 20
                ).Value = txtMaSV.Text.Trim();

                lenh.Parameters.Add(
                    "@HoTen", SqlDbType.NVarChar, 100
                ).Value = txtHoTen.Text.Trim();
            });
        }

        private void SuaSinhVien()
        {
            if (!KiemTraMa(txtMaSV, "Mã sinh viên"))
            {
                return;
            }

            string maLop = txtMaLop.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string ngayNhap = txtNgaySinh.Text.Trim();

            if (maLop.Length == 0
                && hoTen.Length == 0
                && ngayNhap.Length == 0)
            {
                ThongBao(
                    "Hãy nhập ít nhất một thông tin cần sửa: "
                    + "mã lớp, họ tên hoặc ngày sinh."
                );

                return;
            }

            if (maLop.Length > 0
                && !KiemTraMa(txtMaLop, "Mã lớp"))
            {
                return;
            }

            DateTime? ngaySinhMoi = null;

            if (ngayNhap.Length > 0)
            {
                if (!DocNgaySinh(out DateTime ngaySinh))
                {
                    return;
                }

                ngaySinhMoi = ngaySinh.Date;
            }

            // Tham số NULL có nghĩa là giữ nguyên dữ liệu cũ.
            string sql = @"
                UPDATE dbo.SinhVien
                SET MaLop = COALESCE(@MaLop, MaLop),
                    HoTen = COALESCE(@HoTen, HoTen),
                    NgaySinh = COALESCE(@NgaySinh, NgaySinh)
                WHERE MaSinhVien = @MaSV;";

            ThucHienLenh(sql, "Sửa", lenh =>
            {
                lenh.Parameters.Add(
                    "@MaSV", SqlDbType.VarChar, 20
                ).Value = txtMaSV.Text.Trim();

                lenh.Parameters.Add(
                    "@MaLop", SqlDbType.VarChar, 20
                ).Value = maLop.Length == 0
                    ? (object)DBNull.Value
                    : maLop;

                lenh.Parameters.Add(
                    "@HoTen", SqlDbType.NVarChar, 100
                ).Value = hoTen.Length == 0
                    ? (object)DBNull.Value
                    : hoTen;

                lenh.Parameters.Add(
                    "@NgaySinh", SqlDbType.Date
                ).Value = ngaySinhMoi.HasValue
                    ? (object)ngaySinhMoi.Value
                    : DBNull.Value;
            });
        }
    }
}