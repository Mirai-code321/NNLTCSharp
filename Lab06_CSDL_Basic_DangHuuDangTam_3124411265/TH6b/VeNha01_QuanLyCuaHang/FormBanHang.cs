using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace VeNha01_QuanLyCuaHang
{
    public class frmBanHang : FormCoBan
    {
        private readonly TextBox txtMaHD;
        private readonly TextBox txtSoLuong;
        private readonly ComboBox cboSanPham;

        private readonly Button btnTao;
        private readonly Button btnThem;
        private readonly Button btnHuy;
        private readonly Button btnThanhToan;

        private readonly DataGridView gridChiTiet;
        private readonly DataGridView gridTon;

        private int? maHienTai;

        public frmBanHang()
            : base("Bán hàng", 1000, 750)
        {
            btnTao = Nut(
                "Tạo hóa đơn mới", 700, 20, 270, TaoHoaDon
            );

            Nhan("Mã hóa đơn", 25, 85);
            txtMaHD = OText(210, 82, 260);
            txtMaHD.ReadOnly = true;

            Nhan("Mã sản phẩm", 25, 140);

            cboSanPham = new ComboBox();
            cboSanPham.DropDownStyle =
                ComboBoxStyle.DropDownList;
            cboSanPham.SetBounds(210, 137, 400, 32);
            Controls.Add(cboSanPham);

            Nhan("Số lượng", 25, 195);
            txtSoLuong = OText(210, 192, 260);

            txtSoLuong.KeyPress += (_, e) =>
            {
                e.Handled =
                    !char.IsControl(e.KeyChar)
                    && (e.KeyChar < '0' || e.KeyChar > '9');
            };

            btnThem = Nut(
                "Thêm", 650, 135, 150, ThemChiTiet
            );

            btnHuy = Nut(
                "Hủy hóa đơn", 820, 135, 150, HuyHoaDon
            );

            btnThanhToan = Nut(
                "Thanh toán", 650, 190, 320, ThanhToan
            );

            Nhan("Chi tiết hóa đơn", 25, 255);
            gridChiTiet = Bang(25, 290, 945, 160);

            Nhan("Tồn kho hôm nay", 25, 475);
            gridTon = Bang(25, 510, 945, 200);

            DatTrangThai(false);

            Load += (_, _) => AnToan(() =>
            {
                NapDuLieu();

                // Nếu đóng Form khi hóa đơn còn mở, lần sau
                // khôi phục để thanh toán hoặc hủy.
                DataTable hd = CSDL.Doc(@"
                    SELECT TOP (1) MaHD
                    FROM dbo.HOADON
                    WHERE TinhTrangThanhToan = 0
                    ORDER BY MaHD;");

                if (hd.Rows.Count > 0)
                {
                    maHienTai =
                        Convert.ToInt32(hd.Rows[0]["MaHD"]);

                    txtMaHD.Text = maHienTai.Value.ToString();
                    DatTrangThai(true);
                    NapDuLieu();
                }
            });
        }

        private void DatTrangThai(bool dangCoHoaDon)
        {
            btnTao.Enabled = !dangCoHoaDon;

            txtMaHD.Enabled = dangCoHoaDon;
            cboSanPham.Enabled = dangCoHoaDon;
            txtSoLuong.Enabled = dangCoHoaDon;

            btnThem.Enabled = dangCoHoaDon;
            btnHuy.Enabled = dangCoHoaDon;
            btnThanhToan.Enabled = dangCoHoaDon;
        }

        private void NapDuLieu()
        {
            DataTable sanPham = CSDL.Doc(@"
                SELECT MaSP, TenSP
                FROM dbo.SANPHAM
                ORDER BY MaSP;");

            // Hiển thị mã sản phẩm đúng yêu cầu.
            cboSanPham.DisplayMember = "MaSP";
            cboSanPham.ValueMember = "MaSP";
            cboSanPham.DataSource = sanPham;

            gridTon.DataSource = CSDL.TonHomNay();

            if (maHienTai.HasValue)
            {
                gridChiTiet.DataSource = CSDL.Doc(@"
                    SELECT ct.MaSP, sp.TenSP, ct.SoLuong
                    FROM dbo.CHITIET_HOADON AS ct
                    INNER JOIN dbo.SANPHAM AS sp
                        ON ct.MaSP = sp.MaSP
                    WHERE ct.MaHD = @MaHD
                    ORDER BY ct.MaSP;",
                    maHienTai.Value
                );
            }
            else
            {
                gridChiTiet.DataSource = null;
            }
        }

        private void TaoHoaDon()
        {
            maHienTai = CSDL.ThucHien("TAO_HD");

            txtMaHD.Text = maHienTai.Value.ToString();
            txtSoLuong.Clear();

            DatTrangThai(true);
            NapDuLieu();
        }

        private void ThemChiTiet()
        {
            if (!maHienTai.HasValue
                || cboSanPham.SelectedValue == null)
            {
                BaoLoi("Hãy tạo hóa đơn và chọn sản phẩm.");
                return;
            }

            bool hopLe = int.TryParse(
                txtSoLuong.Text.Trim(),
                NumberStyles.None,
                CultureInfo.InvariantCulture,
                out int soLuong
            );

            if (!hopLe || soLuong <= 0)
            {
                BaoLoi("Số lượng phải là số nguyên dương.");
                txtSoLuong.Focus();
                return;
            }

            int maSP = Convert.ToInt32(
                cboSanPham.SelectedValue
            );

            CSDL.ThucHien(
                "THEM_CT",
                maHD: maHienTai.Value,
                maSP: maSP,
                soLuong: soLuong
            );

            txtSoLuong.Clear();
            NapDuLieu();

            BaoTin("Đã thêm sản phẩm vào hóa đơn.");
        }

        private void ThanhToan()
        {
            if (!maHienTai.HasValue)
            {
                return;
            }

            CSDL.ThucHien(
                "THANH_TOAN",
                maHD: maHienTai.Value
            );

            BaoTin("Đã ghi nhận hóa đơn thanh toán.");
            KetThucHoaDon();
        }

        private void HuyHoaDon()
        {
            if (!maHienTai.HasValue)
            {
                return;
            }

            DialogResult chon = MessageBox.Show(
                this,
                "Hủy toàn bộ hóa đơn và hoàn lại lượng tồn?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (chon != DialogResult.Yes)
            {
                return;
            }

            CSDL.ThucHien(
                "HUY_HD",
                maHD: maHienTai.Value
            );

            BaoTin("Đã hủy hóa đơn và hoàn lại lượng tồn.");
            KetThucHoaDon();
        }

        private void KetThucHoaDon()
        {
            maHienTai = null;
            txtMaHD.Clear();
            txtSoLuong.Clear();

            DatTrangThai(false);
            NapDuLieu();
        }
    }
}