# 06 · SQL Server & ADO.NET

> Kết nối giao diện WinForms với dữ liệu được lưu trữ trong cơ sở dữ liệu quan hệ.

[← Trang chính](../README.md)

## 📚 Nội dung và kiến thức đã học

| Nhóm | Bài tập | Kiến thức vận dụng |
| --- | --- | --- |
| [TH6a](TH6a) | Quản lý môn học, sinh viên, điểm, lớp | Kết nối SQL Server, đọc dữ liệu lên form và thực hiện các thao tác quản lý. |
| [TH6b](TH6b) | Sinh viên ComboBox, điểm ComboBox | Liên kết dữ liệu và sử dụng giá trị lựa chọn để truy vấn thông tin liên quan. |
| [TH6b](TH6b) | Danh sách lớp, lọc điểm | Truy vấn theo điều kiện, hiển thị danh sách theo lựa chọn người dùng. |
| [TH6b](TH6b) | Quản lý cửa hàng | Quản lý sản phẩm, bán hàng, gọi stored procedure với tham số có kiểu dữ liệu. |

## 🧠 Kết quả học tập

- Dùng `Microsoft.Data.SqlClient`, `SqlConnection` và `SqlCommand` để giao tiếp SQL Server.
- Đọc kết quả truy vấn và đưa dữ liệu vào bảng hiển thị hoặc ComboBox.
- Hiểu chuỗi kết nối, tên server, tên database và Windows Authentication.
- Truyền tham số truy vấn; quản lý tài nguyên kết nối bằng `using`.
- Phối hợp giao diện, câu lệnh SQL và stored procedure trong luồng xử lý nghiệp vụ.

## 🗄️ Chuẩn bị cơ sở dữ liệu

1. Cài và khởi động SQL Server trên Windows; mở công cụ thực thi SQL như SSMS.
2. Đọc rồi chạy các script có sẵn trên SQL Server thực hành:
   - [QLSinhVien.sql](TH6a/Database/QLSinhVien.sql): cơ sở dữ liệu phục vụ các bài sinh viên, môn học, lớp và điểm.
   - [QLCuaHang.sql](TH6a/Database/QLCuaHang.sql): cơ sở dữ liệu và xử lý cho bài cửa hàng.
3. Trong project cần chạy, mở `KetNoiCSDL.cs` hoặc `CSDL.cs` và điều chỉnh `ChuoiKetNoi` theo máy.

Cấu hình hiện tại sử dụng `Server=localhost`, database `QLSinhVien` hoặc `QLCuaHang`, và `Integrated Security=True`. Nếu dùng SQL Server Express, tên server có thể cần đổi thành `localhost\SQLEXPRESS` tùy instance đã cài. Tài khoản Windows chạy ứng dụng cần có quyền truy cập database.

`TrustServerCertificate=True` trong mã nguồn phục vụ kết nối SQL Server cục bộ khi thực hành.

## ▶️ Chạy thử

Sau khi tạo database và chỉnh chuỗi kết nối, chạy từ thư mục gốc:

```powershell
dotnet run --project "Lab06_CSDL_Basic_DangHuuDangTam_3124411265/TH6a/Bai01_QuanLyMonHoc/Bai01_QuanLyMonHoc.csproj"
```

Nếu không tải được dữ liệu, kiểm tra dịch vụ SQL Server, tên instance, database và quyền đăng nhập trước. Việc build thành công chưa xác nhận kết nối hoặc các thao tác dữ liệu; cần chạy thử với database đã chuẩn bị.
