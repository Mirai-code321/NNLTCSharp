# LAB02 - LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG C#

## Thông tin sinh viên

- Họ và tên: Đặng Hữu Đăng Tâm
- Mã sinh viên: 3124411265
- Môn học: Ngôn ngữ lập trình C#
- Tuần thực hành: Tuần 2
- Nền tảng: .NET 10.0
- Kiểm thử: xUnit

## Giới thiệu

Repository này lưu trữ bài thực hành cá nhân Lab02 về lập trình hướng
đối tượng bằng ngôn ngữ C#.

Bài thực hành giúp vận dụng các kiến thức về lớp và đối tượng, tính đóng
gói, constructor, property, mảng đối tượng, indexer, interface, delegate,
collection, kế thừa và đa hình.

Mỗi bài tập được tổ chức thành một project chương trình và một project
xUnit Test tương ứng nhằm kiểm tra tính đúng đắn của các phương thức.

## Kiến thức được sử dụng

### 1. Lớp và đối tượng

Lớp được sử dụng để mô tả dữ liệu và hành vi của các đối tượng như:

- Sinh viên
- Điểm trong mặt phẳng
- Người
- Phân số
- Đơn thức
- Đa thức
- Nhân viên
- Thí sinh

Các thuộc tính và phương thức liên quan được đóng gói trong cùng một lớp.

### 2. Field và Property

Field dùng để lưu dữ liệu bên trong đối tượng. Property cung cấp cách đọc
và thay đổi dữ liệu có kiểm soát.

Property được sử dụng để:

- Kiểm tra họ tên không được để trống.
- Kiểm tra năm sinh không vượt quá năm hiện tại.
- Kiểm tra mẫu số khác 0.
- Kiểm tra số mũ và điểm số hợp lệ.
- Bảo vệ dữ liệu bên trong đối tượng.

Ví dụ:

```csharp
private double x;

public double X
{
    get => x;
    set => x = value;
}

3. Constructor
Các lớp sử dụng nhiều dạng constructor:
- Constructor mặc định.
- Constructor có tham số.
- Constructor sao chép.
Constructor giúp đối tượng có trạng thái hợp lệ ngay khi được khởi tạo.

4. Interface
Interface định nghĩa một giao kèo mà lớp hoặc struct phải thực hiện.
Interface có thể chứa:
- Method
- Property
- Event
- Indexer
Lớp cài đặt interface phải hiện thực đầy đủ các thành viên được khai báo
trong interface.
Trong bài tập, interface được sử dụng để xây dựng tiêu chí so sánh và
thuật toán sắp xếp có thể tái sử dụng cho nhiều kiểu dữ liệu.

5. Abstract class và Interface
Abstract class được sử dụng khi các lớp con có chung dữ liệu và hành vi.
Interface được sử dụng khi cần quy định khả năng hoặc giao kèo mà nhiều
lớp khác nhau phải thực hiện.
Các bài tính lương và quản lý thí sinh vận dụng lớp trừu tượng, kế thừa
và phương thức ghi đè.

6. Mảng và mảng đối tượng
Mảng được sử dụng để quản lý nhiều giá trị hoặc nhiều đối tượng cùng kiểu.
Các bài tập có sử dụng:
- Mảng một chiều.
- Mảng hai chiều.
- Mảng đối tượng Point.
- Mảng đối tượng Person.
- Danh sách phân số.
- Danh sách đơn thức.
Các thao tác chính gồm nhập, xuất, tìm kiếm, tính tổng, tìm giá trị lớn
nhất và sắp xếp.

7. Indexer
Indexer cho phép đối tượng được truy cập bằng cú pháp giống như mảng.
Ví dụ:
Point point = arrayPoint[0];

Indexer được sử dụng trong các lớp quản lý danh sách và có kiểm tra chỉ
số trước khi truy cập phần tử.

8. Struct và Enum
Struct phù hợp với những kiểu dữ liệu nhỏ và có ngữ nghĩa giá trị.
Enum dùng để biểu diễn một nhóm giá trị có tên, giúp chương trình dễ đọc
và hạn chế sử dụng các giá trị số không rõ ý nghĩa.
Enum có thể được sử dụng để biểu diễn loại nghiệm, loại nhân viên hoặc
trạng thái xử lý.

9. Collections
Các collection được giới thiệu và vận dụng gồm:
- ArrayList
- List<T>
- Queue<T>
- Stack<T>
- Collection tự xây dựng
List<T> được ưu tiên khi cần quản lý danh sách đối tượng có số lượng
thay đổi trong quá trình chạy.

10. Nạp chồng toán tử
Các lớp Point, PhanSo và DonThuc sử dụng nạp chồng toán tử để các
đối tượng có thể thực hiện phép toán bằng cú pháp tự nhiên.
Các toán tử được sử dụng gồm:
+  -  *  /

11. Ghi đè ToString()
Phương thức ToString() được ghi đè để định dạng đối tượng khi xuất.
Ví dụ:
Point   : (3, 4)
PhanSo : 2/3
DonThuc: 5x^2

12. Generic, Interface và Delegate
Generic giúp xây dựng thuật toán dùng được với nhiều kiểu dữ liệu.
Interface và delegate được sử dụng để truyền tiêu chí so sánh vào thuật
toán sắp xếp, giúp tách thuật toán khỏi kiểu dữ liệu cụ thể.

13. Kế thừa và đa hình
Kế thừa được sử dụng khi nhiều lớp có chung thông tin và hành vi.
Đa hình cho phép gọi cùng một phương thức nhưng nhận kết quả khác nhau
tùy theo loại đối tượng thực tế.
Nội dung này được vận dụng trong:
- Bài tính lương nhân viên.
- Bài quản lý điểm thí sinh.
- Bài xây dựng ConsoleMenu.

14. Xử lý ngoại lệ
Chương trình xử lý các trường hợp không hợp lệ như:
- Họ tên rỗng.
- Năm sinh nằm trong tương lai.
- Mẫu số bằng 0.
- Chia cho phân số hoặc đơn thức bằng 0.
- Chỉ số mảng nằm ngoài phạm vi.
- Danh sách rỗng.
- Điểm số không nằm trong khoảng từ 0 đến 10.

15. Unit Test với xUnit
Mỗi bài tập có project kiểm thử tương ứng.
Unit Test được sử dụng để kiểm tra:
- Constructor và property.
- Công thức tính toán.
- Các phép toán trên đối tượng.
- Trường hợp dữ liệu biên.
- Trường hợp phát sinh ngoại lệ.
- Kết quả của phương thức chính.