
## LAB5/README.md

```md
# ✈️ LAB 5 — Quản lý công ty du lịch

[← Quay về trang chủ repository](../)

## 📌 Thông tin

| Nội dung | Chi tiết |
|:--|:--|
| Sinh viên | Trần Văn Hiếu |
| MSSV | 1250080054 |
| Chủ đề | Phân tích, thiết kế hệ thống quản lý công ty du lịch |

## 🎯 Mục tiêu

Phân tích và thiết kế các chức năng quản lý tour, chuyến du lịch, đăng ký khách, hướng dẫn viên và thống kê cho hệ thống công ty du lịch.

## 🧭 Nội dung thực hiện

### Lập lịch chuyến khách lẻ

Use case **Lập lịch chuyến khách lẻ** do nhân viên điều hành thực hiện, gồm hai nhánh chức năng:

- Tạo chuyến.
- Đóng đăng ký.

Khi tạo chuyến, hệ thống kiểm tra thông tin bắt buộc, kiểm tra tour đang mở bán, tính ngày về theo số ngày của tour và lưu dữ liệu chuyến đi.

## 📐 Mô hình thiết kế

- Phân rã Use Case: Lập lịch chuyến khách lẻ.
- Sequence Diagram: Tạo chuyến khách lẻ.
- Activity Diagram: Tạo chuyến khách lẻ.

## 🖥️ Giao diện hệ thống

Các giao diện được thiết kế gồm:

- `FrmMain`: điều hướng hệ thống.
- `FrmDanhMuc`: quản lý phương tiện, điểm bán vé, hướng dẫn viên và điểm tham quan.
- `FrmTour`: quản lý tour, điểm dừng, phương tiện theo chặng và điểm tham quan.
- `FrmChuyenLe`: lập lịch chuyến khách lẻ và đóng đăng ký.
- `FrmDangKyLe`: đăng ký và thanh toán vé khách lẻ.
- `FrmDangKyDoan`: quản lý phiếu đăng ký đoàn và danh sách người đi.
- `FrmPhanCongHDV`: phân công hướng dẫn viên không trùng lịch.
- `FrmKetThucKhaoSat`: thanh toán sau tour, khảo sát và góp ý khách hàng.
- `FrmLuongThongKe`: quản lý lương hướng dẫn viên và thống kê tổng hợp.

## 📄 Báo cáo

[📥 Xem báo cáo LAB 5](./1250080084_TranVanHieu_LAB5.docx)

---

> *LAB 5 — Trần Văn Hiếu · MSSV 1250080054*