# LAB 5 – Quản lý công ty du lịch Văn Hóa Việt

## Thông tin sinh viên

- **Họ và tên:** Trần Văn Hiếu
- **MSSV:** 1250080054

## Giới thiệu

Bài LAB phân tích và thiết kế hệ thống quản lý công ty du lịch Văn Hóa Việt.

Hệ thống hỗ trợ quản lý tour, hành trình, chuyến khách lẻ, đăng ký theo đoàn, phân công hướng dẫn viên, thanh toán, khảo sát khách hàng và thống kê.

## Mục tiêu

- Phân tích các nghiệp vụ của công ty du lịch.
- Xây dựng mô hình UML theo pha phân tích và pha thiết kế.
- Bổ sung phân rã Use Case, sơ đồ tuần tự và sơ đồ hoạt động.
- Thiết kế cơ sở dữ liệu SQL Server nhất quán với mô hình lớp.
- Xây dựng ứng dụng C# WinForms theo kiến trúc UI → Service → Data.
- Xây dựng kịch bản kiểm thử và truy vết yêu cầu.

## Các chức năng chính

| Chức năng | Nội dung |
|---|---|
| Quản lý danh mục | Phương tiện, điểm bán vé, hướng dẫn viên và điểm tham quan |
| Quản lý tour | Thông tin tour, điểm dừng và phương tiện theo chặng |
| Quản lý chuyến khách lẻ | Tạo lịch chuyến, xác định ngày về và đóng đăng ký |
| Đăng ký khách lẻ | Chọn chuyến, ghi nhận khách và thanh toán vé |
| Đăng ký theo đoàn | Quản lý phiếu đoàn, thành viên, bảo hiểm và tiền cọc |
| Phân công hướng dẫn viên | Phân công theo chuyến hoặc đoàn, kiểm tra trùng lịch |
| Thanh toán và khảo sát | Thanh toán sau tour, gửi khảo sát và ghi nhận phản hồi |
| Lương và thống kê | Tính lương hướng dẫn viên và thống kê tổng hợp |

## Công nghệ sử dụng

- **Ngôn ngữ:** C#
- **Giao diện:** Windows Forms
- **Nền tảng:** .NET Framework 4.7.2
- **Cơ sở dữ liệu:** SQL Server
- **Môi trường phát triển:** Visual Studio 2026
- **Công cụ vẽ UML:** draw.io

## Kiến trúc ứng dụng

**UI → Service → Data → SQL Server**

- **UI:** Hiển thị giao diện, nhận thông tin và thông báo kết quả.
- **Service:** Xử lý nghiệp vụ và kiểm tra các điều kiện.
- **Data:** Thực hiện truy vấn và cập nhật cơ sở dữ liệu.

## Nội dung UML bổ sung

Chức năng được chọn bổ sung là **lập lịch chuyến khách lẻ**, gồm:

- Sơ đồ phân rã Use Case.
- Sơ đồ tuần tự tạo chuyến khách lẻ.
- Sơ đồ hoạt động tạo chuyến khách lẻ.

## Hướng dẫn chạy

1. Mở solution của project trong Visual Studio.
2. Chuẩn bị cơ sở dữ liệu SQL Server theo script của bài LAB.
3. Kiểm tra kết nối `QuanLyCongTyDuLichDB` trong `App.config`.
4. Đặt project ứng dụng làm Startup Project.
5. Chọn **Build → Rebuild Solution**.
6. Nhấn **F5** hoặc **Ctrl + F5** để chạy.

> Lưu ý: Kiểm tra script trước khi chạy trên cơ sở dữ liệu có dữ liệu cần giữ.

## Trạng thái kiểm tra

- Đã biên dịch thành công với .NET Framework 4.7.2.
- Đã kiểm tra hiển thị 9 Form với tổng cộng 17 màn hình/tab.
- Các thao tác nghiệp vụ với SQL Server cần được kiểm thử riêng bằng dữ liệu thử nghiệm.