using System;
using System.Windows.Forms;

namespace VeNha01_QuanLyCuaHang
{
    public class frmMain : FormCoBan
    {
        private readonly DataGridView gridTon;

        public frmMain()
            : base("TH6b - Quản lý cửa hàng", 1000, 560)
        {
            MenuStrip menu = new MenuStrip();

            ToolStripMenuItem mucTon =
                new ToolStripMenuItem("Tạo tồn kho");

            ToolStripMenuItem mucSanPham =
                new ToolStripMenuItem("Thêm sản phẩm mới");

            ToolStripMenuItem mucBanHang =
                new ToolStripMenuItem("Bán hàng");

            ToolStripMenuItem mucThoat =
                new ToolStripMenuItem("Thoát");

            menu.Items.AddRange(new ToolStripItem[]
            {
                mucTon, mucSanPham, mucBanHang, mucThoat
            });

            MainMenuStrip = menu;
            Controls.Add(menu);

            Nhan("Tồn kho hôm nay", 20, 55);
            gridTon = Bang(20, 100, 960, 360);

            Nut("Nạp lại", 20, 490, 150, NapTon);

            mucTon.Click += (_, _) => AnToan(() =>
            {
                CSDL.ThucHien("TAO_TON");
                NapTon();
                BaoTin("Đã tạo tồn kho hôm nay.");
            });

            mucSanPham.Click += (_, _) => AnToan(() =>
            {
                using frmSanPham form = new frmSanPham();
                form.ShowDialog(this);
                NapTon();
            });

            mucBanHang.Click += (_, _) => AnToan(() =>
            {
                using frmBanHang form = new frmBanHang();
                form.ShowDialog(this);
                NapTon();
            });

            mucThoat.Click += (_, _) => Close();

            Load += (_, _) => AnToan(NapTon);
        }

        private void NapTon()
        {
            gridTon.DataSource = CSDL.TonHomNay();
        }
    }
}