using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace NangCao01_DanhSachLop
{
    public class frmDanhSachLop : Form
    {
        private readonly ListView lvDanhSachLop;

        public frmDanhSachLop()
        {
            Text = "TH6b - Danh sách lớp";
            ClientSize = new Size(760, 470);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "DANH SÁCH LỚP";
            lblTieuDe.Font = new Font(
                "Segoe UI", 17, FontStyle.Bold
            );
            lblTieuDe.TextAlign =
                ContentAlignment.MiddleCenter;

            lblTieuDe.SetBounds(20, 15, 720, 45);
            Controls.Add(lblTieuDe);

            lvDanhSachLop = new ListView();
            lvDanhSachLop.View = View.Details;
            lvDanhSachLop.FullRowSelect = true;
            lvDanhSachLop.GridLines = true;
            lvDanhSachLop.HideSelection = false;
            lvDanhSachLop.MultiSelect = false;
            lvDanhSachLop.SetBounds(20, 80, 720, 290);

            // Các cột tương ứng với thông tin bảng Lop.
            lvDanhSachLop.Columns.Add("Mã lớp", 150);
            lvDanhSachLop.Columns.Add("Tên lớp", 390);
            lvDanhSachLop.Columns.Add("Mã khoa", 150);

            Controls.Add(lvDanhSachLop);

            Button btnHienThi = new Button();
            btnHienThi.Text = "&Hiển thị dữ liệu";
            btnHienThi.SetBounds(170, 400, 220, 42);
            btnHienThi.Click += (_, _) => HienThiDuLieu();
            Controls.Add(btnHienThi);

            Button btnThoat = new Button();
            btnThoat.Text = "T&hoát";
            btnThoat.SetBounds(430, 400, 160, 42);
            btnThoat.Click += (_, _) => Close();
            Controls.Add(btnThoat);

            AcceptButton = btnHienThi;
        }

        private void HienThiDuLieu()
        {
            try
            {
                // Đọc vào danh sách tạm trước.
                // Nếu truy vấn lỗi thì giữ nguyên nội dung đang hiển thị.
                List<ListViewItem> cacDong =
                    new List<ListViewItem>();

                using (SqlConnection ketNoi =
                    new SqlConnection(KetNoiCSDL.ChuoiKetNoi))
                {
                    string sql = @"
                        SELECT MaLop, TenLop, MaKhoa
                        FROM dbo.Lop
                        ORDER BY MaLop;";

                    using SqlCommand lenh =
                        new SqlCommand(sql, ketNoi);

                    ketNoi.Open();

                    using SqlDataReader reader =
                        lenh.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(
                            reader["MaLop"].ToString()!
                        );

                        item.SubItems.Add(
                            reader["TenLop"].ToString()!
                        );

                        item.SubItems.Add(
                            reader["MaKhoa"].ToString()!
                        );

                        cacDong.Add(item);
                    }
                }

                // Chỉ cập nhật ListView khi đã đọc thành công.
                lvDanhSachLop.BeginUpdate();

                try
                {
                    // Xóa dữ liệu hiển thị cũ, không xóa database.
                    lvDanhSachLop.Items.Clear();

                    lvDanhSachLop.Items.AddRange(
                        cacDong.ToArray()
                    );
                }
                finally
                {
                    lvDanhSachLop.EndUpdate();
                }

                if (cacDong.Count == 0)
                {
                    MessageBox.Show(
                        this,
                        "Bảng Lop chưa có dữ liệu.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    this,
                    "Không đọc được danh sách lớp.\n"
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
                "Lỗi kết nối",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }
}