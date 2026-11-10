namespace DaoSo;

public class SoDao
{
    // Tach tung chu so cua x (4 chu so) roi ghep nguoc lai thanh y
    public static int TinhSoDao(int x)
    {
        int dv = (x / 1) % 10;
        int chuc = (x / 10) % 10;
        int tram = (x / 100) % 10;
        int ngan = (x / 1000) % 10;

        return dv * 1000 + chuc * 100 + tram * 10 + ngan;
    }
}

