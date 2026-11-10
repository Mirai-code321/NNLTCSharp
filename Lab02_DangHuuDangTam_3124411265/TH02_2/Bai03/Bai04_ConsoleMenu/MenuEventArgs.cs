namespace Bai04ConsoleMenu;

public class MenuEventArgs : EventArgs
{
    // Lua chon cua nguoi dung.
    public int LuaChon { get; }

    // Danh dau lua chon da duoc xu ly hay chua.
    public bool DaXuLy { get; set; }

    public MenuEventArgs(int luaChon)
    {
        LuaChon = luaChon;
        DaXuLy = false;
    }
}