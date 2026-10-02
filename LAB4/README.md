Trần Văn Hiếu
1250080054

Hướng dẫn chạy project e-SHOPPING

1. Tạo cơ sở dữ liệu

Mở SQL Server Management Studio.

Kết nối server .\MSSQLSERVER05 bằng Windows Authentication.

Mở file Database.sql trong thư mục Database.

Nhấn Execute để tạo CSDL ESHOPPING_LAB4 và dữ liệu cấu hình mẫu.

2. Cấu hình kết nối

Mở App.config của project e-SHOPPING và sử dụng:

<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <startup useLegacyV2RuntimeActivationPolicy="true">
    <supportedRuntime version="v4.0"
                      sku=".NETFramework,Version=v4.7.2" />
  </startup>

  <connectionStrings>
    <add name="ESHOPPING"
         connectionString="Data Source=.\MSSQLSERVER05;Initial Catalog=ESHOPPING_LAB4;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
         providerName="System.Data.SqlClient" />
  </connectionStrings>
</configuration>

Nếu dùng server khác, sửa Data Source cho phù hợp. Giữ nguyên tên kết nối ESHOPPING.

3. Chạy chương trình

Mở e-SHOPPING.sln bằng Visual Studio có hỗ trợ .NET Framework 4.7.2.

Nhấn chuột phải project e-SHOPPING → Set as Startup Project.

Chọn Build → Build Solution.

Nhấn F5 để chạy ứng dụng.

Chọn sản phẩm, thêm vào giỏ và tiếp tục đặt hàng.

Đăng ký tài khoản mới nếu chưa có, sau đó đăng nhập.
