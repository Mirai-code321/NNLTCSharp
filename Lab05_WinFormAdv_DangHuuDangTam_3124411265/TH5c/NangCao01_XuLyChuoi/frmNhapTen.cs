using System;
using System.Drawing;
using System.Windows.Forms;

namespace NangCao01_XuLyChuoi
{
    public class frmNhapTen : Form
    {
        private readonly TextBox txtTen;

        public string TenMoi { get; private set; } = "";

        public frmNhapTen(string tenCu)
        {
            Text = "Thay đổi họ tên";
            ClientSize = new Size(510, 180);
            StartPosition = FormStartPosition.CenterParent;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;

            Label label = new Label();
            label.Text = "Nhập họ tên mới:";
            label.SetBounds(20, 20, 450, 28);
            Controls.Add(label);

            txtTen = new TextBox();
            txtTen.Text = tenCu;
            txtTen.SetBounds(20, 55, 470, 30);
            Controls.Add(txtTen);

            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.SetBounds(270, 115, 100, 38);
            btnOK.Click += BtnOK_Click;
            Controls.Add(btnOK);

            Button btnHuy = new Button();
            btnHuy.Text = "Hủy";
            btnHuy.SetBounds(390, 115, 100, 38);
            btnHuy.DialogResult = DialogResult.Cancel;
            Controls.Add(btnHuy);

            // Enter để lưu, Esc để hủy.
            AcceptButton = btnOK;
            CancelButton = btnHuy;

            Shown += (_, _) =>
            {
                txtTen.Focus();
                txtTen.SelectAll();
            };
        }

        private void BtnOK_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                MessageBox.Show(
                    this,
                    "Họ tên không được để trống.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                txtTen.Focus();
                return;
            }

            // Loại khoảng trắng thừa và ghép lại bằng một dấu cách.
            TenMoi = string.Join(
                " ",
                txtTen.Text.Split(
                    (char[]?)null,
                    StringSplitOptions.RemoveEmptyEntries
                )
            );

            // Trả kết quả về form chính.
            DialogResult = DialogResult.OK;
        }
    }
}