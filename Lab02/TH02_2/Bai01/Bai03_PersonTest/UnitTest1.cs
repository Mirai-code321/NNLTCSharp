using Bai03Person;

namespace Bai03_Person.Tests;

public class PersonTests
{
    [Fact]
    public void Constructor_CoThamSo_GanDungThongTin()
    {
        // Arrange va Act.
        Person person = new Person(
            "P001",
            "Dang Huu Dang Tam",
            2006,
            0
        );

        // Assert.
        Assert.Equal("P001", person.Id);
        Assert.Equal("Dang Huu Dang Tam", person.Name);
        Assert.Equal(2006, person.Yob);
        Assert.Equal(0, person.Yod);
    }

    [Fact]
    public void CopyConstructor_SaoChepDayDuThongTin()
    {
        // Arrange.
        Person personGoc = new Person(
            "P001",
            "Dang Huu Dang Tam",
            2006,
            0
        );

        // Act.
        Person banSao = new Person(personGoc);

        // Assert.
        Assert.NotSame(personGoc, banSao);
        Assert.Equal(personGoc.Id, banSao.Id);
        Assert.Equal(personGoc.Name, banSao.Name);
        Assert.Equal(personGoc.Yob, banSao.Yob);
        Assert.Equal(personGoc.Yod, banSao.Yod);
    }

    [Fact]
    public void IsLiving_NamMatBangKhong_TraVeTrue()
    {
        // Arrange.
        Person person = new Person(
            "P001",
            "Dang Huu Dang Tam",
            2006,
            0
        );

        // Act.
        bool ketQua = person.IsLiving();

        // Assert.
        Assert.True(ketQua);
    }

    [Fact]
    public void IsLiving_CoNamMat_TraVeFalse()
    {
        // Arrange.
        Person person = new Person(
            "P002",
            "Nguyen Van A",
            1950,
            2020
        );

        // Act.
        bool ketQua = person.IsLiving();

        // Assert.
        Assert.False(ketQua);
    }

    [Fact]
    public void Constructor_NamMatNhoHonNamSinh_NemArgumentException()
    {
        // Act.
        Action hanhDong = () => new Person(
            "P003",
            "Tran Van B",
            2000,
            1999
        );

        // Assert.
        Assert.Throws<ArgumentException>(hanhDong);
    }
}