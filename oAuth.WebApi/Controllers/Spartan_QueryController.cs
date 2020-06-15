using RestSharp.Extensions.MonoHttp;
using Spartane.Services.Spartan_Query;
using Spartane.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace oAuth.WebApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class Spartan_QueryController : BaseApiController
    {
        #region Variables
        private ISpartan_QueryService service = null;
        public static string ApiControllerUrl { get; set; }
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Spartan_QueryController(ISpartan_QueryService service)
        {
            this.service = service;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Spartan_Query";
            
        }
        #endregion Constructor

        #region API Methods
        [Authorize]
        public HttpResponseMessage Get(string query)
        {
            var entity = this.service.ExecuteQuery(query);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage Post(q query)
        {
            var entity = this.service.ExecuteQuery(query.query);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        //CAMBIOS MANUALES
        [Authorize]
        [HttpPost]
        public HttpResponseMessage GetDictionary(q query)
        {
            var entity = this.service.ExecuteQueryDictionary(query.query);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage GetEnumerable(q query)
        {
            var entity = this.service.ExecuteQueryEnumerable(query.query);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [HttpPost]
        public HttpResponseMessage GetRawQuery(q query)
        {
            string newquery = query.query.Replace("\r\n", " ").Replace("\t", " ");
            var entity = this.service.ExecuteRawQuery(HttpUtility.UrlDecode(newquery));
            return Request.CreateResponse(HttpStatusCode.OK, entity);
        }
          [Authorize]
        public HttpResponseMessage GetTable(string query)
        {
            var entity = this.service.ExecuteQueryTable(query);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }
          [HttpPost]
          public HttpResponseMessage GetRawQuery2(q2 query)
          {
              query.parameters = query.parameters == null ? new string[0] : query.parameters;
              string newquery = query.query.Replace("\r\n", " ").Replace("\t", " ");
              var entity = this.service.ExecuteRawQuery2(HttpUtility.UrlDecode(newquery), query.parameters.ToArray());
              return Request.CreateResponse(HttpStatusCode.OK, entity);
          }
      
        #endregion
    }

    public class q
    {
        public string query { get; set; }
    }
    public class q2
    {
        public string query { get; set; }
        public IEnumerable<string> parameters { get; set; }
    }
}
