using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBenhAn.Data
{
    /// <summary>Lớp tiện ích tầng Data hỗ trợ truy cập SQL Server tập trung; Form không viết SQL trực tiếp.</summary>
    public static class Db
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["QuanLyBenhAnDB"].ConnectionString; }
        }

        public static SqlConnection OpenConnection()
        {
            var cn = new SqlConnection(ConnectionString);
            cn.Open();
            return cn;
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

        // Các nghiệp vụ nhiều bảng dùng cùng kết nối và transaction từ Service.
        public static int Execute(SqlConnection cn, SqlTransaction tr, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tr))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(SqlConnection cn, SqlTransaction tr, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tr))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteScalar();
            }
        }

        public static string TaoMaLePhi()
        {
            // 20 ký tự, không phụ thuộc IDENTITY hay stored procedure.
            return "LP" + Guid.NewGuid().ToString("N").Substring(0, 18);
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
