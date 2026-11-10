namespace InNhan;

public class Nhan
{
    // Tra ve noi dung nhan duoi dang chuoi (khong in truc tiep)
    // de co the unit test duoc gia tri tra ve
    public static string LayNoiDungNhan()
    {
        string dong1 = "**************************";
        string dong2 = "* Truong: Dai Hoc HUFLIT *";
        string dong3 = "* Khoa: CNTT             *";
        string dong4 = "* Ho ten:                *";
        string dong5 = "**************************";

        return string.Join(Environment.NewLine, dong1, dong2, dong3, dong4, dong5);
    }
}
