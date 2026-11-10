using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class frmBanVe : Form
{
    // Trạng thái được lưu riêng, màu chỉ dùng để hiển thị.
    private enum TrangThaiGhe
    {
        ChuaBan,
        DangChon,
        DaBan
    }

    private readonly Button[] cacGhe = new Button[15];
    private readonly TrangThaiGhe[] trangThai = new TrangThaiGhe[15];
    private readonly Label lblThanhTien = new Label();

    public frmBanVe()
    {
        Text = "Quản lý bán vé rạp chiếu phim";
        ClientSize = new Size(660, 510);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Font = new Font("Tahoma", 11);

        Label lblManAnh = new Label
        {
            Text = "MÀN ẢNH",
            BackColor = Color.LightGray,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font("Tahoma", 16, FontStyle.Bold),
            Bounds = new Rectangle(105, 25, 510, 50)
        };

        Controls.Add(lblManAnh);

        // Tạo 3 hàng, mỗi hàng 5 ghế.
        for (int hang = 0; hang < 3; hang++)
        {
            Label lblHang = new Label
            {
                Text = ((char)('A' + hang)).ToString(),
                TextAlign = ContentAlignment.MiddleCenter,
                Bounds = new Rectangle(25, 100 + hang * 80, 60, 55)
            };

            Controls.Add(lblHang);

            for (int cot = 0; cot < 5; cot++)
            {
                int viTri = hang * 5 + cot;

                Button ghe = new Button
                {
                    Text = (viTri + 1).ToString(),
                    Tag = viTri,
                    Bounds = new Rectangle(
                        105 + cot * 105,
                        100 + hang * 80,
                        90,
                        55),

                    // Cho phép hiển thị màu nền do chương trình đặt.
                    UseVisualStyleBackColor = false,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat
                };

                ghe.Click += Ghe_Click;

                cacGhe[viTri] = ghe;
                trangThai[viTri] = TrangThaiGhe.ChuaBan;

                Controls.Add(ghe);
            }
        }

        ThemChuThich("Chưa bán", Color.White, 105);
        ThemChuThich("Đang chọn", Color.Blue, 280);
        ThemChuThich("Đã bán", Color.Yellow, 455);

        Label lblNhanTien = new Label
        {
            Text = "Thành tiền:",
            AutoSize = true,
            Location = new Point(105, 370)
        };

        lblThanhTien.Text = "0 đồng";
        lblThanhTien.Font = new Font("Tahoma", 13, FontStyle.Bold);
        lblThanhTien.SetBounds(250, 365, 365, 35);
        lblThanhTien.TextAlign = ContentAlignment.MiddleRight;

        Controls.Add(lblNhanTien);
        Controls.Add(lblThanhTien);

        Button btnChon = ThemButton("CHỌN", 105);
        Button btnHuy = ThemButton("HỦY BỎ", 280);
        Button btnThoat = ThemButton("THOÁT", 455);

        btnChon.Click += btnChon_Click;
        btnHuy.Click += btnHuy_Click;
        btnThoat.Click += (sender, e) => Close();

        CancelButton = btnThoat;
        FormClosing += XacNhanThoat;
    }

    private void ThemChuThich(string noiDung, Color mau, int x)
    {
        Panel oMau = new Panel
        {
            BackColor = mau,
            BorderStyle = BorderStyle.FixedSingle,
            Bounds = new Rectangle(x, 325, 25, 25)
        };

        Label label = new Label
        {
            Text = noiDung,
            AutoSize = true,
            Location = new Point(x + 35, 328)
        };

        Controls.Add(oMau);
        Controls.Add(label);
    }

    private Button ThemButton(string noiDung, int x)
    {
        Button button = new Button
        {
            Text = noiDung,
            Bounds = new Rectangle(x, 430, 160, 45)
        };

        Controls.Add(button);
        return button;
    }

    private void Ghe_Click(object? sender, EventArgs e)
    {
        if (sender is not Button ghe || ghe.Tag is not int viTri)
            return;

        switch (trangThai[viTri])
        {
            case TrangThaiGhe.ChuaBan:
                // Chọn một ghế chưa bán.
                trangThai[viTri] = TrangThaiGhe.DangChon;
                break;

            case TrangThaiGhe.DangChon:
                // Nhấn lại ghế đang chọn để bỏ chọn.
                trangThai[viTri] = TrangThaiGhe.ChuaBan;
                break;

            case TrangThaiGhe.DaBan:
                // Ghế đã bán không được chọn hoặc thay đổi.
                MessageBox.Show(
                    $"Ghế số {viTri + 1} đã được bán.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
        }

        CapNhatMauGhe(viTri);
    }

    private void CapNhatMauGhe(int viTri)
    {
        switch (trangThai[viTri])
        {
            case TrangThaiGhe.ChuaBan:
                cacGhe[viTri].BackColor = Color.White;
                cacGhe[viTri].ForeColor = Color.Black;
                break;

            case TrangThaiGhe.DangChon:
                cacGhe[viTri].BackColor = Color.Blue;
                cacGhe[viTri].ForeColor = Color.White;
                break;

            case TrangThaiGhe.DaBan:
                cacGhe[viTri].BackColor = Color.Yellow;
                cacGhe[viTri].ForeColor = Color.Black;
                break;
        }
    }

    private static int LayGiaVe(int viTri)
    {
        // Chỉ số mảng bắt đầu từ 0:
        // 0–4 là hàng A; 5–9 là hàng B; 10–14 là hàng C.
        if (viTri < 5)
            return 1000;

        if (viTri < 10)
            return 1500;

        return 2000;
    }

    private void btnChon_Click(object? sender, EventArgs e)
    {
        int tongTien = 0;
        int soVe = 0;

        // Tính tiền của những ghế đang chọn trong lần mua này.
        for (int i = 0; i < trangThai.Length; i++)
        {
            if (trangThai[i] == TrangThaiGhe.DangChon)
            {
                tongTien += LayGiaVe(i);
                soVe++;
            }
        }

        if (soVe == 0)
        {
            MessageBox.Show(
                "Bạn chưa chọn ghế nào.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        // Xác nhận bán: chuyển ghế xanh thành ghế vàng.
        for (int i = 0; i < trangThai.Length; i++)
        {
            if (trangThai[i] == TrangThaiGhe.DangChon)
            {
                trangThai[i] = TrangThaiGhe.DaBan;
                CapNhatMauGhe(i);
            }
        }

        lblThanhTien.Text =
            tongTien.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"))
            + " đồng";
    }

    private void btnHuy_Click(object? sender, EventArgs e)
    {
        // Chỉ hủy những ghế đang chọn.
        // Ghế đã bán vẫn giữ nguyên trạng thái.
        for (int i = 0; i < trangThai.Length; i++)
        {
            if (trangThai[i] == TrangThaiGhe.DangChon)
            {
                trangThai[i] = TrangThaiGhe.ChuaBan;
                CapNhatMauGhe(i);
            }
        }

        lblThanhTien.Text = "0 đồng";
    }

    private void XacNhanThoat(object? sender, FormClosingEventArgs e)
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