﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using Spartane.Core.Exceptions.Service;
using System.Web;
using Spartane.Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using Spartane.Services.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using System.Data;
using System.Web.Script.Serialization;
using oAuth.WebAPI.Consumer;
using oAuth.WebApi.Helpers;
using System.Configuration;
using System.Text;

using Spartane.Services.Spartan_Bitacora_SQL;
using Spartane.Core.Classes.Spartan_Bitacora_SQL;

namespace Spartane.WebApi.Controllers
{
    
    public partial class Interpretacion_Frecuencia_cardiaca_en_EsfuerzoController : BaseApiController
    {
        #region Variables
        private IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44391;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Interpretacion_Frecuencia_cardiaca_en_EsfuerzoController(IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Interpretacion_Frecuencia_cardiaca_en_Esfuerzo";
            
        }
        #endregion Constructor


        #region API Methods
        [Authorize]
        public HttpResponseMessage Get(int id)
        {
            var entity = this.service.GetByKey(id, false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAll()
        {
            var entity = this.service.SelAll(false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        [HttpGet]
        public HttpResponseMessage ListaSelAll(int startRowIndex, int maximumRows, string where = "", string order = "")
        {
            var entity = this.service.ListaSelAll(startRowIndex, maximumRows, where, order);
            entity.RowCount = this.service.ListaSelAllCount(where);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAllComplete()
        {
            var entity = this.service.SelAllComplete(false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAll(string where, string order)
        {
            var entity = this.service.SelAll(false, where, order);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage Post(Interpretacion_Frecuencia_cardiaca_en_Esfuerzo varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsInterpretacion_Frecuencia_cardiaca_en_Esfuerzo" , new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsInterpretacion_Frecuencia_cardiaca_en_Esfuerzo", new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsInterpretacion_Frecuencia_cardiaca_en_Esfuerzo",new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Interpretacion_Frecuencia_cardiaca_en_Esfuerzo varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo)
        {
            if (ModelState.IsValid && id == varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdInterpretacion_Frecuencia_cardiaca_en_Esfuerzo", new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdInterpretacion_Frecuencia_cardiaca_en_Esfuerzo", new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdInterpretacion_Frecuencia_cardiaca_en_Esfuerzo", new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Interpretacion_Frecuencia_cardiaca_en_Esfuerzo varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdInterpretacion_Frecuencia_cardiaca_en_Esfuerzo", new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdInterpretacion_Frecuencia_cardiaca_en_Esfuerzo", new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Interpretacion_Frecuencia_cardiaca_en_Esfuerzo entity = this.service.ListaSelAll(1, 1, "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio='" + id.ToString() + "'", "").Interpretacion_Frecuencia_cardiaca_en_Esfuerzos.First();
            Interpretacion_Frecuencia_cardiaca_en_Esfuerzo result = new Interpretacion_Frecuencia_cardiaca_en_Esfuerzo();
			result.Folio = entity.Folio;
result.Descripcion = entity.Descripcion;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage Interpretacion_Frecuencia_cardiaca_en_EsfuerzoGenerateID()
        {
            Interpretacion_Frecuencia_cardiaca_en_Esfuerzo varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo = new Interpretacion_Frecuencia_cardiaca_en_Esfuerzo();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_Interpretacion_Frecuencia_cardiaca_en_EsfuerzoGenerateID", new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_Interpretacion_Frecuencia_cardiaca_en_EsfuerzoGenerateID", new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Interpretacion_Frecuencia_cardiaca_en_Esfuerzo varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo = this.service.GetByKey(id, false);
            bool result = false;
            if (varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelInterpretacion_Frecuencia_cardiaca_en_Esfuerzo", new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelInterpretacion_Frecuencia_cardiaca_en_Esfuerzo", new JavaScriptSerializer().Serialize(varInterpretacion_Frecuencia_cardiaca_en_Esfuerzo), result, ex.Message);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion API Methods

        #region TunnelMethod

        /// <summary>
        /// WebAPI GetALLTunnel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllTunnel(string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/GetAll");
                var Interpretacion_Frecuencia_cardiaca_en_EsfuerzoDataTable = new JavaScriptSerializer().Deserialize<List<Interpretacion_Frecuencia_cardiaca_en_Esfuerzo>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Interpretacion_Frecuencia_cardiaca_en_EsfuerzoDataTable, Configuration.Formatters.JsonFormatter);
        }

        /// <summary>
        /// WebAPI GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetTunnel(int id,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/Get?id=" + id);
                var Interpretacion_Frecuencia_cardiaca_en_EsfuerzoResult = new JavaScriptSerializer().Deserialize<Interpretacion_Frecuencia_cardiaca_en_Esfuerzo>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Interpretacion_Frecuencia_cardiaca_en_EsfuerzoResult, Configuration.Formatters.JsonFormatter);            
        }

        /// <summary>
        /// WebAPI ListaSelAllTunnel
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="Where"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ListaSelAllTunnel(int startRowIndex, int maximumRows, string Where, string Order,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Encoding = Encoding.UTF8;
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                        "&maximumRows=" + maximumRows +
                        (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                         (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order));
                var resp = new HttpResponseMessage(HttpStatusCode.OK);
                resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
                return resp;
        }

        /// <summary>
        /// WebAPI PostTunnel
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PostTunnel(Interpretacion_Frecuencia_cardiaca_en_Esfuerzo emp,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);

                client.Headers["Content-Type"] = "application/json";
                var dataString = new JavaScriptSerializer().Serialize(emp);

                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Post"), "POST",
                    dataString);

                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);            
        }

        /// <summary>
        /// WebAPI put tunnel
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage PutTunnel(Interpretacion_Frecuencia_cardiaca_en_Esfuerzo emp, string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Headers["Content-Type"] = "application/json";
                var dataString = new JavaScriptSerializer().Serialize(emp);

                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Put?Id=" + emp.Folio), "PUT"
                , dataString);

                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        /// <summary>
        /// WebAPI Delete Tunnel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteTunnel(int id,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Headers["Content-Type"] = "application/json";
                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Delete?id=" + id), "DELETE"
                );
                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        #endregion TunnelMethod

    }
}

