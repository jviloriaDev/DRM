using Spartane.Services.GeneratePDF;
using Spartane.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace oAuth.WebApi.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    public class GeneratePDFController : BaseApiController
    {

        #region Variable Declaration
        private IGeneratePDFService _IGeneratePDFService;
        #endregion

        public GeneratePDFController(IGeneratePDFService GeneratePDFService)
        {
            this._IGeneratePDFService = GeneratePDFService;
        }

        /// <summary>
        /// Genera PDF
        /// </summary>
        /// <param name="idFormat"></param>
        /// <param name="RecordId"></param>
        /// <returns>Arreglo de bytes con la informacion del pdf</returns>
        [Authorize]
        [HttpGet]
        public HttpResponseMessage GeneratePdf(int idFormat, string RecordId, string ImgDirectory)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                var data = _IGeneratePDFService.GeneratePDF(connectionString, idFormat, RecordId, ImgDirectory);
                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }


        }
        [Authorize]
        [HttpGet]
        public HttpResponseMessage GenerateHtml(int idFormat, string RecordId, string ImgDirectory)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                var data = _IGeneratePDFService.GenerateHTML(connectionString, idFormat, RecordId, ImgDirectory);
                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }


        }
    }
}