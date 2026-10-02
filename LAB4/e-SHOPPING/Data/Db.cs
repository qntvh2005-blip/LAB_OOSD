using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace e_SHOPPING.Data
{
    public static class Db
    {
        public static SqlConnection Open()
        {
            var setting=ConfigurationManager.ConnectionStrings["ESHOPPING"];
            if(setting==null) throw new InvalidOperationException("Chưa cấu hình kết nối ESHOPPING trong App.config.");
            var c=new SqlConnection(setting.ConnectionString); c.Open(); return c;
        }
        public static SqlCommand Command(SqlConnection c,string sql,SqlTransaction tx=null)
        { return new SqlCommand(sql,c,tx) { CommandTimeout=15 }; }
        public static void Param(SqlCommand cmd,string name,SqlDbType type,object value,int size=0)
        { var p=size==0?cmd.Parameters.Add(name,type):cmd.Parameters.Add(name,type,size); p.Value=value??DBNull.Value; }
        public static void Money(SqlCommand cmd,string name,decimal value)
        { var p=cmd.Parameters.Add(name,SqlDbType.Decimal); p.Precision=19;p.Scale=2;p.Value=value; }
    }
}
