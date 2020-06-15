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
using Spartane.Core.Classes.Solicitud_de_Cita_con_Especialista;
using Spartane.Services.Solicitud_de_Cita_con_Especialista;
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
    
    public partial class Solicitud_de_Cita_con_EspecialistaController : BaseApiController
    {
        #region Variables
        private ISolicitud_de_Cita_con_EspecialistaService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44454;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Solicitud_de_Cita_con_EspecialistaController(ISolicitud_de_Cita_con_EspecialistaService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Solicitud_de_Cita_con_Especialista";
            
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
        public HttpResponseMessage Post(Solicitud_de_Cita_con_Especialista varSolicitud_de_Cita_con_Especialista)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varSolicitud_de_Cita_con_Especialista));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsSolicitud_de_Cita_con_Especialista" , new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsSolicitud_de_Cita_con_Especialista", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsSolicitud_de_Cita_con_Especialista",new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Solicitud_de_Cita_con_Especialista varSolicitud_de_Cita_con_Especialista)
        {
            if (ModelState.IsValid && id == varSolicitud_de_Cita_con_Especialista.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varSolicitud_de_Cita_con_Especialista));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Cita_con_Especialista", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Cita_con_Especialista", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Cita_con_Especialista", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Solicitud_de_Cita_con_Especialista varSolicitud_de_Cita_con_Especialista_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varSolicitud_de_Cita_con_Especialista_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Cita_con_Especialista_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Cita_con_Especialista", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Cita_con_Especialista_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Cita_con_Especialista", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Solicitud_de_Cita_con_Especialista entity = this.service.ListaSelAll(1, 1, "Solicitud_de_Cita_con_Especialista.Folio='" + id.ToString() + "'", "").Solicitud_de_Cita_con_Especialistas.First();
            Solicitud_de_Cita_con_Especialista result = new Solicitud_de_Cita_con_Especialista();
			result.Folio = entity.Folio;
result.Fecha_de_solicitud = entity.Fecha_de_solicitud;
result.Hora_de_solicitud = entity.Hora_de_solicitud;
result.Usuario_que_solicita = entity.Usuario_que_solicita;
result.Usuario_que_solicita_Spartan_User = entity.Usuario_que_solicita_Spartan_User;
result.Nombre_Completo = entity.Nombre_Completo;
result.Correo_del_Paciente = entity.Correo_del_Paciente;
result.Celular_del_Paciente = entity.Celular_del_Paciente;
result.Especialista = entity.Especialista;
result.Especialista_Medicos = entity.Especialista_Medicos;
result.Correo_del_Especialista = entity.Correo_del_Especialista;
result.Correo_enviado = entity.Correo_enviado;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Solicitud(Solicitud_de_Cita_con_Especialista varSolicitud_de_Cita_con_Especialista_Solicitud)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Solicitud(varSolicitud_de_Cita_con_Especialista_Solicitud));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Cita_con_Especialista_Solicitud.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Cita_con_Especialista", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista_Solicitud), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varSolicitud_de_Cita_con_Especialista_Solicitud.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdSolicitud_de_Cita_con_Especialista", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista_Solicitud), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Solicitud(int id)
        {
            Solicitud_de_Cita_con_Especialista entity = this.service.ListaSelAll(1, 1, "Solicitud_de_Cita_con_Especialista.Folio='" + id.ToString() + "'", "").Solicitud_de_Cita_con_Especialistas.First();
            Solicitud_de_Cita_con_Especialista result = new Solicitud_de_Cita_con_Especialista();
			result.Folio = entity.Folio;
result.Fecha_de_Retroalimentacion = entity.Fecha_de_Retroalimentacion;
result.Hora_de_Retroalimentacion = entity.Hora_de_Retroalimentacion;
result.Asististe_a_tu_cita = entity.Asististe_a_tu_cita;
result.Asististe_a_tu_cita_Respuesta_Logica = entity.Asististe_a_tu_cita_Respuesta_Logica;
result.Calificacion_Especialista = entity.Calificacion_Especialista;
result.Calificacion_Especialista_Calificacion = entity.Calificacion_Especialista_Calificacion;
result.Motivo_no_concreto_cita = entity.Motivo_no_concreto_cita;
result.Motivo_no_concreto_cita_Motivos = entity.Motivo_no_concreto_cita_Motivos;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage Solicitud_de_Cita_con_EspecialistaGenerateID()
        {
            Solicitud_de_Cita_con_Especialista varSolicitud_de_Cita_con_Especialista = new Solicitud_de_Cita_con_Especialista();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varSolicitud_de_Cita_con_Especialista));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_Solicitud_de_Cita_con_EspecialistaGenerateID", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_Solicitud_de_Cita_con_EspecialistaGenerateID", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Solicitud_de_Cita_con_Especialista varSolicitud_de_Cita_con_Especialista = this.service.GetByKey(id, false);
            bool result = false;
            if (varSolicitud_de_Cita_con_Especialista == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelSolicitud_de_Cita_con_Especialista", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelSolicitud_de_Cita_con_Especialista", new JavaScriptSerializer().Serialize(varSolicitud_de_Cita_con_Especialista), result, ex.Message);
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
                var Solicitud_de_Cita_con_EspecialistaDataTable = new JavaScriptSerializer().Deserialize<List<Solicitud_de_Cita_con_Especialista>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Solicitud_de_Cita_con_EspecialistaDataTable, Configuration.Formatters.JsonFormatter);
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
                var Solicitud_de_Cita_con_EspecialistaResult = new JavaScriptSerializer().Deserialize<Solicitud_de_Cita_con_Especialista>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Solicitud_de_Cita_con_EspecialistaResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Solicitud_de_Cita_con_Especialista emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Solicitud_de_Cita_con_Especialista emp, string user, string password)
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

