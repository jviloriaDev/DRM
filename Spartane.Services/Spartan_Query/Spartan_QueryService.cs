using Newtonsoft.Json;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Core.Data;
using Spartane.Data.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Spartan_Query
{
    public class Spartan_QueryService : ISpartan_QueryService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        #endregion

        #region Ctor
        public Spartan_QueryService(IDataProvider dataProvider, IDbContext dbContext)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
        }
        #endregion

        #region CRUD Operations
        public string ExecuteQuery(string query)
        {
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "query";
                padreKey.DbType = DbType.String;
                padreKey.Value = query;
                var result = _dbContext.ExecuteStoredProcedureList<SpExecuteQuery>("sp_ExecuteQuery", padreKey).FirstOrDefault();
                if (result != null)
                    return result.result;
                return "";
            }
            catch (Exception ex)
            {
                return "";
                //return query + "//" + ex.Message;
            }
        }

        public string ExecuteRawQuery(string query)
        {
            try
            {
                DataTable dt = _dbContext.ExecuteRawSql(query);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(dt);
                return JSONString;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
     
        public Dictionary<string, string> ExecuteQueryDictionary(string query)
        {
            try
            {
                Dictionary<string, string> result = new Dictionary<string, string>();
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "query";
                padreKey.DbType = DbType.String;
                padreKey.Value = query;
                var partialresult = _dbContext.ExecuteStoredProcedureList<SpExecuteQueryDictionary>("sp_ExecuteQueryClaveValor", padreKey).ToList();
                if (partialresult != null)
                {
                    result = new Dictionary<string, string>();
                    foreach (var item in partialresult)
                    {
                        result.Add(item.Clave, item.Description);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<SpExecuteQueryDictionary> ExecuteQueryEnumerable(string query)
        {
            try
            {
                IEnumerable<SpExecuteQueryDictionary> result;
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "query";
                padreKey.DbType = DbType.String;
                padreKey.Value = query;
                var partialresult = _dbContext.ExecuteStoredProcedureList<SpExecuteQueryDictionary>("sp_ExecuteQueryClaveValor", padreKey).ToList();

                result = partialresult as IEnumerable<SpExecuteQueryDictionary>;
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        //CAMBIOS MANUALES


        public string ExecuteQueryTable(string query)
        {
            try
            {
                string result = "";
                query += " FOR XML PATH('Data'), ROOT ('Root')"; 
                System.Data.SqlClient.SqlParameter p = new System.Data.SqlClient.SqlParameter("@query", query);
                object[] parameters = new object[] { p };
                var partialresult = _dbContext.SqlQuery<string>(query).ToList();
                foreach (var item in partialresult)
                {
                    result += item;
                }
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ExecuteRawQuery2(string query, string[] parametros)
        {
            try
            {
                DataTable dt = _dbContext.ExecuteRawSql(query, parametros);
                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(dt);
                return JSONString;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

       
    }
}
