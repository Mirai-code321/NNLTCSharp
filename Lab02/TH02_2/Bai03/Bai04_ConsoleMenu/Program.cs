using Bai04ConsoleMenu;

// Tao ung dung giai phuong trinh bac hai.
PTBac2Console app = new PTBac2Console();

// Dang ky them mot ham xu ly su kien tu ben ngoai.
// Ham nay ghi nhan lua chon cua nguoi dung.
app.Choose += (sender, e) =>
{
    Console.WriteLine(
        $"Su kien Choose da duoc phat voi lua chon {e.LuaChon}."
    );
};

// Chay chuong trinh menu.
app.Run();