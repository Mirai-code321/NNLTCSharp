using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace NangCao01_XuLyChuoi
{
    public class frmXuLyChuoi : Form
    {
        private readonly ListBox lstHoTen;

        // Các mảng dữ liệu theo đề bài.
        private readonly string[] HO =
        {
            "Lê", "Nguyễn", "Lý", "Trần", "Lâm",
            "Hồ", "Lai", "Huỳnh", "La"
        };

        private readonly string[] TENLOT =
        {
            "Quang", "Thành", "Ngọc", "Anh", "Xuân",
            "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng"
        };

        private readonly string[] TEN =
        {
            "Hà", "Danh", "Sơn", "Mai", "Thắng", "Kỳ",
            "Thành", "Lâm", "Tâm", "Phụng", "Thắm"
        };

        // Dùng quy tắc chữ hoa, chữ thường của tiếng Việt.
        private readonly CultureInfo vanHoa =
            CultureInfo.GetCultureInfo("vi-VN");

        public frmXuLyChuoi()
        {
            Text = "TH5c - Bài nâng cao 1 - Xử lý chuỗi";
            ClientSize = new Size(920, 580);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            // ListBox cho phép chọn nhiều phần tử.
            lstHoTen = new ListBox();
            lstHoTen.SelectionMode = SelectionMode.MultiExtended;
            lstHoTen.HorizontalScrollbar = true;
            lstHoTen.SetBounds(20, 80, 320, 440);
            Controls.Add(lstHoTen);

            ThemButton(
                "Nhập tên &ngẫu nhiên",
                20, 25, 320,
                ThemTenNgauNhien
            );

            ThemButton(
                "&Xóa phần tử đang chọn",
                370, 80, 520,
                XoaDangChon
            );

            ThemButton(
                "Xóa phần tử có tên là &Sơn",
                370, 135, 520,
                () => XoaTheoDieuKien(
                    hoTen => string.Equals(
                        TachTu(hoTen).LastOrDefault(),
                        "Sơn",
                        StringComparison.OrdinalIgnoreCase
                    )
                )
            );

            ThemButton(
                "Xóa phần tử có họ là &Lê",
                370, 190, 520,
                () => XoaTheoDieuKien(
                    hoTen => string.Equals(
                        TachTu(hoTen).FirstOrDefault(),
                        "Lê",
                        StringComparison.OrdinalIgnoreCase
                    )
                )
            );

            ThemButton(
                "Chuyển phần tử đang chọn thành chữ &HOA",
                370, 245, 520,
                () => DoiChuDangChon(
                    hoTen => hoTen.ToUpper(vanHoa)
                )
            );

            ThemButton(
                "Chuyển phần tử đang chọn thành chữ &thường",
                370, 300, 520,
                () => DoiChuDangChon(
                    hoTen => hoTen.ToLower(vanHoa)
                )
            );

            ThemButton(
                "Viết hoa &đầu mỗi từ của phần tử đang chọn",
                370, 355, 520,
                () => DoiChuDangChon(
                    hoTen => vanHoa.TextInfo.ToTitleCase(
                        hoTen.ToLower(vanHoa)
                    )
                )
            );

            ThemButton(
                "Xóa &tất cả các phần tử",
                370, 410, 520,
                () => lstHoTen.Items.Clear()
            );

            ThemButton(
                "T&hoát",
                740, 525, 150,
                Close
            );

            // Nhấn đúp để sửa đúng phần tử tại vị trí con trỏ.
            lstHoTen.MouseDoubleClick +=
                LstHoTen_MouseDoubleClick;

            FormClosing += FrmXuLyChuoi_FormClosing;
        }

        private void ThemButton(
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

        private void ThemTenNgauNhien()
        {
            lstHoTen.BeginUpdate();

            try
            {
                // Mỗi lần nhấn thêm 50 tên vào danh sách hiện tại.
                for (int i = 0; i < 50; i++)
                {
                    string ho = HO[Random.Shared.Next(HO.Length)];

                    string tenLot = TENLOT[
                        Random.Shared.Next(TENLOT.Length)
                    ];

                    string ten = TEN[
                        Random.Shared.Next(TEN.Length)
                    ];

                    string hoTen = $"{ho} {tenLot} {ten}";

                    lstHoTen.Items.Add(hoTen);
                }
            }
            finally
            {
                lstHoTen.EndUpdate();
            }

            // Đề không yêu cầu tên duy nhất nên có thể có tên trùng.
        }

        private static string[] TachTu(string hoTen)
        {
            // Tách theo khoảng trắng và bỏ những phần rỗng.
            return hoTen.Split(
                (char[]?)null,
                StringSplitOptions.RemoveEmptyEntries
            );
        }

        private int[] LayViTriDangChon()
        {
            // Chụp lại danh sách vị trí trước khi sửa hoặc xóa.
            return lstHoTen.SelectedIndices
                .Cast<int>()
                .ToArray();
        }

        private void XoaDangChon()
        {
            int[] viTri = LayViTriDangChon();

            if (viTri.Length == 0)
            {
                ThongBao("Hãy chọn ít nhất một tên cần xóa.");
                return;
            }

            // Xóa từ cuối về đầu để các vị trí chưa xóa
            // không bị dịch chuyển.
            foreach (int index in viTri.OrderByDescending(x => x))
            {
                lstHoTen.Items.RemoveAt(index);
            }
        }

        private void XoaTheoDieuKien(
            Func<string, bool> dieuKien)
        {
            // Duyệt ngược để không bỏ sót phần tử khi xóa.
            for (int i = lstHoTen.Items.Count - 1; i >= 0; i--)
            {
                string hoTen = lstHoTen.Items[i].ToString()!;

                if (dieuKien(hoTen))
                {
                    lstHoTen.Items.RemoveAt(i);
                }
            }
        }

private void DoiChuDangChon(
    Func<string, string> chuyenDoi)
{
    int[] viTri = LayViTriDangChon();

    if (viTri.Length == 0)
    {
        ThongBao("Hãy chọn ít nhất một tên cần chuyển đổi.");
        return;
    }

    // Tính trước tên mới cho tất cả phần tử đang chọn.
    string[] tenMoi = viTri
        .Select(index => chuyenDoi(
            lstHoTen.Items[index].ToString()!
        ))
        .ToArray();

    // Giữ vị trí cuộn hiện tại.
    int viTriCuon = lstHoTen.TopIndex;

    lstHoTen.BeginUpdate();

    try
    {
        lstHoTen.ClearSelected();

        for (int i = 0; i < viTri.Length; i++)
        {
            int index = viTri[i];

            // Xóa mục cũ rồi chèn lại ngay tại vị trí đó.
            // Buộc ListBox cập nhật nội dung hiển thị.
            lstHoTen.Items.RemoveAt(index);
            lstHoTen.Items.Insert(index, tenMoi[i]);
        }

        // Khôi phục các mục đang chọn.
        foreach (int index in viTri)
        {
            lstHoTen.SetSelected(index, true);
        }

        lstHoTen.TopIndex = viTriCuon;
    }
    finally
    {
        lstHoTen.EndUpdate();
    }

    lstHoTen.Refresh();
}

        private void LstHoTen_MouseDoubleClick(
            object? sender,
            MouseEventArgs e)
        {
            int index = lstHoTen.IndexFromPoint(e.Location);

            // Nhấn đúp vào vùng trống thì không xử lý.
            if (index == ListBox.NoMatches)
            {
                return;
            }

            string tenCu = lstHoTen.Items[index].ToString()!;

            using frmNhapTen hopNhap = new frmNhapTen(tenCu);

            if (hopNhap.ShowDialog(this) == DialogResult.OK)
            {
                // Đổi tên tại đúng vị trí đã nhấn đúp.
                lstHoTen.Items[index] = hopNhap.TenMoi;
            }
        }

        private void FrmXuLyChuoi_FormClosing(
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