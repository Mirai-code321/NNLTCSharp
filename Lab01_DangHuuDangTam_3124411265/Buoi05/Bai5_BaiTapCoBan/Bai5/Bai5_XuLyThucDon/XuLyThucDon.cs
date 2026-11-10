using System;

namespace ThucDon
{
    public class XuLyThucDon
    {
        /// <summary>
        /// Kiểm tra xem chuỗi đầu vào có phải là số hợp lệ từ 1 đến 4 hay không.
        /// </summary>
        /// <param name="input">Chuỗi văn bản người dùng nhập từ bàn phím</param>
        /// <param name="luaChon">Giá trị số nguyên đầu ra nếu ép kiểu thành công</param>
        /// <returns>True nếu hợp lệ (là số từ 1-4), ngược lại trả về False</returns>
        public static bool KiemTraHopLe(string? input, out int luaChon)
        {
            // TryParse giúp chuyển chuỗi thành số nguyên an toàn, tránh bị sập chương trình nếu nhập chữ
            bool isNumber = int.TryParse(input, out luaChon);

            // Điều kiện hợp lệ: Phải ép kiểu thành công thành số VÀ nằm trong khoảng [1, 4]
            if (isNumber && luaChon >= 1 && luaChon <= 4)
            {
                return true;
            }

            // Nếu không hợp lệ, gán biến out về 0 để đảm bảo an toàn dữ liệu
            luaChon = 0;
            return false;
        }

        /// <summary>
        /// Trả về câu thông báo tương ứng với mã chức năng người dùng chọn.
        /// </summary>
        /// <param name="luaChon">Mã chức năng (1: Tam giác, 2: Hình chữ nhật, 3: Hình tròn, 4: Thoát)</param>
        /// <returns>Chuỗi thông báo tương ứng</returns>
        /// <exception cref="ArgumentOutOfRangeException">Bắn ngoại lệ nếu mã nằm ngoài khoảng 1-4</exception>
        public static string LayThongBao(int luaChon)
        {
            // Dùng switch-case để phân nhánh thông báo theo đúng yêu cầu đề bài
            switch (luaChon)
            {
                case 1:
                    return "Ban moi vua chon chuc nang tinh dien tich tam giac.";
                case 2:
                    return "Ban moi vua chon chuc nang tinh dien tich hinh chu nhat.";
                case 3:
                    return "Ban moi vua chon chuc nang tinh dien tich hinh tron.";
                case 4:
                    return "Ban moi vua chon chuc nang thoat chuong trinh.";
                default:
                    // Nếu truyền vào số ngoài [1, 4], ném ngoại lệ để phục vụ Unit Test kiểm thử luồng lỗi
                    throw new ArgumentOutOfRangeException(nameof(luaChon), "Lua chon khong hop le.");
            }
        }

        /// <summary>
        /// Kiểm tra xem người dùng có chọn chức năng Thoát (số 4) hay không.
        /// </summary>
        public static bool LaLuaChonThoat(int luaChon)
        {
            return luaChon == 4;
        }
    }
}

