using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Bai01_PhuongTrinh
{
    public class frmPhuongTrinh : Form
    {
        private readonly RadioButton rdoBacNhat = new RadioButton();
        private readonly RadioButton rdoBacHai = new RadioButton();

        private readonly TextBox txtA = new TextBox();
        private readonly TextBox txtB = new TextBox();
        private readonly TextBox txtC = new TextBox();
        private readonly TextBox txtKetQua = new TextBox();

        private readonly Button btnGiai = new Button();
        private readonly ErrorProvider errorProvider1 = new ErrorProvider();

        public frmPhuongTrinh()
        {
            Text = "Giải phương trình";
            ClientSize = new Size(650, 470);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Font = new Font("Tahoma", 11);

            errorProvider1.ContainerControl = this;
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            Label lblTieuDe = new Label
            {
                Text = "GIẢI PHƯƠNG TRÌNH",
                Font = new Font("Tahoma", 17, FontStyle.Bold),
                ForeColor = Color.DodgerBlue,
                TextAlign = ContentAlignment.MiddleCenter,
                Bounds = new Rectangle(20, 15, 610, 40)
            };

            Controls.Add(lblTieuDe);

            // Hai RadioButton cùng GroupBox nên chỉ chọn được một.
            GroupBox grpLoai = new GroupBox
            {
                Text = "Loại phương trình",
                Bounds = new Rectangle(30, 65, 590, 75)
            };

            rdoBacNhat.Text = "Bậc nhất: ax + b = 0";
            rdoBacNhat.SetBounds(20, 30, 260, 30);
            rdoBacNhat.Checked = true;

            rdoBacHai.Text = "Bậc hai: ax² + bx + c = 0";
            rdoBacHai.SetBounds(290, 30, 285, 30);

            grpLoai.Controls.Add(rdoBacNhat);
            grpLoai.Controls.Add(rdoBacHai);
            Controls.Add(grpLoai);

            ThemDong("Nhập a:", txtA, 165);
            ThemDong("Nhập b:", txtB, 210);
            ThemDong("Nhập c:", txtC, 255);

            txtA.TabIndex = 2;
            txtB.TabIndex = 3;
            txtC.TabIndex = 4;
            txtC.Enabled = false;

            Label lblKetQua = new Label
            {
                Text = "Kết quả:",
                AutoSize = true,
                Location = new Point(30, 310)
            };

            txtKetQua.SetBounds(160, 305, 430, 90);
            txtKetQua.Multiline = true;
            txtKetQua.ReadOnly = true;
            txtKetQua.TabStop = false;

            Controls.Add(lblKetQua);
            Controls.Add(txtKetQua);

            btnGiai.Text = "Giải";
            btnGiai.SetBounds(160, 415, 180, 40);

            // Theo đề: nút Giải bị mờ khi form mới mở.
            btnGiai.Enabled = false;
            btnGiai.TabIndex = 5;

            Button btnThoat = new Button
            {
                Text = "Thoát",
                Bounds = new Rectangle(410, 415, 180, 40),
                TabIndex = 6
            };

            Controls.Add(btnGiai);
            Controls.Add(btnThoat);

            // Khi đổi loại phương trình, cập nhật ô c.
            rdoBacNhat.CheckedChanged += DoiLoaiPhuongTrinh;
            rdoBacHai.CheckedChanged += DoiLoaiPhuongTrinh;

            txtA.TextChanged += DuLieuThayDoi;
            txtB.TextChanged += DuLieuThayDoi;
            txtC.TextChanged += DuLieuThayDoi;

            // Kiểm tra và chỉ rõ lỗi khi rời ô nhập.
            txtA.Leave += (sender, e) =>
                KiemTraHeSo(txtA, out _);

            txtB.Leave += (sender, e) =>
                KiemTraHeSo(txtB, out _);

            txtC.Leave += (sender, e) =>
            {
                if (rdoBacHai.Checked)
                    KiemTraHeSo(txtC, out _);
            };

            btnGiai.Click += btnGiai_Click;
            btnThoat.Click += (sender, e) => Close();

            AcceptButton = btnGiai;
            CancelButton = btnThoat;

            FormClosing += XacNhanThoat;
            Shown += (sender, e) => txtA.Focus();
        }

        private void ThemDong(
            string noiDung,
            TextBox textBox,
            int y)
        {
            Label label = new Label
            {
                Text = noiDung,
                AutoSize = true,
                Location = new Point(30, y + 4)
            };

            textBox.SetBounds(160, y, 430, 30);

            Controls.Add(label);
            Controls.Add(textBox);
        }

        private static bool ThuDocSo(string noiDung, out double so)
        {
            // Chấp nhận dấu chấm hoặc dấu phẩy làm dấu thập phân.
            string duLieu = noiDung.Trim().Replace(',', '.');

            bool hopLe = double.TryParse(
                duLieu,
                NumberStyles.AllowLeadingSign |
                NumberStyles.AllowDecimalPoint |
                NumberStyles.AllowExponent,
                CultureInfo.InvariantCulture,
                out so);

            return hopLe && double.IsFinite(so);
        }

        private bool KiemTraHeSo(TextBox textBox, out double so)
        {
            so = 0;

            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(
                    textBox,
                    "Bạn phải nhập hệ số.");

                return false;
            }

            if (!ThuDocSo(textBox.Text, out so))
            {
                errorProvider1.SetError(
                    textBox,
                    "Hệ số phải là số hợp lệ.");

                return false;
            }

            errorProvider1.SetError(textBox, "");
            return true;
        }

        private void DoiLoaiPhuongTrinh(object? sender, EventArgs e)
        {
            txtC.Enabled = rdoBacHai.Checked;

            if (!txtC.Enabled)
                errorProvider1.SetError(txtC, "");

            txtKetQua.Clear();
            CapNhatNutGiai();
        }

        private void DuLieuThayDoi(object? sender, EventArgs e)
        {
            txtKetQua.Clear();

            if (sender is TextBox textBox)
                errorProvider1.SetError(textBox, "");

            CapNhatNutGiai();
        }

        private void CapNhatNutGiai()
        {
            bool aHopLe = ThuDocSo(txtA.Text, out _);
            bool bHopLe = ThuDocSo(txtB.Text, out _);

            // Bậc nhất không cần hệ số c.
            bool cHopLe = !rdoBacHai.Checked ||
                          ThuDocSo(txtC.Text, out _);

            btnGiai.Enabled = aHopLe && bHopLe && cHopLe;
        }

        private void btnGiai_Click(object? sender, EventArgs e)
        {
            bool aHopLe = KiemTraHeSo(txtA, out double a);
            bool bHopLe = KiemTraHeSo(txtB, out double b);

            double c = 0;
            bool cHopLe = true;

            if (rdoBacHai.Checked)
                cHopLe = KiemTraHeSo(txtC, out c);

            if (!aHopLe || !bHopLe || !cHopLe)
            {
                MessageBox.Show(
                    "Hãy kiểm tra các hệ số đã nhập.",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Form gọi class riêng để giải phương trình.
            PhuongTrinhBacHai phuongTrinh =
                new PhuongTrinhBacHai(a, b, c);

            txtKetQua.Text = rdoBacNhat.Checked
                ? phuongTrinh.GiaiBacNhat()
                : phuongTrinh.GiaiBacHai();

            // Theo đề: sau khi giải, nút Giải lại bị mờ.
            btnGiai.Enabled = false;
        }

        private void XacNhanThoat(
            object? sender,
            FormClosingEventArgs e)
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
}