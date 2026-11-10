<div align="center">

# 📘 Ngôn ngữ lập trình C#

**Từ thuật toán cơ bản đến ứng dụng desktop kết nối cơ sở dữ liệu**

![C#](https://img.shields.io/badge/Language-C%23-512BD4?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge)
![WinForms](https://img.shields.io/badge/Desktop-WinForms-0078D4?style=for-the-badge)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=for-the-badge)

**Đặng Hữu Đăng Tâm · MSSV: 3124411265**

</div>

---

## 🎯 Giới thiệu

Kho mã nguồn tổng hợp 6 lab của môn **Ngôn ngữ lập trình C#**, phát triển theo lộ trình: tư duy thuật toán → lập trình hướng đối tượng → LINQ → WinForms → SQL Server.

Mỗi lab có README riêng giải thích kiến thức đã vận dụng, nhóm bài tập và cách chạy. Các project kiểm thử có sẵn tập trung ở Lab01 và Lab02.

## 🧭 Lộ trình thực hành

| Lab | Chủ đề | Kiến thức đã học |
| :---: | --- | --- |
| [01](Lab01_DangHuuDangTam_3124411265/README.md) | **C# cơ bản & thuật toán** | Nhập xuất, biểu thức, rẽ nhánh, vòng lặp, hàm, xử lý số, mảng và ma trận qua 12 buổi. |
| [02](Lab02_DangHuuDangTam_3124411265/README.md) | **Hướng đối tượng** | Lớp, constructor, property, đóng gói, tập hợp đối tượng, indexer, interface, delegate, kế thừa và đa hình. |
| [03](Lab03_DangHuuDangTam_3124411265/README.md) | **LINQ** | Lọc, biến đổi, sắp xếp, thống kê, gom nhóm và kết nối dữ liệu. |
| [04](Lab04_WinFormBasic_DangHuuDangTam_3124411265/README.md) | **WinForms cơ bản** | Form, control, sự kiện, kiểm tra đầu vào; ứng dụng tính toán và quản lý đơn giản. |
| [05](Lab05_WinFormAdv_DangHuuDangTam_3124411265/README.md) | **WinForms nâng cao** | ListBox, ListView, quản lý danh sách, đếm ngược và điều hướng bằng menu. |
| [06](Lab06_CSDL_Basic_DangHuuDangTam_3124411265/README.md) | **Cơ sở dữ liệu & ADO.NET** | SQL Server, đọc và cập nhật dữ liệu, liên kết ComboBox; quản lý sinh viên, điểm và cửa hàng. |

## 🗂️ Cấu trúc repository

```text
NNLTCSharp/
├── Lab01_DangHuuDangTam_3124411265/              # Buoi01 → Buoi12
├── Lab02_DangHuuDangTam_3124411265/              # TH01, TH02, TH02_2
├── Lab03_DangHuuDangTam_3124411265/              # Bai2 → Bai6
├── Lab04_WinFormBasic_DangHuuDangTam_3124411265/ # TH4c, TH4d
├── Lab05_WinFormAdv_DangHuuDangTam_3124411265/   # TH5c, TH5d
├── Lab06_CSDL_Basic_DangHuuDangTam_3124411265/   # TH6a, TH6b, script SQL
├── .gitignore
└── README.md
```

File `.sln`/`.slnx` nhóm các project liên quan; `.csproj` xác định cấu hình từng project. Các bài là những chương trình độc lập, hãy chọn đúng project muốn chạy. File build và dữ liệu IDE được loại khỏi các lần commit mới.

## 🚀 Bắt đầu

### Môi trường

- **.NET SDK 10** cho phần lớn bài tập. Một số project dùng `net8.0` hoặc `.NET Framework 4.8`, cần môi trường tương ứng khi chạy chúng.
- IDE hỗ trợ target framework của project. WinForms cần **Windows**; nếu dùng Visual Studio, cài workload **.NET desktop development**.
- Lab06 cần **SQL Server** và công cụ thực thi script SQL; xem hướng dẫn trong README của lab.

### Lấy code và chạy một bài

```powershell
 git clone https://github.com/Mirai-code321/NNLTCSharp.git
 cd NNLTCSharp

# Ví dụ: truy vấn LINQ trên mảng số nguyên
 dotnet run --project "Lab03_DangHuuDangTam_3124411265/Bai2/Bai2_1_LinQ/Bai2_1_LinQ.csproj"
```

Lần chạy đầu cần Internet nếu phải khôi phục gói NuGet. Có thể mở trực tiếp `.csproj`, hoặc mở solution của bài rồi chọn project khởi động.

## 🧪 Kiểm thử

Các project có tên chứa `Test` dùng xUnit để kiểm tra logic bài tập tương ứng. Ví dụ:

```powershell
 dotnet test "Lab01_DangHuuDangTam_3124411265/Buoi01/Buoi1_BaiTapCoBan/Bai1_InNhanTest/Bai1_InNhanTest.csproj"
```

Đọc test cùng lớp xử lý để hiểu đầu vào, đầu ra và tình huống biên. Kiểm thử logic cần được bổ sung bằng việc chạy thử giao diện và kết nối cơ sở dữ liệu.

---

<div align="center">

**Học qua thực hành · Hiểu qua mã nguồn · Củng cố bằng kiểm thử**

</div>
