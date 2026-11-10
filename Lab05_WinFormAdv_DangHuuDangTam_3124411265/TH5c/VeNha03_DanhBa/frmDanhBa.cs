using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace VeNha03_DanhBa
{
    public class frmDanhBa : Form
    {
        private readonly TreeView trvDanhBa;
        private readonly TextBox txtFirstName;
        private readonly TextBox txtLastName;

        public frmDanhBa()
        {
            Text = "TH5c - Bài về nhà 3 - Nhập danh bạ";
            ClientSize = new Size(820, 560);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // TreeView hiển thị các nhóm chữ cái A-Z.
            trvDanhBa = new TreeView();
            trvDanhBa.HideSelection = false;
            trvDanhBa.SetBounds(20, 20, 340, 520);
            Controls.Add(trvDanhBa);

            // Nhóm nhập thông tin.
            GroupBox grpThongTin = new GroupBox();
            grpThongTin.Text = "Thông tin danh bạ";
            grpThongTin.SetBounds(385, 40, 415, 300);
            Controls.Add(grpThongTin);

            Label lblFirstName = new Label();
            lblFirstName.Text = "First Name (tên)";
            lblFirstName.SetBounds(20, 40, 370, 28);
            grpThongTin.Controls.Add(lblFirstName);

            txtFirstName = new TextBox();
            txtFirstName.SetBounds(20, 75, 370, 30);
            grpThongTin.Controls.Add(txtFirstName);

            Label lblLastName = new Label();
            lblLastName.Text = "Last Name (họ và tên đệm)";
            lblLastName.SetBounds(20, 135, 370, 28);
            grpThongTin.Controls.Add(lblLastName);

            txtLastName = new TextBox();
            txtLastName.SetBounds(20, 170, 370, 30);
            grpThongTin.Controls.Add(txtLastName);

            Button btnAdd = new Button();
            btnAdd.Text = "&Add";
            btnAdd.SetBounds(250, 230, 140, 40);
            btnAdd.Click += (_, _) => ThemDanhBa();
            grpThongTin.Controls.Add(btnAdd);

            Button btnExit = new Button();
            btnExit.Text = "E&xit";
            btnExit.SetBounds(660, 480, 140, 40);
            btnExit.Click += (_, _) => Close();
            Controls.Add(btnExit);

            // Nhấn Enter để thêm người vào danh bạ.
            AcceptButton = btnAdd;

            Load += FrmDanhBa_Load;
            FormClosing += FrmDanhBa_FormClosing;

            Shown += (_, _) => txtFirstName.Focus();
        }

        private void FrmDanhBa_Load(
            object? sender,
            EventArgs e)
        {
            trvDanhBa.Nodes.Clear();

            // Tạo đủ 26 node từ A đến Z.
            for (char chu = 'A'; chu <= 'Z'; chu++)
            {
                string kyTu = chu.ToString();

                // Tham số thứ nhất là khóa, thứ hai là nội dung.
                trvDanhBa.Nodes.Add(kyTu, kyTu);
            }
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

        private static string ChuanHoaKhoangTrang(
            string noiDung)
        {
            // Bỏ khoảng trắng đầu, cuối và khoảng trắng thừa.
            // Chuẩn hóa Unicode để tên có dấu được lưu nhất quán.
            return string.Join(
                " ",
                noiDung.Split(
                    (char[]?)null,
                    StringSplitOptions.RemoveEmptyEntries
                )
            ).Normalize(NormalizationForm.FormC);
        }

        private static char LayChuCaiDau(string ten)
        {
            // Tách ký tự tiếng Việt thành chữ gốc và dấu.
            // Ví dụ: Á -> A + dấu sắc.
            string chuoiTachDau =
                ten.Normalize(NormalizationForm.FormD);

            foreach (char kyTu in chuoiTachDau)
            {
                // Bỏ các dấu tổ hợp.
                if (CharUnicodeInfo.GetUnicodeCategory(kyTu)
                    == UnicodeCategory.NonSpacingMark)
                {
                    continue;
                }

                char chuDau = char.ToUpperInvariant(kyTu);

                // Đ không được tách thành D bằng FormD,
                // nên cần xử lý riêng.
                if (chuDau == 'Đ')
                {
                    chuDau = 'D';
                }

                return chuDau;
            }

            return '\0';
        }

        private void ThemDanhBa()
        {
            string firstName =
                ChuanHoaKhoangTrang(txtFirstName.Text);

            string lastName =
                ChuanHoaKhoangTrang(txtLastName.Text);

            if (string.IsNullOrWhiteSpace(firstName))
            {
                ThongBao("Hãy nhập First Name (tên).");
                txtFirstName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                ThongBao("Hãy nhập Last Name (họ và tên đệm).");
                txtLastName.Focus();
                return;
            }

            char chuDau = LayChuCaiDau(firstName);

            // Danh bạ chỉ có nhóm A-Z.
            if (chuDau < 'A' || chuDau > 'Z')
            {
                ThongBao(
                    "Tên phải bắt đầu bằng chữ cái A-Z "
                    + "hoặc chữ tiếng Việt tương ứng."
                );

                txtFirstName.Focus();
                txtFirstName.SelectAll();
                return;
            }

            // Tìm node theo khóa đã tạo trong sự kiện Load.
            TreeNode? nodeChuCai =
                trvDanhBa.Nodes[chuDau.ToString()];

            if (nodeChuCai == null)
            {
                ThongBao("Không tìm thấy nhóm chữ cái.");
                return;
            }

            // Hiển thị theo hình trong đề: Bình, Ngô Thanh.
            string noiDung = $"{firstName}, {lastName}";

            TreeNode nodeNguoi =
                nodeChuCai.Nodes.Add(noiDung);

            // Mở nhóm và cuộn đến người vừa được thêm.
            nodeChuCai.Expand();
            trvDanhBa.SelectedNode = nodeNguoi;
            nodeNguoi.EnsureVisible();

            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }

        private void FrmDanhBa_FormClosing(
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