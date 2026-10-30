using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyChoThueVanPhong.Data
{
    /// <summary>
    /// Lớp tiện ích tầng Data hỗ trợ truy cập SQL Server tập trung;
    /// Form UI và Service không mở kết nối phân tán hoặc viết chuỗi SQL nối chuỗi không an toàn.
    /// </summary>
    public static class Db
    {
        private static string _activeConnString = null;

        public static string ConnectionString
        {
            get
            {
                if (!string.IsNullOrEmpty(_activeConnString))
                    return _activeConnString;

                if (ConfigurationManager.ConnectionStrings["QuanLyChoThueVanPhongDB"] != null)
                {
                    _activeConnString = ConfigurationManager.ConnectionStrings["QuanLyChoThueVanPhongDB"].ConnectionString;
                    return _activeConnString;
                }

                // Fallback mặc định
                _activeConnString = @"Data Source=.\MSSQLSERVER05;Initial Catalog=QuanLyChoThueVanPhong;Integrated Security=True;Connect Timeout=10;TrustServerCertificate=True";
                return _activeConnString;
            }
            set
            {
                _activeConnString = value;
            }
        }

        public static SqlConnection OpenConnection()
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(ConnectionString);
                cn.Open();
                return cn;
            }
            catch (Exception)
            {
                // Nếu instance .\MSSQLSERVER05 không phản hồi, thử fallback sang (localdb)\MSSQLLocalDB hoặc .
                string[] fallbacks = new string[]
                {
                    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyChoThueVanPhong;Integrated Security=True",
                    @"Data Source=.;Initial Catalog=QuanLyChoThueVanPhong;Integrated Security=True"
                };

                foreach (var fb in fallbacks)
                {
                    try
                    {
                        var testCn = new SqlConnection(fb);
                        testCn.Open();
                        _activeConnString = fb;
                        return testCn;
                    }
                    catch { }
                }

                // Nếu vẫn lỗi, ném ngoại lệ rõ ràng để người dùng biết đã chạy script SQL chưa
                throw new Exception("Không thể kết nối SQL Server! Vui lòng đảm bảo bạn đã chạy script 'QuanLyChoThueVanPhong.sql' trên SQL Server (instance .\\MSSQLSERVER05 hoặc (localdb)\\MSSQLLocalDB).");
            }
        }

        public static DataTable Query(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int Execute(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteScalar();
            }
        }

        public static DataTable ExecuteProc(string procName, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(procName, cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (ps != null && ps.Length > 0) cmd.Parameters.AddRange(ps);
                using (var da = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /// <summary>Tạo SqlParameter an toàn; chuỗi rỗng / null được chuyển thành DBNull.</summary>
        public static SqlParameter P(string name, object value)
        {
            var s = value as string;
            if (value == null || (s != null && s.Trim().Length == 0))
                return new SqlParameter(name, DBNull.Value);
            return new SqlParameter(name, s != null ? (object)s.Trim() : value);
        }
    }
}
