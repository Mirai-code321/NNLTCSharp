using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace VeNha02_ListBoxSo
{
    public class frmListBoxSo : Form
    {
        private readonly TextBox txtNhapSo;
        private readonly ListBox lstSo;

        public frmListBoxSo()
        {
            Text = "TH5c - Bài về nhà 2 - Xử lý ListBox";
            ClientSize = new Size(880, 590);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "XỬ LÝ LISTBOX SỐ TỰ NHIÊN";
            lblTieuDe.Font = new Font(
                "Segoe UI", 16, FontStyle.Bold
            );
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.SetBounds(20, 15, 840, 45);
            Controls.Add(lblTieuDe);

            // Khu vực nhập và hiển thị danh sách.
            GroupBox grpDanhSach = new GroupBox();
            grpDanhSach.Text = "Danh sách số";
            grpDanhSach.SetBounds(20, 75, 310, 425);
            Controls.Add(grpDanhSach);

            txtNhapSo = new TextBox();
            txtNhapSo.SetBounds(20, 35, 270, 30);
            grpDanhSach.Controls.Add(txtNhapSo);

            Button btnNhap = ThemButton(
                grpDanhSach,
                "&Nhập",
                20, 80, 270,
                NhapSo
            );

            lstSo = new ListBox();

            // Cho phép chọn nhiều mục bằng Ctrl hoặc Shift.
            lstSo.SelectionMode = SelectionMode.MultiExtended;
            lstSo.HorizontalScrollbar = true;
            lstSo.SetBounds(20, 135, 270, 270);
            grpDanhSach.Controls.Add(lstSo);

            // Khu vực các nút xử lý.
            GroupBox grpXuLy = new GroupBox();
            grpXuLy.Text = "Xử lý ListBox";
            grpXuLy.SetBounds(350, 75, 510, 425);
            Controls.Add(grpXuLy);

            ThemButton(
                grpXuLy,
                "&Tổng các phần tử trong List",
                20, 35, 470,
                TinhTong
            );

            ThemButton(
                grpXuLy,
                "Xóa phần tử &đầu và cuối",
                20, 90, 470,
                XoaDauCuoi
            );

            ThemButton(
                grpXuLy,
                "&Xóa phần tử đang chọn",
                20, 145, 470,
                XoaDangChon
            );

            ThemButton(
                grpXuLy,
                "Tăng mỗi phần tử lên &2",
                20, 200, 470,
                () => BienDoiDanhSach(n => n + 2)
            );

            ThemButton(
                grpXuLy,
                "Thay bằng &bình phương",
                20, 255, 470,
                () => BienDoiDanhSach(n => n * n)
            );

            ThemButton(
                grpXuLy,
                "Chọn số &chẵn",
                20, 310, 470,
                () => ChonTheoTinhChanLe(true)
            );

            ThemButton(
                grpXuLy,
                "Chọn số &lẻ",
                20, 365, 470,
                () => ChonTheoTinhChanLe(false)
            );

            ThemButton(
                this,
                "&Kết thúc",
                20, 525, 840,
                Close
            );

            // Enter để thêm số.
            AcceptButton = btnNhap;

            txtNhapSo.KeyPress += TxtNhapSo_KeyPress;
            FormClosing += FrmListBoxSo_FormClosing;

            Shown += (_, _) => txtNhapSo.Focus();
        }

        private Button ThemButton(
            Control parent,
            string noiDung,
            int x,
            int y,
            int rong,
            Action xuLy)
        {
            Button button = new Button();
            button.Text = noiDung;
            button.SetBounds(x, y, rong, 38);
            button.Click += (_, _) => xuLy();

            parent.Controls.Add(button);

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

        private bool KiemTraDanhSach()
        {
            if (lstSo.Items.Count > 0)
            {
                return true;
            }

            ThongBao("Danh sách đang rỗng. Hãy nhập số trước.");
            txtNhapSo.Focus();

            return false;
        }

        private void TxtNhapSo_KeyPress(
            object? sender,
            KeyPressEventArgs e)
        {
            // Chỉ cho gõ chữ số từ 0 đến 9.
            // Cho phép Backspace và các ký tự điều khiển.
            bool laChuSo =
                e.KeyChar >= '0' && e.KeyChar <= '9';

            if (!char.IsControl(e.KeyChar) && !laChuSo)
            {
                e.Handled = true;
            }
        }

        private void NhapSo()
        {
            string duLieu = txtNhapSo.Text.Trim();

            // Kiểm tra cả dữ liệu được dán vào TextBox.
            bool chiCoChuSo =
                duLieu.Length > 0
                && duLieu.All(c => c >= '0' && c <= '9');

            if (!chiCoChuSo
                || !BigInteger.TryParse(
                    duLieu,
                    NumberStyles.None,
                    CultureInfo.InvariantCulture,
                    out BigInteger n))
            {
                ThongBao(
                    "Hãy nhập số tự nhiên: 0 hoặc số nguyên dương."
                );

                txtNhapSo.Focus();
                txtNhapSo.SelectAll();

                return;
            }

            // Lưu trực tiếp BigInteger, không lưu chuỗi.
            // Đề không yêu cầu kiểm tra trùng.
            lstSo.Items.Add(n);

            txtNhapSo.Clear();
            txtNhapSo.Focus();
        }

        private void TinhTong()
        {
            if (!KiemTraDanhSach())
            {
                return;
            }

            BigInteger tong = BigInteger.Zero;

            foreach (BigInteger n in lstSo.Items)
            {
                tong += n;
            }

            MessageBox.Show(
                this,
                $"Tổng các phần tử = {tong}",
                "Kết quả",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void XoaDauCuoi()
        {
            if (!KiemTraDanhSach())
            {
                return;
            }

            // Xóa cuối trước để không ảnh hưởng vị trí đầu.
            lstSo.Items.RemoveAt(lstSo.Items.Count - 1);

            // Nếu ban đầu chỉ có một phần tử thì đã xóa xong.
            if (lstSo.Items.Count > 0)
            {
                lstSo.Items.RemoveAt(0);
            }
        }

        private void XoaDangChon()
        {
            if (!KiemTraDanhSach())
            {
                return;
            }

            // Lấy vị trí trước khi thay đổi danh sách.
            int[] viTri = lstSo.SelectedIndices
                .Cast<int>()
                .OrderByDescending(index => index)
                .ToArray();

            if (viTri.Length == 0)
            {
                ThongBao("Hãy chọn các phần tử cần xóa.");
                return;
            }

            // Xóa từ cuối về đầu để không lệch vị trí.
            foreach (int index in viTri)
            {
                lstSo.Items.RemoveAt(index);
            }
        }

        private void BienDoiDanhSach(
            Func<BigInteger, BigInteger> bienDoi)
        {
            if (!KiemTraDanhSach())
            {
                return;
            }

            // Tính toàn bộ giá trị mới trước khi cập nhật giao diện.
            BigInteger[] giaTriMoi = lstSo.Items
                .Cast<BigInteger>()
                .Select(bienDoi)
                .ToArray();

            int[] viTriDangChon = lstSo.SelectedIndices
                .Cast<int>()
                .ToArray();

            int viTriCuon = lstSo.TopIndex;

            lstSo.BeginUpdate();

            try
            {
                // Nạp lại các mục để nội dung hiển thị cập nhật ngay.
                lstSo.Items.Clear();

                foreach (BigInteger n in giaTriMoi)
                {
                    lstSo.Items.Add(n);
                }

                // Giữ lại các vị trí đang chọn.
                foreach (int index in viTriDangChon)
                {
                    lstSo.SetSelected(index, true);
                }

                lstSo.TopIndex = viTriCuon;
            }
            finally
            {
                lstSo.EndUpdate();
            }

            lstSo.Refresh();
        }

        private void ChonTheoTinhChanLe(bool chonChan)
        {
            if (!KiemTraDanhSach())
            {
                return;
            }

            lstSo.BeginUpdate();

            try
            {
                // Bỏ lựa chọn cũ trước khi chọn theo điều kiện mới.
                lstSo.ClearSelected();

                for (int i = 0; i < lstSo.Items.Count; i++)
                {
                    BigInteger n = (BigInteger)lstSo.Items[i];

                    if (n.IsEven == chonChan)
                    {
                        lstSo.SetSelected(i, true);
                    }
                }
            }
            finally
            {
                lstSo.EndUpdate();
            }

            lstSo.Refresh();
        }

        private void FrmListBoxSo_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            DialogResult luaChon = MessageBox.Show(
                this,
                "Bạn có muốn kết thúc chương trình không?",
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