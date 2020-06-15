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
using Spartane.Core.Classes.Detalle_Registro_en_Actividad_Evento;
using Spartane.Services.Detalle_Registro_en_Actividad_Evento;
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
    
    public partial class Detalle_Registro_en_Actividad_EventoController : BaseApiController
    {
        #region Variables
        private IDetalle_Registro_en_Actividad_EventoService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44441;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Detalle_Registro_en_Actividad_EventoController(IDetalle_Registro_en_Actividad_EventoService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Detalle_Registro_en_Actividad_Evento";
            
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
        public HttpResponseMessage Post(Detalle_Registro_en_Actividad_Evento varDetalle_Registro_en_Actividad_Evento)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varDetalle_Registro_en_Actividad_Evento));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsDetalle_Registro_en_Actividad_Evento" , new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsDetalle_Registro_en_Actividad_Evento", new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsDetalle_Registro_en_Actividad_Evento",new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Detalle_Registro_en_Actividad_Evento varDetalle_Registro_en_Actividad_Evento)
        {
            if (ModelState.IsValid && id == varDetalle_Registro_en_Actividad_Evento.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varDetalle_Registro_en_Actividad_Evento));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdDetalle_Registro_en_Actividad_Evento", new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdDetalle_Registro_en_Actividad_Evento", new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdDetalle_Registro_en_Actividad_Evento", new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Detalle_Registro_en_Actividad_Evento varDetalle_Registro_en_Actividad_Evento_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varDetalle_Registro_en_Actividad_Evento_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varDetalle_Registro_en_Actividad_Evento_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdDetalle_Registro_en_Actividad_Evento", new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varDetalle_Registro_en_Actividad_Evento_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdDetalle_Registro_en_Actividad_Evento", new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Detalle_Registro_en_Actividad_Evento entity = this.service.ListaSelAll(1, 1, "Detalle_Registro_en_Actividad_Evento.Folio='" + id.ToString() + "'", "").Detalle_Registro_en_Actividad_Eventos.First();
            Detalle_Registro_en_Actividad_Evento result = new Detalle_Registro_en_Actividad_Evento();
			result.Folio = entity.Folio;
result.Actividad = entity.Actividad;
result.Actividad_Detalle_Actividades_Evento = entity.Actividad_Detalle_Actividades_Evento;
result.Fecha = entity.Fecha;
result.Horario = entity.Horario;
result.Es_para_un_familiar = entity.Es_para_un_familiar;
result.Numero_de_Empleado = entity.Numero_de_Empleado;
result.Nombres = entity.Nombres;
result.Apellido_Paterno = entity.Apellido_Paterno;
result.Apellido_Materno = entity.Apellido_Materno;
result.Nombre_Completo = entity.Nombre_Completo;
result.Parentesco = entity.Parentesco;
result.Parentesco_Parentescos_Empleados = entity.Parentesco_Parentescos_Empleados;
result.Sexo = entity.Sexo;
result.Sexo_Sexo = entity.Sexo_Sexo;
result.Fecha_de_nacimiento = entity.Fecha_de_nacimiento;
result.Estatus_de_la_Reservacion = entity.Estatus_de_la_Reservacion;
result.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad = entity.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad;
result.Codigo_Reservacion = entity.Codigo_Reservacion;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage Detalle_Registro_en_Actividad_EventoGenerateID()
        {
            Detalle_Registro_en_Actividad_Evento varDetalle_Registro_en_Actividad_Evento = new Detalle_Registro_en_Actividad_Evento();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varDetalle_Registro_en_Actividad_Evento));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_Detalle_Registro_en_Actividad_EventoGenerateID", new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_Detalle_Registro_en_Actividad_EventoGenerateID", new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Detalle_Registro_en_Actividad_Evento varDetalle_Registro_en_Actividad_Evento = this.service.GetByKey(id, false);
            bool result = false;
            if (varDetalle_Registro_en_Actividad_Evento == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelDetalle_Registro_en_Actividad_Evento", new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelDetalle_Registro_en_Actividad_Evento", new JavaScriptSerializer().Serialize(varDetalle_Registro_en_Actividad_Evento), result, ex.Message);
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
                var Detalle_Registro_en_Actividad_EventoDataTable = new JavaScriptSerializer().Deserialize<List<Detalle_Registro_en_Actividad_Evento>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Detalle_Registro_en_Actividad_EventoDataTable, Configuration.Formatters.JsonFormatter);
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
                var Detalle_Registro_en_Actividad_EventoResult = new JavaScriptSerializer().Deserialize<Detalle_Registro_en_Actividad_Evento>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Detalle_Registro_en_Actividad_EventoResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Detalle_Registro_en_Actividad_Evento emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Detalle_Registro_en_Actividad_Evento emp, string user, string password)
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

