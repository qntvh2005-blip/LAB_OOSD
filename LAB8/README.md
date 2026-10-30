# 🏢 LAB 8 · Quản lý cho thuê văn phòng ở cao ốc

> Thực hành Phân tích thiết kế hướng đối tượng (OOSD) · HUTECH  
> Chuỗi chuyển đổi chuẩn công nghiệp: **Yêu cầu nghiệp vụ → Biểu đồ UML → CSDL SQL Server 3NF (Transactions) → C# WinForms (.NET Framework 4.7.2) → Kịch bản kiểm thử (RTM)**

![Visual Studio 2022](https://img.shields.io/badge/Visual_Studio-2022-5C2D91?style=flat-square)
![.NET Framework 4.7.2](https://img.shields.io/badge/.NET_Framework-4.7.2-512BD4?style=flat-square)
![SQL Server](https://img.shields.io/badge/SQL_Server-2022-CC2927?style=flat-square)
![C# 7.3](https://img.shields.io/badge/C%23-7.3-239120?style=flat-square)
![Build Passing](https://img.shields.io/badge/Build-Passing-brightgreen?style=flat-square)

---

## 1. Thông tin sinh viên và bài Lab

| Nội dung | Thông tin chi tiết |
| --- | --- |
| **Họ và tên sinh viên** | **Trần Văn Hiếu** |
| **Mã số sinh viên (MSSV)** | **1250080054** |
| **Lớp học phần** | **12_ĐH_CNPM1** |
| **Tên bài Lab** | **Bài 4 – Quản lý cho thuê văn phòng ở cao ốc (LAB 8)** |
| **Học phần** | Thực hành Phân tích thiết kế hướng đối tượng (OOSD) |
| **File Báo cáo Word** | [1250080054_TranVanHieu_LAB8.docx](1250080054_TranVanHieu_LAB8.docx) |
| **Thư mục Project** | `D:\GITHUB\LAB_OOSD\LAB8\` |

---

## 2. Môi trường phát triển và cấu hình kết nối CSDL

| Thành phần | Phiên bản / Cấu hình thực tế |
| --- | --- |
| **Hệ điều hành** | Windows 10 / 11, 64-bit |
| **IDE** | **Visual Studio 2022 Community** (Workload: *.NET desktop development*) |
| **Framework** | **.NET Framework 4.7.2** (Windows Forms Application) |
| **Ngôn ngữ** | C# 7.3 |
| **Hệ quản trị CSDL** | **Microsoft SQL Server** |
| **Instance CSDL cấu hình** | `.\MSSQLSERVER05` (có sẵn cơ chế fallback thông minh về `(localdb)\MSSQLLocalDB` và `.`) |
| **Tên CSDL** | `QuanLyChoThueVanPhong` |
| **Chế độ xác thực** | Windows Authentication (`Integrated Security=True;TrustServerCertificate=True`) |
| **File Script SQL** | `Database/QuanLyChoThueVanPhong.sql` |

---

## 3. Các quy tắc nghiệp vụ cốt lõi đã hiện thực (Business Rules)

Hệ thống tuân thủ 100% các ràng buộc thực tế trong mô tả đề bài:
1. **Thuê nhiều phòng cùng lúc & tối thiểu 6 tháng:** Khách hàng có thể lập hợp đồng thuê cùng lúc nhiều văn phòng. Thời hạn thuê bắt buộc `>= 6 tháng` (kiểm tra ở cả mức UI, Service C# và `CHECK` constraint SQL Server).
2. **Trả trước 6 tháng đầu tiên:** Tiền thuê của 6 tháng đầu tiên được tính bằng `Tổng tiền thuê 1 tháng × 6` và tự động đánh dấu đã thanh toán ngay khi hợp đồng được ký kết thành công.
3. **Thanh toán tháng thứ 7+ vào ngày 01 đầu tháng:** Từ tháng thứ 7 trở đi (nếu thời hạn thuê > 6 tháng), hệ thống tự động lên lịch thanh toán với ngày hẹn trả là **ngày 01 của mỗi tháng**.
4. **Chi phí dịch vụ thanh toán cuối tháng:** Giá thuê phòng không bao gồm tiền điện, nước, internet... Các khoản phí dịch vụ này được chốt chỉ số và lập hóa đơn thanh toán riêng vào **ngày cuối tháng** (28/29/30/31).
5. **Gia hạn hợp đồng (Quy tắc kép):**
   - Thời gian gia hạn: $\le \frac{1}{2}$ thời hạn hợp đồng ban đầu (`SoThangGiaHan <= ThoiHanThueThang / 2`).
   - Sạch nợ tuyệt đối: Hợp đồng chỉ được gia hạn khi **không còn nợ tiền thuê mặt bằng** và **đã thanh toán đầy đủ các hóa đơn dịch vụ đã sử dụng**.
6. **Báo cáo nhân viên & Cấp thẻ giữ xe:** Lưu trữ thông tin nhân viên văn phòng (mã số, họ tên, CCCD, chức vụ, phòng, tầng...) và cấp thẻ giữ xe gắn với biển số, loại xe (xe máy, ô tô).
7. **Kiểm tra phòng định kỳ 1 năm & Xử phạt kết cấu:** Định kỳ 1 năm/lần cao ốc tiến hành kiểm tra tình trạng phòng; nếu phát hiện tự ý thay đổi, chỉnh sửa kết cấu sẽ lập biên bản xử phạt theo quy định.

---

## 4. Danh mục biểu đồ UML (Phân tích & Thiết kế)

Tất cả biểu đồ được xuất ảnh độ phân giải cao tại thư mục `Diagrams/` và nhúng trực tiếp vào file Word báo cáo:

| STT | Tên Biểu Đồ | File Ảnh | Mục Đích & Nội Dung |
|:---:|:---:|:---:|:---|
| **H1** | **Class Diagram** | `Diagrams/ClassDiagram.png` | 14 lớp nghiệp vụ đầy đủ thuộc tính, phương thức, định danh `{ID}` và bản số multiplicity (`1..*`, `0..1`). |
| **H2** | **Use Case Diagram Tổng Quát** | `Diagrams/UseCase_TongQuat.png` | 5 nhóm tác nhân (Khách hàng, Nhân viên VP, Quản lý cao ốc, Kế toán, Kỹ thuật) và 12 Use Case tổng quát. |
| **H3** | **Use Case Diagram Phân Rã** | `Diagrams/UseCase_PhanRa.png` | Phân rã chi tiết từ ký hợp đồng → thanh toán T7+ đầu tháng → hóa đơn dịch vụ cuối tháng với `<<include>>` và `<<extend>>`. |
| **H4** | **Activity Diagram** | `Diagrams/ActivityDiagram.png` | Luồng hoạt động phân 3 làn bơi (Khách Hàng – Kế Toán – Hệ Thống), điểm rẽ nhánh `>= 6 tháng` và sự kiện thời gian. |
| **H5** | **Sequence Diagram** | `Diagrams/SequenceDiagram_GiaHan.png` | Tương tác lập phiếu gia hạn: kiểm tra $\le 1/2$ TG gốc, kiểm tra sạch nợ tiền thuê và dịch vụ, thực thi Stored Procedure trong Transaction. |

---

## 5. Cấu trúc Solution & Kiến trúc phần mềm

Project C# WinForms được xây dựng theo kiến trúc **UI → Service → Data**:

```
D:\GITHUB\LAB_OOSD\LAB8\
├── 1250080054_TranVanHieu_LAB8.docx       # Báo cáo Word hoàn chỉnh chuẩn mẫu HUTECH
├── README.md                              # Tài liệu hướng dẫn và mô tả dự án
├── QuanLyChoThueVanPhong.sln              # Solution Visual Studio 2022
├── Database/
│   └── QuanLyChoThueVanPhong.sql          # Script SQL 14 bảng 3NF, Stored Procedures, Seed Data
├── Diagrams/
│   ├── ClassDiagram.png                   # Hình 1: Biểu đồ lớp
│   ├── UseCase_TongQuat.png               # Hình 2: Use Case tổng quát
│   ├── UseCase_PhanRa.png                 # Hình 3: Use Case phân rã chi tiết
│   ├── ActivityDiagram.png                # Hình 4: Biểu đồ luồng hoạt động
│   └── SequenceDiagram_GiaHan.png         # Hình 5: Biểu đồ tuần tự gia hạn
└── QuanLyChoThueVanPhong/
    ├── App.config                         # Chuỗi kết nối SQL Server (.\MSSQLSERVER05)
    ├── Program.cs                         # Điểm khởi chạy ứng dụng (Main)
    ├── QuanLyChoThueVanPhong.csproj       # Project file .NET Framework 4.7.2
    ├── Data/
    │   └── Db.cs                          # Data Access Layer (ADO.NET, parameterized queries, fallback)
    ├── Services/
    │   ├── Models.cs                      # DTOs, KetQuaXuLy, QuyDinhCaoOc constants
    │   ├── DanhMucService.cs              # Nghiệp vụ Tầng, Phòng, Dịch vụ, Khách hàng
    │   ├── HopDongService.cs              # Nghiệp vụ lập hợp đồng nhiều phòng, tính tiền 6th, sinh T7+
    │   ├── ThanhToanService.cs            # Nghiệp vụ thu tiền thuê tháng 7+ và hóa đơn dịch vụ cuối tháng
    │   ├── GiaHanService.cs               # Nghiệp vụ kiểm tra điều kiện gia hạn (<=1/2 TG, sạch nợ)
    │   ├── NhanVienTheXeService.cs        # Báo cáo nhân viên văn phòng và cấp thẻ giữ xe
    │   ├── KiemTraPhongService.cs         # Kiểm tra phòng định kỳ 1 năm và xử phạt vi phạm kết cấu
    │   └── ThongKeService.cs              # Báo cáo tỷ lệ lấp đầy, doanh thu thuê, dịch vụ, công nợ
    └── Forms/
        ├── FormHelper.cs                  # Tiện ích ComboBox, Grid, hiển thị thông báo
        ├── FrmMain.cs / .Designer.cs      # Dashboard điều hướng trung tâm
        ├── FrmDanhMuc.cs / .Designer.cs   # Quản lý 4 Tab danh mục cao ốc
        ├── FrmHopDongThue.cs / .Designer  # Lập và quản lý hợp đồng cho thuê văn phòng
        ├── FrmThanhToanThang.cs / .Des.   # Thanh toán tiền thuê tháng 7+ & hóa đơn dịch vụ cuối tháng
        ├── FrmGiaHan.cs / .Designer.cs    # Lập phiếu gia hạn hợp đồng (kiểm soát 3 quy tắc)
        ├── FrmNhanVienTheXe.cs / .Des.    # Quản lý nhân viên văn phòng & cấp thẻ giữ xe
        ├── FrmKiemTraXuPhat.cs / .Des.    # Kiểm tra phòng định kỳ & lập biên bản xử phạt kết cấu
        └── FrmThongKeBaoCao.cs / .Des.    # Báo cáo thống kê lấp đầy, doanh thu, công nợ
```

---

## 6. Hướng dẫn chạy dự án trên Visual Studio 2022

### Bước 1: Khởi tạo Cơ Sở Dữ Liệu SQL Server
1. Mở **SQL Server Management Studio (SSMS)**.
2. Kết nối tới instance SQL Server của bạn (ví dụ: `.\MSSQLSERVER05` hoặc `(local)`).
3. Mở file script: `D:\GITHUB\LAB_OOSD\LAB8\Database\QuanLyChoThueVanPhong.sql`.
4. Nhấn **Execute (F5)** để tạo CSDL `QuanLyChoThueVanPhong`, các bảng, ràng buộc toàn vẹn, Stored Procedure và dữ liệu mẫu kiểm thử.

### Bước 2: Mở và chạy trên Visual Studio 2022
1. Khởi động **Visual Studio 2022**.
2. Chọn **Open a project or solution** → Duyệt đến file `D:\GITHUB\LAB_OOSD\LAB8\QuanLyChoThueVanPhong.sln`.
3. Kiểm tra file `App.config`: Đảm bảo chuỗi kết nối khớp với instance SQL Server của máy:
   ```xml
   <connectionStrings>
     <add name="CaoOcDB" 
          connectionString="Data Source=.\MSSQLSERVER05;Initial Catalog=QuanLyChoThueVanPhong;Integrated Security=True;Connect Timeout=10;TrustServerCertificate=True" 
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```
4. Bấm **Ctrl + Shift + B** để Build Solution (xác nhận `0 errors, 0 warnings`).
5. Bấm **F5** (hoặc nút **Start**) để khởi chạy hệ thống. Màn hình FrmMain sẽ hiển thị sẵn sàng cho việc thao tác và nghiệm thu toàn bộ kịch bản kiểm thử.

---

## 7. Kết quả kiểm thử & Ma trận truy vết (RTM)

- Toàn bộ **20/20 Test Cases** kiểm thử trên dữ liệu thực tế đều đạt kết quả **ĐẠT (PASS)**.
- Ma trận truy vết yêu cầu (BR) → Mô hình UML → Form / Service C# → Bảng CSDL SQL → Test Case được trình bày chi tiết trong file báo cáo Word:
  - `TC01 - TC04`: Kiểm thử quy tắc thuê tối thiểu 6 tháng và trả trước 6 tháng đầu.
  - `TC05 - TC08`: Kiểm thử thanh toán tiền thuê từ tháng thứ 7+ vào ngày 01 đầu tháng.
  - `TC09 - TC11`: Kiểm thử ghi nhận dịch vụ và thanh toán cuối tháng.
  - `TC12 - TC15`: Kiểm thử quy tắc kép gia hạn ($\le 1/2$ TG gốc và sạch toàn bộ nợ tiền thuê + dịch vụ).
  - `TC16 - TC18`: Kiểm thử khai báo nhân sự văn phòng và cấp thẻ giữ xe.
  - `TC19 - TC20`: Kiểm thử kiểm tra phòng định kỳ 1 năm và xử phạt tự ý thay đổi kết cấu cao ốc.
