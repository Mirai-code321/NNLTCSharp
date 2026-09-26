using Bai03Person;

namespace Bai02PersonList;

public class PersonList
{
    // List dung de luu cac doi tuong Person.
    private readonly List<Person> people;

    // Tra ve so luong nguoi trong danh sach.
    public int Count => people.Count;

    // Constructor mac dinh tao danh sach rong.
    public PersonList()
    {
        people = new List<Person>();
    }

    // Constructor sao chep.
    public PersonList(PersonList personList)
    {
        ArgumentNullException.ThrowIfNull(personList);

        people = new List<Person>();

        // Tao ban sao cho tung Person.
        // Hai danh sach se khong dung chung doi tuong Person.
        foreach (Person person in personList.people)
        {
            people.Add(new Person(person));
        }
    }

    // Indexer giup truy cap Person tai vi tri index.
    public Person this[int index]
    {
        get
        {
            KiemTraChiSo(index);
            return people[index];
        }

        set
        {
            KiemTraChiSo(index);
            ArgumentNullException.ThrowIfNull(value);

            people[index] = value;
        }
    }

    public void Add(Person person)
    {
        ArgumentNullException.ThrowIfNull(person);

        people.Add(person);
    }

    public void RemoveAt(int index)
    {
        KiemTraChiSo(index);

        people.RemoveAt(index);
    }

    public void Clear()
    {
        people.Clear();
    }

    private void KiemTraChiSo(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException(
                $"Chi so {index} khong hop le."
            );
        }
    }

    public void Input()
    {
        int soLuong = NhapSoLuong();

        // Xoa danh sach cu truoc khi nhap danh sach moi.
        people.Clear();

        for (int i = 0; i < soLuong; i++)
        {
            Console.WriteLine(
                $"\nNhap thong tin nguoi thu {i + 1}:"
            );

            Person person = new Person();
            person.Input();

            people.Add(person);
        }
    }

    private static int NhapSoLuong()
    {
        while (true)
        {
            Console.Write("Nhap so luong nguoi: ");
            string? duLieu = Console.ReadLine();

            if (int.TryParse(duLieu, out int soLuong) &&
                soLuong >= 0)
            {
                return soLuong;
            }

            Console.WriteLine(
                "Loi: So luong phai la so nguyen khong am."
            );
        }
    }

    public void Output()
    {
        if (Count == 0)
        {
            Console.WriteLine("Danh sach dang rong.");
            return;
        }

        Console.WriteLine(
            $"DANH SACH GOM {Count} NGUOI"
        );

        for (int i = 0; i < Count; i++)
        {
            Console.WriteLine(
                $"\nNguoi thu {i + 1}:"
            );

            people[i].Output();
        }
    }

    public PersonList LivingPeople()
    {
        PersonList ketQua = new PersonList();

        foreach (Person person in people)
        {
            if (person.IsLiving())
            {
                // Tao ban sao de danh sach ket qua
                // khong dung chung doi tuong voi danh sach goc.
                ketQua.Add(new Person(person));
            }
        }

        return ketQua;
    }
}