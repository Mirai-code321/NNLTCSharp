using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class frmDangKy : Form
{
    private readonly TextBox txtTenDangNhap = new TextBox();
    private readonly TextBox txtEmail = new TextBox();
    private readonly TextBox txtMatKhau = new TextBox();
    private readonly TextBox txtXacNhan = new TextBox();

    private readonly Button btnDangKy = new Button();
    private readonly ErrorProvider errorProvider1 = new ErrorProvider();

    public frmDangKy()
    {
        // Thiết lập cửa sổ đăng ký.
        Text = "Đăng ký tài khoản";
        ClientSize = new Size(560, 330);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Font = new Font("Tahoma", 11);

        errorProvider1.ContainerControl = this;
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        Label lblTieuDe = new Label
        {
            Text = "Đăng ký tài khoản",
            Font = new Font("Tahoma", 16, FontStyle.Bold),
            ForeColor = Color.DodgerBlue,
            TextAlign = ContentAlignment.MiddleCenter,
            Bounds = new Rectangle(20, 15, 520, 40)
        };

        Controls.Add(lblTieuDe);

        // Ba ô có (*) là các thông tin bắt buộc theo hình đề bài.
        ThemDong("Tên đăng nhập", txtTenDangNhap, 75, true);
        ThemDong("Địa chỉ email", txtEmail, 120, true);
        ThemDong("Mật khẩu", txtMatKhau, 165, true);
        ThemDong("Xác nhận mật khẩu", txtXacNhan, 210, false);

        txtTenDangNhap.TabIndex = 0;
        txtEmail.TabIndex = 1;
        txtMatKhau.TabIndex = 2;
        txtXacNhan.TabIndex = 3;

        // Che mật khẩu khi nhập.
        txtMatKhau.UseSystemPasswordChar = true;
        txtXacNhan.UseSystemPasswordChar = true;

        btnDangKy.Text = "Đăng ký";
        btnDangKy.SetBounds(200, 265, 280, 40);
        btnDangKy.ForeColor = Color.DodgerBlue;
        btnDangKy.TabIndex = 4;
        Controls.Add(btnDangKy);

        // Kiểm tra email khi người dùng rời khỏi ô email.
        txtEmail.Leave += (sender, e) => KiemTraEmail();

        // Kiểm tra các thông tin khác khi rời ô nhập.
        txtTenDangNhap.Leave += (sender, e) =>
            KiemTraBatBuoc(txtTenDangNhap, "tên đăng nhập");

        txtMatKhau.Leave += (sender, e) =>
            KiemTraBatBuoc(txtMatKhau, "mật khẩu");

        txtXacNhan.Leave += (sender, e) => KiemTraXacNhan();

        btnDangKy.Click += btnDangKy_Click;

        // Nhấn Enter sẽ thực hiện đăng ký,
        // bao gồm khi con trỏ ở ô xác nhận mật khẩu.
        AcceptButton = btnDangKy;

        FormClosing += frmDangKy_FormClosing;
        Shown += (sender, e) => txtTenDangNhap.Focus();
    }

    private void ThemDong(
        string noiDung,
        TextBox textBox,
        int y,
        bool batBuoc)
    {
        Label label = new Label
        {
            Text = noiDung,
            AutoSize = true,
            Location = new Point(25, y + 4)
        };

        textBox.SetBounds(200, y, 280, 30);

        Controls.Add(label);
        Controls.Add(textBox);

        if (batBuoc)
        {
            Label lblBatBuoc = new Label
            {
                Text = "(*)",
                AutoSize = true,
                Location = new Point(510, y + 4)
            };

            Controls.Add(lblBatBuoc);
        }
    }

    private bool KiemTraBatBuoc(TextBox textBox, string tenTruong)
    {
        // Không chấp nhận dữ liệu trống hoặc toàn khoảng trắng.
        if (string.IsNullOrWhiteSpace(textBox.Text))
        {
            errorProvider1.SetError(
                textBox,
                $"Bạn phải nhập {tenTruong}.");

            return false;
        }

        // Xóa lỗi của riêng ô đang kiểm tra.
        errorProvider1.SetError(textBox, "");
        return true;
    }

    private bool KiemTraEmail()
    {
        if (!KiemTraBatBuoc(txtEmail, "địa chỉ email"))
            return false;

        string email = txtEmail.Text.Trim();

        // Kiểm tra định dạng cơ bản:
        // có phần trước @, tên miền và phần sau dấu chấm.
        // Ví dụ hợp lệ: sinhvien@gmail.com
        bool hopLe = Regex.IsMatch(
            email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        if (!hopLe)
        {
            errorProvider1.SetError(
                txtEmail,
                "Email không đúng định dạng. Ví dụ: sinhvien@gmail.com");

            return false;
        }

        errorProvider1.SetError(txtEmail, "");
        return true;
    }

    private bool KiemTraXacNhan()
    {
        // Bổ sung kiểm tra khớp mật khẩu để tránh nhập nhầm.
        // So sánh nguyên văn, không Trim mật khẩu.
        if (txtXacNhan.Text != txtMatKhau.Text)
        {
            errorProvider1.SetError(
                txtXacNhan,
                "Xác nhận mật khẩu phải giống mật khẩu.");

            return false;
        }

        errorProvider1.SetError(txtXacNhan, "");
        return true;
    }

    private void btnDangKy_Click(object? sender, EventArgs e)
    {
        // Kiểm tra lại toàn bộ dữ liệu khi đăng ký.
        // Gọi riêng từng hàm để hiển thị đủ các lỗi.
        bool tenHopLe =
            KiemTraBatBuoc(txtTenDangNhap, "tên đăng nhập");

        bool emailHopLe = KiemTraEmail();

        bool matKhauHopLe =
            KiemTraBatBuoc(txtMatKhau, "mật khẩu");

        bool xacNhanHopLe = KiemTraXacNhan();

        if (!tenHopLe || !emailHopLe ||
            !matKhauHopLe || !xacNhanHopLe)
        {
            MessageBox.Show(
                "Thông tin chưa hợp lệ. Hãy kiểm tra các ô có biểu tượng lỗi.",
                "Lỗi nhập liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            // Đưa con trỏ về ô sai đầu tiên.
            if (!tenHopLe)
                txtTenDangNhap.Focus();
            else if (!emailHopLe)
                txtEmail.Focus();
            else if (!matKhauHopLe)
                txtMatKhau.Focus();
            else
                txtXacNhan.Focus();

            return;
        }

        // Hiển thị nội dung của tất cả TextBox theo đề bài.
        string thongTin =
            $"Tên đăng nhập: {txtTenDangNhap.Text.Trim()}\n" +
            $"Địa chỉ email: {txtEmail.Text.Trim()}\n" +
            $"Mật khẩu: {txtMatKhau.Text}\n" +
            $"Xác nhận mật khẩu: {txtXacNhan.Text}";

        MessageBox.Show(
            thongTin,
            "Thông tin đăng ký",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }

    private void frmDangKy_FormClosing(
        object? sender,
        FormClosingEventArgs e)
    {
        DialogResult luaChon = MessageBox.Show(
            "Bạn có muốn đóng form đăng ký không?",
            "Xác nhận thoát",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

        if (luaChon == DialogResult.No)
        {
            // Chọn No thì tiếp tục sử dụng form.
            e.Cancel = true;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            errorProvider1.Dispose();

        base.Dispose(disposing);
    }
}