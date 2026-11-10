using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Bai02_TaiKhoanNganHang
{
    // Lưu dữ liệu thật, độc lập với cách định dạng trên ListView.
    public class TaiKhoan
    {
        public string SoTaiKhoan { get; }
        public string TenKhachHang { get; }
        public string DiaChi { get; }
        public decimal SoTien { get; }

        public TaiKhoan(
            string soTaiKhoan,
            string tenKhachHang,
            string diaChi,
            decimal soTien)
        {
            SoTaiKhoan = soTaiKhoan;
            TenKhachHang = tenKhachHang;
            DiaChi = diaChi;
            SoTien = soTien;
        }
    }

    public class frmTaiKhoanNganHang : Form
    {
        private readonly TextBox txtSoTaiKhoan;
        private readonly TextBox txtTenKhachHang;
        private readonly TextBox txtDiaChi;
        private readonly TextBox txtSoTien;
        private readonly TextBox txtTongTien;

        private readonly ListView lvTaiKhoan;

        private readonly Button btnThem;
        private readonly Button btnLuu;
        private readonly Button btnXoa;

        private bool dangThemMoi = false;

        private readonly CultureInfo vanHoa =
            CultureInfo.GetCultureInfo("vi-VN");

        public frmTaiKhoanNganHang()
        {
            Text = "TH5d - Bài 2 - Quản lý tài khoản";
            ClientSize = new Size(950, 660);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN";
            lblTieuDe.Font = new Font(
                "Segoe UI", 18, FontStyle.Bold
            );
            lblTieuDe.ForeColor = Color.Blue;
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.SetBounds(20, 15, 910, 50);
            Controls.Add(lblTieuDe);

            ThemLabel("Số tài khoản", 50, 90);
            txtSoTaiKhoan = ThemTextBox(285, 87, 610);

            ThemLabel("Tên khách hàng", 50, 140);
            txtTenKhachHang = ThemTextBox(285, 137, 610);

            ThemLabel("Địa chỉ khách hàng", 50, 190);
            txtDiaChi = ThemTextBox(285, 187, 610);

            ThemLabel("Số tiền trong tài khoản", 50, 240);
            txtSoTien = ThemTextBox(285, 237, 610);
            txtSoTien.TextAlign = HorizontalAlignment.Right;

            btnThem = ThemButton(
                "&Thêm", 285, 290, 140, ThemHoacHuy
            );

            btnLuu = ThemButton(
                "&Lưu", 440, 290, 140, LuuTaiKhoan
            );

            btnXoa = ThemButton(
                "&Xóa", 595, 290, 140, XoaTaiKhoan
            );

            ThemButton(
                "T&hoát", 750, 290, 145, Close
            );

            // Trạng thái ban đầu theo đề.
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;

            lvTaiKhoan = new ListView();
            lvTaiKhoan.View = View.Details;
            lvTaiKhoan.FullRowSelect = true;
            lvTaiKhoan.GridLines = true;
            lvTaiKhoan.MultiSelect = false;
            lvTaiKhoan.HideSelection = false;
            lvTaiKhoan.SetBounds(25, 355, 900, 235);

            lvTaiKhoan.Columns.Add("STT", 55);
            lvTaiKhoan.Columns.Add("Số tài khoản", 170);
            lvTaiKhoan.Columns.Add("Tên khách hàng", 240);
            lvTaiKhoan.Columns.Add("Địa chỉ", 235);
            lvTaiKhoan.Columns.Add(
                "Số tiền", 175, HorizontalAlignment.Right
            );

            Controls.Add(lvTaiKhoan);

            ThemLabel("Tổng tiền", 510, 615);
            txtTongTien = ThemTextBox(700, 610, 225);
            txtTongTien.ReadOnly = true;
            txtTongTien.TextAlign = HorizontalAlignment.Right;
            txtTongTien.Text = "0";

            lvTaiKhoan.SelectedIndexChanged +=
                LvTaiKhoan_SelectedIndexChanged;

            // Chỉ chặn khi gõ; lúc lưu vẫn kiểm tra dữ liệu dán.
            txtSoTaiKhoan.KeyPress += (_, e) =>
            {
                if (!char.IsControl(e.KeyChar)
                    && (e.KeyChar < '0' || e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            };

            txtSoTien.KeyPress += (_, e) =>
            {
                if (!char.IsControl(e.KeyChar)
                    && (e.KeyChar < '0' || e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            };

            FormClosing += FrmTaiKhoanNganHang_FormClosing;
        }

        private void ThemLabel(string noiDung, int x, int y)
        {
            Label label = new Label();
            label.Text = noiDung;
            label.SetBounds(x, y, 230, 30);
            Controls.Add(label);
        }

        private TextBox ThemTextBox(int x, int y, int rong)
        {
            TextBox textBox = new TextBox();
            textBox.SetBounds(x, y, rong, 30);
            Controls.Add(textBox);

            return textBox;
        }

        private Button ThemButton(
            string noiDung,
            int x,
            int y,
            int rong,
            Action xuLy)
        {
            Button button = new Button();
            button.Text = noiDung;
            button.SetBounds(x, y, rong, 40);
            button.Click += (_, _) => xuLy();
            Controls.Add(button);

            return button;
        }

        private void ThongBao(string noiDung)
        {
            MessageBox.Show(
                this,
                noiDung,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }

        private void XoaOInput()
        {
            txtSoTaiKhoan.Clear();
            txtTenKhachHang.Clear();
            txtDiaChi.Clear();
            txtSoTien.Clear();
        }

        private void ThemHoacHuy()
        {
            if (dangThemMoi)
            {
                // Hủy dữ liệu chưa lưu, giữ nguyên danh sách.
                KetThucNhap();
                return;
            }

            dangThemMoi = true;

            // Bỏ lựa chọn cũ trước khi nhập tài khoản mới.
            foreach (ListViewItem item in
                lvTaiKhoan.SelectedItems
                    .Cast<ListViewItem>()
                    .ToArray())
            {
                item.Selected = false;
            }

            // Tạm khóa danh sách để không ghi đè ô đang nhập
            // bằng dữ liệu của một tài khoản khác.
            lvTaiKhoan.Enabled = false;

            btnThem.Text = "&Hủy";
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;

            XoaOInput();
            txtSoTaiKhoan.Focus();
        }

        private void KetThucNhap()
        {
            dangThemMoi = false;

            lvTaiKhoan.Enabled = true;
            btnThem.Text = "&Thêm";
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;

            XoaOInput();
            btnThem.Focus();
        }

        private decimal TinhTongTien()
        {
            decimal tong = 0;

            foreach (ListViewItem item in lvTaiKhoan.Items)
            {
                TaiKhoan taiKhoan = (TaiKhoan)item.Tag!;

                tong = checked(tong + taiKhoan.SoTien);
            }

            return tong;
        }

        private void LuuTaiKhoan()
        {
            if (!dangThemMoi)
            {
                return;
            }

            string soTaiKhoan = txtSoTaiKhoan.Text.Trim();
            string ten = txtTenKhachHang.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string tienNhap = txtSoTien.Text.Trim();

            if (soTaiKhoan.Length == 0
                || !soTaiKhoan.All(c => c >= '0' && c <= '9'))
            {
                ThongBao("Số tài khoản phải gồm các chữ số.");
                txtSoTaiKhoan.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                ThongBao("Tên khách hàng không được để trống.");
                txtTenKhachHang.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(diaChi))
            {
                ThongBao("Địa chỉ không được để trống.");
                txtDiaChi.Focus();
                return;
            }

            // Nhập số tiền bằng chữ số, không dùng dấu phân cách.
            // Ví dụ: 5200000, không nhập 5.200.000.
            bool tienHopLe =
                tienNhap.Length > 0
                && tienNhap.All(c => c >= '0' && c <= '9');

            if (!tienHopLe
                || !decimal.TryParse(
                    tienNhap,
                    NumberStyles.None,
                    CultureInfo.InvariantCulture,
                    out decimal soTien))
            {
                ThongBao(
                    "Nhập số tiền không âm bằng các chữ số, "
                    + "không có dấu phân cách."
                );

                txtSoTien.Focus();
                return;
            }

            bool daTonTai = lvTaiKhoan.Items
                .Cast<ListViewItem>()
                .Any(item =>
                    ((TaiKhoan)item.Tag!).SoTaiKhoan
                    == soTaiKhoan
                );

            if (daTonTai)
            {
                ThongBao("Số tài khoản đã tồn tại.");
                txtSoTaiKhoan.Focus();
                txtSoTaiKhoan.SelectAll();
                return;
            }

            // Kiểm tra tổng trước khi thêm để tránh lưu
            // một dòng làm tổng tiền vượt giới hạn decimal.
            try
            {
                decimal tongMoi =
                    checked(TinhTongTien() + soTien);
            }
            catch (OverflowException)
            {
                ThongBao("Tổng tiền vượt giới hạn xử lý.");
                return;
            }

            TaiKhoan taiKhoan = new TaiKhoan(
                soTaiKhoan, ten, diaChi, soTien
            );

            ListViewItem itemMoi = new ListViewItem(new[]
            {
                "",
                taiKhoan.SoTaiKhoan,
                taiKhoan.TenKhachHang,
                taiKhoan.DiaChi,
                taiKhoan.SoTien.ToString("N0", vanHoa)
            });

            // Lưu dữ liệu gốc vào Tag.
            itemMoi.Tag = taiKhoan;
            lvTaiKhoan.Items.Add(itemMoi);

            CapNhatSTTVaTong();
            KetThucNhap();

            itemMoi.EnsureVisible();
        }

        private void LvTaiKhoan_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            if (dangThemMoi)
            {
                return;
            }

            bool daChon =
                lvTaiKhoan.SelectedItems.Count == 1;

            btnXoa.Enabled = daChon;

            if (!daChon)
            {
                XoaOInput();
                return;
            }

            TaiKhoan taiKhoan =
                (TaiKhoan)lvTaiKhoan.SelectedItems[0].Tag!;

            txtSoTaiKhoan.Text = taiKhoan.SoTaiKhoan;
            txtTenKhachHang.Text = taiKhoan.TenKhachHang;
            txtDiaChi.Text = taiKhoan.DiaChi;

            // Ô nhập hiển thị số tiền không có dấu phân cách.
            txtSoTien.Text = taiKhoan.SoTien.ToString(
                "0", CultureInfo.InvariantCulture
            );
        }

        private void XoaTaiKhoan()
        {
            if (dangThemMoi
                || lvTaiKhoan.SelectedItems.Count != 1)
            {
                ThongBao("Hãy chọn tài khoản cần xóa.");
                return;
            }

            ListViewItem item = lvTaiKhoan.SelectedItems[0];
            TaiKhoan taiKhoan = (TaiKhoan)item.Tag!;

            DialogResult luaChon = MessageBox.Show(
                this,
                $"Xóa tài khoản {taiKhoan.SoTaiKhoan}"
                    + $" của {taiKhoan.TenKhachHang}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (luaChon != DialogResult.Yes)
            {
                return;
            }

            lvTaiKhoan.Items.Remove(item);

            CapNhatSTTVaTong();
            XoaOInput();
            btnXoa.Enabled = false;
        }

        private void CapNhatSTTVaTong()
        {
            // STT luôn liên tục từ 1 sau khi thêm hoặc xóa.
            for (int i = 0; i < lvTaiKhoan.Items.Count; i++)
            {
                lvTaiKhoan.Items[i].Text = (i + 1).ToString();
            }

            txtTongTien.Text =
                TinhTongTien().ToString("N0", vanHoa);
        }

        private void FrmTaiKhoanNganHang_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            DialogResult luaChon = MessageBox.Show(
                this,
                "Bạn có muốn đóng chương trình không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (luaChon != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}