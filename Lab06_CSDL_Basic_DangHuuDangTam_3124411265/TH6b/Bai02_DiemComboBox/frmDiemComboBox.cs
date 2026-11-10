using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Bai02_DiemComboBox
{
    public class frmDiemComboBox : Form
    {
        private readonly ComboBox cboSinhVien;
        private readonly ComboBox cboMonHoc;
        private readonly TextBox txtDiem;

        public frmDiemComboBox()
        {
            Text = "TH6b - Quản lý điểm";
            ClientSize = new Size(600, 330);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ThemLabel("Sinh viên", 25, 35);
            cboSinhVien = ThemComboBox(200, 32);

            ThemLabel("Môn học", 25, 95);
            cboMonHoc = ThemComboBox(200, 92);

            ThemLabel("Điểm", 25, 155);

            txtDiem = new TextBox();
            txtDiem.MaxLength = 20;
            txtDiem.SetBounds(200, 152, 360, 30);
            Controls.Add(txtDiem);

            Label lblHuongDan = new Label();
            lblHuongDan.Text =
                "0 < Điểm < 10. Ví dụ: 8.5 hoặc 8,25";
            lblHuongDan.SetBounds(200, 195, 380, 30);
            Controls.Add(lblHuongDan);

            ThemButton("&Thêm", 35, ThemDiem);
            ThemButton("&Xóa", 225, XoaDiem);
            ThemButton("&Sửa", 415, SuaDiem);

            txtDiem.KeyPress += TxtDiem_KeyPress;

            // Đổi lựa chọn thì bỏ điểm cũ để tránh nhầm dữ liệu.
            cboSinhVien.SelectedIndexChanged +=
                (_, _) => txtDiem.Clear();

            cboMonHoc.SelectedIndexChanged +=
                (_, _) => txtDiem.Clear();

            Load += (_, _) => XuLyCSDL(NapDanhSach);
        }

        private void ThemLabel(string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.SetBounds(x, y, 160, 30);
            Controls.Add(label);
        }

        private ComboBox ThemComboBox(int x, int y)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.DropDownStyle =
                ComboBoxStyle.DropDownList;

            comboBox.SetBounds(x, y, 360, 32);
            Controls.Add(comboBox);

            return comboBox;
        }

        private void ThemButton(
            string text,
            int x,
            Action xuLy)
        {
            Button button = new Button();
            button.Text = text;
            button.SetBounds(x, 260, 150, 42);
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

            txtDiem.Clear();
            txtDiem.Focus();
        }

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
                ThongBao(
                    "Sinh viên đã có điểm của môn học này. "
                    + "Hãy sử dụng chức năng Sửa."
                );
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                ThongBao(
                    "Dữ liệu vi phạm ràng buộc database. "
                    + "Hãy kiểm tra sinh viên, môn học "
                    + "và giới hạn điểm."
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

        private void NapDanhSach(SqlConnection ketNoi)
        {
            cboSinhVien.Items.Clear();
            cboMonHoc.Items.Clear();

            // Dùng hai khối using để reader thứ nhất được
            // đóng trước khi thực hiện truy vấn thứ hai.
            using (SqlCommand lenh = new SqlCommand(
                @"SELECT MaSinhVien
                  FROM dbo.SinhVien
                  ORDER BY MaSinhVien;",
                ketNoi))
            {
                using SqlDataReader reader =
                    lenh.ExecuteReader();

                while (reader.Read())
                {
                    cboSinhVien.Items.Add(reader.GetString(0));
                }
            }

            using (SqlCommand lenh = new SqlCommand(
                @"SELECT MaMonHoc
                  FROM dbo.MonHoc
                  ORDER BY MaMonHoc;",
                ketNoi))
            {
                using SqlDataReader reader =
                    lenh.ExecuteReader();

                while (reader.Read())
                {
                    cboMonHoc.Items.Add(reader.GetString(0));
                }
            }

            if (cboSinhVien.Items.Count > 0)
            {
                cboSinhVien.SelectedIndex = 0;
            }

            if (cboMonHoc.Items.Count > 0)
            {
                cboMonHoc.SelectedIndex = 0;
            }

            if (cboSinhVien.Items.Count == 0
                || cboMonHoc.Items.Count == 0)
            {
                ThongBao(
                    "Cần có dữ liệu sinh viên và môn học "
                    + "trước khi quản lý điểm."
                );
            }
        }

        private bool CoDuLieu(
            SqlConnection ketNoi,
            string sql,
            string ma)
        {
            using SqlCommand lenh =
                new SqlCommand(sql, ketNoi);

            lenh.Parameters.Add(
                "@Ma",
                SqlDbType.VarChar,
                20
            ).Value = ma;

            using SqlDataReader reader = lenh.ExecuteReader();

            return reader.HasRows;
        }

        private bool KiemTraKhoaNgoai(SqlConnection ketNoi)
        {
            string maSV = cboSinhVien.SelectedItem!.ToString()!;
            string maMH = cboMonHoc.SelectedItem!.ToString()!;

            bool coSinhVien = CoDuLieu(
                ketNoi,
                @"SELECT TOP (1) MaSinhVien
                  FROM dbo.SinhVien
                  WHERE MaSinhVien = @Ma;",
                maSV
            );

            if (!coSinhVien)
            {
                ThongBao(
                    "Sinh viên không còn tồn tại. "
                    + "Hãy mở lại Form để nạp danh sách."
                );

                return false;
            }

            bool coMonHoc = CoDuLieu(
                ketNoi,
                @"SELECT TOP (1) MaMonHoc
                  FROM dbo.MonHoc
                  WHERE MaMonHoc = @Ma;",
                maMH
            );

            if (!coMonHoc)
            {
                ThongBao(
                    "Môn học không còn tồn tại. "
                    + "Hãy mở lại Form để nạp danh sách."
                );

                return false;
            }

            return true;
        }

        private void GanHaiMa(SqlCommand lenh)
        {
            lenh.Parameters.Add(
                "@MaSV",
                SqlDbType.VarChar,
                20
            ).Value = cboSinhVien.SelectedItem!.ToString()!;

            lenh.Parameters.Add(
                "@MaMH",
                SqlDbType.VarChar,
                20
            ).Value = cboMonHoc.SelectedItem!.ToString()!;
        }

        private bool DiemDaTonTai(SqlConnection ketNoi)
        {
            string sql = @"
                SELECT TOP (1) MaSinhVien
                FROM dbo.Diem
                WHERE MaSinhVien = @MaSV
                  AND MaMonHoc = @MaMH;";

            using SqlCommand lenh =
                new SqlCommand(sql, ketNoi);

            GanHaiMa(lenh);

            using SqlDataReader reader = lenh.ExecuteReader();

            return reader.HasRows;
        }

        private bool KiemTraLuaChon()
        {
            if (cboSinhVien.SelectedIndex < 0)
            {
                ThongBao("Hãy chọn sinh viên.");
                cboSinhVien.Focus();
                return false;
            }

            if (cboMonHoc.SelectedIndex < 0)
            {
                ThongBao("Hãy chọn môn học.");
                cboMonHoc.Focus();
                return false;
            }

            return true;
        }

        private void TxtDiem_KeyPress(
            object? sender,
            KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                return;
            }

            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                string conLai = txtDiem.Text.Remove(
                    txtDiem.SelectionStart,
                    txtDiem.SelectionLength
                );

                e.Handled =
                    conLai.Contains('.') || conLai.Contains(',');

                return;
            }

            e.Handled = true;
        }

        private bool DocDiem(out decimal diem)
        {
            diem = 0;

            string noiDung = txtDiem.Text.Trim();

            bool dungDang = Regex.IsMatch(
                noiDung,
                @"\A[0-9]+([.,][0-9]{1,2})?\z"
            );

            if (!dungDang
                || !decimal.TryParse(
                    noiDung.Replace(',', '.'),
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture,
                    out diem))
            {
                ThongBao(
                    "Hãy nhập điểm bằng số, tối đa hai "
                    + "chữ số thập phân. Ví dụ: 8.5 hoặc 8,25."
                );

                txtDiem.Focus();
                return false;
            }

            // Hiểu khoảng (0-10) trong đề là khoảng mở.
            if (diem <= 0 || diem >= 10)
            {
                ThongBao("Điểm phải lớn hơn 0 và nhỏ hơn 10.");
                txtDiem.Focus();
                return false;
            }

            return true;
        }

        private void GanThamSoDiem(
            SqlCommand lenh,
            decimal diem)
        {
            SqlParameter thamSo =
                lenh.Parameters.Add(
                    "@Diem",
                    SqlDbType.Decimal
                );

            thamSo.Precision = 4;
            thamSo.Scale = 2;
            thamSo.Value = diem;
        }

        private void ThemDiem()
        {
            if (!KiemTraLuaChon()
                || !DocDiem(out decimal diem))
            {
                return;
            }

            XuLyCSDL(ketNoi =>
            {
                if (!KiemTraKhoaNgoai(ketNoi))
                {
                    return;
                }

                // Kiểm tra khóa chính ghép trước khi thêm.
                if (DiemDaTonTai(ketNoi))
                {
                    ThongBao(
                        "Cặp sinh viên và môn học đã có điểm. "
                        + "Không thể thêm trùng."
                    );

                    return;
                }

                string sql = @"
                    INSERT INTO dbo.Diem
                        (MaSinhVien, MaMonHoc, Diem)
                    VALUES
                        (@MaSV, @MaMH, @Diem);";

                using SqlCommand lenh =
                    new SqlCommand(sql, ketNoi);

                GanHaiMa(lenh);
                GanThamSoDiem(lenh, diem);

                if (lenh.ExecuteNonQuery() > 0)
                {
                    ThanhCong("Thêm điểm thành công.");
                }
            });
        }

        private void XoaDiem()
        {
            if (!KiemTraLuaChon())
            {
                return;
            }

            DialogResult luaChon = MessageBox.Show(
                this,
                "Bạn có muốn xóa điểm của sinh viên "
                    + "trong môn học đang chọn?",
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
                if (!KiemTraKhoaNgoai(ketNoi))
                {
                    return;
                }

                if (!DiemDaTonTai(ketNoi))
                {
                    ThongBao(
                        "Chưa có điểm của sinh viên "
                        + "trong môn học này."
                    );

                    return;
                }

                string sql = @"
                    DELETE FROM dbo.Diem
                    WHERE MaSinhVien = @MaSV
                      AND MaMonHoc = @MaMH;";

                using SqlCommand lenh =
                    new SqlCommand(sql, ketNoi);

                GanHaiMa(lenh);

                if (lenh.ExecuteNonQuery() > 0)
                {
                    ThanhCong("Xóa điểm thành công.");
                }
                else
                {
                    ThongBao("Dòng điểm không còn tồn tại.");
                }
            });
        }

        private void SuaDiem()
        {
            if (!KiemTraLuaChon()
                || !DocDiem(out decimal diem))
            {
                return;
            }

            XuLyCSDL(ketNoi =>
            {
                if (!KiemTraKhoaNgoai(ketNoi))
                {
                    return;
                }

                if (!DiemDaTonTai(ketNoi))
                {
                    ThongBao(
                        "Chưa có dòng điểm để sửa. "
                        + "Hãy dùng chức năng Thêm."
                    );

                    return;
                }

                string sql = @"
                    UPDATE dbo.Diem
                    SET Diem = @Diem
                    WHERE MaSinhVien = @MaSV
                      AND MaMonHoc = @MaMH;";

                using SqlCommand lenh =
                    new SqlCommand(sql, ketNoi);

                GanHaiMa(lenh);
                GanThamSoDiem(lenh, diem);

                if (lenh.ExecuteNonQuery() > 0)
                {
                    ThanhCong("Sửa điểm thành công.");
                }
                else
                {
                    ThongBao("Dòng điểm không còn tồn tại.");
                }
            });
        }
    }
}