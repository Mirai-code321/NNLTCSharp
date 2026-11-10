using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace VeNha01_KhachSan
{
    public class frmKhachSan : Form
    {
        private readonly TextBox txtTen = new TextBox();
        private readonly TextBox txtDiaChi = new TextBox();
        private readonly TextBox txtSoNgay = new TextBox();

        private readonly RadioButton rdoDon = new RadioButton();
        private readonly RadioButton rdoDoi = new RadioButton();
        private readonly RadioButton rdoBa = new RadioButton();

        private readonly CheckBox chkTivi = new CheckBox();
        private readonly CheckBox chkInternet = new CheckBox();
        private readonly CheckBox chkMayLanh = new CheckBox();

        private readonly CheckBox chkKaraoke = new CheckBox();
        private readonly CheckBox chkAnSang = new CheckBox();

        private readonly Button btnThanhToan = new Button();
        private readonly Button btnNhapMoi = new Button();
        private readonly Button btnTongKet = new Button();

        private readonly Label lblThanhTien = new Label();
        private readonly Label lblTongLuot = new Label();
        private readonly Label lblTongTien = new Label();

        private readonly ErrorProvider errorProvider1 = new ErrorProvider();

        private long tongLuot = 0;
        private decimal tongTien = 0;

        private bool daThanhToan = false;
        private bool dangDatLai = false;

        public frmKhachSan()
        {
            Text = "Khách sạn Thanh Thanh";
            ClientSize = new Size(800, 620);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Font = new Font("Tahoma", 11);

            errorProvider1.ContainerControl = this;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            Label tieuDe = new Label
            {
                Text = "KHÁCH SẠN THANH THANH",
                Font = new Font("Tahoma", 18, FontStyle.Bold),
                ForeColor = Color.DodgerBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Bounds = new Rectangle(20, 15, 760, 45)
            };
            Controls.Add(tieuDe);

            ThemDong("Tên khách:", txtTen, 80);
            ThemDong("Địa chỉ:", txtDiaChi, 125);
            ThemDong("Số ngày ở:", txtSoNgay, 170);

            GroupBox grpPhong = TaoNhom("Loại phòng", 25, 235, 245, 160);
            TaoLuaChon(rdoDon, "Phòng đơn: 300.000đ/ngày", 30, grpPhong);
            TaoLuaChon(rdoDoi, "Phòng đôi: 350.000đ/ngày", 70, grpPhong);
            TaoLuaChon(rdoBa, "Phòng ba: 400.000đ/ngày", 110, grpPhong);

            GroupBox grpTienNghi =
                TaoNhom("Tiện nghi (+10.000đ/loại)", 285, 235, 240, 160);

            TaoLuaChon(chkTivi, "Tivi", 30, grpTienNghi);
            TaoLuaChon(chkInternet, "Internet", 70, grpTienNghi);
            TaoLuaChon(chkMayLanh, "Máy lạnh", 110, grpTienNghi);

            GroupBox grpDichVu =
                TaoNhom("Dịch vụ", 540, 235, 235, 160);

            TaoLuaChon(chkKaraoke, "Karaoke: 50.000đ", 35, grpDichVu);
            TaoLuaChon(chkAnSang, "Ăn sáng: 15.000đ/ngày", 85, grpDichVu);

            ThemLabel("Thành tiền:", 25, 420);
            lblThanhTien.SetBounds(180, 415, 590, 35);
            lblThanhTien.Font = new Font("Tahoma", 14, FontStyle.Bold);
            lblThanhTien.TextAlign = ContentAlignment.MiddleRight;
            Controls.Add(lblThanhTien);

            TaoNut(btnThanhToan, "Thanh toán", 25);
            TaoNut(btnNhapMoi, "Nhập mới", 220);
            TaoNut(btnTongKet, "Tổng kết", 415);

            Button btnThoat = new Button();
            TaoNut(btnThoat, "Thoát", 610);

            ThemLabel("Tổng lượt trả phòng:", 25, 540);
            lblTongLuot.SetBounds(250, 535, 520, 30);
            Controls.Add(lblTongLuot);

            ThemLabel("Tổng tiền đã thu:", 25, 580);
            lblTongTien.SetBounds(250, 575, 520, 30);
            Controls.Add(lblTongTien);

            txtTen.TextChanged += DuLieuThayDoi;
            txtDiaChi.TextChanged += DuLieuThayDoi;
            txtSoNgay.TextChanged += DuLieuThayDoi;

            rdoDon.CheckedChanged += DuLieuThayDoi;
            rdoDoi.CheckedChanged += DuLieuThayDoi;
            rdoBa.CheckedChanged += DuLieuThayDoi;

            chkTivi.CheckedChanged += DuLieuThayDoi;
            chkInternet.CheckedChanged += DuLieuThayDoi;
            chkMayLanh.CheckedChanged += DuLieuThayDoi;
            chkKaraoke.CheckedChanged += DuLieuThayDoi;
            chkAnSang.CheckedChanged += DuLieuThayDoi;

            txtSoNgay.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) &&
                    (e.KeyChar < '0' || e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            };

            txtTen.Leave += (sender, e) =>
                KiemTraDuLieu(true, out _);

            txtDiaChi.Leave += (sender, e) =>
                KiemTraDuLieu(true, out _);

            txtSoNgay.Leave += (sender, e) =>
                KiemTraDuLieu(true, out _);

            btnThanhToan.Click += ThanhToan;
            btnNhapMoi.Click += (sender, e) => DatLaiForm();
            btnTongKet.Click += TongKet;
            btnThoat.Click += (sender, e) => Close();

            FormClosing += XacNhanThoat;
            Shown += (sender, e) => txtTen.Focus();

            lblTongLuot.Text = "0";
            lblTongTien.Text = DinhDangTien(0);
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

        private void ThemDong(string noiDung, TextBox textBox, int y)
        {
            ThemLabel(noiDung, 25, y + 5);
            textBox.SetBounds(180, y, 550, 30);
            Controls.Add(textBox);
        }

        private GroupBox TaoNhom(
            string ten, int x, int y, int width, int height)
        {
            GroupBox nhom = new GroupBox
            {
                Text = ten,
                Bounds = new Rectangle(x, y, width, height)
            };

            Controls.Add(nhom);
            return nhom;
        }

        private static void TaoLuaChon(
            Control luaChon, string noiDung, int y, GroupBox nhom)
        {
            luaChon.Text = noiDung;
            luaChon.SetBounds(10, y, nhom.Width - 15, 30);
            nhom.Controls.Add(luaChon);
        }

        private void TaoNut(Button nut, string noiDung, int x)
        {
            nut.Text = noiDung;
            nut.SetBounds(x, 475, 165, 40);
            Controls.Add(nut);
        }

        private static string DinhDangTien(decimal tien)
        {
            return tien.ToString(
                "N0", CultureInfo.GetCultureInfo("vi-VN")) + " đồng";
        }

        private bool KiemTraDuLieu(bool hienLoi, out int soNgay)
        {
            bool tenHopLe = !string.IsNullOrWhiteSpace(txtTen.Text);
            bool diaChiHopLe = !string.IsNullOrWhiteSpace(txtDiaChi.Text);

            bool ngayHopLe =
                int.TryParse(txtSoNgay.Text.Trim(), out soNgay) &&
                soNgay > 0;

            bool daChonPhong =
                rdoDon.Checked || rdoDoi.Checked || rdoBa.Checked;

            if (hienLoi)
            {
                errorProvider1.SetError(
                    txtTen,
                    tenHopLe ? "" : "Tên khách không được để trống.");

                errorProvider1.SetError(
                    txtDiaChi,
                    diaChiHopLe ? "" : "Bạn phải nhập địa chỉ.");

                errorProvider1.SetError(
                    txtSoNgay,
                    ngayHopLe ? "" : "Số ngày ở phải là số nguyên dương.");
            }

            // Tiện nghi và dịch vụ là tùy chọn.
            return tenHopLe && diaChiHopLe && ngayHopLe && daChonPhong;
        }

        private void DuLieuThayDoi(object? sender, EventArgs e)
        {
            if (dangDatLai || daThanhToan)
                return;

            lblThanhTien.Text = DinhDangTien(0);

            if (sender is TextBox textBox)
                errorProvider1.SetError(textBox, "");

            btnThanhToan.Enabled = KiemTraDuLieu(false, out _);
        }

        private void ThanhToan(object? sender, EventArgs e)
        {
            if (daThanhToan)
                return;

            if (!KiemTraDuLieu(true, out int soNgay))
            {
                MessageBox.Show(
                    "Hãy nhập đủ thông tin và chọn loại phòng.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal giaPhong = rdoDon.Checked ? 300000m
                : rdoDoi.Checked ? 350000m
                : 400000m;

            int soTienNghi = 0;
            if (chkTivi.Checked) soTienNghi++;
            if (chkInternet.Checked) soTienNghi++;
            if (chkMayLanh.Checked) soTienNghi++;

            decimal tienPhong = giaPhong * soNgay;
            decimal tienTienNghi = soTienNghi * 10000m;
            decimal tienKaraoke = chkKaraoke.Checked ? 50000m : 0m;
            decimal tienAnSang = chkAnSang.Checked ? 15000m * soNgay : 0m;

            decimal thanhTien =
                tienPhong + tienTienNghi + tienKaraoke + tienAnSang;

            // Tính cả hai tổng trước khi ghi nhận hóa đơn.
            try
            {
                long tongLuotMoi = checked(tongLuot + 1);
                decimal tongTienMoi = checked(tongTien + thanhTien);

                tongLuot = tongLuotMoi;
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

            lblThanhTien.Text = DinhDangTien(thanhTien);
            daThanhToan = true;

            // Khóa hóa đơn đã ghi nhận để tránh thanh toán trùng.
            DatTrangThaiNhap(false);
            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = true;
            btnTongKet.Enabled = true;
        }

        private void DatTrangThaiNhap(bool choNhap)
        {
            txtTen.Enabled = choNhap;
            txtDiaChi.Enabled = choNhap;
            txtSoNgay.Enabled = choNhap;

            rdoDon.Enabled = choNhap;
            rdoDoi.Enabled = choNhap;
            rdoBa.Enabled = choNhap;

            chkTivi.Enabled = choNhap;
            chkInternet.Enabled = choNhap;
            chkMayLanh.Enabled = choNhap;
            chkKaraoke.Enabled = choNhap;
            chkAnSang.Enabled = choNhap;
        }

        private void DatLaiForm()
        {
            dangDatLai = true;
            daThanhToan = false;

            DatTrangThaiNhap(true);

            txtTen.Clear();
            txtDiaChi.Clear();
            txtSoNgay.Clear();

            rdoDon.Checked = false;
            rdoDoi.Checked = false;
            rdoBa.Checked = false;

            chkTivi.Checked = false;
            chkInternet.Checked = false;
            chkMayLanh.Checked = false;
            chkKaraoke.Checked = false;
            chkAnSang.Checked = false;

            errorProvider1.Clear();
            lblThanhTien.Text = DinhDangTien(0);

            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;

            // Vẫn cho tổng kết nếu còn hóa đơn chưa tổng kết.
            btnTongKet.Enabled = tongLuot > 0;

            dangDatLai = false;
            txtTen.Focus();
        }

        private void TongKet(object? sender, EventArgs e)
        {
            // Hiển thị thống kê của đợt vừa kết thúc.
            lblTongLuot.Text = tongLuot.ToString();
            lblTongTien.Text = DinhDangTien(tongTien);

            // Đặt lại bộ đếm cho đợt tiếp theo.
            // Giữ kết quả tổng kết trên Label để người dùng xem.
            tongLuot = 0;
            tongTien = 0;

            btnTongKet.Enabled = false;
        }

        private void XacNhanThoat(
            object? sender, FormClosingEventArgs e)
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