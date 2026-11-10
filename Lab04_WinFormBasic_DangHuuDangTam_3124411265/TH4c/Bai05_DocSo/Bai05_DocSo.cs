using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class frmDocSo : Form
{
    private readonly TextBox txtSo = new TextBox();
    private readonly TextBox txtKetQua = new TextBox();
    private readonly ErrorProvider errorProvider1 = new ErrorProvider();

    // Cách đọc các chữ số từ 0 đến 9.
    private static readonly string[] ChuSo =
    {
        "không", "một", "hai", "ba", "bốn",
        "năm", "sáu", "bảy", "tám", "chín"
    };

    public frmDocSo()
    {
        Text = "Bài 5 - Đọc số thành chữ";
        ClientSize = new Size(650, 280);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Font = new Font("Tahoma", 11);

        errorProvider1.ContainerControl = this;
        errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

        Label lblTieuDe = new Label
        {
            Text = "ĐỌC SỐ THÀNH CHỮ",
            Font = new Font("Tahoma", 16, FontStyle.Bold),
            ForeColor = Color.DodgerBlue,
            TextAlign = ContentAlignment.MiddleCenter,
            Bounds = new Rectangle(20, 15, 610, 40)
        };

        Controls.Add(lblTieuDe);

        ThemLabel("Nhập số (1–999):", 25, 85);
        txtSo.SetBounds(190, 80, 400, 30);
        txtSo.TabIndex = 0;
        Controls.Add(txtSo);

        ThemLabel("Đọc thành chữ:", 25, 140);
        txtKetQua.SetBounds(190, 135, 400, 30);
        txtKetQua.ReadOnly = true;
        txtKetQua.TabStop = false;
        Controls.Add(txtKetQua);

        Button btnThucHien = ThemButton("Thực hiện", 55);
        Button btnXoa = ThemButton("Xóa", 245);
        Button btnThoat = ThemButton("Thoát", 435);

        btnThucHien.TabIndex = 1;
        btnXoa.TabIndex = 2;
        btnThoat.TabIndex = 3;

        btnThucHien.Click += btnThucHien_Click;
        btnXoa.Click += btnXoa_Click;
        btnThoat.Click += (sender, e) => Close();

        // Khi sửa số, xóa kết quả và thông báo lỗi cũ.
        txtSo.TextChanged += (sender, e) =>
        {
            txtKetQua.Clear();
            errorProvider1.SetError(txtSo, "");
        };

        AcceptButton = btnThucHien;
        CancelButton = btnThoat;

        FormClosing += XacNhanThoat;
        Shown += (sender, e) => txtSo.Focus();
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

    private Button ThemButton(string noiDung, int x)
    {
        Button button = new Button
        {
            Text = noiDung,
            Bounds = new Rectangle(x, 210, 150, 40)
        };

        Controls.Add(button);
        return button;
    }

    private void btnThucHien_Click(object? sender, EventArgs e)
    {
        txtKetQua.Clear();

        // Kiểm tra cả định dạng số nguyên và khoảng cho phép.
        if (!int.TryParse(txtSo.Text.Trim(), out int so) ||
            so < 1 || so > 999)
        {
            errorProvider1.SetError(
                txtSo,
                "Bạn phải nhập số nguyên từ 1 đến 999.");

            MessageBox.Show(
                "Dữ liệu không hợp lệ. Hãy nhập số nguyên từ 1 đến 999.",
                "Lỗi nhập liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSo.Focus();
            txtSo.SelectAll();
            return;
        }

        errorProvider1.SetError(txtSo, "");
        txtKetQua.Text = DocSo(so);
    }

    private static string DocSo(int so)
    {
        // Tách các chữ số theo hàng.
        int tram = so / 100;
        int chuc = (so / 10) % 10;
        int donVi = so % 10;

        List<string> cacTu = new List<string>();

        // Đọc hàng trăm nếu có.
        if (tram > 0)
        {
            cacTu.Add(ChuSo[tram]);
            cacTu.Add("trăm");
        }

        // Đọc hàng chục.
        if (chuc == 0)
        {
            // Ví dụ: 105 đọc là "một trăm lẻ năm".
            // Không thêm "lẻ" khi số là tròn trăm.
            if (tram > 0 && donVi > 0)
                cacTu.Add("lẻ");
        }
        else if (chuc == 1)
        {
            cacTu.Add("mười");
        }
        else
        {
            cacTu.Add(ChuSo[chuc]);
            cacTu.Add("mươi");
        }

        // Đọc hàng đơn vị và các trường hợp đặc biệt.
        if (donVi > 0)
        {
            if (donVi == 1 && chuc >= 2)
            {
                // 21: hai mươi mốt.
                cacTu.Add("mốt");
            }
            else if (donVi == 5 && chuc >= 1)
            {
                // 15: mười lăm; 25: hai mươi lăm.
                cacTu.Add("lăm");
            }
            else
            {
                cacTu.Add(ChuSo[donVi]);
            }
        }

        string ketQua = string.Join(" ", cacTu);

        // Viết hoa chữ đầu tiên.
        return char.ToUpperInvariant(ketQua[0]) + ketQua.Substring(1);
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        // Trả form về trạng thái ban đầu.
        txtSo.Clear();
        txtKetQua.Clear();
        errorProvider1.Clear();
        txtSo.Focus();
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