using Bai02PersonList;
using Bai03Person;

namespace Bai02_PersonListTest;

public class PersonListTests
{
    [Fact]
    public void ConstructorMacDinh_TaoDanhSachRong()
    {
        // Arrange va Act.
        PersonList danhSach = new PersonList();

        // Assert.
        Assert.Equal(0, danhSach.Count);
    }

    [Fact]
    public void Add_ThemMotNguoi_TangSoLuongVaLuuDungDuLieu()
    {
        // Arrange.
        PersonList danhSach = new PersonList();

        Person person = new Person(
            "P001",
            "Dang Huu Dang Tam",
            2006,
            0
        );

        // Act.
        danhSach.Add(person);

        // Assert.
        Assert.Equal(1, danhSach.Count);
        Assert.Equal("P001", danhSach[0].Id);
        Assert.Equal(
            "Dang Huu Dang Tam",
            danhSach[0].Name
        );
    }

    [Fact]
    public void LivingPeople_DanhSachCoNguoiDaMat_ChiTraVeNguoiConSong()
    {
        // Arrange.
        PersonList danhSach = new PersonList();

        danhSach.Add(
            new Person(
                "P001",
                "Dang Huu Dang Tam",
                2006,
                0
            )
        );

        danhSach.Add(
            new Person(
                "P002",
                "Nguyen Van A",
                1950,
                2020
            )
        );

        danhSach.Add(
            new Person(
                "P003",
                "Tran Thi B",
                2001,
                0
            )
        );

        // Act.
        PersonList nguoiConSong =
            danhSach.LivingPeople();

        // Assert.
        Assert.Equal(2, nguoiConSong.Count);
        Assert.Equal("P001", nguoiConSong[0].Id);
        Assert.Equal("P003", nguoiConSong[1].Id);

        Assert.True(nguoiConSong[0].IsLiving());
        Assert.True(nguoiConSong[1].IsLiving());
    }

    [Fact]
    public void LivingPeople_KhongCoNguoiConSong_TraVeDanhSachRong()
    {
        // Arrange.
        PersonList danhSach = new PersonList();

        danhSach.Add(
            new Person(
                "P001",
                "Nguyen Van A",
                1950,
                2020
            )
        );

        danhSach.Add(
            new Person(
                "P002",
                "Tran Van B",
                1960,
                2021
            )
        );

        // Act.
        PersonList nguoiConSong =
            danhSach.LivingPeople();

        // Assert.
        Assert.Equal(0, nguoiConSong.Count);
    }

    [Fact]
    public void CopyConstructor_SaoChepSauDanhSach()
    {
        // Arrange.
        PersonList danhSachGoc = new PersonList();

        danhSachGoc.Add(
            new Person(
                "P001",
                "Dang Huu Dang Tam",
                2006,
                0
            )
        );

        // Act.
        PersonList banSao =
            new PersonList(danhSachGoc);

        banSao[0].Name = "Ten da thay doi";

        // Assert.
        Assert.Equal(1, banSao.Count);

        // Du lieu cua ban sao da thay doi.
        Assert.Equal(
            "Ten da thay doi",
            banSao[0].Name
        );

        // Du lieu cua danh sach goc khong thay doi.
        Assert.Equal(
            "Dang Huu Dang Tam",
            danhSachGoc[0].Name
        );

        // Hai danh sach khong dung chung doi tuong Person.
        Assert.NotSame(
            danhSachGoc[0],
            banSao[0]
        );
    }
}