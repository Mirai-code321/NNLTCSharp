using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Bai01_UocSo
{
    public class frmUocSo : Form
    {
        private readonly TextBox txtNhapSo;
        private readonly ComboBox cboDanhSachSo;
        private readonly ListBox lstUocSo;

        public frmUocSo()
        {
            // Thiết lập form.
            Text = "TH5c - Bài 1 - Danh sách ước số";
            ClientSize = new Size(760, 450);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // Khu vực nhập số.
            ThemLabel("Nhập số nguyên dương", 25, 25, 300);

            txtNhapSo = new TextBox();
            txtNhapSo.SetBounds(25, 60, 160, 30);
            Controls.Add(txtNhapSo);

            Button btnCapNhat = ThemButton(
                "&Cập nhật",
                200, 57, 130,
                CapNhatSo
            );

            // Nhấn Enter tại ô nhập để cập nhật số.
            AcceptButton = btnCapNhat;

            // ComboBox chỉ cho chọn các số đã được thêm.
            cboDanhSachSo = new ComboBox();
            cboDanhSachSo.DropDownStyle =
                ComboBoxStyle.DropDownList;

            cboDanhSachSo.SetBounds(25, 110, 305, 32);
            Controls.Add(cboDanhSachSo);

            // Khu vực hiển thị các ước số.
            ThemLabel("Danh sách các ước số", 380, 25, 340);

            lstUocSo = new ListBox();
            lstUocSo.SetBounds(380, 60, 340, 190);
            Controls.Add(lstUocSo);

            // Các nút xử lý.
            ThemButton(
                "&Tổng các ước số",
                380, 265, 340,
                TinhTongUocSo
            );

            ThemButton(
                "&Số lượng các ước số chẵn",
                380, 312, 340,
                DemUocChan
            );

            ThemButton(
                "Số lượng các ước số &nguyên tố",
                380, 359, 340,
                DemUocNguyenTo
            );

            ThemButton(
                "T&hoát",
                200, 359, 130,
                Close
            );

            // Gắn các sự kiện.
            txtNhapSo.KeyPress += TxtNhapSo_KeyPress;

            cboDanhSachSo.SelectedIndexChanged +=
                CboDanhSachSo_SelectedIndexChanged;

            FormClosing += FrmUocSo_FormClosing;

            Shown += (_, _) => txtNhapSo.Focus();
        }

        // Tạo Label để giảm lặp code giao diện.
        private void ThemLabel(
            string noiDung,
            int x,
            int y,
            int rong)
        {
            Label label = new Label();
            label.Text = noiDung;
            label.SetBounds(x, y, rong, 28);

            Controls.Add(label);
        }

        // Dấu & trong Text tạo phím tắt Alt + ký tự phía sau.
        private Button ThemButton(
            string noiDung,
            int x,
            int y,
            int rong,
            Action xuLy)
        {
            Button button = new Button();
            button.Text = noiDung;
            button.UseMnemonic = true;
            button.SetBounds(x, y, rong, 38);

            button.Click += (_, _) => xuLy();

            Controls.Add(button);

            return button;
        }

        // Chặn ký tự khác chữ số khi người dùng gõ.
        // Vẫn cho phép Backspace và các ký tự điều khiển.
        private void TxtNhapSo_KeyPress(
            object? sender,
            KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CapNhatSo()
        {
            // TryParse kiểm tra cả dữ liệu được dán vào TextBox
            // và trường hợp số vượt giới hạn kiểu int.
            if (!int.TryParse(txtNhapSo.Text.Trim(), out int n)
                || n <= 0)
            {
                MessageBox.Show(
                    this,
                    "Hãy nhập số nguyên dương từ 1 đến 2147483647.",
                    "Dữ liệu không hợp lệ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNhapSo.Focus();
                txtNhapSo.SelectAll();

                return;
            }

            // ComboBox lưu trực tiếp giá trị int,
            // nên 20 và 020 được xem là cùng một số.
            if (cboDanhSachSo.Items.Contains(n))
            {
                MessageBox.Show(
                    this,
                    "Số này đã tồn tại trong danh sách.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtNhapSo.Focus();
                txtNhapSo.SelectAll();

                return;
            }

            cboDanhSachSo.Items.Add(n);

            // Chọn số vừa thêm để hiển thị ngay các ước số.
            cboDanhSachSo.SelectedItem = n;

            txtNhapSo.Clear();
            txtNhapSo.Focus();
        }

        private void CboDanhSachSo_SelectedIndexChanged(
            object? sender,
            EventArgs e)
        {
            lstUocSo.Items.Clear();

            if (cboDanhSachSo.SelectedItem is not int n)
            {
                return;
            }

            List<int> danhSachUoc = TimUocSo(n);

            foreach (int uoc in danhSachUoc)
            {
                lstUocSo.Items.Add(uoc);
            }
        }

        private static List<int> TimUocSo(int n)
        {
            List<int> ketQua = new List<int>();

            // Ước xuất hiện theo cặp i và n / i.
            // i <= n / i tương đương i * i <= n,
            // nhưng tránh tràn số khi nhân.
            for (int i = 1; i <= n / i; i++)
            {
                if (n % i == 0)
                {
                    ketQua.Add(i);

                    int uocConLai = n / i;

                    // Với số chính phương, chỉ thêm căn một lần.
                    if (uocConLai != i)
                    {
                        ketQua.Add(uocConLai);
                    }
                }
            }

            ketQua.Sort();

            return ketQua;
        }

        private bool KiemTraDaChonSo()
        {
            if (cboDanhSachSo.SelectedIndex >= 0)
            {
                return true;
            }

            MessageBox.Show(
                this,
                "Hãy thêm và chọn một số trước khi tính.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

            return false;
        }

        private void TinhTongUocSo()
        {
            if (!KiemTraDaChonSo())
            {
                return;
            }

            // Dùng long để tổng không bị tràn kiểu int.
            long tong = 0;

            foreach (int uoc in lstUocSo.Items)
            {
                tong += uoc;
            }

            HienKetQua($"Tổng các ước số = {tong}");
        }

        private void DemUocChan()
        {
            if (!KiemTraDaChonSo())
            {
                return;
            }

            int soLuong = 0;

            foreach (int uoc in lstUocSo.Items)
            {
                if (uoc % 2 == 0)
                {
                    soLuong++;
                }
            }

            HienKetQua($"Số lượng các ước số chẵn = {soLuong}");
        }

        private static bool LaSoNguyenTo(int n)
        {
            // 0 và 1 không phải số nguyên tố.
            if (n < 2)
            {
                return false;
            }

            for (int i = 2; i <= n / i; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        private void DemUocNguyenTo()
        {
            if (!KiemTraDaChonSo())
            {
                return;
            }

            int soLuong = 0;

            foreach (int uoc in lstUocSo.Items)
            {
                if (LaSoNguyenTo(uoc))
                {
                    soLuong++;
                }
            }

            HienKetQua(
                $"Số lượng các ước số nguyên tố = {soLuong}"
            );
        }

        private void HienKetQua(string noiDung)
        {
            MessageBox.Show(
                this,
                noiDung,
                "Kết quả",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void FrmUocSo_FormClosing(
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

            // Chọn No thì hủy thao tác đóng form.
            if (luaChon != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}