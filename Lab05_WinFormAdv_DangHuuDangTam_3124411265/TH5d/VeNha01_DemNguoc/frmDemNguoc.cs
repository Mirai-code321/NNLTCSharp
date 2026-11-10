using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace VeNha01_DemNguoc
{
    public class frmDemNguoc : Form
    {
        // Thời gian ban đầu: 30 phút = 1800 giây.
        private const int THOI_GIAN_BAN_DAU = 30 * 60;

        private readonly Label lblThoiGian;
        private readonly Button btnBatDau;

        // Ghi rõ Timer của Windows Forms để tránh nhầm
        // với các lớp Timer khác.
        private readonly System.Windows.Forms.Timer timer;

        // Đo thời gian thực đã trôi qua.
        private readonly Stopwatch dongHo = new Stopwatch();

        public frmDemNguoc()
        {
            Text = "Đồng hồ";
            ClientSize = new Size(360, 200);
            StartPosition = FormStartPosition.CenterScreen;
            Font = new Font("Segoe UI", 11);

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            lblThoiGian = new Label();
            lblThoiGian.Font = new Font(
                "Consolas", 32, FontStyle.Bold
            );
            lblThoiGian.TextAlign =
                ContentAlignment.MiddleCenter;

            lblThoiGian.SetBounds(20, 25, 320, 75);
            Controls.Add(lblThoiGian);

            btnBatDau = new Button();
            btnBatDau.Text = "&Bắt đầu";
            btnBatDau.SetBounds(95, 120, 170, 45);
            btnBatDau.Click += BtnBatDau_Click;
            Controls.Add(btnBatDau);

            AcceptButton = btnBatDau;

            timer = new System.Windows.Forms.Timer();

            // Kiểm tra và cập nhật hiển thị mỗi 200 mili giây.
            // Số giây còn lại dựa trên Stopwatch,
            // không dựa vào số lần Tick.
            timer.Interval = 200;
            timer.Tick += Timer_Tick;

            HienThiThoiGian(THOI_GIAN_BAN_DAU);
        }

        private void HienThiThoiGian(int tongGiay)
        {
            int phut = tongGiay / 60;
            int giay = tongGiay % 60;

            // D2: luôn hiển thị ít nhất hai chữ số.
            lblThoiGian.Text = $"{phut:D2}:{giay:D2}";
        }

        private void BtnBatDau_Click(
            object? sender,
            EventArgs e)
        {
            // Đưa đồng hồ về thời gian ban đầu.
            HienThiThoiGian(THOI_GIAN_BAN_DAU);

            // Không cho bắt đầu thêm lượt khi đang chạy.
            btnBatDau.Enabled = false;
            btnBatDau.Text = "Đang đếm...";

            dongHo.Restart();
            timer.Start();
        }

        private void Timer_Tick(
            object? sender,
            EventArgs e)
        {
            // Tính số giây thực tế đã trôi qua.
            int giayDaQua =
                (int)dongHo.Elapsed.TotalSeconds;

            int giayConLai = Math.Max(
                0,
                THOI_GIAN_BAN_DAU - giayDaQua
            );

            HienThiThoiGian(giayConLai);

            if (giayConLai > 0)
            {
                return;
            }

            // Dừng trước khi hiện MessageBox để thông báo
            // chỉ xuất hiện một lần.
            timer.Stop();
            dongHo.Stop();

            btnBatDau.Text = "&Bắt đầu lại";
            btnBatDau.Enabled = true;

            MessageBox.Show(
                this,
                "Đã hết thời gian!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Timer được tạo bằng code nên cần giải phóng.
                timer?.Stop();
                timer?.Dispose();
                dongHo.Stop();
            }

            base.Dispose(disposing);
        }
    }
}