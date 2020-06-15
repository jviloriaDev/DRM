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
using Spartane.Core.Classes.Proveedores;
using Spartane.Services.Proveedores;
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
    
    public partial class ProveedoresController : BaseApiController
    {
        #region Variables
        private IProveedoresService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44591;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public ProveedoresController(IProveedoresService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Proveedores";
            
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
        public HttpResponseMessage Post(Proveedores varProveedores)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varProveedores));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsProveedores" , new JavaScriptSerializer().Serialize(varProveedores), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsProveedores", new JavaScriptSerializer().Serialize(varProveedores), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsProveedores",new JavaScriptSerializer().Serialize(varProveedores), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Proveedores varProveedores)
        {
            if (ModelState.IsValid && id == varProveedores.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varProveedores));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdProveedores", new JavaScriptSerializer().Serialize(varProveedores), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdProveedores", new JavaScriptSerializer().Serialize(varProveedores), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdProveedores", new JavaScriptSerializer().Serialize(varProveedores), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Proveedores varProveedores_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varProveedores_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varProveedores_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdProveedores", new JavaScriptSerializer().Serialize(varProveedores_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varProveedores_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdProveedores", new JavaScriptSerializer().Serialize(varProveedores_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Proveedores entity = this.service.ListaSelAll(1, 1, "Proveedores.Folio='" + id.ToString() + "'", "").Proveedoress.First();
            Proveedores result = new Proveedores();
			result.Folio = entity.Folio;
result.Fecha_de_Registro = entity.Fecha_de_Registro;
result.Hora_de_Registro = entity.Hora_de_Registro;
result.Usuario_que_Registra = entity.Usuario_que_Registra;
result.Usuario_que_Registra_Spartan_User = entity.Usuario_que_Registra_Spartan_User;
result.Nombre_del_Proveedor = entity.Nombre_del_Proveedor;
result.Tipo_de_Proveedor = entity.Tipo_de_Proveedor;
result.Tipo_de_Proveedor_Tipo_de_proveedor = entity.Tipo_de_Proveedor_Tipo_de_proveedor;
result.Estatus = entity.Estatus;
result.Estatus_Estatus = entity.Estatus_Estatus;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_de_Contacto(Proveedores varProveedores_Datos_de_Contacto)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_de_Contacto(varProveedores_Datos_de_Contacto));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varProveedores_Datos_de_Contacto.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdProveedores", new JavaScriptSerializer().Serialize(varProveedores_Datos_de_Contacto), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varProveedores_Datos_de_Contacto.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdProveedores", new JavaScriptSerializer().Serialize(varProveedores_Datos_de_Contacto), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_de_Contacto(int id)
        {
            Proveedores entity = this.service.ListaSelAll(1, 1, "Proveedores.Folio='" + id.ToString() + "'", "").Proveedoress.First();
            Proveedores result = new Proveedores();
			result.Folio = entity.Folio;
result.Nombres = entity.Nombres;
result.Apellido_Paterno = entity.Apellido_Paterno;
result.Apellido_Materno = entity.Apellido_Materno;
result.Nombre_Completo = entity.Nombre_Completo;
result.Nombre_de_Usuario = entity.Nombre_de_Usuario;
result.Usuario_Registrado = entity.Usuario_Registrado;
result.Usuario_Registrado_Spartan_User = entity.Usuario_Registrado_Spartan_User;
result.Email = entity.Email;
result.Celular = entity.Celular;
result.Fecha_de_Nacimiento = entity.Fecha_de_Nacimiento;
result.Pais_de_nacimiento = entity.Pais_de_nacimiento;
result.Pais_de_nacimiento_Pais = entity.Pais_de_nacimiento_Pais;
result.Entidad_de_nacimiento = entity.Entidad_de_nacimiento;
result.Entidad_de_nacimiento_Estado = entity.Entidad_de_nacimiento_Estado;
result.Sexo = entity.Sexo;
result.Sexo_Sexo = entity.Sexo_Sexo;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Red_de_Proveedores(Proveedores varProveedores_Red_de_Proveedores)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Red_de_Proveedores(varProveedores_Red_de_Proveedores));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varProveedores_Red_de_Proveedores.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdProveedores", new JavaScriptSerializer().Serialize(varProveedores_Red_de_Proveedores), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varProveedores_Red_de_Proveedores.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdProveedores", new JavaScriptSerializer().Serialize(varProveedores_Red_de_Proveedores), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Red_de_Proveedores(int id)
        {
            Proveedores entity = this.service.ListaSelAll(1, 1, "Proveedores.Folio='" + id.ToString() + "'", "").Proveedoress.First();
            Proveedores result = new Proveedores();
			result.Folio = entity.Folio;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Fiscales(Proveedores varProveedores_Datos_Fiscales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Fiscales(varProveedores_Datos_Fiscales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varProveedores_Datos_Fiscales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdProveedores", new JavaScriptSerializer().Serialize(varProveedores_Datos_Fiscales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varProveedores_Datos_Fiscales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdProveedores", new JavaScriptSerializer().Serialize(varProveedores_Datos_Fiscales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Fiscales(int id)
        {
            Proveedores entity = this.service.ListaSelAll(1, 1, "Proveedores.Folio='" + id.ToString() + "'", "").Proveedoress.First();
            Proveedores result = new Proveedores();
			result.Folio = entity.Folio;
result.Regimen_Fiscal = entity.Regimen_Fiscal;
result.Regimen_Fiscal_Regimenes_Fiscales = entity.Regimen_Fiscal_Regimenes_Fiscales;
result.Nombre_o_Razon_Social = entity.Nombre_o_Razon_Social;
result.RFC = entity.RFC;
result.Calle_Fiscal = entity.Calle_Fiscal;
result.Numero_exterior_Fiscal = entity.Numero_exterior_Fiscal;
result.Numero_interior_Fiscal = entity.Numero_interior_Fiscal;
result.Colonia_Fiscal = entity.Colonia_Fiscal;
result.C_P__Fiscal = entity.C_P__Fiscal;
result.Ciudad_Fiscal = entity.Ciudad_Fiscal;
result.Estado_Fiscal = entity.Estado_Fiscal;
result.Estado_Fiscal_Estado = entity.Estado_Fiscal_Estado;
result.Pais_Fiscal = entity.Pais_Fiscal;
result.Pais_Fiscal_Pais = entity.Pais_Fiscal_Pais;
result.Telefono = entity.Telefono;
result.Fax = entity.Fax;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage ProveedoresGenerateID()
        {
            Proveedores varProveedores = new Proveedores();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varProveedores));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_ProveedoresGenerateID", new JavaScriptSerializer().Serialize(varProveedores), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_ProveedoresGenerateID", new JavaScriptSerializer().Serialize(varProveedores), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Proveedores varProveedores = this.service.GetByKey(id, false);
            bool result = false;
            if (varProveedores == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelProveedores", new JavaScriptSerializer().Serialize(varProveedores), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelProveedores", new JavaScriptSerializer().Serialize(varProveedores), result, ex.Message);
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
                var ProveedoresDataTable = new JavaScriptSerializer().Deserialize<List<Proveedores>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, ProveedoresDataTable, Configuration.Formatters.JsonFormatter);
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
                var ProveedoresResult = new JavaScriptSerializer().Deserialize<Proveedores>(result);
                return Request.CreateResponse(HttpStatusCode.OK, ProveedoresResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Proveedores emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Proveedores emp, string user, string password)
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

