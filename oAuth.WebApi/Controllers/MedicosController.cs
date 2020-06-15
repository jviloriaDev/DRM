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
using Spartane.Core.Classes.Medicos;
using Spartane.Services.Medicos;
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
    
    public partial class MedicosController : BaseApiController
    {
        #region Variables
        private IMedicosService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44379;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public MedicosController(IMedicosService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Medicos";
            
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
        public HttpResponseMessage Post(Medicos varMedicos)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varMedicos));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsMedicos" , new JavaScriptSerializer().Serialize(varMedicos), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsMedicos", new JavaScriptSerializer().Serialize(varMedicos), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsMedicos",new JavaScriptSerializer().Serialize(varMedicos), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Medicos varMedicos)
        {
            if (ModelState.IsValid && id == varMedicos.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varMedicos));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Medicos varMedicos_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varMedicos_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Medicos entity = this.service.ListaSelAll(1, 1, "Medicos.Folio='" + id.ToString() + "'", "").Medicoss.First();
            Medicos result = new Medicos();
			result.Folio = entity.Folio;
result.Fecha_de_Registro = entity.Fecha_de_Registro;
result.Hora_de_Registro = entity.Hora_de_Registro;
result.Usuario_que_Registra = entity.Usuario_que_Registra;
result.Usuario_que_Registra_Spartan_User = entity.Usuario_que_Registra_Spartan_User;
result.Titulo_Personal = entity.Titulo_Personal;
result.Titulo_Personal_Titulos_Personales = entity.Titulo_Personal_Titulos_Personales;
result.Nombres = entity.Nombres;
result.Apellido_Paterno = entity.Apellido_Paterno;
result.Apellido_Materno = entity.Apellido_Materno;
result.Nombre_Completo = entity.Nombre_Completo;
result.Tipo_de_Especialista = entity.Tipo_de_Especialista;
result.Tipo_de_Especialista_Tipos_de_Especialistas = entity.Tipo_de_Especialista_Tipos_de_Especialistas;
result.Foto = entity.Foto;
result.Foto_Spartane_File = entity.Foto_Spartane_File;
result.Nombre_de_usuario = entity.Nombre_de_usuario;
result.Usuario_Registrado = entity.Usuario_Registrado;
result.Usuario_Registrado_Spartan_User = entity.Usuario_Registrado_Spartan_User;
result.Email = entity.Email;
result.Celular = entity.Celular;
result.Fecha_de_nacimiento = entity.Fecha_de_nacimiento;
result.Pais_de_nacimiento = entity.Pais_de_nacimiento;
result.Pais_de_nacimiento_Pais = entity.Pais_de_nacimiento_Pais;
result.Entidad_de_nacimiento = entity.Entidad_de_nacimiento;
result.Entidad_de_nacimiento_Estado = entity.Entidad_de_nacimiento_Estado;
result.Sexo = entity.Sexo;
result.Sexo_Sexo = entity.Sexo_Sexo;
result.Email_institucional = entity.Email_institucional;
result.Estatus = entity.Estatus;
result.Estatus_Estatus = entity.Estatus_Estatus;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_de_Contacto(Medicos varMedicos_Datos_de_Contacto)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_de_Contacto(varMedicos_Datos_de_Contacto));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Datos_de_Contacto.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Datos_de_Contacto), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Datos_de_Contacto.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Datos_de_Contacto), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_de_Contacto(int id)
        {
            Medicos entity = this.service.ListaSelAll(1, 1, "Medicos.Folio='" + id.ToString() + "'", "").Medicoss.First();
            Medicos result = new Medicos();
			result.Folio = entity.Folio;
result.Email_ppal_publico = entity.Email_ppal_publico;
result.Email_ppal_publico_Respuesta_Logica = entity.Email_ppal_publico_Respuesta_Logica;
result.Email_de_contacto = entity.Email_de_contacto;
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
result.Telefonos = entity.Telefonos;
result.En_Hospital = entity.En_Hospital;
result.En_Hospital_Respuesta_Logica = entity.En_Hospital_Respuesta_Logica;
result.Nombre_del_Hospital = entity.Nombre_del_Hospital;
result.Piso_hospital = entity.Piso_hospital;
result.Numero_de_consultorio = entity.Numero_de_consultorio;
result.Se_ajusta_tabulador = entity.Se_ajusta_tabulador;
result.Se_ajusta_tabulador_Respuesta_Logica = entity.Se_ajusta_tabulador_Respuesta_Logica;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Profesionales(Medicos varMedicos_Datos_Profesionales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Profesionales(varMedicos_Datos_Profesionales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Datos_Profesionales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Datos_Profesionales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Datos_Profesionales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Datos_Profesionales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Profesionales(int id)
        {
            Medicos entity = this.service.ListaSelAll(1, 1, "Medicos.Folio='" + id.ToString() + "'", "").Medicoss.First();
            Medicos result = new Medicos();
			result.Folio = entity.Folio;
result.Profesion = entity.Profesion;
result.Profesion_Profesiones = entity.Profesion_Profesiones;
result.Especialidad = entity.Especialidad;
result.Especialidad_Especialidades = entity.Especialidad_Especialidades;
result.Resumen_Profesional = entity.Resumen_Profesional;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Fiscales(Medicos varMedicos_Datos_Fiscales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Fiscales(varMedicos_Datos_Fiscales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Datos_Fiscales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Datos_Fiscales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Datos_Fiscales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Datos_Fiscales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Fiscales(int id)
        {
            Medicos entity = this.service.ListaSelAll(1, 1, "Medicos.Folio='" + id.ToString() + "'", "").Medicoss.First();
            Medicos result = new Medicos();
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
result.Telefono = entity.Telefono;
result.Fax = entity.Fax;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Documentacion(Medicos varMedicos_Documentacion)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Documentacion(varMedicos_Documentacion));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Documentacion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Documentacion), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Documentacion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Documentacion), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Documentacion(int id)
        {
            Medicos entity = this.service.ListaSelAll(1, 1, "Medicos.Folio='" + id.ToString() + "'", "").Medicoss.First();
            Medicos result = new Medicos();
			result.Folio = entity.Folio;
result.Cedula_Fiscal_Documento = entity.Cedula_Fiscal_Documento;
result.Cedula_Fiscal_Documento_Spartane_File = entity.Cedula_Fiscal_Documento_Spartane_File;
result.Comprobante_de_Domicilio = entity.Comprobante_de_Domicilio;
result.Comprobante_de_Domicilio_Spartane_File = entity.Comprobante_de_Domicilio_Spartane_File;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Codigos_de_Referencia(Medicos varMedicos_Codigos_de_Referencia)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Codigos_de_Referencia(varMedicos_Codigos_de_Referencia));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Codigos_de_Referencia.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Codigos_de_Referencia), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Codigos_de_Referencia.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Codigos_de_Referencia), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Codigos_de_Referencia(int id)
        {
            Medicos entity = this.service.ListaSelAll(1, 1, "Medicos.Folio='" + id.ToString() + "'", "").Medicoss.First();
            Medicos result = new Medicos();
			result.Folio = entity.Folio;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Suscripcion_Red_de_Especialistas(Medicos varMedicos_Suscripcion_Red_de_Especialistas)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Suscripcion_Red_de_Especialistas(varMedicos_Suscripcion_Red_de_Especialistas));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Suscripcion_Red_de_Especialistas.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Suscripcion_Red_de_Especialistas), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Suscripcion_Red_de_Especialistas.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Suscripcion_Red_de_Especialistas), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Suscripcion_Red_de_Especialistas(int id)
        {
            Medicos entity = this.service.ListaSelAll(1, 1, "Medicos.Folio='" + id.ToString() + "'", "").Medicoss.First();
            Medicos result = new Medicos();
			result.Folio = entity.Folio;
result.Calificacion_Red_de_Medicos = entity.Calificacion_Red_de_Medicos;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Bancarios(Medicos varMedicos_Datos_Bancarios)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Bancarios(varMedicos_Datos_Bancarios));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Datos_Bancarios.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Datos_Bancarios), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Datos_Bancarios.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Datos_Bancarios), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Bancarios(int id)
        {
            Medicos entity = this.service.ListaSelAll(1, 1, "Medicos.Folio='" + id.ToString() + "'", "").Medicoss.First();
            Medicos result = new Medicos();
			result.Folio = entity.Folio;
result.Banco = entity.Banco;
result.Banco_Bancos = entity.Banco_Bancos;
result.CLABE_Interbancaria = entity.CLABE_Interbancaria;
result.Numero_de_Cuenta = entity.Numero_de_Cuenta;
result.Nombre_del_Titular = entity.Nombre_del_Titular;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Facturacion(Medicos varMedicos_Facturacion)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Facturacion(varMedicos_Facturacion));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Facturacion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Facturacion), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varMedicos_Facturacion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdMedicos", new JavaScriptSerializer().Serialize(varMedicos_Facturacion), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Facturacion(int id)
        {
            Medicos entity = this.service.ListaSelAll(1, 1, "Medicos.Folio='" + id.ToString() + "'", "").Medicoss.First();
            Medicos result = new Medicos();
			result.Folio = entity.Folio;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage MedicosGenerateID()
        {
            Medicos varMedicos = new Medicos();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varMedicos));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_MedicosGenerateID", new JavaScriptSerializer().Serialize(varMedicos), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_MedicosGenerateID", new JavaScriptSerializer().Serialize(varMedicos), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Medicos varMedicos = this.service.GetByKey(id, false);
            bool result = false;
            if (varMedicos == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelMedicos", new JavaScriptSerializer().Serialize(varMedicos), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelMedicos", new JavaScriptSerializer().Serialize(varMedicos), result, ex.Message);
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
                var MedicosDataTable = new JavaScriptSerializer().Deserialize<List<Medicos>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, MedicosDataTable, Configuration.Formatters.JsonFormatter);
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
                var MedicosResult = new JavaScriptSerializer().Deserialize<Medicos>(result);
                return Request.CreateResponse(HttpStatusCode.OK, MedicosResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Medicos emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Medicos emp, string user, string password)
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

