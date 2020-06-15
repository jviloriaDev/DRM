using Microsoft.Owin;
using Spartane.Core.Classes.Spartan_Bitacora_SQL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace oAuth.WebApi.Helpers
{
    public static class BitacoraHelper
    {


        public static string GetClientIpAddress()
        {
            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
        }


        public static string GetHostName()
        {
            return HttpContext.Current.Request.ServerVariables["REMOTE_USER"].ToString();
        }
        public enum TypeSql
        {
            INSERT, UPDATE, DELETE
        }


        public static Spartan_Bitacora_SQL GetBitacora(HttpRequestMessage request, int objectId, int Folio, TypeSql tipo, string commandText, string json, bool result, string error = null)
        {
            try
            {

                var bitacora = new Spartan_Bitacora_SQL();
                var cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                bitacora.Result = result;
                bitacora.Error = error;
                bitacora.Json = json;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(cnnString);
                bitacora.Command_SQL = commandText;
                bitacora.Computer_Name = Dns.GetHostName();               
                bitacora.Database_Name = builder.InitialCatalog;
                bitacora.Folio_SQL = Folio.ToString();

                IEnumerable<string> headerValues ;
                request.Headers.TryGetValues("Id_User", out headerValues);

                if (headerValues!= null)
                {
                    var Id_User = headerValues.FirstOrDefault();

                    if (Id_User != null)
                        bitacora.Id_User = Convert.ToInt32(Id_User);
                }
                bitacora.IP = GetClientIpAddress();

               // IPHostEntry entry = Dns.GetHostEntry(bitacora.IP);
                bitacora.Object_Id = Convert.ToInt32(objectId);
                bitacora.Register_Date = DateTime.Now;
                bitacora.Server_Name = builder.DataSource;
                bitacora.Type_SQL = tipo.ToString();
                bitacora.Windows_Version = System.Environment.OSVersion.ToString();
                bitacora.System_Version = ConfigurationManager.AppSettings["VersionApp"].ToString();
                bitacora.System_Name = ConfigurationManager.AppSettings["SystemName"].ToString();
                return bitacora;
            }catch
            {
               
                throw;
                
            }
            
        }
		
		public static Spartan_Bitacora_SQL GetBitacora(HttpRequestMessage request, int objectId, string Folio, TypeSql tipo, string commandText, string json, bool result, string error = null)
        {
            try
            {

                var bitacora = new Spartan_Bitacora_SQL();
                var cnnString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                bitacora.Result = result;
                bitacora.Error = error;
                bitacora.Json = json;
                System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(cnnString);
                bitacora.Command_SQL = commandText;
                bitacora.Computer_Name = Dns.GetHostName();
                bitacora.Database_Name = builder.InitialCatalog;
                bitacora.Folio_SQL = Folio.ToString();

                IEnumerable<string> headerValues;
                request.Headers.TryGetValues("Id_User", out headerValues);

                if (headerValues != null)
                {
                    var Id_User = headerValues.FirstOrDefault();

                    if (Id_User != null)
                        bitacora.Id_User = Convert.ToInt32(Id_User);
                }
                bitacora.IP = GetClientIpAddress();

                // IPHostEntry entry = Dns.GetHostEntry(bitacora.IP);
                bitacora.Object_Id = Convert.ToInt32(objectId);
                bitacora.Register_Date = DateTime.Now;
                bitacora.Server_Name = builder.DataSource;
                bitacora.Type_SQL = tipo.ToString();
                bitacora.Windows_Version = System.Environment.OSVersion.ToString();
                bitacora.System_Version = ConfigurationManager.AppSettings["VersionApp"].ToString();
                bitacora.System_Name = ConfigurationManager.AppSettings["SystemName"].ToString();
                return bitacora;
            }
            catch
            {

                throw;

            }

        }
    }
}