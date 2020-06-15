using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using Spartane.Core.Exceptions.Service;
using System.Web;
using Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento;
using Spartane.Services.Detalle_Consulta_Actividades_Registro_Evento;
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
    
    public partial class Detalle_Consulta_Actividades_Registro_EventoController : BaseApiController
    {
        #region Variables
        private IDetalle_Consulta_Actividades_Registro_EventoService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44440;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Detalle_Consulta_Actividades_Registro_EventoController(IDetalle_Consulta_Actividades_Registro_EventoService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Detalle_Consulta_Actividades_Registro_Evento";
            
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
        public HttpResponseMessage Post(Detalle_Consulta_Actividades_Registro_Evento varDetalle_Consulta_Actividades_Registro_Evento)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varDetalle_Consulta_Actividades_Registro_Evento));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsDetalle_Consulta_Actividades_Registro_Evento" , new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsDetalle_Consulta_Actividades_Registro_Evento", new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsDetalle_Consulta_Actividades_Registro_Evento",new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Detalle_Consulta_Actividades_Registro_Evento varDetalle_Consulta_Actividades_Registro_Evento)
        {
            if (ModelState.IsValid && id == varDetalle_Consulta_Actividades_Registro_Evento.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varDetalle_Consulta_Actividades_Registro_Evento));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdDetalle_Consulta_Actividades_Registro_Evento", new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdDetalle_Consulta_Actividades_Registro_Evento", new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdDetalle_Consulta_Actividades_Registro_Evento", new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Detalle_Consulta_Actividades_Registro_Evento varDetalle_Consulta_Actividades_Registro_Evento_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varDetalle_Consulta_Actividades_Registro_Evento_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varDetalle_Consulta_Actividades_Registro_Evento_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdDetalle_Consulta_Actividades_Registro_Evento", new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varDetalle_Consulta_Actividades_Registro_Evento_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdDetalle_Consulta_Actividades_Registro_Evento", new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Detalle_Consulta_Actividades_Registro_Evento entity = this.service.ListaSelAll(1, 1, "Detalle_Consulta_Actividades_Registro_Evento.Folio='" + id.ToString() + "'", "").Detalle_Consulta_Actividades_Registro_Eventos.First();
            Detalle_Consulta_Actividades_Registro_Evento result = new Detalle_Consulta_Actividades_Registro_Evento();
			result.Folio = entity.Folio;
result.Actividad = entity.Actividad;
result.Actividad_Detalle_Actividades_Evento = entity.Actividad_Detalle_Actividades_Evento;
result.Tipo_de_Actividad = entity.Tipo_de_Actividad;
result.Tipo_de_Actividad_Tipos_de_Actividades = entity.Tipo_de_Actividad_Tipos_de_Actividades;
result.Especialidad = entity.Especialidad;
result.Especialidad_Especialidades = entity.Especialidad_Especialidades;
result.Imparte = entity.Imparte;
result.Imparte_Spartan_User = entity.Imparte_Spartan_User;
result.Fecha = entity.Fecha;
result.Lugares_disponibles = entity.Lugares_disponibles;
result.Horarios_disponibles = entity.Horarios_disponibles;
result.Ubicacion = entity.Ubicacion;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage Detalle_Consulta_Actividades_Registro_EventoGenerateID()
        {
            Detalle_Consulta_Actividades_Registro_Evento varDetalle_Consulta_Actividades_Registro_Evento = new Detalle_Consulta_Actividades_Registro_Evento();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varDetalle_Consulta_Actividades_Registro_Evento));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_Detalle_Consulta_Actividades_Registro_EventoGenerateID", new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_Detalle_Consulta_Actividades_Registro_EventoGenerateID", new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Detalle_Consulta_Actividades_Registro_Evento varDetalle_Consulta_Actividades_Registro_Evento = this.service.GetByKey(id, false);
            bool result = false;
            if (varDetalle_Consulta_Actividades_Registro_Evento == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelDetalle_Consulta_Actividades_Registro_Evento", new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelDetalle_Consulta_Actividades_Registro_Evento", new JavaScriptSerializer().Serialize(varDetalle_Consulta_Actividades_Registro_Evento), result, ex.Message);
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
                var Detalle_Consulta_Actividades_Registro_EventoDataTable = new JavaScriptSerializer().Deserialize<List<Detalle_Consulta_Actividades_Registro_Evento>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Detalle_Consulta_Actividades_Registro_EventoDataTable, Configuration.Formatters.JsonFormatter);
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
                var Detalle_Consulta_Actividades_Registro_EventoResult = new JavaScriptSerializer().Deserialize<Detalle_Consulta_Actividades_Registro_Evento>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Detalle_Consulta_Actividades_Registro_EventoResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Detalle_Consulta_Actividades_Registro_Evento emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Detalle_Consulta_Actividades_Registro_Evento emp, string user, string password)
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

