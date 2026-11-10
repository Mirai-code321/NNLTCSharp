using DaoSo;

namespace Bai5_DaoSoTest;

public class SoDaoTests
{
    // Vi du chinh trong de bai: 1234 -> 4321
    [Fact]
    public void TinhSoDao_ViDuTrongDe_TraVe4321()
    {
        int ketQua = SoDao.TinhSoDao(1234);
        Assert.Equal(4321, ketQua);
    }

    // So doi xung, dao lai van bang chinh no
    [Fact]
    public void TinhSoDao_SoDoiXung_BangChinhNo()
    {
        int ketQua = SoDao.TinhSoDao(1221);
        Assert.Equal(1221, ketQua);
    }

    // Truong hop dac biet: so co chu so 0 o dau sau khi dao
    // 1000 dao lai la 0001, nhung kieu int se tu dong bo so 0 dau => chi con 1
    [Fact]
    public void TinhSoDao_ChuSoCuoiLaKhong_MatSo0Dau()
    {
        int ketQua = SoDao.TinhSoDao(1000);
        Assert.Equal(1, ketQua);
    }
}

