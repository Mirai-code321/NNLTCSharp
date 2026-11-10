using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace VeNha01_TuDien
{
    // Mỗi mục từ gồm từ cần tra và nghĩa tương ứng.
    public class MucTu
    {
        public string Tu { get; }
        public string Nghia { get; }

        public MucTu(string tu, string nghia)
        {
            Tu = tu;
            Nghia = nghia;
        }
    }

    public class frmTuDien : Form
    {
        // Danh sách Anh - Việt được lưu sẵn trong List.
        private readonly List<MucTu> anhViet = new List<MucTu>
        {
            new MucTu("student", "Sinh viên; học sinh"),
            new MucTu("teacher", "Giáo viên"),
            new MucTu("worker", "Công nhân"),
            new MucTu("hat", "Mũ"),
            new MucTu("head", "Đầu"),
            new MucTu("mouse", "Chuột"),
            new MucTu("cat", "Mèo"),
            new MucTu("dog", "Chó"),
            new MucTu("snake", "Rắn"),
            new MucTu("lion", "Sư tử"),
            new MucTu("frog", "Ếch"),
            new MucTu("sheep", "Cừu"),
            new MucTu("book", "Sách"),
            new MucTu("school", "Trường học"),
            new MucTu("computer", "Máy tính")
        };

        // Tách riêng danh sách Việt - Anh vì một từ tiếng Anh
        // có thể có nhiều nghĩa tiếng Việt.
        private readonly List<MucTu> vietAnh = new List<MucTu>
        {
            new MucTu("sinh viên", "Student"),
            new MucTu("học sinh", "Student; pupil"),
            new MucTu("giáo viên", "Teacher"),
            new MucTu("công nhân", "Worker"),
            new MucTu("mũ", "Hat"),
            new MucTu("đầu", "Head"),
            new MucTu("chuột", "Mouse"),
            new MucTu("mèo", "Cat"),
            new MucTu("chó", "Dog"),
            new MucTu("rắn", "Snake"),
            new MucTu("sư tử", "Lion"),
            new MucTu("ếch", "Frog"),
            new MucTu("cừu", "Sheep"),
            new MucTu("sách", "Book"),
            new MucTu("trường học", "School"),
            new MucTu("máy tính", "Computer")
        };

        public frmTuDien()
        {
            Text = "TH5c - Từ điển Anh Việt - Việt Anh";
            ClientSize = new Size(850, 590);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            TabControl tabTuDien = new TabControl();
            tabTuDien.SetBounds(20, 20, 810, 490);
            Controls.Add(tabTuDien);

            // Hai tab sử dụng chung cách tạo giao diện và xử lý.
            TaoTab(
                tabTuDien,
                "ANH - VIỆT",
                "Tiếng Anh",
                "Tiếng Việt",
                anhViet,
                CultureInfo.GetCultureInfo("en-US")
            );

            TaoTab(
                tabTuDien,
                "VIỆT - ANH",
                "Tiếng Việt",
                "Tiếng Anh",
                vietAnh,
                CultureInfo.GetCultureInfo("vi-VN")
            );

            Button btnThoat = new Button();
            btnThoat.Text = "T&hoát";
            btnThoat.SetBounds(680, 530, 150, 40);
            btnThoat.Click += (_, _) => Close();
            Controls.Add(btnThoat);

            FormClosing += FrmTuDien_FormClosing;
        }

        private void TaoTab(
            TabControl tabControl,
            string tenTab,
            string ngonNguNguon,
            string ngonNguDich,
            List<MucTu> duLieu,
            CultureInfo vanHoa)
        {
            // Sắp xếp từ theo ngôn ngữ của tab.
            StringComparer soSanh =
                StringComparer.Create(vanHoa, true);

            List<MucTu> danhSach = duLieu
                .OrderBy(muc => muc.Tu, soSanh)
                .ToList();

            TabPage tab = new TabPage(tenTab);
            tabControl.TabPages.Add(tab);

            Label lblNguon = new Label();
            lblNguon.Text = ngonNguNguon;
            lblNguon.SetBounds(20, 20, 300, 28);
            tab.Controls.Add(lblNguon);

            Label lblDich = new Label();
            lblDich.Text = ngonNguDich;
            lblDich.SetBounds(365, 20, 390, 28);
            tab.Controls.Add(lblDich);

            ComboBox cboTu = new ComboBox();

            // Cho phép vừa nhập vừa chọn từ.
            cboTu.DropDownStyle = ComboBoxStyle.DropDown;

            // Tự gợi ý và điền tiếp phần còn lại của từ.
            cboTu.AutoCompleteMode =
                AutoCompleteMode.SuggestAppend;

            cboTu.AutoCompleteSource =
                AutoCompleteSource.ListItems;

            cboTu.SetBounds(20, 55, 310, 32);
            tab.Controls.Add(cboTu);

            ListBox lstTu = new ListBox();
            lstTu.SetBounds(20, 105, 310, 285);
            tab.Controls.Add(lstTu);

            TextBox txtNghia = new TextBox();
            txtNghia.Multiline = true;
            txtNghia.ReadOnly = true;
            txtNghia.ScrollBars = ScrollBars.Vertical;
            txtNghia.SetBounds(365, 55, 390, 335);
            tab.Controls.Add(txtNghia);

            Button btnEnter = new Button();
            btnEnter.Text = "&Enter";
            btnEnter.SetBounds(20, 405, 310, 38);
            tab.Controls.Add(btnEnter);

            foreach (MucTu muc in danhSach)
            {
                cboTu.Items.Add(muc.Tu);
                lstTu.Items.Add(muc.Tu);
            }

            // Ngăn các sự kiện đồng bộ gọi lẫn nhau.
            // Khi gợi ý trên ListBox, không thay phần đang gõ.
            bool dangDongBo = false;

            // Hàm tra cứu dùng chung cho các thao tác Enter
            // và nhấn đúp.
            void TraTu()
            {
                string tuCanTra = cboTu.Text.Trim();

                if (string.IsNullOrWhiteSpace(tuCanTra))
                {
                    txtNghia.Clear();

                    MessageBox.Show(
                        this,
                        "Hãy nhập hoặc chọn một từ cần tra.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    cboTu.Focus();
                    return;
                }

                // Tra chính xác, không phân biệt hoa thường.
                MucTu? ketQua = danhSach.FirstOrDefault(
                    muc => soSanh.Equals(muc.Tu, tuCanTra)
                );

                txtNghia.Text = ketQua != null
                    ? ketQua.Nghia
                    : "Không tìm thấy từ trong danh sách.";
            }

            // Khi người dùng nhập, tìm từ đầu tiên
            // bắt đầu bằng nội dung đang gõ.
            cboTu.TextUpdate += (_, _) =>
            {
                if (dangDongBo)
                {
                    return;
                }

                string phanNhap = cboTu.Text.Trim();

                int viTri = -1;

                if (phanNhap.Length > 0)
                {
                    viTri = danhSach.FindIndex(
                        muc => vanHoa.CompareInfo.IsPrefix(
                            muc.Tu,
                            phanNhap,
                            CompareOptions.IgnoreCase
                        )
                    );
                }

                dangDongBo = true;

                try
                {
                    lstTu.SelectedIndex = viTri;

                    if (viTri >= 0)
                    {
                        // Cuộn tới từ khớp để người dùng nhìn thấy.
                        lstTu.TopIndex = viTri;
                    }
                }
                finally
                {
                    dangDongBo = false;
                }

                // Xóa nghĩa cũ khi đang nhập từ mới.
                txtNghia.Clear();
            };

            // Chọn từ trong ComboBox thì chọn cùng từ ở ListBox.
            cboTu.SelectedIndexChanged += (_, _) =>
            {
                if (dangDongBo)
                {
                    return;
                }

                dangDongBo = true;

                try
                {
                    lstTu.SelectedIndex = cboTu.SelectedIndex;
                }
                finally
                {
                    dangDongBo = false;
                }

                txtNghia.Clear();
            };

            // Chọn từ trong ListBox thì đưa từ lên ComboBox.
            lstTu.SelectedIndexChanged += (_, _) =>
            {
                if (dangDongBo || lstTu.SelectedIndex < 0)
                {
                    return;
                }

                dangDongBo = true;

                try
                {
                    cboTu.SelectedIndex = lstTu.SelectedIndex;
                }
                finally
                {
                    dangDongBo = false;
                }

                txtNghia.Clear();
            };

            // Nhấn nút Enter để tra nghĩa.
            btnEnter.Click += (_, _) => TraTu();

            // Nhấn phím Enter trong ComboBox.
            cboTu.KeyDown += (_, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // Không phát tiếng báo khi nhấn Enter.
                    e.SuppressKeyPress = true;
                    TraTu();
                }
            };

            // Nhấn đúp vào một từ trên ListBox.
            lstTu.MouseDoubleClick += (_, e) =>
            {
                int viTri = lstTu.IndexFromPoint(e.Location);

                if (viTri == ListBox.NoMatches)
                {
                    return;
                }

                // Đảm bảo tra đúng từ tại vị trí nhấn đúp.
                dangDongBo = true;

                try
                {
                    lstTu.SelectedIndex = viTri;
                    cboTu.SelectedIndex = viTri;
                }
                finally
                {
                    dangDongBo = false;
                }

                TraTu();
            };

            // Cho phép tra bằng phím Enter tại ListBox.
            lstTu.KeyDown += (_, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    TraTu();
                }
            };
        }

        private void FrmTuDien_FormClosing(
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