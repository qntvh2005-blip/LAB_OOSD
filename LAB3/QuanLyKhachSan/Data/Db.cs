using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKhachSan.Data
{
    public static class Db
    {
        public static SqlConnection Open()
        {
            var c = new SqlConnection(ConfigurationManager.ConnectionStrings["QuanLyKhachSanDB"].ConnectionString);
            c.Open(); return c;
        }
        public static SqlCommand Command(SqlConnection c, SqlTransaction t, string sql, params object[] args)
        {
            var cmd = new SqlCommand(sql, c, t);
            for (int i = 0; i < args.Length; i++) cmd.Parameters.AddWithValue("@p" + i, args[i] ?? DBNull.Value);
            return cmd;
        }
        public static DataTable Query(string sql, params object[] args)
        {
            using (var c = Open()) using (var cmd = Command(c, null, sql, args))
            using (var da = new SqlDataAdapter(cmd)) { var dt = new DataTable(); da.Fill(dt); return dt; }
        }
        public static object Scalar(SqlConnection c, SqlTransaction t, string sql, params object[] args)
        { using (var cmd = Command(c, t, sql, args)) return cmd.ExecuteScalar(); }
        public static int Execute(SqlConnection c, SqlTransaction t, string sql, params object[] args)
        { using (var cmd = Command(c, t, sql, args)) return cmd.ExecuteNonQuery(); }
        // LAB quy mô nhỏ: một khóa nghiệp vụ dùng chung giúp tuần tự hóa các thao tác ghi.
        // Tất cả Service ghi đều đi qua Tx; không coi đây là bảo vệ cho SQL chạy ngoài ứng dụng.
        public static void Tx(Action<SqlConnection, SqlTransaction> action)
        {
            using (var c = Open()) using (var t = c.BeginTransaction())
            {
                try
                {
                    Execute(c,t,@"DECLARE @r int; EXEC @r=sys.sp_getapplock
@Resource=N'QuanLyKhachSan.Business',@LockMode='Exclusive',@LockOwner='Transaction',@LockTimeout=10000;
IF @r<0 THROW 50001,N'Hệ thống đang bận. Vui lòng thử lại.',1;");
                    action(c,t); t.Commit();
                }
                catch { t.Rollback(); throw; }
            }
        }
        public static void Require(bool ok, string message) { if (!ok) throw new InvalidOperationException(message); }
        public static void Required(params string[] values)
        { foreach (var v in values) Require(!string.IsNullOrWhiteSpace(v), "Vui lòng nhập đủ các trường bắt buộc."); }
        public static string Id(string prefix) { return prefix + Guid.NewGuid().ToString("N").Substring(0, 24); }
    }
}
