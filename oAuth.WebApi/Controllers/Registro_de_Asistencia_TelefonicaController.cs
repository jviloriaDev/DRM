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
using Spartane.Core.Classes.Registro_de_Asistencia_Telefonica;
using Spartane.Services.Registro_de_Asistencia_Telefonica;
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
    
    public partial class Registro_de_Asistencia_TelefonicaController : BaseApiController
    {
        #region Variables
        private IRegistro_de_Asistencia_TelefonicaService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44458;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Registro_de_Asistencia_TelefonicaController(IRegistro_de_Asistencia_TelefonicaService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Registro_de_Asistencia_Telefonica";
            
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
        public HttpResponseMessage Post(Registro_de_Asistencia_Telefonica varRegistro_de_Asistencia_Telefonica)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varRegistro_de_Asistencia_Telefonica));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsRegistro_de_Asistencia_Telefonica" , new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsRegistro_de_Asistencia_Telefonica", new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsRegistro_de_Asistencia_Telefonica",new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Registro_de_Asistencia_Telefonica varRegistro_de_Asistencia_Telefonica)
        {
            if (ModelState.IsValid && id == varRegistro_de_Asistencia_Telefonica.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varRegistro_de_Asistencia_Telefonica));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_de_Asistencia_Telefonica", new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_de_Asistencia_Telefonica", new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_de_Asistencia_Telefonica", new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Registro_de_Asistencia_Telefonica varRegistro_de_Asistencia_Telefonica_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varRegistro_de_Asistencia_Telefonica_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varRegistro_de_Asistencia_Telefonica_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_de_Asistencia_Telefonica", new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varRegistro_de_Asistencia_Telefonica_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_de_Asistencia_Telefonica", new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Registro_de_Asistencia_Telefonica entity = this.service.ListaSelAll(1, 1, "Registro_de_Asistencia_Telefonica.Folio='" + id.ToString() + "'", "").Registro_de_Asistencia_Telefonicas.First();
            Registro_de_Asistencia_Telefonica result = new Registro_de_Asistencia_Telefonica();
			result.Folio = entity.Folio;
result.Fecha_de_llamada = entity.Fecha_de_llamada;
result.Hora_de_llamada = entity.Hora_de_llamada;
result.Usuario_que_llama = entity.Usuario_que_llama;
result.Usuario_que_llama_Spartan_User = entity.Usuario_que_llama_Spartan_User;
result.Dispositivo = entity.Dispositivo;
result.Nombre_Paciente = entity.Nombre_Paciente;
result.Nombre_Paciente_Pacientes = entity.Nombre_Paciente_Pacientes;
result.Suscripcion = entity.Suscripcion;
result.Suscripcion_Planes_de_Suscripcion = entity.Suscripcion_Planes_de_Suscripcion;
result.Numero_telefonico_del_Paciente = entity.Numero_telefonico_del_Paciente;
result.Correo_del_Paciente = entity.Correo_del_Paciente;
result.Telefono_de_Asistencia_marcado = entity.Telefono_de_Asistencia_marcado;
result.Hora_inicio_de_la_Llamada = entity.Hora_inicio_de_la_Llamada;
result.Hora_fin_de_la_Llamada = entity.Hora_fin_de_la_Llamada;
result.Duracion_minutos = entity.Duracion_minutos;
result.Asunto_de_la_Llamada = entity.Asunto_de_la_Llamada;
result.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica = entity.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica;
result.Atendio = entity.Atendio;
result.Atendio_Spartan_User = entity.Atendio_Spartan_User;
result.Comentarios = entity.Comentarios;
result.Estatus = entity.Estatus;
result.Estatus_Estatus_Llamadas = entity.Estatus_Estatus_Llamadas;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage Registro_de_Asistencia_TelefonicaGenerateID()
        {
            Registro_de_Asistencia_Telefonica varRegistro_de_Asistencia_Telefonica = new Registro_de_Asistencia_Telefonica();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varRegistro_de_Asistencia_Telefonica));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_Registro_de_Asistencia_TelefonicaGenerateID", new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_Registro_de_Asistencia_TelefonicaGenerateID", new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Registro_de_Asistencia_Telefonica varRegistro_de_Asistencia_Telefonica = this.service.GetByKey(id, false);
            bool result = false;
            if (varRegistro_de_Asistencia_Telefonica == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelRegistro_de_Asistencia_Telefonica", new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelRegistro_de_Asistencia_Telefonica", new JavaScriptSerializer().Serialize(varRegistro_de_Asistencia_Telefonica), result, ex.Message);
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
                var Registro_de_Asistencia_TelefonicaDataTable = new JavaScriptSerializer().Deserialize<List<Registro_de_Asistencia_Telefonica>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Registro_de_Asistencia_TelefonicaDataTable, Configuration.Formatters.JsonFormatter);
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
                var Registro_de_Asistencia_TelefonicaResult = new JavaScriptSerializer().Deserialize<Registro_de_Asistencia_Telefonica>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Registro_de_Asistencia_TelefonicaResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Registro_de_Asistencia_Telefonica emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Registro_de_Asistencia_Telefonica emp, string user, string password)
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

