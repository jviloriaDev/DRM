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
using Spartane.Core.Classes.Consultas;
using Spartane.Services.Consultas;
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
    
    public partial class ConsultasController : BaseApiController
    {
        #region Variables
        private IConsultasService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44352;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public ConsultasController(IConsultasService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Consultas";
            
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
        public HttpResponseMessage Post(Consultas varConsultas)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varConsultas));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsConsultas" , new JavaScriptSerializer().Serialize(varConsultas), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsConsultas", new JavaScriptSerializer().Serialize(varConsultas), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsConsultas",new JavaScriptSerializer().Serialize(varConsultas), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Consultas varConsultas)
        {
            if (ModelState.IsValid && id == varConsultas.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varConsultas));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConsultas", new JavaScriptSerializer().Serialize(varConsultas), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConsultas", new JavaScriptSerializer().Serialize(varConsultas), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConsultas", new JavaScriptSerializer().Serialize(varConsultas), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Consultas varConsultas_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varConsultas_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varConsultas_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConsultas", new JavaScriptSerializer().Serialize(varConsultas_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varConsultas_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConsultas", new JavaScriptSerializer().Serialize(varConsultas_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Consultas entity = this.service.ListaSelAll(1, 1, "Consultas.Folio='" + id.ToString() + "'", "").Consultass.First();
            Consultas result = new Consultas();
			result.Folio = entity.Folio;
result.Fecha_de_Registo = entity.Fecha_de_Registo;
result.Hora_de_Registro = entity.Hora_de_Registro;
result.Usuario_que_Registra = entity.Usuario_que_Registra;
result.Usuario_que_Registra_Spartan_User = entity.Usuario_que_Registra_Spartan_User;
result.Fecha_Programada = entity.Fecha_Programada;
result.Paciente = entity.Paciente;
result.Paciente_Pacientes = entity.Paciente_Pacientes;
result.Edad = entity.Edad;
result.Nombre_del_padre = entity.Nombre_del_padre;
result.Sexo = entity.Sexo;
result.Sexo_Sexo = entity.Sexo_Sexo;
result.Email = entity.Email;
result.Objetivo = entity.Objetivo;
result.Objetivo_Objetivos = entity.Objetivo_Objetivos;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Mediciones(Consultas varConsultas_Mediciones)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Mediciones(varConsultas_Mediciones));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varConsultas_Mediciones.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConsultas", new JavaScriptSerializer().Serialize(varConsultas_Mediciones), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varConsultas_Mediciones.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConsultas", new JavaScriptSerializer().Serialize(varConsultas_Mediciones), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Mediciones(int id)
        {
            Consultas entity = this.service.ListaSelAll(1, 1, "Consultas.Folio='" + id.ToString() + "'", "").Consultass.First();
            Consultas result = new Consultas();
			result.Folio = entity.Folio;
result.Frecuencia_Cardiaca = entity.Frecuencia_Cardiaca;
result.Presion_sistolica = entity.Presion_sistolica;
result.Presion_diastolica = entity.Presion_diastolica;
result.Peso_actual = entity.Peso_actual;
result.Estatura = entity.Estatura;
result.Circunferencia_de_cintura_cm = entity.Circunferencia_de_cintura_cm;
result.Circunferencia_de_cadera_cm = entity.Circunferencia_de_cadera_cm;
result.Edad_Metabolica = entity.Edad_Metabolica;
result.Agua_corporal = entity.Agua_corporal;
result.Grasa_Visceral = entity.Grasa_Visceral;
result.Grasa_Corporal = entity.Grasa_Corporal;
result.Grasa_Corporal_kg = entity.Grasa_Corporal_kg;
result.Masa_Muscular_kg = entity.Masa_Muscular_kg;
result.Semana_de_gestacion = entity.Semana_de_gestacion;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Resultados(Consultas varConsultas_Resultados)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Resultados(varConsultas_Resultados));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varConsultas_Resultados.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConsultas", new JavaScriptSerializer().Serialize(varConsultas_Resultados), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varConsultas_Resultados.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdConsultas", new JavaScriptSerializer().Serialize(varConsultas_Resultados), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Resultados(int id)
        {
            Consultas entity = this.service.ListaSelAll(1, 1, "Consultas.Folio='" + id.ToString() + "'", "").Consultass.First();
            Consultas result = new Consultas();
			result.Folio = entity.Folio;
result.IMC = entity.IMC;
result.IMC_Pediatria = entity.IMC_Pediatria;
result.IMC_Pediatria_Interpretacion_IMC = entity.IMC_Pediatria_Interpretacion_IMC;
result.Interpretacion_IMC = entity.Interpretacion_IMC;
result.Interpretacion_IMC_Interpretacion_IMC = entity.Interpretacion_IMC_Interpretacion_IMC;
result.Consumo_de_agua_resultado = entity.Consumo_de_agua_resultado;
result.Interpretacion_agua = entity.Interpretacion_agua;
result.Interpretacion_agua_Interpretacion_consumo_de_agua = entity.Interpretacion_agua_Interpretacion_consumo_de_agua;
result.Frecuencia_cardiaca_en_Esfuerzo = entity.Frecuencia_cardiaca_en_Esfuerzo;
result.Interpretacion_frecuencia = entity.Interpretacion_frecuencia;
result.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo = entity.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
result.Indice_cintura_cadera = entity.Indice_cintura_cadera;
result.Interpretacion_indice = entity.Interpretacion_indice;
result.Interpretacion_indice_Interpretacion_indice_cintura__cadera = entity.Interpretacion_indice_Interpretacion_indice_cintura__cadera;
result.Dificultad_de_Rutina_de_Ejercicios = entity.Dificultad_de_Rutina_de_Ejercicios;
result.Interpretacion_dificultad = entity.Interpretacion_dificultad;
result.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios = entity.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
result.Calorias = entity.Calorias;
result.Interpretacion_calorias = entity.Interpretacion_calorias;
result.Interpretacion_calorias_Interpretacion_Calorias = entity.Interpretacion_calorias_Interpretacion_Calorias;
result.Observaciones = entity.Observaciones;
result.Fecha_siguiente_Consulta = entity.Fecha_siguiente_Consulta;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage ConsultasGenerateID()
        {
            Consultas varConsultas = new Consultas();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varConsultas));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_ConsultasGenerateID", new JavaScriptSerializer().Serialize(varConsultas), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_ConsultasGenerateID", new JavaScriptSerializer().Serialize(varConsultas), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Consultas varConsultas = this.service.GetByKey(id, false);
            bool result = false;
            if (varConsultas == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelConsultas", new JavaScriptSerializer().Serialize(varConsultas), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelConsultas", new JavaScriptSerializer().Serialize(varConsultas), result, ex.Message);
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
                var ConsultasDataTable = new JavaScriptSerializer().Deserialize<List<Consultas>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, ConsultasDataTable, Configuration.Formatters.JsonFormatter);
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
                var ConsultasResult = new JavaScriptSerializer().Deserialize<Consultas>(result);
                return Request.CreateResponse(HttpStatusCode.OK, ConsultasResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Consultas emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Consultas emp, string user, string password)
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

