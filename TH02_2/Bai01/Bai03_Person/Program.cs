using Bai03Person;

Console.WriteLine("CHUONG TRINH QUAN LY THONG TIN MOT NGUOI");
Console.WriteLine();

// Tao doi tuong bang constructor mac dinh.
Person person = new Person();

// Nhap thong tin.
person.Input();

Console.WriteLine("\nTHONG TIN DA NHAP");

// Xuat thong tin.
person.Output();

// Kiem tra trang thai song.
if (person.IsLiving())
{
    Console.WriteLine(
        $"{person.Name} hien tai con song."
    );
}
else
{
    Console.WriteLine(
        $"{person.Name} da mat."
    );
}

// Tao mot ban sao bang copy constructor.
Person banSao = new Person(person);

Console.WriteLine("\nTHONG TIN BAN SAO");
banSao.Output();