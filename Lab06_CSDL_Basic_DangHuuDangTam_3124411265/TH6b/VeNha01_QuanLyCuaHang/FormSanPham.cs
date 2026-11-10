using System.Windows.Forms;

namespace VeNha01_QuanLyCuaHang
{
    public class frmSanPham : FormCoBan
    {
        private readonly TextBox txtTen;

        public frmSanPham()
            : base("Thêm sản phẩm mới", 550, 210)
        {
            Nhan("Tên sản phẩm", 20, 40);

            txtTen = OText(200, 37, 320);
            txtTen.MaxLength = 100;

            Button btnThem = Nut(
                "Thêm", 200, 120, 140, ThemSanPham
            );

            Nut("Thoát", 380, 120, 140, Close);

            AcceptButton = btnThem;
        }

        private void ThemSanPham()
        {
            string ten = txtTen.Text.Trim();

            if (ten.Length == 0)
            {
                BaoLoi("Tên sản phẩm không được để trống.");
                txtTen.Focus();
                return;
            }

            int ma = CSDL.ThucHien(
                "THEM_SP",
                tenSP: ten
            );

            BaoTin(
                $"Đã thêm sản phẩm mã {ma}.\n"
                + "Tồn đầu, nhập và bán của hôm nay đều bằng 0."
            );

            txtTen.Clear();
            txtTen.Focus();
        }
    }
}