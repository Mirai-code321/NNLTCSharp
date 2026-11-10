using System;
using System.Drawing;
using System.Windows.Forms;

public class frmUCLNBCNN : Form
{
    private readonly TextBox txtA = new TextBox();
    private readonly TextBox txtB = new TextBox();
    private readonly TextBox txtUCLN = new TextBox();
    private readonly TextBox txtBCNN = new TextBox();

    private readonly ErrorProvider errorProvider1 = new ErrorProvider();

    public frmUCLNBCNN()
    {
        // Thiết lập cửa sổ.
        Text = "Ước số - Bội số";
        ClientSize = new Size(580, 350);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Font = new Font("Tahoma", 11);

        errorProvider1.ContainerControl = this;
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        Label lblTieuDe = new Label
        {
            Text = "Ước Số Chung - Bội Số Chung",
            Font = new Font("Tahoma", 17, FontStyle.Bold),
            ForeColor = Color.Red,
            TextAlign = ContentAlignment.MiddleCenter,
            Bounds = new Rectangle(15, 15, 550, 45)
        };

        Controls.Add(lblTieuDe);

        ThemDong("Nhập số a:", txtA, 85);
        ThemDong("Nhập số b:", txtB, 130);
        ThemDong("Ước số chung lớn nhất:", txtUCLN, 180);
        ThemDong("Bội số chung nhỏ nhất:", txtBCNN, 225);

        txtA.TabIndex = 0;
        txtB.TabIndex = 1;

        // Các ô kết quả không cho phép nhập trực tiếp.
        txtUCLN.ReadOnly = true;
        txtBCNN.ReadOnly = true;
        txtUCLN.TabStop = false;
        txtBCNN.TabStop = false;

        Button btnThucHien = ThemButton("Thực hiện", 35);
        Button btnTiepTuc = ThemButton("Tiếp tục", 220);
        Button btnThoat = ThemButton("Thoát", 405);

        btnThucHien.TabIndex = 2;
        btnTiepTuc.TabIndex = 3;
        btnThoat.TabIndex = 4;

        btnThucHien.Click += btnThucHien_Click;
        btnTiepTuc.Click += btnTiepTuc_Click;
        btnThoat.Click += (sender, e) => Close();

        // Kiểm tra khi rời ô nhập.
        txtA.Leave += (sender, e) => KiemTraSo(txtA, out _);
        txtB.Leave += (sender, e) => KiemTraSo(txtB, out _);

        // Xóa kết quả cũ khi thay đổi dữ liệu.
        txtA.TextChanged += (sender, e) => XoaKetQua();
        txtB.TextChanged += (sender, e) => XoaKetQua();

        AcceptButton = btnThucHien;
        CancelButton = btnThoat;

        FormClosing += XacNhanThoat;
        Shown += (sender, e) => txtA.Focus();
    }

    private void ThemDong(string noiDung, TextBox textBox, int y)
    {
        Label label = new Label
        {
            Text = noiDung,
            AutoSize = true,
            Location = new Point(35, y + 4)
        };

        textBox.SetBounds(285, y, 240, 30);

        Controls.Add(label);
        Controls.Add(textBox);
    }

    private Button ThemButton(string noiDung, int x)
    {
        Button button = new Button
        {
            Text = noiDung,
            Bounds = new Rectangle(x, 290, 140, 40)
        };

        Controls.Add(button);
        return button;
    }

    private bool KiemTraSo(TextBox textBox, out int giaTri)
    {
        giaTri = 0;

        if (string.IsNullOrWhiteSpace(textBox.Text))
        {
            errorProvider1.SetError(
                textBox,
                "Bạn phải nhập một số nguyên.");

            return false;
        }

        // TryParse kiểm tra cả định dạng và phạm vi kiểu int.
        if (!int.TryParse(textBox.Text.Trim(), out giaTri))
        {
            errorProvider1.SetError(
                textBox,
                "Nhập số nguyên từ -2147483648 đến 2147483647.");

            return false;
        }

        errorProvider1.SetError(textBox, "");
        return true;
    }

    private static long TimUCLN(long a, long b)
    {
        // Thuật toán Euclid:
        // UCLN(a, b) = UCLN(b, a % b).
        while (b != 0)
        {
            long phanDu = a % b;
            a = b;
            b = phanDu;
        }

        return a;
    }

    private void btnThucHien_Click(object? sender, EventArgs e)
    {
        XoaKetQua();

        // Kiểm tra cả hai ô để hiển thị đầy đủ lỗi.
        bool aHopLe = KiemTraSo(txtA, out int a);
        bool bHopLe = KiemTraSo(txtB, out int b);

        if (!aHopLe || !bHopLe)
        {
            MessageBox.Show(
                "Dữ liệu chưa hợp lệ. Hãy nhập hai số nguyên.",
                "Lỗi nhập liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            if (!aHopLe)
                txtA.Focus();
            else
                txtB.Focus();

            return;
        }

        // Không xác định UCLN của hai số cùng bằng 0
        // theo phạm vi xử lý của bài tập này.
        if (a == 0 && b == 0)
        {
            errorProvider1.SetError(
                txtA,
                "Hai số không được đồng thời bằng 0.");

            errorProvider1.SetError(
                txtB,
                "Hai số không được đồng thời bằng 0.");

            MessageBox.Show(
                "Hai số không được đồng thời bằng 0.",
                "Lỗi dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtA.Focus();
            return;
        }

        // Chuyển sang long trước khi lấy trị tuyệt đối.
        // Cách này xử lý được cả giá trị int.MinValue.
        long soA = Math.Abs((long)a);
        long soB = Math.Abs((long)b);

        long ucln = TimUCLN(soA, soB);

        // BCNN = |a| / UCLN * |b|.
        // Chia trước khi nhân để giảm giá trị trung gian.
        // Với đầu vào int, kết quả nằm trong phạm vi long.
        long bcnn = (soA == 0 || soB == 0)
            ? 0
            : (soA / ucln) * soB;

        txtUCLN.Text = ucln.ToString();
        txtBCNN.Text = bcnn.ToString();
    }

    private void XoaKetQua()
    {
        txtUCLN.Clear();
        txtBCNN.Clear();
    }

    private void btnTiepTuc_Click(object? sender, EventArgs e)
    {
        // Trả form về trạng thái ban đầu.
        txtA.Clear();
        txtB.Clear();
        XoaKetQua();

        errorProvider1.Clear();
        txtA.Focus();
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