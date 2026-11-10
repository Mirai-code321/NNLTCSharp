using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

public class frmMayTinh : Form
{
    private readonly TextBox txtManHinh = new TextBox();

    // Giá trị bên trái của phép toán.
    private decimal giaTriTruoc = 0;

    // Phép toán đang chờ thực hiện.
    private string phepToan = "";

    // Khi true, chữ số tiếp theo sẽ bắt đầu một số mới.
    private bool nhapMoi = true;

    private bool dangLoi = false;

    public frmMayTinh()
    {
        Text = "Máy tính bỏ túi";
        ClientSize = new Size(360, 450);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Font = new Font("Tahoma", 13);

        txtManHinh.SetBounds(20, 20, 320, 50);
        txtManHinh.ReadOnly = true;
        txtManHinh.TabStop = false;
        txtManHinh.TextAlign = HorizontalAlignment.Right;
        txtManHinh.Font = new Font("Tahoma", 22);
        txtManHinh.Text = "0";
        Controls.Add(txtManHinh);

        string[,] cacNut =
        {
            { "C", "⌫", "±", "/" },
            { "7", "8", "9", "*" },
            { "4", "5", "6", "-" },
            { "1", "2", "3", "+" },
            { "0", ".", "=", "Thoát" }
        };

        for (int hang = 0; hang < 5; hang++)
        {
            for (int cot = 0; cot < 4; cot++)
            {
                Button nut = new Button
                {
                    Text = cacNut[hang, cot],
                    Bounds = new Rectangle(
                        20 + cot * 82,
                        90 + hang * 68,
                        74,
                        58)
                };

                nut.Click += Nut_Click;
                Controls.Add(nut);
            }
        }

        FormClosing += XacNhanThoat;
    }

    private void Nut_Click(object? sender, EventArgs e)
    {
        if (sender is not Button nut)
            return;

        string noiDung = nut.Text;

        // Nút C luôn có thể đưa máy tính về trạng thái ban đầu.
        if (noiDung == "C")
        {
            XoaTatCa();
            return;
        }

        if (noiDung == "Thoát")
        {
            Close();
            return;
        }

        bool laChuSo = noiDung.Length == 1 &&
                       noiDung[0] >= '0' &&
                       noiDung[0] <= '9';

        // Sau lỗi, nhập một chữ số để bắt đầu lại.
        if (dangLoi)
        {
            if (laChuSo || noiDung == ".")
                XoaTatCa();
            else
                return;
        }

        if (laChuSo)
        {
            NhapChuSo(noiDung);
            return;
        }

        switch (noiDung)
        {
            case ".":
                NhapDauThapPhan();
                break;

            case "±":
                DoiDau();
                break;

            case "⌫":
                XoaMotKyTu();
                break;

            case "+":
            case "-":
            case "*":
            case "/":
                ChonPhepToan(noiDung);
                break;

            case "=":
                TinhKetQua();
                break;
        }
    }

    private void NhapChuSo(string chuSo)
    {
        string duLieuMoi;

        if (nhapMoi || txtManHinh.Text == "0")
            duLieuMoi = chuSo;
        else
            duLieuMoi = txtManHinh.Text + chuSo;

        // Chỉ nhận dữ liệu còn nằm trong phạm vi decimal.
        if (!decimal.TryParse(
            duLieuMoi,
            NumberStyles.AllowLeadingSign |
            NumberStyles.AllowDecimalPoint,
            CultureInfo.InvariantCulture,
            out _))
        {
            BaoLoi("Số nhập vượt phạm vi cho phép.");
            return;
        }

        txtManHinh.Text = duLieuMoi;
        nhapMoi = false;
    }

    private void NhapDauThapPhan()
    {
        if (nhapMoi)
        {
            txtManHinh.Text = "0.";
            nhapMoi = false;
        }
        else if (!txtManHinh.Text.Contains("."))
        {
            // Mỗi số chỉ được có một dấu thập phân.
            txtManHinh.Text += ".";
        }
    }

