using System.Text;

namespace Bai11_DaoChuoi
{
    public class XuLyChuoi
    {
        // Tra ve chuoi dao nguoc cua chuoi dau vao, vi du "abc" -> "cba".
        // string trong C# la bat bien nen khong the doi cho ky tu ngay tren chuoi goc,
        // phai tao chuoi moi. Dung StringBuilder de khong sinh ra nhieu chuoi trung gian
        // (neu dung ketQua += ky tu thi moi lan cong la tao them 1 chuoi moi).
        public string DaoChuoi(string? chuoi)
        {
            // null hoac rong thi khong co gi de dao, tra ve chuoi rong (khong tra null
            // de noi khac khong phai kiem tra null ket qua)
            if (string.IsNullOrEmpty(chuoi))
                return string.Empty;

            // biet truoc do dai nen cap phat san dung dung so cho can dung
            StringBuilder ketQua = new StringBuilder(chuoi.Length);

            // duyet tu ky tu cuoi ve ky tu dau
            for (int i = chuoi.Length - 1; i >= 0; i--)
            {
                ketQua.Append(chuoi[i]);
            }

            return ketQua.ToString();
        }
    }
}