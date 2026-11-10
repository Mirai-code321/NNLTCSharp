# 03 · Truy vấn dữ liệu với LINQ

> Diễn đạt việc lọc, biến đổi và tổng hợp dữ liệu bằng các chuỗi phép truy vấn.

[← Trang chính](../README.md)

## 📚 Nội dung và kiến thức đã học

| Nhóm | Nội dung | Kiến thức vận dụng |
| --- | --- | --- |
| [Bài 2](Bai2) | Truy vấn mảng số nguyên và mảng chuỗi | `Where`, `Select`, biểu thức lambda, lọc theo nhiều điều kiện và biến đổi chuỗi. |
| [Bài 3](Bai3) | Thống kê số và chuỗi | `Sum`, `Min`, `Max`, `Count`, `Distinct`, `GroupBy`; gom nhóm theo khóa. |
| [Bài 4](Bai4) | Mô hình môn học và dữ liệu mẫu | Tạo lớp đối tượng và danh sách làm nguồn truy vấn. |
| [Bài 5](Bai5) | Lọc và thống kê danh sách môn học | Sắp xếp nhiều tiêu chí, chọn trường dữ liệu, đếm và tính tổng số tiết. |
| [Bài 6](Bai6) | Kết hợp môn học và hệ đào tạo | `Join`, `GroupJoin`, `DefaultIfEmpty`, left outer join và thống kê theo hệ. |

## 🧠 Kết quả học tập

- Phân biệt **lọc phần tử** (`Where`) với **biến đổi kết quả** (`Select`).
- Phối hợp sắp xếp, gom nhóm và tổng hợp để trả lời câu hỏi về dữ liệu.
- Hiểu khóa kết nối và lý do cần giữ các nhóm chưa có phần tử khi dùng left join.
- Áp dụng LINQ cho dữ liệu trong bộ nhớ; các bài lab này không yêu cầu SQL Server.

## ▶️ Chạy thử

Từ thư mục gốc repository:

```powershell
dotnet run --project "Lab03_DangHuuDangTam_3124411265/Bai2/Bai2_1_LinQ/Bai2_1_LinQ.csproj"
dotnet run --project "Lab03_DangHuuDangTam_3124411265/Bai6/Bai6_2_LinQ/Bai6_2_LinQ.csproj"
```

Đổi dữ liệu mẫu rồi quan sát kết quả từng truy vấn để hiểu tác dụng của từng toán tử.
