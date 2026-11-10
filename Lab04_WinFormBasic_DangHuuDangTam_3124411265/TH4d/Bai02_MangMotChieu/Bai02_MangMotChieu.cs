using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai02_MangMotChieu
{
    public class frmMangMotChieu : Form
    {
        private MangMotChieu mang = new MangMotChieu();

        private readonly TextBox txtNhapMang = new TextBox();
        private readonly TextBox txtMangHienTai = new TextBox();
        private readonly TextBox txtGiaTri = new TextBox();
        private readonly TextBox txtViTri = new TextBox();
        private readonly TextBox txtGiaTriMoi = new TextBox();
        private readonly TextBox txtKetQua = new TextBox();

        public frmMangMotChieu()
        {
            Text = "Bài 2 - Mảng một chiều";
            ClientSize = new Size(850, 600);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Font = new Font("Tahoma", 10);

            ThemLabel("XỬ LÝ MẢNG MỘT CHIỀU", 245, 15);

            ThemLabel("Nhập mảng:", 20, 60);
            ThemTextBox(txtNhapMang, 140, 55, 520);

            ThemNut("Nhập mảng", 680, 53, 145, NhapMang);

            ThemLabel(
                "Ví dụ: 5 2 -3 8 2. Phân cách bằng khoảng trắng, dấu phẩy hoặc dấu chấm phẩy.",
                20, 95);

            ThemLabel("Mảng hiện tại:", 20, 140);
            ThemTextBox(txtMangHienTai, 140, 135, 685);
            txtMangHienTai.ReadOnly = true;

            ThemLabel("Giá trị tìm / giá trị cũ:", 20, 195);
            ThemTextBox(txtGiaTri, 210, 190, 130);

            ThemLabel("Vị trí (từ 0):", 365, 195);
            ThemTextBox(txtViTri, 470, 190, 100);

            ThemLabel("Giá trị mới:", 590, 195);
            ThemTextBox(txtGiaTriMoi, 695, 190, 130);

            ThemNut("Sắp xếp tăng", 20, 245, 180, () =>
            {
                CanCoMang();
                mang.SapXepTang();
                CapNhatMang();
                txtKetQua.Text = "Đã sắp xếp tăng dần.";
            });

            ThemNut("Sắp xếp giảm", 225, 245, 180, () =>
            {
                CanCoMang();
                mang.SapXepGiam();
                CapNhatMang();
                txtKetQua.Text = "Đã sắp xếp giảm dần.";
            });

            ThemNut("Tìm vị trí theo giá trị", 430, 245, 190, () =>
            {
                CanCoMang();

                int giaTri = DocSo(txtGiaTri, "giá trị cần tìm");
                int[] viTri = mang.TimViTri(giaTri);

                txtKetQua.Text = viTri.Length == 0
                    ? $"Không tìm thấy giá trị {giaTri}."
                    : $"Giá trị {giaTri} tại vị trí: " +
                      string.Join(", ", viTri);
            });

            ThemNut("Lấy giá trị tại vị trí", 635, 245, 190, () =>
            {
                CanCoMang();
                int viTri = DocSo(txtViTri, "vị trí");

                txtKetQua.Text =
                    $"Giá trị tại vị trí {viTri}: {mang.LayGiaTri(viTri)}";
            });

            ThemNut("Chèn tại vị trí", 20, 300, 240, () =>
            {
                int viTri = DocSo(txtViTri, "vị trí chèn");
                int giaTri = DocSo(txtGiaTriMoi, "giá trị mới");

                mang.Chen(viTri, giaTri);
                CapNhatMang();

                txtKetQua.Text =
                    $"Đã chèn {giaTri} tại vị trí {viTri}.";
            });

            ThemNut("Thay thế tại vị trí", 290, 300, 240, () =>
            {
                CanCoMang();

                int viTri = DocSo(txtViTri, "vị trí");
                int giaTri = DocSo(txtGiaTriMoi, "giá trị mới");

                mang.ThayTheTaiViTri(viTri, giaTri);
                CapNhatMang();

                txtKetQua.Text =
                    $"Đã thay vị trí {viTri} bằng {giaTri}.";
            });

            ThemNut("Thay thế theo giá trị", 560, 300, 265, () =>
            {
                CanCoMang();

                int giaTriCu = DocSo(txtGiaTri, "giá trị cũ");
                int giaTriMoi = DocSo(txtGiaTriMoi, "giá trị mới");

                int soLan = mang.ThayTheTheoGiaTri(
                    giaTriCu, giaTriMoi);

                CapNhatMang();

                txtKetQua.Text = soLan == 0
                    ? $"Không có giá trị {giaTriCu} để thay."
                    : $"Đã thay {soLan} phần tử từ " +
                      $"{giaTriCu} thành {giaTriMoi}.";
            });

            ThemNut("Tổng", 20, 355, 145,
                () => HienTong(0, "Tổng mảng"));

            ThemNut("Tổng chẵn", 185, 355, 145,
                () => HienTong(1, "Tổng chẵn"));

            ThemNut("Tổng lẻ", 350, 355, 145,
                () => HienTong(2, "Tổng lẻ"));

            ThemNut("Lớn nhất", 515, 355, 145, () =>
            {
                CanCoMang();
                txtKetQua.Text = $"Lớn nhất: {mang.LonNhat()}";
            });

            ThemNut("Nhỏ nhất", 680, 355, 145, () =>
            {
                CanCoMang();
                txtKetQua.Text = $"Nhỏ nhất: {mang.NhoNhat()}";
            });

            ThemLabel("Kết quả:", 20, 420);
            ThemTextBox(txtKetQua, 140, 415, 685);
            txtKetQua.Height = 85;
            txtKetQua.Multiline = true;
            txtKetQua.ReadOnly = true;

            ThemNut("Nhập mới", 225, 535, 180, NhapMoi);
            ThemNut("Thoát", 445, 535, 180, () => Close());

            FormClosing += XacNhanThoat;
            Shown += (sender, e) => txtNhapMang.Focus();
        }

        private void ThemLabel(string noiDung, int x, int y)
        {
            Controls.Add(new Label
            {
                Text = noiDung,
                AutoSize = true,
                Location = new Point(x, y)
            });
        }

        private void ThemTextBox(
            TextBox textBox, int x, int y, int width)
        {
            textBox.SetBounds(x, y, width, 30);
            Controls.Add(textBox);
        }

        private void ThemNut(
            string noiDung,
            int x,
            int y,
            int width,
            Action xuLy)
        {
            Button nut = new Button
            {
                Text = noiDung,
                Bounds = new Rectangle(x, y, width, 40)
            };

            nut.Click += (sender, e) =>
            {
                txtKetQua.Clear();

                try
                {
                    xuLy();
                }
                catch (ArgumentException ex)
                {
                    BaoLoi(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    BaoLoi(ex.Message);
                }
            };

            Controls.Add(nut);
        }

        private void NhapMang()
        {
            string[] cacPhanTu = txtNhapMang.Text.Split(
                new char[] { ' ', ',', ';', '\t', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            if (cacPhanTu.Length == 0)
            {
                throw new ArgumentException(
                    "Hãy nhập ít nhất một số nguyên.");
            }

            int[] cacSo = new int[cacPhanTu.Length];

            // Chỉ thay mảng cũ khi tất cả phần tử hợp lệ.
            for (int i = 0; i < cacPhanTu.Length; i++)
            {
                if (!int.TryParse(cacPhanTu[i], out cacSo[i]))
                {
                    throw new ArgumentException(
                        $"'{cacPhanTu[i]}' không phải số nguyên hợp lệ.");
                }
            }

            mang = new MangMotChieu(cacSo);
            CapNhatMang();

            txtKetQua.Text = $"Đã nhập {mang.SoLuong} phần tử.";
        }

        private static int DocSo(TextBox textBox, string tenTruong)
        {
            if (!int.TryParse(textBox.Text.Trim(), out int so))
            {
                textBox.Focus();
                textBox.SelectAll();

                throw new ArgumentException(
                    $"Hãy nhập số nguyên hợp lệ cho {tenTruong}.");
            }

            return so;
        }

        private void CanCoMang()
        {
            if (mang.SoLuong == 0)
            {
                throw new InvalidOperationException(
                    "Mảng chưa có dữ liệu. Hãy nhập mảng trước.");
            }
        }

        private void CapNhatMang()
        {
            txtMangHienTai.Text = mang.ToString();
        }

        private void HienTong(int loai, string tenTong)
        {
            CanCoMang();
            txtKetQua.Text = $"{tenTong}: {mang.TinhTong(loai)}";
        }

        private void NhapMoi()
        {
            mang = new MangMotChieu();

            txtNhapMang.Clear();
            txtMangHienTai.Clear();
            txtGiaTri.Clear();
            txtViTri.Clear();
            txtGiaTriMoi.Clear();
            txtKetQua.Clear();

            txtNhapMang.Focus();
        }

        private void BaoLoi(string thongBao)
        {
            MessageBox.Show(
                thongBao,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        private void XacNhanThoat(
            object? sender, FormClosingEventArgs e)
        {
            DialogResult luaChon = MessageBox.Show(
                "Bạn có muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            e.Cancel = luaChon == DialogResult.No;
        }
    }
}