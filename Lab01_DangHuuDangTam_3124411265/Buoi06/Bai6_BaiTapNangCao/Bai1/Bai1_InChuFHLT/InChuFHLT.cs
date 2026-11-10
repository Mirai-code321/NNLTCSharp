namespace InChuFHLT
{
    public class ChuFHLT
    {
        // Tạo hình chữ F với chiều cao h
        public string InChuF(int h)
        {
            string ketQua = "";

            // Dòng đầu tiên: in toàn bộ thanh ngang
            for (int i = 0; i < h; i++)
            {
                ketQua += "* ";
            }

            ketQua += "\n";

            // Các dòng ở giữa
            for (int dong = 2; dong <= h; dong++)
            {
                // Dòng giữa của chữ F cũng có thanh ngang
                if (dong == (h + 1) / 2)
                {
                    for (int i = 0; i < h; i++)
                    {
                        ketQua += "* ";
                    }
                }
                else
                {
                    // Chỉ in thanh dọc bên trái
                    ketQua += "* ";
                }

                ketQua += "\n";
            }

            return ketQua;
        }

        // Tạo hình chữ H với chiều cao h
        public string InChuH(int h)
        {
            string ketQua = "";

            for (int dong = 1; dong <= h; dong++)
            {
                // Cột trái
                ketQua += "* ";

                // Nếu là dòng giữa thì in thanh ngang
                if (dong == (h + 1) / 2)
                {
                    for (int i = 1; i < h - 1; i++)
                    {
                        ketQua += "* ";
                    }
                }
                else
                {
                    // Khoảng trống ở giữa
                    for (int i = 1; i < h - 1; i++)
                    {
                        ketQua += "  ";
                    }
                }

                // Cột phải
                ketQua += "* ";

                ketQua += "\n";
            }

            return ketQua;
        }

        // Tạo hình chữ L với chiều cao h
        public string InChuL(int h)
        {
            string ketQua = "";

            for (int dong = 1; dong <= h; dong++)
            {
                // Dòng cuối cùng là thanh ngang
                if (dong == h)
                {
                    for (int i = 0; i < h; i++)
                    {
                        ketQua += "* ";
                    }
                }
                else
                {
                    // Các dòng còn lại chỉ có thanh dọc
                    ketQua += "* ";
                }

                ketQua += "\n";
            }

            return ketQua;
        }

        // Tạo hình chữ T với chiều cao h
        public string InChuT(int h)
        {
            string ketQua = "";

            // Dòng đầu tiên là thanh ngang
            for (int i = 0; i < h; i++)
            {
                ketQua += "* ";
            }

            ketQua += "\n";

            // Các dòng còn lại chỉ có thanh dọc ở giữa
            for (int dong = 2; dong <= h; dong++)
            {
                // Khoảng trắng trước cột giữa
                for (int i = 0; i < h / 2; i++)
                {
                    ketQua += "  ";
                }

                ketQua += "* ";
                ketQua += "\n";
            }

            return ketQua;
        }
    }
}