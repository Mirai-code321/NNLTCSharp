using System;
using System.Drawing;
using System.Windows.Forms;

namespace NangCao01_QuanLyHocVien
{
    public class frmNhapHocVien : Form
    {
        private readonly TextBox txtHoTen;
        private readonly ComboBox cboLop;

        // Form chính đăng ký sự kiện để nhận họ tên và lớp.
        public event Action<string, string>? HocVienDuocThem;

        public frmNhapHocVien()
        {
            Text = "Nhập học viên mới";
            ClientSize = new Size(560, 260);
            StartPosition = FormStartPosition.CenterParent;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            Label lblHoTen = new Label();
            lblHoTen.Text = "Họ và tên";
            lblHoTen.SetBounds(25, 40, 110, 30);
            Controls.Add(lblHoTen);

            txtHoTen = new TextBox();
            txtHoTen.SetBounds(150, 37, 380, 30);
            Controls.Add(txtHoTen);

            Label lblLop = new Label();
            lblLop.Text = "Lớp";
            lblLop.SetBounds(25, 105, 110, 30);
            Controls.Add(lblLop);

            cboLop = new ComboBox();
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.SetBounds(150, 102, 380, 32);

            cboLop.Items.AddRange(new object[]
            {
                "Lớp A",
                "Lớp B"
            });

            cboLop.SelectedIndex = 0;
            Controls.Add(cboLop);

            Button btnCapNhat = new Button();
            btnCapNhat.Text = "&Cập nhật";
            btnCapNhat.SetBounds(150, 180, 170, 42);
            btnCapNhat.Click += (_, _) => CapNhatHocVien();
            Controls.Add(btnCapNhat);

            Button btnTroVe = new Button();
            btnTroVe.Text = "&Trở về";
            btnTroVe.SetBounds(360, 180, 170, 42);
            btnTroVe.Click += (_, _) => Close();
            Controls.Add(btnTroVe);

            // Enter để cập nhật; Esc để trở về.
            AcceptButton = btnCapNhat;
            CancelButton = btnTroVe;

            Shown += (_, _) => txtHoTen.Focus();
        }

        private void CapNhatHocVien()
        {
            // Loại bỏ khoảng trắng thừa trong họ tên.
            string hoTen = string.Join(
                " ",
                txtHoTen.Text.Split(
                    (char[]?)null,
                    StringSplitOptions.RemoveEmptyEntries
                )
            );

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show(
                    this,
                    "Hãy nhập họ tên học viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtHoTen.Focus();
                return;
            }

            if (cboLop.SelectedItem is not string lop)
            {
                MessageBox.Show(
                    this,
                    "Hãy chọn lớp cho học viên.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                cboLop.Focus();
                return;
            }

            // Gửi dữ liệu về Form chính.
            HocVienDuocThem?.Invoke(hoTen, lop);

            // Giữ Form nhập mở để nhập tiếp học viên khác.
            txtHoTen.Clear();
            txtHoTen.Focus();
        }
    }
}