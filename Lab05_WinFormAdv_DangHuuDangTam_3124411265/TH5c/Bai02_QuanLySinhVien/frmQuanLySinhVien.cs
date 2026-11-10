using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bai02_QuanLySinhVien
{
    // Lưu thông tin sinh viên riêng với nội dung hiển thị trên TreeView.
    public class SinhVien
    {
        public string MaSV { get; }
        public string HoTen { get; }
        public string DiaChi { get; }

        public SinhVien(string maSV, string hoTen, string diaChi)
        {
            MaSV = maSV;
            HoTen = hoTen;
            DiaChi = diaChi;
        }
    }

    public class frmQuanLySinhVien : Form
    {
        private readonly TreeView trvDanhSach;
        private readonly TreeNode nodeGoc;
        private readonly ComboBox cboLop;

        private readonly TextBox txtMaSV;
        private readonly TextBox txtHoTen;
        private readonly TextBox txtDiaChi;
        private readonly TextBox txtTenLop;

        private readonly CheckBox chkThemLop;
        private readonly GroupBox grpThongTinLop;

        // Mã sinh viên không được trùng trên toàn bộ các lớp.
        // So sánh không phân biệt chữ hoa, chữ thường.
        private readonly Dictionary<string, SinhVien> danhSachSV =
            new Dictionary<string, SinhVien>(
                StringComparer.OrdinalIgnoreCase
            );

        public frmQuanLySinhVien()
        {
            Text = "TH5c - Bài 2 - Quản lý sinh viên";
            ClientSize = new Size(900, 590);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // TreeView chứa: danh sách lớp -> lớp -> sinh viên -> địa chỉ.
            trvDanhSach = new TreeView();
            trvDanhSach.HideSelection = false;
            trvDanhSach.SetBounds(20, 20, 340, 540);
            Controls.Add(trvDanhSach);

            nodeGoc = trvDanhSach.Nodes.Add("Danh sách lớp");

            ThemLabel(this, "Chọn lớp", 390, 25, 100);

            cboLop = new ComboBox();
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.SetBounds(510, 22, 350, 32);
            Controls.Add(cboLop);

            // Nhóm thông tin sinh viên.
            GroupBox grpSinhVien = new GroupBox();
            grpSinhVien.Text = "Thông tin sinh viên";
            grpSinhVien.SetBounds(385, 75, 480, 285);
            Controls.Add(grpSinhVien);

            ThemLabel(grpSinhVien, "Mã SV", 20, 40, 100);
            txtMaSV = ThemTextBox(grpSinhVien, 130, 37, 325);

            ThemLabel(grpSinhVien, "Họ tên", 20, 100, 100);
            txtHoTen = ThemTextBox(grpSinhVien, 130, 97, 325);

            ThemLabel(grpSinhVien, "Địa chỉ", 20, 160, 100);
            txtDiaChi = ThemTextBox(grpSinhVien, 130, 157, 325);

            ThemButton(
                grpSinhVien, "&Cập nhật",
                130, 220, 160, ThemSinhVien
            );

            ThemButton(
                grpSinhVien, "&Xóa",
                320, 220, 135, XoaSinhVien
            );

            // Checkbox ban đầu chưa chọn.
            chkThemLop = new CheckBox();
            chkThemLop.Text = "Thêm lớp";
            chkThemLop.Checked = false;
            chkThemLop.SetBounds(390, 380, 180, 30);
            Controls.Add(chkThemLop);

            // Ẩn GroupBox cũng đồng thời ẩn các control bên trong.
            grpThongTinLop = new GroupBox();
            grpThongTinLop.Text = "Thông tin lớp";
            grpThongTinLop.SetBounds(385, 425, 480, 85);
            grpThongTinLop.Visible = false;
            Controls.Add(grpThongTinLop);

            ThemLabel(grpThongTinLop, "Tên lớp", 15, 35, 95);
            txtTenLop = ThemTextBox(
                grpThongTinLop, 110, 32, 205
            );

            ThemButton(
                grpThongTinLop, "&Thêm lớp",
                330, 29, 130, ThemLopMoi
            );

            ThemButton(
                this, "T&hoát",
                715, 530, 150, Close
            );

            // Các lớp có sẵn theo hình minh họa trong đề.
            string[] cacLop =
            {
                "05DHTH1",
                "05DHTH2",
                "05DHTH3",
                "05DHTH4"
            };

            foreach (string tenLop in cacLop)
            {
                ThemLopVaoDanhSach(tenLop);
            }

            cboLop.SelectedIndex = 0;
            nodeGoc.Expand();

            // Gắn sự kiện.
            chkThemLop.CheckedChanged += (_, _) =>
            {
                grpThongTinLop.Visible = chkThemLop.Checked;

                if (chkThemLop.Checked)
                {
                    txtTenLop.Focus();
                }
            };

            trvDanhSach.AfterSelect +=
                TrvDanhSach_AfterSelect;

            FormClosing += FrmQuanLySinhVien_FormClosing;
        }

        private void ThemLabel(
            Control parent,
            string noiDung,
            int x,
            int y,
            int rong)
        {
            Label label = new Label();
            label.Text = noiDung;
            label.SetBounds(x, y, rong, 28);

            parent.Controls.Add(label);
        }

        private TextBox ThemTextBox(
            Control parent,
            int x,
            int y,
            int rong)
        {
            TextBox textBox = new TextBox();
            textBox.SetBounds(x, y, rong, 30);

            parent.Controls.Add(textBox);

            return textBox;
        }

        private void ThemButton(
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

        // Dùng chung khi khởi tạo và khi thêm lớp mới.
        private void ThemLopVaoDanhSach(string tenLop)
        {
            nodeGoc.Nodes.Add(tenLop);
            cboLop.Items.Add(tenLop);
        }

        private void ThemLopMoi()
        {
            string tenLop = txtTenLop.Text.Trim();

            if (string.IsNullOrWhiteSpace(tenLop))
            {
                ThongBao("Tên lớp không được để trống.");
                txtTenLop.Focus();
                return;
            }

            // Kiểm tra tên lớp, không phân biệt hoa thường.
            bool daTonTai = nodeGoc.Nodes
                .Cast<TreeNode>()
                .Any(node => string.Equals(
                    node.Text,
                    tenLop,
                    StringComparison.OrdinalIgnoreCase
                ));

            if (daTonTai)
            {
                ThongBao("Tên lớp đã tồn tại.");
                txtTenLop.Focus();
                txtTenLop.SelectAll();
                return;
            }

            ThemLopVaoDanhSach(tenLop);

            // Chọn lớp mới trong ComboBox.
            cboLop.SelectedItem = tenLop;
            nodeGoc.Expand();

            txtTenLop.Clear();
            txtTenLop.Focus();
        }

        private void ThemSinhVien()
        {
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();

            if (string.IsNullOrWhiteSpace(maSV))
            {
                ThongBao("Mã sinh viên không được để trống.");
                txtMaSV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                ThongBao("Họ tên không được để trống.");
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(diaChi))
            {
                ThongBao("Địa chỉ không được để trống.");
                txtDiaChi.Focus();
                return;
            }

            if (cboLop.SelectedItem is not string tenLop)
            {
                ThongBao("Hãy chọn lớp cho sinh viên.");
                return;
            }

            if (danhSachSV.ContainsKey(maSV))
            {
                ThongBao("Mã sinh viên đã tồn tại.");
                txtMaSV.Focus();
                txtMaSV.SelectAll();
                return;
            }

            // Tìm node lớp tương ứng với lớp trong ComboBox.
            TreeNode? nodeLop = nodeGoc.Nodes
                .Cast<TreeNode>()
                .FirstOrDefault(node => node.Text == tenLop);

            if (nodeLop == null)
            {
                ThongBao("Không tìm thấy lớp được chọn.");
                return;
            }

            SinhVien sinhVien = new SinhVien(
                maSV, hoTen, diaChi
            );

            TreeNode nodeSinhVien = new TreeNode(
                $"{maSV}, {hoTen}"
            );

            // Tag lưu dữ liệu thật của sinh viên.
            nodeSinhVien.Tag = sinhVien;

            // Địa chỉ là node con, giống hình trong đề.
            nodeSinhVien.Nodes.Add(diaChi);

            nodeLop.Nodes.Add(nodeSinhVien);
            danhSachSV.Add(maSV, sinhVien);

            nodeGoc.Expand();
            nodeLop.Expand();
            nodeSinhVien.Expand();
            nodeSinhVien.EnsureVisible();

            XoaThongTinNhap();
            txtMaSV.Focus();
        }

        private void TrvDanhSach_AfterSelect(
            object? sender,
            TreeViewEventArgs e)
        {
            // Chỉ node sinh viên có Tag là đối tượng SinhVien.
            if (e.Node?.Tag is SinhVien sinhVien)
            {
                txtMaSV.Text = sinhVien.MaSV;
                txtHoTen.Text = sinhVien.HoTen;
                txtDiaChi.Text = sinhVien.DiaChi;

                // Đồng thời chọn đúng lớp của sinh viên.
                if (e.Node.Parent != null)
                {
                    cboLop.SelectedItem = e.Node.Parent.Text;
                }
            }
        }

        private void XoaSinhVien()
        {
            TreeNode? nodeDangChon = trvDanhSach.SelectedNode;

            // Không cho xóa node gốc, node lớp hoặc node địa chỉ.
            if (nodeDangChon?.Tag is not SinhVien sinhVien)
            {
                ThongBao(
                    "Hãy chọn node sinh viên cần xóa, "
                    + "không chọn node lớp hoặc địa chỉ."
                );

                return;
            }

            DialogResult luaChon = MessageBox.Show(
                this,
                $"Bạn có muốn xóa sinh viên "
                    + $"{sinhVien.MaSV} - {sinhVien.HoTen}?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (luaChon != DialogResult.Yes)
            {
                return;
            }

            // Xóa đồng thời trên giao diện và danh sách dữ liệu.
            nodeDangChon.Remove();
            danhSachSV.Remove(sinhVien.MaSV);

            XoaThongTinNhap();
            txtMaSV.Focus();
        }

        private void XoaThongTinNhap()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
        }

        private void FrmQuanLySinhVien_FormClosing(
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