using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhanSu.Data
{
    public static class Db
    {
        public static string ConnectionString = ConfigurationManager
            .ConnectionStrings["QuanLyNhanSuDB"]
            .ConnectionString;

        public static SqlParameter P(string k, object v)
        {
            return new SqlParameter(k, v ?? DBNull.Value);
        }

        public static DataTable Query(string sql, params SqlParameter[] p)
        {
            using (var c = new SqlConnection(ConnectionString))
            {
                c.Open();
                return Query(c, null, sql, p);
            }
        }

        public static DataTable Query(
            SqlConnection c,
            SqlTransaction t,
            string sql,
            params SqlParameter[] p
        )
        {
            using (var cmd = new SqlCommand(sql, c, t))
            {
                cmd.Parameters.AddRange(p);
                using (var a = new SqlDataAdapter(cmd))
                {
                    var d = new DataTable();
                    a.Fill(d);
                    return d;
                }
            }
        }

        public static object Scalar(
            SqlConnection c,
            SqlTransaction t,
            string sql,
            params SqlParameter[] p
        )
        {
            using (var cmd = new SqlCommand(sql, c, t))
            {
                cmd.Parameters.AddRange(p);
                return cmd.ExecuteScalar();
            }
        }

        public static int Execute(
            SqlConnection c,
            SqlTransaction t,
            string sql,
            params SqlParameter[] p
        )
        {
            using (var cmd = new SqlCommand(sql, c, t))
            {
                cmd.Parameters.AddRange(p);
                return cmd.ExecuteNonQuery();
            }
        }

        public static void Transaction(Action<SqlConnection, SqlTransaction> action)
        {
            using (var c = new SqlConnection(ConnectionString))
            {
                c.Open();
                using (var t = c.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        action(c, t);
                        t.Commit();
                    }
                    catch
                    {
                        t.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
