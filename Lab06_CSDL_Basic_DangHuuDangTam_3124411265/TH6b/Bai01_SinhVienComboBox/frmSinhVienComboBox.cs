using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bai01_SinhVienComboBox
{
    public class frmSinhVienComboBox : Form
    {
        private readonly ComboBox cboLop;
        private readonly TextBox txtMaSV;
        private readonly TextBox txtHoTen;
        private readonly TextBox txtNgaySinh;

        public frmSinhVienComboBox()
        {
            Text = "TH6b - Quản lý sinh viên";
            ClientSize = new Size(600, 380);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ThemLabel("Lớp", 25, 35);

            cboLop = new ComboBox();
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.SetBounds(200, 32, 360, 32);
            Controls.Add(cboLop);

            ThemLabel("Mã sinh viên", 25, 95);
            txtMaSV = ThemTextBox(200, 92, 20);

            ThemLabel("Họ tên", 25, 155);
            txtHoTen = ThemTextBox(200, 152, 100);

            ThemLabel("Ngày sinh", 25, 215);
            txtNgaySinh = ThemTextBox(200, 212, 10);

            Label lblHuongDan = new Label();
            lblHuongDan.Text = "Ngày sinh: dd/MM/yyyy";
            lblHuongDan.SetBounds(200, 250, 360, 28);
            Controls.Add(lblHuongDan);

            ThemButton("&Thêm", 35, ThemSinhVien);
            ThemButton("&Xóa", 225, XoaSinhVien);
            ThemButton("&Sửa", 415, SuaSinhVien);

            Load += (_, _) => XuLyCSDL(NapDanhSachLop);
            Shown += (_, _) => txtMaSV.Focus();
        }

        private void ThemLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.SetBounds(x, y, 160, 30);
            Controls.Add(label);
        }

        private TextBox ThemTextBox(
            int x, int y, int doDaiToiDa)
        {
            TextBox textBox = new TextBox();
            textBox.MaxLength = doDaiToiDa;
            textBox.SetBounds(x, y, 360, 30);
            Controls.Add(textBox);

            return textBox;
        }

        private void ThemButton(
            string text, int x, Action xuLy)
        {
            Button button = new Button();
            button.Text = text;
            button.SetBounds(x, 305, 150, 42);
            button.Click += (_, _) => xuLy();
            Controls.Add(button);
        }

        private void ThongBao(string text)
        {
            MessageBox.Show(
                this,
                text,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        private void ThanhCong(string text)
        {
            MessageBox.Show(
                this,
                text,
                "Kết quả",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            txtMaSV.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            txtMaSV.Focus();
        }

        // Dùng chung để mở kết nối và xử lý lỗi.
        private void XuLyCSDL(Action<SqlConnection> congViec)
        {
            try
            {
                using SqlConnection ketNoi =
                    new SqlConnection(KetNoiCSDL.ChuoiKetNoi);

                ketNoi.Open();
                congViec(ketNoi);
            }
            catch (SqlException ex)
                when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Vẫn giữ xử lý lỗi database trong trường hợp
                // dữ liệu thay đổi sau bước kiểm tra trước.
                ThongBao("Mã sinh viên đã tồn tại.");
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                ThongBao(
                    "Thao tác vi phạm khóa ngoại. "
                    + "Dữ liệu liên quan có thể đã thay đổi. "
                    + "Hãy kiểm tra lại lớp hoặc điểm sinh viên."
                );
            }
            catch (SqlException ex)
            {
                ThongBao(
                    "Lỗi SQL Server. Kiểm tra kết nối "
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

        private void NapDanhSachLop(SqlConnection ketNoi)
        {
            cboLop.Items.Clear();

            string sql = @"
                SELECT MaLop
                FROM dbo.Lop
                ORDER BY MaLop;";

            using SqlCommand lenh = new SqlCommand(sql, ketNoi);

            // Đọc từng dòng và đưa mã lớp lên ComboBox.
            using SqlDataReader reader = lenh.ExecuteReader();

            while (reader.Read())
            {
                cboLop.Items.Add(reader.GetString(0));
            }

            if (cboLop.Items.Count > 0)
            {
                cboLop.SelectedIndex = 0;
            }
            else
            {
                ThongBao(
                    "Bảng Lop chưa có dữ liệu. "
                    + "Hãy thêm lớp trước khi thêm sinh viên."
                );
            }
        }

        // Trả về true nếu truy vấn tìm thấy ít nhất một dòng.
        // Reader được giải phóng trước khi chạy câu lệnh tiếp theo.
        private bool CoDuLieu(
            SqlConnection ketNoi,
            string sql,
            string ma)
        {
            using SqlCommand lenh = new SqlCommand(sql, ketNoi);

            lenh.Parameters.Add(
                "@Ma", SqlDbType.VarChar, 20
            ).Value = ma;

            using SqlDataReader reader = lenh.ExecuteReader();

            return reader.HasRows;
        }

        private bool SinhVienTonTai(
            SqlConnection ketNoi, string maSV)
        {
            return CoDuLieu(
                ketNoi,
                @"SELECT TOP (1) MaSinhVien
                  FROM dbo.SinhVien
                  WHERE MaSinhVien = @Ma;",
                maSV
            );
        }

        private bool LopTonTai(
            SqlConnection ketNoi, string maLop)
        {
            return CoDuLieu(
                ketNoi,
                @"SELECT TOP (1) MaLop
                  FROM dbo.Lop
                  WHERE MaLop = @Ma;",
                maLop
            );
        }

        private bool SinhVienDaCoDiem(
            SqlConnection ketNoi, string maSV)
        {
            return CoDuLieu(
                ketNoi,
                @"SELECT TOP (1) MaSinhVien
                  FROM dbo.Diem
                  WHERE MaSinhVien = @Ma;",
                maSV
            );
        }

        private bool KiemTraMaSV()
        {
            string ma = txtMaSV.Text.Trim();

            if (ma.Length == 0)
            {
                ThongBao("Mã sinh viên không được để trống.");
                txtMaSV.Focus();
                return false;
            }

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
                        "Mã sinh viên chỉ gồm chữ không dấu, "
                        + "chữ số, dấu _ hoặc dấu -."
                    );

                    txtMaSV.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool KiemTraThongTin(out DateTime ngaySinh)
        {
            ngaySinh = default;

            if (!KiemTraMaSV())
            {
                return false;
            }

            if (cboLop.SelectedItem == null)
            {
                ThongBao("Hãy chọn lớp.");
                cboLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                ThongBao("Họ tên không được để trống.");
                txtHoTen.Focus();
                return false;
            }

            bool ngayHopLe = DateTime.TryParseExact(
                txtNgaySinh.Text.Trim(),
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out ngaySinh
            );

            if (!ngayHopLe)
            {
                ThongBao(
                    "Hãy nhập ngày sinh hợp lệ "
                    + "theo dạng dd/MM/yyyy."
                );

                txtNgaySinh.Focus();
                return false;
            }

            // Theo đề: chỉ tính tuổi theo năm sinh.
            int tuoi = DateTime.Today.Year - ngaySinh.Year;

            if (tuoi < 17)
            {
                ThongBao(
                    "Sinh viên phải từ 17 tuổi trở lên, "
                    + "tính theo năm sinh."
                );

                txtNgaySinh.Focus();
                return false;
            }

            return true;
        }

        private void GanThongTin(
            SqlCommand lenh, DateTime ngaySinh)
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
            ).Value = cboLop.SelectedItem!.ToString()!;
        }

        private void ThemSinhVien()
        {
            if (!KiemTraThongTin(out DateTime ngaySinh))
            {
                return;
            }

            XuLyCSDL(ketNoi =>
            {
                string maSV = txtMaSV.Text.Trim();
                string maLop = cboLop.SelectedItem!.ToString()!;

                // Chủ động kiểm tra khóa chính trước khi thêm.
                if (SinhVienTonTai(ketNoi, maSV))
                {
                    ThongBao("Mã sinh viên đã tồn tại.");
                    return;
                }

                // ComboBox đã nạp lớp nhưng vẫn kiểm tra lại
                // vì dữ liệu database có thể đã thay đổi.
                if (!LopTonTai(ketNoi, maLop))
                {
                    ThongBao(
                        "Lớp được chọn không còn tồn tại. "
                        + "Hãy mở lại Form để nạp danh sách lớp."
                    );

                    return;
                }

                string sql = @"
                    INSERT INTO dbo.SinhVien
                        (MaSinhVien, HoTen, NgaySinh, MaLop)
                    VALUES
                        (@MaSV, @HoTen, @NgaySinh, @MaLop);";

                using SqlCommand lenh =
                    new SqlCommand(sql, ketNoi);

                GanThongTin(lenh, ngaySinh);

                if (lenh.ExecuteNonQuery() > 0)
                {
                    ThanhCong("Thêm sinh viên thành công.");
                }
            });
        }

        private void XoaSinhVien()
        {
            // TH6b: xóa theo mã sinh viên.
            // Các ô khác không được dùng trong điều kiện xóa.
            if (!KiemTraMaSV())
            {
                return;
            }

            string maSV = txtMaSV.Text.Trim();

            DialogResult luaChon = MessageBox.Show(
                this,
                $"Bạn có muốn xóa sinh viên {maSV}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (luaChon != DialogResult.Yes)
            {
                return;
            }

            XuLyCSDL(ketNoi =>
            {
                if (!SinhVienTonTai(ketNoi, maSV))
                {
                    ThongBao("Mã sinh viên không tồn tại.");
                    return;
                }

                // Kiểm tra bảng con trước khi xóa.
                if (SinhVienDaCoDiem(ketNoi, maSV))
                {
                    ThongBao(
                        "Không thể xóa vì sinh viên "
                        + "đã có dữ liệu trong bảng Diem."
                    );

                    return;
                }

                string sql = @"
                    DELETE FROM dbo.SinhVien
                    WHERE MaSinhVien = @MaSV;";

                using SqlCommand lenh =
                    new SqlCommand(sql, ketNoi);

                lenh.Parameters.Add(
                    "@MaSV", SqlDbType.VarChar, 20
                ).Value = maSV;

                if (lenh.ExecuteNonQuery() > 0)
                {
                    ThanhCong("Xóa sinh viên thành công.");
                }
                else
                {
                    ThongBao("Sinh viên không còn tồn tại.");
                }
            });
        }

        private void SuaSinhVien()
        {
            // Khi sửa nhập đủ thông tin mới.
            // Giữ điều kiện tuổi hợp lệ cho dữ liệu sau cập nhật.
            if (!KiemTraThongTin(out DateTime ngaySinh))
            {
                return;
            }

            XuLyCSDL(ketNoi =>
            {
                string maSV = txtMaSV.Text.Trim();
                string maLop = cboLop.SelectedItem!.ToString()!;

                if (!SinhVienTonTai(ketNoi, maSV))
                {
                    ThongBao("Mã sinh viên không tồn tại.");
                    return;
                }

                if (!LopTonTai(ketNoi, maLop))
                {
                    ThongBao("Mã lớp được chọn không tồn tại.");
                    return;
                }

                string sql = @"
                    UPDATE dbo.SinhVien
                    SET HoTen = @HoTen,
                        NgaySinh = @NgaySinh,
                        MaLop = @MaLop
                    WHERE MaSinhVien = @MaSV;";

                using SqlCommand lenh =
                    new SqlCommand(sql, ketNoi);

                GanThongTin(lenh, ngaySinh);

                if (lenh.ExecuteNonQuery() > 0)
                {
                    ThanhCong("Sửa sinh viên thành công.");
                }
                else
                {
                    ThongBao("Sinh viên không còn tồn tại.");
                }
            });
        }
    }
}