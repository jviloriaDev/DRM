using Spartane.Services.Spartan_Query;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace oAuth.WebApi.Helpers
{
    public static class GeneralHelper
    {
        public static string ReplaceFLD(string query, string auxMatch, object obj, PropertyInfo info, string capture)
        {
            if (info.PropertyType == typeof(string))
            {
                string value = (string)obj.GetType().GetProperty(auxMatch).GetValue(obj, null);
                query = query.Replace(capture, "'" + value + "'");
            }
            if (info.PropertyType == typeof(int))
            {
                int value = (int)obj.GetType().GetProperty(auxMatch).GetValue(obj, null);
                query = query.Replace(capture, value.ToString());
            }
            if (info.PropertyType == typeof(bool))
            {
                bool value = (bool)obj.GetType().GetProperty(auxMatch).GetValue(obj, null);
                query = query.Replace(capture, value == true ? "1" : "0");
            }
            if (info.PropertyType == typeof(DateTime))
            {
                DateTime value = (DateTime)obj.GetType().GetProperty(auxMatch).GetValue(obj, null);
                query = query.Replace(capture, "'" + value.ToShortDateString() + "'");
            }
            return query;
        }

        public static string EvaluaQuery(string query)
        {
            string value = "";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        value = reader[0].ToString();
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            return value;
        }


        public static void SendEmail(string subject, string to, string body)
        {

        }
    }
}