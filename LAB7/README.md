# 👥 LAB 7 · Quản lý nhân sự công ty sơn Đông Á

> Thực hành Phân tích thiết kế hướng đối tượng · UML → SQL Server → C# WinForms

![Visual Studio 2022](https://img.shields.io/badge/Visual_Studio-2022-5C2D91?style=flat-square)
![.NET Framework 4.7.2](https://img.shields.io/badge/.NET_Framework-4.7.2-512BD4?style=flat-square)
![SQL Server 2022](https://img.shields.io/badge/SQL_Server-2022-CC2927?style=flat-square)
![C# 7.3](https://img.shields.io/badge/C%23-7.3-239120?style=flat-square)

## 1. Thông tin sinh viên và bài Lab

| Nội dung | Thông tin |
| --- | --- |
| Họ và tên | **Trần Văn Hiếu** |
| MSSV | **1250080054** |
| Tên bài Lab | **Bài 7 – Quản lý nhân sự công ty sơn Đông Á** |
| Học phần | Thực hành Phân tích thiết kế hướng đối tượng |
| Báo cáo | [1250080054_TranVanHieu_LAB7.docx](1250080054_TranVanHieu_LAB7.docx) |

## 2. Môi trường và phiên bản

| Thành phần | Phiên bản / cấu hình |
| --- | --- |
| Hệ điều hành kiểm tra | Windows 11, 64-bit |
| IDE | Visual Studio **2022 Community 17.14** |
| Ngôn ngữ | C# **7.3** |
| Giao diện | Windows Forms, **.NET Framework 4.7.2** |
| CSDL đã kiểm tra | SQL Server **2022 Developer – 16.0.1000.6** |
| Công cụ chạy SQL | SQL Server Management Studio (SSMS) |
| Xác thực | Windows Authentication |
| SQL Server instance đang cấu hình | `.\MSSQLSERVER05` |
| Tên CSDL | `QuanLyNhanSu_LAB7` |

Visual Studio cần workload **.NET desktop development** và **.NET Framework 4.7.2 targeting pack**. Đây là project .NET Framework, không phải .NET Core.

## 3. Nội dung đã thực hiện

### Phân tích và thiết kế UML

- [x] Câu 1: xác định lớp, thuộc tính, phương thức và ID.
- [x] Câu 2: xác định liên kết, bản số và Class Diagram.
- [x] Câu 3: xác định Actor và Use Case tổng quát.
- [x] Câu 4: phân rã từ tiếp nhận thử việc đến ký hợp đồng chính thức.
- [x] Câu 5: Activity Diagram của quy trình ở Câu 4.
- [x] Câu 6: Sequence Diagram lập quyết định khen thưởng cá nhân hoặc tập thể.

### Chức năng chương trình

| Module | Nội dung |
| --- | --- |
| Danh mục | Phòng ban, chức vụ, ca làm việc |
| Tuyển dụng – thử việc | Lưu hồ sơ, quyết định tuyển dụng và kết quả đánh giá |
| Hợp đồng – bảo hiểm | Hợp đồng ngắn/dài hạn, BHXH/BHYT và quyết định ban đầu |
| Quyết định | Lưu lịch sử lương, phụ cấp và chức vụ theo ngày hiệu lực |
| Kế hoạch tuần | Phân ca và dự kiến phụ trội cho nhân viên theo phòng ban |
| Chấm công – phụ trội | Ghi giờ làm thực tế và phiếu phụ trội theo kế hoạch |
| Khen thưởng – kỷ luật | Quyết định cá nhân/tập thể, phân bổ và phiếu thu/chi |
| Bảng lương tháng | Tổng hợp công, phụ trội, bảo hiểm, thưởng/phạt và chốt kỳ |

### CSDL và kiến trúc

- **19 bảng**, có khóa chính, khóa ngoại, `UNIQUE` và `CHECK`, nhất quán với mô hình lớp.
- Kiến trúc **UI → Service → Data → SQL Server**; Form không tự thực hiện SQL.
- Câu lệnh có tham số; nghiệp vụ nhiều bảng dùng transaction để commit hoặc rollback đồng thời.
- Giao diện gồm **9 Form**: Form chính và 8 module. Có tìm kiếm, nhóm nhập liệu và bảng dữ liệu chỉ đọc.
- Kiểm thử có dữ liệu cụ thể và bảng truy vết **yêu cầu → UML → Form/Service → bảng CSDL → test case** trong báo cáo.

```text
LAB7/
├── Database/
│   └── QuanLyNhanSu.sql          # Một file: tạo CSDL, tạo bảng và nạp mẫu
├── QuanLyNhanSu/
│   ├── App.config                # Cấu hình kết nối
│   ├── Program.cs
│   ├── Data/Db.cs
│   ├── Services/                 # Kiểm tra nghiệp vụ và tính toán
│   ├── UI/Forms.cs               # FrmMain và các Form chức năng
│   ├── UI/ModuleForm.cs          # Thành phần giao diện dùng chung
│   └── QuanLyNhanSu.csproj
├── QuanLyNhanSu.sln
├── 1250080054_TranVanHieu_LAB7.docx
└── README.md
```

## 4. Kết quả

- Build thành công ở **Debug** và **Release** bằng Visual Studio 2022.
- Các Form tải được dữ liệu mẫu từ SQL Server.
- Script SQL gộp đã kiểm tra việc tạo mới, chạy lại không trùng, giữ dữ liệu đã nhập và rollback khi nạp mẫu lỗi.
- Bộ mẫu gồm **5 nhân viên, 4 hợp đồng, 2 hồ sơ bảo hiểm, 10 kế hoạch tuần, 88 phân công và 88 dòng chấm công**.

Bảng lương mẫu `BL0926`, tháng **09/2026**, giờ chuẩn **176**:

| Mã nhân viên | Họ tên | Thực lĩnh (đồng) |
| --- | --- | ---: |
| NV001 | Trần Minh An | **4.647.527** |
| NV002 | Nguyễn Thị Bích | **4.056.818** |
| NV003 | Lê Quốc Cường | **8.691.761** |
| NV004 | Phạm Thu Dung | **4.872.727** |
| NV005 | Võ Gia Huy | **0** |

**Tháng 09/2026 đã chốt** để xem kết quả mẫu. **Tháng 10/2026 chưa chốt trong bộ dữ liệu ban đầu**, có thể dùng để thực hành.

Tên, thông tin liên hệ và tỷ lệ BHXH **10%**, BHYT **2%** là dữ liệu giả lập. Hệ số phụ trội **1,5** áp dụng theo đề; công thức quy đổi theo giờ được nêu trong báo cáo, không phải bảng lương pháp lý cho doanh nghiệp thực tế.

## 5. Lỗi gặp phải và cách khắc phục

| Hiện tượng | Nguyên nhân | Cách khắc phục |
| --- | --- | --- |
| Form không có dữ liệu ban đầu | Chỉ chạy phần tạo bảng, chưa nạp mẫu | Gộp tạo bảng và dữ liệu mẫu trong `QuanLyNhanSu.sql` |
| Không lấy được chuỗi kết nối | Tên kết nối trong code và cấu hình không khớp | Dùng thống nhất tên `QuanLyNhanSuDB` trong `App.config` và `Data/Db.cs` |
| Nhân viên Không đạt bị chặn nhập công thử việc quá khứ | Kiểm tra theo trạng thái hiện tại thay vì ngày làm | Kiểm tra thời gian thử việc/hợp đồng tại ngày công; vẫn khóa kỳ đã chốt |
| Form khó theo dõi, vùng nhập chiếm nhiều chỗ | Bố cục chưa phù hợp số trường | Chia nhóm nhập liệu, thu gọn phần nhập và định dạng bảng tiếng Việt |
| Chạy lại script tạo bảng cũ báo trùng đối tượng | Bảng đã được tạo ở lần chạy trước | Script gộp kiểm tra schema trước; không tạo lại các bảng đã có |

**Nếu gặp lỗi trên máy giảng viên:**

- **Không kết nối được SQL Server:** kiểm tra dịch vụ SQL Server, tên instance và quyền Windows Authentication; sửa `Data Source` cho đúng máy.
- **Thiếu reference assemblies .NET Framework 4.7.2:** cài targeting pack tương ứng trong Visual Studio Installer rồi build lại.
- **CSDL thiếu bảng hoặc khác cấu trúc:** dùng CSDL mới với tên khác trong file SQL và `Initial Catalog`; không xóa CSDL đang có dữ liệu.
- **Bị chặn đánh giá/chấm công/chốt lương:** kiểm tra thời gian thử việc, phân ca, giờ ca và trạng thái kỳ lương. Đây có thể là quy tắc nghiệp vụ, không phải lỗi chương trình.

## 6. Hướng dẫn giảng viên chạy lại

### Bước 1 · Khởi tạo CSDL bằng một file

1. Mở SSMS, kết nối đúng **SQL Server instance** bằng Windows Authentication.
2. Mở [Database/QuanLyNhanSu.sql](Database/QuanLyNhanSu.sql).
3. Chạy **toàn bộ file bằng F5**. Không cần tự tạo CSDL hay chạy một file dữ liệu khác.

Script sẽ tự tạo `QuanLyNhanSu_LAB7` nếu chưa có, tạo 19 bảng và nạp dữ liệu mẫu. Tài khoản chạy cần quyền tạo CSDL/bảng và ghi dữ liệu.

> **An toàn dữ liệu:** script không DROP hay xóa dữ liệu cũ. Nếu đã có đủ bảng và có nhân viên, script giữ nguyên dữ liệu, không nạp lại mẫu. Schema đầy đủ nhưng chưa có nhân viên sẽ được nạp mẫu; schema thiếu bảng sẽ bị từ chối để tránh ghi vào CSDL không tương thích. Script không tự nâng cấp cấu trúc CSDL cũ.

### Bước 2 · Kiểm tra kết nối trong project

Mở `QuanLyNhanSu/App.config`, sửa **Data Source** cho đúng instance trên máy. Ví dụ cấu hình hiện tại:

```xml
<add
    name="QuanLyNhanSuDB"
    connectionString="Data Source=.\MSSQLSERVER05;Initial Catalog=QuanLyNhanSu_LAB7;Integrated Security=True;Connect Timeout=10;TrustServerCertificate=True"
    providerName="System.Data.SqlClient"
/>
```

Nếu dùng SQL Express, tên instance thường có dạng `.\SQLEXPRESS`; phải lấy đúng tên máy đang kết nối trong SSMS. Giữ tên kết nối **QuanLyNhanSuDB** thống nhất với code.

Nếu cần một bộ dữ liệu thử hoàn toàn mới, đổi tên CSDL tại các vị trí khởi tạo/chọn CSDL ở đầu file SQL và sửa `Initial Catalog` tương ứng. Không cần xóa dữ liệu hiện có.

### Bước 3 · Build và chạy ứng dụng

1. Mở **QuanLyNhanSu.sln** bằng **Visual Studio 2022**.
2. Chọn project **QuanLyNhanSu → Set as Startup Project** nếu cần.
3. Chọn **Build → Build Solution** (`Ctrl + Shift + B`).
4. Nhấn **F5** để chạy. Menu chính có 8 nút chức năng và nút Thoát.

Các Form được tạo bằng C# trong `UI/Forms.cs` và `UI/ModuleForm.cs`; không cần tạo lại Form bằng Designer. Sau khi khởi tạo xong, các lần mở ứng dụng tiếp theo **không cần chạy lại SQL**.

### Bước 4 · Kiểm tra nhanh kết quả

| Thao tác | Kết quả cần thấy |
| --- | --- |
| Mở Danh mục | Có PB01/PB02, CV01/CV02 và các ca làm |
| Mở Tuyển dụng và Hợp đồng | Có NV001–NV005; 4 hợp đồng của NV001–NV004 |
| Mở Chấm công – Phụ trội | Có dữ liệu tháng 09/2026; tìm NV001 thấy 22 dòng chấm công |
| Mở Khen thưởng – Kỷ luật | Có thưởng/phạt cá nhân, tập thể và thu/chi trực tiếp |
| Mở Bảng lương | Thực lĩnh `BL0926` khớp bảng ở mục 4 |
| Thử lập lại lương tháng 09/2026 | Bị từ chối vì kỳ đã chốt |

Có thể đối chiếu thêm bằng truy vấn chỉ đọc trong SSMS:

```sql
USE [QuanLyNhanSu_LAB7];

SELECT COUNT(*) AS SoBangLab
FROM sys.tables
WHERE is_ms_shipped = 0;

SELECT COUNT(*) AS SoNhanVien
FROM dbo.NhanVien;

SELECT MaBL, MaNV, GioThuong, GioPhuTroi, ThucLinh
FROM dbo.ChiTietBangLuong
WHERE MaBL = 'BL0926'
ORDER BY MaNV;
```

Trên CSDL mới chạy từ script, kết quả là **19 bảng, 5 nhân viên** và 5 dòng lương mẫu. Nếu đã nhập thêm dữ liệu, số lượng nhân viên có thể khác.

### Bước 5 · Kiểm tra luồng nghiệp vụ mới

Thực hiện theo thứ tự **Danh mục → Tuyển dụng/đánh giá → Hợp đồng/BH → Kế hoạch tuần → Chấm công/phụ trội → Thưởng/phạt → Bảng lương**. Chọn kỳ chưa chốt, mã chứng từ chưa dùng và ngày phù hợp tại thời điểm kiểm tra.

- **Thử việc:** chưa qua ngày kết thúc thì không được đánh giá; chỉ Đạt mới ký hợp đồng. Dài hạn phải có đủ BHXH/BHYT.
- **Kế hoạch và công:** đầu tuần là thứ Hai, nhân viên đúng phòng; chỉ chấm ngày đã phân ca và không vượt giờ ca.
- **Phụ trội:** phải có phân công, chấm công và kế hoạch phụ trội; không vượt tổng giờ đã dự kiến.
- **Thưởng tập thể:** ví dụ PB01 tổng 50.000 đồng, phân bổ đúng hai dòng bên dưới. Chỉ nhập mã PB, để trống mã NV ở phần đối tượng.

```text
NV001|20000
NV002|30000
```

- **Thanh toán:** `TrucTiep` lập phiếu riêng; `QuaLuong` sinh phiếu khi chốt kỳ, không trả hai lần.
- **Chốt lương:** nhập đủ căn cứ trước khi chốt. Kỳ đã chốt không được bổ sung dữ liệu nguồn ảnh hưởng kết quả.

Các ô chi tiết dùng dấu `|`, mỗi nhân viên/ngày một dòng. Nhập số thập phân bằng dấu chấm, không thêm dấu phân cách hàng nghìn. Các kịch bản chi tiết, kết quả mong đợi và bảng truy vết nằm trong báo cáo Word.
