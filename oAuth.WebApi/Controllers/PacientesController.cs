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
using Spartane.Core.Classes.Pacientes;
using Spartane.Services.Pacientes;
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
    
    public partial class PacientesController : BaseApiController
    {
        #region Variables
        private IPacientesService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 44337;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public PacientesController(IPacientesService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Pacientes";
            
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
        public HttpResponseMessage Post(Pacientes varPacientes)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varPacientes));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsPacientes" , new JavaScriptSerializer().Serialize(varPacientes), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsPacientes", new JavaScriptSerializer().Serialize(varPacientes), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsPacientes",new JavaScriptSerializer().Serialize(varPacientes), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Pacientes varPacientes)
        {
            if (ModelState.IsValid && id == varPacientes.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varPacientes));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Pacientes varPacientes_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varPacientes_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Pacientes entity = this.service.ListaSelAll(1, 1, "Pacientes.Folio='" + id.ToString() + "'", "").Pacientess.First();
            Pacientes result = new Pacientes();
			result.Folio = entity.Folio;
result.Fecha_de_Registro = entity.Fecha_de_Registro;
result.Hora_de_Registro = entity.Hora_de_Registro;
result.Usuario_que_Registra = entity.Usuario_que_Registra;
result.Usuario_que_Registra_Spartan_User = entity.Usuario_que_Registra_Spartan_User;
result.Tipo_de_Registro = entity.Tipo_de_Registro;
result.Tipo_de_Registro_Tipo_de_Registro = entity.Tipo_de_Registro_Tipo_de_Registro;
result.Tipo_de_Paciente = entity.Tipo_de_Paciente;
result.Tipo_de_Paciente_Tipo_Paciente = entity.Tipo_de_Paciente_Tipo_Paciente;
result.Usuario_Registrado = entity.Usuario_Registrado;
result.Usuario_Registrado_Spartan_User = entity.Usuario_Registrado_Spartan_User;
result.Empresa = entity.Empresa;
result.Empresa_Empresas = entity.Empresa_Empresas;
result.Numero_de_Empleado = entity.Numero_de_Empleado;
result.Nombres = entity.Nombres;
result.Apellido_Paterno = entity.Apellido_Paterno;
result.Apellido_Materno = entity.Apellido_Materno;
result.Nombre_Completo = entity.Nombre_Completo;
result.Celular = entity.Celular;
result.Email = entity.Email;
result.Fecha_de_nacimiento = entity.Fecha_de_nacimiento;
result.Nombre_del_Padre_o_Tutor = entity.Nombre_del_Padre_o_Tutor;
result.Pais_de_nacimiento = entity.Pais_de_nacimiento;
result.Pais_de_nacimiento_Pais = entity.Pais_de_nacimiento_Pais;
result.Lugar_de_nacimiento = entity.Lugar_de_nacimiento;
result.Lugar_de_nacimiento_Estado = entity.Lugar_de_nacimiento_Estado;
result.Sexo = entity.Sexo;
result.Sexo_Sexo = entity.Sexo_Sexo;
result.Estado_Civil = entity.Estado_Civil;
result.Estado_Civil_Estado_Civil = entity.Estado_Civil_Estado_Civil;
result.Calle = entity.Calle;
result.Numero_exterior = entity.Numero_exterior;
result.Numero_interior = entity.Numero_interior;
result.Colonia = entity.Colonia;
result.CP = entity.CP;
result.Ciudad = entity.Ciudad;
result.Pais = entity.Pais;
result.Pais_Pais = entity.Pais_Pais;
result.Estado = entity.Estado;
result.Estado_Estado = entity.Estado_Estado;
result.Ocupacion = entity.Ocupacion;
result.Cantidad_hijos = entity.Cantidad_hijos;
result.Objetivo = entity.Objetivo;
result.Objetivo_Objetivos = entity.Objetivo_Objetivos;
result.Estatus_Paciente = entity.Estatus_Paciente;
result.Estatus_Paciente_Estatus_por_Suscripcion = entity.Estatus_Paciente_Estatus_por_Suscripcion;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Padecimientos(Pacientes varPacientes_Padecimientos)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Padecimientos(varPacientes_Padecimientos));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Padecimientos.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Padecimientos), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Padecimientos.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Padecimientos), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Padecimientos(int id)
        {
            Pacientes entity = this.service.ListaSelAll(1, 1, "Pacientes.Folio='" + id.ToString() + "'", "").Pacientess.First();
            Pacientes result = new Pacientes();
			result.Folio = entity.Folio;
result.Cuenta_con_padecimientos = entity.Cuenta_con_padecimientos;
result.Cuenta_con_padecimientos_Respuesta_Logica = entity.Cuenta_con_padecimientos_Respuesta_Logica;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Antecedentes(Pacientes varPacientes_Antecedentes)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Antecedentes(varPacientes_Antecedentes));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Antecedentes.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Antecedentes), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Antecedentes.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Antecedentes), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Antecedentes(int id)
        {
            Pacientes entity = this.service.ListaSelAll(1, 1, "Pacientes.Folio='" + id.ToString() + "'", "").Pacientess.First();
            Pacientes result = new Pacientes();
			result.Folio = entity.Folio;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Mediciones_Iniciales(Pacientes varPacientes_Mediciones_Iniciales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Mediciones_Iniciales(varPacientes_Mediciones_Iniciales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Mediciones_Iniciales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Mediciones_Iniciales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Mediciones_Iniciales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Mediciones_Iniciales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Mediciones_Iniciales(int id)
        {
            Pacientes entity = this.service.ListaSelAll(1, 1, "Pacientes.Folio='" + id.ToString() + "'", "").Pacientess.First();
            Pacientes result = new Pacientes();
			result.Folio = entity.Folio;
result.Frecuencia_Cardiaca = entity.Frecuencia_Cardiaca;
result.Frecuencia_Respiratoria = entity.Frecuencia_Respiratoria;
result.Presion_sistolica = entity.Presion_sistolica;
result.Presion_diastolica = entity.Presion_diastolica;
result.Peso_actual = entity.Peso_actual;
result.Estatura = entity.Estatura;
result.Peso_habitual = entity.Peso_habitual;
result.Circunferencia_de_cintura_cm = entity.Circunferencia_de_cintura_cm;
result.Circunferencia_de_cadera_cm = entity.Circunferencia_de_cadera_cm;
result.Anchura_de_muneca_mm = entity.Anchura_de_muneca_mm;
result.Circunferencia_de_brazo_cm = entity.Circunferencia_de_brazo_cm;
result.Pliegue_cutaneo_tricipital_mm = entity.Pliegue_cutaneo_tricipital_mm;
result.Pliegue_cutaneo_bicipital_mm = entity.Pliegue_cutaneo_bicipital_mm;
result.Pliegue_cutaneo_subescapular_mm = entity.Pliegue_cutaneo_subescapular_mm;
result.Pliegue_cutaneo_supraespinal_mm = entity.Pliegue_cutaneo_supraespinal_mm;
result.Edad_Metabolica = entity.Edad_Metabolica;
result.Agua_corporal = entity.Agua_corporal;
result.Grasa_Visceral = entity.Grasa_Visceral;
result.Grasa_Corporal = entity.Grasa_Corporal;
result.Grasa_Corporal_kg = entity.Grasa_Corporal_kg;
result.Masa_Muscular_kg = entity.Masa_Muscular_kg;
result.Masa_Muscular_ = entity.Masa_Muscular_;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Ginecologicos(Pacientes varPacientes_Datos_Ginecologicos)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Ginecologicos(varPacientes_Datos_Ginecologicos));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Datos_Ginecologicos.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Datos_Ginecologicos), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Datos_Ginecologicos.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Datos_Ginecologicos), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Ginecologicos(int id)
        {
            Pacientes entity = this.service.ListaSelAll(1, 1, "Pacientes.Folio='" + id.ToString() + "'", "").Pacientess.First();
            Pacientes result = new Pacientes();
			result.Folio = entity.Folio;
result.Esta_embarazada = entity.Esta_embarazada;
result.Esta_embarazada_Respuesta_Logica = entity.Esta_embarazada_Respuesta_Logica;
result.Semana_de_gestacion = entity.Semana_de_gestacion;
result.Peso_pregestacional = entity.Peso_pregestacional;
result.Toma_anticonceptivos = entity.Toma_anticonceptivos;
result.Toma_anticonceptivos_Respuesta_Logica = entity.Toma_anticonceptivos_Respuesta_Logica;
result.Nombre_del_Anticonceptivo = entity.Nombre_del_Anticonceptivo;
result.Dosis = entity.Dosis;
result.Climaterio = entity.Climaterio;
result.Climaterio_Respuesta_Logica = entity.Climaterio_Respuesta_Logica;
result.Fecha_Climaterio = entity.Fecha_Climaterio;
result.Terapia_reemplazo_hormonal = entity.Terapia_reemplazo_hormonal;
result.Terapia_reemplazo_hormonal_Respuesta_Logica = entity.Terapia_reemplazo_hormonal_Respuesta_Logica;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Historia_Nutricional(Pacientes varPacientes_Historia_Nutricional)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Historia_Nutricional(varPacientes_Historia_Nutricional));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Historia_Nutricional.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Historia_Nutricional), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Historia_Nutricional.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Historia_Nutricional), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Historia_Nutricional(int id)
        {
            Pacientes entity = this.service.ListaSelAll(1, 1, "Pacientes.Folio='" + id.ToString() + "'", "").Pacientess.First();
            Pacientes result = new Pacientes();
			result.Folio = entity.Folio;
result.Tipo_Dieta = entity.Tipo_Dieta;
result.Tipo_Dieta_Tipo_de_Dieta = entity.Tipo_Dieta_Tipo_de_Dieta;
result.Suplementos = entity.Suplementos;
result.Suplementos_Suplementos = entity.Suplementos_Suplementos;
result.Consumo_de_sal = entity.Consumo_de_sal;
result.Consumo_de_sal_Preferencias_Sal = entity.Consumo_de_sal_Preferencias_Sal;
result.Grasas_Preferencias = entity.Grasas_Preferencias;
result.Grasas_Preferencias_Preferencias_Grasas = entity.Grasas_Preferencias_Preferencias_Grasas;
result.Comidas_cantidad = entity.Comidas_cantidad;
result.Comidas_cantidad_Cantidad_Comidas = entity.Comidas_cantidad_Cantidad_Comidas;
result.Preparacion_Preferencias = entity.Preparacion_Preferencias;
result.Preparacion_Preferencias_Preferencias_Preparacion = entity.Preparacion_Preferencias_Preferencias_Preparacion;
result.Entre_comidas = entity.Entre_comidas;
result.Entre_comidas_Preferencias_Entrecomidas = entity.Entre_comidas_Preferencias_Entrecomidas;
result.Apetito = entity.Apetito;
result.Apetito_Nivel_de_Satisfaccion = entity.Apetito_Nivel_de_Satisfaccion;
result.Habitos_Modificacion = entity.Habitos_Modificacion;
result.Habitos_Modificacion_Tipo_Modificacion_Alimentos = entity.Habitos_Modificacion_Tipo_Modificacion_Alimentos;
result.Horario_hambre = entity.Horario_hambre;
result.Horario_hambre_Periodo_del_dia = entity.Horario_hambre_Periodo_del_dia;
result.Cuando_cambia_mi_estado_de_animo = entity.Cuando_cambia_mi_estado_de_animo;
result.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo = entity.Cuando_cambia_mi_estado_de_animo_Estado_de_Animo;
result.Medicamentos_bajar_peso = entity.Medicamentos_bajar_peso;
result.Medicamentos_bajar_peso_Respuesta_Logica = entity.Medicamentos_bajar_peso_Respuesta_Logica;
result.Cual_medicamento = entity.Cual_medicamento;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Estilo_de_Vida(Pacientes varPacientes_Estilo_de_Vida)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Estilo_de_Vida(varPacientes_Estilo_de_Vida));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Estilo_de_Vida.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Estilo_de_Vida), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Estilo_de_Vida.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Estilo_de_Vida), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Estilo_de_Vida(int id)
        {
            Pacientes entity = this.service.ListaSelAll(1, 1, "Pacientes.Folio='" + id.ToString() + "'", "").Pacientess.First();
            Pacientes result = new Pacientes();
			result.Folio = entity.Folio;
result.Frecuencia_Ejercicio = entity.Frecuencia_Ejercicio;
result.Frecuencia_Ejercicio_Frecuencia_Ejercicio = entity.Frecuencia_Ejercicio_Frecuencia_Ejercicio;
result.Duracion_Ejercicio = entity.Duracion_Ejercicio;
result.Duracion_Ejercicio_Duracion_Ejercicio = entity.Duracion_Ejercicio_Duracion_Ejercicio;
result.Tipo_Ejercicio = entity.Tipo_Ejercicio;
result.Tipo_Ejercicio_Tipo_Ejercicio = entity.Tipo_Ejercicio_Tipo_Ejercicio;
result.Antiguedad_Ejercicio = entity.Antiguedad_Ejercicio;
result.Antiguedad_Ejercicio_Antiguedad_Ejercicios = entity.Antiguedad_Ejercicio_Antiguedad_Ejercicios;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Resultados(Pacientes varPacientes_Resultados)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Resultados(varPacientes_Resultados));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Resultados.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Resultados), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Resultados.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Resultados), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Resultados(int id)
        {
            Pacientes entity = this.service.ListaSelAll(1, 1, "Pacientes.Folio='" + id.ToString() + "'", "").Pacientess.First();
            Pacientes result = new Pacientes();
			result.Folio = entity.Folio;
result.IMC = entity.IMC;
result.Interpretacion_IMC = entity.Interpretacion_IMC;
result.Interpretacion_IMC_Interpretacion_IMC = entity.Interpretacion_IMC_Interpretacion_IMC;
result.IMC_Pediatria = entity.IMC_Pediatria;
result.IMC_Pediatria_Interpretacion_IMC = entity.IMC_Pediatria_Interpretacion_IMC;
result.Complexion_corporal = entity.Complexion_corporal;
result.Interpretacion_complexion_corporal = entity.Interpretacion_complexion_corporal;
result.Interpretacion_complexion_corporal_Interpretacion_corporal = entity.Interpretacion_complexion_corporal_Interpretacion_corporal;
result.Distribucion_de_grasa_corporal = entity.Distribucion_de_grasa_corporal;
result.Interpretacion_grasa_corporal = entity.Interpretacion_grasa_corporal;
result.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal = entity.Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal;
result.Indice_cintura_cadera = entity.Indice_cintura_cadera;
result.Interpretacion_indice = entity.Interpretacion_indice;
result.Interpretacion_indice_Interpretacion_indice_cintura__cadera = entity.Interpretacion_indice_Interpretacion_indice_cintura__cadera;
result.Consumo_de_agua_resultado = entity.Consumo_de_agua_resultado;
result.Interpretacion_agua = entity.Interpretacion_agua;
result.Interpretacion_agua_Interpretacion_consumo_de_agua = entity.Interpretacion_agua_Interpretacion_consumo_de_agua;
result.Frecuencia_cardiaca_en_Esfuerzo = entity.Frecuencia_cardiaca_en_Esfuerzo;
result.Interpretacion_frecuencia = entity.Interpretacion_frecuencia;
result.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo = entity.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
result.Dificultad_de_Rutina_de_Ejercicios = entity.Dificultad_de_Rutina_de_Ejercicios;
result.Interpretacion_dificultad = entity.Interpretacion_dificultad;
result.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios = entity.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
result.Calorias = entity.Calorias;
result.Interpretacion_calorias = entity.Interpretacion_calorias;
result.Interpretacion_calorias_Interpretacion_Calorias = entity.Interpretacion_calorias_Interpretacion_Calorias;
result.Observaciones = entity.Observaciones;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Suscripcion(Pacientes varPacientes_Suscripcion)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Suscripcion(varPacientes_Suscripcion));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Suscripcion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Suscripcion), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varPacientes_Suscripcion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_UpdPacientes", new JavaScriptSerializer().Serialize(varPacientes_Suscripcion), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Suscripcion(int id)
        {
            Pacientes entity = this.service.ListaSelAll(1, 1, "Pacientes.Folio='" + id.ToString() + "'", "").Pacientess.First();
            Pacientes result = new Pacientes();
			result.Folio = entity.Folio;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage PacientesGenerateID()
        {
            Pacientes varPacientes = new Pacientes();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varPacientes));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_PacientesGenerateID", new JavaScriptSerializer().Serialize(varPacientes), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_PacientesGenerateID", new JavaScriptSerializer().Serialize(varPacientes), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Pacientes varPacientes = this.service.GetByKey(id, false);
            bool result = false;
            if (varPacientes == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelPacientes", new JavaScriptSerializer().Serialize(varPacientes), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelPacientes", new JavaScriptSerializer().Serialize(varPacientes), result, ex.Message);
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
                var PacientesDataTable = new JavaScriptSerializer().Deserialize<List<Pacientes>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, PacientesDataTable, Configuration.Formatters.JsonFormatter);
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
                var PacientesResult = new JavaScriptSerializer().Deserialize<Pacientes>(result);
                return Request.CreateResponse(HttpStatusCode.OK, PacientesResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Pacientes emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Pacientes emp, string user, string password)
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

