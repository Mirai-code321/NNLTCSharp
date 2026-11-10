# 02 · Lập trình hướng đối tượng

> Từ các hàm xử lý độc lập đến mô hình dữ liệu và hành vi được đóng gói trong lớp.

[← Trang chính](../README.md)

## 📚 Nội dung và kiến thức đã học

| Nhóm | Nội dung | Kiến thức vận dụng |
| --- | --- | --- |
| [TH01](TH01) | Nhập xuất, menu, số nguyên tố, hoán vị, chuỗi, sinh viên, lương, mảng | Củng cố hàm, xử lý dữ liệu, mảng một/hai chiều và tổ chức chương trình. |
| [TH02](TH02) | Các project thư viện, chương trình sử dụng thư viện và kiểm thử | Chia project, tái sử dụng mã nguồn, tham chiếu project và xUnit. |
| [TH02_2/Bai01](TH02_2/Bai01) | Tuổi sinh viên, Point, Person, phân số, đơn thức | Class, field, property, constructor, đóng gói dữ liệu và phương thức. |
| [TH02_2/Bai02](TH02_2/Bai02) | Mảng điểm, danh sách người, dãy số, ma trận, đa thức, dãy phân số, tính lương | Tập hợp đối tượng, indexer, mô hình dữ liệu phức hợp, kế thừa và đa hình. |
| [TH02_2/Bai03](TH02_2/Bai03) | Sinh viên, sắp xếp bằng interface và delegate | Giao kèo so sánh, truyền hành vi và tái sử dụng thuật toán sắp xếp. |
| [TH02_2/Bai04](TH02_2/Bai04) | Tính điểm thí sinh | Mô hình hóa nghiệp vụ, kế thừa, ghi đè và xử lý theo loại đối tượng. |

## 🧠 Kết quả học tập

- **Đóng gói:** gom dữ liệu và hành vi liên quan vào một lớp; dùng property để kiểm soát dữ liệu.
- **Khởi tạo:** dùng constructor thiết lập trạng thái ban đầu của đối tượng.
- **Tái sử dụng:** chia thư viện và tận dụng kế thừa cho các mô hình có phần chung.
- **Đa hình:** thao tác qua kiểu chung và thực thi hành vi phù hợp với lớp cụ thể.
- **Interface và delegate:** tách quy tắc so sánh khỏi thuật toán sắp xếp.
- **Kiểm thử:** xác nhận phương thức bằng bộ test tương ứng, thay vì chỉ quan sát đầu ra console.

## ▶️ Chạy thử

Từ thư mục gốc repository:

```powershell
dotnet run --project "Lab02_DangHuuDangTam_3124411265/TH02_2/Bai01/Bai02_Point/Bai02_Point.csproj"
dotnet test "Lab02_DangHuuDangTam_3124411265/TH02_2/Bai01/Bai02.PointTest/Bai02.PointTest.csproj"
```

Đọc file lớp và test song song để hiểu quy tắc dữ liệu của từng mô hình. Lab có nhiều target framework; kiểm tra `.csproj` trước khi chọn SDK/runtime.
