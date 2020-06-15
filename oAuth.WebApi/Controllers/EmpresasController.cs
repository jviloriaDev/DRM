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
using Spartane.Core.Classes.Empresas;
using Spartane.Services.Empresas;
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
    
    public partial class EmpresasController : BaseApiController
    {
        #region Variables
        private IEmpresasService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44282;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public EmpresasController(IEmpresasService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Empresas";
            
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
        public HttpResponseMessage Post(Empresas varEmpresas)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varEmpresas));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsEmpresas" , new JavaScriptSerializer().Serialize(varEmpresas), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsEmpresas", new JavaScriptSerializer().Serialize(varEmpresas), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsEmpresas",new JavaScriptSerializer().Serialize(varEmpresas), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Empresas varEmpresas)
        {
            if (ModelState.IsValid && id == varEmpresas.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varEmpresas));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Empresas varEmpresas_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varEmpresas_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEmpresas_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEmpresas_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Empresas entity = this.service.ListaSelAll(1, 1, "Empresas.Folio='" + id.ToString() + "'", "").Empresass.First();
            Empresas result = new Empresas();
			result.Folio = entity.Folio;
result.Fecha_de_Registro = entity.Fecha_de_Registro;
result.Hora_de_Registro = entity.Hora_de_Registro;
result.Usuario_que_Registra = entity.Usuario_que_Registra;
result.Usuario_que_Registra_Spartan_User = entity.Usuario_que_Registra_Spartan_User;
result.Nombre_de_la_Empresa = entity.Nombre_de_la_Empresa;
result.Tipo_de_Empresa = entity.Tipo_de_Empresa;
result.Tipo_de_Empresa_Tipos_de_Empresa = entity.Tipo_de_Empresa_Tipos_de_Empresa;
result.Email = entity.Email;
result.Telefono = entity.Telefono;
result.Calle = entity.Calle;
result.Numero_exterior = entity.Numero_exterior;
result.Numero_interior = entity.Numero_interior;
result.Colonia = entity.Colonia;
result.CP = entity.CP;
result.Ciudad = entity.Ciudad;
result.Estado = entity.Estado;
result.Estado_Estado = entity.Estado_Estado;
result.Pais = entity.Pais;
result.Pais_Pais = entity.Pais_Pais;
result.Estatus = entity.Estatus;
result.Estatus_Estatus = entity.Estatus_Estatus;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_de_Contacto(Empresas varEmpresas_Datos_de_Contacto)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_de_Contacto(varEmpresas_Datos_de_Contacto));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEmpresas_Datos_de_Contacto.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas_Datos_de_Contacto), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEmpresas_Datos_de_Contacto.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas_Datos_de_Contacto), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_de_Contacto(int id)
        {
            Empresas entity = this.service.ListaSelAll(1, 1, "Empresas.Folio='" + id.ToString() + "'", "").Empresass.First();
            Empresas result = new Empresas();
			result.Folio = entity.Folio;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Fiscales(Empresas varEmpresas_Datos_Fiscales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Fiscales(varEmpresas_Datos_Fiscales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEmpresas_Datos_Fiscales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas_Datos_Fiscales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEmpresas_Datos_Fiscales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas_Datos_Fiscales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Fiscales(int id)
        {
            Empresas entity = this.service.ListaSelAll(1, 1, "Empresas.Folio='" + id.ToString() + "'", "").Empresass.First();
            Empresas result = new Empresas();
			result.Folio = entity.Folio;
result.Regimen_Fiscal = entity.Regimen_Fiscal;
result.Regimen_Fiscal_Regimenes_Fiscales = entity.Regimen_Fiscal_Regimenes_Fiscales;
result.Nombre_o_Razon_Social = entity.Nombre_o_Razon_Social;
result.RFC = entity.RFC;
result.Calle_Fiscal = entity.Calle_Fiscal;
result.Numero_exterior_Fiscal = entity.Numero_exterior_Fiscal;
result.Numero_interior_Fiscal = entity.Numero_interior_Fiscal;
result.Colonia_Fiscal = entity.Colonia_Fiscal;
result.CP_Fiscal = entity.CP_Fiscal;
result.Ciudad_Fiscal = entity.Ciudad_Fiscal;
result.Estado_Fiscal = entity.Estado_Fiscal;
result.Estado_Fiscal_Estado = entity.Estado_Fiscal_Estado;
result.Pais_Fiscal = entity.Pais_Fiscal;
result.Pais_Fiscal_Pais = entity.Pais_Fiscal_Pais;
result.Telefono_Fiscal = entity.Telefono_Fiscal;
result.Fax = entity.Fax;
result.Nombres_del_Representante_Legal = entity.Nombres_del_Representante_Legal;
result.Apellido_Paterno_del_Representante_Legal = entity.Apellido_Paterno_del_Representante_Legal;
result.Apellido_Materno_del_Representante_Legal = entity.Apellido_Materno_del_Representante_Legal;
result.Nombre_Completo_del_Representante_Legal = entity.Nombre_Completo_del_Representante_Legal;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Suscripcion(Empresas varEmpresas_Suscripcion)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Suscripcion(varEmpresas_Suscripcion));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEmpresas_Suscripcion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas_Suscripcion), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEmpresas_Suscripcion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas_Suscripcion), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Suscripcion(int id)
        {
            Empresas entity = this.service.ListaSelAll(1, 1, "Empresas.Folio='" + id.ToString() + "'", "").Empresass.First();
            Empresas result = new Empresas();
			result.Folio = entity.Folio;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Documentacion(Empresas varEmpresas_Documentacion)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Documentacion(varEmpresas_Documentacion));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEmpresas_Documentacion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas_Documentacion), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varEmpresas_Documentacion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdEmpresas", new JavaScriptSerializer().Serialize(varEmpresas_Documentacion), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Documentacion(int id)
        {
            Empresas entity = this.service.ListaSelAll(1, 1, "Empresas.Folio='" + id.ToString() + "'", "").Empresass.First();
            Empresas result = new Empresas();
			result.Folio = entity.Folio;
result.Cedula_Fiscal = entity.Cedula_Fiscal;
result.Cedula_Fiscal_Spartane_File = entity.Cedula_Fiscal_Spartane_File;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage EmpresasGenerateID()
        {
            Empresas varEmpresas = new Empresas();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varEmpresas));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_EmpresasGenerateID", new JavaScriptSerializer().Serialize(varEmpresas), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_EmpresasGenerateID", new JavaScriptSerializer().Serialize(varEmpresas), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Empresas varEmpresas = this.service.GetByKey(id, false);
            bool result = false;
            if (varEmpresas == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelEmpresas", new JavaScriptSerializer().Serialize(varEmpresas), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelEmpresas", new JavaScriptSerializer().Serialize(varEmpresas), result, ex.Message);
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
                var EmpresasDataTable = new JavaScriptSerializer().Deserialize<List<Empresas>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, EmpresasDataTable, Configuration.Formatters.JsonFormatter);
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
                var EmpresasResult = new JavaScriptSerializer().Deserialize<Empresas>(result);
                return Request.CreateResponse(HttpStatusCode.OK, EmpresasResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Empresas emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Empresas emp, string user, string password)
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

