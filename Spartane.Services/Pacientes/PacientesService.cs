using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Pacientes;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Pacientes
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class PacientesService : IPacientesService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Pacientes.Pacientes> _PacientesRepository;
        #endregion

        #region Ctor
        public PacientesService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Pacientes.Pacientes> PacientesRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._PacientesRepository = PacientesRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._PacientesRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Pacientes.Pacientes> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Pacientes.Pacientes>("sp_SelAllPacientes");
        }

        public IList<Core.Classes.Pacientes.Pacientes> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPacientes_Complete>("sp_SelAllComplete_Pacientes");
            return data.Select(m => new Core.Classes.Pacientes.Pacientes
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Tipo_de_Registro_Tipo_de_Registro = new Core.Classes.Tipo_de_Registro.Tipo_de_Registro() { Clave = m.Tipo_de_Registro.GetValueOrDefault(), Descripcion = m.Tipo_de_Registro_Descripcion }
                ,Tipo_de_Paciente_Tipo_Paciente = new Core.Classes.Tipo_Paciente.Tipo_Paciente() { Clave = m.Tipo_de_Paciente.GetValueOrDefault(), Descripcion = m.Tipo_de_Paciente_Descripcion }
                ,Usuario_Registrado_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_Registrado.GetValueOrDefault(), Name = m.Usuario_Registrado_Name }
                ,Empresa_Empresas = new Core.Classes.Empresas.Empresas() { Folio = m.Empresa.GetValueOrDefault(), Nombre_de_la_Empresa = m.Empresa_Nombre_de_la_Empresa }
                ,Numero_de_Empleado = m.Numero_de_Empleado
                ,Nombres = m.Nombres
                ,Apellido_Paterno = m.Apellido_Paterno
                ,Apellido_Materno = m.Apellido_Materno
                ,Nombre_Completo = m.Nombre_Completo
                ,Celular = m.Celular
                ,Email = m.Email
                ,Fecha_de_nacimiento = m.Fecha_de_nacimiento
                ,Nombre_del_Padre_o_Tutor = m.Nombre_del_Padre_o_Tutor
                ,Pais_de_nacimiento_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais_de_nacimiento.GetValueOrDefault(), Nombre_del_Pais = m.Pais_de_nacimiento_Nombre_del_Pais }
                ,Lugar_de_nacimiento_Estado = new Core.Classes.Estado.Estado() { Clave = m.Lugar_de_nacimiento.GetValueOrDefault(), Nombre_del_Estado = m.Lugar_de_nacimiento_Nombre_del_Estado }
                ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Sexo.GetValueOrDefault(), Descripcion = m.Sexo_Descripcion }
                ,Estado_Civil_Estado_Civil = new Core.Classes.Estado_Civil.Estado_Civil() { Clave = m.Estado_Civil.GetValueOrDefault(), Descripcion = m.Estado_Civil_Descripcion }
                ,Calle = m.Calle
                ,Numero_exterior = m.Numero_exterior
                ,Numero_interior = m.Numero_interior
                ,Colonia = m.Colonia
                ,CP = m.CP
                ,Ciudad = m.Ciudad
                ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais.GetValueOrDefault(), Nombre_del_Pais = m.Pais_Nombre_del_Pais }
                ,Estado_Estado = new Core.Classes.Estado.Estado() { Clave = m.Estado.GetValueOrDefault(), Nombre_del_Estado = m.Estado_Nombre_del_Estado }
                ,Ocupacion = m.Ocupacion
                ,Cantidad_hijos = m.Cantidad_hijos
                ,Objetivo_Objetivos = new Core.Classes.Objetivos.Objetivos() { Clave = m.Objetivo.GetValueOrDefault(), Descripcion = m.Objetivo_Descripcion }
                ,Estatus_Paciente_Estatus_por_Suscripcion = new Core.Classes.Estatus_por_Suscripcion.Estatus_por_Suscripcion() { Clave = m.Estatus_Paciente.GetValueOrDefault(), Descripcion = m.Estatus_Paciente_Descripcion }
                ,Cuenta_con_padecimientos_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Cuenta_con_padecimientos.GetValueOrDefault(), Descripcion = m.Cuenta_con_padecimientos_Descripcion }
                ,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
                ,Frecuencia_Respiratoria = m.Frecuencia_Respiratoria
                ,Presion_sistolica = m.Presion_sistolica
                ,Presion_diastolica = m.Presion_diastolica
                ,Peso_actual = m.Peso_actual
                ,Estatura = m.Estatura
                ,Peso_habitual = m.Peso_habitual
                ,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
                ,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
                ,Anchura_de_muneca_mm = m.Anchura_de_muneca_mm
                ,Circunferencia_de_brazo_cm = m.Circunferencia_de_brazo_cm
                ,Pliegue_cutaneo_tricipital_mm = m.Pliegue_cutaneo_tricipital_mm
                ,Pliegue_cutaneo_bicipital_mm = m.Pliegue_cutaneo_bicipital_mm
                ,Pliegue_cutaneo_subescapular_mm = m.Pliegue_cutaneo_subescapular_mm
                ,Pliegue_cutaneo_supraespinal_mm = m.Pliegue_cutaneo_supraespinal_mm
                ,Edad_Metabolica = m.Edad_Metabolica
                ,Agua_corporal = m.Agua_corporal
                ,Grasa_Visceral = m.Grasa_Visceral
                ,Grasa_Corporal = m.Grasa_Corporal
                ,Grasa_Corporal_kg = m.Grasa_Corporal_kg
                ,Masa_Muscular_kg = m.Masa_Muscular_kg
                ,Masa_Muscular_ = m.Masa_Muscular_
                ,Esta_embarazada_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Esta_embarazada.GetValueOrDefault(), Descripcion = m.Esta_embarazada_Descripcion }
                ,Semana_de_gestacion = m.Semana_de_gestacion
                ,Peso_pregestacional = m.Peso_pregestacional
                ,Toma_anticonceptivos_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Toma_anticonceptivos.GetValueOrDefault(), Descripcion = m.Toma_anticonceptivos_Descripcion }
                ,Nombre_del_Anticonceptivo = m.Nombre_del_Anticonceptivo
                ,Dosis = m.Dosis
                ,Climaterio_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Climaterio.GetValueOrDefault(), Descripcion = m.Climaterio_Descripcion }
                ,Fecha_Climaterio = m.Fecha_Climaterio
                ,Terapia_reemplazo_hormonal_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Terapia_reemplazo_hormonal.GetValueOrDefault(), Descripcion = m.Terapia_reemplazo_hormonal_Descripcion }
                ,Tipo_Dieta_Tipo_de_Dieta = new Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta() { Clave = m.Tipo_Dieta.GetValueOrDefault(), Descripcion = m.Tipo_Dieta_Descripcion }
                ,Suplementos_Suplementos = new Core.Classes.Suplementos.Suplementos() { Clave = m.Suplementos.GetValueOrDefault(), Descripcion = m.Suplementos_Descripcion }
                ,Consumo_de_sal_Preferencias_Sal = new Core.Classes.Preferencias_Sal.Preferencias_Sal() { Clave = m.Consumo_de_sal.GetValueOrDefault(), Descripcion = m.Consumo_de_sal_Descripcion }
                ,Grasas_Preferencias_Preferencias_Grasas = new Core.Classes.Preferencias_Grasas.Preferencias_Grasas() { Clave = m.Grasas_Preferencias.GetValueOrDefault(), Descripcion = m.Grasas_Preferencias_Descripcion }
                ,Comidas_cantidad_Cantidad_Comidas = new Core.Classes.Cantidad_Comidas.Cantidad_Comidas() { Clave = m.Comidas_cantidad.GetValueOrDefault(), Descripcion = m.Comidas_cantidad_Descripcion }
                ,Preparacion_Preferencias_Preferencias_Preparacion = new Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion() { Clave = m.Preparacion_Preferencias.GetValueOrDefault(), Descripcion = m.Preparacion_Preferencias_Descripcion }
                ,Entre_comidas_Preferencias_Entrecomidas = new Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas() { Clave = m.Entre_comidas.GetValueOrDefault(), Descripcion = m.Entre_comidas_Descripcion }
                ,Apetito_Nivel_de_Satisfaccion = new Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion() { Clave = m.Apetito.GetValueOrDefault(), Descripcion = m.Apetito_Descripcion }
                ,Habitos_Modificacion_Tipo_Modificacion_Alimentos = new Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos() { Clave = m.Habitos_Modificacion.GetValueOrDefault(), Descripcion = m.Habitos_Modificacion_Descripcion }
                ,Horario_hambre_Periodo_del_dia = new Core.Classes.Periodo_del_dia.Periodo_del_dia() { Clave = m.Horario_hambre.GetValueOrDefault(), Descripcion = m.Horario_hambre_Descripcion }
                ,Cuando_cambia_mi_estado_de_animo_Estado_de_Animo = new Core.Classes.Estado_de_Animo.Estado_de_Animo() { Clave = m.Cuando_cambia_mi_estado_de_animo.GetValueOrDefault(), Descripcion = m.Cuando_cambia_mi_estado_de_animo_Descripcion }
                ,Medicamentos_bajar_peso_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Medicamentos_bajar_peso.GetValueOrDefault(), Descripcion = m.Medicamentos_bajar_peso_Descripcion }
                ,Cual_medicamento = m.Cual_medicamento
                ,Frecuencia_Ejercicio_Frecuencia_Ejercicio = new Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio() { Clave = m.Frecuencia_Ejercicio.GetValueOrDefault(), Descripcion = m.Frecuencia_Ejercicio_Descripcion }
                ,Duracion_Ejercicio_Duracion_Ejercicio = new Core.Classes.Duracion_Ejercicio.Duracion_Ejercicio() { Clave = m.Duracion_Ejercicio.GetValueOrDefault(), Descripcion = m.Duracion_Ejercicio_Descripcion }
                ,Tipo_Ejercicio_Tipo_Ejercicio = new Core.Classes.Tipo_Ejercicio.Tipo_Ejercicio() { Clave = m.Tipo_Ejercicio.GetValueOrDefault(), Descripcion = m.Tipo_Ejercicio_Descripcion }
                ,Antiguedad_Ejercicio_Antiguedad_Ejercicios = new Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios() { Clave = m.Antiguedad_Ejercicio.GetValueOrDefault(), Descripcion = m.Antiguedad_Ejercicio_Descripcion }
                ,IMC = m.IMC
                ,Interpretacion_IMC_Interpretacion_IMC = new Core.Classes.Interpretacion_IMC.Interpretacion_IMC() { Folio = m.Interpretacion_IMC.GetValueOrDefault(), Descripcion = m.Interpretacion_IMC_Descripcion }
                ,IMC_Pediatria_Interpretacion_IMC = new Core.Classes.Interpretacion_IMC.Interpretacion_IMC() { Folio = m.IMC_Pediatria.GetValueOrDefault(), Descripcion = m.IMC_Pediatria_Descripcion }
                ,Complexion_corporal = m.Complexion_corporal
                ,Interpretacion_complexion_corporal_Interpretacion_corporal = new Core.Classes.Interpretacion_corporal.Interpretacion_corporal() { Folio = m.Interpretacion_complexion_corporal.GetValueOrDefault(), Descripcion = m.Interpretacion_complexion_corporal_Descripcion }
                ,Distribucion_de_grasa_corporal = m.Distribucion_de_grasa_corporal
                ,Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal = new Core.Classes.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal() { Folio = m.Interpretacion_grasa_corporal.GetValueOrDefault(), Descripcion = m.Interpretacion_grasa_corporal_Descripcion }
                ,Indice_cintura_cadera = m.Indice_cintura_cadera
                ,Interpretacion_indice_Interpretacion_indice_cintura__cadera = new Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera() { Folio = m.Interpretacion_indice.GetValueOrDefault(), Descripcion = m.Interpretacion_indice_Descripcion }
                ,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                ,Interpretacion_agua_Interpretacion_consumo_de_agua = new Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua() { Folio = m.Interpretacion_agua.GetValueOrDefault(), Descripcion = m.Interpretacion_agua_Descripcion }
                ,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                ,Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo = new Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo() { Folio = m.Interpretacion_frecuencia.GetValueOrDefault(), Descripcion = m.Interpretacion_frecuencia_Descripcion }
                ,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                ,Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios = new Core.Classes.Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Interpretacion_Dificultad_de_Rutina_de_Ejercicios() { Folio = m.Interpretacion_dificultad.GetValueOrDefault(), Descripcion = m.Interpretacion_dificultad_Descripcion }
                ,Calorias = m.Calorias
                ,Interpretacion_calorias_Interpretacion_Calorias = new Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias() { Folio = m.Interpretacion_calorias.GetValueOrDefault(), Descripcion = m.Interpretacion_calorias_Descripcion }
                ,Observaciones = m.Observaciones


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Pacientes>("sp_ListSelCount_Pacientes", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Pacientes.Pacientes> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                var padreWhere = _dataProvider.GetParameter();
                padreWhere.ParameterName = "Where";
                padreWhere.DbType = DbType.String;

                padreWhere.Value = Where;

                var padreOrderBy = _dataProvider.GetParameter();
                padreOrderBy.ParameterName = "Order";
                padreOrderBy.DbType = DbType.String;
                padreOrderBy.Value = Order;


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPacientes>("sp_ListSelAll_Pacientes", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Pacientes.Pacientes
                {
                    Folio = m.Pacientes_Folio,
                    Fecha_de_Registro = m.Pacientes_Fecha_de_Registro,
                    Hora_de_Registro = m.Pacientes_Hora_de_Registro,
                    Usuario_que_Registra = m.Pacientes_Usuario_que_Registra,
                    Tipo_de_Registro = m.Pacientes_Tipo_de_Registro,
                    Tipo_de_Paciente = m.Pacientes_Tipo_de_Paciente,
                    Usuario_Registrado = m.Pacientes_Usuario_Registrado,
                    Empresa = m.Pacientes_Empresa,
                    Numero_de_Empleado = m.Pacientes_Numero_de_Empleado,
                    Nombres = m.Pacientes_Nombres,
                    Apellido_Paterno = m.Pacientes_Apellido_Paterno,
                    Apellido_Materno = m.Pacientes_Apellido_Materno,
                    Nombre_Completo = m.Pacientes_Nombre_Completo,
                    Celular = m.Pacientes_Celular,
                    Email = m.Pacientes_Email,
                    Fecha_de_nacimiento = m.Pacientes_Fecha_de_nacimiento,
                    Nombre_del_Padre_o_Tutor = m.Pacientes_Nombre_del_Padre_o_Tutor,
                    Pais_de_nacimiento = m.Pacientes_Pais_de_nacimiento,
                    Lugar_de_nacimiento = m.Pacientes_Lugar_de_nacimiento,
                    Sexo = m.Pacientes_Sexo,
                    Estado_Civil = m.Pacientes_Estado_Civil,
                    Calle = m.Pacientes_Calle,
                    Numero_exterior = m.Pacientes_Numero_exterior,
                    Numero_interior = m.Pacientes_Numero_interior,
                    Colonia = m.Pacientes_Colonia,
                    CP = m.Pacientes_CP,
                    Ciudad = m.Pacientes_Ciudad,
                    Pais = m.Pacientes_Pais,
                    Estado = m.Pacientes_Estado,
                    Ocupacion = m.Pacientes_Ocupacion,
                    Cantidad_hijos = m.Pacientes_Cantidad_hijos,
                    Objetivo = m.Pacientes_Objetivo,
                    Estatus_Paciente = m.Pacientes_Estatus_Paciente,
                    Cuenta_con_padecimientos = m.Pacientes_Cuenta_con_padecimientos,
                    Frecuencia_Cardiaca = m.Pacientes_Frecuencia_Cardiaca,
                    Frecuencia_Respiratoria = m.Pacientes_Frecuencia_Respiratoria,
                    Presion_sistolica = m.Pacientes_Presion_sistolica,
                    Presion_diastolica = m.Pacientes_Presion_diastolica,
                    Peso_actual = m.Pacientes_Peso_actual,
                    Estatura = m.Pacientes_Estatura,
                    Peso_habitual = m.Pacientes_Peso_habitual,
                    Circunferencia_de_cintura_cm = m.Pacientes_Circunferencia_de_cintura_cm,
                    Circunferencia_de_cadera_cm = m.Pacientes_Circunferencia_de_cadera_cm,
                    Anchura_de_muneca_mm = m.Pacientes_Anchura_de_muneca_mm,
                    Circunferencia_de_brazo_cm = m.Pacientes_Circunferencia_de_brazo_cm,
                    Pliegue_cutaneo_tricipital_mm = m.Pacientes_Pliegue_cutaneo_tricipital_mm,
                    Pliegue_cutaneo_bicipital_mm = m.Pacientes_Pliegue_cutaneo_bicipital_mm,
                    Pliegue_cutaneo_subescapular_mm = m.Pacientes_Pliegue_cutaneo_subescapular_mm,
                    Pliegue_cutaneo_supraespinal_mm = m.Pacientes_Pliegue_cutaneo_supraespinal_mm,
                    Edad_Metabolica = m.Pacientes_Edad_Metabolica,
                    Agua_corporal = m.Pacientes_Agua_corporal,
                    Grasa_Visceral = m.Pacientes_Grasa_Visceral,
                    Grasa_Corporal = m.Pacientes_Grasa_Corporal,
                    Grasa_Corporal_kg = m.Pacientes_Grasa_Corporal_kg,
                    Masa_Muscular_kg = m.Pacientes_Masa_Muscular_kg,
                    Masa_Muscular_ = m.Pacientes_Masa_Muscular_,
                    Esta_embarazada = m.Pacientes_Esta_embarazada,
                    Semana_de_gestacion = m.Pacientes_Semana_de_gestacion,
                    Peso_pregestacional = m.Pacientes_Peso_pregestacional,
                    Toma_anticonceptivos = m.Pacientes_Toma_anticonceptivos,
                    Nombre_del_Anticonceptivo = m.Pacientes_Nombre_del_Anticonceptivo,
                    Dosis = m.Pacientes_Dosis,
                    Climaterio = m.Pacientes_Climaterio,
                    Fecha_Climaterio = m.Pacientes_Fecha_Climaterio,
                    Terapia_reemplazo_hormonal = m.Pacientes_Terapia_reemplazo_hormonal,
                    Tipo_Dieta = m.Pacientes_Tipo_Dieta,
                    Suplementos = m.Pacientes_Suplementos,
                    Consumo_de_sal = m.Pacientes_Consumo_de_sal,
                    Grasas_Preferencias = m.Pacientes_Grasas_Preferencias,
                    Comidas_cantidad = m.Pacientes_Comidas_cantidad,
                    Preparacion_Preferencias = m.Pacientes_Preparacion_Preferencias,
                    Entre_comidas = m.Pacientes_Entre_comidas,
                    Apetito = m.Pacientes_Apetito,
                    Habitos_Modificacion = m.Pacientes_Habitos_Modificacion,
                    Horario_hambre = m.Pacientes_Horario_hambre,
                    Cuando_cambia_mi_estado_de_animo = m.Pacientes_Cuando_cambia_mi_estado_de_animo,
                    Medicamentos_bajar_peso = m.Pacientes_Medicamentos_bajar_peso,
                    Cual_medicamento = m.Pacientes_Cual_medicamento,
                    Frecuencia_Ejercicio = m.Pacientes_Frecuencia_Ejercicio,
                    Duracion_Ejercicio = m.Pacientes_Duracion_Ejercicio,
                    Tipo_Ejercicio = m.Pacientes_Tipo_Ejercicio,
                    Antiguedad_Ejercicio = m.Pacientes_Antiguedad_Ejercicio,
                    IMC = m.Pacientes_IMC,
                    Interpretacion_IMC = m.Pacientes_Interpretacion_IMC,
                    IMC_Pediatria = m.Pacientes_IMC_Pediatria,
                    Complexion_corporal = m.Pacientes_Complexion_corporal,
                    Interpretacion_complexion_corporal = m.Pacientes_Interpretacion_complexion_corporal,
                    Distribucion_de_grasa_corporal = m.Pacientes_Distribucion_de_grasa_corporal,
                    Interpretacion_grasa_corporal = m.Pacientes_Interpretacion_grasa_corporal,
                    Indice_cintura_cadera = m.Pacientes_Indice_cintura_cadera,
                    Interpretacion_indice = m.Pacientes_Interpretacion_indice,
                    Consumo_de_agua_resultado = m.Pacientes_Consumo_de_agua_resultado,
                    Interpretacion_agua = m.Pacientes_Interpretacion_agua,
                    Frecuencia_cardiaca_en_Esfuerzo = m.Pacientes_Frecuencia_cardiaca_en_Esfuerzo,
                    Interpretacion_frecuencia = m.Pacientes_Interpretacion_frecuencia,
                    Dificultad_de_Rutina_de_Ejercicios = m.Pacientes_Dificultad_de_Rutina_de_Ejercicios,
                    Interpretacion_dificultad = m.Pacientes_Interpretacion_dificultad,
                    Calorias = m.Pacientes_Calorias,
                    Interpretacion_calorias = m.Pacientes_Interpretacion_calorias,
                    Observaciones = m.Pacientes_Observaciones,

                    //Id = m.Id,
                }).ToList();
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

        }

        public IList<Spartane.Core.Classes.Pacientes.Pacientes> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._PacientesRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Pacientes.Pacientes> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._PacientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Pacientes.PacientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            var padstartRowIndex = _dataProvider.GetParameter();
            padstartRowIndex.ParameterName = "startRowIndex";
            padstartRowIndex.DbType = DbType.Int32;
            padstartRowIndex.Value = startRowIndex;

            var padmaximumRows = _dataProvider.GetParameter();
            padmaximumRows.ParameterName = "maximumRows";
            padmaximumRows.DbType = DbType.Int32;
            padmaximumRows.Value = maximumRows;

            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var padOrder = _dataProvider.GetParameter();
            padOrder.ParameterName = "Order";
            padOrder.DbType = DbType.String;
            padOrder.Value = Order;

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPacientes>("sp_ListSelAll_Pacientes", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            PacientesPagingModel result = null;

            if (data != null)
            {
                result = new PacientesPagingModel
                {
                    Pacientess =
                        data.Select(m => new Spartane.Core.Classes.Pacientes.Pacientes
                {
                    Folio = m.Pacientes_Folio
                    ,Fecha_de_Registro = m.Pacientes_Fecha_de_Registro
                    ,Hora_de_Registro = m.Pacientes_Hora_de_Registro
                    ,Usuario_que_Registra = m.Pacientes_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Pacientes_Usuario_que_Registra.GetValueOrDefault(), Name = m.Pacientes_Usuario_que_Registra_Name }
                    ,Tipo_de_Registro = m.Pacientes_Tipo_de_Registro
                    ,Tipo_de_Registro_Tipo_de_Registro = new Core.Classes.Tipo_de_Registro.Tipo_de_Registro() { Clave = m.Pacientes_Tipo_de_Registro.GetValueOrDefault(), Descripcion = m.Pacientes_Tipo_de_Registro_Descripcion }
                    ,Tipo_de_Paciente = m.Pacientes_Tipo_de_Paciente
                    ,Tipo_de_Paciente_Tipo_Paciente = new Core.Classes.Tipo_Paciente.Tipo_Paciente() { Clave = m.Pacientes_Tipo_de_Paciente.GetValueOrDefault(), Descripcion = m.Pacientes_Tipo_de_Paciente_Descripcion }
                    ,Usuario_Registrado = m.Pacientes_Usuario_Registrado
                    ,Usuario_Registrado_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Pacientes_Usuario_Registrado.GetValueOrDefault(), Name = m.Pacientes_Usuario_Registrado_Name }
                    ,Empresa = m.Pacientes_Empresa
                    ,Empresa_Empresas = new Core.Classes.Empresas.Empresas() { Folio = m.Pacientes_Empresa.GetValueOrDefault(), Nombre_de_la_Empresa = m.Pacientes_Empresa_Nombre_de_la_Empresa }
                    ,Numero_de_Empleado = m.Pacientes_Numero_de_Empleado
                    ,Nombres = m.Pacientes_Nombres
                    ,Apellido_Paterno = m.Pacientes_Apellido_Paterno
                    ,Apellido_Materno = m.Pacientes_Apellido_Materno
                    ,Nombre_Completo = m.Pacientes_Nombre_Completo
                    ,Celular = m.Pacientes_Celular
                    ,Email = m.Pacientes_Email
                    ,Fecha_de_nacimiento = m.Pacientes_Fecha_de_nacimiento
                    ,Nombre_del_Padre_o_Tutor = m.Pacientes_Nombre_del_Padre_o_Tutor
                    ,Pais_de_nacimiento = m.Pacientes_Pais_de_nacimiento
                    ,Pais_de_nacimiento_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pacientes_Pais_de_nacimiento.GetValueOrDefault(), Nombre_del_Pais = m.Pacientes_Pais_de_nacimiento_Nombre_del_Pais }
                    ,Lugar_de_nacimiento = m.Pacientes_Lugar_de_nacimiento
                    ,Lugar_de_nacimiento_Estado = new Core.Classes.Estado.Estado() { Clave = m.Pacientes_Lugar_de_nacimiento.GetValueOrDefault(), Nombre_del_Estado = m.Pacientes_Lugar_de_nacimiento_Nombre_del_Estado }
                    ,Sexo = m.Pacientes_Sexo
                    ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Pacientes_Sexo.GetValueOrDefault(), Descripcion = m.Pacientes_Sexo_Descripcion }
                    ,Estado_Civil = m.Pacientes_Estado_Civil
                    ,Estado_Civil_Estado_Civil = new Core.Classes.Estado_Civil.Estado_Civil() { Clave = m.Pacientes_Estado_Civil.GetValueOrDefault(), Descripcion = m.Pacientes_Estado_Civil_Descripcion }
                    ,Calle = m.Pacientes_Calle
                    ,Numero_exterior = m.Pacientes_Numero_exterior
                    ,Numero_interior = m.Pacientes_Numero_interior
                    ,Colonia = m.Pacientes_Colonia
                    ,CP = m.Pacientes_CP
                    ,Ciudad = m.Pacientes_Ciudad
                    ,Pais = m.Pacientes_Pais
                    ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pacientes_Pais.GetValueOrDefault(), Nombre_del_Pais = m.Pacientes_Pais_Nombre_del_Pais }
                    ,Estado = m.Pacientes_Estado
                    ,Estado_Estado = new Core.Classes.Estado.Estado() { Clave = m.Pacientes_Estado.GetValueOrDefault(), Nombre_del_Estado = m.Pacientes_Estado_Nombre_del_Estado }
                    ,Ocupacion = m.Pacientes_Ocupacion
                    ,Cantidad_hijos = m.Pacientes_Cantidad_hijos
                    ,Objetivo = m.Pacientes_Objetivo
                    ,Objetivo_Objetivos = new Core.Classes.Objetivos.Objetivos() { Clave = m.Pacientes_Objetivo.GetValueOrDefault(), Descripcion = m.Pacientes_Objetivo_Descripcion }
                    ,Estatus_Paciente = m.Pacientes_Estatus_Paciente
                    ,Estatus_Paciente_Estatus_por_Suscripcion = new Core.Classes.Estatus_por_Suscripcion.Estatus_por_Suscripcion() { Clave = m.Pacientes_Estatus_Paciente.GetValueOrDefault(), Descripcion = m.Pacientes_Estatus_Paciente_Descripcion }
                    ,Cuenta_con_padecimientos = m.Pacientes_Cuenta_con_padecimientos
                    ,Cuenta_con_padecimientos_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Pacientes_Cuenta_con_padecimientos.GetValueOrDefault(), Descripcion = m.Pacientes_Cuenta_con_padecimientos_Descripcion }
                    ,Frecuencia_Cardiaca = m.Pacientes_Frecuencia_Cardiaca
                    ,Frecuencia_Respiratoria = m.Pacientes_Frecuencia_Respiratoria
                    ,Presion_sistolica = m.Pacientes_Presion_sistolica
                    ,Presion_diastolica = m.Pacientes_Presion_diastolica
                    ,Peso_actual = m.Pacientes_Peso_actual
                    ,Estatura = m.Pacientes_Estatura
                    ,Peso_habitual = m.Pacientes_Peso_habitual
                    ,Circunferencia_de_cintura_cm = m.Pacientes_Circunferencia_de_cintura_cm
                    ,Circunferencia_de_cadera_cm = m.Pacientes_Circunferencia_de_cadera_cm
                    ,Anchura_de_muneca_mm = m.Pacientes_Anchura_de_muneca_mm
                    ,Circunferencia_de_brazo_cm = m.Pacientes_Circunferencia_de_brazo_cm
                    ,Pliegue_cutaneo_tricipital_mm = m.Pacientes_Pliegue_cutaneo_tricipital_mm
                    ,Pliegue_cutaneo_bicipital_mm = m.Pacientes_Pliegue_cutaneo_bicipital_mm
                    ,Pliegue_cutaneo_subescapular_mm = m.Pacientes_Pliegue_cutaneo_subescapular_mm
                    ,Pliegue_cutaneo_supraespinal_mm = m.Pacientes_Pliegue_cutaneo_supraespinal_mm
                    ,Edad_Metabolica = m.Pacientes_Edad_Metabolica
                    ,Agua_corporal = m.Pacientes_Agua_corporal
                    ,Grasa_Visceral = m.Pacientes_Grasa_Visceral
                    ,Grasa_Corporal = m.Pacientes_Grasa_Corporal
                    ,Grasa_Corporal_kg = m.Pacientes_Grasa_Corporal_kg
                    ,Masa_Muscular_kg = m.Pacientes_Masa_Muscular_kg
                    ,Masa_Muscular_ = m.Pacientes_Masa_Muscular_
                    ,Esta_embarazada = m.Pacientes_Esta_embarazada
                    ,Esta_embarazada_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Pacientes_Esta_embarazada.GetValueOrDefault(), Descripcion = m.Pacientes_Esta_embarazada_Descripcion }
                    ,Semana_de_gestacion = m.Pacientes_Semana_de_gestacion
                    ,Peso_pregestacional = m.Pacientes_Peso_pregestacional
                    ,Toma_anticonceptivos = m.Pacientes_Toma_anticonceptivos
                    ,Toma_anticonceptivos_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Pacientes_Toma_anticonceptivos.GetValueOrDefault(), Descripcion = m.Pacientes_Toma_anticonceptivos_Descripcion }
                    ,Nombre_del_Anticonceptivo = m.Pacientes_Nombre_del_Anticonceptivo
                    ,Dosis = m.Pacientes_Dosis
                    ,Climaterio = m.Pacientes_Climaterio
                    ,Climaterio_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Pacientes_Climaterio.GetValueOrDefault(), Descripcion = m.Pacientes_Climaterio_Descripcion }
                    ,Fecha_Climaterio = m.Pacientes_Fecha_Climaterio
                    ,Terapia_reemplazo_hormonal = m.Pacientes_Terapia_reemplazo_hormonal
                    ,Terapia_reemplazo_hormonal_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Pacientes_Terapia_reemplazo_hormonal.GetValueOrDefault(), Descripcion = m.Pacientes_Terapia_reemplazo_hormonal_Descripcion }
                    ,Tipo_Dieta = m.Pacientes_Tipo_Dieta
                    ,Tipo_Dieta_Tipo_de_Dieta = new Core.Classes.Tipo_de_Dieta.Tipo_de_Dieta() { Clave = m.Pacientes_Tipo_Dieta.GetValueOrDefault(), Descripcion = m.Pacientes_Tipo_Dieta_Descripcion }
                    ,Suplementos = m.Pacientes_Suplementos
                    ,Suplementos_Suplementos = new Core.Classes.Suplementos.Suplementos() { Clave = m.Pacientes_Suplementos.GetValueOrDefault(), Descripcion = m.Pacientes_Suplementos_Descripcion }
                    ,Consumo_de_sal = m.Pacientes_Consumo_de_sal
                    ,Consumo_de_sal_Preferencias_Sal = new Core.Classes.Preferencias_Sal.Preferencias_Sal() { Clave = m.Pacientes_Consumo_de_sal.GetValueOrDefault(), Descripcion = m.Pacientes_Consumo_de_sal_Descripcion }
                    ,Grasas_Preferencias = m.Pacientes_Grasas_Preferencias
                    ,Grasas_Preferencias_Preferencias_Grasas = new Core.Classes.Preferencias_Grasas.Preferencias_Grasas() { Clave = m.Pacientes_Grasas_Preferencias.GetValueOrDefault(), Descripcion = m.Pacientes_Grasas_Preferencias_Descripcion }
                    ,Comidas_cantidad = m.Pacientes_Comidas_cantidad
                    ,Comidas_cantidad_Cantidad_Comidas = new Core.Classes.Cantidad_Comidas.Cantidad_Comidas() { Clave = m.Pacientes_Comidas_cantidad.GetValueOrDefault(), Descripcion = m.Pacientes_Comidas_cantidad_Descripcion }
                    ,Preparacion_Preferencias = m.Pacientes_Preparacion_Preferencias
                    ,Preparacion_Preferencias_Preferencias_Preparacion = new Core.Classes.Preferencias_Preparacion.Preferencias_Preparacion() { Clave = m.Pacientes_Preparacion_Preferencias.GetValueOrDefault(), Descripcion = m.Pacientes_Preparacion_Preferencias_Descripcion }
                    ,Entre_comidas = m.Pacientes_Entre_comidas
                    ,Entre_comidas_Preferencias_Entrecomidas = new Core.Classes.Preferencias_Entrecomidas.Preferencias_Entrecomidas() { Clave = m.Pacientes_Entre_comidas.GetValueOrDefault(), Descripcion = m.Pacientes_Entre_comidas_Descripcion }
                    ,Apetito = m.Pacientes_Apetito
                    ,Apetito_Nivel_de_Satisfaccion = new Core.Classes.Nivel_de_Satisfaccion.Nivel_de_Satisfaccion() { Clave = m.Pacientes_Apetito.GetValueOrDefault(), Descripcion = m.Pacientes_Apetito_Descripcion }
                    ,Habitos_Modificacion = m.Pacientes_Habitos_Modificacion
                    ,Habitos_Modificacion_Tipo_Modificacion_Alimentos = new Core.Classes.Tipo_Modificacion_Alimentos.Tipo_Modificacion_Alimentos() { Clave = m.Pacientes_Habitos_Modificacion.GetValueOrDefault(), Descripcion = m.Pacientes_Habitos_Modificacion_Descripcion }
                    ,Horario_hambre = m.Pacientes_Horario_hambre
                    ,Horario_hambre_Periodo_del_dia = new Core.Classes.Periodo_del_dia.Periodo_del_dia() { Clave = m.Pacientes_Horario_hambre.GetValueOrDefault(), Descripcion = m.Pacientes_Horario_hambre_Descripcion }
                    ,Cuando_cambia_mi_estado_de_animo = m.Pacientes_Cuando_cambia_mi_estado_de_animo
                    ,Cuando_cambia_mi_estado_de_animo_Estado_de_Animo = new Core.Classes.Estado_de_Animo.Estado_de_Animo() { Clave = m.Pacientes_Cuando_cambia_mi_estado_de_animo.GetValueOrDefault(), Descripcion = m.Pacientes_Cuando_cambia_mi_estado_de_animo_Descripcion }
                    ,Medicamentos_bajar_peso = m.Pacientes_Medicamentos_bajar_peso
                    ,Medicamentos_bajar_peso_Respuesta_Logica = new Core.Classes.Respuesta_Logica.Respuesta_Logica() { Clave = m.Pacientes_Medicamentos_bajar_peso.GetValueOrDefault(), Descripcion = m.Pacientes_Medicamentos_bajar_peso_Descripcion }
                    ,Cual_medicamento = m.Pacientes_Cual_medicamento
                    ,Frecuencia_Ejercicio = m.Pacientes_Frecuencia_Ejercicio
                    ,Frecuencia_Ejercicio_Frecuencia_Ejercicio = new Core.Classes.Frecuencia_Ejercicio.Frecuencia_Ejercicio() { Clave = m.Pacientes_Frecuencia_Ejercicio.GetValueOrDefault(), Descripcion = m.Pacientes_Frecuencia_Ejercicio_Descripcion }
                    ,Duracion_Ejercicio = m.Pacientes_Duracion_Ejercicio
                    ,Duracion_Ejercicio_Duracion_Ejercicio = new Core.Classes.Duracion_Ejercicio.Duracion_Ejercicio() { Clave = m.Pacientes_Duracion_Ejercicio.GetValueOrDefault(), Descripcion = m.Pacientes_Duracion_Ejercicio_Descripcion }
                    ,Tipo_Ejercicio = m.Pacientes_Tipo_Ejercicio
                    ,Tipo_Ejercicio_Tipo_Ejercicio = new Core.Classes.Tipo_Ejercicio.Tipo_Ejercicio() { Clave = m.Pacientes_Tipo_Ejercicio.GetValueOrDefault(), Descripcion = m.Pacientes_Tipo_Ejercicio_Descripcion }
                    ,Antiguedad_Ejercicio = m.Pacientes_Antiguedad_Ejercicio
                    ,Antiguedad_Ejercicio_Antiguedad_Ejercicios = new Core.Classes.Antiguedad_Ejercicios.Antiguedad_Ejercicios() { Clave = m.Pacientes_Antiguedad_Ejercicio.GetValueOrDefault(), Descripcion = m.Pacientes_Antiguedad_Ejercicio_Descripcion }
                    ,IMC = m.Pacientes_IMC
                    ,Interpretacion_IMC = m.Pacientes_Interpretacion_IMC
                    ,Interpretacion_IMC_Interpretacion_IMC = new Core.Classes.Interpretacion_IMC.Interpretacion_IMC() { Folio = m.Pacientes_Interpretacion_IMC.GetValueOrDefault(), Descripcion = m.Pacientes_Interpretacion_IMC_Descripcion }
                    ,IMC_Pediatria = m.Pacientes_IMC_Pediatria
                    ,IMC_Pediatria_Interpretacion_IMC = new Core.Classes.Interpretacion_IMC.Interpretacion_IMC() { Folio = m.Pacientes_IMC_Pediatria.GetValueOrDefault(), Descripcion = m.Pacientes_IMC_Pediatria_Descripcion }
                    ,Complexion_corporal = m.Pacientes_Complexion_corporal
                    ,Interpretacion_complexion_corporal = m.Pacientes_Interpretacion_complexion_corporal
                    ,Interpretacion_complexion_corporal_Interpretacion_corporal = new Core.Classes.Interpretacion_corporal.Interpretacion_corporal() { Folio = m.Pacientes_Interpretacion_complexion_corporal.GetValueOrDefault(), Descripcion = m.Pacientes_Interpretacion_complexion_corporal_Descripcion }
                    ,Distribucion_de_grasa_corporal = m.Pacientes_Distribucion_de_grasa_corporal
                    ,Interpretacion_grasa_corporal = m.Pacientes_Interpretacion_grasa_corporal
                    ,Interpretacion_grasa_corporal_Interpretacion_distribucion_grasa_corporal = new Core.Classes.Interpretacion_distribucion_grasa_corporal.Interpretacion_distribucion_grasa_corporal() { Folio = m.Pacientes_Interpretacion_grasa_corporal.GetValueOrDefault(), Descripcion = m.Pacientes_Interpretacion_grasa_corporal_Descripcion }
                    ,Indice_cintura_cadera = m.Pacientes_Indice_cintura_cadera
                    ,Interpretacion_indice = m.Pacientes_Interpretacion_indice
                    ,Interpretacion_indice_Interpretacion_indice_cintura__cadera = new Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera() { Folio = m.Pacientes_Interpretacion_indice.GetValueOrDefault(), Descripcion = m.Pacientes_Interpretacion_indice_Descripcion }
                    ,Consumo_de_agua_resultado = m.Pacientes_Consumo_de_agua_resultado
                    ,Interpretacion_agua = m.Pacientes_Interpretacion_agua
                    ,Interpretacion_agua_Interpretacion_consumo_de_agua = new Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua() { Folio = m.Pacientes_Interpretacion_agua.GetValueOrDefault(), Descripcion = m.Pacientes_Interpretacion_agua_Descripcion }
                    ,Frecuencia_cardiaca_en_Esfuerzo = m.Pacientes_Frecuencia_cardiaca_en_Esfuerzo
                    ,Interpretacion_frecuencia = m.Pacientes_Interpretacion_frecuencia
                    ,Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo = new Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo() { Folio = m.Pacientes_Interpretacion_frecuencia.GetValueOrDefault(), Descripcion = m.Pacientes_Interpretacion_frecuencia_Descripcion }
                    ,Dificultad_de_Rutina_de_Ejercicios = m.Pacientes_Dificultad_de_Rutina_de_Ejercicios
                    ,Interpretacion_dificultad = m.Pacientes_Interpretacion_dificultad
                    ,Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios = new Core.Classes.Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Interpretacion_Dificultad_de_Rutina_de_Ejercicios() { Folio = m.Pacientes_Interpretacion_dificultad.GetValueOrDefault(), Descripcion = m.Pacientes_Interpretacion_dificultad_Descripcion }
                    ,Calorias = m.Pacientes_Calorias
                    ,Interpretacion_calorias = m.Pacientes_Interpretacion_calorias
                    ,Interpretacion_calorias_Interpretacion_Calorias = new Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias() { Folio = m.Pacientes_Interpretacion_calorias.GetValueOrDefault(), Descripcion = m.Pacientes_Interpretacion_calorias_Descripcion }
                    ,Observaciones = m.Pacientes_Observaciones

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Pacientes.Pacientes> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._PacientesRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Pacientes.Pacientes GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Pacientes.Pacientes>("sp_GetPacientes", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Folio";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPacientes>("sp_DelPacientes", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result.ToString() == "1";
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Insert(Spartane.Core.Classes.Pacientes.Pacientes entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFecha_de_Registro = _dataProvider.GetParameter();
                padreFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                padreFecha_de_Registro.DbType = DbType.DateTime;
                padreFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreUsuario_que_Registra = _dataProvider.GetParameter();
                padreUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                padreUsuario_que_Registra.DbType = DbType.Int32;
                padreUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var padreTipo_de_Registro = _dataProvider.GetParameter();
                padreTipo_de_Registro.ParameterName = "Tipo_de_Registro";
                padreTipo_de_Registro.DbType = DbType.Int32;
                padreTipo_de_Registro.Value = (object)entity.Tipo_de_Registro ?? DBNull.Value;

                var padreTipo_de_Paciente = _dataProvider.GetParameter();
                padreTipo_de_Paciente.ParameterName = "Tipo_de_Paciente";
                padreTipo_de_Paciente.DbType = DbType.Int32;
                padreTipo_de_Paciente.Value = (object)entity.Tipo_de_Paciente ?? DBNull.Value;

                var padreUsuario_Registrado = _dataProvider.GetParameter();
                padreUsuario_Registrado.ParameterName = "Usuario_Registrado";
                padreUsuario_Registrado.DbType = DbType.Int32;
                padreUsuario_Registrado.Value = (object)entity.Usuario_Registrado ?? DBNull.Value;

                var padreEmpresa = _dataProvider.GetParameter();
                padreEmpresa.ParameterName = "Empresa";
                padreEmpresa.DbType = DbType.Int32;
                padreEmpresa.Value = (object)entity.Empresa ?? DBNull.Value;

                var padreNumero_de_Empleado = _dataProvider.GetParameter();
                padreNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                padreNumero_de_Empleado.DbType = DbType.String;
                padreNumero_de_Empleado.Value = (object)entity.Numero_de_Empleado ?? DBNull.Value;
                var padreNombres = _dataProvider.GetParameter();
                padreNombres.ParameterName = "Nombres";
                padreNombres.DbType = DbType.String;
                padreNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var padreApellido_Paterno = _dataProvider.GetParameter();
                padreApellido_Paterno.ParameterName = "Apellido_Paterno";
                padreApellido_Paterno.DbType = DbType.String;
                padreApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var padreApellido_Materno = _dataProvider.GetParameter();
                padreApellido_Materno.ParameterName = "Apellido_Materno";
                padreApellido_Materno.DbType = DbType.String;
                padreApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var padreNombre_Completo = _dataProvider.GetParameter();
                padreNombre_Completo.ParameterName = "Nombre_Completo";
                padreNombre_Completo.DbType = DbType.String;
                padreNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var padreCelular = _dataProvider.GetParameter();
                padreCelular.ParameterName = "Celular";
                padreCelular.DbType = DbType.String;
                padreCelular.Value = (object)entity.Celular ?? DBNull.Value;
                var padreEmail = _dataProvider.GetParameter();
                padreEmail.ParameterName = "Email";
                padreEmail.DbType = DbType.String;
                padreEmail.Value = (object)entity.Email ?? DBNull.Value;
                var padreFecha_de_nacimiento = _dataProvider.GetParameter();
                padreFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                padreFecha_de_nacimiento.DbType = DbType.DateTime;
                padreFecha_de_nacimiento.Value = (object)entity.Fecha_de_nacimiento ?? DBNull.Value;

                var padreNombre_del_Padre_o_Tutor = _dataProvider.GetParameter();
                padreNombre_del_Padre_o_Tutor.ParameterName = "Nombre_del_Padre_o_Tutor";
                padreNombre_del_Padre_o_Tutor.DbType = DbType.String;
                padreNombre_del_Padre_o_Tutor.Value = (object)entity.Nombre_del_Padre_o_Tutor ?? DBNull.Value;
                var padrePais_de_nacimiento = _dataProvider.GetParameter();
                padrePais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                padrePais_de_nacimiento.DbType = DbType.Int32;
                padrePais_de_nacimiento.Value = (object)entity.Pais_de_nacimiento ?? DBNull.Value;

                var padreLugar_de_nacimiento = _dataProvider.GetParameter();
                padreLugar_de_nacimiento.ParameterName = "Lugar_de_nacimiento";
                padreLugar_de_nacimiento.DbType = DbType.Int32;
                padreLugar_de_nacimiento.Value = (object)entity.Lugar_de_nacimiento ?? DBNull.Value;

                var padreSexo = _dataProvider.GetParameter();
                padreSexo.ParameterName = "Sexo";
                padreSexo.DbType = DbType.Int32;
                padreSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var padreEstado_Civil = _dataProvider.GetParameter();
                padreEstado_Civil.ParameterName = "Estado_Civil";
                padreEstado_Civil.DbType = DbType.Int32;
                padreEstado_Civil.Value = (object)entity.Estado_Civil ?? DBNull.Value;

                var padreCalle = _dataProvider.GetParameter();
                padreCalle.ParameterName = "Calle";
                padreCalle.DbType = DbType.String;
                padreCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var padreNumero_exterior = _dataProvider.GetParameter();
                padreNumero_exterior.ParameterName = "Numero_exterior";
                padreNumero_exterior.DbType = DbType.String;
                padreNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;
                var padreNumero_interior = _dataProvider.GetParameter();
                padreNumero_interior.ParameterName = "Numero_interior";
                padreNumero_interior.DbType = DbType.String;
                padreNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;
                var padreColonia = _dataProvider.GetParameter();
                padreColonia.ParameterName = "Colonia";
                padreColonia.DbType = DbType.String;
                padreColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var padreCP = _dataProvider.GetParameter();
                padreCP.ParameterName = "CP";
                padreCP.DbType = DbType.Int32;
                padreCP.Value = (object)entity.CP ?? DBNull.Value;

                var padreCiudad = _dataProvider.GetParameter();
                padreCiudad.ParameterName = "Ciudad";
                padreCiudad.DbType = DbType.String;
                padreCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
                var padrePais = _dataProvider.GetParameter();
                padrePais.ParameterName = "Pais";
                padrePais.DbType = DbType.Int32;
                padrePais.Value = (object)entity.Pais ?? DBNull.Value;

                var padreEstado = _dataProvider.GetParameter();
                padreEstado.ParameterName = "Estado";
                padreEstado.DbType = DbType.Int32;
                padreEstado.Value = (object)entity.Estado ?? DBNull.Value;

                var padreOcupacion = _dataProvider.GetParameter();
                padreOcupacion.ParameterName = "Ocupacion";
                padreOcupacion.DbType = DbType.String;
                padreOcupacion.Value = (object)entity.Ocupacion ?? DBNull.Value;
                var padreCantidad_hijos = _dataProvider.GetParameter();
                padreCantidad_hijos.ParameterName = "Cantidad_hijos";
                padreCantidad_hijos.DbType = DbType.Int32;
                padreCantidad_hijos.Value = (object)entity.Cantidad_hijos ?? DBNull.Value;

                var padreObjetivo = _dataProvider.GetParameter();
                padreObjetivo.ParameterName = "Objetivo";
                padreObjetivo.DbType = DbType.Int32;
                padreObjetivo.Value = (object)entity.Objetivo ?? DBNull.Value;

                var padreEstatus_Paciente = _dataProvider.GetParameter();
                padreEstatus_Paciente.ParameterName = "Estatus_Paciente";
                padreEstatus_Paciente.DbType = DbType.Int32;
                padreEstatus_Paciente.Value = (object)entity.Estatus_Paciente ?? DBNull.Value;

                var padreCuenta_con_padecimientos = _dataProvider.GetParameter();
                padreCuenta_con_padecimientos.ParameterName = "Cuenta_con_padecimientos";
                padreCuenta_con_padecimientos.DbType = DbType.Int32;
                padreCuenta_con_padecimientos.Value = (object)entity.Cuenta_con_padecimientos ?? DBNull.Value;

                var padreFrecuencia_Cardiaca = _dataProvider.GetParameter();
                padreFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                padreFrecuencia_Cardiaca.DbType = DbType.Int32;
                padreFrecuencia_Cardiaca.Value = (object)entity.Frecuencia_Cardiaca ?? DBNull.Value;

                var padreFrecuencia_Respiratoria = _dataProvider.GetParameter();
                padreFrecuencia_Respiratoria.ParameterName = "Frecuencia_Respiratoria";
                padreFrecuencia_Respiratoria.DbType = DbType.Int32;
                padreFrecuencia_Respiratoria.Value = (object)entity.Frecuencia_Respiratoria ?? DBNull.Value;

                var padrePresion_sistolica = _dataProvider.GetParameter();
                padrePresion_sistolica.ParameterName = "Presion_sistolica";
                padrePresion_sistolica.DbType = DbType.Int32;
                padrePresion_sistolica.Value = (object)entity.Presion_sistolica ?? DBNull.Value;

                var padrePresion_diastolica = _dataProvider.GetParameter();
                padrePresion_diastolica.ParameterName = "Presion_diastolica";
                padrePresion_diastolica.DbType = DbType.Int32;
                padrePresion_diastolica.Value = (object)entity.Presion_diastolica ?? DBNull.Value;

                var padrePeso_actual = _dataProvider.GetParameter();
                padrePeso_actual.ParameterName = "Peso_actual";
                padrePeso_actual.DbType = DbType.Decimal;
                padrePeso_actual.Value = (object)entity.Peso_actual ?? DBNull.Value;

                var padreEstatura = _dataProvider.GetParameter();
                padreEstatura.ParameterName = "Estatura";
                padreEstatura.DbType = DbType.Decimal;
                padreEstatura.Value = (object)entity.Estatura ?? DBNull.Value;

                var padrePeso_habitual = _dataProvider.GetParameter();
                padrePeso_habitual.ParameterName = "Peso_habitual";
                padrePeso_habitual.DbType = DbType.Decimal;
                padrePeso_habitual.Value = (object)entity.Peso_habitual ?? DBNull.Value;

                var padreCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                padreCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                padreCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                padreCircunferencia_de_cintura_cm.Value = (object)entity.Circunferencia_de_cintura_cm ?? DBNull.Value;

                var padreCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                padreCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                padreCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                padreCircunferencia_de_cadera_cm.Value = (object)entity.Circunferencia_de_cadera_cm ?? DBNull.Value;

                var padreAnchura_de_muneca_mm = _dataProvider.GetParameter();
                padreAnchura_de_muneca_mm.ParameterName = "Anchura_de_muneca_mm";
                padreAnchura_de_muneca_mm.DbType = DbType.Int32;
                padreAnchura_de_muneca_mm.Value = (object)entity.Anchura_de_muneca_mm ?? DBNull.Value;

                var padreCircunferencia_de_brazo_cm = _dataProvider.GetParameter();
                padreCircunferencia_de_brazo_cm.ParameterName = "Circunferencia_de_brazo_cm";
                padreCircunferencia_de_brazo_cm.DbType = DbType.Int32;
                padreCircunferencia_de_brazo_cm.Value = (object)entity.Circunferencia_de_brazo_cm ?? DBNull.Value;

                var padrePliegue_cutaneo_tricipital_mm = _dataProvider.GetParameter();
                padrePliegue_cutaneo_tricipital_mm.ParameterName = "Pliegue_cutaneo_tricipital_mm";
                padrePliegue_cutaneo_tricipital_mm.DbType = DbType.Int32;
                padrePliegue_cutaneo_tricipital_mm.Value = (object)entity.Pliegue_cutaneo_tricipital_mm ?? DBNull.Value;

                var padrePliegue_cutaneo_bicipital_mm = _dataProvider.GetParameter();
                padrePliegue_cutaneo_bicipital_mm.ParameterName = "Pliegue_cutaneo_bicipital_mm";
                padrePliegue_cutaneo_bicipital_mm.DbType = DbType.Int32;
                padrePliegue_cutaneo_bicipital_mm.Value = (object)entity.Pliegue_cutaneo_bicipital_mm ?? DBNull.Value;

                var padrePliegue_cutaneo_subescapular_mm = _dataProvider.GetParameter();
                padrePliegue_cutaneo_subescapular_mm.ParameterName = "Pliegue_cutaneo_subescapular_mm";
                padrePliegue_cutaneo_subescapular_mm.DbType = DbType.Int32;
                padrePliegue_cutaneo_subescapular_mm.Value = (object)entity.Pliegue_cutaneo_subescapular_mm ?? DBNull.Value;

                var padrePliegue_cutaneo_supraespinal_mm = _dataProvider.GetParameter();
                padrePliegue_cutaneo_supraespinal_mm.ParameterName = "Pliegue_cutaneo_supraespinal_mm";
                padrePliegue_cutaneo_supraespinal_mm.DbType = DbType.Int32;
                padrePliegue_cutaneo_supraespinal_mm.Value = (object)entity.Pliegue_cutaneo_supraespinal_mm ?? DBNull.Value;

                var padreEdad_Metabolica = _dataProvider.GetParameter();
                padreEdad_Metabolica.ParameterName = "Edad_Metabolica";
                padreEdad_Metabolica.DbType = DbType.Int32;
                padreEdad_Metabolica.Value = (object)entity.Edad_Metabolica ?? DBNull.Value;

                var padreAgua_corporal = _dataProvider.GetParameter();
                padreAgua_corporal.ParameterName = "Agua_corporal";
                padreAgua_corporal.DbType = DbType.Int32;
                padreAgua_corporal.Value = (object)entity.Agua_corporal ?? DBNull.Value;

                var padreGrasa_Visceral = _dataProvider.GetParameter();
                padreGrasa_Visceral.ParameterName = "Grasa_Visceral";
                padreGrasa_Visceral.DbType = DbType.Int32;
                padreGrasa_Visceral.Value = (object)entity.Grasa_Visceral ?? DBNull.Value;

                var padreGrasa_Corporal = _dataProvider.GetParameter();
                padreGrasa_Corporal.ParameterName = "Grasa_Corporal";
                padreGrasa_Corporal.DbType = DbType.Int32;
                padreGrasa_Corporal.Value = (object)entity.Grasa_Corporal ?? DBNull.Value;

                var padreGrasa_Corporal_kg = _dataProvider.GetParameter();
                padreGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                padreGrasa_Corporal_kg.DbType = DbType.Int32;
                padreGrasa_Corporal_kg.Value = (object)entity.Grasa_Corporal_kg ?? DBNull.Value;

                var padreMasa_Muscular_kg = _dataProvider.GetParameter();
                padreMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                padreMasa_Muscular_kg.DbType = DbType.Int32;
                padreMasa_Muscular_kg.Value = (object)entity.Masa_Muscular_kg ?? DBNull.Value;

                var padreMasa_Muscular_ = _dataProvider.GetParameter();
                padreMasa_Muscular_.ParameterName = "Masa_Muscular_";
                padreMasa_Muscular_.DbType = DbType.Int32;
                padreMasa_Muscular_.Value = (object)entity.Masa_Muscular_ ?? DBNull.Value;

                var padreEsta_embarazada = _dataProvider.GetParameter();
                padreEsta_embarazada.ParameterName = "Esta_embarazada";
                padreEsta_embarazada.DbType = DbType.Int32;
                padreEsta_embarazada.Value = (object)entity.Esta_embarazada ?? DBNull.Value;

                var padreSemana_de_gestacion = _dataProvider.GetParameter();
                padreSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                padreSemana_de_gestacion.DbType = DbType.Int32;
                padreSemana_de_gestacion.Value = (object)entity.Semana_de_gestacion ?? DBNull.Value;

                var padrePeso_pregestacional = _dataProvider.GetParameter();
                padrePeso_pregestacional.ParameterName = "Peso_pregestacional";
                padrePeso_pregestacional.DbType = DbType.Int32;
                padrePeso_pregestacional.Value = (object)entity.Peso_pregestacional ?? DBNull.Value;

                var padreToma_anticonceptivos = _dataProvider.GetParameter();
                padreToma_anticonceptivos.ParameterName = "Toma_anticonceptivos";
                padreToma_anticonceptivos.DbType = DbType.Int32;
                padreToma_anticonceptivos.Value = (object)entity.Toma_anticonceptivos ?? DBNull.Value;

                var padreNombre_del_Anticonceptivo = _dataProvider.GetParameter();
                padreNombre_del_Anticonceptivo.ParameterName = "Nombre_del_Anticonceptivo";
                padreNombre_del_Anticonceptivo.DbType = DbType.String;
                padreNombre_del_Anticonceptivo.Value = (object)entity.Nombre_del_Anticonceptivo ?? DBNull.Value;
                var padreDosis = _dataProvider.GetParameter();
                padreDosis.ParameterName = "Dosis";
                padreDosis.DbType = DbType.String;
                padreDosis.Value = (object)entity.Dosis ?? DBNull.Value;
                var padreClimaterio = _dataProvider.GetParameter();
                padreClimaterio.ParameterName = "Climaterio";
                padreClimaterio.DbType = DbType.Int32;
                padreClimaterio.Value = (object)entity.Climaterio ?? DBNull.Value;

                var padreFecha_Climaterio = _dataProvider.GetParameter();
                padreFecha_Climaterio.ParameterName = "Fecha_Climaterio";
                padreFecha_Climaterio.DbType = DbType.DateTime;
                padreFecha_Climaterio.Value = (object)entity.Fecha_Climaterio ?? DBNull.Value;

                var padreTerapia_reemplazo_hormonal = _dataProvider.GetParameter();
                padreTerapia_reemplazo_hormonal.ParameterName = "Terapia_reemplazo_hormonal";
                padreTerapia_reemplazo_hormonal.DbType = DbType.Int32;
                padreTerapia_reemplazo_hormonal.Value = (object)entity.Terapia_reemplazo_hormonal ?? DBNull.Value;

                var padreTipo_Dieta = _dataProvider.GetParameter();
                padreTipo_Dieta.ParameterName = "Tipo_Dieta";
                padreTipo_Dieta.DbType = DbType.Int32;
                padreTipo_Dieta.Value = (object)entity.Tipo_Dieta ?? DBNull.Value;

                var padreSuplementos = _dataProvider.GetParameter();
                padreSuplementos.ParameterName = "Suplementos";
                padreSuplementos.DbType = DbType.Int32;
                padreSuplementos.Value = (object)entity.Suplementos ?? DBNull.Value;

                var padreConsumo_de_sal = _dataProvider.GetParameter();
                padreConsumo_de_sal.ParameterName = "Consumo_de_sal";
                padreConsumo_de_sal.DbType = DbType.Int32;
                padreConsumo_de_sal.Value = (object)entity.Consumo_de_sal ?? DBNull.Value;

                var padreGrasas_Preferencias = _dataProvider.GetParameter();
                padreGrasas_Preferencias.ParameterName = "Grasas_Preferencias";
                padreGrasas_Preferencias.DbType = DbType.Int32;
                padreGrasas_Preferencias.Value = (object)entity.Grasas_Preferencias ?? DBNull.Value;

                var padreComidas_cantidad = _dataProvider.GetParameter();
                padreComidas_cantidad.ParameterName = "Comidas_cantidad";
                padreComidas_cantidad.DbType = DbType.Int32;
                padreComidas_cantidad.Value = (object)entity.Comidas_cantidad ?? DBNull.Value;

                var padrePreparacion_Preferencias = _dataProvider.GetParameter();
                padrePreparacion_Preferencias.ParameterName = "Preparacion_Preferencias";
                padrePreparacion_Preferencias.DbType = DbType.Int32;
                padrePreparacion_Preferencias.Value = (object)entity.Preparacion_Preferencias ?? DBNull.Value;

                var padreEntre_comidas = _dataProvider.GetParameter();
                padreEntre_comidas.ParameterName = "Entre_comidas";
                padreEntre_comidas.DbType = DbType.Int32;
                padreEntre_comidas.Value = (object)entity.Entre_comidas ?? DBNull.Value;

                var padreApetito = _dataProvider.GetParameter();
                padreApetito.ParameterName = "Apetito";
                padreApetito.DbType = DbType.Int32;
                padreApetito.Value = (object)entity.Apetito ?? DBNull.Value;

                var padreHabitos_Modificacion = _dataProvider.GetParameter();
                padreHabitos_Modificacion.ParameterName = "Habitos_Modificacion";
                padreHabitos_Modificacion.DbType = DbType.Int32;
                padreHabitos_Modificacion.Value = (object)entity.Habitos_Modificacion ?? DBNull.Value;

                var padreHorario_hambre = _dataProvider.GetParameter();
                padreHorario_hambre.ParameterName = "Horario_hambre";
                padreHorario_hambre.DbType = DbType.Int32;
                padreHorario_hambre.Value = (object)entity.Horario_hambre ?? DBNull.Value;

                var padreCuando_cambia_mi_estado_de_animo = _dataProvider.GetParameter();
                padreCuando_cambia_mi_estado_de_animo.ParameterName = "Cuando_cambia_mi_estado_de_animo";
                padreCuando_cambia_mi_estado_de_animo.DbType = DbType.Int32;
                padreCuando_cambia_mi_estado_de_animo.Value = (object)entity.Cuando_cambia_mi_estado_de_animo ?? DBNull.Value;

                var padreMedicamentos_bajar_peso = _dataProvider.GetParameter();
                padreMedicamentos_bajar_peso.ParameterName = "Medicamentos_bajar_peso";
                padreMedicamentos_bajar_peso.DbType = DbType.Int32;
                padreMedicamentos_bajar_peso.Value = (object)entity.Medicamentos_bajar_peso ?? DBNull.Value;

                var padreCual_medicamento = _dataProvider.GetParameter();
                padreCual_medicamento.ParameterName = "Cual_medicamento";
                padreCual_medicamento.DbType = DbType.String;
                padreCual_medicamento.Value = (object)entity.Cual_medicamento ?? DBNull.Value;
                var padreFrecuencia_Ejercicio = _dataProvider.GetParameter();
                padreFrecuencia_Ejercicio.ParameterName = "Frecuencia_Ejercicio";
                padreFrecuencia_Ejercicio.DbType = DbType.Int32;
                padreFrecuencia_Ejercicio.Value = (object)entity.Frecuencia_Ejercicio ?? DBNull.Value;

                var padreDuracion_Ejercicio = _dataProvider.GetParameter();
                padreDuracion_Ejercicio.ParameterName = "Duracion_Ejercicio";
                padreDuracion_Ejercicio.DbType = DbType.Int32;
                padreDuracion_Ejercicio.Value = (object)entity.Duracion_Ejercicio ?? DBNull.Value;

                var padreTipo_Ejercicio = _dataProvider.GetParameter();
                padreTipo_Ejercicio.ParameterName = "Tipo_Ejercicio";
                padreTipo_Ejercicio.DbType = DbType.Int32;
                padreTipo_Ejercicio.Value = (object)entity.Tipo_Ejercicio ?? DBNull.Value;

                var padreAntiguedad_Ejercicio = _dataProvider.GetParameter();
                padreAntiguedad_Ejercicio.ParameterName = "Antiguedad_Ejercicio";
                padreAntiguedad_Ejercicio.DbType = DbType.Int32;
                padreAntiguedad_Ejercicio.Value = (object)entity.Antiguedad_Ejercicio ?? DBNull.Value;

                var padreIMC = _dataProvider.GetParameter();
                padreIMC.ParameterName = "IMC";
                padreIMC.DbType = DbType.Int32;
                padreIMC.Value = (object)entity.IMC ?? DBNull.Value;

                var padreInterpretacion_IMC = _dataProvider.GetParameter();
                padreInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                padreInterpretacion_IMC.DbType = DbType.Int32;
                padreInterpretacion_IMC.Value = (object)entity.Interpretacion_IMC ?? DBNull.Value;

                var padreIMC_Pediatria = _dataProvider.GetParameter();
                padreIMC_Pediatria.ParameterName = "IMC_Pediatria";
                padreIMC_Pediatria.DbType = DbType.Int32;
                padreIMC_Pediatria.Value = (object)entity.IMC_Pediatria ?? DBNull.Value;

                var padreComplexion_corporal = _dataProvider.GetParameter();
                padreComplexion_corporal.ParameterName = "Complexion_corporal";
                padreComplexion_corporal.DbType = DbType.String;
                padreComplexion_corporal.Value = (object)entity.Complexion_corporal ?? DBNull.Value;
                var padreInterpretacion_complexion_corporal = _dataProvider.GetParameter();
                padreInterpretacion_complexion_corporal.ParameterName = "Interpretacion_complexion_corporal";
                padreInterpretacion_complexion_corporal.DbType = DbType.Int32;
                padreInterpretacion_complexion_corporal.Value = (object)entity.Interpretacion_complexion_corporal ?? DBNull.Value;

                var padreDistribucion_de_grasa_corporal = _dataProvider.GetParameter();
                padreDistribucion_de_grasa_corporal.ParameterName = "Distribucion_de_grasa_corporal";
                padreDistribucion_de_grasa_corporal.DbType = DbType.String;
                padreDistribucion_de_grasa_corporal.Value = (object)entity.Distribucion_de_grasa_corporal ?? DBNull.Value;
                var padreInterpretacion_grasa_corporal = _dataProvider.GetParameter();
                padreInterpretacion_grasa_corporal.ParameterName = "Interpretacion_grasa_corporal";
                padreInterpretacion_grasa_corporal.DbType = DbType.Int32;
                padreInterpretacion_grasa_corporal.Value = (object)entity.Interpretacion_grasa_corporal ?? DBNull.Value;

                var padreIndice_cintura_cadera = _dataProvider.GetParameter();
                padreIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                padreIndice_cintura_cadera.DbType = DbType.String;
                padreIndice_cintura_cadera.Value = (object)entity.Indice_cintura_cadera ?? DBNull.Value;
                var padreInterpretacion_indice = _dataProvider.GetParameter();
                padreInterpretacion_indice.ParameterName = "Interpretacion_indice";
                padreInterpretacion_indice.DbType = DbType.Int32;
                padreInterpretacion_indice.Value = (object)entity.Interpretacion_indice ?? DBNull.Value;

                var padreConsumo_de_agua_resultado = _dataProvider.GetParameter();
                padreConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                padreConsumo_de_agua_resultado.DbType = DbType.String;
                padreConsumo_de_agua_resultado.Value = (object)entity.Consumo_de_agua_resultado ?? DBNull.Value;
                var padreInterpretacion_agua = _dataProvider.GetParameter();
                padreInterpretacion_agua.ParameterName = "Interpretacion_agua";
                padreInterpretacion_agua.DbType = DbType.Int32;
                padreInterpretacion_agua.Value = (object)entity.Interpretacion_agua ?? DBNull.Value;

                var padreFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                padreFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                padreFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                padreFrecuencia_cardiaca_en_Esfuerzo.Value = (object)entity.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;

                var padreInterpretacion_frecuencia = _dataProvider.GetParameter();
                padreInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                padreInterpretacion_frecuencia.DbType = DbType.Int32;
                padreInterpretacion_frecuencia.Value = (object)entity.Interpretacion_frecuencia ?? DBNull.Value;

                var padreDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                padreDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                padreDificultad_de_Rutina_de_Ejercicios.DbType = DbType.String;
                padreDificultad_de_Rutina_de_Ejercicios.Value = (object)entity.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
                var padreInterpretacion_dificultad = _dataProvider.GetParameter();
                padreInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                padreInterpretacion_dificultad.DbType = DbType.Int32;
                padreInterpretacion_dificultad.Value = (object)entity.Interpretacion_dificultad ?? DBNull.Value;

                var padreCalorias = _dataProvider.GetParameter();
                padreCalorias.ParameterName = "Calorias";
                padreCalorias.DbType = DbType.Int32;
                padreCalorias.Value = (object)entity.Calorias ?? DBNull.Value;

                var padreInterpretacion_calorias = _dataProvider.GetParameter();
                padreInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                padreInterpretacion_calorias.DbType = DbType.Int32;
                padreInterpretacion_calorias.Value = (object)entity.Interpretacion_calorias ?? DBNull.Value;

                var padreObservaciones = _dataProvider.GetParameter();
                padreObservaciones.ParameterName = "Observaciones";
                padreObservaciones.DbType = DbType.String;
                padreObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPacientes>("sp_InsPacientes" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreTipo_de_Registro
, padreTipo_de_Paciente
, padreUsuario_Registrado
, padreEmpresa
, padreNumero_de_Empleado
, padreNombres
, padreApellido_Paterno
, padreApellido_Materno
, padreNombre_Completo
, padreCelular
, padreEmail
, padreFecha_de_nacimiento
, padreNombre_del_Padre_o_Tutor
, padrePais_de_nacimiento
, padreLugar_de_nacimiento
, padreSexo
, padreEstado_Civil
, padreCalle
, padreNumero_exterior
, padreNumero_interior
, padreColonia
, padreCP
, padreCiudad
, padrePais
, padreEstado
, padreOcupacion
, padreCantidad_hijos
, padreObjetivo
, padreEstatus_Paciente
, padreCuenta_con_padecimientos
, padreFrecuencia_Cardiaca
, padreFrecuencia_Respiratoria
, padrePresion_sistolica
, padrePresion_diastolica
, padrePeso_actual
, padreEstatura
, padrePeso_habitual
, padreCircunferencia_de_cintura_cm
, padreCircunferencia_de_cadera_cm
, padreAnchura_de_muneca_mm
, padreCircunferencia_de_brazo_cm
, padrePliegue_cutaneo_tricipital_mm
, padrePliegue_cutaneo_bicipital_mm
, padrePliegue_cutaneo_subescapular_mm
, padrePliegue_cutaneo_supraespinal_mm
, padreEdad_Metabolica
, padreAgua_corporal
, padreGrasa_Visceral
, padreGrasa_Corporal
, padreGrasa_Corporal_kg
, padreMasa_Muscular_kg
, padreMasa_Muscular_
, padreEsta_embarazada
, padreSemana_de_gestacion
, padrePeso_pregestacional
, padreToma_anticonceptivos
, padreNombre_del_Anticonceptivo
, padreDosis
, padreClimaterio
, padreFecha_Climaterio
, padreTerapia_reemplazo_hormonal
, padreTipo_Dieta
, padreSuplementos
, padreConsumo_de_sal
, padreGrasas_Preferencias
, padreComidas_cantidad
, padrePreparacion_Preferencias
, padreEntre_comidas
, padreApetito
, padreHabitos_Modificacion
, padreHorario_hambre
, padreCuando_cambia_mi_estado_de_animo
, padreMedicamentos_bajar_peso
, padreCual_medicamento
, padreFrecuencia_Ejercicio
, padreDuracion_Ejercicio
, padreTipo_Ejercicio
, padreAntiguedad_Ejercicio
, padreIMC
, padreInterpretacion_IMC
, padreIMC_Pediatria
, padreComplexion_corporal
, padreInterpretacion_complexion_corporal
, padreDistribucion_de_grasa_corporal
, padreInterpretacion_grasa_corporal
, padreIndice_cintura_cadera
, padreInterpretacion_indice
, padreConsumo_de_agua_resultado
, padreInterpretacion_agua
, padreFrecuencia_cardiaca_en_Esfuerzo
, padreInterpretacion_frecuencia
, padreDificultad_de_Rutina_de_Ejercicios
, padreInterpretacion_dificultad
, padreCalorias
, padreInterpretacion_calorias
, padreObservaciones
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);

            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Update(Spartane.Core.Classes.Pacientes.Pacientes entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var paramUpdTipo_de_Registro = _dataProvider.GetParameter();
                paramUpdTipo_de_Registro.ParameterName = "Tipo_de_Registro";
                paramUpdTipo_de_Registro.DbType = DbType.Int32;
                paramUpdTipo_de_Registro.Value = (object)entity.Tipo_de_Registro ?? DBNull.Value;

                var paramUpdTipo_de_Paciente = _dataProvider.GetParameter();
                paramUpdTipo_de_Paciente.ParameterName = "Tipo_de_Paciente";
                paramUpdTipo_de_Paciente.DbType = DbType.Int32;
                paramUpdTipo_de_Paciente.Value = (object)entity.Tipo_de_Paciente ?? DBNull.Value;

                var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)entity.Usuario_Registrado ?? DBNull.Value;

                var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)entity.Empresa ?? DBNull.Value;

                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)entity.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)entity.Celular ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)entity.Fecha_de_nacimiento ?? DBNull.Value;

                var paramUpdNombre_del_Padre_o_Tutor = _dataProvider.GetParameter();
                paramUpdNombre_del_Padre_o_Tutor.ParameterName = "Nombre_del_Padre_o_Tutor";
                paramUpdNombre_del_Padre_o_Tutor.DbType = DbType.String;
                paramUpdNombre_del_Padre_o_Tutor.Value = (object)entity.Nombre_del_Padre_o_Tutor ?? DBNull.Value;
                var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)entity.Pais_de_nacimiento ?? DBNull.Value;

                var paramUpdLugar_de_nacimiento = _dataProvider.GetParameter();
                paramUpdLugar_de_nacimiento.ParameterName = "Lugar_de_nacimiento";
                paramUpdLugar_de_nacimiento.DbType = DbType.Int32;
                paramUpdLugar_de_nacimiento.Value = (object)entity.Lugar_de_nacimiento ?? DBNull.Value;

                var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var paramUpdEstado_Civil = _dataProvider.GetParameter();
                paramUpdEstado_Civil.ParameterName = "Estado_Civil";
                paramUpdEstado_Civil.DbType = DbType.Int32;
                paramUpdEstado_Civil.Value = (object)entity.Estado_Civil ?? DBNull.Value;

                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)entity.CP ?? DBNull.Value;

                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
                var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;

                var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)entity.Estado ?? DBNull.Value;

                var paramUpdOcupacion = _dataProvider.GetParameter();
                paramUpdOcupacion.ParameterName = "Ocupacion";
                paramUpdOcupacion.DbType = DbType.String;
                paramUpdOcupacion.Value = (object)entity.Ocupacion ?? DBNull.Value;
                var paramUpdCantidad_hijos = _dataProvider.GetParameter();
                paramUpdCantidad_hijos.ParameterName = "Cantidad_hijos";
                paramUpdCantidad_hijos.DbType = DbType.Int32;
                paramUpdCantidad_hijos.Value = (object)entity.Cantidad_hijos ?? DBNull.Value;

                var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)entity.Objetivo ?? DBNull.Value;

                var paramUpdEstatus_Paciente = _dataProvider.GetParameter();
                paramUpdEstatus_Paciente.ParameterName = "Estatus_Paciente";
                paramUpdEstatus_Paciente.DbType = DbType.Int32;
                paramUpdEstatus_Paciente.Value = (object)entity.Estatus_Paciente ?? DBNull.Value;

                var paramUpdCuenta_con_padecimientos = _dataProvider.GetParameter();
                paramUpdCuenta_con_padecimientos.ParameterName = "Cuenta_con_padecimientos";
                paramUpdCuenta_con_padecimientos.DbType = DbType.Int32;
                paramUpdCuenta_con_padecimientos.Value = (object)entity.Cuenta_con_padecimientos ?? DBNull.Value;

                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)entity.Frecuencia_Cardiaca ?? DBNull.Value;

                var paramUpdFrecuencia_Respiratoria = _dataProvider.GetParameter();
                paramUpdFrecuencia_Respiratoria.ParameterName = "Frecuencia_Respiratoria";
                paramUpdFrecuencia_Respiratoria.DbType = DbType.Int32;
                paramUpdFrecuencia_Respiratoria.Value = (object)entity.Frecuencia_Respiratoria ?? DBNull.Value;

                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)entity.Presion_sistolica ?? DBNull.Value;

                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)entity.Presion_diastolica ?? DBNull.Value;

                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)entity.Peso_actual ?? DBNull.Value;

                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)entity.Estatura ?? DBNull.Value;

                var paramUpdPeso_habitual = _dataProvider.GetParameter();
                paramUpdPeso_habitual.ParameterName = "Peso_habitual";
                paramUpdPeso_habitual.DbType = DbType.Decimal;
                paramUpdPeso_habitual.Value = (object)entity.Peso_habitual ?? DBNull.Value;

                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)entity.Circunferencia_de_cintura_cm ?? DBNull.Value;

                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)entity.Circunferencia_de_cadera_cm ?? DBNull.Value;

                var paramUpdAnchura_de_muneca_mm = _dataProvider.GetParameter();
                paramUpdAnchura_de_muneca_mm.ParameterName = "Anchura_de_muneca_mm";
                paramUpdAnchura_de_muneca_mm.DbType = DbType.Int32;
                paramUpdAnchura_de_muneca_mm.Value = (object)entity.Anchura_de_muneca_mm ?? DBNull.Value;

                var paramUpdCircunferencia_de_brazo_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_brazo_cm.ParameterName = "Circunferencia_de_brazo_cm";
                paramUpdCircunferencia_de_brazo_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_brazo_cm.Value = (object)entity.Circunferencia_de_brazo_cm ?? DBNull.Value;

                var paramUpdPliegue_cutaneo_tricipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_tricipital_mm.ParameterName = "Pliegue_cutaneo_tricipital_mm";
                paramUpdPliegue_cutaneo_tricipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_tricipital_mm.Value = (object)entity.Pliegue_cutaneo_tricipital_mm ?? DBNull.Value;

                var paramUpdPliegue_cutaneo_bicipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_bicipital_mm.ParameterName = "Pliegue_cutaneo_bicipital_mm";
                paramUpdPliegue_cutaneo_bicipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_bicipital_mm.Value = (object)entity.Pliegue_cutaneo_bicipital_mm ?? DBNull.Value;

                var paramUpdPliegue_cutaneo_subescapular_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_subescapular_mm.ParameterName = "Pliegue_cutaneo_subescapular_mm";
                paramUpdPliegue_cutaneo_subescapular_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_subescapular_mm.Value = (object)entity.Pliegue_cutaneo_subescapular_mm ?? DBNull.Value;

                var paramUpdPliegue_cutaneo_supraespinal_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_supraespinal_mm.ParameterName = "Pliegue_cutaneo_supraespinal_mm";
                paramUpdPliegue_cutaneo_supraespinal_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_supraespinal_mm.Value = (object)entity.Pliegue_cutaneo_supraespinal_mm ?? DBNull.Value;

                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)entity.Edad_Metabolica ?? DBNull.Value;

                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)entity.Agua_corporal ?? DBNull.Value;

                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)entity.Grasa_Visceral ?? DBNull.Value;

                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)entity.Grasa_Corporal ?? DBNull.Value;

                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)entity.Grasa_Corporal_kg ?? DBNull.Value;

                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)entity.Masa_Muscular_kg ?? DBNull.Value;

                var paramUpdMasa_Muscular_ = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_.ParameterName = "Masa_Muscular_";
                paramUpdMasa_Muscular_.DbType = DbType.Int32;
                paramUpdMasa_Muscular_.Value = (object)entity.Masa_Muscular_ ?? DBNull.Value;

                var paramUpdEsta_embarazada = _dataProvider.GetParameter();
                paramUpdEsta_embarazada.ParameterName = "Esta_embarazada";
                paramUpdEsta_embarazada.DbType = DbType.Int32;
                paramUpdEsta_embarazada.Value = (object)entity.Esta_embarazada ?? DBNull.Value;

                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)entity.Semana_de_gestacion ?? DBNull.Value;

                var paramUpdPeso_pregestacional = _dataProvider.GetParameter();
                paramUpdPeso_pregestacional.ParameterName = "Peso_pregestacional";
                paramUpdPeso_pregestacional.DbType = DbType.Int32;
                paramUpdPeso_pregestacional.Value = (object)entity.Peso_pregestacional ?? DBNull.Value;

                var paramUpdToma_anticonceptivos = _dataProvider.GetParameter();
                paramUpdToma_anticonceptivos.ParameterName = "Toma_anticonceptivos";
                paramUpdToma_anticonceptivos.DbType = DbType.Int32;
                paramUpdToma_anticonceptivos.Value = (object)entity.Toma_anticonceptivos ?? DBNull.Value;

                var paramUpdNombre_del_Anticonceptivo = _dataProvider.GetParameter();
                paramUpdNombre_del_Anticonceptivo.ParameterName = "Nombre_del_Anticonceptivo";
                paramUpdNombre_del_Anticonceptivo.DbType = DbType.String;
                paramUpdNombre_del_Anticonceptivo.Value = (object)entity.Nombre_del_Anticonceptivo ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)entity.Dosis ?? DBNull.Value;
                var paramUpdClimaterio = _dataProvider.GetParameter();
                paramUpdClimaterio.ParameterName = "Climaterio";
                paramUpdClimaterio.DbType = DbType.Int32;
                paramUpdClimaterio.Value = (object)entity.Climaterio ?? DBNull.Value;

                var paramUpdFecha_Climaterio = _dataProvider.GetParameter();
                paramUpdFecha_Climaterio.ParameterName = "Fecha_Climaterio";
                paramUpdFecha_Climaterio.DbType = DbType.DateTime;
                paramUpdFecha_Climaterio.Value = (object)entity.Fecha_Climaterio ?? DBNull.Value;

                var paramUpdTerapia_reemplazo_hormonal = _dataProvider.GetParameter();
                paramUpdTerapia_reemplazo_hormonal.ParameterName = "Terapia_reemplazo_hormonal";
                paramUpdTerapia_reemplazo_hormonal.DbType = DbType.Int32;
                paramUpdTerapia_reemplazo_hormonal.Value = (object)entity.Terapia_reemplazo_hormonal ?? DBNull.Value;

                var paramUpdTipo_Dieta = _dataProvider.GetParameter();
                paramUpdTipo_Dieta.ParameterName = "Tipo_Dieta";
                paramUpdTipo_Dieta.DbType = DbType.Int32;
                paramUpdTipo_Dieta.Value = (object)entity.Tipo_Dieta ?? DBNull.Value;

                var paramUpdSuplementos = _dataProvider.GetParameter();
                paramUpdSuplementos.ParameterName = "Suplementos";
                paramUpdSuplementos.DbType = DbType.Int32;
                paramUpdSuplementos.Value = (object)entity.Suplementos ?? DBNull.Value;

                var paramUpdConsumo_de_sal = _dataProvider.GetParameter();
                paramUpdConsumo_de_sal.ParameterName = "Consumo_de_sal";
                paramUpdConsumo_de_sal.DbType = DbType.Int32;
                paramUpdConsumo_de_sal.Value = (object)entity.Consumo_de_sal ?? DBNull.Value;

                var paramUpdGrasas_Preferencias = _dataProvider.GetParameter();
                paramUpdGrasas_Preferencias.ParameterName = "Grasas_Preferencias";
                paramUpdGrasas_Preferencias.DbType = DbType.Int32;
                paramUpdGrasas_Preferencias.Value = (object)entity.Grasas_Preferencias ?? DBNull.Value;

                var paramUpdComidas_cantidad = _dataProvider.GetParameter();
                paramUpdComidas_cantidad.ParameterName = "Comidas_cantidad";
                paramUpdComidas_cantidad.DbType = DbType.Int32;
                paramUpdComidas_cantidad.Value = (object)entity.Comidas_cantidad ?? DBNull.Value;

                var paramUpdPreparacion_Preferencias = _dataProvider.GetParameter();
                paramUpdPreparacion_Preferencias.ParameterName = "Preparacion_Preferencias";
                paramUpdPreparacion_Preferencias.DbType = DbType.Int32;
                paramUpdPreparacion_Preferencias.Value = (object)entity.Preparacion_Preferencias ?? DBNull.Value;

                var paramUpdEntre_comidas = _dataProvider.GetParameter();
                paramUpdEntre_comidas.ParameterName = "Entre_comidas";
                paramUpdEntre_comidas.DbType = DbType.Int32;
                paramUpdEntre_comidas.Value = (object)entity.Entre_comidas ?? DBNull.Value;

                var paramUpdApetito = _dataProvider.GetParameter();
                paramUpdApetito.ParameterName = "Apetito";
                paramUpdApetito.DbType = DbType.Int32;
                paramUpdApetito.Value = (object)entity.Apetito ?? DBNull.Value;

                var paramUpdHabitos_Modificacion = _dataProvider.GetParameter();
                paramUpdHabitos_Modificacion.ParameterName = "Habitos_Modificacion";
                paramUpdHabitos_Modificacion.DbType = DbType.Int32;
                paramUpdHabitos_Modificacion.Value = (object)entity.Habitos_Modificacion ?? DBNull.Value;

                var paramUpdHorario_hambre = _dataProvider.GetParameter();
                paramUpdHorario_hambre.ParameterName = "Horario_hambre";
                paramUpdHorario_hambre.DbType = DbType.Int32;
                paramUpdHorario_hambre.Value = (object)entity.Horario_hambre ?? DBNull.Value;

                var paramUpdCuando_cambia_mi_estado_de_animo = _dataProvider.GetParameter();
                paramUpdCuando_cambia_mi_estado_de_animo.ParameterName = "Cuando_cambia_mi_estado_de_animo";
                paramUpdCuando_cambia_mi_estado_de_animo.DbType = DbType.Int32;
                paramUpdCuando_cambia_mi_estado_de_animo.Value = (object)entity.Cuando_cambia_mi_estado_de_animo ?? DBNull.Value;

                var paramUpdMedicamentos_bajar_peso = _dataProvider.GetParameter();
                paramUpdMedicamentos_bajar_peso.ParameterName = "Medicamentos_bajar_peso";
                paramUpdMedicamentos_bajar_peso.DbType = DbType.Int32;
                paramUpdMedicamentos_bajar_peso.Value = (object)entity.Medicamentos_bajar_peso ?? DBNull.Value;

                var paramUpdCual_medicamento = _dataProvider.GetParameter();
                paramUpdCual_medicamento.ParameterName = "Cual_medicamento";
                paramUpdCual_medicamento.DbType = DbType.String;
                paramUpdCual_medicamento.Value = (object)entity.Cual_medicamento ?? DBNull.Value;
                var paramUpdFrecuencia_Ejercicio = _dataProvider.GetParameter();
                paramUpdFrecuencia_Ejercicio.ParameterName = "Frecuencia_Ejercicio";
                paramUpdFrecuencia_Ejercicio.DbType = DbType.Int32;
                paramUpdFrecuencia_Ejercicio.Value = (object)entity.Frecuencia_Ejercicio ?? DBNull.Value;

                var paramUpdDuracion_Ejercicio = _dataProvider.GetParameter();
                paramUpdDuracion_Ejercicio.ParameterName = "Duracion_Ejercicio";
                paramUpdDuracion_Ejercicio.DbType = DbType.Int32;
                paramUpdDuracion_Ejercicio.Value = (object)entity.Duracion_Ejercicio ?? DBNull.Value;

                var paramUpdTipo_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_Ejercicio.ParameterName = "Tipo_Ejercicio";
                paramUpdTipo_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_Ejercicio.Value = (object)entity.Tipo_Ejercicio ?? DBNull.Value;

                var paramUpdAntiguedad_Ejercicio = _dataProvider.GetParameter();
                paramUpdAntiguedad_Ejercicio.ParameterName = "Antiguedad_Ejercicio";
                paramUpdAntiguedad_Ejercicio.DbType = DbType.Int32;
                paramUpdAntiguedad_Ejercicio.Value = (object)entity.Antiguedad_Ejercicio ?? DBNull.Value;

                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)entity.IMC ?? DBNull.Value;

                var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)entity.Interpretacion_IMC ?? DBNull.Value;

                var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)entity.IMC_Pediatria ?? DBNull.Value;

                var paramUpdComplexion_corporal = _dataProvider.GetParameter();
                paramUpdComplexion_corporal.ParameterName = "Complexion_corporal";
                paramUpdComplexion_corporal.DbType = DbType.String;
                paramUpdComplexion_corporal.Value = (object)entity.Complexion_corporal ?? DBNull.Value;
                var paramUpdInterpretacion_complexion_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_complexion_corporal.ParameterName = "Interpretacion_complexion_corporal";
                paramUpdInterpretacion_complexion_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_complexion_corporal.Value = (object)entity.Interpretacion_complexion_corporal ?? DBNull.Value;

                var paramUpdDistribucion_de_grasa_corporal = _dataProvider.GetParameter();
                paramUpdDistribucion_de_grasa_corporal.ParameterName = "Distribucion_de_grasa_corporal";
                paramUpdDistribucion_de_grasa_corporal.DbType = DbType.String;
                paramUpdDistribucion_de_grasa_corporal.Value = (object)entity.Distribucion_de_grasa_corporal ?? DBNull.Value;
                var paramUpdInterpretacion_grasa_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_grasa_corporal.ParameterName = "Interpretacion_grasa_corporal";
                paramUpdInterpretacion_grasa_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_grasa_corporal.Value = (object)entity.Interpretacion_grasa_corporal ?? DBNull.Value;

                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.String;
                paramUpdIndice_cintura_cadera.Value = (object)entity.Indice_cintura_cadera ?? DBNull.Value;
                var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)entity.Interpretacion_indice ?? DBNull.Value;

                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.String;
                paramUpdConsumo_de_agua_resultado.Value = (object)entity.Consumo_de_agua_resultado ?? DBNull.Value;
                var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)entity.Interpretacion_agua ?? DBNull.Value;

                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)entity.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;

                var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)entity.Interpretacion_frecuencia ?? DBNull.Value;

                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.String;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)entity.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
                var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)entity.Interpretacion_dificultad ?? DBNull.Value;

                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)entity.Calorias ?? DBNull.Value;

                var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)entity.Interpretacion_calorias ?? DBNull.Value;

                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPacientes>("sp_UpdPacientes" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Registro , paramUpdTipo_de_Paciente , paramUpdUsuario_Registrado , paramUpdEmpresa , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdCelular , paramUpdEmail , paramUpdFecha_de_nacimiento , paramUpdNombre_del_Padre_o_Tutor , paramUpdPais_de_nacimiento , paramUpdLugar_de_nacimiento , paramUpdSexo , paramUpdEstado_Civil , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdPais , paramUpdEstado , paramUpdOcupacion , paramUpdCantidad_hijos , paramUpdObjetivo , paramUpdEstatus_Paciente , paramUpdCuenta_con_padecimientos , paramUpdFrecuencia_Cardiaca , paramUpdFrecuencia_Respiratoria , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdPeso_habitual , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdAnchura_de_muneca_mm , paramUpdCircunferencia_de_brazo_cm , paramUpdPliegue_cutaneo_tricipital_mm , paramUpdPliegue_cutaneo_bicipital_mm , paramUpdPliegue_cutaneo_subescapular_mm , paramUpdPliegue_cutaneo_supraespinal_mm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdMasa_Muscular_ , paramUpdEsta_embarazada , paramUpdSemana_de_gestacion , paramUpdPeso_pregestacional , paramUpdToma_anticonceptivos , paramUpdNombre_del_Anticonceptivo , paramUpdDosis , paramUpdClimaterio , paramUpdFecha_Climaterio , paramUpdTerapia_reemplazo_hormonal , paramUpdTipo_Dieta , paramUpdSuplementos , paramUpdConsumo_de_sal , paramUpdGrasas_Preferencias , paramUpdComidas_cantidad , paramUpdPreparacion_Preferencias , paramUpdEntre_comidas , paramUpdApetito , paramUpdHabitos_Modificacion , paramUpdHorario_hambre , paramUpdCuando_cambia_mi_estado_de_animo , paramUpdMedicamentos_bajar_peso , paramUpdCual_medicamento , paramUpdFrecuencia_Ejercicio , paramUpdDuracion_Ejercicio , paramUpdTipo_Ejercicio , paramUpdAntiguedad_Ejercicio , paramUpdIMC , paramUpdInterpretacion_IMC , paramUpdIMC_Pediatria , paramUpdComplexion_corporal , paramUpdInterpretacion_complexion_corporal , paramUpdDistribucion_de_grasa_corporal , paramUpdInterpretacion_grasa_corporal , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }
		public int Update_Datos_Generales(Spartane.Core.Classes.Pacientes.Pacientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Pacientes.Pacientes PacientesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdTipo_de_Registro = _dataProvider.GetParameter();
                paramUpdTipo_de_Registro.ParameterName = "Tipo_de_Registro";
                paramUpdTipo_de_Registro.DbType = DbType.Int32;
                paramUpdTipo_de_Registro.Value = (object)entity.Tipo_de_Registro ?? DBNull.Value;
		var paramUpdTipo_de_Paciente = _dataProvider.GetParameter();
                paramUpdTipo_de_Paciente.ParameterName = "Tipo_de_Paciente";
                paramUpdTipo_de_Paciente.DbType = DbType.Int32;
                paramUpdTipo_de_Paciente.Value = (object)entity.Tipo_de_Paciente ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)entity.Usuario_Registrado ?? DBNull.Value;
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)entity.Empresa ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)entity.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)entity.Celular ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)entity.Fecha_de_nacimiento ?? DBNull.Value;
                var paramUpdNombre_del_Padre_o_Tutor = _dataProvider.GetParameter();
                paramUpdNombre_del_Padre_o_Tutor.ParameterName = "Nombre_del_Padre_o_Tutor";
                paramUpdNombre_del_Padre_o_Tutor.DbType = DbType.String;
                paramUpdNombre_del_Padre_o_Tutor.Value = (object)entity.Nombre_del_Padre_o_Tutor ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)entity.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdLugar_de_nacimiento = _dataProvider.GetParameter();
                paramUpdLugar_de_nacimiento.ParameterName = "Lugar_de_nacimiento";
                paramUpdLugar_de_nacimiento.DbType = DbType.Int32;
                paramUpdLugar_de_nacimiento.Value = (object)entity.Lugar_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;
		var paramUpdEstado_Civil = _dataProvider.GetParameter();
                paramUpdEstado_Civil.ParameterName = "Estado_Civil";
                paramUpdEstado_Civil.DbType = DbType.Int32;
                paramUpdEstado_Civil.Value = (object)entity.Estado_Civil ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)entity.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)entity.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)entity.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)entity.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)entity.Ciudad ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)entity.Estado ?? DBNull.Value;
                var paramUpdOcupacion = _dataProvider.GetParameter();
                paramUpdOcupacion.ParameterName = "Ocupacion";
                paramUpdOcupacion.DbType = DbType.String;
                paramUpdOcupacion.Value = (object)entity.Ocupacion ?? DBNull.Value;
                var paramUpdCantidad_hijos = _dataProvider.GetParameter();
                paramUpdCantidad_hijos.ParameterName = "Cantidad_hijos";
                paramUpdCantidad_hijos.DbType = DbType.Int32;
                paramUpdCantidad_hijos.Value = (object)entity.Cantidad_hijos ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)entity.Objetivo ?? DBNull.Value;
		var paramUpdEstatus_Paciente = _dataProvider.GetParameter();
                paramUpdEstatus_Paciente.ParameterName = "Estatus_Paciente";
                paramUpdEstatus_Paciente.DbType = DbType.Int32;
                paramUpdEstatus_Paciente.Value = (object)entity.Estatus_Paciente ?? DBNull.Value;
		var paramUpdCuenta_con_padecimientos = _dataProvider.GetParameter();
                paramUpdCuenta_con_padecimientos.ParameterName = "Cuenta_con_padecimientos";
                paramUpdCuenta_con_padecimientos.DbType = DbType.Int32;
                paramUpdCuenta_con_padecimientos.Value = (object)PacientesDB.Cuenta_con_padecimientos ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)PacientesDB.Frecuencia_Cardiaca ?? DBNull.Value;
                var paramUpdFrecuencia_Respiratoria = _dataProvider.GetParameter();
                paramUpdFrecuencia_Respiratoria.ParameterName = "Frecuencia_Respiratoria";
                paramUpdFrecuencia_Respiratoria.DbType = DbType.Int32;
                paramUpdFrecuencia_Respiratoria.Value = (object)PacientesDB.Frecuencia_Respiratoria ?? DBNull.Value;
                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)PacientesDB.Presion_sistolica ?? DBNull.Value;
                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)PacientesDB.Presion_diastolica ?? DBNull.Value;
                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)PacientesDB.Peso_actual ?? DBNull.Value;
                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)PacientesDB.Estatura ?? DBNull.Value;
                var paramUpdPeso_habitual = _dataProvider.GetParameter();
                paramUpdPeso_habitual.ParameterName = "Peso_habitual";
                paramUpdPeso_habitual.DbType = DbType.Decimal;
                paramUpdPeso_habitual.Value = (object)PacientesDB.Peso_habitual ?? DBNull.Value;
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)PacientesDB.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)PacientesDB.Circunferencia_de_cadera_cm ?? DBNull.Value;
                var paramUpdAnchura_de_muneca_mm = _dataProvider.GetParameter();
                paramUpdAnchura_de_muneca_mm.ParameterName = "Anchura_de_muneca_mm";
                paramUpdAnchura_de_muneca_mm.DbType = DbType.Int32;
                paramUpdAnchura_de_muneca_mm.Value = (object)PacientesDB.Anchura_de_muneca_mm ?? DBNull.Value;
                var paramUpdCircunferencia_de_brazo_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_brazo_cm.ParameterName = "Circunferencia_de_brazo_cm";
                paramUpdCircunferencia_de_brazo_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_brazo_cm.Value = (object)PacientesDB.Circunferencia_de_brazo_cm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_tricipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_tricipital_mm.ParameterName = "Pliegue_cutaneo_tricipital_mm";
                paramUpdPliegue_cutaneo_tricipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_tricipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_tricipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_bicipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_bicipital_mm.ParameterName = "Pliegue_cutaneo_bicipital_mm";
                paramUpdPliegue_cutaneo_bicipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_bicipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_bicipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_subescapular_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_subescapular_mm.ParameterName = "Pliegue_cutaneo_subescapular_mm";
                paramUpdPliegue_cutaneo_subescapular_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_subescapular_mm.Value = (object)PacientesDB.Pliegue_cutaneo_subescapular_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_supraespinal_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_supraespinal_mm.ParameterName = "Pliegue_cutaneo_supraespinal_mm";
                paramUpdPliegue_cutaneo_supraespinal_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_supraespinal_mm.Value = (object)PacientesDB.Pliegue_cutaneo_supraespinal_mm ?? DBNull.Value;
                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)PacientesDB.Edad_Metabolica ?? DBNull.Value;
                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)PacientesDB.Agua_corporal ?? DBNull.Value;
                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)PacientesDB.Grasa_Visceral ?? DBNull.Value;
                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)PacientesDB.Grasa_Corporal ?? DBNull.Value;
                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)PacientesDB.Grasa_Corporal_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)PacientesDB.Masa_Muscular_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_ = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_.ParameterName = "Masa_Muscular_";
                paramUpdMasa_Muscular_.DbType = DbType.Int32;
                paramUpdMasa_Muscular_.Value = (object)PacientesDB.Masa_Muscular_ ?? DBNull.Value;
		var paramUpdEsta_embarazada = _dataProvider.GetParameter();
                paramUpdEsta_embarazada.ParameterName = "Esta_embarazada";
                paramUpdEsta_embarazada.DbType = DbType.Int32;
                paramUpdEsta_embarazada.Value = (object)PacientesDB.Esta_embarazada ?? DBNull.Value;
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)PacientesDB.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdPeso_pregestacional = _dataProvider.GetParameter();
                paramUpdPeso_pregestacional.ParameterName = "Peso_pregestacional";
                paramUpdPeso_pregestacional.DbType = DbType.Int32;
                paramUpdPeso_pregestacional.Value = (object)PacientesDB.Peso_pregestacional ?? DBNull.Value;
		var paramUpdToma_anticonceptivos = _dataProvider.GetParameter();
                paramUpdToma_anticonceptivos.ParameterName = "Toma_anticonceptivos";
                paramUpdToma_anticonceptivos.DbType = DbType.Int32;
                paramUpdToma_anticonceptivos.Value = (object)PacientesDB.Toma_anticonceptivos ?? DBNull.Value;
                var paramUpdNombre_del_Anticonceptivo = _dataProvider.GetParameter();
                paramUpdNombre_del_Anticonceptivo.ParameterName = "Nombre_del_Anticonceptivo";
                paramUpdNombre_del_Anticonceptivo.DbType = DbType.String;
                paramUpdNombre_del_Anticonceptivo.Value = (object)PacientesDB.Nombre_del_Anticonceptivo ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)PacientesDB.Dosis ?? DBNull.Value;
		var paramUpdClimaterio = _dataProvider.GetParameter();
                paramUpdClimaterio.ParameterName = "Climaterio";
                paramUpdClimaterio.DbType = DbType.Int32;
                paramUpdClimaterio.Value = (object)PacientesDB.Climaterio ?? DBNull.Value;
                var paramUpdFecha_Climaterio = _dataProvider.GetParameter();
                paramUpdFecha_Climaterio.ParameterName = "Fecha_Climaterio";
                paramUpdFecha_Climaterio.DbType = DbType.DateTime;
                paramUpdFecha_Climaterio.Value = (object)PacientesDB.Fecha_Climaterio ?? DBNull.Value;
		var paramUpdTerapia_reemplazo_hormonal = _dataProvider.GetParameter();
                paramUpdTerapia_reemplazo_hormonal.ParameterName = "Terapia_reemplazo_hormonal";
                paramUpdTerapia_reemplazo_hormonal.DbType = DbType.Int32;
                paramUpdTerapia_reemplazo_hormonal.Value = (object)PacientesDB.Terapia_reemplazo_hormonal ?? DBNull.Value;
		var paramUpdTipo_Dieta = _dataProvider.GetParameter();
                paramUpdTipo_Dieta.ParameterName = "Tipo_Dieta";
                paramUpdTipo_Dieta.DbType = DbType.Int32;
                paramUpdTipo_Dieta.Value = (object)PacientesDB.Tipo_Dieta ?? DBNull.Value;
		var paramUpdSuplementos = _dataProvider.GetParameter();
                paramUpdSuplementos.ParameterName = "Suplementos";
                paramUpdSuplementos.DbType = DbType.Int32;
                paramUpdSuplementos.Value = (object)PacientesDB.Suplementos ?? DBNull.Value;
		var paramUpdConsumo_de_sal = _dataProvider.GetParameter();
                paramUpdConsumo_de_sal.ParameterName = "Consumo_de_sal";
                paramUpdConsumo_de_sal.DbType = DbType.Int32;
                paramUpdConsumo_de_sal.Value = (object)PacientesDB.Consumo_de_sal ?? DBNull.Value;
		var paramUpdGrasas_Preferencias = _dataProvider.GetParameter();
                paramUpdGrasas_Preferencias.ParameterName = "Grasas_Preferencias";
                paramUpdGrasas_Preferencias.DbType = DbType.Int32;
                paramUpdGrasas_Preferencias.Value = (object)PacientesDB.Grasas_Preferencias ?? DBNull.Value;
		var paramUpdComidas_cantidad = _dataProvider.GetParameter();
                paramUpdComidas_cantidad.ParameterName = "Comidas_cantidad";
                paramUpdComidas_cantidad.DbType = DbType.Int32;
                paramUpdComidas_cantidad.Value = (object)PacientesDB.Comidas_cantidad ?? DBNull.Value;
		var paramUpdPreparacion_Preferencias = _dataProvider.GetParameter();
                paramUpdPreparacion_Preferencias.ParameterName = "Preparacion_Preferencias";
                paramUpdPreparacion_Preferencias.DbType = DbType.Int32;
                paramUpdPreparacion_Preferencias.Value = (object)PacientesDB.Preparacion_Preferencias ?? DBNull.Value;
		var paramUpdEntre_comidas = _dataProvider.GetParameter();
                paramUpdEntre_comidas.ParameterName = "Entre_comidas";
                paramUpdEntre_comidas.DbType = DbType.Int32;
                paramUpdEntre_comidas.Value = (object)PacientesDB.Entre_comidas ?? DBNull.Value;
		var paramUpdApetito = _dataProvider.GetParameter();
                paramUpdApetito.ParameterName = "Apetito";
                paramUpdApetito.DbType = DbType.Int32;
                paramUpdApetito.Value = (object)PacientesDB.Apetito ?? DBNull.Value;
		var paramUpdHabitos_Modificacion = _dataProvider.GetParameter();
                paramUpdHabitos_Modificacion.ParameterName = "Habitos_Modificacion";
                paramUpdHabitos_Modificacion.DbType = DbType.Int32;
                paramUpdHabitos_Modificacion.Value = (object)PacientesDB.Habitos_Modificacion ?? DBNull.Value;
		var paramUpdHorario_hambre = _dataProvider.GetParameter();
                paramUpdHorario_hambre.ParameterName = "Horario_hambre";
                paramUpdHorario_hambre.DbType = DbType.Int32;
                paramUpdHorario_hambre.Value = (object)PacientesDB.Horario_hambre ?? DBNull.Value;
		var paramUpdCuando_cambia_mi_estado_de_animo = _dataProvider.GetParameter();
                paramUpdCuando_cambia_mi_estado_de_animo.ParameterName = "Cuando_cambia_mi_estado_de_animo";
                paramUpdCuando_cambia_mi_estado_de_animo.DbType = DbType.Int32;
                paramUpdCuando_cambia_mi_estado_de_animo.Value = (object)PacientesDB.Cuando_cambia_mi_estado_de_animo ?? DBNull.Value;
		var paramUpdMedicamentos_bajar_peso = _dataProvider.GetParameter();
                paramUpdMedicamentos_bajar_peso.ParameterName = "Medicamentos_bajar_peso";
                paramUpdMedicamentos_bajar_peso.DbType = DbType.Int32;
                paramUpdMedicamentos_bajar_peso.Value = (object)PacientesDB.Medicamentos_bajar_peso ?? DBNull.Value;
                var paramUpdCual_medicamento = _dataProvider.GetParameter();
                paramUpdCual_medicamento.ParameterName = "Cual_medicamento";
                paramUpdCual_medicamento.DbType = DbType.String;
                paramUpdCual_medicamento.Value = (object)PacientesDB.Cual_medicamento ?? DBNull.Value;
		var paramUpdFrecuencia_Ejercicio = _dataProvider.GetParameter();
                paramUpdFrecuencia_Ejercicio.ParameterName = "Frecuencia_Ejercicio";
                paramUpdFrecuencia_Ejercicio.DbType = DbType.Int32;
                paramUpdFrecuencia_Ejercicio.Value = (object)PacientesDB.Frecuencia_Ejercicio ?? DBNull.Value;
		var paramUpdDuracion_Ejercicio = _dataProvider.GetParameter();
                paramUpdDuracion_Ejercicio.ParameterName = "Duracion_Ejercicio";
                paramUpdDuracion_Ejercicio.DbType = DbType.Int32;
                paramUpdDuracion_Ejercicio.Value = (object)PacientesDB.Duracion_Ejercicio ?? DBNull.Value;
		var paramUpdTipo_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_Ejercicio.ParameterName = "Tipo_Ejercicio";
                paramUpdTipo_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_Ejercicio.Value = (object)PacientesDB.Tipo_Ejercicio ?? DBNull.Value;
		var paramUpdAntiguedad_Ejercicio = _dataProvider.GetParameter();
                paramUpdAntiguedad_Ejercicio.ParameterName = "Antiguedad_Ejercicio";
                paramUpdAntiguedad_Ejercicio.DbType = DbType.Int32;
                paramUpdAntiguedad_Ejercicio.Value = (object)PacientesDB.Antiguedad_Ejercicio ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)PacientesDB.IMC ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)PacientesDB.Interpretacion_IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)PacientesDB.IMC_Pediatria ?? DBNull.Value;
                var paramUpdComplexion_corporal = _dataProvider.GetParameter();
                paramUpdComplexion_corporal.ParameterName = "Complexion_corporal";
                paramUpdComplexion_corporal.DbType = DbType.String;
                paramUpdComplexion_corporal.Value = (object)PacientesDB.Complexion_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_complexion_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_complexion_corporal.ParameterName = "Interpretacion_complexion_corporal";
                paramUpdInterpretacion_complexion_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_complexion_corporal.Value = (object)PacientesDB.Interpretacion_complexion_corporal ?? DBNull.Value;
                var paramUpdDistribucion_de_grasa_corporal = _dataProvider.GetParameter();
                paramUpdDistribucion_de_grasa_corporal.ParameterName = "Distribucion_de_grasa_corporal";
                paramUpdDistribucion_de_grasa_corporal.DbType = DbType.String;
                paramUpdDistribucion_de_grasa_corporal.Value = (object)PacientesDB.Distribucion_de_grasa_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_grasa_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_grasa_corporal.ParameterName = "Interpretacion_grasa_corporal";
                paramUpdInterpretacion_grasa_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_grasa_corporal.Value = (object)PacientesDB.Interpretacion_grasa_corporal ?? DBNull.Value;
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.String;
                paramUpdIndice_cintura_cadera.Value = (object)PacientesDB.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)PacientesDB.Interpretacion_indice ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.String;
                paramUpdConsumo_de_agua_resultado.Value = (object)PacientesDB.Consumo_de_agua_resultado ?? DBNull.Value;
		var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)PacientesDB.Interpretacion_agua ?? DBNull.Value;
                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)PacientesDB.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;
		var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)PacientesDB.Interpretacion_frecuencia ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.String;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)PacientesDB.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
		var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)PacientesDB.Interpretacion_dificultad ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)PacientesDB.Calorias ?? DBNull.Value;
		var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)PacientesDB.Interpretacion_calorias ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)PacientesDB.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPacientes>("sp_UpdPacientes" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Registro , paramUpdTipo_de_Paciente , paramUpdUsuario_Registrado , paramUpdEmpresa , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdCelular , paramUpdEmail , paramUpdFecha_de_nacimiento , paramUpdNombre_del_Padre_o_Tutor , paramUpdPais_de_nacimiento , paramUpdLugar_de_nacimiento , paramUpdSexo , paramUpdEstado_Civil , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdPais , paramUpdEstado , paramUpdOcupacion , paramUpdCantidad_hijos , paramUpdObjetivo , paramUpdEstatus_Paciente , paramUpdCuenta_con_padecimientos , paramUpdFrecuencia_Cardiaca , paramUpdFrecuencia_Respiratoria , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdPeso_habitual , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdAnchura_de_muneca_mm , paramUpdCircunferencia_de_brazo_cm , paramUpdPliegue_cutaneo_tricipital_mm , paramUpdPliegue_cutaneo_bicipital_mm , paramUpdPliegue_cutaneo_subescapular_mm , paramUpdPliegue_cutaneo_supraespinal_mm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdMasa_Muscular_ , paramUpdEsta_embarazada , paramUpdSemana_de_gestacion , paramUpdPeso_pregestacional , paramUpdToma_anticonceptivos , paramUpdNombre_del_Anticonceptivo , paramUpdDosis , paramUpdClimaterio , paramUpdFecha_Climaterio , paramUpdTerapia_reemplazo_hormonal , paramUpdTipo_Dieta , paramUpdSuplementos , paramUpdConsumo_de_sal , paramUpdGrasas_Preferencias , paramUpdComidas_cantidad , paramUpdPreparacion_Preferencias , paramUpdEntre_comidas , paramUpdApetito , paramUpdHabitos_Modificacion , paramUpdHorario_hambre , paramUpdCuando_cambia_mi_estado_de_animo , paramUpdMedicamentos_bajar_peso , paramUpdCual_medicamento , paramUpdFrecuencia_Ejercicio , paramUpdDuracion_Ejercicio , paramUpdTipo_Ejercicio , paramUpdAntiguedad_Ejercicio , paramUpdIMC , paramUpdInterpretacion_IMC , paramUpdIMC_Pediatria , paramUpdComplexion_corporal , paramUpdInterpretacion_complexion_corporal , paramUpdDistribucion_de_grasa_corporal , paramUpdInterpretacion_grasa_corporal , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

		public int Update_Padecimientos(Spartane.Core.Classes.Pacientes.Pacientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Pacientes.Pacientes PacientesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)PacientesDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)PacientesDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)PacientesDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)PacientesDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdTipo_de_Registro = _dataProvider.GetParameter();
                paramUpdTipo_de_Registro.ParameterName = "Tipo_de_Registro";
                paramUpdTipo_de_Registro.DbType = DbType.Int32;
                paramUpdTipo_de_Registro.Value = (object)PacientesDB.Tipo_de_Registro ?? DBNull.Value;
		var paramUpdTipo_de_Paciente = _dataProvider.GetParameter();
                paramUpdTipo_de_Paciente.ParameterName = "Tipo_de_Paciente";
                paramUpdTipo_de_Paciente.DbType = DbType.Int32;
                paramUpdTipo_de_Paciente.Value = (object)PacientesDB.Tipo_de_Paciente ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)PacientesDB.Usuario_Registrado ?? DBNull.Value;
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)PacientesDB.Empresa ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)PacientesDB.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)PacientesDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)PacientesDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)PacientesDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)PacientesDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)PacientesDB.Celular ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)PacientesDB.Email ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)PacientesDB.Fecha_de_nacimiento ?? DBNull.Value;
                var paramUpdNombre_del_Padre_o_Tutor = _dataProvider.GetParameter();
                paramUpdNombre_del_Padre_o_Tutor.ParameterName = "Nombre_del_Padre_o_Tutor";
                paramUpdNombre_del_Padre_o_Tutor.DbType = DbType.String;
                paramUpdNombre_del_Padre_o_Tutor.Value = (object)PacientesDB.Nombre_del_Padre_o_Tutor ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)PacientesDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdLugar_de_nacimiento = _dataProvider.GetParameter();
                paramUpdLugar_de_nacimiento.ParameterName = "Lugar_de_nacimiento";
                paramUpdLugar_de_nacimiento.DbType = DbType.Int32;
                paramUpdLugar_de_nacimiento.Value = (object)PacientesDB.Lugar_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)PacientesDB.Sexo ?? DBNull.Value;
		var paramUpdEstado_Civil = _dataProvider.GetParameter();
                paramUpdEstado_Civil.ParameterName = "Estado_Civil";
                paramUpdEstado_Civil.DbType = DbType.Int32;
                paramUpdEstado_Civil.Value = (object)PacientesDB.Estado_Civil ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)PacientesDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)PacientesDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)PacientesDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)PacientesDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)PacientesDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)PacientesDB.Ciudad ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)PacientesDB.Pais ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)PacientesDB.Estado ?? DBNull.Value;
                var paramUpdOcupacion = _dataProvider.GetParameter();
                paramUpdOcupacion.ParameterName = "Ocupacion";
                paramUpdOcupacion.DbType = DbType.String;
                paramUpdOcupacion.Value = (object)PacientesDB.Ocupacion ?? DBNull.Value;
                var paramUpdCantidad_hijos = _dataProvider.GetParameter();
                paramUpdCantidad_hijos.ParameterName = "Cantidad_hijos";
                paramUpdCantidad_hijos.DbType = DbType.Int32;
                paramUpdCantidad_hijos.Value = (object)PacientesDB.Cantidad_hijos ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)PacientesDB.Objetivo ?? DBNull.Value;
		var paramUpdEstatus_Paciente = _dataProvider.GetParameter();
                paramUpdEstatus_Paciente.ParameterName = "Estatus_Paciente";
                paramUpdEstatus_Paciente.DbType = DbType.Int32;
                paramUpdEstatus_Paciente.Value = (object)PacientesDB.Estatus_Paciente ?? DBNull.Value;
		var paramUpdCuenta_con_padecimientos = _dataProvider.GetParameter();
                paramUpdCuenta_con_padecimientos.ParameterName = "Cuenta_con_padecimientos";
                paramUpdCuenta_con_padecimientos.DbType = DbType.Int32;
                paramUpdCuenta_con_padecimientos.Value = (object)entity.Cuenta_con_padecimientos ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)PacientesDB.Frecuencia_Cardiaca ?? DBNull.Value;
                var paramUpdFrecuencia_Respiratoria = _dataProvider.GetParameter();
                paramUpdFrecuencia_Respiratoria.ParameterName = "Frecuencia_Respiratoria";
                paramUpdFrecuencia_Respiratoria.DbType = DbType.Int32;
                paramUpdFrecuencia_Respiratoria.Value = (object)PacientesDB.Frecuencia_Respiratoria ?? DBNull.Value;
                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)PacientesDB.Presion_sistolica ?? DBNull.Value;
                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)PacientesDB.Presion_diastolica ?? DBNull.Value;
                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)PacientesDB.Peso_actual ?? DBNull.Value;
                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)PacientesDB.Estatura ?? DBNull.Value;
                var paramUpdPeso_habitual = _dataProvider.GetParameter();
                paramUpdPeso_habitual.ParameterName = "Peso_habitual";
                paramUpdPeso_habitual.DbType = DbType.Decimal;
                paramUpdPeso_habitual.Value = (object)PacientesDB.Peso_habitual ?? DBNull.Value;
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)PacientesDB.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)PacientesDB.Circunferencia_de_cadera_cm ?? DBNull.Value;
                var paramUpdAnchura_de_muneca_mm = _dataProvider.GetParameter();
                paramUpdAnchura_de_muneca_mm.ParameterName = "Anchura_de_muneca_mm";
                paramUpdAnchura_de_muneca_mm.DbType = DbType.Int32;
                paramUpdAnchura_de_muneca_mm.Value = (object)PacientesDB.Anchura_de_muneca_mm ?? DBNull.Value;
                var paramUpdCircunferencia_de_brazo_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_brazo_cm.ParameterName = "Circunferencia_de_brazo_cm";
                paramUpdCircunferencia_de_brazo_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_brazo_cm.Value = (object)PacientesDB.Circunferencia_de_brazo_cm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_tricipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_tricipital_mm.ParameterName = "Pliegue_cutaneo_tricipital_mm";
                paramUpdPliegue_cutaneo_tricipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_tricipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_tricipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_bicipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_bicipital_mm.ParameterName = "Pliegue_cutaneo_bicipital_mm";
                paramUpdPliegue_cutaneo_bicipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_bicipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_bicipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_subescapular_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_subescapular_mm.ParameterName = "Pliegue_cutaneo_subescapular_mm";
                paramUpdPliegue_cutaneo_subescapular_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_subescapular_mm.Value = (object)PacientesDB.Pliegue_cutaneo_subescapular_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_supraespinal_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_supraespinal_mm.ParameterName = "Pliegue_cutaneo_supraespinal_mm";
                paramUpdPliegue_cutaneo_supraespinal_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_supraespinal_mm.Value = (object)PacientesDB.Pliegue_cutaneo_supraespinal_mm ?? DBNull.Value;
                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)PacientesDB.Edad_Metabolica ?? DBNull.Value;
                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)PacientesDB.Agua_corporal ?? DBNull.Value;
                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)PacientesDB.Grasa_Visceral ?? DBNull.Value;
                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)PacientesDB.Grasa_Corporal ?? DBNull.Value;
                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)PacientesDB.Grasa_Corporal_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)PacientesDB.Masa_Muscular_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_ = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_.ParameterName = "Masa_Muscular_";
                paramUpdMasa_Muscular_.DbType = DbType.Int32;
                paramUpdMasa_Muscular_.Value = (object)PacientesDB.Masa_Muscular_ ?? DBNull.Value;
		var paramUpdEsta_embarazada = _dataProvider.GetParameter();
                paramUpdEsta_embarazada.ParameterName = "Esta_embarazada";
                paramUpdEsta_embarazada.DbType = DbType.Int32;
                paramUpdEsta_embarazada.Value = (object)PacientesDB.Esta_embarazada ?? DBNull.Value;
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)PacientesDB.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdPeso_pregestacional = _dataProvider.GetParameter();
                paramUpdPeso_pregestacional.ParameterName = "Peso_pregestacional";
                paramUpdPeso_pregestacional.DbType = DbType.Int32;
                paramUpdPeso_pregestacional.Value = (object)PacientesDB.Peso_pregestacional ?? DBNull.Value;
		var paramUpdToma_anticonceptivos = _dataProvider.GetParameter();
                paramUpdToma_anticonceptivos.ParameterName = "Toma_anticonceptivos";
                paramUpdToma_anticonceptivos.DbType = DbType.Int32;
                paramUpdToma_anticonceptivos.Value = (object)PacientesDB.Toma_anticonceptivos ?? DBNull.Value;
                var paramUpdNombre_del_Anticonceptivo = _dataProvider.GetParameter();
                paramUpdNombre_del_Anticonceptivo.ParameterName = "Nombre_del_Anticonceptivo";
                paramUpdNombre_del_Anticonceptivo.DbType = DbType.String;
                paramUpdNombre_del_Anticonceptivo.Value = (object)PacientesDB.Nombre_del_Anticonceptivo ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)PacientesDB.Dosis ?? DBNull.Value;
		var paramUpdClimaterio = _dataProvider.GetParameter();
                paramUpdClimaterio.ParameterName = "Climaterio";
                paramUpdClimaterio.DbType = DbType.Int32;
                paramUpdClimaterio.Value = (object)PacientesDB.Climaterio ?? DBNull.Value;
                var paramUpdFecha_Climaterio = _dataProvider.GetParameter();
                paramUpdFecha_Climaterio.ParameterName = "Fecha_Climaterio";
                paramUpdFecha_Climaterio.DbType = DbType.DateTime;
                paramUpdFecha_Climaterio.Value = (object)PacientesDB.Fecha_Climaterio ?? DBNull.Value;
		var paramUpdTerapia_reemplazo_hormonal = _dataProvider.GetParameter();
                paramUpdTerapia_reemplazo_hormonal.ParameterName = "Terapia_reemplazo_hormonal";
                paramUpdTerapia_reemplazo_hormonal.DbType = DbType.Int32;
                paramUpdTerapia_reemplazo_hormonal.Value = (object)PacientesDB.Terapia_reemplazo_hormonal ?? DBNull.Value;
		var paramUpdTipo_Dieta = _dataProvider.GetParameter();
                paramUpdTipo_Dieta.ParameterName = "Tipo_Dieta";
                paramUpdTipo_Dieta.DbType = DbType.Int32;
                paramUpdTipo_Dieta.Value = (object)PacientesDB.Tipo_Dieta ?? DBNull.Value;
		var paramUpdSuplementos = _dataProvider.GetParameter();
                paramUpdSuplementos.ParameterName = "Suplementos";
                paramUpdSuplementos.DbType = DbType.Int32;
                paramUpdSuplementos.Value = (object)PacientesDB.Suplementos ?? DBNull.Value;
		var paramUpdConsumo_de_sal = _dataProvider.GetParameter();
                paramUpdConsumo_de_sal.ParameterName = "Consumo_de_sal";
                paramUpdConsumo_de_sal.DbType = DbType.Int32;
                paramUpdConsumo_de_sal.Value = (object)PacientesDB.Consumo_de_sal ?? DBNull.Value;
		var paramUpdGrasas_Preferencias = _dataProvider.GetParameter();
                paramUpdGrasas_Preferencias.ParameterName = "Grasas_Preferencias";
                paramUpdGrasas_Preferencias.DbType = DbType.Int32;
                paramUpdGrasas_Preferencias.Value = (object)PacientesDB.Grasas_Preferencias ?? DBNull.Value;
		var paramUpdComidas_cantidad = _dataProvider.GetParameter();
                paramUpdComidas_cantidad.ParameterName = "Comidas_cantidad";
                paramUpdComidas_cantidad.DbType = DbType.Int32;
                paramUpdComidas_cantidad.Value = (object)PacientesDB.Comidas_cantidad ?? DBNull.Value;
		var paramUpdPreparacion_Preferencias = _dataProvider.GetParameter();
                paramUpdPreparacion_Preferencias.ParameterName = "Preparacion_Preferencias";
                paramUpdPreparacion_Preferencias.DbType = DbType.Int32;
                paramUpdPreparacion_Preferencias.Value = (object)PacientesDB.Preparacion_Preferencias ?? DBNull.Value;
		var paramUpdEntre_comidas = _dataProvider.GetParameter();
                paramUpdEntre_comidas.ParameterName = "Entre_comidas";
                paramUpdEntre_comidas.DbType = DbType.Int32;
                paramUpdEntre_comidas.Value = (object)PacientesDB.Entre_comidas ?? DBNull.Value;
		var paramUpdApetito = _dataProvider.GetParameter();
                paramUpdApetito.ParameterName = "Apetito";
                paramUpdApetito.DbType = DbType.Int32;
                paramUpdApetito.Value = (object)PacientesDB.Apetito ?? DBNull.Value;
		var paramUpdHabitos_Modificacion = _dataProvider.GetParameter();
                paramUpdHabitos_Modificacion.ParameterName = "Habitos_Modificacion";
                paramUpdHabitos_Modificacion.DbType = DbType.Int32;
                paramUpdHabitos_Modificacion.Value = (object)PacientesDB.Habitos_Modificacion ?? DBNull.Value;
		var paramUpdHorario_hambre = _dataProvider.GetParameter();
                paramUpdHorario_hambre.ParameterName = "Horario_hambre";
                paramUpdHorario_hambre.DbType = DbType.Int32;
                paramUpdHorario_hambre.Value = (object)PacientesDB.Horario_hambre ?? DBNull.Value;
		var paramUpdCuando_cambia_mi_estado_de_animo = _dataProvider.GetParameter();
                paramUpdCuando_cambia_mi_estado_de_animo.ParameterName = "Cuando_cambia_mi_estado_de_animo";
                paramUpdCuando_cambia_mi_estado_de_animo.DbType = DbType.Int32;
                paramUpdCuando_cambia_mi_estado_de_animo.Value = (object)PacientesDB.Cuando_cambia_mi_estado_de_animo ?? DBNull.Value;
		var paramUpdMedicamentos_bajar_peso = _dataProvider.GetParameter();
                paramUpdMedicamentos_bajar_peso.ParameterName = "Medicamentos_bajar_peso";
                paramUpdMedicamentos_bajar_peso.DbType = DbType.Int32;
                paramUpdMedicamentos_bajar_peso.Value = (object)PacientesDB.Medicamentos_bajar_peso ?? DBNull.Value;
                var paramUpdCual_medicamento = _dataProvider.GetParameter();
                paramUpdCual_medicamento.ParameterName = "Cual_medicamento";
                paramUpdCual_medicamento.DbType = DbType.String;
                paramUpdCual_medicamento.Value = (object)PacientesDB.Cual_medicamento ?? DBNull.Value;
		var paramUpdFrecuencia_Ejercicio = _dataProvider.GetParameter();
                paramUpdFrecuencia_Ejercicio.ParameterName = "Frecuencia_Ejercicio";
                paramUpdFrecuencia_Ejercicio.DbType = DbType.Int32;
                paramUpdFrecuencia_Ejercicio.Value = (object)PacientesDB.Frecuencia_Ejercicio ?? DBNull.Value;
		var paramUpdDuracion_Ejercicio = _dataProvider.GetParameter();
                paramUpdDuracion_Ejercicio.ParameterName = "Duracion_Ejercicio";
                paramUpdDuracion_Ejercicio.DbType = DbType.Int32;
                paramUpdDuracion_Ejercicio.Value = (object)PacientesDB.Duracion_Ejercicio ?? DBNull.Value;
		var paramUpdTipo_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_Ejercicio.ParameterName = "Tipo_Ejercicio";
                paramUpdTipo_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_Ejercicio.Value = (object)PacientesDB.Tipo_Ejercicio ?? DBNull.Value;
		var paramUpdAntiguedad_Ejercicio = _dataProvider.GetParameter();
                paramUpdAntiguedad_Ejercicio.ParameterName = "Antiguedad_Ejercicio";
                paramUpdAntiguedad_Ejercicio.DbType = DbType.Int32;
                paramUpdAntiguedad_Ejercicio.Value = (object)PacientesDB.Antiguedad_Ejercicio ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)PacientesDB.IMC ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)PacientesDB.Interpretacion_IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)PacientesDB.IMC_Pediatria ?? DBNull.Value;
                var paramUpdComplexion_corporal = _dataProvider.GetParameter();
                paramUpdComplexion_corporal.ParameterName = "Complexion_corporal";
                paramUpdComplexion_corporal.DbType = DbType.String;
                paramUpdComplexion_corporal.Value = (object)PacientesDB.Complexion_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_complexion_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_complexion_corporal.ParameterName = "Interpretacion_complexion_corporal";
                paramUpdInterpretacion_complexion_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_complexion_corporal.Value = (object)PacientesDB.Interpretacion_complexion_corporal ?? DBNull.Value;
                var paramUpdDistribucion_de_grasa_corporal = _dataProvider.GetParameter();
                paramUpdDistribucion_de_grasa_corporal.ParameterName = "Distribucion_de_grasa_corporal";
                paramUpdDistribucion_de_grasa_corporal.DbType = DbType.String;
                paramUpdDistribucion_de_grasa_corporal.Value = (object)PacientesDB.Distribucion_de_grasa_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_grasa_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_grasa_corporal.ParameterName = "Interpretacion_grasa_corporal";
                paramUpdInterpretacion_grasa_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_grasa_corporal.Value = (object)PacientesDB.Interpretacion_grasa_corporal ?? DBNull.Value;
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.String;
                paramUpdIndice_cintura_cadera.Value = (object)PacientesDB.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)PacientesDB.Interpretacion_indice ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.String;
                paramUpdConsumo_de_agua_resultado.Value = (object)PacientesDB.Consumo_de_agua_resultado ?? DBNull.Value;
		var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)PacientesDB.Interpretacion_agua ?? DBNull.Value;
                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)PacientesDB.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;
		var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)PacientesDB.Interpretacion_frecuencia ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.String;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)PacientesDB.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
		var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)PacientesDB.Interpretacion_dificultad ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)PacientesDB.Calorias ?? DBNull.Value;
		var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)PacientesDB.Interpretacion_calorias ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)PacientesDB.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPacientes>("sp_UpdPacientes" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Registro , paramUpdTipo_de_Paciente , paramUpdUsuario_Registrado , paramUpdEmpresa , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdCelular , paramUpdEmail , paramUpdFecha_de_nacimiento , paramUpdNombre_del_Padre_o_Tutor , paramUpdPais_de_nacimiento , paramUpdLugar_de_nacimiento , paramUpdSexo , paramUpdEstado_Civil , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdPais , paramUpdEstado , paramUpdOcupacion , paramUpdCantidad_hijos , paramUpdObjetivo , paramUpdEstatus_Paciente , paramUpdCuenta_con_padecimientos , paramUpdFrecuencia_Cardiaca , paramUpdFrecuencia_Respiratoria , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdPeso_habitual , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdAnchura_de_muneca_mm , paramUpdCircunferencia_de_brazo_cm , paramUpdPliegue_cutaneo_tricipital_mm , paramUpdPliegue_cutaneo_bicipital_mm , paramUpdPliegue_cutaneo_subescapular_mm , paramUpdPliegue_cutaneo_supraespinal_mm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdMasa_Muscular_ , paramUpdEsta_embarazada , paramUpdSemana_de_gestacion , paramUpdPeso_pregestacional , paramUpdToma_anticonceptivos , paramUpdNombre_del_Anticonceptivo , paramUpdDosis , paramUpdClimaterio , paramUpdFecha_Climaterio , paramUpdTerapia_reemplazo_hormonal , paramUpdTipo_Dieta , paramUpdSuplementos , paramUpdConsumo_de_sal , paramUpdGrasas_Preferencias , paramUpdComidas_cantidad , paramUpdPreparacion_Preferencias , paramUpdEntre_comidas , paramUpdApetito , paramUpdHabitos_Modificacion , paramUpdHorario_hambre , paramUpdCuando_cambia_mi_estado_de_animo , paramUpdMedicamentos_bajar_peso , paramUpdCual_medicamento , paramUpdFrecuencia_Ejercicio , paramUpdDuracion_Ejercicio , paramUpdTipo_Ejercicio , paramUpdAntiguedad_Ejercicio , paramUpdIMC , paramUpdInterpretacion_IMC , paramUpdIMC_Pediatria , paramUpdComplexion_corporal , paramUpdInterpretacion_complexion_corporal , paramUpdDistribucion_de_grasa_corporal , paramUpdInterpretacion_grasa_corporal , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

		public int Update_Antecedentes(Spartane.Core.Classes.Pacientes.Pacientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Pacientes.Pacientes PacientesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)PacientesDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)PacientesDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)PacientesDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)PacientesDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdTipo_de_Registro = _dataProvider.GetParameter();
                paramUpdTipo_de_Registro.ParameterName = "Tipo_de_Registro";
                paramUpdTipo_de_Registro.DbType = DbType.Int32;
                paramUpdTipo_de_Registro.Value = (object)PacientesDB.Tipo_de_Registro ?? DBNull.Value;
		var paramUpdTipo_de_Paciente = _dataProvider.GetParameter();
                paramUpdTipo_de_Paciente.ParameterName = "Tipo_de_Paciente";
                paramUpdTipo_de_Paciente.DbType = DbType.Int32;
                paramUpdTipo_de_Paciente.Value = (object)PacientesDB.Tipo_de_Paciente ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)PacientesDB.Usuario_Registrado ?? DBNull.Value;
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)PacientesDB.Empresa ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)PacientesDB.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)PacientesDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)PacientesDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)PacientesDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)PacientesDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)PacientesDB.Celular ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)PacientesDB.Email ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)PacientesDB.Fecha_de_nacimiento ?? DBNull.Value;
                var paramUpdNombre_del_Padre_o_Tutor = _dataProvider.GetParameter();
                paramUpdNombre_del_Padre_o_Tutor.ParameterName = "Nombre_del_Padre_o_Tutor";
                paramUpdNombre_del_Padre_o_Tutor.DbType = DbType.String;
                paramUpdNombre_del_Padre_o_Tutor.Value = (object)PacientesDB.Nombre_del_Padre_o_Tutor ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)PacientesDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdLugar_de_nacimiento = _dataProvider.GetParameter();
                paramUpdLugar_de_nacimiento.ParameterName = "Lugar_de_nacimiento";
                paramUpdLugar_de_nacimiento.DbType = DbType.Int32;
                paramUpdLugar_de_nacimiento.Value = (object)PacientesDB.Lugar_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)PacientesDB.Sexo ?? DBNull.Value;
		var paramUpdEstado_Civil = _dataProvider.GetParameter();
                paramUpdEstado_Civil.ParameterName = "Estado_Civil";
                paramUpdEstado_Civil.DbType = DbType.Int32;
                paramUpdEstado_Civil.Value = (object)PacientesDB.Estado_Civil ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)PacientesDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)PacientesDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)PacientesDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)PacientesDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)PacientesDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)PacientesDB.Ciudad ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)PacientesDB.Pais ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)PacientesDB.Estado ?? DBNull.Value;
                var paramUpdOcupacion = _dataProvider.GetParameter();
                paramUpdOcupacion.ParameterName = "Ocupacion";
                paramUpdOcupacion.DbType = DbType.String;
                paramUpdOcupacion.Value = (object)PacientesDB.Ocupacion ?? DBNull.Value;
                var paramUpdCantidad_hijos = _dataProvider.GetParameter();
                paramUpdCantidad_hijos.ParameterName = "Cantidad_hijos";
                paramUpdCantidad_hijos.DbType = DbType.Int32;
                paramUpdCantidad_hijos.Value = (object)PacientesDB.Cantidad_hijos ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)PacientesDB.Objetivo ?? DBNull.Value;
		var paramUpdEstatus_Paciente = _dataProvider.GetParameter();
                paramUpdEstatus_Paciente.ParameterName = "Estatus_Paciente";
                paramUpdEstatus_Paciente.DbType = DbType.Int32;
                paramUpdEstatus_Paciente.Value = (object)PacientesDB.Estatus_Paciente ?? DBNull.Value;
		var paramUpdCuenta_con_padecimientos = _dataProvider.GetParameter();
                paramUpdCuenta_con_padecimientos.ParameterName = "Cuenta_con_padecimientos";
                paramUpdCuenta_con_padecimientos.DbType = DbType.Int32;
                paramUpdCuenta_con_padecimientos.Value = (object)PacientesDB.Cuenta_con_padecimientos ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)PacientesDB.Frecuencia_Cardiaca ?? DBNull.Value;
                var paramUpdFrecuencia_Respiratoria = _dataProvider.GetParameter();
                paramUpdFrecuencia_Respiratoria.ParameterName = "Frecuencia_Respiratoria";
                paramUpdFrecuencia_Respiratoria.DbType = DbType.Int32;
                paramUpdFrecuencia_Respiratoria.Value = (object)PacientesDB.Frecuencia_Respiratoria ?? DBNull.Value;
                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)PacientesDB.Presion_sistolica ?? DBNull.Value;
                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)PacientesDB.Presion_diastolica ?? DBNull.Value;
                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)PacientesDB.Peso_actual ?? DBNull.Value;
                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)PacientesDB.Estatura ?? DBNull.Value;
                var paramUpdPeso_habitual = _dataProvider.GetParameter();
                paramUpdPeso_habitual.ParameterName = "Peso_habitual";
                paramUpdPeso_habitual.DbType = DbType.Decimal;
                paramUpdPeso_habitual.Value = (object)PacientesDB.Peso_habitual ?? DBNull.Value;
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)PacientesDB.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)PacientesDB.Circunferencia_de_cadera_cm ?? DBNull.Value;
                var paramUpdAnchura_de_muneca_mm = _dataProvider.GetParameter();
                paramUpdAnchura_de_muneca_mm.ParameterName = "Anchura_de_muneca_mm";
                paramUpdAnchura_de_muneca_mm.DbType = DbType.Int32;
                paramUpdAnchura_de_muneca_mm.Value = (object)PacientesDB.Anchura_de_muneca_mm ?? DBNull.Value;
                var paramUpdCircunferencia_de_brazo_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_brazo_cm.ParameterName = "Circunferencia_de_brazo_cm";
                paramUpdCircunferencia_de_brazo_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_brazo_cm.Value = (object)PacientesDB.Circunferencia_de_brazo_cm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_tricipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_tricipital_mm.ParameterName = "Pliegue_cutaneo_tricipital_mm";
                paramUpdPliegue_cutaneo_tricipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_tricipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_tricipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_bicipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_bicipital_mm.ParameterName = "Pliegue_cutaneo_bicipital_mm";
                paramUpdPliegue_cutaneo_bicipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_bicipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_bicipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_subescapular_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_subescapular_mm.ParameterName = "Pliegue_cutaneo_subescapular_mm";
                paramUpdPliegue_cutaneo_subescapular_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_subescapular_mm.Value = (object)PacientesDB.Pliegue_cutaneo_subescapular_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_supraespinal_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_supraespinal_mm.ParameterName = "Pliegue_cutaneo_supraespinal_mm";
                paramUpdPliegue_cutaneo_supraespinal_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_supraespinal_mm.Value = (object)PacientesDB.Pliegue_cutaneo_supraespinal_mm ?? DBNull.Value;
                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)PacientesDB.Edad_Metabolica ?? DBNull.Value;
                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)PacientesDB.Agua_corporal ?? DBNull.Value;
                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)PacientesDB.Grasa_Visceral ?? DBNull.Value;
                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)PacientesDB.Grasa_Corporal ?? DBNull.Value;
                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)PacientesDB.Grasa_Corporal_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)PacientesDB.Masa_Muscular_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_ = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_.ParameterName = "Masa_Muscular_";
                paramUpdMasa_Muscular_.DbType = DbType.Int32;
                paramUpdMasa_Muscular_.Value = (object)PacientesDB.Masa_Muscular_ ?? DBNull.Value;
		var paramUpdEsta_embarazada = _dataProvider.GetParameter();
                paramUpdEsta_embarazada.ParameterName = "Esta_embarazada";
                paramUpdEsta_embarazada.DbType = DbType.Int32;
                paramUpdEsta_embarazada.Value = (object)PacientesDB.Esta_embarazada ?? DBNull.Value;
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)PacientesDB.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdPeso_pregestacional = _dataProvider.GetParameter();
                paramUpdPeso_pregestacional.ParameterName = "Peso_pregestacional";
                paramUpdPeso_pregestacional.DbType = DbType.Int32;
                paramUpdPeso_pregestacional.Value = (object)PacientesDB.Peso_pregestacional ?? DBNull.Value;
		var paramUpdToma_anticonceptivos = _dataProvider.GetParameter();
                paramUpdToma_anticonceptivos.ParameterName = "Toma_anticonceptivos";
                paramUpdToma_anticonceptivos.DbType = DbType.Int32;
                paramUpdToma_anticonceptivos.Value = (object)PacientesDB.Toma_anticonceptivos ?? DBNull.Value;
                var paramUpdNombre_del_Anticonceptivo = _dataProvider.GetParameter();
                paramUpdNombre_del_Anticonceptivo.ParameterName = "Nombre_del_Anticonceptivo";
                paramUpdNombre_del_Anticonceptivo.DbType = DbType.String;
                paramUpdNombre_del_Anticonceptivo.Value = (object)PacientesDB.Nombre_del_Anticonceptivo ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)PacientesDB.Dosis ?? DBNull.Value;
		var paramUpdClimaterio = _dataProvider.GetParameter();
                paramUpdClimaterio.ParameterName = "Climaterio";
                paramUpdClimaterio.DbType = DbType.Int32;
                paramUpdClimaterio.Value = (object)PacientesDB.Climaterio ?? DBNull.Value;
                var paramUpdFecha_Climaterio = _dataProvider.GetParameter();
                paramUpdFecha_Climaterio.ParameterName = "Fecha_Climaterio";
                paramUpdFecha_Climaterio.DbType = DbType.DateTime;
                paramUpdFecha_Climaterio.Value = (object)PacientesDB.Fecha_Climaterio ?? DBNull.Value;
		var paramUpdTerapia_reemplazo_hormonal = _dataProvider.GetParameter();
                paramUpdTerapia_reemplazo_hormonal.ParameterName = "Terapia_reemplazo_hormonal";
                paramUpdTerapia_reemplazo_hormonal.DbType = DbType.Int32;
                paramUpdTerapia_reemplazo_hormonal.Value = (object)PacientesDB.Terapia_reemplazo_hormonal ?? DBNull.Value;
		var paramUpdTipo_Dieta = _dataProvider.GetParameter();
                paramUpdTipo_Dieta.ParameterName = "Tipo_Dieta";
                paramUpdTipo_Dieta.DbType = DbType.Int32;
                paramUpdTipo_Dieta.Value = (object)PacientesDB.Tipo_Dieta ?? DBNull.Value;
		var paramUpdSuplementos = _dataProvider.GetParameter();
                paramUpdSuplementos.ParameterName = "Suplementos";
                paramUpdSuplementos.DbType = DbType.Int32;
                paramUpdSuplementos.Value = (object)PacientesDB.Suplementos ?? DBNull.Value;
		var paramUpdConsumo_de_sal = _dataProvider.GetParameter();
                paramUpdConsumo_de_sal.ParameterName = "Consumo_de_sal";
                paramUpdConsumo_de_sal.DbType = DbType.Int32;
                paramUpdConsumo_de_sal.Value = (object)PacientesDB.Consumo_de_sal ?? DBNull.Value;
		var paramUpdGrasas_Preferencias = _dataProvider.GetParameter();
                paramUpdGrasas_Preferencias.ParameterName = "Grasas_Preferencias";
                paramUpdGrasas_Preferencias.DbType = DbType.Int32;
                paramUpdGrasas_Preferencias.Value = (object)PacientesDB.Grasas_Preferencias ?? DBNull.Value;
		var paramUpdComidas_cantidad = _dataProvider.GetParameter();
                paramUpdComidas_cantidad.ParameterName = "Comidas_cantidad";
                paramUpdComidas_cantidad.DbType = DbType.Int32;
                paramUpdComidas_cantidad.Value = (object)PacientesDB.Comidas_cantidad ?? DBNull.Value;
		var paramUpdPreparacion_Preferencias = _dataProvider.GetParameter();
                paramUpdPreparacion_Preferencias.ParameterName = "Preparacion_Preferencias";
                paramUpdPreparacion_Preferencias.DbType = DbType.Int32;
                paramUpdPreparacion_Preferencias.Value = (object)PacientesDB.Preparacion_Preferencias ?? DBNull.Value;
		var paramUpdEntre_comidas = _dataProvider.GetParameter();
                paramUpdEntre_comidas.ParameterName = "Entre_comidas";
                paramUpdEntre_comidas.DbType = DbType.Int32;
                paramUpdEntre_comidas.Value = (object)PacientesDB.Entre_comidas ?? DBNull.Value;
		var paramUpdApetito = _dataProvider.GetParameter();
                paramUpdApetito.ParameterName = "Apetito";
                paramUpdApetito.DbType = DbType.Int32;
                paramUpdApetito.Value = (object)PacientesDB.Apetito ?? DBNull.Value;
		var paramUpdHabitos_Modificacion = _dataProvider.GetParameter();
                paramUpdHabitos_Modificacion.ParameterName = "Habitos_Modificacion";
                paramUpdHabitos_Modificacion.DbType = DbType.Int32;
                paramUpdHabitos_Modificacion.Value = (object)PacientesDB.Habitos_Modificacion ?? DBNull.Value;
		var paramUpdHorario_hambre = _dataProvider.GetParameter();
                paramUpdHorario_hambre.ParameterName = "Horario_hambre";
                paramUpdHorario_hambre.DbType = DbType.Int32;
                paramUpdHorario_hambre.Value = (object)PacientesDB.Horario_hambre ?? DBNull.Value;
		var paramUpdCuando_cambia_mi_estado_de_animo = _dataProvider.GetParameter();
                paramUpdCuando_cambia_mi_estado_de_animo.ParameterName = "Cuando_cambia_mi_estado_de_animo";
                paramUpdCuando_cambia_mi_estado_de_animo.DbType = DbType.Int32;
                paramUpdCuando_cambia_mi_estado_de_animo.Value = (object)PacientesDB.Cuando_cambia_mi_estado_de_animo ?? DBNull.Value;
		var paramUpdMedicamentos_bajar_peso = _dataProvider.GetParameter();
                paramUpdMedicamentos_bajar_peso.ParameterName = "Medicamentos_bajar_peso";
                paramUpdMedicamentos_bajar_peso.DbType = DbType.Int32;
                paramUpdMedicamentos_bajar_peso.Value = (object)PacientesDB.Medicamentos_bajar_peso ?? DBNull.Value;
                var paramUpdCual_medicamento = _dataProvider.GetParameter();
                paramUpdCual_medicamento.ParameterName = "Cual_medicamento";
                paramUpdCual_medicamento.DbType = DbType.String;
                paramUpdCual_medicamento.Value = (object)PacientesDB.Cual_medicamento ?? DBNull.Value;
		var paramUpdFrecuencia_Ejercicio = _dataProvider.GetParameter();
                paramUpdFrecuencia_Ejercicio.ParameterName = "Frecuencia_Ejercicio";
                paramUpdFrecuencia_Ejercicio.DbType = DbType.Int32;
                paramUpdFrecuencia_Ejercicio.Value = (object)PacientesDB.Frecuencia_Ejercicio ?? DBNull.Value;
		var paramUpdDuracion_Ejercicio = _dataProvider.GetParameter();
                paramUpdDuracion_Ejercicio.ParameterName = "Duracion_Ejercicio";
                paramUpdDuracion_Ejercicio.DbType = DbType.Int32;
                paramUpdDuracion_Ejercicio.Value = (object)PacientesDB.Duracion_Ejercicio ?? DBNull.Value;
		var paramUpdTipo_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_Ejercicio.ParameterName = "Tipo_Ejercicio";
                paramUpdTipo_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_Ejercicio.Value = (object)PacientesDB.Tipo_Ejercicio ?? DBNull.Value;
		var paramUpdAntiguedad_Ejercicio = _dataProvider.GetParameter();
                paramUpdAntiguedad_Ejercicio.ParameterName = "Antiguedad_Ejercicio";
                paramUpdAntiguedad_Ejercicio.DbType = DbType.Int32;
                paramUpdAntiguedad_Ejercicio.Value = (object)PacientesDB.Antiguedad_Ejercicio ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)PacientesDB.IMC ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)PacientesDB.Interpretacion_IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)PacientesDB.IMC_Pediatria ?? DBNull.Value;
                var paramUpdComplexion_corporal = _dataProvider.GetParameter();
                paramUpdComplexion_corporal.ParameterName = "Complexion_corporal";
                paramUpdComplexion_corporal.DbType = DbType.String;
                paramUpdComplexion_corporal.Value = (object)PacientesDB.Complexion_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_complexion_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_complexion_corporal.ParameterName = "Interpretacion_complexion_corporal";
                paramUpdInterpretacion_complexion_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_complexion_corporal.Value = (object)PacientesDB.Interpretacion_complexion_corporal ?? DBNull.Value;
                var paramUpdDistribucion_de_grasa_corporal = _dataProvider.GetParameter();
                paramUpdDistribucion_de_grasa_corporal.ParameterName = "Distribucion_de_grasa_corporal";
                paramUpdDistribucion_de_grasa_corporal.DbType = DbType.String;
                paramUpdDistribucion_de_grasa_corporal.Value = (object)PacientesDB.Distribucion_de_grasa_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_grasa_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_grasa_corporal.ParameterName = "Interpretacion_grasa_corporal";
                paramUpdInterpretacion_grasa_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_grasa_corporal.Value = (object)PacientesDB.Interpretacion_grasa_corporal ?? DBNull.Value;
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.String;
                paramUpdIndice_cintura_cadera.Value = (object)PacientesDB.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)PacientesDB.Interpretacion_indice ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.String;
                paramUpdConsumo_de_agua_resultado.Value = (object)PacientesDB.Consumo_de_agua_resultado ?? DBNull.Value;
		var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)PacientesDB.Interpretacion_agua ?? DBNull.Value;
                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)PacientesDB.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;
		var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)PacientesDB.Interpretacion_frecuencia ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.String;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)PacientesDB.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
		var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)PacientesDB.Interpretacion_dificultad ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)PacientesDB.Calorias ?? DBNull.Value;
		var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)PacientesDB.Interpretacion_calorias ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)PacientesDB.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPacientes>("sp_UpdPacientes" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Registro , paramUpdTipo_de_Paciente , paramUpdUsuario_Registrado , paramUpdEmpresa , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdCelular , paramUpdEmail , paramUpdFecha_de_nacimiento , paramUpdNombre_del_Padre_o_Tutor , paramUpdPais_de_nacimiento , paramUpdLugar_de_nacimiento , paramUpdSexo , paramUpdEstado_Civil , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdPais , paramUpdEstado , paramUpdOcupacion , paramUpdCantidad_hijos , paramUpdObjetivo , paramUpdEstatus_Paciente , paramUpdCuenta_con_padecimientos , paramUpdFrecuencia_Cardiaca , paramUpdFrecuencia_Respiratoria , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdPeso_habitual , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdAnchura_de_muneca_mm , paramUpdCircunferencia_de_brazo_cm , paramUpdPliegue_cutaneo_tricipital_mm , paramUpdPliegue_cutaneo_bicipital_mm , paramUpdPliegue_cutaneo_subescapular_mm , paramUpdPliegue_cutaneo_supraespinal_mm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdMasa_Muscular_ , paramUpdEsta_embarazada , paramUpdSemana_de_gestacion , paramUpdPeso_pregestacional , paramUpdToma_anticonceptivos , paramUpdNombre_del_Anticonceptivo , paramUpdDosis , paramUpdClimaterio , paramUpdFecha_Climaterio , paramUpdTerapia_reemplazo_hormonal , paramUpdTipo_Dieta , paramUpdSuplementos , paramUpdConsumo_de_sal , paramUpdGrasas_Preferencias , paramUpdComidas_cantidad , paramUpdPreparacion_Preferencias , paramUpdEntre_comidas , paramUpdApetito , paramUpdHabitos_Modificacion , paramUpdHorario_hambre , paramUpdCuando_cambia_mi_estado_de_animo , paramUpdMedicamentos_bajar_peso , paramUpdCual_medicamento , paramUpdFrecuencia_Ejercicio , paramUpdDuracion_Ejercicio , paramUpdTipo_Ejercicio , paramUpdAntiguedad_Ejercicio , paramUpdIMC , paramUpdInterpretacion_IMC , paramUpdIMC_Pediatria , paramUpdComplexion_corporal , paramUpdInterpretacion_complexion_corporal , paramUpdDistribucion_de_grasa_corporal , paramUpdInterpretacion_grasa_corporal , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

		public int Update_Mediciones_Iniciales(Spartane.Core.Classes.Pacientes.Pacientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Pacientes.Pacientes PacientesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)PacientesDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)PacientesDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)PacientesDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)PacientesDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdTipo_de_Registro = _dataProvider.GetParameter();
                paramUpdTipo_de_Registro.ParameterName = "Tipo_de_Registro";
                paramUpdTipo_de_Registro.DbType = DbType.Int32;
                paramUpdTipo_de_Registro.Value = (object)PacientesDB.Tipo_de_Registro ?? DBNull.Value;
		var paramUpdTipo_de_Paciente = _dataProvider.GetParameter();
                paramUpdTipo_de_Paciente.ParameterName = "Tipo_de_Paciente";
                paramUpdTipo_de_Paciente.DbType = DbType.Int32;
                paramUpdTipo_de_Paciente.Value = (object)PacientesDB.Tipo_de_Paciente ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)PacientesDB.Usuario_Registrado ?? DBNull.Value;
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)PacientesDB.Empresa ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)PacientesDB.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)PacientesDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)PacientesDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)PacientesDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)PacientesDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)PacientesDB.Celular ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)PacientesDB.Email ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)PacientesDB.Fecha_de_nacimiento ?? DBNull.Value;
                var paramUpdNombre_del_Padre_o_Tutor = _dataProvider.GetParameter();
                paramUpdNombre_del_Padre_o_Tutor.ParameterName = "Nombre_del_Padre_o_Tutor";
                paramUpdNombre_del_Padre_o_Tutor.DbType = DbType.String;
                paramUpdNombre_del_Padre_o_Tutor.Value = (object)PacientesDB.Nombre_del_Padre_o_Tutor ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)PacientesDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdLugar_de_nacimiento = _dataProvider.GetParameter();
                paramUpdLugar_de_nacimiento.ParameterName = "Lugar_de_nacimiento";
                paramUpdLugar_de_nacimiento.DbType = DbType.Int32;
                paramUpdLugar_de_nacimiento.Value = (object)PacientesDB.Lugar_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)PacientesDB.Sexo ?? DBNull.Value;
		var paramUpdEstado_Civil = _dataProvider.GetParameter();
                paramUpdEstado_Civil.ParameterName = "Estado_Civil";
                paramUpdEstado_Civil.DbType = DbType.Int32;
                paramUpdEstado_Civil.Value = (object)PacientesDB.Estado_Civil ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)PacientesDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)PacientesDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)PacientesDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)PacientesDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)PacientesDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)PacientesDB.Ciudad ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)PacientesDB.Pais ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)PacientesDB.Estado ?? DBNull.Value;
                var paramUpdOcupacion = _dataProvider.GetParameter();
                paramUpdOcupacion.ParameterName = "Ocupacion";
                paramUpdOcupacion.DbType = DbType.String;
                paramUpdOcupacion.Value = (object)PacientesDB.Ocupacion ?? DBNull.Value;
                var paramUpdCantidad_hijos = _dataProvider.GetParameter();
                paramUpdCantidad_hijos.ParameterName = "Cantidad_hijos";
                paramUpdCantidad_hijos.DbType = DbType.Int32;
                paramUpdCantidad_hijos.Value = (object)PacientesDB.Cantidad_hijos ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)PacientesDB.Objetivo ?? DBNull.Value;
		var paramUpdEstatus_Paciente = _dataProvider.GetParameter();
                paramUpdEstatus_Paciente.ParameterName = "Estatus_Paciente";
                paramUpdEstatus_Paciente.DbType = DbType.Int32;
                paramUpdEstatus_Paciente.Value = (object)PacientesDB.Estatus_Paciente ?? DBNull.Value;
		var paramUpdCuenta_con_padecimientos = _dataProvider.GetParameter();
                paramUpdCuenta_con_padecimientos.ParameterName = "Cuenta_con_padecimientos";
                paramUpdCuenta_con_padecimientos.DbType = DbType.Int32;
                paramUpdCuenta_con_padecimientos.Value = (object)PacientesDB.Cuenta_con_padecimientos ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)entity.Frecuencia_Cardiaca ?? DBNull.Value;
                var paramUpdFrecuencia_Respiratoria = _dataProvider.GetParameter();
                paramUpdFrecuencia_Respiratoria.ParameterName = "Frecuencia_Respiratoria";
                paramUpdFrecuencia_Respiratoria.DbType = DbType.Int32;
                paramUpdFrecuencia_Respiratoria.Value = (object)entity.Frecuencia_Respiratoria ?? DBNull.Value;
                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)entity.Presion_sistolica ?? DBNull.Value;
                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)entity.Presion_diastolica ?? DBNull.Value;
                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)entity.Peso_actual ?? DBNull.Value;
                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)entity.Estatura ?? DBNull.Value;
                var paramUpdPeso_habitual = _dataProvider.GetParameter();
                paramUpdPeso_habitual.ParameterName = "Peso_habitual";
                paramUpdPeso_habitual.DbType = DbType.Decimal;
                paramUpdPeso_habitual.Value = (object)entity.Peso_habitual ?? DBNull.Value;
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)entity.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)entity.Circunferencia_de_cadera_cm ?? DBNull.Value;
                var paramUpdAnchura_de_muneca_mm = _dataProvider.GetParameter();
                paramUpdAnchura_de_muneca_mm.ParameterName = "Anchura_de_muneca_mm";
                paramUpdAnchura_de_muneca_mm.DbType = DbType.Int32;
                paramUpdAnchura_de_muneca_mm.Value = (object)entity.Anchura_de_muneca_mm ?? DBNull.Value;
                var paramUpdCircunferencia_de_brazo_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_brazo_cm.ParameterName = "Circunferencia_de_brazo_cm";
                paramUpdCircunferencia_de_brazo_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_brazo_cm.Value = (object)entity.Circunferencia_de_brazo_cm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_tricipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_tricipital_mm.ParameterName = "Pliegue_cutaneo_tricipital_mm";
                paramUpdPliegue_cutaneo_tricipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_tricipital_mm.Value = (object)entity.Pliegue_cutaneo_tricipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_bicipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_bicipital_mm.ParameterName = "Pliegue_cutaneo_bicipital_mm";
                paramUpdPliegue_cutaneo_bicipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_bicipital_mm.Value = (object)entity.Pliegue_cutaneo_bicipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_subescapular_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_subescapular_mm.ParameterName = "Pliegue_cutaneo_subescapular_mm";
                paramUpdPliegue_cutaneo_subescapular_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_subescapular_mm.Value = (object)entity.Pliegue_cutaneo_subescapular_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_supraespinal_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_supraespinal_mm.ParameterName = "Pliegue_cutaneo_supraespinal_mm";
                paramUpdPliegue_cutaneo_supraespinal_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_supraespinal_mm.Value = (object)entity.Pliegue_cutaneo_supraespinal_mm ?? DBNull.Value;
                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)entity.Edad_Metabolica ?? DBNull.Value;
                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)entity.Agua_corporal ?? DBNull.Value;
                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)entity.Grasa_Visceral ?? DBNull.Value;
                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)entity.Grasa_Corporal ?? DBNull.Value;
                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)entity.Grasa_Corporal_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)entity.Masa_Muscular_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_ = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_.ParameterName = "Masa_Muscular_";
                paramUpdMasa_Muscular_.DbType = DbType.Int32;
                paramUpdMasa_Muscular_.Value = (object)entity.Masa_Muscular_ ?? DBNull.Value;
		var paramUpdEsta_embarazada = _dataProvider.GetParameter();
                paramUpdEsta_embarazada.ParameterName = "Esta_embarazada";
                paramUpdEsta_embarazada.DbType = DbType.Int32;
                paramUpdEsta_embarazada.Value = (object)PacientesDB.Esta_embarazada ?? DBNull.Value;
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)PacientesDB.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdPeso_pregestacional = _dataProvider.GetParameter();
                paramUpdPeso_pregestacional.ParameterName = "Peso_pregestacional";
                paramUpdPeso_pregestacional.DbType = DbType.Int32;
                paramUpdPeso_pregestacional.Value = (object)PacientesDB.Peso_pregestacional ?? DBNull.Value;
		var paramUpdToma_anticonceptivos = _dataProvider.GetParameter();
                paramUpdToma_anticonceptivos.ParameterName = "Toma_anticonceptivos";
                paramUpdToma_anticonceptivos.DbType = DbType.Int32;
                paramUpdToma_anticonceptivos.Value = (object)PacientesDB.Toma_anticonceptivos ?? DBNull.Value;
                var paramUpdNombre_del_Anticonceptivo = _dataProvider.GetParameter();
                paramUpdNombre_del_Anticonceptivo.ParameterName = "Nombre_del_Anticonceptivo";
                paramUpdNombre_del_Anticonceptivo.DbType = DbType.String;
                paramUpdNombre_del_Anticonceptivo.Value = (object)PacientesDB.Nombre_del_Anticonceptivo ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)PacientesDB.Dosis ?? DBNull.Value;
		var paramUpdClimaterio = _dataProvider.GetParameter();
                paramUpdClimaterio.ParameterName = "Climaterio";
                paramUpdClimaterio.DbType = DbType.Int32;
                paramUpdClimaterio.Value = (object)PacientesDB.Climaterio ?? DBNull.Value;
                var paramUpdFecha_Climaterio = _dataProvider.GetParameter();
                paramUpdFecha_Climaterio.ParameterName = "Fecha_Climaterio";
                paramUpdFecha_Climaterio.DbType = DbType.DateTime;
                paramUpdFecha_Climaterio.Value = (object)PacientesDB.Fecha_Climaterio ?? DBNull.Value;
		var paramUpdTerapia_reemplazo_hormonal = _dataProvider.GetParameter();
                paramUpdTerapia_reemplazo_hormonal.ParameterName = "Terapia_reemplazo_hormonal";
                paramUpdTerapia_reemplazo_hormonal.DbType = DbType.Int32;
                paramUpdTerapia_reemplazo_hormonal.Value = (object)PacientesDB.Terapia_reemplazo_hormonal ?? DBNull.Value;
		var paramUpdTipo_Dieta = _dataProvider.GetParameter();
                paramUpdTipo_Dieta.ParameterName = "Tipo_Dieta";
                paramUpdTipo_Dieta.DbType = DbType.Int32;
                paramUpdTipo_Dieta.Value = (object)PacientesDB.Tipo_Dieta ?? DBNull.Value;
		var paramUpdSuplementos = _dataProvider.GetParameter();
                paramUpdSuplementos.ParameterName = "Suplementos";
                paramUpdSuplementos.DbType = DbType.Int32;
                paramUpdSuplementos.Value = (object)PacientesDB.Suplementos ?? DBNull.Value;
		var paramUpdConsumo_de_sal = _dataProvider.GetParameter();
                paramUpdConsumo_de_sal.ParameterName = "Consumo_de_sal";
                paramUpdConsumo_de_sal.DbType = DbType.Int32;
                paramUpdConsumo_de_sal.Value = (object)PacientesDB.Consumo_de_sal ?? DBNull.Value;
		var paramUpdGrasas_Preferencias = _dataProvider.GetParameter();
                paramUpdGrasas_Preferencias.ParameterName = "Grasas_Preferencias";
                paramUpdGrasas_Preferencias.DbType = DbType.Int32;
                paramUpdGrasas_Preferencias.Value = (object)PacientesDB.Grasas_Preferencias ?? DBNull.Value;
		var paramUpdComidas_cantidad = _dataProvider.GetParameter();
                paramUpdComidas_cantidad.ParameterName = "Comidas_cantidad";
                paramUpdComidas_cantidad.DbType = DbType.Int32;
                paramUpdComidas_cantidad.Value = (object)PacientesDB.Comidas_cantidad ?? DBNull.Value;
		var paramUpdPreparacion_Preferencias = _dataProvider.GetParameter();
                paramUpdPreparacion_Preferencias.ParameterName = "Preparacion_Preferencias";
                paramUpdPreparacion_Preferencias.DbType = DbType.Int32;
                paramUpdPreparacion_Preferencias.Value = (object)PacientesDB.Preparacion_Preferencias ?? DBNull.Value;
		var paramUpdEntre_comidas = _dataProvider.GetParameter();
                paramUpdEntre_comidas.ParameterName = "Entre_comidas";
                paramUpdEntre_comidas.DbType = DbType.Int32;
                paramUpdEntre_comidas.Value = (object)PacientesDB.Entre_comidas ?? DBNull.Value;
		var paramUpdApetito = _dataProvider.GetParameter();
                paramUpdApetito.ParameterName = "Apetito";
                paramUpdApetito.DbType = DbType.Int32;
                paramUpdApetito.Value = (object)PacientesDB.Apetito ?? DBNull.Value;
		var paramUpdHabitos_Modificacion = _dataProvider.GetParameter();
                paramUpdHabitos_Modificacion.ParameterName = "Habitos_Modificacion";
                paramUpdHabitos_Modificacion.DbType = DbType.Int32;
                paramUpdHabitos_Modificacion.Value = (object)PacientesDB.Habitos_Modificacion ?? DBNull.Value;
		var paramUpdHorario_hambre = _dataProvider.GetParameter();
                paramUpdHorario_hambre.ParameterName = "Horario_hambre";
                paramUpdHorario_hambre.DbType = DbType.Int32;
                paramUpdHorario_hambre.Value = (object)PacientesDB.Horario_hambre ?? DBNull.Value;
		var paramUpdCuando_cambia_mi_estado_de_animo = _dataProvider.GetParameter();
                paramUpdCuando_cambia_mi_estado_de_animo.ParameterName = "Cuando_cambia_mi_estado_de_animo";
                paramUpdCuando_cambia_mi_estado_de_animo.DbType = DbType.Int32;
                paramUpdCuando_cambia_mi_estado_de_animo.Value = (object)PacientesDB.Cuando_cambia_mi_estado_de_animo ?? DBNull.Value;
		var paramUpdMedicamentos_bajar_peso = _dataProvider.GetParameter();
                paramUpdMedicamentos_bajar_peso.ParameterName = "Medicamentos_bajar_peso";
                paramUpdMedicamentos_bajar_peso.DbType = DbType.Int32;
                paramUpdMedicamentos_bajar_peso.Value = (object)PacientesDB.Medicamentos_bajar_peso ?? DBNull.Value;
                var paramUpdCual_medicamento = _dataProvider.GetParameter();
                paramUpdCual_medicamento.ParameterName = "Cual_medicamento";
                paramUpdCual_medicamento.DbType = DbType.String;
                paramUpdCual_medicamento.Value = (object)PacientesDB.Cual_medicamento ?? DBNull.Value;
		var paramUpdFrecuencia_Ejercicio = _dataProvider.GetParameter();
                paramUpdFrecuencia_Ejercicio.ParameterName = "Frecuencia_Ejercicio";
                paramUpdFrecuencia_Ejercicio.DbType = DbType.Int32;
                paramUpdFrecuencia_Ejercicio.Value = (object)PacientesDB.Frecuencia_Ejercicio ?? DBNull.Value;
		var paramUpdDuracion_Ejercicio = _dataProvider.GetParameter();
                paramUpdDuracion_Ejercicio.ParameterName = "Duracion_Ejercicio";
                paramUpdDuracion_Ejercicio.DbType = DbType.Int32;
                paramUpdDuracion_Ejercicio.Value = (object)PacientesDB.Duracion_Ejercicio ?? DBNull.Value;
		var paramUpdTipo_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_Ejercicio.ParameterName = "Tipo_Ejercicio";
                paramUpdTipo_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_Ejercicio.Value = (object)PacientesDB.Tipo_Ejercicio ?? DBNull.Value;
		var paramUpdAntiguedad_Ejercicio = _dataProvider.GetParameter();
                paramUpdAntiguedad_Ejercicio.ParameterName = "Antiguedad_Ejercicio";
                paramUpdAntiguedad_Ejercicio.DbType = DbType.Int32;
                paramUpdAntiguedad_Ejercicio.Value = (object)PacientesDB.Antiguedad_Ejercicio ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)PacientesDB.IMC ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)PacientesDB.Interpretacion_IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)PacientesDB.IMC_Pediatria ?? DBNull.Value;
                var paramUpdComplexion_corporal = _dataProvider.GetParameter();
                paramUpdComplexion_corporal.ParameterName = "Complexion_corporal";
                paramUpdComplexion_corporal.DbType = DbType.String;
                paramUpdComplexion_corporal.Value = (object)PacientesDB.Complexion_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_complexion_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_complexion_corporal.ParameterName = "Interpretacion_complexion_corporal";
                paramUpdInterpretacion_complexion_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_complexion_corporal.Value = (object)PacientesDB.Interpretacion_complexion_corporal ?? DBNull.Value;
                var paramUpdDistribucion_de_grasa_corporal = _dataProvider.GetParameter();
                paramUpdDistribucion_de_grasa_corporal.ParameterName = "Distribucion_de_grasa_corporal";
                paramUpdDistribucion_de_grasa_corporal.DbType = DbType.String;
                paramUpdDistribucion_de_grasa_corporal.Value = (object)PacientesDB.Distribucion_de_grasa_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_grasa_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_grasa_corporal.ParameterName = "Interpretacion_grasa_corporal";
                paramUpdInterpretacion_grasa_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_grasa_corporal.Value = (object)PacientesDB.Interpretacion_grasa_corporal ?? DBNull.Value;
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.String;
                paramUpdIndice_cintura_cadera.Value = (object)PacientesDB.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)PacientesDB.Interpretacion_indice ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.String;
                paramUpdConsumo_de_agua_resultado.Value = (object)PacientesDB.Consumo_de_agua_resultado ?? DBNull.Value;
		var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)PacientesDB.Interpretacion_agua ?? DBNull.Value;
                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)PacientesDB.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;
		var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)PacientesDB.Interpretacion_frecuencia ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.String;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)PacientesDB.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
		var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)PacientesDB.Interpretacion_dificultad ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)PacientesDB.Calorias ?? DBNull.Value;
		var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)PacientesDB.Interpretacion_calorias ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)PacientesDB.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPacientes>("sp_UpdPacientes" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Registro , paramUpdTipo_de_Paciente , paramUpdUsuario_Registrado , paramUpdEmpresa , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdCelular , paramUpdEmail , paramUpdFecha_de_nacimiento , paramUpdNombre_del_Padre_o_Tutor , paramUpdPais_de_nacimiento , paramUpdLugar_de_nacimiento , paramUpdSexo , paramUpdEstado_Civil , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdPais , paramUpdEstado , paramUpdOcupacion , paramUpdCantidad_hijos , paramUpdObjetivo , paramUpdEstatus_Paciente , paramUpdCuenta_con_padecimientos , paramUpdFrecuencia_Cardiaca , paramUpdFrecuencia_Respiratoria , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdPeso_habitual , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdAnchura_de_muneca_mm , paramUpdCircunferencia_de_brazo_cm , paramUpdPliegue_cutaneo_tricipital_mm , paramUpdPliegue_cutaneo_bicipital_mm , paramUpdPliegue_cutaneo_subescapular_mm , paramUpdPliegue_cutaneo_supraespinal_mm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdMasa_Muscular_ , paramUpdEsta_embarazada , paramUpdSemana_de_gestacion , paramUpdPeso_pregestacional , paramUpdToma_anticonceptivos , paramUpdNombre_del_Anticonceptivo , paramUpdDosis , paramUpdClimaterio , paramUpdFecha_Climaterio , paramUpdTerapia_reemplazo_hormonal , paramUpdTipo_Dieta , paramUpdSuplementos , paramUpdConsumo_de_sal , paramUpdGrasas_Preferencias , paramUpdComidas_cantidad , paramUpdPreparacion_Preferencias , paramUpdEntre_comidas , paramUpdApetito , paramUpdHabitos_Modificacion , paramUpdHorario_hambre , paramUpdCuando_cambia_mi_estado_de_animo , paramUpdMedicamentos_bajar_peso , paramUpdCual_medicamento , paramUpdFrecuencia_Ejercicio , paramUpdDuracion_Ejercicio , paramUpdTipo_Ejercicio , paramUpdAntiguedad_Ejercicio , paramUpdIMC , paramUpdInterpretacion_IMC , paramUpdIMC_Pediatria , paramUpdComplexion_corporal , paramUpdInterpretacion_complexion_corporal , paramUpdDistribucion_de_grasa_corporal , paramUpdInterpretacion_grasa_corporal , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

		public int Update_Datos_Ginecologicos(Spartane.Core.Classes.Pacientes.Pacientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Pacientes.Pacientes PacientesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)PacientesDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)PacientesDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)PacientesDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)PacientesDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdTipo_de_Registro = _dataProvider.GetParameter();
                paramUpdTipo_de_Registro.ParameterName = "Tipo_de_Registro";
                paramUpdTipo_de_Registro.DbType = DbType.Int32;
                paramUpdTipo_de_Registro.Value = (object)PacientesDB.Tipo_de_Registro ?? DBNull.Value;
		var paramUpdTipo_de_Paciente = _dataProvider.GetParameter();
                paramUpdTipo_de_Paciente.ParameterName = "Tipo_de_Paciente";
                paramUpdTipo_de_Paciente.DbType = DbType.Int32;
                paramUpdTipo_de_Paciente.Value = (object)PacientesDB.Tipo_de_Paciente ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)PacientesDB.Usuario_Registrado ?? DBNull.Value;
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)PacientesDB.Empresa ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)PacientesDB.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)PacientesDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)PacientesDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)PacientesDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)PacientesDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)PacientesDB.Celular ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)PacientesDB.Email ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)PacientesDB.Fecha_de_nacimiento ?? DBNull.Value;
                var paramUpdNombre_del_Padre_o_Tutor = _dataProvider.GetParameter();
                paramUpdNombre_del_Padre_o_Tutor.ParameterName = "Nombre_del_Padre_o_Tutor";
                paramUpdNombre_del_Padre_o_Tutor.DbType = DbType.String;
                paramUpdNombre_del_Padre_o_Tutor.Value = (object)PacientesDB.Nombre_del_Padre_o_Tutor ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)PacientesDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdLugar_de_nacimiento = _dataProvider.GetParameter();
                paramUpdLugar_de_nacimiento.ParameterName = "Lugar_de_nacimiento";
                paramUpdLugar_de_nacimiento.DbType = DbType.Int32;
                paramUpdLugar_de_nacimiento.Value = (object)PacientesDB.Lugar_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)PacientesDB.Sexo ?? DBNull.Value;
		var paramUpdEstado_Civil = _dataProvider.GetParameter();
                paramUpdEstado_Civil.ParameterName = "Estado_Civil";
                paramUpdEstado_Civil.DbType = DbType.Int32;
                paramUpdEstado_Civil.Value = (object)PacientesDB.Estado_Civil ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)PacientesDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)PacientesDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)PacientesDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)PacientesDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)PacientesDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)PacientesDB.Ciudad ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)PacientesDB.Pais ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)PacientesDB.Estado ?? DBNull.Value;
                var paramUpdOcupacion = _dataProvider.GetParameter();
                paramUpdOcupacion.ParameterName = "Ocupacion";
                paramUpdOcupacion.DbType = DbType.String;
                paramUpdOcupacion.Value = (object)PacientesDB.Ocupacion ?? DBNull.Value;
                var paramUpdCantidad_hijos = _dataProvider.GetParameter();
                paramUpdCantidad_hijos.ParameterName = "Cantidad_hijos";
                paramUpdCantidad_hijos.DbType = DbType.Int32;
                paramUpdCantidad_hijos.Value = (object)PacientesDB.Cantidad_hijos ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)PacientesDB.Objetivo ?? DBNull.Value;
		var paramUpdEstatus_Paciente = _dataProvider.GetParameter();
                paramUpdEstatus_Paciente.ParameterName = "Estatus_Paciente";
                paramUpdEstatus_Paciente.DbType = DbType.Int32;
                paramUpdEstatus_Paciente.Value = (object)PacientesDB.Estatus_Paciente ?? DBNull.Value;
		var paramUpdCuenta_con_padecimientos = _dataProvider.GetParameter();
                paramUpdCuenta_con_padecimientos.ParameterName = "Cuenta_con_padecimientos";
                paramUpdCuenta_con_padecimientos.DbType = DbType.Int32;
                paramUpdCuenta_con_padecimientos.Value = (object)PacientesDB.Cuenta_con_padecimientos ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)PacientesDB.Frecuencia_Cardiaca ?? DBNull.Value;
                var paramUpdFrecuencia_Respiratoria = _dataProvider.GetParameter();
                paramUpdFrecuencia_Respiratoria.ParameterName = "Frecuencia_Respiratoria";
                paramUpdFrecuencia_Respiratoria.DbType = DbType.Int32;
                paramUpdFrecuencia_Respiratoria.Value = (object)PacientesDB.Frecuencia_Respiratoria ?? DBNull.Value;
                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)PacientesDB.Presion_sistolica ?? DBNull.Value;
                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)PacientesDB.Presion_diastolica ?? DBNull.Value;
                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)PacientesDB.Peso_actual ?? DBNull.Value;
                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)PacientesDB.Estatura ?? DBNull.Value;
                var paramUpdPeso_habitual = _dataProvider.GetParameter();
                paramUpdPeso_habitual.ParameterName = "Peso_habitual";
                paramUpdPeso_habitual.DbType = DbType.Decimal;
                paramUpdPeso_habitual.Value = (object)PacientesDB.Peso_habitual ?? DBNull.Value;
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)PacientesDB.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)PacientesDB.Circunferencia_de_cadera_cm ?? DBNull.Value;
                var paramUpdAnchura_de_muneca_mm = _dataProvider.GetParameter();
                paramUpdAnchura_de_muneca_mm.ParameterName = "Anchura_de_muneca_mm";
                paramUpdAnchura_de_muneca_mm.DbType = DbType.Int32;
                paramUpdAnchura_de_muneca_mm.Value = (object)PacientesDB.Anchura_de_muneca_mm ?? DBNull.Value;
                var paramUpdCircunferencia_de_brazo_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_brazo_cm.ParameterName = "Circunferencia_de_brazo_cm";
                paramUpdCircunferencia_de_brazo_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_brazo_cm.Value = (object)PacientesDB.Circunferencia_de_brazo_cm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_tricipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_tricipital_mm.ParameterName = "Pliegue_cutaneo_tricipital_mm";
                paramUpdPliegue_cutaneo_tricipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_tricipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_tricipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_bicipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_bicipital_mm.ParameterName = "Pliegue_cutaneo_bicipital_mm";
                paramUpdPliegue_cutaneo_bicipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_bicipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_bicipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_subescapular_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_subescapular_mm.ParameterName = "Pliegue_cutaneo_subescapular_mm";
                paramUpdPliegue_cutaneo_subescapular_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_subescapular_mm.Value = (object)PacientesDB.Pliegue_cutaneo_subescapular_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_supraespinal_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_supraespinal_mm.ParameterName = "Pliegue_cutaneo_supraespinal_mm";
                paramUpdPliegue_cutaneo_supraespinal_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_supraespinal_mm.Value = (object)PacientesDB.Pliegue_cutaneo_supraespinal_mm ?? DBNull.Value;
                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)PacientesDB.Edad_Metabolica ?? DBNull.Value;
                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)PacientesDB.Agua_corporal ?? DBNull.Value;
                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)PacientesDB.Grasa_Visceral ?? DBNull.Value;
                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)PacientesDB.Grasa_Corporal ?? DBNull.Value;
                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)PacientesDB.Grasa_Corporal_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)PacientesDB.Masa_Muscular_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_ = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_.ParameterName = "Masa_Muscular_";
                paramUpdMasa_Muscular_.DbType = DbType.Int32;
                paramUpdMasa_Muscular_.Value = (object)PacientesDB.Masa_Muscular_ ?? DBNull.Value;
		var paramUpdEsta_embarazada = _dataProvider.GetParameter();
                paramUpdEsta_embarazada.ParameterName = "Esta_embarazada";
                paramUpdEsta_embarazada.DbType = DbType.Int32;
                paramUpdEsta_embarazada.Value = (object)entity.Esta_embarazada ?? DBNull.Value;
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)entity.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdPeso_pregestacional = _dataProvider.GetParameter();
                paramUpdPeso_pregestacional.ParameterName = "Peso_pregestacional";
                paramUpdPeso_pregestacional.DbType = DbType.Int32;
                paramUpdPeso_pregestacional.Value = (object)entity.Peso_pregestacional ?? DBNull.Value;
		var paramUpdToma_anticonceptivos = _dataProvider.GetParameter();
                paramUpdToma_anticonceptivos.ParameterName = "Toma_anticonceptivos";
                paramUpdToma_anticonceptivos.DbType = DbType.Int32;
                paramUpdToma_anticonceptivos.Value = (object)entity.Toma_anticonceptivos ?? DBNull.Value;
                var paramUpdNombre_del_Anticonceptivo = _dataProvider.GetParameter();
                paramUpdNombre_del_Anticonceptivo.ParameterName = "Nombre_del_Anticonceptivo";
                paramUpdNombre_del_Anticonceptivo.DbType = DbType.String;
                paramUpdNombre_del_Anticonceptivo.Value = (object)entity.Nombre_del_Anticonceptivo ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)entity.Dosis ?? DBNull.Value;
		var paramUpdClimaterio = _dataProvider.GetParameter();
                paramUpdClimaterio.ParameterName = "Climaterio";
                paramUpdClimaterio.DbType = DbType.Int32;
                paramUpdClimaterio.Value = (object)entity.Climaterio ?? DBNull.Value;
                var paramUpdFecha_Climaterio = _dataProvider.GetParameter();
                paramUpdFecha_Climaterio.ParameterName = "Fecha_Climaterio";
                paramUpdFecha_Climaterio.DbType = DbType.DateTime;
                paramUpdFecha_Climaterio.Value = (object)entity.Fecha_Climaterio ?? DBNull.Value;
		var paramUpdTerapia_reemplazo_hormonal = _dataProvider.GetParameter();
                paramUpdTerapia_reemplazo_hormonal.ParameterName = "Terapia_reemplazo_hormonal";
                paramUpdTerapia_reemplazo_hormonal.DbType = DbType.Int32;
                paramUpdTerapia_reemplazo_hormonal.Value = (object)entity.Terapia_reemplazo_hormonal ?? DBNull.Value;
		var paramUpdTipo_Dieta = _dataProvider.GetParameter();
                paramUpdTipo_Dieta.ParameterName = "Tipo_Dieta";
                paramUpdTipo_Dieta.DbType = DbType.Int32;
                paramUpdTipo_Dieta.Value = (object)PacientesDB.Tipo_Dieta ?? DBNull.Value;
		var paramUpdSuplementos = _dataProvider.GetParameter();
                paramUpdSuplementos.ParameterName = "Suplementos";
                paramUpdSuplementos.DbType = DbType.Int32;
                paramUpdSuplementos.Value = (object)PacientesDB.Suplementos ?? DBNull.Value;
		var paramUpdConsumo_de_sal = _dataProvider.GetParameter();
                paramUpdConsumo_de_sal.ParameterName = "Consumo_de_sal";
                paramUpdConsumo_de_sal.DbType = DbType.Int32;
                paramUpdConsumo_de_sal.Value = (object)PacientesDB.Consumo_de_sal ?? DBNull.Value;
		var paramUpdGrasas_Preferencias = _dataProvider.GetParameter();
                paramUpdGrasas_Preferencias.ParameterName = "Grasas_Preferencias";
                paramUpdGrasas_Preferencias.DbType = DbType.Int32;
                paramUpdGrasas_Preferencias.Value = (object)PacientesDB.Grasas_Preferencias ?? DBNull.Value;
		var paramUpdComidas_cantidad = _dataProvider.GetParameter();
                paramUpdComidas_cantidad.ParameterName = "Comidas_cantidad";
                paramUpdComidas_cantidad.DbType = DbType.Int32;
                paramUpdComidas_cantidad.Value = (object)PacientesDB.Comidas_cantidad ?? DBNull.Value;
		var paramUpdPreparacion_Preferencias = _dataProvider.GetParameter();
                paramUpdPreparacion_Preferencias.ParameterName = "Preparacion_Preferencias";
                paramUpdPreparacion_Preferencias.DbType = DbType.Int32;
                paramUpdPreparacion_Preferencias.Value = (object)PacientesDB.Preparacion_Preferencias ?? DBNull.Value;
		var paramUpdEntre_comidas = _dataProvider.GetParameter();
                paramUpdEntre_comidas.ParameterName = "Entre_comidas";
                paramUpdEntre_comidas.DbType = DbType.Int32;
                paramUpdEntre_comidas.Value = (object)PacientesDB.Entre_comidas ?? DBNull.Value;
		var paramUpdApetito = _dataProvider.GetParameter();
                paramUpdApetito.ParameterName = "Apetito";
                paramUpdApetito.DbType = DbType.Int32;
                paramUpdApetito.Value = (object)PacientesDB.Apetito ?? DBNull.Value;
		var paramUpdHabitos_Modificacion = _dataProvider.GetParameter();
                paramUpdHabitos_Modificacion.ParameterName = "Habitos_Modificacion";
                paramUpdHabitos_Modificacion.DbType = DbType.Int32;
                paramUpdHabitos_Modificacion.Value = (object)PacientesDB.Habitos_Modificacion ?? DBNull.Value;
		var paramUpdHorario_hambre = _dataProvider.GetParameter();
                paramUpdHorario_hambre.ParameterName = "Horario_hambre";
                paramUpdHorario_hambre.DbType = DbType.Int32;
                paramUpdHorario_hambre.Value = (object)PacientesDB.Horario_hambre ?? DBNull.Value;
		var paramUpdCuando_cambia_mi_estado_de_animo = _dataProvider.GetParameter();
                paramUpdCuando_cambia_mi_estado_de_animo.ParameterName = "Cuando_cambia_mi_estado_de_animo";
                paramUpdCuando_cambia_mi_estado_de_animo.DbType = DbType.Int32;
                paramUpdCuando_cambia_mi_estado_de_animo.Value = (object)PacientesDB.Cuando_cambia_mi_estado_de_animo ?? DBNull.Value;
		var paramUpdMedicamentos_bajar_peso = _dataProvider.GetParameter();
                paramUpdMedicamentos_bajar_peso.ParameterName = "Medicamentos_bajar_peso";
                paramUpdMedicamentos_bajar_peso.DbType = DbType.Int32;
                paramUpdMedicamentos_bajar_peso.Value = (object)PacientesDB.Medicamentos_bajar_peso ?? DBNull.Value;
                var paramUpdCual_medicamento = _dataProvider.GetParameter();
                paramUpdCual_medicamento.ParameterName = "Cual_medicamento";
                paramUpdCual_medicamento.DbType = DbType.String;
                paramUpdCual_medicamento.Value = (object)PacientesDB.Cual_medicamento ?? DBNull.Value;
		var paramUpdFrecuencia_Ejercicio = _dataProvider.GetParameter();
                paramUpdFrecuencia_Ejercicio.ParameterName = "Frecuencia_Ejercicio";
                paramUpdFrecuencia_Ejercicio.DbType = DbType.Int32;
                paramUpdFrecuencia_Ejercicio.Value = (object)PacientesDB.Frecuencia_Ejercicio ?? DBNull.Value;
		var paramUpdDuracion_Ejercicio = _dataProvider.GetParameter();
                paramUpdDuracion_Ejercicio.ParameterName = "Duracion_Ejercicio";
                paramUpdDuracion_Ejercicio.DbType = DbType.Int32;
                paramUpdDuracion_Ejercicio.Value = (object)PacientesDB.Duracion_Ejercicio ?? DBNull.Value;
		var paramUpdTipo_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_Ejercicio.ParameterName = "Tipo_Ejercicio";
                paramUpdTipo_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_Ejercicio.Value = (object)PacientesDB.Tipo_Ejercicio ?? DBNull.Value;
		var paramUpdAntiguedad_Ejercicio = _dataProvider.GetParameter();
                paramUpdAntiguedad_Ejercicio.ParameterName = "Antiguedad_Ejercicio";
                paramUpdAntiguedad_Ejercicio.DbType = DbType.Int32;
                paramUpdAntiguedad_Ejercicio.Value = (object)PacientesDB.Antiguedad_Ejercicio ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)PacientesDB.IMC ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)PacientesDB.Interpretacion_IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)PacientesDB.IMC_Pediatria ?? DBNull.Value;
                var paramUpdComplexion_corporal = _dataProvider.GetParameter();
                paramUpdComplexion_corporal.ParameterName = "Complexion_corporal";
                paramUpdComplexion_corporal.DbType = DbType.String;
                paramUpdComplexion_corporal.Value = (object)PacientesDB.Complexion_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_complexion_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_complexion_corporal.ParameterName = "Interpretacion_complexion_corporal";
                paramUpdInterpretacion_complexion_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_complexion_corporal.Value = (object)PacientesDB.Interpretacion_complexion_corporal ?? DBNull.Value;
                var paramUpdDistribucion_de_grasa_corporal = _dataProvider.GetParameter();
                paramUpdDistribucion_de_grasa_corporal.ParameterName = "Distribucion_de_grasa_corporal";
                paramUpdDistribucion_de_grasa_corporal.DbType = DbType.String;
                paramUpdDistribucion_de_grasa_corporal.Value = (object)PacientesDB.Distribucion_de_grasa_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_grasa_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_grasa_corporal.ParameterName = "Interpretacion_grasa_corporal";
                paramUpdInterpretacion_grasa_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_grasa_corporal.Value = (object)PacientesDB.Interpretacion_grasa_corporal ?? DBNull.Value;
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.String;
                paramUpdIndice_cintura_cadera.Value = (object)PacientesDB.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)PacientesDB.Interpretacion_indice ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.String;
                paramUpdConsumo_de_agua_resultado.Value = (object)PacientesDB.Consumo_de_agua_resultado ?? DBNull.Value;
		var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)PacientesDB.Interpretacion_agua ?? DBNull.Value;
                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)PacientesDB.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;
		var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)PacientesDB.Interpretacion_frecuencia ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.String;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)PacientesDB.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
		var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)PacientesDB.Interpretacion_dificultad ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)PacientesDB.Calorias ?? DBNull.Value;
		var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)PacientesDB.Interpretacion_calorias ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)PacientesDB.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPacientes>("sp_UpdPacientes" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Registro , paramUpdTipo_de_Paciente , paramUpdUsuario_Registrado , paramUpdEmpresa , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdCelular , paramUpdEmail , paramUpdFecha_de_nacimiento , paramUpdNombre_del_Padre_o_Tutor , paramUpdPais_de_nacimiento , paramUpdLugar_de_nacimiento , paramUpdSexo , paramUpdEstado_Civil , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdPais , paramUpdEstado , paramUpdOcupacion , paramUpdCantidad_hijos , paramUpdObjetivo , paramUpdEstatus_Paciente , paramUpdCuenta_con_padecimientos , paramUpdFrecuencia_Cardiaca , paramUpdFrecuencia_Respiratoria , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdPeso_habitual , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdAnchura_de_muneca_mm , paramUpdCircunferencia_de_brazo_cm , paramUpdPliegue_cutaneo_tricipital_mm , paramUpdPliegue_cutaneo_bicipital_mm , paramUpdPliegue_cutaneo_subescapular_mm , paramUpdPliegue_cutaneo_supraespinal_mm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdMasa_Muscular_ , paramUpdEsta_embarazada , paramUpdSemana_de_gestacion , paramUpdPeso_pregestacional , paramUpdToma_anticonceptivos , paramUpdNombre_del_Anticonceptivo , paramUpdDosis , paramUpdClimaterio , paramUpdFecha_Climaterio , paramUpdTerapia_reemplazo_hormonal , paramUpdTipo_Dieta , paramUpdSuplementos , paramUpdConsumo_de_sal , paramUpdGrasas_Preferencias , paramUpdComidas_cantidad , paramUpdPreparacion_Preferencias , paramUpdEntre_comidas , paramUpdApetito , paramUpdHabitos_Modificacion , paramUpdHorario_hambre , paramUpdCuando_cambia_mi_estado_de_animo , paramUpdMedicamentos_bajar_peso , paramUpdCual_medicamento , paramUpdFrecuencia_Ejercicio , paramUpdDuracion_Ejercicio , paramUpdTipo_Ejercicio , paramUpdAntiguedad_Ejercicio , paramUpdIMC , paramUpdInterpretacion_IMC , paramUpdIMC_Pediatria , paramUpdComplexion_corporal , paramUpdInterpretacion_complexion_corporal , paramUpdDistribucion_de_grasa_corporal , paramUpdInterpretacion_grasa_corporal , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

		public int Update_Historia_Nutricional(Spartane.Core.Classes.Pacientes.Pacientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Pacientes.Pacientes PacientesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)PacientesDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)PacientesDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)PacientesDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)PacientesDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdTipo_de_Registro = _dataProvider.GetParameter();
                paramUpdTipo_de_Registro.ParameterName = "Tipo_de_Registro";
                paramUpdTipo_de_Registro.DbType = DbType.Int32;
                paramUpdTipo_de_Registro.Value = (object)PacientesDB.Tipo_de_Registro ?? DBNull.Value;
		var paramUpdTipo_de_Paciente = _dataProvider.GetParameter();
                paramUpdTipo_de_Paciente.ParameterName = "Tipo_de_Paciente";
                paramUpdTipo_de_Paciente.DbType = DbType.Int32;
                paramUpdTipo_de_Paciente.Value = (object)PacientesDB.Tipo_de_Paciente ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)PacientesDB.Usuario_Registrado ?? DBNull.Value;
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)PacientesDB.Empresa ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)PacientesDB.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)PacientesDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)PacientesDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)PacientesDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)PacientesDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)PacientesDB.Celular ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)PacientesDB.Email ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)PacientesDB.Fecha_de_nacimiento ?? DBNull.Value;
                var paramUpdNombre_del_Padre_o_Tutor = _dataProvider.GetParameter();
                paramUpdNombre_del_Padre_o_Tutor.ParameterName = "Nombre_del_Padre_o_Tutor";
                paramUpdNombre_del_Padre_o_Tutor.DbType = DbType.String;
                paramUpdNombre_del_Padre_o_Tutor.Value = (object)PacientesDB.Nombre_del_Padre_o_Tutor ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)PacientesDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdLugar_de_nacimiento = _dataProvider.GetParameter();
                paramUpdLugar_de_nacimiento.ParameterName = "Lugar_de_nacimiento";
                paramUpdLugar_de_nacimiento.DbType = DbType.Int32;
                paramUpdLugar_de_nacimiento.Value = (object)PacientesDB.Lugar_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)PacientesDB.Sexo ?? DBNull.Value;
		var paramUpdEstado_Civil = _dataProvider.GetParameter();
                paramUpdEstado_Civil.ParameterName = "Estado_Civil";
                paramUpdEstado_Civil.DbType = DbType.Int32;
                paramUpdEstado_Civil.Value = (object)PacientesDB.Estado_Civil ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)PacientesDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)PacientesDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)PacientesDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)PacientesDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)PacientesDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)PacientesDB.Ciudad ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)PacientesDB.Pais ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)PacientesDB.Estado ?? DBNull.Value;
                var paramUpdOcupacion = _dataProvider.GetParameter();
                paramUpdOcupacion.ParameterName = "Ocupacion";
                paramUpdOcupacion.DbType = DbType.String;
                paramUpdOcupacion.Value = (object)PacientesDB.Ocupacion ?? DBNull.Value;
                var paramUpdCantidad_hijos = _dataProvider.GetParameter();
                paramUpdCantidad_hijos.ParameterName = "Cantidad_hijos";
                paramUpdCantidad_hijos.DbType = DbType.Int32;
                paramUpdCantidad_hijos.Value = (object)PacientesDB.Cantidad_hijos ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)PacientesDB.Objetivo ?? DBNull.Value;
		var paramUpdEstatus_Paciente = _dataProvider.GetParameter();
                paramUpdEstatus_Paciente.ParameterName = "Estatus_Paciente";
                paramUpdEstatus_Paciente.DbType = DbType.Int32;
                paramUpdEstatus_Paciente.Value = (object)PacientesDB.Estatus_Paciente ?? DBNull.Value;
		var paramUpdCuenta_con_padecimientos = _dataProvider.GetParameter();
                paramUpdCuenta_con_padecimientos.ParameterName = "Cuenta_con_padecimientos";
                paramUpdCuenta_con_padecimientos.DbType = DbType.Int32;
                paramUpdCuenta_con_padecimientos.Value = (object)PacientesDB.Cuenta_con_padecimientos ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)PacientesDB.Frecuencia_Cardiaca ?? DBNull.Value;
                var paramUpdFrecuencia_Respiratoria = _dataProvider.GetParameter();
                paramUpdFrecuencia_Respiratoria.ParameterName = "Frecuencia_Respiratoria";
                paramUpdFrecuencia_Respiratoria.DbType = DbType.Int32;
                paramUpdFrecuencia_Respiratoria.Value = (object)PacientesDB.Frecuencia_Respiratoria ?? DBNull.Value;
                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)PacientesDB.Presion_sistolica ?? DBNull.Value;
                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)PacientesDB.Presion_diastolica ?? DBNull.Value;
                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)PacientesDB.Peso_actual ?? DBNull.Value;
                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)PacientesDB.Estatura ?? DBNull.Value;
                var paramUpdPeso_habitual = _dataProvider.GetParameter();
                paramUpdPeso_habitual.ParameterName = "Peso_habitual";
                paramUpdPeso_habitual.DbType = DbType.Decimal;
                paramUpdPeso_habitual.Value = (object)PacientesDB.Peso_habitual ?? DBNull.Value;
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)PacientesDB.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)PacientesDB.Circunferencia_de_cadera_cm ?? DBNull.Value;
                var paramUpdAnchura_de_muneca_mm = _dataProvider.GetParameter();
                paramUpdAnchura_de_muneca_mm.ParameterName = "Anchura_de_muneca_mm";
                paramUpdAnchura_de_muneca_mm.DbType = DbType.Int32;
                paramUpdAnchura_de_muneca_mm.Value = (object)PacientesDB.Anchura_de_muneca_mm ?? DBNull.Value;
                var paramUpdCircunferencia_de_brazo_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_brazo_cm.ParameterName = "Circunferencia_de_brazo_cm";
                paramUpdCircunferencia_de_brazo_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_brazo_cm.Value = (object)PacientesDB.Circunferencia_de_brazo_cm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_tricipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_tricipital_mm.ParameterName = "Pliegue_cutaneo_tricipital_mm";
                paramUpdPliegue_cutaneo_tricipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_tricipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_tricipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_bicipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_bicipital_mm.ParameterName = "Pliegue_cutaneo_bicipital_mm";
                paramUpdPliegue_cutaneo_bicipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_bicipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_bicipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_subescapular_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_subescapular_mm.ParameterName = "Pliegue_cutaneo_subescapular_mm";
                paramUpdPliegue_cutaneo_subescapular_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_subescapular_mm.Value = (object)PacientesDB.Pliegue_cutaneo_subescapular_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_supraespinal_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_supraespinal_mm.ParameterName = "Pliegue_cutaneo_supraespinal_mm";
                paramUpdPliegue_cutaneo_supraespinal_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_supraespinal_mm.Value = (object)PacientesDB.Pliegue_cutaneo_supraespinal_mm ?? DBNull.Value;
                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)PacientesDB.Edad_Metabolica ?? DBNull.Value;
                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)PacientesDB.Agua_corporal ?? DBNull.Value;
                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)PacientesDB.Grasa_Visceral ?? DBNull.Value;
                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)PacientesDB.Grasa_Corporal ?? DBNull.Value;
                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)PacientesDB.Grasa_Corporal_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)PacientesDB.Masa_Muscular_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_ = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_.ParameterName = "Masa_Muscular_";
                paramUpdMasa_Muscular_.DbType = DbType.Int32;
                paramUpdMasa_Muscular_.Value = (object)PacientesDB.Masa_Muscular_ ?? DBNull.Value;
		var paramUpdEsta_embarazada = _dataProvider.GetParameter();
                paramUpdEsta_embarazada.ParameterName = "Esta_embarazada";
                paramUpdEsta_embarazada.DbType = DbType.Int32;
                paramUpdEsta_embarazada.Value = (object)PacientesDB.Esta_embarazada ?? DBNull.Value;
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)PacientesDB.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdPeso_pregestacional = _dataProvider.GetParameter();
                paramUpdPeso_pregestacional.ParameterName = "Peso_pregestacional";
                paramUpdPeso_pregestacional.DbType = DbType.Int32;
                paramUpdPeso_pregestacional.Value = (object)PacientesDB.Peso_pregestacional ?? DBNull.Value;
		var paramUpdToma_anticonceptivos = _dataProvider.GetParameter();
                paramUpdToma_anticonceptivos.ParameterName = "Toma_anticonceptivos";
                paramUpdToma_anticonceptivos.DbType = DbType.Int32;
                paramUpdToma_anticonceptivos.Value = (object)PacientesDB.Toma_anticonceptivos ?? DBNull.Value;
                var paramUpdNombre_del_Anticonceptivo = _dataProvider.GetParameter();
                paramUpdNombre_del_Anticonceptivo.ParameterName = "Nombre_del_Anticonceptivo";
                paramUpdNombre_del_Anticonceptivo.DbType = DbType.String;
                paramUpdNombre_del_Anticonceptivo.Value = (object)PacientesDB.Nombre_del_Anticonceptivo ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)PacientesDB.Dosis ?? DBNull.Value;
		var paramUpdClimaterio = _dataProvider.GetParameter();
                paramUpdClimaterio.ParameterName = "Climaterio";
                paramUpdClimaterio.DbType = DbType.Int32;
                paramUpdClimaterio.Value = (object)PacientesDB.Climaterio ?? DBNull.Value;
                var paramUpdFecha_Climaterio = _dataProvider.GetParameter();
                paramUpdFecha_Climaterio.ParameterName = "Fecha_Climaterio";
                paramUpdFecha_Climaterio.DbType = DbType.DateTime;
                paramUpdFecha_Climaterio.Value = (object)PacientesDB.Fecha_Climaterio ?? DBNull.Value;
		var paramUpdTerapia_reemplazo_hormonal = _dataProvider.GetParameter();
                paramUpdTerapia_reemplazo_hormonal.ParameterName = "Terapia_reemplazo_hormonal";
                paramUpdTerapia_reemplazo_hormonal.DbType = DbType.Int32;
                paramUpdTerapia_reemplazo_hormonal.Value = (object)PacientesDB.Terapia_reemplazo_hormonal ?? DBNull.Value;
		var paramUpdTipo_Dieta = _dataProvider.GetParameter();
                paramUpdTipo_Dieta.ParameterName = "Tipo_Dieta";
                paramUpdTipo_Dieta.DbType = DbType.Int32;
                paramUpdTipo_Dieta.Value = (object)entity.Tipo_Dieta ?? DBNull.Value;
		var paramUpdSuplementos = _dataProvider.GetParameter();
                paramUpdSuplementos.ParameterName = "Suplementos";
                paramUpdSuplementos.DbType = DbType.Int32;
                paramUpdSuplementos.Value = (object)entity.Suplementos ?? DBNull.Value;
		var paramUpdConsumo_de_sal = _dataProvider.GetParameter();
                paramUpdConsumo_de_sal.ParameterName = "Consumo_de_sal";
                paramUpdConsumo_de_sal.DbType = DbType.Int32;
                paramUpdConsumo_de_sal.Value = (object)entity.Consumo_de_sal ?? DBNull.Value;
		var paramUpdGrasas_Preferencias = _dataProvider.GetParameter();
                paramUpdGrasas_Preferencias.ParameterName = "Grasas_Preferencias";
                paramUpdGrasas_Preferencias.DbType = DbType.Int32;
                paramUpdGrasas_Preferencias.Value = (object)entity.Grasas_Preferencias ?? DBNull.Value;
		var paramUpdComidas_cantidad = _dataProvider.GetParameter();
                paramUpdComidas_cantidad.ParameterName = "Comidas_cantidad";
                paramUpdComidas_cantidad.DbType = DbType.Int32;
                paramUpdComidas_cantidad.Value = (object)entity.Comidas_cantidad ?? DBNull.Value;
		var paramUpdPreparacion_Preferencias = _dataProvider.GetParameter();
                paramUpdPreparacion_Preferencias.ParameterName = "Preparacion_Preferencias";
                paramUpdPreparacion_Preferencias.DbType = DbType.Int32;
                paramUpdPreparacion_Preferencias.Value = (object)entity.Preparacion_Preferencias ?? DBNull.Value;
		var paramUpdEntre_comidas = _dataProvider.GetParameter();
                paramUpdEntre_comidas.ParameterName = "Entre_comidas";
                paramUpdEntre_comidas.DbType = DbType.Int32;
                paramUpdEntre_comidas.Value = (object)entity.Entre_comidas ?? DBNull.Value;
		var paramUpdApetito = _dataProvider.GetParameter();
                paramUpdApetito.ParameterName = "Apetito";
                paramUpdApetito.DbType = DbType.Int32;
                paramUpdApetito.Value = (object)entity.Apetito ?? DBNull.Value;
		var paramUpdHabitos_Modificacion = _dataProvider.GetParameter();
                paramUpdHabitos_Modificacion.ParameterName = "Habitos_Modificacion";
                paramUpdHabitos_Modificacion.DbType = DbType.Int32;
                paramUpdHabitos_Modificacion.Value = (object)entity.Habitos_Modificacion ?? DBNull.Value;
		var paramUpdHorario_hambre = _dataProvider.GetParameter();
                paramUpdHorario_hambre.ParameterName = "Horario_hambre";
                paramUpdHorario_hambre.DbType = DbType.Int32;
                paramUpdHorario_hambre.Value = (object)entity.Horario_hambre ?? DBNull.Value;
		var paramUpdCuando_cambia_mi_estado_de_animo = _dataProvider.GetParameter();
                paramUpdCuando_cambia_mi_estado_de_animo.ParameterName = "Cuando_cambia_mi_estado_de_animo";
                paramUpdCuando_cambia_mi_estado_de_animo.DbType = DbType.Int32;
                paramUpdCuando_cambia_mi_estado_de_animo.Value = (object)entity.Cuando_cambia_mi_estado_de_animo ?? DBNull.Value;
		var paramUpdMedicamentos_bajar_peso = _dataProvider.GetParameter();
                paramUpdMedicamentos_bajar_peso.ParameterName = "Medicamentos_bajar_peso";
                paramUpdMedicamentos_bajar_peso.DbType = DbType.Int32;
                paramUpdMedicamentos_bajar_peso.Value = (object)entity.Medicamentos_bajar_peso ?? DBNull.Value;
                var paramUpdCual_medicamento = _dataProvider.GetParameter();
                paramUpdCual_medicamento.ParameterName = "Cual_medicamento";
                paramUpdCual_medicamento.DbType = DbType.String;
                paramUpdCual_medicamento.Value = (object)entity.Cual_medicamento ?? DBNull.Value;
		var paramUpdFrecuencia_Ejercicio = _dataProvider.GetParameter();
                paramUpdFrecuencia_Ejercicio.ParameterName = "Frecuencia_Ejercicio";
                paramUpdFrecuencia_Ejercicio.DbType = DbType.Int32;
                paramUpdFrecuencia_Ejercicio.Value = (object)PacientesDB.Frecuencia_Ejercicio ?? DBNull.Value;
		var paramUpdDuracion_Ejercicio = _dataProvider.GetParameter();
                paramUpdDuracion_Ejercicio.ParameterName = "Duracion_Ejercicio";
                paramUpdDuracion_Ejercicio.DbType = DbType.Int32;
                paramUpdDuracion_Ejercicio.Value = (object)PacientesDB.Duracion_Ejercicio ?? DBNull.Value;
		var paramUpdTipo_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_Ejercicio.ParameterName = "Tipo_Ejercicio";
                paramUpdTipo_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_Ejercicio.Value = (object)PacientesDB.Tipo_Ejercicio ?? DBNull.Value;
		var paramUpdAntiguedad_Ejercicio = _dataProvider.GetParameter();
                paramUpdAntiguedad_Ejercicio.ParameterName = "Antiguedad_Ejercicio";
                paramUpdAntiguedad_Ejercicio.DbType = DbType.Int32;
                paramUpdAntiguedad_Ejercicio.Value = (object)PacientesDB.Antiguedad_Ejercicio ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)PacientesDB.IMC ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)PacientesDB.Interpretacion_IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)PacientesDB.IMC_Pediatria ?? DBNull.Value;
                var paramUpdComplexion_corporal = _dataProvider.GetParameter();
                paramUpdComplexion_corporal.ParameterName = "Complexion_corporal";
                paramUpdComplexion_corporal.DbType = DbType.String;
                paramUpdComplexion_corporal.Value = (object)PacientesDB.Complexion_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_complexion_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_complexion_corporal.ParameterName = "Interpretacion_complexion_corporal";
                paramUpdInterpretacion_complexion_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_complexion_corporal.Value = (object)PacientesDB.Interpretacion_complexion_corporal ?? DBNull.Value;
                var paramUpdDistribucion_de_grasa_corporal = _dataProvider.GetParameter();
                paramUpdDistribucion_de_grasa_corporal.ParameterName = "Distribucion_de_grasa_corporal";
                paramUpdDistribucion_de_grasa_corporal.DbType = DbType.String;
                paramUpdDistribucion_de_grasa_corporal.Value = (object)PacientesDB.Distribucion_de_grasa_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_grasa_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_grasa_corporal.ParameterName = "Interpretacion_grasa_corporal";
                paramUpdInterpretacion_grasa_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_grasa_corporal.Value = (object)PacientesDB.Interpretacion_grasa_corporal ?? DBNull.Value;
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.String;
                paramUpdIndice_cintura_cadera.Value = (object)PacientesDB.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)PacientesDB.Interpretacion_indice ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.String;
                paramUpdConsumo_de_agua_resultado.Value = (object)PacientesDB.Consumo_de_agua_resultado ?? DBNull.Value;
		var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)PacientesDB.Interpretacion_agua ?? DBNull.Value;
                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)PacientesDB.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;
		var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)PacientesDB.Interpretacion_frecuencia ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.String;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)PacientesDB.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
		var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)PacientesDB.Interpretacion_dificultad ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)PacientesDB.Calorias ?? DBNull.Value;
		var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)PacientesDB.Interpretacion_calorias ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)PacientesDB.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPacientes>("sp_UpdPacientes" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Registro , paramUpdTipo_de_Paciente , paramUpdUsuario_Registrado , paramUpdEmpresa , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdCelular , paramUpdEmail , paramUpdFecha_de_nacimiento , paramUpdNombre_del_Padre_o_Tutor , paramUpdPais_de_nacimiento , paramUpdLugar_de_nacimiento , paramUpdSexo , paramUpdEstado_Civil , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdPais , paramUpdEstado , paramUpdOcupacion , paramUpdCantidad_hijos , paramUpdObjetivo , paramUpdEstatus_Paciente , paramUpdCuenta_con_padecimientos , paramUpdFrecuencia_Cardiaca , paramUpdFrecuencia_Respiratoria , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdPeso_habitual , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdAnchura_de_muneca_mm , paramUpdCircunferencia_de_brazo_cm , paramUpdPliegue_cutaneo_tricipital_mm , paramUpdPliegue_cutaneo_bicipital_mm , paramUpdPliegue_cutaneo_subescapular_mm , paramUpdPliegue_cutaneo_supraespinal_mm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdMasa_Muscular_ , paramUpdEsta_embarazada , paramUpdSemana_de_gestacion , paramUpdPeso_pregestacional , paramUpdToma_anticonceptivos , paramUpdNombre_del_Anticonceptivo , paramUpdDosis , paramUpdClimaterio , paramUpdFecha_Climaterio , paramUpdTerapia_reemplazo_hormonal , paramUpdTipo_Dieta , paramUpdSuplementos , paramUpdConsumo_de_sal , paramUpdGrasas_Preferencias , paramUpdComidas_cantidad , paramUpdPreparacion_Preferencias , paramUpdEntre_comidas , paramUpdApetito , paramUpdHabitos_Modificacion , paramUpdHorario_hambre , paramUpdCuando_cambia_mi_estado_de_animo , paramUpdMedicamentos_bajar_peso , paramUpdCual_medicamento , paramUpdFrecuencia_Ejercicio , paramUpdDuracion_Ejercicio , paramUpdTipo_Ejercicio , paramUpdAntiguedad_Ejercicio , paramUpdIMC , paramUpdInterpretacion_IMC , paramUpdIMC_Pediatria , paramUpdComplexion_corporal , paramUpdInterpretacion_complexion_corporal , paramUpdDistribucion_de_grasa_corporal , paramUpdInterpretacion_grasa_corporal , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

		public int Update_Estilo_de_Vida(Spartane.Core.Classes.Pacientes.Pacientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Pacientes.Pacientes PacientesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)PacientesDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)PacientesDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)PacientesDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)PacientesDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdTipo_de_Registro = _dataProvider.GetParameter();
                paramUpdTipo_de_Registro.ParameterName = "Tipo_de_Registro";
                paramUpdTipo_de_Registro.DbType = DbType.Int32;
                paramUpdTipo_de_Registro.Value = (object)PacientesDB.Tipo_de_Registro ?? DBNull.Value;
		var paramUpdTipo_de_Paciente = _dataProvider.GetParameter();
                paramUpdTipo_de_Paciente.ParameterName = "Tipo_de_Paciente";
                paramUpdTipo_de_Paciente.DbType = DbType.Int32;
                paramUpdTipo_de_Paciente.Value = (object)PacientesDB.Tipo_de_Paciente ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)PacientesDB.Usuario_Registrado ?? DBNull.Value;
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)PacientesDB.Empresa ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)PacientesDB.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)PacientesDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)PacientesDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)PacientesDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)PacientesDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)PacientesDB.Celular ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)PacientesDB.Email ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)PacientesDB.Fecha_de_nacimiento ?? DBNull.Value;
                var paramUpdNombre_del_Padre_o_Tutor = _dataProvider.GetParameter();
                paramUpdNombre_del_Padre_o_Tutor.ParameterName = "Nombre_del_Padre_o_Tutor";
                paramUpdNombre_del_Padre_o_Tutor.DbType = DbType.String;
                paramUpdNombre_del_Padre_o_Tutor.Value = (object)PacientesDB.Nombre_del_Padre_o_Tutor ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)PacientesDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdLugar_de_nacimiento = _dataProvider.GetParameter();
                paramUpdLugar_de_nacimiento.ParameterName = "Lugar_de_nacimiento";
                paramUpdLugar_de_nacimiento.DbType = DbType.Int32;
                paramUpdLugar_de_nacimiento.Value = (object)PacientesDB.Lugar_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)PacientesDB.Sexo ?? DBNull.Value;
		var paramUpdEstado_Civil = _dataProvider.GetParameter();
                paramUpdEstado_Civil.ParameterName = "Estado_Civil";
                paramUpdEstado_Civil.DbType = DbType.Int32;
                paramUpdEstado_Civil.Value = (object)PacientesDB.Estado_Civil ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)PacientesDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)PacientesDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)PacientesDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)PacientesDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)PacientesDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)PacientesDB.Ciudad ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)PacientesDB.Pais ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)PacientesDB.Estado ?? DBNull.Value;
                var paramUpdOcupacion = _dataProvider.GetParameter();
                paramUpdOcupacion.ParameterName = "Ocupacion";
                paramUpdOcupacion.DbType = DbType.String;
                paramUpdOcupacion.Value = (object)PacientesDB.Ocupacion ?? DBNull.Value;
                var paramUpdCantidad_hijos = _dataProvider.GetParameter();
                paramUpdCantidad_hijos.ParameterName = "Cantidad_hijos";
                paramUpdCantidad_hijos.DbType = DbType.Int32;
                paramUpdCantidad_hijos.Value = (object)PacientesDB.Cantidad_hijos ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)PacientesDB.Objetivo ?? DBNull.Value;
		var paramUpdEstatus_Paciente = _dataProvider.GetParameter();
                paramUpdEstatus_Paciente.ParameterName = "Estatus_Paciente";
                paramUpdEstatus_Paciente.DbType = DbType.Int32;
                paramUpdEstatus_Paciente.Value = (object)PacientesDB.Estatus_Paciente ?? DBNull.Value;
		var paramUpdCuenta_con_padecimientos = _dataProvider.GetParameter();
                paramUpdCuenta_con_padecimientos.ParameterName = "Cuenta_con_padecimientos";
                paramUpdCuenta_con_padecimientos.DbType = DbType.Int32;
                paramUpdCuenta_con_padecimientos.Value = (object)PacientesDB.Cuenta_con_padecimientos ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)PacientesDB.Frecuencia_Cardiaca ?? DBNull.Value;
                var paramUpdFrecuencia_Respiratoria = _dataProvider.GetParameter();
                paramUpdFrecuencia_Respiratoria.ParameterName = "Frecuencia_Respiratoria";
                paramUpdFrecuencia_Respiratoria.DbType = DbType.Int32;
                paramUpdFrecuencia_Respiratoria.Value = (object)PacientesDB.Frecuencia_Respiratoria ?? DBNull.Value;
                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)PacientesDB.Presion_sistolica ?? DBNull.Value;
                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)PacientesDB.Presion_diastolica ?? DBNull.Value;
                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)PacientesDB.Peso_actual ?? DBNull.Value;
                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)PacientesDB.Estatura ?? DBNull.Value;
                var paramUpdPeso_habitual = _dataProvider.GetParameter();
                paramUpdPeso_habitual.ParameterName = "Peso_habitual";
                paramUpdPeso_habitual.DbType = DbType.Decimal;
                paramUpdPeso_habitual.Value = (object)PacientesDB.Peso_habitual ?? DBNull.Value;
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)PacientesDB.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)PacientesDB.Circunferencia_de_cadera_cm ?? DBNull.Value;
                var paramUpdAnchura_de_muneca_mm = _dataProvider.GetParameter();
                paramUpdAnchura_de_muneca_mm.ParameterName = "Anchura_de_muneca_mm";
                paramUpdAnchura_de_muneca_mm.DbType = DbType.Int32;
                paramUpdAnchura_de_muneca_mm.Value = (object)PacientesDB.Anchura_de_muneca_mm ?? DBNull.Value;
                var paramUpdCircunferencia_de_brazo_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_brazo_cm.ParameterName = "Circunferencia_de_brazo_cm";
                paramUpdCircunferencia_de_brazo_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_brazo_cm.Value = (object)PacientesDB.Circunferencia_de_brazo_cm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_tricipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_tricipital_mm.ParameterName = "Pliegue_cutaneo_tricipital_mm";
                paramUpdPliegue_cutaneo_tricipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_tricipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_tricipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_bicipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_bicipital_mm.ParameterName = "Pliegue_cutaneo_bicipital_mm";
                paramUpdPliegue_cutaneo_bicipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_bicipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_bicipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_subescapular_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_subescapular_mm.ParameterName = "Pliegue_cutaneo_subescapular_mm";
                paramUpdPliegue_cutaneo_subescapular_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_subescapular_mm.Value = (object)PacientesDB.Pliegue_cutaneo_subescapular_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_supraespinal_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_supraespinal_mm.ParameterName = "Pliegue_cutaneo_supraespinal_mm";
                paramUpdPliegue_cutaneo_supraespinal_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_supraespinal_mm.Value = (object)PacientesDB.Pliegue_cutaneo_supraespinal_mm ?? DBNull.Value;
                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)PacientesDB.Edad_Metabolica ?? DBNull.Value;
                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)PacientesDB.Agua_corporal ?? DBNull.Value;
                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)PacientesDB.Grasa_Visceral ?? DBNull.Value;
                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)PacientesDB.Grasa_Corporal ?? DBNull.Value;
                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)PacientesDB.Grasa_Corporal_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)PacientesDB.Masa_Muscular_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_ = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_.ParameterName = "Masa_Muscular_";
                paramUpdMasa_Muscular_.DbType = DbType.Int32;
                paramUpdMasa_Muscular_.Value = (object)PacientesDB.Masa_Muscular_ ?? DBNull.Value;
		var paramUpdEsta_embarazada = _dataProvider.GetParameter();
                paramUpdEsta_embarazada.ParameterName = "Esta_embarazada";
                paramUpdEsta_embarazada.DbType = DbType.Int32;
                paramUpdEsta_embarazada.Value = (object)PacientesDB.Esta_embarazada ?? DBNull.Value;
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)PacientesDB.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdPeso_pregestacional = _dataProvider.GetParameter();
                paramUpdPeso_pregestacional.ParameterName = "Peso_pregestacional";
                paramUpdPeso_pregestacional.DbType = DbType.Int32;
                paramUpdPeso_pregestacional.Value = (object)PacientesDB.Peso_pregestacional ?? DBNull.Value;
		var paramUpdToma_anticonceptivos = _dataProvider.GetParameter();
                paramUpdToma_anticonceptivos.ParameterName = "Toma_anticonceptivos";
                paramUpdToma_anticonceptivos.DbType = DbType.Int32;
                paramUpdToma_anticonceptivos.Value = (object)PacientesDB.Toma_anticonceptivos ?? DBNull.Value;
                var paramUpdNombre_del_Anticonceptivo = _dataProvider.GetParameter();
                paramUpdNombre_del_Anticonceptivo.ParameterName = "Nombre_del_Anticonceptivo";
                paramUpdNombre_del_Anticonceptivo.DbType = DbType.String;
                paramUpdNombre_del_Anticonceptivo.Value = (object)PacientesDB.Nombre_del_Anticonceptivo ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)PacientesDB.Dosis ?? DBNull.Value;
		var paramUpdClimaterio = _dataProvider.GetParameter();
                paramUpdClimaterio.ParameterName = "Climaterio";
                paramUpdClimaterio.DbType = DbType.Int32;
                paramUpdClimaterio.Value = (object)PacientesDB.Climaterio ?? DBNull.Value;
                var paramUpdFecha_Climaterio = _dataProvider.GetParameter();
                paramUpdFecha_Climaterio.ParameterName = "Fecha_Climaterio";
                paramUpdFecha_Climaterio.DbType = DbType.DateTime;
                paramUpdFecha_Climaterio.Value = (object)PacientesDB.Fecha_Climaterio ?? DBNull.Value;
		var paramUpdTerapia_reemplazo_hormonal = _dataProvider.GetParameter();
                paramUpdTerapia_reemplazo_hormonal.ParameterName = "Terapia_reemplazo_hormonal";
                paramUpdTerapia_reemplazo_hormonal.DbType = DbType.Int32;
                paramUpdTerapia_reemplazo_hormonal.Value = (object)PacientesDB.Terapia_reemplazo_hormonal ?? DBNull.Value;
		var paramUpdTipo_Dieta = _dataProvider.GetParameter();
                paramUpdTipo_Dieta.ParameterName = "Tipo_Dieta";
                paramUpdTipo_Dieta.DbType = DbType.Int32;
                paramUpdTipo_Dieta.Value = (object)PacientesDB.Tipo_Dieta ?? DBNull.Value;
		var paramUpdSuplementos = _dataProvider.GetParameter();
                paramUpdSuplementos.ParameterName = "Suplementos";
                paramUpdSuplementos.DbType = DbType.Int32;
                paramUpdSuplementos.Value = (object)PacientesDB.Suplementos ?? DBNull.Value;
		var paramUpdConsumo_de_sal = _dataProvider.GetParameter();
                paramUpdConsumo_de_sal.ParameterName = "Consumo_de_sal";
                paramUpdConsumo_de_sal.DbType = DbType.Int32;
                paramUpdConsumo_de_sal.Value = (object)PacientesDB.Consumo_de_sal ?? DBNull.Value;
		var paramUpdGrasas_Preferencias = _dataProvider.GetParameter();
                paramUpdGrasas_Preferencias.ParameterName = "Grasas_Preferencias";
                paramUpdGrasas_Preferencias.DbType = DbType.Int32;
                paramUpdGrasas_Preferencias.Value = (object)PacientesDB.Grasas_Preferencias ?? DBNull.Value;
		var paramUpdComidas_cantidad = _dataProvider.GetParameter();
                paramUpdComidas_cantidad.ParameterName = "Comidas_cantidad";
                paramUpdComidas_cantidad.DbType = DbType.Int32;
                paramUpdComidas_cantidad.Value = (object)PacientesDB.Comidas_cantidad ?? DBNull.Value;
		var paramUpdPreparacion_Preferencias = _dataProvider.GetParameter();
                paramUpdPreparacion_Preferencias.ParameterName = "Preparacion_Preferencias";
                paramUpdPreparacion_Preferencias.DbType = DbType.Int32;
                paramUpdPreparacion_Preferencias.Value = (object)PacientesDB.Preparacion_Preferencias ?? DBNull.Value;
		var paramUpdEntre_comidas = _dataProvider.GetParameter();
                paramUpdEntre_comidas.ParameterName = "Entre_comidas";
                paramUpdEntre_comidas.DbType = DbType.Int32;
                paramUpdEntre_comidas.Value = (object)PacientesDB.Entre_comidas ?? DBNull.Value;
		var paramUpdApetito = _dataProvider.GetParameter();
                paramUpdApetito.ParameterName = "Apetito";
                paramUpdApetito.DbType = DbType.Int32;
                paramUpdApetito.Value = (object)PacientesDB.Apetito ?? DBNull.Value;
		var paramUpdHabitos_Modificacion = _dataProvider.GetParameter();
                paramUpdHabitos_Modificacion.ParameterName = "Habitos_Modificacion";
                paramUpdHabitos_Modificacion.DbType = DbType.Int32;
                paramUpdHabitos_Modificacion.Value = (object)PacientesDB.Habitos_Modificacion ?? DBNull.Value;
		var paramUpdHorario_hambre = _dataProvider.GetParameter();
                paramUpdHorario_hambre.ParameterName = "Horario_hambre";
                paramUpdHorario_hambre.DbType = DbType.Int32;
                paramUpdHorario_hambre.Value = (object)PacientesDB.Horario_hambre ?? DBNull.Value;
		var paramUpdCuando_cambia_mi_estado_de_animo = _dataProvider.GetParameter();
                paramUpdCuando_cambia_mi_estado_de_animo.ParameterName = "Cuando_cambia_mi_estado_de_animo";
                paramUpdCuando_cambia_mi_estado_de_animo.DbType = DbType.Int32;
                paramUpdCuando_cambia_mi_estado_de_animo.Value = (object)PacientesDB.Cuando_cambia_mi_estado_de_animo ?? DBNull.Value;
		var paramUpdMedicamentos_bajar_peso = _dataProvider.GetParameter();
                paramUpdMedicamentos_bajar_peso.ParameterName = "Medicamentos_bajar_peso";
                paramUpdMedicamentos_bajar_peso.DbType = DbType.Int32;
                paramUpdMedicamentos_bajar_peso.Value = (object)PacientesDB.Medicamentos_bajar_peso ?? DBNull.Value;
                var paramUpdCual_medicamento = _dataProvider.GetParameter();
                paramUpdCual_medicamento.ParameterName = "Cual_medicamento";
                paramUpdCual_medicamento.DbType = DbType.String;
                paramUpdCual_medicamento.Value = (object)PacientesDB.Cual_medicamento ?? DBNull.Value;
		var paramUpdFrecuencia_Ejercicio = _dataProvider.GetParameter();
                paramUpdFrecuencia_Ejercicio.ParameterName = "Frecuencia_Ejercicio";
                paramUpdFrecuencia_Ejercicio.DbType = DbType.Int32;
                paramUpdFrecuencia_Ejercicio.Value = (object)entity.Frecuencia_Ejercicio ?? DBNull.Value;
		var paramUpdDuracion_Ejercicio = _dataProvider.GetParameter();
                paramUpdDuracion_Ejercicio.ParameterName = "Duracion_Ejercicio";
                paramUpdDuracion_Ejercicio.DbType = DbType.Int32;
                paramUpdDuracion_Ejercicio.Value = (object)entity.Duracion_Ejercicio ?? DBNull.Value;
		var paramUpdTipo_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_Ejercicio.ParameterName = "Tipo_Ejercicio";
                paramUpdTipo_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_Ejercicio.Value = (object)entity.Tipo_Ejercicio ?? DBNull.Value;
		var paramUpdAntiguedad_Ejercicio = _dataProvider.GetParameter();
                paramUpdAntiguedad_Ejercicio.ParameterName = "Antiguedad_Ejercicio";
                paramUpdAntiguedad_Ejercicio.DbType = DbType.Int32;
                paramUpdAntiguedad_Ejercicio.Value = (object)entity.Antiguedad_Ejercicio ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)PacientesDB.IMC ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)PacientesDB.Interpretacion_IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)PacientesDB.IMC_Pediatria ?? DBNull.Value;
                var paramUpdComplexion_corporal = _dataProvider.GetParameter();
                paramUpdComplexion_corporal.ParameterName = "Complexion_corporal";
                paramUpdComplexion_corporal.DbType = DbType.String;
                paramUpdComplexion_corporal.Value = (object)PacientesDB.Complexion_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_complexion_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_complexion_corporal.ParameterName = "Interpretacion_complexion_corporal";
                paramUpdInterpretacion_complexion_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_complexion_corporal.Value = (object)PacientesDB.Interpretacion_complexion_corporal ?? DBNull.Value;
                var paramUpdDistribucion_de_grasa_corporal = _dataProvider.GetParameter();
                paramUpdDistribucion_de_grasa_corporal.ParameterName = "Distribucion_de_grasa_corporal";
                paramUpdDistribucion_de_grasa_corporal.DbType = DbType.String;
                paramUpdDistribucion_de_grasa_corporal.Value = (object)PacientesDB.Distribucion_de_grasa_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_grasa_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_grasa_corporal.ParameterName = "Interpretacion_grasa_corporal";
                paramUpdInterpretacion_grasa_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_grasa_corporal.Value = (object)PacientesDB.Interpretacion_grasa_corporal ?? DBNull.Value;
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.String;
                paramUpdIndice_cintura_cadera.Value = (object)PacientesDB.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)PacientesDB.Interpretacion_indice ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.String;
                paramUpdConsumo_de_agua_resultado.Value = (object)PacientesDB.Consumo_de_agua_resultado ?? DBNull.Value;
		var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)PacientesDB.Interpretacion_agua ?? DBNull.Value;
                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)PacientesDB.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;
		var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)PacientesDB.Interpretacion_frecuencia ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.String;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)PacientesDB.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
		var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)PacientesDB.Interpretacion_dificultad ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)PacientesDB.Calorias ?? DBNull.Value;
		var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)PacientesDB.Interpretacion_calorias ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)PacientesDB.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPacientes>("sp_UpdPacientes" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Registro , paramUpdTipo_de_Paciente , paramUpdUsuario_Registrado , paramUpdEmpresa , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdCelular , paramUpdEmail , paramUpdFecha_de_nacimiento , paramUpdNombre_del_Padre_o_Tutor , paramUpdPais_de_nacimiento , paramUpdLugar_de_nacimiento , paramUpdSexo , paramUpdEstado_Civil , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdPais , paramUpdEstado , paramUpdOcupacion , paramUpdCantidad_hijos , paramUpdObjetivo , paramUpdEstatus_Paciente , paramUpdCuenta_con_padecimientos , paramUpdFrecuencia_Cardiaca , paramUpdFrecuencia_Respiratoria , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdPeso_habitual , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdAnchura_de_muneca_mm , paramUpdCircunferencia_de_brazo_cm , paramUpdPliegue_cutaneo_tricipital_mm , paramUpdPliegue_cutaneo_bicipital_mm , paramUpdPliegue_cutaneo_subescapular_mm , paramUpdPliegue_cutaneo_supraespinal_mm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdMasa_Muscular_ , paramUpdEsta_embarazada , paramUpdSemana_de_gestacion , paramUpdPeso_pregestacional , paramUpdToma_anticonceptivos , paramUpdNombre_del_Anticonceptivo , paramUpdDosis , paramUpdClimaterio , paramUpdFecha_Climaterio , paramUpdTerapia_reemplazo_hormonal , paramUpdTipo_Dieta , paramUpdSuplementos , paramUpdConsumo_de_sal , paramUpdGrasas_Preferencias , paramUpdComidas_cantidad , paramUpdPreparacion_Preferencias , paramUpdEntre_comidas , paramUpdApetito , paramUpdHabitos_Modificacion , paramUpdHorario_hambre , paramUpdCuando_cambia_mi_estado_de_animo , paramUpdMedicamentos_bajar_peso , paramUpdCual_medicamento , paramUpdFrecuencia_Ejercicio , paramUpdDuracion_Ejercicio , paramUpdTipo_Ejercicio , paramUpdAntiguedad_Ejercicio , paramUpdIMC , paramUpdInterpretacion_IMC , paramUpdIMC_Pediatria , paramUpdComplexion_corporal , paramUpdInterpretacion_complexion_corporal , paramUpdDistribucion_de_grasa_corporal , paramUpdInterpretacion_grasa_corporal , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

		public int Update_Resultados(Spartane.Core.Classes.Pacientes.Pacientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Pacientes.Pacientes PacientesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)PacientesDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)PacientesDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)PacientesDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)PacientesDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdTipo_de_Registro = _dataProvider.GetParameter();
                paramUpdTipo_de_Registro.ParameterName = "Tipo_de_Registro";
                paramUpdTipo_de_Registro.DbType = DbType.Int32;
                paramUpdTipo_de_Registro.Value = (object)PacientesDB.Tipo_de_Registro ?? DBNull.Value;
		var paramUpdTipo_de_Paciente = _dataProvider.GetParameter();
                paramUpdTipo_de_Paciente.ParameterName = "Tipo_de_Paciente";
                paramUpdTipo_de_Paciente.DbType = DbType.Int32;
                paramUpdTipo_de_Paciente.Value = (object)PacientesDB.Tipo_de_Paciente ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)PacientesDB.Usuario_Registrado ?? DBNull.Value;
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)PacientesDB.Empresa ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)PacientesDB.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)PacientesDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)PacientesDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)PacientesDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)PacientesDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)PacientesDB.Celular ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)PacientesDB.Email ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)PacientesDB.Fecha_de_nacimiento ?? DBNull.Value;
                var paramUpdNombre_del_Padre_o_Tutor = _dataProvider.GetParameter();
                paramUpdNombre_del_Padre_o_Tutor.ParameterName = "Nombre_del_Padre_o_Tutor";
                paramUpdNombre_del_Padre_o_Tutor.DbType = DbType.String;
                paramUpdNombre_del_Padre_o_Tutor.Value = (object)PacientesDB.Nombre_del_Padre_o_Tutor ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)PacientesDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdLugar_de_nacimiento = _dataProvider.GetParameter();
                paramUpdLugar_de_nacimiento.ParameterName = "Lugar_de_nacimiento";
                paramUpdLugar_de_nacimiento.DbType = DbType.Int32;
                paramUpdLugar_de_nacimiento.Value = (object)PacientesDB.Lugar_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)PacientesDB.Sexo ?? DBNull.Value;
		var paramUpdEstado_Civil = _dataProvider.GetParameter();
                paramUpdEstado_Civil.ParameterName = "Estado_Civil";
                paramUpdEstado_Civil.DbType = DbType.Int32;
                paramUpdEstado_Civil.Value = (object)PacientesDB.Estado_Civil ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)PacientesDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)PacientesDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)PacientesDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)PacientesDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)PacientesDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)PacientesDB.Ciudad ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)PacientesDB.Pais ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)PacientesDB.Estado ?? DBNull.Value;
                var paramUpdOcupacion = _dataProvider.GetParameter();
                paramUpdOcupacion.ParameterName = "Ocupacion";
                paramUpdOcupacion.DbType = DbType.String;
                paramUpdOcupacion.Value = (object)PacientesDB.Ocupacion ?? DBNull.Value;
                var paramUpdCantidad_hijos = _dataProvider.GetParameter();
                paramUpdCantidad_hijos.ParameterName = "Cantidad_hijos";
                paramUpdCantidad_hijos.DbType = DbType.Int32;
                paramUpdCantidad_hijos.Value = (object)PacientesDB.Cantidad_hijos ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)PacientesDB.Objetivo ?? DBNull.Value;
		var paramUpdEstatus_Paciente = _dataProvider.GetParameter();
                paramUpdEstatus_Paciente.ParameterName = "Estatus_Paciente";
                paramUpdEstatus_Paciente.DbType = DbType.Int32;
                paramUpdEstatus_Paciente.Value = (object)PacientesDB.Estatus_Paciente ?? DBNull.Value;
		var paramUpdCuenta_con_padecimientos = _dataProvider.GetParameter();
                paramUpdCuenta_con_padecimientos.ParameterName = "Cuenta_con_padecimientos";
                paramUpdCuenta_con_padecimientos.DbType = DbType.Int32;
                paramUpdCuenta_con_padecimientos.Value = (object)PacientesDB.Cuenta_con_padecimientos ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)PacientesDB.Frecuencia_Cardiaca ?? DBNull.Value;
                var paramUpdFrecuencia_Respiratoria = _dataProvider.GetParameter();
                paramUpdFrecuencia_Respiratoria.ParameterName = "Frecuencia_Respiratoria";
                paramUpdFrecuencia_Respiratoria.DbType = DbType.Int32;
                paramUpdFrecuencia_Respiratoria.Value = (object)PacientesDB.Frecuencia_Respiratoria ?? DBNull.Value;
                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)PacientesDB.Presion_sistolica ?? DBNull.Value;
                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)PacientesDB.Presion_diastolica ?? DBNull.Value;
                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)PacientesDB.Peso_actual ?? DBNull.Value;
                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)PacientesDB.Estatura ?? DBNull.Value;
                var paramUpdPeso_habitual = _dataProvider.GetParameter();
                paramUpdPeso_habitual.ParameterName = "Peso_habitual";
                paramUpdPeso_habitual.DbType = DbType.Decimal;
                paramUpdPeso_habitual.Value = (object)PacientesDB.Peso_habitual ?? DBNull.Value;
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)PacientesDB.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)PacientesDB.Circunferencia_de_cadera_cm ?? DBNull.Value;
                var paramUpdAnchura_de_muneca_mm = _dataProvider.GetParameter();
                paramUpdAnchura_de_muneca_mm.ParameterName = "Anchura_de_muneca_mm";
                paramUpdAnchura_de_muneca_mm.DbType = DbType.Int32;
                paramUpdAnchura_de_muneca_mm.Value = (object)PacientesDB.Anchura_de_muneca_mm ?? DBNull.Value;
                var paramUpdCircunferencia_de_brazo_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_brazo_cm.ParameterName = "Circunferencia_de_brazo_cm";
                paramUpdCircunferencia_de_brazo_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_brazo_cm.Value = (object)PacientesDB.Circunferencia_de_brazo_cm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_tricipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_tricipital_mm.ParameterName = "Pliegue_cutaneo_tricipital_mm";
                paramUpdPliegue_cutaneo_tricipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_tricipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_tricipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_bicipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_bicipital_mm.ParameterName = "Pliegue_cutaneo_bicipital_mm";
                paramUpdPliegue_cutaneo_bicipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_bicipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_bicipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_subescapular_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_subescapular_mm.ParameterName = "Pliegue_cutaneo_subescapular_mm";
                paramUpdPliegue_cutaneo_subescapular_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_subescapular_mm.Value = (object)PacientesDB.Pliegue_cutaneo_subescapular_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_supraespinal_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_supraespinal_mm.ParameterName = "Pliegue_cutaneo_supraespinal_mm";
                paramUpdPliegue_cutaneo_supraespinal_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_supraespinal_mm.Value = (object)PacientesDB.Pliegue_cutaneo_supraespinal_mm ?? DBNull.Value;
                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)PacientesDB.Edad_Metabolica ?? DBNull.Value;
                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)PacientesDB.Agua_corporal ?? DBNull.Value;
                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)PacientesDB.Grasa_Visceral ?? DBNull.Value;
                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)PacientesDB.Grasa_Corporal ?? DBNull.Value;
                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)PacientesDB.Grasa_Corporal_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)PacientesDB.Masa_Muscular_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_ = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_.ParameterName = "Masa_Muscular_";
                paramUpdMasa_Muscular_.DbType = DbType.Int32;
                paramUpdMasa_Muscular_.Value = (object)PacientesDB.Masa_Muscular_ ?? DBNull.Value;
		var paramUpdEsta_embarazada = _dataProvider.GetParameter();
                paramUpdEsta_embarazada.ParameterName = "Esta_embarazada";
                paramUpdEsta_embarazada.DbType = DbType.Int32;
                paramUpdEsta_embarazada.Value = (object)PacientesDB.Esta_embarazada ?? DBNull.Value;
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)PacientesDB.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdPeso_pregestacional = _dataProvider.GetParameter();
                paramUpdPeso_pregestacional.ParameterName = "Peso_pregestacional";
                paramUpdPeso_pregestacional.DbType = DbType.Int32;
                paramUpdPeso_pregestacional.Value = (object)PacientesDB.Peso_pregestacional ?? DBNull.Value;
		var paramUpdToma_anticonceptivos = _dataProvider.GetParameter();
                paramUpdToma_anticonceptivos.ParameterName = "Toma_anticonceptivos";
                paramUpdToma_anticonceptivos.DbType = DbType.Int32;
                paramUpdToma_anticonceptivos.Value = (object)PacientesDB.Toma_anticonceptivos ?? DBNull.Value;
                var paramUpdNombre_del_Anticonceptivo = _dataProvider.GetParameter();
                paramUpdNombre_del_Anticonceptivo.ParameterName = "Nombre_del_Anticonceptivo";
                paramUpdNombre_del_Anticonceptivo.DbType = DbType.String;
                paramUpdNombre_del_Anticonceptivo.Value = (object)PacientesDB.Nombre_del_Anticonceptivo ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)PacientesDB.Dosis ?? DBNull.Value;
		var paramUpdClimaterio = _dataProvider.GetParameter();
                paramUpdClimaterio.ParameterName = "Climaterio";
                paramUpdClimaterio.DbType = DbType.Int32;
                paramUpdClimaterio.Value = (object)PacientesDB.Climaterio ?? DBNull.Value;
                var paramUpdFecha_Climaterio = _dataProvider.GetParameter();
                paramUpdFecha_Climaterio.ParameterName = "Fecha_Climaterio";
                paramUpdFecha_Climaterio.DbType = DbType.DateTime;
                paramUpdFecha_Climaterio.Value = (object)PacientesDB.Fecha_Climaterio ?? DBNull.Value;
		var paramUpdTerapia_reemplazo_hormonal = _dataProvider.GetParameter();
                paramUpdTerapia_reemplazo_hormonal.ParameterName = "Terapia_reemplazo_hormonal";
                paramUpdTerapia_reemplazo_hormonal.DbType = DbType.Int32;
                paramUpdTerapia_reemplazo_hormonal.Value = (object)PacientesDB.Terapia_reemplazo_hormonal ?? DBNull.Value;
		var paramUpdTipo_Dieta = _dataProvider.GetParameter();
                paramUpdTipo_Dieta.ParameterName = "Tipo_Dieta";
                paramUpdTipo_Dieta.DbType = DbType.Int32;
                paramUpdTipo_Dieta.Value = (object)PacientesDB.Tipo_Dieta ?? DBNull.Value;
		var paramUpdSuplementos = _dataProvider.GetParameter();
                paramUpdSuplementos.ParameterName = "Suplementos";
                paramUpdSuplementos.DbType = DbType.Int32;
                paramUpdSuplementos.Value = (object)PacientesDB.Suplementos ?? DBNull.Value;
		var paramUpdConsumo_de_sal = _dataProvider.GetParameter();
                paramUpdConsumo_de_sal.ParameterName = "Consumo_de_sal";
                paramUpdConsumo_de_sal.DbType = DbType.Int32;
                paramUpdConsumo_de_sal.Value = (object)PacientesDB.Consumo_de_sal ?? DBNull.Value;
		var paramUpdGrasas_Preferencias = _dataProvider.GetParameter();
                paramUpdGrasas_Preferencias.ParameterName = "Grasas_Preferencias";
                paramUpdGrasas_Preferencias.DbType = DbType.Int32;
                paramUpdGrasas_Preferencias.Value = (object)PacientesDB.Grasas_Preferencias ?? DBNull.Value;
		var paramUpdComidas_cantidad = _dataProvider.GetParameter();
                paramUpdComidas_cantidad.ParameterName = "Comidas_cantidad";
                paramUpdComidas_cantidad.DbType = DbType.Int32;
                paramUpdComidas_cantidad.Value = (object)PacientesDB.Comidas_cantidad ?? DBNull.Value;
		var paramUpdPreparacion_Preferencias = _dataProvider.GetParameter();
                paramUpdPreparacion_Preferencias.ParameterName = "Preparacion_Preferencias";
                paramUpdPreparacion_Preferencias.DbType = DbType.Int32;
                paramUpdPreparacion_Preferencias.Value = (object)PacientesDB.Preparacion_Preferencias ?? DBNull.Value;
		var paramUpdEntre_comidas = _dataProvider.GetParameter();
                paramUpdEntre_comidas.ParameterName = "Entre_comidas";
                paramUpdEntre_comidas.DbType = DbType.Int32;
                paramUpdEntre_comidas.Value = (object)PacientesDB.Entre_comidas ?? DBNull.Value;
		var paramUpdApetito = _dataProvider.GetParameter();
                paramUpdApetito.ParameterName = "Apetito";
                paramUpdApetito.DbType = DbType.Int32;
                paramUpdApetito.Value = (object)PacientesDB.Apetito ?? DBNull.Value;
		var paramUpdHabitos_Modificacion = _dataProvider.GetParameter();
                paramUpdHabitos_Modificacion.ParameterName = "Habitos_Modificacion";
                paramUpdHabitos_Modificacion.DbType = DbType.Int32;
                paramUpdHabitos_Modificacion.Value = (object)PacientesDB.Habitos_Modificacion ?? DBNull.Value;
		var paramUpdHorario_hambre = _dataProvider.GetParameter();
                paramUpdHorario_hambre.ParameterName = "Horario_hambre";
                paramUpdHorario_hambre.DbType = DbType.Int32;
                paramUpdHorario_hambre.Value = (object)PacientesDB.Horario_hambre ?? DBNull.Value;
		var paramUpdCuando_cambia_mi_estado_de_animo = _dataProvider.GetParameter();
                paramUpdCuando_cambia_mi_estado_de_animo.ParameterName = "Cuando_cambia_mi_estado_de_animo";
                paramUpdCuando_cambia_mi_estado_de_animo.DbType = DbType.Int32;
                paramUpdCuando_cambia_mi_estado_de_animo.Value = (object)PacientesDB.Cuando_cambia_mi_estado_de_animo ?? DBNull.Value;
		var paramUpdMedicamentos_bajar_peso = _dataProvider.GetParameter();
                paramUpdMedicamentos_bajar_peso.ParameterName = "Medicamentos_bajar_peso";
                paramUpdMedicamentos_bajar_peso.DbType = DbType.Int32;
                paramUpdMedicamentos_bajar_peso.Value = (object)PacientesDB.Medicamentos_bajar_peso ?? DBNull.Value;
                var paramUpdCual_medicamento = _dataProvider.GetParameter();
                paramUpdCual_medicamento.ParameterName = "Cual_medicamento";
                paramUpdCual_medicamento.DbType = DbType.String;
                paramUpdCual_medicamento.Value = (object)PacientesDB.Cual_medicamento ?? DBNull.Value;
		var paramUpdFrecuencia_Ejercicio = _dataProvider.GetParameter();
                paramUpdFrecuencia_Ejercicio.ParameterName = "Frecuencia_Ejercicio";
                paramUpdFrecuencia_Ejercicio.DbType = DbType.Int32;
                paramUpdFrecuencia_Ejercicio.Value = (object)PacientesDB.Frecuencia_Ejercicio ?? DBNull.Value;
		var paramUpdDuracion_Ejercicio = _dataProvider.GetParameter();
                paramUpdDuracion_Ejercicio.ParameterName = "Duracion_Ejercicio";
                paramUpdDuracion_Ejercicio.DbType = DbType.Int32;
                paramUpdDuracion_Ejercicio.Value = (object)PacientesDB.Duracion_Ejercicio ?? DBNull.Value;
		var paramUpdTipo_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_Ejercicio.ParameterName = "Tipo_Ejercicio";
                paramUpdTipo_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_Ejercicio.Value = (object)PacientesDB.Tipo_Ejercicio ?? DBNull.Value;
		var paramUpdAntiguedad_Ejercicio = _dataProvider.GetParameter();
                paramUpdAntiguedad_Ejercicio.ParameterName = "Antiguedad_Ejercicio";
                paramUpdAntiguedad_Ejercicio.DbType = DbType.Int32;
                paramUpdAntiguedad_Ejercicio.Value = (object)PacientesDB.Antiguedad_Ejercicio ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)entity.IMC ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)entity.Interpretacion_IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)entity.IMC_Pediatria ?? DBNull.Value;
                var paramUpdComplexion_corporal = _dataProvider.GetParameter();
                paramUpdComplexion_corporal.ParameterName = "Complexion_corporal";
                paramUpdComplexion_corporal.DbType = DbType.String;
                paramUpdComplexion_corporal.Value = (object)entity.Complexion_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_complexion_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_complexion_corporal.ParameterName = "Interpretacion_complexion_corporal";
                paramUpdInterpretacion_complexion_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_complexion_corporal.Value = (object)entity.Interpretacion_complexion_corporal ?? DBNull.Value;
                var paramUpdDistribucion_de_grasa_corporal = _dataProvider.GetParameter();
                paramUpdDistribucion_de_grasa_corporal.ParameterName = "Distribucion_de_grasa_corporal";
                paramUpdDistribucion_de_grasa_corporal.DbType = DbType.String;
                paramUpdDistribucion_de_grasa_corporal.Value = (object)entity.Distribucion_de_grasa_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_grasa_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_grasa_corporal.ParameterName = "Interpretacion_grasa_corporal";
                paramUpdInterpretacion_grasa_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_grasa_corporal.Value = (object)entity.Interpretacion_grasa_corporal ?? DBNull.Value;
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.String;
                paramUpdIndice_cintura_cadera.Value = (object)entity.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)entity.Interpretacion_indice ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.String;
                paramUpdConsumo_de_agua_resultado.Value = (object)entity.Consumo_de_agua_resultado ?? DBNull.Value;
		var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)entity.Interpretacion_agua ?? DBNull.Value;
                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)entity.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;
		var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)entity.Interpretacion_frecuencia ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.String;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)entity.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
		var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)entity.Interpretacion_dificultad ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)entity.Calorias ?? DBNull.Value;
		var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)entity.Interpretacion_calorias ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPacientes>("sp_UpdPacientes" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Registro , paramUpdTipo_de_Paciente , paramUpdUsuario_Registrado , paramUpdEmpresa , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdCelular , paramUpdEmail , paramUpdFecha_de_nacimiento , paramUpdNombre_del_Padre_o_Tutor , paramUpdPais_de_nacimiento , paramUpdLugar_de_nacimiento , paramUpdSexo , paramUpdEstado_Civil , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdPais , paramUpdEstado , paramUpdOcupacion , paramUpdCantidad_hijos , paramUpdObjetivo , paramUpdEstatus_Paciente , paramUpdCuenta_con_padecimientos , paramUpdFrecuencia_Cardiaca , paramUpdFrecuencia_Respiratoria , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdPeso_habitual , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdAnchura_de_muneca_mm , paramUpdCircunferencia_de_brazo_cm , paramUpdPliegue_cutaneo_tricipital_mm , paramUpdPliegue_cutaneo_bicipital_mm , paramUpdPliegue_cutaneo_subescapular_mm , paramUpdPliegue_cutaneo_supraespinal_mm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdMasa_Muscular_ , paramUpdEsta_embarazada , paramUpdSemana_de_gestacion , paramUpdPeso_pregestacional , paramUpdToma_anticonceptivos , paramUpdNombre_del_Anticonceptivo , paramUpdDosis , paramUpdClimaterio , paramUpdFecha_Climaterio , paramUpdTerapia_reemplazo_hormonal , paramUpdTipo_Dieta , paramUpdSuplementos , paramUpdConsumo_de_sal , paramUpdGrasas_Preferencias , paramUpdComidas_cantidad , paramUpdPreparacion_Preferencias , paramUpdEntre_comidas , paramUpdApetito , paramUpdHabitos_Modificacion , paramUpdHorario_hambre , paramUpdCuando_cambia_mi_estado_de_animo , paramUpdMedicamentos_bajar_peso , paramUpdCual_medicamento , paramUpdFrecuencia_Ejercicio , paramUpdDuracion_Ejercicio , paramUpdTipo_Ejercicio , paramUpdAntiguedad_Ejercicio , paramUpdIMC , paramUpdInterpretacion_IMC , paramUpdIMC_Pediatria , paramUpdComplexion_corporal , paramUpdInterpretacion_complexion_corporal , paramUpdDistribucion_de_grasa_corporal , paramUpdInterpretacion_grasa_corporal , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

		public int Update_Suscripcion(Spartane.Core.Classes.Pacientes.Pacientes entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Pacientes.Pacientes PacientesDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)PacientesDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)PacientesDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)PacientesDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)PacientesDB.Usuario_que_Registra ?? DBNull.Value;
		var paramUpdTipo_de_Registro = _dataProvider.GetParameter();
                paramUpdTipo_de_Registro.ParameterName = "Tipo_de_Registro";
                paramUpdTipo_de_Registro.DbType = DbType.Int32;
                paramUpdTipo_de_Registro.Value = (object)PacientesDB.Tipo_de_Registro ?? DBNull.Value;
		var paramUpdTipo_de_Paciente = _dataProvider.GetParameter();
                paramUpdTipo_de_Paciente.ParameterName = "Tipo_de_Paciente";
                paramUpdTipo_de_Paciente.DbType = DbType.Int32;
                paramUpdTipo_de_Paciente.Value = (object)PacientesDB.Tipo_de_Paciente ?? DBNull.Value;
		var paramUpdUsuario_Registrado = _dataProvider.GetParameter();
                paramUpdUsuario_Registrado.ParameterName = "Usuario_Registrado";
                paramUpdUsuario_Registrado.DbType = DbType.Int32;
                paramUpdUsuario_Registrado.Value = (object)PacientesDB.Usuario_Registrado ?? DBNull.Value;
		var paramUpdEmpresa = _dataProvider.GetParameter();
                paramUpdEmpresa.ParameterName = "Empresa";
                paramUpdEmpresa.DbType = DbType.Int32;
                paramUpdEmpresa.Value = (object)PacientesDB.Empresa ?? DBNull.Value;
                var paramUpdNumero_de_Empleado = _dataProvider.GetParameter();
                paramUpdNumero_de_Empleado.ParameterName = "Numero_de_Empleado";
                paramUpdNumero_de_Empleado.DbType = DbType.String;
                paramUpdNumero_de_Empleado.Value = (object)PacientesDB.Numero_de_Empleado ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)PacientesDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)PacientesDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)PacientesDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)PacientesDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)PacientesDB.Celular ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)PacientesDB.Email ?? DBNull.Value;
                var paramUpdFecha_de_nacimiento = _dataProvider.GetParameter();
                paramUpdFecha_de_nacimiento.ParameterName = "Fecha_de_nacimiento";
                paramUpdFecha_de_nacimiento.DbType = DbType.DateTime;
                paramUpdFecha_de_nacimiento.Value = (object)PacientesDB.Fecha_de_nacimiento ?? DBNull.Value;
                var paramUpdNombre_del_Padre_o_Tutor = _dataProvider.GetParameter();
                paramUpdNombre_del_Padre_o_Tutor.ParameterName = "Nombre_del_Padre_o_Tutor";
                paramUpdNombre_del_Padre_o_Tutor.DbType = DbType.String;
                paramUpdNombre_del_Padre_o_Tutor.Value = (object)PacientesDB.Nombre_del_Padre_o_Tutor ?? DBNull.Value;
		var paramUpdPais_de_nacimiento = _dataProvider.GetParameter();
                paramUpdPais_de_nacimiento.ParameterName = "Pais_de_nacimiento";
                paramUpdPais_de_nacimiento.DbType = DbType.Int32;
                paramUpdPais_de_nacimiento.Value = (object)PacientesDB.Pais_de_nacimiento ?? DBNull.Value;
		var paramUpdLugar_de_nacimiento = _dataProvider.GetParameter();
                paramUpdLugar_de_nacimiento.ParameterName = "Lugar_de_nacimiento";
                paramUpdLugar_de_nacimiento.DbType = DbType.Int32;
                paramUpdLugar_de_nacimiento.Value = (object)PacientesDB.Lugar_de_nacimiento ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)PacientesDB.Sexo ?? DBNull.Value;
		var paramUpdEstado_Civil = _dataProvider.GetParameter();
                paramUpdEstado_Civil.ParameterName = "Estado_Civil";
                paramUpdEstado_Civil.DbType = DbType.Int32;
                paramUpdEstado_Civil.Value = (object)PacientesDB.Estado_Civil ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)PacientesDB.Calle ?? DBNull.Value;
                var paramUpdNumero_exterior = _dataProvider.GetParameter();
                paramUpdNumero_exterior.ParameterName = "Numero_exterior";
                paramUpdNumero_exterior.DbType = DbType.String;
                paramUpdNumero_exterior.Value = (object)PacientesDB.Numero_exterior ?? DBNull.Value;
                var paramUpdNumero_interior = _dataProvider.GetParameter();
                paramUpdNumero_interior.ParameterName = "Numero_interior";
                paramUpdNumero_interior.DbType = DbType.String;
                paramUpdNumero_interior.Value = (object)PacientesDB.Numero_interior ?? DBNull.Value;
                var paramUpdColonia = _dataProvider.GetParameter();
                paramUpdColonia.ParameterName = "Colonia";
                paramUpdColonia.DbType = DbType.String;
                paramUpdColonia.Value = (object)PacientesDB.Colonia ?? DBNull.Value;
                var paramUpdCP = _dataProvider.GetParameter();
                paramUpdCP.ParameterName = "CP";
                paramUpdCP.DbType = DbType.Int32;
                paramUpdCP.Value = (object)PacientesDB.CP ?? DBNull.Value;
                var paramUpdCiudad = _dataProvider.GetParameter();
                paramUpdCiudad.ParameterName = "Ciudad";
                paramUpdCiudad.DbType = DbType.String;
                paramUpdCiudad.Value = (object)PacientesDB.Ciudad ?? DBNull.Value;
		var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)PacientesDB.Pais ?? DBNull.Value;
		var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)PacientesDB.Estado ?? DBNull.Value;
                var paramUpdOcupacion = _dataProvider.GetParameter();
                paramUpdOcupacion.ParameterName = "Ocupacion";
                paramUpdOcupacion.DbType = DbType.String;
                paramUpdOcupacion.Value = (object)PacientesDB.Ocupacion ?? DBNull.Value;
                var paramUpdCantidad_hijos = _dataProvider.GetParameter();
                paramUpdCantidad_hijos.ParameterName = "Cantidad_hijos";
                paramUpdCantidad_hijos.DbType = DbType.Int32;
                paramUpdCantidad_hijos.Value = (object)PacientesDB.Cantidad_hijos ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)PacientesDB.Objetivo ?? DBNull.Value;
		var paramUpdEstatus_Paciente = _dataProvider.GetParameter();
                paramUpdEstatus_Paciente.ParameterName = "Estatus_Paciente";
                paramUpdEstatus_Paciente.DbType = DbType.Int32;
                paramUpdEstatus_Paciente.Value = (object)PacientesDB.Estatus_Paciente ?? DBNull.Value;
		var paramUpdCuenta_con_padecimientos = _dataProvider.GetParameter();
                paramUpdCuenta_con_padecimientos.ParameterName = "Cuenta_con_padecimientos";
                paramUpdCuenta_con_padecimientos.DbType = DbType.Int32;
                paramUpdCuenta_con_padecimientos.Value = (object)PacientesDB.Cuenta_con_padecimientos ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)PacientesDB.Frecuencia_Cardiaca ?? DBNull.Value;
                var paramUpdFrecuencia_Respiratoria = _dataProvider.GetParameter();
                paramUpdFrecuencia_Respiratoria.ParameterName = "Frecuencia_Respiratoria";
                paramUpdFrecuencia_Respiratoria.DbType = DbType.Int32;
                paramUpdFrecuencia_Respiratoria.Value = (object)PacientesDB.Frecuencia_Respiratoria ?? DBNull.Value;
                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)PacientesDB.Presion_sistolica ?? DBNull.Value;
                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)PacientesDB.Presion_diastolica ?? DBNull.Value;
                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)PacientesDB.Peso_actual ?? DBNull.Value;
                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)PacientesDB.Estatura ?? DBNull.Value;
                var paramUpdPeso_habitual = _dataProvider.GetParameter();
                paramUpdPeso_habitual.ParameterName = "Peso_habitual";
                paramUpdPeso_habitual.DbType = DbType.Decimal;
                paramUpdPeso_habitual.Value = (object)PacientesDB.Peso_habitual ?? DBNull.Value;
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)PacientesDB.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)PacientesDB.Circunferencia_de_cadera_cm ?? DBNull.Value;
                var paramUpdAnchura_de_muneca_mm = _dataProvider.GetParameter();
                paramUpdAnchura_de_muneca_mm.ParameterName = "Anchura_de_muneca_mm";
                paramUpdAnchura_de_muneca_mm.DbType = DbType.Int32;
                paramUpdAnchura_de_muneca_mm.Value = (object)PacientesDB.Anchura_de_muneca_mm ?? DBNull.Value;
                var paramUpdCircunferencia_de_brazo_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_brazo_cm.ParameterName = "Circunferencia_de_brazo_cm";
                paramUpdCircunferencia_de_brazo_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_brazo_cm.Value = (object)PacientesDB.Circunferencia_de_brazo_cm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_tricipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_tricipital_mm.ParameterName = "Pliegue_cutaneo_tricipital_mm";
                paramUpdPliegue_cutaneo_tricipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_tricipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_tricipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_bicipital_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_bicipital_mm.ParameterName = "Pliegue_cutaneo_bicipital_mm";
                paramUpdPliegue_cutaneo_bicipital_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_bicipital_mm.Value = (object)PacientesDB.Pliegue_cutaneo_bicipital_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_subescapular_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_subescapular_mm.ParameterName = "Pliegue_cutaneo_subescapular_mm";
                paramUpdPliegue_cutaneo_subescapular_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_subescapular_mm.Value = (object)PacientesDB.Pliegue_cutaneo_subescapular_mm ?? DBNull.Value;
                var paramUpdPliegue_cutaneo_supraespinal_mm = _dataProvider.GetParameter();
                paramUpdPliegue_cutaneo_supraespinal_mm.ParameterName = "Pliegue_cutaneo_supraespinal_mm";
                paramUpdPliegue_cutaneo_supraespinal_mm.DbType = DbType.Int32;
                paramUpdPliegue_cutaneo_supraespinal_mm.Value = (object)PacientesDB.Pliegue_cutaneo_supraespinal_mm ?? DBNull.Value;
                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)PacientesDB.Edad_Metabolica ?? DBNull.Value;
                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)PacientesDB.Agua_corporal ?? DBNull.Value;
                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)PacientesDB.Grasa_Visceral ?? DBNull.Value;
                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)PacientesDB.Grasa_Corporal ?? DBNull.Value;
                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)PacientesDB.Grasa_Corporal_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)PacientesDB.Masa_Muscular_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_ = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_.ParameterName = "Masa_Muscular_";
                paramUpdMasa_Muscular_.DbType = DbType.Int32;
                paramUpdMasa_Muscular_.Value = (object)PacientesDB.Masa_Muscular_ ?? DBNull.Value;
		var paramUpdEsta_embarazada = _dataProvider.GetParameter();
                paramUpdEsta_embarazada.ParameterName = "Esta_embarazada";
                paramUpdEsta_embarazada.DbType = DbType.Int32;
                paramUpdEsta_embarazada.Value = (object)PacientesDB.Esta_embarazada ?? DBNull.Value;
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)PacientesDB.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdPeso_pregestacional = _dataProvider.GetParameter();
                paramUpdPeso_pregestacional.ParameterName = "Peso_pregestacional";
                paramUpdPeso_pregestacional.DbType = DbType.Int32;
                paramUpdPeso_pregestacional.Value = (object)PacientesDB.Peso_pregestacional ?? DBNull.Value;
		var paramUpdToma_anticonceptivos = _dataProvider.GetParameter();
                paramUpdToma_anticonceptivos.ParameterName = "Toma_anticonceptivos";
                paramUpdToma_anticonceptivos.DbType = DbType.Int32;
                paramUpdToma_anticonceptivos.Value = (object)PacientesDB.Toma_anticonceptivos ?? DBNull.Value;
                var paramUpdNombre_del_Anticonceptivo = _dataProvider.GetParameter();
                paramUpdNombre_del_Anticonceptivo.ParameterName = "Nombre_del_Anticonceptivo";
                paramUpdNombre_del_Anticonceptivo.DbType = DbType.String;
                paramUpdNombre_del_Anticonceptivo.Value = (object)PacientesDB.Nombre_del_Anticonceptivo ?? DBNull.Value;
                var paramUpdDosis = _dataProvider.GetParameter();
                paramUpdDosis.ParameterName = "Dosis";
                paramUpdDosis.DbType = DbType.String;
                paramUpdDosis.Value = (object)PacientesDB.Dosis ?? DBNull.Value;
		var paramUpdClimaterio = _dataProvider.GetParameter();
                paramUpdClimaterio.ParameterName = "Climaterio";
                paramUpdClimaterio.DbType = DbType.Int32;
                paramUpdClimaterio.Value = (object)PacientesDB.Climaterio ?? DBNull.Value;
                var paramUpdFecha_Climaterio = _dataProvider.GetParameter();
                paramUpdFecha_Climaterio.ParameterName = "Fecha_Climaterio";
                paramUpdFecha_Climaterio.DbType = DbType.DateTime;
                paramUpdFecha_Climaterio.Value = (object)PacientesDB.Fecha_Climaterio ?? DBNull.Value;
		var paramUpdTerapia_reemplazo_hormonal = _dataProvider.GetParameter();
                paramUpdTerapia_reemplazo_hormonal.ParameterName = "Terapia_reemplazo_hormonal";
                paramUpdTerapia_reemplazo_hormonal.DbType = DbType.Int32;
                paramUpdTerapia_reemplazo_hormonal.Value = (object)PacientesDB.Terapia_reemplazo_hormonal ?? DBNull.Value;
		var paramUpdTipo_Dieta = _dataProvider.GetParameter();
                paramUpdTipo_Dieta.ParameterName = "Tipo_Dieta";
                paramUpdTipo_Dieta.DbType = DbType.Int32;
                paramUpdTipo_Dieta.Value = (object)PacientesDB.Tipo_Dieta ?? DBNull.Value;
		var paramUpdSuplementos = _dataProvider.GetParameter();
                paramUpdSuplementos.ParameterName = "Suplementos";
                paramUpdSuplementos.DbType = DbType.Int32;
                paramUpdSuplementos.Value = (object)PacientesDB.Suplementos ?? DBNull.Value;
		var paramUpdConsumo_de_sal = _dataProvider.GetParameter();
                paramUpdConsumo_de_sal.ParameterName = "Consumo_de_sal";
                paramUpdConsumo_de_sal.DbType = DbType.Int32;
                paramUpdConsumo_de_sal.Value = (object)PacientesDB.Consumo_de_sal ?? DBNull.Value;
		var paramUpdGrasas_Preferencias = _dataProvider.GetParameter();
                paramUpdGrasas_Preferencias.ParameterName = "Grasas_Preferencias";
                paramUpdGrasas_Preferencias.DbType = DbType.Int32;
                paramUpdGrasas_Preferencias.Value = (object)PacientesDB.Grasas_Preferencias ?? DBNull.Value;
		var paramUpdComidas_cantidad = _dataProvider.GetParameter();
                paramUpdComidas_cantidad.ParameterName = "Comidas_cantidad";
                paramUpdComidas_cantidad.DbType = DbType.Int32;
                paramUpdComidas_cantidad.Value = (object)PacientesDB.Comidas_cantidad ?? DBNull.Value;
		var paramUpdPreparacion_Preferencias = _dataProvider.GetParameter();
                paramUpdPreparacion_Preferencias.ParameterName = "Preparacion_Preferencias";
                paramUpdPreparacion_Preferencias.DbType = DbType.Int32;
                paramUpdPreparacion_Preferencias.Value = (object)PacientesDB.Preparacion_Preferencias ?? DBNull.Value;
		var paramUpdEntre_comidas = _dataProvider.GetParameter();
                paramUpdEntre_comidas.ParameterName = "Entre_comidas";
                paramUpdEntre_comidas.DbType = DbType.Int32;
                paramUpdEntre_comidas.Value = (object)PacientesDB.Entre_comidas ?? DBNull.Value;
		var paramUpdApetito = _dataProvider.GetParameter();
                paramUpdApetito.ParameterName = "Apetito";
                paramUpdApetito.DbType = DbType.Int32;
                paramUpdApetito.Value = (object)PacientesDB.Apetito ?? DBNull.Value;
		var paramUpdHabitos_Modificacion = _dataProvider.GetParameter();
                paramUpdHabitos_Modificacion.ParameterName = "Habitos_Modificacion";
                paramUpdHabitos_Modificacion.DbType = DbType.Int32;
                paramUpdHabitos_Modificacion.Value = (object)PacientesDB.Habitos_Modificacion ?? DBNull.Value;
		var paramUpdHorario_hambre = _dataProvider.GetParameter();
                paramUpdHorario_hambre.ParameterName = "Horario_hambre";
                paramUpdHorario_hambre.DbType = DbType.Int32;
                paramUpdHorario_hambre.Value = (object)PacientesDB.Horario_hambre ?? DBNull.Value;
		var paramUpdCuando_cambia_mi_estado_de_animo = _dataProvider.GetParameter();
                paramUpdCuando_cambia_mi_estado_de_animo.ParameterName = "Cuando_cambia_mi_estado_de_animo";
                paramUpdCuando_cambia_mi_estado_de_animo.DbType = DbType.Int32;
                paramUpdCuando_cambia_mi_estado_de_animo.Value = (object)PacientesDB.Cuando_cambia_mi_estado_de_animo ?? DBNull.Value;
		var paramUpdMedicamentos_bajar_peso = _dataProvider.GetParameter();
                paramUpdMedicamentos_bajar_peso.ParameterName = "Medicamentos_bajar_peso";
                paramUpdMedicamentos_bajar_peso.DbType = DbType.Int32;
                paramUpdMedicamentos_bajar_peso.Value = (object)PacientesDB.Medicamentos_bajar_peso ?? DBNull.Value;
                var paramUpdCual_medicamento = _dataProvider.GetParameter();
                paramUpdCual_medicamento.ParameterName = "Cual_medicamento";
                paramUpdCual_medicamento.DbType = DbType.String;
                paramUpdCual_medicamento.Value = (object)PacientesDB.Cual_medicamento ?? DBNull.Value;
		var paramUpdFrecuencia_Ejercicio = _dataProvider.GetParameter();
                paramUpdFrecuencia_Ejercicio.ParameterName = "Frecuencia_Ejercicio";
                paramUpdFrecuencia_Ejercicio.DbType = DbType.Int32;
                paramUpdFrecuencia_Ejercicio.Value = (object)PacientesDB.Frecuencia_Ejercicio ?? DBNull.Value;
		var paramUpdDuracion_Ejercicio = _dataProvider.GetParameter();
                paramUpdDuracion_Ejercicio.ParameterName = "Duracion_Ejercicio";
                paramUpdDuracion_Ejercicio.DbType = DbType.Int32;
                paramUpdDuracion_Ejercicio.Value = (object)PacientesDB.Duracion_Ejercicio ?? DBNull.Value;
		var paramUpdTipo_Ejercicio = _dataProvider.GetParameter();
                paramUpdTipo_Ejercicio.ParameterName = "Tipo_Ejercicio";
                paramUpdTipo_Ejercicio.DbType = DbType.Int32;
                paramUpdTipo_Ejercicio.Value = (object)PacientesDB.Tipo_Ejercicio ?? DBNull.Value;
		var paramUpdAntiguedad_Ejercicio = _dataProvider.GetParameter();
                paramUpdAntiguedad_Ejercicio.ParameterName = "Antiguedad_Ejercicio";
                paramUpdAntiguedad_Ejercicio.DbType = DbType.Int32;
                paramUpdAntiguedad_Ejercicio.Value = (object)PacientesDB.Antiguedad_Ejercicio ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)PacientesDB.IMC ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)PacientesDB.Interpretacion_IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)PacientesDB.IMC_Pediatria ?? DBNull.Value;
                var paramUpdComplexion_corporal = _dataProvider.GetParameter();
                paramUpdComplexion_corporal.ParameterName = "Complexion_corporal";
                paramUpdComplexion_corporal.DbType = DbType.String;
                paramUpdComplexion_corporal.Value = (object)PacientesDB.Complexion_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_complexion_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_complexion_corporal.ParameterName = "Interpretacion_complexion_corporal";
                paramUpdInterpretacion_complexion_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_complexion_corporal.Value = (object)PacientesDB.Interpretacion_complexion_corporal ?? DBNull.Value;
                var paramUpdDistribucion_de_grasa_corporal = _dataProvider.GetParameter();
                paramUpdDistribucion_de_grasa_corporal.ParameterName = "Distribucion_de_grasa_corporal";
                paramUpdDistribucion_de_grasa_corporal.DbType = DbType.String;
                paramUpdDistribucion_de_grasa_corporal.Value = (object)PacientesDB.Distribucion_de_grasa_corporal ?? DBNull.Value;
		var paramUpdInterpretacion_grasa_corporal = _dataProvider.GetParameter();
                paramUpdInterpretacion_grasa_corporal.ParameterName = "Interpretacion_grasa_corporal";
                paramUpdInterpretacion_grasa_corporal.DbType = DbType.Int32;
                paramUpdInterpretacion_grasa_corporal.Value = (object)PacientesDB.Interpretacion_grasa_corporal ?? DBNull.Value;
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.String;
                paramUpdIndice_cintura_cadera.Value = (object)PacientesDB.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)PacientesDB.Interpretacion_indice ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.String;
                paramUpdConsumo_de_agua_resultado.Value = (object)PacientesDB.Consumo_de_agua_resultado ?? DBNull.Value;
		var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)PacientesDB.Interpretacion_agua ?? DBNull.Value;
                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)PacientesDB.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;
		var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)PacientesDB.Interpretacion_frecuencia ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.String;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)PacientesDB.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
		var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)PacientesDB.Interpretacion_dificultad ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)PacientesDB.Calorias ?? DBNull.Value;
		var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)PacientesDB.Interpretacion_calorias ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)PacientesDB.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPacientes>("sp_UpdPacientes" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdTipo_de_Registro , paramUpdTipo_de_Paciente , paramUpdUsuario_Registrado , paramUpdEmpresa , paramUpdNumero_de_Empleado , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdCelular , paramUpdEmail , paramUpdFecha_de_nacimiento , paramUpdNombre_del_Padre_o_Tutor , paramUpdPais_de_nacimiento , paramUpdLugar_de_nacimiento , paramUpdSexo , paramUpdEstado_Civil , paramUpdCalle , paramUpdNumero_exterior , paramUpdNumero_interior , paramUpdColonia , paramUpdCP , paramUpdCiudad , paramUpdPais , paramUpdEstado , paramUpdOcupacion , paramUpdCantidad_hijos , paramUpdObjetivo , paramUpdEstatus_Paciente , paramUpdCuenta_con_padecimientos , paramUpdFrecuencia_Cardiaca , paramUpdFrecuencia_Respiratoria , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdPeso_habitual , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdAnchura_de_muneca_mm , paramUpdCircunferencia_de_brazo_cm , paramUpdPliegue_cutaneo_tricipital_mm , paramUpdPliegue_cutaneo_bicipital_mm , paramUpdPliegue_cutaneo_subescapular_mm , paramUpdPliegue_cutaneo_supraespinal_mm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdMasa_Muscular_ , paramUpdEsta_embarazada , paramUpdSemana_de_gestacion , paramUpdPeso_pregestacional , paramUpdToma_anticonceptivos , paramUpdNombre_del_Anticonceptivo , paramUpdDosis , paramUpdClimaterio , paramUpdFecha_Climaterio , paramUpdTerapia_reemplazo_hormonal , paramUpdTipo_Dieta , paramUpdSuplementos , paramUpdConsumo_de_sal , paramUpdGrasas_Preferencias , paramUpdComidas_cantidad , paramUpdPreparacion_Preferencias , paramUpdEntre_comidas , paramUpdApetito , paramUpdHabitos_Modificacion , paramUpdHorario_hambre , paramUpdCuando_cambia_mi_estado_de_animo , paramUpdMedicamentos_bajar_peso , paramUpdCual_medicamento , paramUpdFrecuencia_Ejercicio , paramUpdDuracion_Ejercicio , paramUpdTipo_Ejercicio , paramUpdAntiguedad_Ejercicio , paramUpdIMC , paramUpdInterpretacion_IMC , paramUpdIMC_Pediatria , paramUpdComplexion_corporal , paramUpdInterpretacion_complexion_corporal , paramUpdDistribucion_de_grasa_corporal , paramUpdInterpretacion_grasa_corporal , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }


        #endregion
    }
}

