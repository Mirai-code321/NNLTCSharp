using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bai01_ListViewSinhVien
{
    public class frmListViewSinhVien : Form
    {
        private readonly TextBox txtHoTen;
        private readonly TextBox txtMaSV;

        private readonly RadioButton rdoNam;
        private readonly RadioButton rdoNu;

        private readonly CheckBox chkAnh;
        private readonly CheckBox chkPhap;
        private readonly CheckBox chkHoa;

        private readonly ComboBox cboDanToc;
        private readonly ListView lvSinhVien;

        private readonly Button btnThem;
        private readonly Button btnXoa;
        private readonly Button btnSua;

        private readonly ContextMenuStrip menuChuOtPhai;

        public frmListViewSinhVien()
        {
            Text = "TH5d - Bài 1 - Quản lý sinh viên";
            ClientSize = new Size(900, 650);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            ThemLabel("Họ và tên", 50, 30);
            txtHoTen = ThemTextBox(210, 27, 590);

            ThemLabel("Mã sinh viên", 50, 80);
            txtMaSV = ThemTextBox(210, 77, 590);

            ThemLabel("Giới tính", 50, 135);

            // Đặt hai RadioButton cùng Panel để chúng
            // thuộc một nhóm lựa chọn.
            Panel pnlGioiTinh = new Panel();
            pnlGioiTinh.SetBounds(210, 125, 400, 40);
            Controls.Add(pnlGioiTinh);

            rdoNam = new RadioButton();
            rdoNam.Text = "Nam";
            rdoNam.Checked = true;
            rdoNam.SetBounds(0, 5, 120, 30);
            pnlGioiTinh.Controls.Add(rdoNam);

            rdoNu = new RadioButton();
            rdoNu.Text = "Nữ";
            rdoNu.SetBounds(150, 5, 120, 30);
            pnlGioiTinh.Controls.Add(rdoNu);

            ThemLabel("Ngoại ngữ", 50, 185);

            chkAnh = ThemCheckBox("Anh", 210, 180);
            chkPhap = ThemCheckBox("Pháp", 360, 180);
            chkHoa = ThemCheckBox("Hoa", 510, 180);

            ThemLabel("Dân tộc", 50, 235);

            cboDanToc = new ComboBox();
            cboDanToc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDanToc.SetBounds(210, 232, 590, 32);
            Controls.Add(cboDanToc);

            // ListView hiển thị dữ liệu theo các cột.
            lvSinhVien = new ListView();
            lvSinhVien.View = View.Details;
            lvSinhVien.FullRowSelect = true;
            lvSinhVien.GridLines = true;
            lvSinhVien.MultiSelect = false;
            lvSinhVien.HideSelection = false;
            lvSinhVien.SetBounds(30, 290, 840, 250);

            lvSinhVien.Columns.Add("Họ tên", 240);
            lvSinhVien.Columns.Add("Mã sinh viên", 150);
            lvSinhVien.Columns.Add("Giới tính", 100);
            lvSinhVien.Columns.Add("Ngoại ngữ", 190);
            lvSinhVien.Columns.Add("Dân tộc", 130);

            Controls.Add(lvSinhVien);

            btnThem = ThemButton(
                "&Thêm", 30, 565, 150, ThemSinhVien
            );

            btnXoa = ThemButton(
                "&Xóa", 200, 565, 150, XoaSinhVien
            );

            btnSua = ThemButton(
                "&Sửa", 370, 565, 150, SuaSinhVien
            );

            ThemButton(
                "&Nhập mới", 540, 565, 150, NhapMoi
            );

            ThemButton(
                "T&hoát", 710, 565, 160, Close
            );

            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            // Menu xuất hiện khi nhấn chuột phải trên ListView.
            menuChuOtPhai = new ContextMenuStrip();

            ToolStripMenuItem mucXoa =
                new ToolStripMenuItem("Xóa sinh viên");

            mucXoa.Click += (_, _) => XoaSinhVien();

            menuChuOtPhai.Items.Add(mucXoa);
            lvSinhVien.ContextMenuStrip = menuChuOtPhai;

            menuChuOtPhai.Opening += (_, _) =>
            {
                mucXoa.Enabled =
                    lvSinhVien.SelectedItems.Count == 1;
            };

            // Chuột phải vào dòng nào thì chọn đúng dòng đó.
            lvSinhVien.MouseDown += (_, e) =>
            {
                if (e.Button != MouseButtons.Right)
                {
                    return;
                }

                ListViewItem? item =
                    lvSinhVien.HitTest(e.Location).Item;

                // Chụp danh sách trước khi bỏ lựa chọn.
                foreach (ListViewItem selected in
                    lvSinhVien.SelectedItems
                        .Cast<ListViewItem>()
                        .ToArray())
                {
                    selected.Selected = false;
                }

                if (item != null)
                {
                    item.Selected = true;
                    item.Focused = true;
                }
            };

            lvSinhVien.SelectedIndexChanged +=
                LvSinhVien_SelectedIndexChanged;

            Load += FrmListViewSinhVien_Load;
            FormClosing += FrmListViewSinhVien_FormClosing;
        }

        private void ThemLabel(string noiDung, int x, int y)
        {
            Label label = new Label();
            label.Text = noiDung;
            label.SetBounds(x, y, 150, 30);
            Controls.Add(label);
        }

        private TextBox ThemTextBox(int x, int y, int rong)
        {
            TextBox textBox = new TextBox();
            textBox.SetBounds(x, y, rong, 30);
            Controls.Add(textBox);

            return textBox;
        }

        private CheckBox ThemCheckBox(
            string noiDung, int x, int y)
        {
            CheckBox checkBox = new CheckBox();
            checkBox.Text = noiDung;
            checkBox.SetBounds(x, y, 120, 30);
            Controls.Add(checkBox);

            return checkBox;
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
            button.SetBounds(x, y, rong, 42);
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

        private void FrmListViewSinhVien_Load(
            object? sender,
            EventArgs e)
        {
            // Nạp dữ liệu dân tộc khi mở Form.
            cboDanToc.Items.AddRange(new object[]
            {
                "Kinh",
                "Hoa",
                "Khmer",
                "H'Mông",
                "Khác"
            });

            NhapMoi();
        }

        private bool KiemTraThongTin()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                ThongBao("Họ tên không được để trống.");
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                ThongBao("Mã sinh viên không được để trống.");
                txtMaSV.Focus();
                return false;
            }

            if (cboDanToc.SelectedIndex < 0)
            {
                ThongBao("Hãy chọn dân tộc.");
                cboDanToc.Focus();
                return false;
            }

            return true;
        }

        private string LayNgoaiNgu()
        {
            List<string> ngoaiNgu = new List<string>();

            if (chkAnh.Checked)
            {
                ngoaiNgu.Add("Anh");
            }

            if (chkPhap.Checked)
            {
                ngoaiNgu.Add("Pháp");
            }

            if (chkHoa.Checked)
            {
                ngoaiNgu.Add("Hoa");
            }

            // Không chọn ngoại ngữ thì để trống cột.
            return string.Join(", ", ngoaiNgu);
        }

        private void ThemSinhVien()
        {
            if (!KiemTraThongTin())
            {
                return;
            }

            string maSV = txtMaSV.Text.Trim();

            bool trungMa = lvSinhVien.Items
                .Cast<ListViewItem>()
                .Any(item => string.Equals(
                    item.SubItems[1].Text,
                    maSV,
                    StringComparison.OrdinalIgnoreCase
                ));

            if (trungMa)
            {
                ThongBao("Mã sinh viên đã tồn tại.");
                txtMaSV.Focus();
                txtMaSV.SelectAll();
                return;
            }

            ListViewItem itemMoi = new ListViewItem(new[]
            {
                txtHoTen.Text.Trim(),
                maSV,
                rdoNam.Checked ? "Nam" : "Nữ",
                LayNgoaiNgu(),
                cboDanToc.SelectedItem!.ToString()!
            });

            lvSinhVien.Items.Add(itemMoi);
            itemMoi.EnsureVisible();

            NhapMoi();
        }

        private void LvSinhVien_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            bool daChon =
                lvSinhVien.SelectedItems.Count == 1;

            btnSua.Enabled = daChon;
            btnXoa.Enabled = daChon;
            btnThem.Enabled = !daChon;

            // Không được chỉnh mã khi chọn sinh viên để sửa.
            txtMaSV.ReadOnly = daChon;

            if (!daChon)
            {
                return;
            }

            ListViewItem item = lvSinhVien.SelectedItems[0];

            txtHoTen.Text = item.SubItems[0].Text;
            txtMaSV.Text = item.SubItems[1].Text;

            rdoNam.Checked = item.SubItems[2].Text == "Nam";
            rdoNu.Checked = item.SubItems[2].Text == "Nữ";

            string[] ngoaiNgu = item.SubItems[3].Text.Split(
                ',',
                StringSplitOptions.TrimEntries
                | StringSplitOptions.RemoveEmptyEntries
            );

            chkAnh.Checked = ngoaiNgu.Contains("Anh");
            chkPhap.Checked = ngoaiNgu.Contains("Pháp");
            chkHoa.Checked = ngoaiNgu.Contains("Hoa");

            cboDanToc.SelectedItem = item.SubItems[4].Text;
        }

        private void SuaSinhVien()
        {
            if (lvSinhVien.SelectedItems.Count != 1)
            {
                ThongBao("Hãy chọn sinh viên cần sửa.");
                return;
            }

            if (!KiemTraThongTin())
            {
                return;
            }

            ListViewItem item = lvSinhVien.SelectedItems[0];

            // Chỉ cập nhật các cột được phép sửa.
            // Không gán lại SubItems[1] là mã sinh viên.
            item.SubItems[0].Text = txtHoTen.Text.Trim();
            item.SubItems[2].Text =
                rdoNam.Checked ? "Nam" : "Nữ";

            item.SubItems[3].Text = LayNgoaiNgu();
            item.SubItems[4].Text =
                cboDanToc.SelectedItem!.ToString()!;

            lvSinhVien.Refresh();
        }

        private void XoaSinhVien()
        {
            if (lvSinhVien.SelectedItems.Count != 1)
            {
                ThongBao("Hãy chọn sinh viên cần xóa.");
                return;
            }

            ListViewItem item = lvSinhVien.SelectedItems[0];

            DialogResult luaChon = MessageBox.Show(
                this,
                $"Xóa sinh viên {item.SubItems[1].Text}"
                    + $" - {item.Text}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (luaChon != DialogResult.Yes)
            {
                return;
            }

            lvSinhVien.Items.Remove(item);
            NhapMoi();
        }

        private void NhapMoi()
        {
            foreach (ListViewItem item in
                lvSinhVien.SelectedItems
                    .Cast<ListViewItem>()
                    .ToArray())
            {
                item.Selected = false;
            }

            txtHoTen.Clear();
            txtMaSV.Clear();
            txtMaSV.ReadOnly = false;

            rdoNam.Checked = true;

            chkAnh.Checked = false;
            chkPhap.Checked = false;
            chkHoa.Checked = false;

            if (cboDanToc.Items.Count > 0)
            {
                cboDanToc.SelectedIndex = 0;
            }

            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            txtHoTen.Focus();
        }

        private void FrmListViewSinhVien_FormClosing(
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

        // Giải phóng menu khi Form được giải phóng.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                menuChuOtPhai?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}