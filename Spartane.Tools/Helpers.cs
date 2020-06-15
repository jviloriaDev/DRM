using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Tools
{
    public class Helpers
    {
        private static RandomNumberGenerator rng = RandomNumberGenerator.Create();

        public static DataSet GetDataSet(string sql, string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();

            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }

        public static DataSet GetDataSet(SqlCommand sqlCmd, string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            sqlCmd.Connection = conn;
            da.SelectCommand = sqlCmd;
            DataSet ds = new DataSet();

            conn.Open();
            da.Fill(ds);
            conn.Close();

            return ds;
        }

        public static T GetScalar<T>(SqlCommand sqlCmd, string connectionString)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            object value;

            sqlCmd.Connection = conn;
            da.SelectCommand = sqlCmd;

            conn.Open();
            value = sqlCmd.ExecuteScalar();
            conn.Close();

            return (T)value;
        }

        public static string Get8Digits()
        {
            var bytes = new byte[4];
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }
    }
}
