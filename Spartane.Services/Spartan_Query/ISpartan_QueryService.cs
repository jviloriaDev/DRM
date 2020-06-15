using Spartane.Core.Classes.StoredProcedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Spartan_Query
{
    public partial interface ISpartan_QueryService
    {
        string ExecuteQuery(string query);
        //CAMBIOS MANUALES
        string ExecuteQueryTable(string query);
        Dictionary<string, string> ExecuteQueryDictionary(string query);
        IEnumerable<SpExecuteQueryDictionary> ExecuteQueryEnumerable(string query);
        string ExecuteRawQuery(string query);
        string ExecuteRawQuery2(string query, string[] parametros);
    }
}
