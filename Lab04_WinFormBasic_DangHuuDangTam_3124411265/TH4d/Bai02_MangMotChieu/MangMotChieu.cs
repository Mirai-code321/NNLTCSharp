using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai02_MangMotChieu
{
    public class MangMotChieu
    {
        private readonly List<int> duLieu;

        public int SoLuong => duLieu.Count;

        public MangMotChieu()
        {
            duLieu = new List<int>();
        }

        public MangMotChieu(IEnumerable<int> cacSo)
        {
            duLieu = new List<int>(cacSo);
        }

        public void SapXepTang()
        {
            duLieu.Sort();
        }

        public void SapXepGiam()
        {
            duLieu.Sort();
            duLieu.Reverse();
        }

        // Tìm tất cả vị trí xuất hiện của giá trị.
        public int[] TimViTri(int giaTri)
        {
            List<int> ketQua = new List<int>();

            for (int i = 0; i < SoLuong; i++)
            {
                if (duLieu[i] == giaTri)
                    ketQua.Add(i);
            }

            return ketQua.ToArray();
        }

        public int LayGiaTri(int viTri)
        {
            KiemTraViTri(viTri);
            return duLieu[viTri];
        }

        public void Chen(int viTri, int giaTri)
        {
            // Vị trí bằng SoLuong nghĩa là chèn cuối.
            if (viTri < 0 || viTri > SoLuong)
            {
                throw new ArgumentException(
                    $"Vị trí chèn phải từ 0 đến {SoLuong}.");
            }

            duLieu.Insert(viTri, giaTri);
        }

        public void ThayTheTaiViTri(int viTri, int giaTriMoi)
        {
            KiemTraViTri(viTri);
            duLieu[viTri] = giaTriMoi;
        }

        public int ThayTheTheoGiaTri(int giaTriCu, int giaTriMoi)
        {
            int soLan = 0;

            for (int i = 0; i < SoLuong; i++)
            {
                if (duLieu[i] == giaTriCu)
                {
                    duLieu[i] = giaTriMoi;
                    soLan++;
                }
            }

            return soLan;
        }

        // 0: tổng toàn bộ, 1: tổng chẵn, 2: tổng lẻ.
        public long TinhTong(int loai)
        {
            long tong = 0;

            foreach (int so in duLieu)
            {
                bool canCong =
                    loai == 0 ||
                    (loai == 1 && so % 2 == 0) ||
                    (loai == 2 && so % 2 != 0);

                if (canCong)
                    tong += so;
            }

            return tong;
        }

        public int LonNhat()
        {
            KiemTraKhongRong();
            return duLieu.Max();
        }

        public int NhoNhat()
        {
            KiemTraKhongRong();
            return duLieu.Min();
        }

        private void KiemTraViTri(int viTri)
        {
            KiemTraKhongRong();

            if (viTri < 0 || viTri >= SoLuong)
            {
                throw new ArgumentException(
                    $"Vị trí phải từ 0 đến {SoLuong - 1}.");
            }
        }

        private void KiemTraKhongRong()
        {
            if (SoLuong == 0)
            {
                throw new InvalidOperationException(
                    "Mảng chưa có dữ liệu.");
            }
        }

        public override string ToString()
        {
            return string.Join(" ", duLieu);
        }
    }
}