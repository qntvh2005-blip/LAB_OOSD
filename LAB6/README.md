# 🏥 LAB 6 — Quản lý hồ sơ bệnh án

[← Quay về trang chủ repository](../)

## 📌 Thông tin

| Nội dung | Chi tiết |
|:--|:--|
| Sinh viên | Trần Văn Hiếu |
| MSSV | 1250080054 |
| Chủ đề | Phân tích, thiết kế hệ thống quản lý hồ sơ bệnh án |
| Công nghệ | C# WinForms, .NET Framework 4.7.2, SQL Server |
| Kiến trúc | UI → Service → Data |

## 🎯 Mục tiêu

Phân tích và thiết kế hệ thống quản lý bệnh nhân, lệ phí năm, hồ sơ bệnh án, khám bệnh, xét nghiệm, toa thuốc, lịch khám định kỳ và hoàn tất đợt điều trị.

## 🧭 Nội dung thực hiện

- Đăng ký bệnh nhân lần đầu, thu lệ phí năm và cấp hồ sơ bệnh án.
- Tra cứu thông tin bệnh nhân và lịch sử khám.
- Đặt lịch khám sức khỏe định kỳ theo quý.
- Lập phiếu khám, ghi nhận triệu chứng và chẩn đoán.
- Chỉ định xét nghiệm và cập nhật kết quả.
- Lập toa thuốc gắn với phiếu khám.
- Thanh toán viện phí và hoàn tất đợt điều trị.

## 📐 Mô hình thiết kế

- Xác định Class, thuộc tính, phương thức và ID.
- Xác định association và multiplicity giữa các Class.
- Xác định Actor và đặc tả các Use Case trọng tâm.
- Class Diagram.
- Use Case Diagram tổng quát.
- Use Case Diagram phân rã từ đăng ký khám đến xét nghiệm và nhận toa thuốc.
- Activity Diagram cho quy trình đăng ký khám đến nhận toa.
- Sequence Diagram cho nghiệp vụ lập toa thuốc.
- ERD thiết kế cơ sở dữ liệu SQL Server.
- Sơ đồ kiến trúc và điều hướng các module giao diện.

## 🗄️ Cơ sở dữ liệu

CSDL `QuanLyBenhAn` gồm 14 bảng, sử dụng khóa chính, khóa ngoại và các ràng buộc UNIQUE để bảo đảm tính toàn vẹn dữ liệu.

Các nghiệp vụ ghi nhiều bảng được xử lý bằng transaction, gồm:

- Đăng ký bệnh nhân, cấp hồ sơ và thu lệ phí.
- Tiếp nhận lịch định kỳ và tạo phiếu khám.
- Chỉ định xét nghiệm, cập nhật kết quả và trạng thái phiếu khám.
- Lưu toa thuốc, chi tiết toa và tổng tiền.
- Thanh toán viện phí và hoàn tất đợt điều trị.

Script CSDL: `Database/QuanLyBenhAn.sql`.

## 🖥️ Giao diện hệ thống

- `FrmMain`: điều hướng các module.
- `FrmDanhMuc`: quản lý khoa, bác sĩ, loại xét nghiệm và thuốc.
- `FrmDangKyHoSo`: đăng ký bệnh nhân, cấp hồ sơ và gia hạn lệ phí năm.
- `FrmLichDinhKy`: đặt và xem lịch khám định kỳ theo quý.
- `FrmKhamBenh`: tạo phiếu khám, ghi nhận triệu chứng và chẩn đoán.
- `FrmXetNghiem`: chỉ định xét nghiệm và cập nhật kết quả.
- `FrmToaThuoc`: chọn thuốc, nhập số lượng, liều dùng, cách dùng và lưu toa.
- `FrmVienPhiHoanTat`: tính viện phí, thanh toán và ghi nhận kết quả điều trị.
- `FrmTraCuuLichSu`: tra cứu hồ sơ, phiếu khám, xét nghiệm và toa thuốc.

## 🧪 Kiểm thử

Các kịch bản kiểm thử tập trung vào:

1. Đăng ký lần đầu, đóng lệ phí năm và cấp hồ sơ trong cùng giao dịch.
2. Tra cứu đúng lịch sử khám của bệnh nhân.
3. Đặt lịch đúng năm, quý và không trùng lịch cùng quý của hồ sơ.
4. Liên kết xét nghiệm với đúng phiếu khám.
5. Liên kết toa thuốc và chi tiết thuốc với đúng phiếu khám.
6. Chỉ hoàn tất đợt điều trị khi giao dịch thanh toán thành công.

## 🚀 Chạy chương trình

1. Mở `QuanLyBenhAn.sln` bằng Visual Studio.
2. Chọn project `QuanLyBenhAn` làm Startup Project.
3. Kiểm tra SQL Server có CSDL `QuanLyBenhAn`.
4. Điều chỉnh chuỗi kết nối tại `QuanLyBenhAn/App.config` cho phù hợp.
5. Build project và nhấn `F5` để chạy.

Cấu hình hiện tại sử dụng SQL Server instance `.\MSSQLSERVER05` và Windows Authentication.

Máy cần .NET Framework 4.7.2 Developer Pack và bộ công cụ phát triển ứng dụng desktop .NET.

> Lưu ý: Nếu CSDL đã có sẵn, không cần chạy lại script SQL. Script có lệnh DROP TABLE, chỉ sử dụng khi chủ động tạo lại CSDL và đã sao lưu dữ liệu.

---

> *LAB 6 — Trần Văn Hiếu · MSSV 1250080054*