using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace NangCao02_QuanLyDiem
{
    public class frmQuanLyDiem : Form
    {
        private readonly TextBox txtMaSV;
        private readonly TextBox txtMaMonHoc;
        private readonly TextBox txtDiem;

        public frmQuanLyDiem()
        {
            Text = "TH6a - Quản lý điểm";
            ClientSize = new Size(600, 330);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ThemLabel("Mã sinh viên", 25, 35);
            txtMaSV = ThemTextBox(200, 32, 360, 20);

            ThemLabel("Mã môn học", 25, 95);
            txtMaMonHoc = ThemTextBox(200, 92, 360, 20);

            ThemLabel("Điểm", 25, 155);
            txtDiem = ThemTextBox(200, 152, 360, 20);

            Label lblHuongDan = new Label();
            lblHuongDan.Text =
                "Điểm từ 0 đến 10. Ví dụ: 8.5 hoặc 8,5";
            lblHuongDan.SetBounds(200, 195, 380, 30);
            Controls.Add(lblHuongDan);

            ThemButton("&Thêm", 35, 260, ThemDiem);
            ThemButton("&Xóa", 225, 260, XoaDiem);
            ThemButton("&Sửa", 415, 260, SuaDiem);

            txtDiem.KeyPress += TxtDiem_KeyPress;

            Shown += (_, _) => txtMaSV.Focus();
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

        private bool KiemTraMa(
            TextBox textBox,
            string tenTruong)
        {
            string ma = textBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                ThongBao(tenTruong + " không được để trống.");
                textBox.Focus();
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

        private bool KiemTraHaiMa()
        {
            return KiemTraMa(txtMaSV, "Mã sinh viên")
                && KiemTraMa(txtMaMonHoc, "Mã môn học");
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
                // Cho phép thay thế đoạn đang chọn.
                string phanConLai = txtDiem.Text.Remove(
                    txtDiem.SelectionStart,
                    txtDiem.SelectionLength
                );

                // Chỉ cho nhập một dấu phân cách.
                e.Handled =
                    phanConLai.Contains('.')
                    || phanConLai.Contains(',');

                return;
            }

            e.Handled = true;
        }

        private bool DocDiem(out decimal diem)
        {
            diem = 0;

            string noiDung = txtDiem.Text.Trim();

            if (noiDung.Length == 0)
            {
                ThongBao("Điểm không được để trống.");
                txtDiem.Focus();
                return false;
            }

            // Kiểm tra cả dữ liệu dán vào TextBox:
            // chữ số, có thể có một dấu chấm hoặc phẩy,
            // tối đa hai chữ số sau dấu phân cách.
            bool dungDang = Regex.IsMatch(
                noiDung,
                @"\A[0-9]+([.,][0-9]{1,2})?\z"
            );

            string chuanHoa = noiDung.Replace(',', '.');

            if (!dungDang
                || !decimal.TryParse(
                    chuanHoa,
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture,
                    out diem))
            {
                ThongBao(
                    "Điểm phải là số, tối đa hai chữ số "
                    + "thập phân. Ví dụ: 8.5 hoặc 8,25."
                );

                txtDiem.Focus();
                txtDiem.SelectAll();
                return false;
            }

            if (diem < 0 || diem > 10)
            {
                ThongBao("Điểm phải nằm trong khoảng 0 đến 10.");
                txtDiem.Focus();
                txtDiem.SelectAll();
                return false;
            }

            return true;
        }

        private void XoaOInput()
        {
            txtMaSV.Clear();
            txtMaMonHoc.Clear();
            txtDiem.Clear();
            txtMaSV.Focus();
        }

        private void ThucHienLenh(
            string sql,
            string thaoTac,
            decimal? diem)
        {
            try
            {
                using SqlConnection ketNoi =
                    new SqlConnection(KetNoiCSDL.ChuoiKetNoi);

                using SqlCommand lenh =
                    new SqlCommand(sql, ketNoi);

                lenh.Parameters.Add(
                    "@MaSV",
                    SqlDbType.VarChar,
                    20
                ).Value = txtMaSV.Text.Trim();

                lenh.Parameters.Add(
                    "@MaMonHoc",
                    SqlDbType.VarChar,
                    20
                ).Value = txtMaMonHoc.Text.Trim();

                if (diem.HasValue)
                {
                    // Khớp với cột Diem DECIMAL(4,2).
                    SqlParameter thamSoDiem =
                        lenh.Parameters.Add(
                            "@Diem",
                            SqlDbType.Decimal
                        );

                    thamSoDiem.Precision = 4;
                    thamSoDiem.Scale = 2;
                    thamSoDiem.Value = diem.Value;
                }

                ketNoi.Open();

                int soDong = lenh.ExecuteNonQuery();

                if (soDong == 0)
                {
                    ThongBao(
                        "Không tìm thấy dòng điểm ứng với "
                        + "mã sinh viên và mã môn học đã nhập."
                    );

                    return;
                }

                MessageBox.Show(
                    this,
                    thaoTac + " điểm thành công.",
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
                    "Sinh viên đã có điểm của môn học này. "
                    + "Hãy dùng chức năng Sửa."
                );
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                ThongBao(
                    "Dữ liệu không thỏa ràng buộc database.\n"
                    + "Hãy kiểm tra mã sinh viên, mã môn học "
                    + "đã tồn tại và điểm từ 0 đến 10."
                );
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

        private void ThemDiem()
        {
            if (!KiemTraHaiMa()
                || !DocDiem(out decimal diem))
            {
                return;
            }

            string sql = @"
                INSERT INTO dbo.Diem
                    (MaSinhVien, MaMonHoc, Diem)
                VALUES
                    (@MaSV, @MaMonHoc, @Diem);";

            ThucHienLenh(sql, "Thêm", diem);
        }

        private void XoaDiem()
        {
            if (!KiemTraHaiMa())
            {
                return;
            }

            // Theo đề: khi xóa không nhập điểm.
            if (!string.IsNullOrWhiteSpace(txtDiem.Text))
            {
                ThongBao(
                    "Khi xóa, chỉ nhập mã sinh viên "
                    + "và mã môn học. Để trống ô điểm."
                );

                txtDiem.Focus();
                return;
            }

            DialogResult luaChon = MessageBox.Show(
                this,
                $"Xóa điểm môn {txtMaMonHoc.Text.Trim()}"
                    + $" của sinh viên {txtMaSV.Text.Trim()}?",
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
                DELETE FROM dbo.Diem
                WHERE MaSinhVien = @MaSV
                  AND MaMonHoc = @MaMonHoc;";

            ThucHienLenh(sql, "Xóa", null);
        }

        private void SuaDiem()
        {
            if (!KiemTraHaiMa()
                || !DocDiem(out decimal diem))
            {
                return;
            }

            // Chỉ đổi điểm, không đổi hai mã định danh.
            string sql = @"
                UPDATE dbo.Diem
                SET Diem = @Diem
                WHERE MaSinhVien = @MaSV
                  AND MaMonHoc = @MaMonHoc;";

            ThucHienLenh(sql, "Sửa", diem);
        }
    }
}