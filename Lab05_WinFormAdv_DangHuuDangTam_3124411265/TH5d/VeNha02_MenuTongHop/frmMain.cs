using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace VeNha02_MenuTongHop
{
    public class frmMain : Form
    {
        // Mỗi loại Form chỉ mở một cửa sổ tại một thời điểm.
        private readonly Dictionary<Type, Form> cacForm =
            new Dictionary<Type, Form>();

        public frmMain()
        {
            Text = "Lab05 - Tổng hợp bài tập TH5c và TH5d";
            ClientSize = new Size(1200, 850);
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            Font = new Font("Segoe UI", 11);

            // Cho phép hiển thị Form con bên trong Form chính.
            IsMdiContainer = true;

            MenuStrip menu = new MenuStrip();
            menu.Font = Font;

            ToolStripMenuItem mucTH5c =
                new ToolStripMenuItem("Thực hành &5c");

            ToolStripMenuItem mucTH5d =
                new ToolStripMenuItem("Thực hành &5d");

            ToolStripMenuItem mucCuaSo =
                new ToolStripMenuItem("&Cửa sổ");

            ToolStripMenuItem mucKetThuc =
                new ToolStripMenuItem("&Kết thúc");

            // ---------- Các bài TH5c ----------

            ThemMucMenu(
                mucTH5c,
                "Tại lớp 1 - Ước số",
                () => MoForm<Bai01_UocSo.frmUocSo>()
            );

            ThemMucMenu(
                mucTH5c,
                "Tại lớp 2 - Quản lý sinh viên",
                () => MoForm<
                    Bai02_QuanLySinhVien.frmQuanLySinhVien>()
            );

            mucTH5c.DropDownItems.Add(
                new ToolStripSeparator()
            );

            ThemMucMenu(
                mucTH5c,
                "Nâng cao 1 - Xử lý chuỗi",
                () => MoForm<
                    NangCao01_XuLyChuoi.frmXuLyChuoi>()
            );

            mucTH5c.DropDownItems.Add(
                new ToolStripSeparator()
            );

            ThemMucMenu(
                mucTH5c,
                "Về nhà 1 - Từ điển",
                () => MoForm<VeNha01_TuDien.frmTuDien>()
            );

            ThemMucMenu(
                mucTH5c,
                "Về nhà 2 - ListBox số tự nhiên",
                () => MoForm<VeNha02_ListBoxSo.frmListBoxSo>()
            );

            ThemMucMenu(
                mucTH5c,
                "Về nhà 3 - Danh bạ",
                () => MoForm<VeNha03_DanhBa.frmDanhBa>()
            );

            // ---------- Các bài TH5d ----------

            ThemMucMenu(
                mucTH5d,
                "Tại lớp 1 - ListView sinh viên",
                () => MoForm<
                    Bai01_ListViewSinhVien.frmListViewSinhVien>()
            );

            ThemMucMenu(
                mucTH5d,
                "Tại lớp 2 - Tài khoản ngân hàng",
                () => MoForm<
                    Bai02_TaiKhoanNganHang.frmTaiKhoanNganHang>()
            );

            mucTH5d.DropDownItems.Add(
                new ToolStripSeparator()
            );

            ThemMucMenu(
                mucTH5d,
                "Nâng cao 1 - Quản lý học viên",
                () => MoForm<
                    NangCao01_QuanLyHocVien.frmQuanLyHocVien>()
            );

            mucTH5d.DropDownItems.Add(
                new ToolStripSeparator()
            );

            ThemMucMenu(
                mucTH5d,
                "Về nhà 1 - Đếm ngược thời gian",
                () => MoForm<VeNha01_DemNguoc.frmDemNguoc>()
            );

            // ---------- Sắp xếp các cửa sổ con ----------

            ThemMucMenu(
                mucCuaSo,
                "Xếp chồng",
                () => LayoutMdi(MdiLayout.Cascade)
            );

            ThemMucMenu(
                mucCuaSo,
                "Xếp ngang",
                () => LayoutMdi(MdiLayout.TileHorizontal)
            );

            ThemMucMenu(
                mucCuaSo,
                "Xếp dọc",
                () => LayoutMdi(MdiLayout.TileVertical)
            );

            // Menu Cửa sổ tự hiển thị danh sách Form đang mở.
            menu.MdiWindowListItem = mucCuaSo;

            mucKetThuc.Click += (_, _) => Close();

            menu.Items.AddRange(new ToolStripItem[]
            {
                mucTH5c,
                mucTH5d,
                mucCuaSo,
                mucKetThuc
            });

            MainMenuStrip = menu;
            Controls.Add(menu);

            FormClosing += FrmMain_FormClosing;
        }

        private void ThemMucMenu(
            ToolStripMenuItem menuCha,
            string noiDung,
            Action xuLy)
        {
            ToolStripMenuItem muc =
                new ToolStripMenuItem(noiDung);

            muc.Click += (_, _) => xuLy();

            menuCha.DropDownItems.Add(muc);
        }

        private void MoForm<T>() where T : Form, new()
        {
            Type loaiForm = typeof(T);

            // Nếu Form đã mở, đưa nó lên phía trước.
            if (cacForm.TryGetValue(loaiForm, out Form? daMo)
                && !daMo.IsDisposed)
            {
                if (daMo.WindowState == FormWindowState.Minimized)
                {
                    daMo.WindowState = FormWindowState.Normal;
                }

                daMo.Activate();
                return;
            }

            // Khởi tạo Form từ project đã tham chiếu.
            T formCon = new T();

            formCon.MdiParent = this;
            formCon.StartPosition = FormStartPosition.Manual;
            formCon.Location = new Point(20, 20);

            cacForm[loaiForm] = formCon;

            // Khi đóng Form con, cho phép mở lại một Form mới.
            formCon.FormClosed += (_, _) =>
            {
                cacForm.Remove(loaiForm);
            };

            formCon.Show();
        }

        private void FrmMain_FormClosing(
            object? sender,
            FormClosingEventArgs e)
        {
            // Form con vẫn giữ xử lý xác nhận đóng riêng
            // đã được viết ở các bài trước.
            if (e.Cancel)
            {
                return;
            }

            DialogResult luaChon = MessageBox.Show(
                this,
                "Bạn có muốn đóng chương trình tổng hợp không?",
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