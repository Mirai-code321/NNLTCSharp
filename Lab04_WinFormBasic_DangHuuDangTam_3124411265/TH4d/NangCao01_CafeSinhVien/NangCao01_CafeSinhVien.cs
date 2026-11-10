using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace NangCao01_CafeSinhVien
{
    public class frmCafeSinhVien : Form
    {
        private readonly TextBox txtTen = new TextBox();
        private readonly TextBox txtSoKhach = new TextBox();
        private readonly CheckBox chkSinhVien = new CheckBox();

        private readonly RadioButton[] cacNuoc = new RadioButton[5];
        private readonly RadioButton[] cacMonAn = new RadioButton[5];

        private readonly Button btnTinhTien = new Button();
        private readonly Button btnNhapLai = new Button();
        private readonly Button btnThanhToan = new Button();

        private readonly Label lblTongKhach = new Label();
        private readonly Label lblTongTien = new Label();

        private readonly ErrorProvider errorProvider1 = new ErrorProvider();

        private long tongKhach = 0;
        private decimal tongTien = 0;

        // Hóa đơn đã tính nhưng chưa thanh toán.
        private decimal tienHoaDon = 0;
        private int soKhachHoaDon = 0;
        private bool daTinhTien = false;
        private bool dangDatLai = false;

        private static readonly string[] TenNuoc =
        {
            "Cafe đen", "Cafe đá", "Cafe sữa",
            "Cafe sữa đá", "Cafe kem"
        };

        private static readonly decimal[] GiaNuoc =
        {
            20000, 25000, 25000, 30000, 35000
        };

        private static readonly string[] TenMonAn =
        {
            "Bánh mì trứng", "Bánh mì cá", "Mì tôm trứng",
            "Mì xào bò", "Mì cay"
        };

        private static readonly decimal[] GiaMonAn =
        {
            15000, 15000, 20000, 30000, 50000
        };

        public frmCafeSinhVien()
        {
            Text = "Cafe Sinh Viên";
            ClientSize = new Size(760, 590);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Font = new Font("Tahoma", 11);

            errorProvider1.ContainerControl = this;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            Label tieuDe = new Label
            {
                Text = "CAFE SINH VIÊN",
                Font = new Font("Tahoma", 19, FontStyle.Bold),
                ForeColor = Color.Brown,
                TextAlign = ContentAlignment.MiddleCenter,
                Bounds = new Rectangle(20, 15, 720, 45)
            };
            Controls.Add(tieuDe);

            ThemLabel("Tên khách hàng:", 25, 85);
            txtTen.SetBounds(180, 80, 330, 30);
            Controls.Add(txtTen);

            chkSinhVien.Text = "Sinh viên (-20%)";
            chkSinhVien.SetBounds(535, 80, 200, 30);
            Controls.Add(chkSinhVien);

            ThemLabel("Số khách:", 25, 130);
            txtSoKhach.SetBounds(180, 125, 150, 30);
            Controls.Add(txtSoKhach);

            ThemLabel(
                "Mỗi khách dùng 1 nước uống và 1 phần thức ăn đã chọn.",
                25, 175);

            TaoNhom(
                "Nước uống", TenNuoc, GiaNuoc, cacNuoc, 25);

            TaoNhom(
                "Thức ăn", TenMonAn, GiaMonAn, cacMonAn, 395);

            TaoNut(btnTinhTien, "Tính tiền", 25);
            TaoNut(btnNhapLai, "Nhập lại", 210);
            TaoNut(btnThanhToan, "Thanh toán", 395);

            Button btnThoat = new Button();
            TaoNut(btnThoat, "Thoát", 580);

            ThemLabel("Tổng số khách đã thanh toán:", 25, 505);
            lblTongKhach.SetBounds(340, 500, 390, 30);
            Controls.Add(lblTongKhach);

            ThemLabel("Tổng tiền đã thu:", 25, 545);
            lblTongTien.SetBounds(340, 540, 390, 30);
            Controls.Add(lblTongTien);

            txtTen.TextChanged += DuLieuThayDoi;
            txtSoKhach.TextChanged += DuLieuThayDoi;
            chkSinhVien.CheckedChanged += DuLieuThayDoi;

            // Chặn ký tự không phải chữ số khi gõ.
            // Dữ liệu dán vào vẫn được kiểm tra bằng TryParse.
            txtSoKhach.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) &&
                    (e.KeyChar < '0' || e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            };

            txtTen.Leave += (sender, e) =>
                KiemTraDuLieu(true, out _);

            txtSoKhach.Leave += (sender, e) =>
                KiemTraDuLieu(true, out _);

            btnTinhTien.Click += TinhTien;
            btnNhapLai.Click += (sender, e) => DatLaiForm();
            btnThanhToan.Click += ThanhToan;
            btnThoat.Click += (sender, e) => Close();

            FormClosing += XacNhanThoat;
            Shown += (sender, e) => txtTen.Focus();

            CapNhatThongKe();
            DatLaiForm();
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

        private void TaoNhom(
            string tieuDe,
            string[] ten,
            decimal[] gia,
            RadioButton[] cacLuaChon,
            int x)
        {
            GroupBox nhom = new GroupBox
            {
                Text = tieuDe,
                Bounds = new Rectangle(x, 210, 340, 220)
            };

            for (int i = 0; i < ten.Length; i++)
            {
                RadioButton luaChon = new RadioButton
                {
                    Text = $"{ten[i]} — {DinhDangTien(gia[i])}",
                    Bounds = new Rectangle(15, 30 + i * 35, 315, 30)
                };

                luaChon.CheckedChanged += DuLieuThayDoi;
                cacLuaChon[i] = luaChon;
                nhom.Controls.Add(luaChon);
            }

            Controls.Add(nhom);
        }

        private void TaoNut(Button nut, string noiDung, int x)
        {
            nut.Text = noiDung;
            nut.SetBounds(x, 450, 155, 40);
            Controls.Add(nut);
        }

        private static string DinhDangTien(decimal tien)
        {
            return tien.ToString(
                "N0", CultureInfo.GetCultureInfo("vi-VN")) + " đồng";
        }

        private static int LayLuaChon(RadioButton[] cacLuaChon)
        {
            for (int i = 0; i < cacLuaChon.Length; i++)
            {
                if (cacLuaChon[i].Checked)
                    return i;
            }

            return -1;
        }

        private bool KiemTraDuLieu(bool hienLoi, out int soKhach)
        {
            bool tenHopLe = !string.IsNullOrWhiteSpace(txtTen.Text);

            bool soKhachHopLe =
                int.TryParse(txtSoKhach.Text.Trim(), out soKhach) &&
                soKhach > 0;

            bool daChonNuoc = LayLuaChon(cacNuoc) >= 0;
            bool daChonMon = LayLuaChon(cacMonAn) >= 0;

            if (hienLoi)
            {
                errorProvider1.SetError(
                    txtTen,
                    tenHopLe ? "" : "Tên khách hàng không được để trống.");

                errorProvider1.SetError(
                    txtSoKhach,
                    soKhachHopLe ? "" : "Số khách phải là số nguyên dương.");
            }

            return tenHopLe && soKhachHopLe &&
                   daChonNuoc && daChonMon;
        }

        private void DuLieuThayDoi(object? sender, EventArgs e)
        {
            if (dangDatLai)
                return;

            // Dữ liệu thay đổi thì hóa đơn đã tính không còn hợp lệ.
            daTinhTien = false;
            tienHoaDon = 0;
            soKhachHoaDon = 0;

            btnThanhToan.Enabled = false;
            btnNhapLai.Enabled = false;

            if (sender is TextBox textBox)
                errorProvider1.SetError(textBox, "");

            btnTinhTien.Enabled = KiemTraDuLieu(false, out _);
        }

        private void TinhTien(object? sender, EventArgs e)
        {
            if (!KiemTraDuLieu(true, out int soKhach))
            {
                MessageBox.Show(
                    "Hãy nhập tên, số khách và chọn nước uống, thức ăn.",
                    "Dữ liệu chưa hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int nuoc = LayLuaChon(cacNuoc);
            int mon = LayLuaChon(cacMonAn);

            decimal tienGoc =
                (GiaNuoc[nuoc] + GiaMonAn[mon]) * soKhach;

            decimal giamGia = chkSinhVien.Checked
                ? tienGoc * 0.20m
                : 0;

            tienHoaDon = tienGoc - giamGia;
            soKhachHoaDon = soKhach;
            daTinhTien = true;

            MessageBox.Show(
                $"Khách hàng: {txtTen.Text.Trim()}\n" +
                $"Số khách: {soKhach}\n" +
                $"Nước uống: {TenNuoc[nuoc]}\n" +
                $"Thức ăn: {TenMonAn[mon]}\n" +
                $"Tiền trước giảm: {DinhDangTien(tienGoc)}\n" +
                $"Giảm giá: {DinhDangTien(giamGia)}\n" +
                $"Phải trả: {DinhDangTien(tienHoaDon)}",
                "Hóa đơn",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            btnNhapLai.Enabled = true;
            btnThanhToan.Enabled = true;
        }

        private void ThanhToan(object? sender, EventArgs e)
        {
            if (!daTinhTien)
                return;

            // Chỉ cộng thống kê khi xác nhận thanh toán.
            // Tính trước cả hai tổng để tránh cập nhật một phần.
            try
            {
                long tongKhachMoi = checked(tongKhach + soKhachHoaDon);
                decimal tongTienMoi = checked(tongTien + tienHoaDon);

                tongKhach = tongKhachMoi;
                tongTien = tongTienMoi;
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "Tổng thống kê vượt phạm vi lưu trữ.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            CapNhatThongKe();

            // Chuẩn bị nhóm khách mới, tránh thanh toán trùng.
            DatLaiForm();
        }

        private void CapNhatThongKe()
        {
            lblTongKhach.Text = tongKhach.ToString();
            lblTongTien.Text = DinhDangTien(tongTien);
        }

        private void DatLaiForm()
        {
            dangDatLai = true;

            txtTen.Clear();
            txtSoKhach.Clear();
            chkSinhVien.Checked = false;

            foreach (RadioButton nuoc in cacNuoc)
                nuoc.Checked = false;

            foreach (RadioButton mon in cacMonAn)
                mon.Checked = false;

            errorProvider1.Clear();

            daTinhTien = false;
            tienHoaDon = 0;
            soKhachHoaDon = 0;

            btnTinhTien.Enabled = false;
            btnNhapLai.Enabled = false;
            btnThanhToan.Enabled = false;

            dangDatLai = false;
            txtTen.Focus();

            // Giữ nguyên thống kê các nhóm đã thanh toán.
        }

        private void XacNhanThoat(
            object? sender,
            FormClosingEventArgs e)
        {
            DialogResult luaChon = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không?",
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
}