    private decimal DocManHinh()
    {
        // Màn hình dùng dấu chấm làm dấu thập phân.
        return decimal.Parse(
            txtManHinh.Text,
            CultureInfo.InvariantCulture);
    }

    private void HienThi(decimal giaTri)
    {
        txtManHinh.Text = giaTri.ToString(
            CultureInfo.InvariantCulture);
    }

    private void DoiDau()
    {
        // Nếu đang chờ số bên phải, bắt đầu nhập số mới.
        if (nhapMoi && phepToan != "")
        {
            txtManHinh.Text = "-0";
            nhapMoi = false;
            return;
        }

        string noiDung = txtManHinh.Text;

        txtManHinh.Text = noiDung.StartsWith("-")
            ? noiDung.Substring(1)
            : "-" + noiDung;

        // Giữ trạng thái nhapMoi khi đổi dấu kết quả.
    }

    private void XoaMotKyTu()
    {
        if (nhapMoi)
            return;

        string noiDung = txtManHinh.Text;

        if (noiDung.Length > 1)
            noiDung = noiDung.Substring(0, noiDung.Length - 1);
        else
            noiDung = "0";

        if (noiDung == "" || noiDung == "-")
            noiDung = "0";

        txtManHinh.Text = noiDung;
    }

    private void ChonPhepToan(string phepToanMoi)
    {
        decimal giaTriHienTai = DocManHinh();

        // Nếu đã nhập đủ hai số, tính phép toán trước.
        // Máy tính xử lý nối tiếp từ trái sang phải.
        if (phepToan != "" && !nhapMoi)
        {
            if (!ThuTinh(giaTriHienTai, out decimal ketQua))
                return;

            giaTriTruoc = ketQua;
            HienThi(ketQua);
        }
        else if (phepToan == "")
        {
            giaTriTruoc = giaTriHienTai;
        }

        // Nếu bấm liên tiếp các phép toán,
        // phép toán mới sẽ thay thế phép toán đang chờ.
        phepToan = phepToanMoi;
        nhapMoi = true;
    }

    private void TinhKetQua()
    {
        // Cần có phép toán và đã nhập số thứ hai.
        if (phepToan == "" || nhapMoi)
            return;

        decimal giaTriHienTai = DocManHinh();

        if (!ThuTinh(giaTriHienTai, out decimal ketQua))
            return;

        HienThi(ketQua);

        giaTriTruoc = ketQua;
        phepToan = "";
        nhapMoi = true;
    }

    private bool ThuTinh(decimal giaTriSau, out decimal ketQua)
    {
        ketQua = 0;

        try
        {
            switch (phepToan)
            {
                case "+":
                    ketQua = giaTriTruoc + giaTriSau;
                    break;

                case "-":
                    ketQua = giaTriTruoc - giaTriSau;
                    break;

                case "*":
                    ketQua = giaTriTruoc * giaTriSau;
                    break;

                case "/":
                    if (giaTriSau == 0)
                    {
                        BaoLoi("Không thể chia cho 0.");
                        return false;
                    }

                    ketQua = giaTriTruoc / giaTriSau;
                    break;

                default:
                    return false;
            }

            return true;
        }
        catch (OverflowException)
        {
            BaoLoi("Kết quả vượt phạm vi tính toán.");
            return false;
        }
    }

    private void BaoLoi(string thongBao)
    {
        MessageBox.Show(
            thongBao,
            "Lỗi",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning);

        txtManHinh.Text = "Lỗi";
        giaTriTruoc = 0;
        phepToan = "";
        nhapMoi = true;
        dangLoi = true;
    }

    private void XoaTatCa()
    {
        txtManHinh.Text = "0";
        giaTriTruoc = 0;
        phepToan = "";
        nhapMoi = true;
        dangLoi = false;
    }

    private void XacNhanThoat(object? sender, FormClosingEventArgs e)
    {
        DialogResult luaChon = MessageBox.Show(
            "Bạn có muốn thoát máy tính không?",
            "Xác nhận thoát",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

        e.Cancel = luaChon == DialogResult.No;
    }
}