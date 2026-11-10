using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace NangCao02_LocDiem
{
    public class frmLocDiem : Form
    {
        private readonly ComboBox cboMonHoc;
        private readonly ListView lvDiem;
        private readonly TextBox txtTongDiem;

        private readonly CultureInfo vanHoa =
            CultureInfo.GetCultureInfo("vi-VN");

        public frmLocDiem()
        {
            Text = "TH6b - Lọc điểm theo môn học";
            ClientSize = new Size(1000, 570);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblMonHoc = new Label();
            lblMonHoc.Text = "Môn học";
            lblMonHoc.SetBounds(25, 30, 110, 30);
            Controls.Add(lblMonHoc);

            cboMonHoc = new ComboBox();
            cboMonHoc.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cboMonHoc.SetBounds(140, 27, 290, 32);
            Controls.Add(cboMonHoc);

            Button btnLoc = new Button();
            btnLoc.Text = "&Lọc dữ liệu";
            btnLoc.SetBounds(460, 24, 180, 40);
            btnLoc.Click += (_, _) => LocDuLieu();
            Controls.Add(btnLoc);

            Label lblHuongDan = new Label();
            lblHuongDan.Text =
                "Chọn mục trống để hiển thị tất cả môn học.";
            lblHuongDan.SetBounds(25, 80, 900, 30);
            Controls.Add(lblHuongDan);

            lvDiem = new ListView();
            lvDiem.View = View.Details;
            lvDiem.GridLines = true;
            lvDiem.FullRowSelect = true;
            lvDiem.HideSelection = false;
            lvDiem.MultiSelect = false;
            lvDiem.SetBounds(25, 125, 950, 335);

            lvDiem.Columns.Add("STT", 60);
            lvDiem.Columns.Add("Tên sinh viên", 260);
            lvDiem.Columns.Add("Ngày sinh", 140);
            lvDiem.Columns.Add("Tên môn học", 340);
            lvDiem.Columns.Add(
                "Điểm", 120, HorizontalAlignment.Right
            );

            Controls.Add(lvDiem);

            Label lblTong = new Label();
            lblTong.Text = "Tổng điểm";
            lblTong.SetBounds(25, 505, 120, 30);
            Controls.Add(lblTong);

            txtTongDiem = new TextBox();
            txtTongDiem.ReadOnly = true;
            txtTongDiem.TextAlign = HorizontalAlignment.Right;
            txtTongDiem.Text = "0";
            txtTongDiem.SetBounds(150, 502, 200, 30);
            Controls.Add(txtTongDiem);

            Button btnThoat = new Button();
            btnThoat.Text = "T&hoát";
            btnThoat.SetBounds(815, 495, 160, 42);
            btnThoat.Click += (_, _) => Close();
            Controls.Add(btnThoat);

            AcceptButton = btnLoc;

            Load += (_, _) =>
            {
                XuLyCSDL(ketNoi =>
                {
                    NapMonHoc(ketNoi);

                    // Khi mở Form: hiển thị tất cả môn học.
                    HienThiDiem(ketNoi, null);
                });
            };
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
            {
                MessageBox.Show(
                    this,
                    "Không đọc được dữ liệu SQL Server.\n"
                        + "Hãy kiểm tra kết nối và database.\n\n"
                        + ex.Message,
                    "Lỗi SQL Server",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (InvalidOperationException ex)
            {
                ThongBaoLoi(ex.Message);
            }
            catch (ArgumentException ex)
            {
                ThongBaoLoi(ex.Message);
            }
        }

        private void ThongBaoLoi(string noiDung)
        {
            MessageBox.Show(
                this,
                noiDung,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void NapMonHoc(SqlConnection ketNoi)
        {
            // Đọc thành công rồi mới cập nhật ComboBox.
            List<string> cacMa = new List<string>();

            string sql = @"
                SELECT MaMonHoc
                FROM dbo.MonHoc
                ORDER BY MaMonHoc;";

            using (SqlCommand lenh =
                new SqlCommand(sql, ketNoi))
            {
                using SqlDataReader reader =
                    lenh.ExecuteReader();

                while (reader.Read())
                {
                    cacMa.Add(reader.GetString(0));
                }
            }

            cboMonHoc.Items.Clear();

            // Mục trống có nghĩa là tất cả môn học.
            cboMonHoc.Items.Add("");

            foreach (string ma in cacMa)
            {
                cboMonHoc.Items.Add(ma);
            }

            cboMonHoc.SelectedIndex = 0;
        }

        private void LocDuLieu()
        {
            if (cboMonHoc.SelectedIndex < 0)
            {
                MessageBox.Show(
                    this,
                    "Hãy chọn môn học hoặc mục trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string luaChon =
                cboMonHoc.SelectedItem!.ToString()!;

            // null đại diện cho tất cả môn học.
            string? maMonHoc =
                string.IsNullOrWhiteSpace(luaChon)
                    ? null
                    : luaChon;

            XuLyCSDL(ketNoi =>
                HienThiDiem(ketNoi, maMonHoc)
            );
        }

        private void HienThiDiem(
            SqlConnection ketNoi,
            string? maMonHoc)
        {
            // Danh sách tạm giúp giữ dữ liệu cũ nếu truy vấn lỗi.
            List<ListViewItem> cacDong =
                new List<ListViewItem>();

            decimal tongDiem = 0;

            string sql = @"
                SELECT
                    sv.HoTen,
                    sv.NgaySinh,
                    mh.TenMonHoc,
                    d.Diem
                FROM dbo.Diem AS d
                INNER JOIN dbo.SinhVien AS sv
                    ON d.MaSinhVien = sv.MaSinhVien
                INNER JOIN dbo.MonHoc AS mh
                    ON d.MaMonHoc = mh.MaMonHoc
                WHERE
                    @MaMonHoc IS NULL
                    OR d.MaMonHoc = @MaMonHoc
                ORDER BY
                    sv.MaSinhVien,
                    d.MaMonHoc;";

            using (SqlCommand lenh =
                new SqlCommand(sql, ketNoi))
            {
                lenh.Parameters.Add(
                    "@MaMonHoc",
                    SqlDbType.VarChar,
                    20
                ).Value = maMonHoc == null
                    ? (object)DBNull.Value
                    : maMonHoc;

                using SqlDataReader reader =
                    lenh.ExecuteReader();

                int stt = 1;

                while (reader.Read())
                {
                    string hoTen = reader.GetString(0);
                    DateTime ngaySinh = reader.GetDateTime(1);
                    string tenMonHoc = reader.GetString(2);
                    decimal diem = reader.GetDecimal(3);

                    ListViewItem item = new ListViewItem(
                        new[]
                        {
                            stt.ToString(),
                            hoTen,
                            ngaySinh.ToString(
                                "dd/MM/yyyy",
                                CultureInfo.InvariantCulture
                            ),
                            tenMonHoc,
                            diem.ToString("0.##", vanHoa)
                        }
                    );

                    cacDong.Add(item);
                    tongDiem += diem;
                    stt++;
                }
            }

            lvDiem.BeginUpdate();

            try
            {
                // Xóa nội dung hiển thị cũ, không xóa database.
                lvDiem.Items.Clear();
                lvDiem.Items.AddRange(cacDong.ToArray());

                // Tổng được tính từ đúng các dòng vừa đọc.
                txtTongDiem.Text =
                    tongDiem.ToString("0.##", vanHoa);
            }
            finally
            {
                lvDiem.EndUpdate();
            }
        }
    }
}