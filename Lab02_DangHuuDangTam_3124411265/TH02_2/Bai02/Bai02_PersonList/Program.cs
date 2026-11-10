using Bai02PersonList;
using Bai03Person;

Console.WriteLine("CHUONG TRINH QUAN LY DANH SACH NGUOI");
Console.WriteLine();

PersonList danhSach = new PersonList();

// Nhap danh sach nguoi.
danhSach.Input();

Console.WriteLine("\nDANH SACH DA NHAP");
danhSach.Output();

// Lay danh sach nhung nguoi con song.
PersonList nguoiConSong =
    danhSach.LivingPeople();

Console.WriteLine("\nDANH SACH NGUOI CON SONG");
nguoiConSong.Output();

// Them mot nguoi moi de minh hoa phuong thuc Add.
Person nguoiMoi = new Person(
    "P100",
    "Nguyen Van Moi",
    2000,
    0
);

danhSach.Add(nguoiMoi);

Console.WriteLine("\nDANH SACH SAU KHI THEM");
danhSach.Output();