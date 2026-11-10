# 05 · Windows Forms nâng cao

> Quản lý danh sách và xây dựng các luồng tương tác phong phú hơn trên desktop.

[← Trang chính](../README.md)

## 📚 Nội dung và kiến thức đã học

| Nhóm | Bài tập | Kiến thức vận dụng |
| --- | --- | --- |
| [TH5c](TH5c) | Ước số, quản lý sinh viên, xử lý chuỗi | Thao tác danh sách, chọn phần tử và cập nhật dữ liệu hiển thị. |
| [TH5c](TH5c) | Từ điển, ListBox số, danh bạ | Quản lý tập hợp dữ liệu và tra cứu theo nội dung nhập. |
| [TH5d](TH5d) | ListView sinh viên, quản lý học viên | Trình bày dữ liệu nhiều cột, xử lý lựa chọn và đồng bộ thông tin trên form. |
| [TH5d](TH5d) | Tài khoản ngân hàng | Mô hình dữ liệu tài khoản và xử lý các thao tác nghiệp vụ trên giao diện. |
| [TH5d](TH5d) | Đếm ngược, menu tổng hợp | Timer, trạng thái thời gian và tổ chức điều hướng bằng menu. |

## 🧠 Kết quả học tập

- Chọn ListBox hoặc ListView theo cách trình bày dữ liệu cần thiết.
- Phối hợp thao tác trên danh sách với các ô nhập liệu và nút chức năng.
- Quản lý trạng thái trong các sự kiện chọn, thêm, sửa hoặc xóa tùy bài tập.
- Vận dụng Timer cho đếm ngược và menu để tổ chức các chức năng ứng dụng.

## ▶️ Chạy thử

Cần Windows và .NET SDK hỗ trợ WinForms. Từ thư mục gốc:

```powershell
dotnet run --project "Lab05_WinFormAdv_DangHuuDangTam_3124411265/TH5d/Bai01_ListViewSinhVien/Bai01_ListViewSinhVien.csproj"
```

Khi kiểm tra, chú ý trạng thái chưa chọn dòng, danh sách rỗng và các lần thao tác liên tiếp. Với bài đếm ngược, kiểm tra luồng bắt đầu/dừng theo các nút được cung cấp.
