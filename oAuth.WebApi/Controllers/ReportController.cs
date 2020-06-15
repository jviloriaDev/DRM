using Spartane.Services.Spartan_Query;
using Spartane.Services.Spartan_Report;
using Spartane.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace oAuth.WebApi.Controllers
{
    public class ReportController : BaseApiController
    {
        private ISpartan_QueryService service = null;
        private ISpartan_ReportService serviceReport = null;
        public static string ApiControllerUrl { get; set; }
        public string baseApi;

        public ReportController(ISpartan_QueryService service, ISpartan_ReportService serviceReport)
        {
            this.service = service;
            this.serviceReport = serviceReport;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Report";
        }

        [Authorize]
        [HttpGet]
        public HttpResponseMessage GetReport(int id, string where)
        {
            string result = "";
            var report = serviceReport.GetByKey(id, false);
            string query = report.Query;
            string whereFinal = "";
            if (!String.IsNullOrEmpty(query) && !String.IsNullOrEmpty(where))
            {
                if (query.ToLower().Contains("where"))
                {
                    whereFinal = " AND " + where;
                }
                else
                {
                    whereFinal = " where " + where;
                }
                if (query.ToLower().Contains("group by"))
                {
                    query = query.ToLower().Replace("group by", " " + whereFinal + " group by");
                }
                else
                {
                    query = query.ToLower() + whereFinal;
                }
            }
            result = service.ExecuteRawQuery(query);
            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }
    }
}
