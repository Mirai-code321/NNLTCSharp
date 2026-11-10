using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class frmDaySo : Form
{
    // Lưu các số nguyên đã nhập theo đúng thứ tự.
    private readonly List<int> daySo = new List<int>();

    private readonly TextBox txtNhapSo = new TextBox();
    private readonly TextBox txtDaySo = new TextBox();
    private readonly TextBox txtTong = new TextBox();
    private readonly TextBox txtTongChan = new TextBox();
    private readonly TextBox txtTongLe = new TextBox();

    private readonly ErrorProvider errorProvider1 = new ErrorProvider();

    public frmDaySo()
    {
        Text = "Bài 4 - Xử lý dãy số nguyên";
        ClientSize = new Size(650, 420);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Font = new Font("Tahoma", 11);

        errorProvider1.ContainerControl = this;
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        Label lblTieuDe = new Label
        {
            Text = "NHẬP VÀ TÍNH TỔNG DÃY SỐ",
            Font = new Font("Tahoma", 16, FontStyle.Bold),
            ForeColor = Color.DodgerBlue,
            TextAlign = ContentAlignment.MiddleCenter,
            Bounds = new Rectangle(20, 15, 610, 40)
        };

        Controls.Add(lblTieuDe);

        ThemLabel("Nhập số:", 30, 80);
        txtNhapSo.SetBounds(160, 75, 280, 30);
        txtNhapSo.TabIndex = 0;
        Controls.Add(txtNhapSo);

        Button btnNhap = ThemButton("Nhập", 480, 73, 130);
        btnNhap.TabIndex = 1;

        ThemLabel("Dãy vừa nhập:", 30, 130);
        txtDaySo.SetBounds(160, 125, 450, 30);
        txtDaySo.ReadOnly = true;
        txtDaySo.TabStop = false;
        Controls.Add(txtDaySo);

        Button btnTong = ThemButton("Tính tổng", 30, 185, 160);
        Button btnTongChan = ThemButton("Tổng chẵn", 245, 185, 160);
        Button btnTongLe = ThemButton("Tổng lẻ", 460, 185, 160);

        btnTong.TabIndex = 2;
        btnTongChan.TabIndex = 3;
        btnTongLe.TabIndex = 4;

        TaoOketQua(txtTong, 30, 240);
        TaoOketQua(txtTongChan, 245, 240);
        TaoOketQua(txtTongLe, 460, 240);

        Button btnTiepTuc = ThemButton("Tiếp tục", 140, 330, 160);
        Button btnThoat = ThemButton("Thoát", 350, 330, 160);

        btnTiepTuc.TabIndex = 5;
        btnThoat.TabIndex = 6;

        // Gắn sự kiện cho các nút.
        btnNhap.Click += btnNhap_Click;
        btnTong.Click += (sender, e) => TinhTong(0);
        btnTongChan.Click += (sender, e) => TinhTong(1);
        btnTongLe.Click += (sender, e) => TinhTong(2);
        btnTiepTuc.Click += btnTiepTuc_Click;
        btnThoat.Click += (sender, e) => Close();

        // Khi sửa nội dung, xóa lỗi cũ của ô nhập.
        txtNhapSo.TextChanged += (sender, e) =>
            errorProvider1.SetError(txtNhapSo, "");

        // Nhấn Enter để thêm số; Esc để yêu cầu thoát.
        AcceptButton = btnNhap;
        CancelButton = btnThoat;

        FormClosing += XacNhanThoat;
        Shown += (sender, e) => txtNhapSo.Focus();
    }

    private void ThemLabel(string noiDung, int x, int y)
    {
        Label label = new Label
        {
            Text = noiDung,
            AutoSize = true,
            Location = new Point(x, y)
        };

        Controls.Add(label);
    }

    private Button ThemButton(
        string noiDung,
        int x,
        int y,
        int width)
    {
        Button button = new Button
        {
            Text = noiDung,
            Bounds = new Rectangle(x, y, width, 40)
        };

        Controls.Add(button);
        return button;
    }

    private void TaoOketQua(TextBox textBox, int x, int y)
    {
        textBox.SetBounds(x, y, 160, 30);
        textBox.ReadOnly = true;
        textBox.TabStop = false;
        textBox.TextAlign = HorizontalAlignment.Center;

        Controls.Add(textBox);
    }

    private void btnNhap_Click(object? sender, EventArgs e)
    {
        // Kiểm tra số nguyên và phạm vi kiểu int.
        if (!int.TryParse(txtNhapSo.Text.Trim(), out int so))
        {
            errorProvider1.SetError(
                txtNhapSo,
                "Hãy nhập số nguyên từ -2147483648 đến 2147483647.");

            MessageBox.Show(
                "Dữ liệu không hợp lệ. Bạn phải nhập một số nguyên.",
                "Lỗi nhập liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtNhapSo.Focus();
            txtNhapSo.SelectAll();
            return;
        }

        // Chỉ thêm vào danh sách sau khi kiểm tra thành công.
        daySo.Add(so);

        // Hiển thị toàn bộ dãy theo thứ tự đã nhập.
        txtDaySo.Text = string.Join("  ", daySo);

        // Dãy đã thay đổi nên kết quả cũ không còn phù hợp.
        XoaKetQua();

        txtNhapSo.Clear();
        errorProvider1.SetError(txtNhapSo, "");
        txtNhapSo.Focus();
    }

    private void TinhTong(int loai)
    {
        // Không thực hiện tính khi chưa nhập số nào.
        if (daySo.Count == 0)
        {
            MessageBox.Show(
                "Bạn phải nhập ít nhất một số vào dãy.",
                "Chưa có dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtNhapSo.Focus();
            return;
        }

        // Dùng long để chứa tổng của các số int.
        long tong = 0;

        foreach (int so in daySo)
        {
            bool canCong = loai == 0 ||
                           (loai == 1 && so % 2 == 0) ||
                           (loai == 2 && so % 2 != 0);

            if (canCong)
                tong += so;
        }

        // loai = 0: tổng tất cả; 1: tổng chẵn; 2: tổng lẻ.
        switch (loai)
        {
            case 0:
                txtTong.Text = tong.ToString();
                break;

            case 1:
                txtTongChan.Text = tong.ToString();
                break;

            case 2:
                txtTongLe.Text = tong.ToString();
                break;
        }
    }

    private void XoaKetQua()
    {
        txtTong.Clear();
        txtTongChan.Clear();
        txtTongLe.Clear();
    }

    private void btnTiepTuc_Click(object? sender, EventArgs e)
    {
        // Xóa cả dữ liệu lưu trong danh sách và trên giao diện.
        daySo.Clear();

        txtNhapSo.Clear();
        txtDaySo.Clear();
        XoaKetQua();

        errorProvider1.Clear();
        txtNhapSo.Focus();
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

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            errorProvider1.Dispose();

        base.Dispose(disposing);
    }
}