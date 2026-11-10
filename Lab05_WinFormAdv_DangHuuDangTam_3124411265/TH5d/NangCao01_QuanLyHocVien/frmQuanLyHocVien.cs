using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NangCao01_QuanLyHocVien
{
    public class frmQuanLyHocVien : Form
    {
        private readonly ListBox lstLopA;
        private readonly ListBox lstLopB;

        public frmQuanLyHocVien()
        {
            Text = "TH5d - Quản lý học viên";
            ClientSize = new Size(860, 560);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // Tạo thanh menu.
            MenuStrip menu = new MenuStrip();
            menu.Font = Font;

            ToolStripMenuItem mucCapNhat =
                new ToolStripMenuItem("&Cập nhật");

            ToolStripMenuItem mucXoa =
                new ToolStripMenuItem("&Xóa học viên");

            ToolStripMenuItem mucChuyenA =
                new ToolStripMenuItem("Chuyển sang lớp &A");

            ToolStripMenuItem mucChuyenB =
                new ToolStripMenuItem("Chuyển sang lớp &B");

            ToolStripMenuItem mucNhapMoi =
                new ToolStripMenuItem("&Nhập học viên mới");

            ToolStripMenuItem mucKetThuc =
                new ToolStripMenuItem("&Kết thúc");

            mucCapNhat.DropDownItems.AddRange(
                new ToolStripItem[]
                {
                    mucXoa,
                    new ToolStripSeparator(),
                    mucChuyenA,
                    mucChuyenB,
                    new ToolStripSeparator(),
                    mucNhapMoi
                }
            );

            menu.Items.Add(mucCapNhat);
            menu.Items.Add(mucKetThuc);

            MainMenuStrip = menu;
            Controls.Add(menu);

            // Tiêu đề hai lớp.
            Label lblLopA = new Label();
            lblLopA.Text = "LỚP A";
            lblLopA.Font = new Font(
                "Segoe UI", 14, FontStyle.Bold
            );
            lblLopA.TextAlign = ContentAlignment.MiddleCenter;
            lblLopA.SetBounds(30, 60, 380, 35);
            Controls.Add(lblLopA);

            Label lblLopB = new Label();
            lblLopB.Text = "LỚP B";
            lblLopB.Font = lblLopA.Font;
            lblLopB.TextAlign = ContentAlignment.MiddleCenter;
            lblLopB.SetBounds(450, 60, 380, 35);
            Controls.Add(lblLopB);

            // Hai danh sách cho phép chọn nhiều học viên.
            lstLopA = new ListBox();
            lstLopA.SelectionMode = SelectionMode.MultiExtended;
            lstLopA.HorizontalScrollbar = true;
            lstLopA.SetBounds(30, 110, 380, 380);
            Controls.Add(lstLopA);

            lstLopB = new ListBox();
            lstLopB.SelectionMode = SelectionMode.MultiExtended;
            lstLopB.HorizontalScrollbar = true;
            lstLopB.SetBounds(450, 110, 380, 380);
            Controls.Add(lstLopB);

            Label lblHuongDan = new Label();
            lblHuongDan.Text =
                "Giữ Ctrl để chọn nhiều học viên; "
                + "giữ Shift để chọn một dãy.";
            lblHuongDan.SetBounds(30, 510, 800, 30);
            Controls.Add(lblHuongDan);

            // Gắn sự kiện của các mục menu.
            mucXoa.Click += (_, _) => XoaHocVien();

            mucChuyenA.Click += (_, _) =>
                ChuyenHocVien(lstLopB, lstLopA);

            mucChuyenB.Click += (_, _) =>
                ChuyenHocVien(lstLopA, lstLopB);

            mucNhapMoi.Click += (_, _) => MoFormNhap();

            mucKetThuc.Click += (_, _) => Close();

            FormClosing += FrmQuanLyHocVien_FormClosing;
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

        private void MoFormNhap()
        {
            using frmNhapHocVien formNhap =
                new frmNhapHocVien();

            // Mỗi lần Form nhập phát sự kiện, thêm tên
            // vào đúng ListBox trên Form chính.
            formNhap.HocVienDuocThem += (hoTen, lop) =>
            {
                if (lop == "Lớp A")
                {
                    lstLopA.Items.Add(hoTen);
                }
                else
                {
                    lstLopB.Items.Add(hoTen);
                }
            };

            formNhap.ShowDialog(this);
        }

        private static void XoaCacViTri(
            ListBox danhSach,
            int[] viTri)
        {
            // Xóa từ cuối về đầu để không lệch vị trí.
            foreach (int index in viTri.OrderByDescending(i => i))
            {
                danhSach.Items.RemoveAt(index);
            }
        }

        private void XoaHocVien()
        {
            // Chụp lựa chọn ở cả hai lớp trước khi xóa.
            int[] viTriA = lstLopA.SelectedIndices
                .Cast<int>()
                .ToArray();

            int[] viTriB = lstLopB.SelectedIndices
                .Cast<int>()
                .ToArray();

            if (viTriA.Length == 0 && viTriB.Length == 0)
            {
                ThongBao("Hãy chọn học viên cần xóa.");
                return;
            }

            XoaCacViTri(lstLopA, viTriA);
            XoaCacViTri(lstLopB, viTriB);
        }

        private void ChuyenHocVien(
            ListBox lopNguon,
            ListBox lopDich)
        {
            int[] viTri = lopNguon.SelectedIndices
                .Cast<int>()
                .ToArray();

            if (viTri.Length == 0)
            {
                ThongBao(
                    "Hãy chọn học viên trong lớp nguồn "
                    + "trước khi chuyển."
                );

                return;
            }

            // Lấy tên trước khi thay đổi danh sách.
            object[] hocVien = viTri
                .Select(index => lopNguon.Items[index])
                .ToArray();

            lopNguon.BeginUpdate();
            lopDich.BeginUpdate();

            try
            {
                // Thêm vào cuối lớp đích theo thứ tự lớp nguồn.
                lopDich.Items.AddRange(hocVien);

                // Sau đó loại khỏi lớp nguồn.
                XoaCacViTri(lopNguon, viTri);
            }
            finally
            {
                lopNguon.EndUpdate();
                lopDich.EndUpdate();
            }
        }

        private void FrmQuanLyHocVien_FormClosing(
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