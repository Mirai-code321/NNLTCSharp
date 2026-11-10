using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class frmPhepTinh : Form
{
    private readonly TextBox txtA = new TextBox();
    private readonly TextBox txtB = new TextBox();
    private readonly TextBox txtKetQua = new TextBox();
    private readonly ErrorProvider errorProvider1 = new ErrorProvider();

    public frmPhepTinh()
    {
        // Thiết lập cửa sổ chương trình.
        Text = "Bài 1 - Các phép tính";
        ClientSize = new Size(470, 280);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Font = new Font("Tahoma", 11);

        errorProvider1.ContainerControl = this;
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        // Tạo các nhãn và ô nhập dữ liệu.
        ThemLabel("Số a:", 30, 30);
        ThemLabel("Số b:", 30, 75);
        ThemLabel("Kết quả:", 30, 120);

        txtA.SetBounds(130, 25, 290, 30);
        txtB.SetBounds(130, 70, 290, 30);
        txtKetQua.SetBounds(130, 115, 290, 30);

        txtA.TabIndex = 0;
        txtB.TabIndex = 1;

        // Kết quả chỉ được xuất bởi chương trình.
        txtKetQua.ReadOnly = true;
        txtKetQua.TabStop = false;

        Controls.AddRange(new Control[]
        {
            txtA, txtB, txtKetQua
        });

        // Tạo các nút phép tính.
        Button btnCong = ThemButton("+", 30, 170, 90);
        Button btnTru = ThemButton("-", 135, 170, 90);
        Button btnNhan = ThemButton("×", 240, 170, 90);
        Button btnChia = ThemButton("÷", 345, 170, 90);
        Button btnThoat = ThemButton("Thoát", 345, 220, 90);

        btnCong.TabIndex = 2;
        btnTru.TabIndex = 3;
        btnNhan.TabIndex = 4;
        btnChia.TabIndex = 5;
        btnThoat.TabIndex = 6;

        // Mỗi nút gọi cùng một hàm với phép toán tương ứng.
        btnCong.Click += (sender, e) => TinhToan('+');
        btnTru.Click += (sender, e) => TinhToan('-');
        btnNhan.Click += (sender, e) => TinhToan('*');
        btnChia.Click += (sender, e) => TinhToan('/');
        btnThoat.Click += (sender, e) => Close();

        // Mức 2: chặn ký tự không phù hợp khi gõ bàn phím.
        txtA.KeyPress += ChiChoNhapSo;
        txtB.KeyPress += ChiChoNhapSo;

        // Mức 1: kiểm tra toàn bộ dữ liệu, kể cả dữ liệu dán vào.
        txtA.TextChanged += (sender, e) => DuLieuThayDoi(txtA);
        txtB.TextChanged += (sender, e) => DuLieuThayDoi(txtB);

        FormClosing += XacNhanThoat;
        Shown += (sender, e) => txtA.Focus();

        CancelButton = btnThoat;
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

    private Button ThemButton(string noiDung, int x, int y, int width)
    {
        Button button = new Button
        {
            Text = noiDung,
            Location = new Point(x, y),
            Size = new Size(width, 35)
        };

        Controls.Add(button);
        return button;
    }

    private void ChiChoNhapSo(object? sender, KeyPressEventArgs e)
    {
        if (sender is not TextBox textBox)
            return;

        // Cho phép Backspace và các phím điều khiển.
        if (char.IsControl(e.KeyChar))
            return;

        // Chỉ cho phép chữ số, dấu âm và dấu thập phân.
        bool kyTuHopLe =
            (e.KeyChar >= '0' && e.KeyChar <= '9') ||
            e.KeyChar == '-' ||
            e.KeyChar == '.' ||
            e.KeyChar == ',';

        if (!kyTuHopLe)
        {
            e.Handled = true;
            return;
        }

        // Tính nội dung sau khi chèn ký tự hoặc thay vùng được chọn.
        string noiDungMoi = textBox.Text
            .Remove(textBox.SelectionStart, textBox.SelectionLength)
            .Insert(textBox.SelectionStart, e.KeyChar.ToString());

        int soDauAm = 0;
        int soDauThapPhan = 0;

        for (int i = 0; i < noiDungMoi.Length; i++)
        {
            char c = noiDungMoi[i];

            if (c == '-')
            {
                soDauAm++;

                // Dấu âm chỉ được nằm đầu chuỗi.
                if (i != 0 || soDauAm > 1)
                {
                    e.Handled = true;
                    return;
                }
            }
            else if (c == '.' || c == ',')
            {
                soDauThapPhan++;

                if (soDauThapPhan > 1)
                {
                    e.Handled = true;
                    return;
                }
            }
            else if (c < '0' || c > '9')
            {
                e.Handled = true;
                return;
            }
        }
    }

    private bool KiemTraSo(TextBox textBox, out double giaTri)
    {
        giaTri = 0;

        if (string.IsNullOrWhiteSpace(textBox.Text))
        {
            errorProvider1.SetError(textBox, "Bạn phải nhập số.");
            return false;
        }

        // Chấp nhận dấu chấm hoặc dấu phẩy làm dấu thập phân.
        // Ví dụ: 2.5 hoặc 2,5 đều được hiểu là hai phẩy năm.
        string duLieu = textBox.Text.Trim().Replace(',', '.');

        bool hopLe = double.TryParse(
            duLieu,
            NumberStyles.AllowLeadingSign |
            NumberStyles.AllowDecimalPoint,
            CultureInfo.InvariantCulture,
            out giaTri);

        if (!hopLe || double.IsNaN(giaTri) || double.IsInfinity(giaTri))
        {
            errorProvider1.SetError(textBox, "Dữ liệu phải là số hợp lệ.");
            return false;
        }

        errorProvider1.SetError(textBox, "");
        return true;
    }

    private void DuLieuThayDoi(TextBox textBox)
    {
        // Xóa kết quả cũ khi người dùng sửa dữ liệu đầu vào.
        txtKetQua.Clear();
        KiemTraSo(textBox, out _);
    }

    private void TinhToan(char phepToan)
    {
        txtKetQua.Clear();

        // Kiểm tra cả hai ô trước khi thực hiện phép tính.
        bool aHopLe = KiemTraSo(txtA, out double a);
        bool bHopLe = KiemTraSo(txtB, out double b);

        if (!aHopLe || !bHopLe)
        {
            MessageBox.Show(
                "Bạn hãy nhập số a và số b hợp lệ.",
                "Lỗi nhập liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            if (!aHopLe)
                txtA.Focus();
            else
                txtB.Focus();

            return;
        }

        // Không được chia cho 0.
        if (phepToan == '/' && b == 0)
        {
            errorProvider1.SetError(txtB, "Số chia phải khác 0.");

            MessageBox.Show(
                "Không thể chia cho 0.",
                "Lỗi phép tính",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtB.Focus();
            return;
        }

        double ketQua;

        switch (phepToan)
        {
            case '+':
                ketQua = a + b;
                break;

            case '-':
                ketQua = a - b;
                break;

            case '*':
                ketQua = a * b;
                break;

            case '/':
                ketQua = a / b;
                break;

            default:
                return;
        }

        // Kiểm tra kết quả vượt phạm vi của kiểu double.
        if (double.IsInfinity(ketQua) || double.IsNaN(ketQua))
        {
            MessageBox.Show(
                "Kết quả vượt phạm vi tính toán.",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        txtKetQua.Text = ketQua.ToString(
            "G",
            CultureInfo.CurrentCulture);
    }

    private void XacNhanThoat(object? sender, FormClosingEventArgs e)
    {
        DialogResult luaChon = MessageBox.Show(
            "Bạn có muốn thoát chương trình không?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

        // Chọn No thì hủy việc đóng form.
        e.Cancel = luaChon == DialogResult.No;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            errorProvider1.Dispose();

        base.Dispose(disposing);
    }
}