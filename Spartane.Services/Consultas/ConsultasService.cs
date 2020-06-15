using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Consultas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Consultas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class ConsultasService : IConsultasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Consultas.Consultas> _ConsultasRepository;
        #endregion

        #region Ctor
        public ConsultasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Consultas.Consultas> ConsultasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ConsultasRepository = ConsultasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._ConsultasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Consultas.Consultas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Consultas.Consultas>("sp_SelAllConsultas");
        }

        public IList<Core.Classes.Consultas.Consultas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallConsultas_Complete>("sp_SelAllComplete_Consultas");
            return data.Select(m => new Core.Classes.Consultas.Consultas
            {
                Folio = m.Folio
                ,Fecha_de_Registo = m.Fecha_de_Registo
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Fecha_Programada = m.Fecha_Programada
                ,Paciente_Pacientes = new Core.Classes.Pacientes.Pacientes() { Folio = m.Paciente.GetValueOrDefault(), Nombre_Completo = m.Paciente_Nombre_Completo }
                ,Edad = m.Edad
                ,Nombre_del_padre = m.Nombre_del_padre
                ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Sexo.GetValueOrDefault(), Descripcion = m.Sexo_Descripcion }
                ,Email = m.Email
                ,Objetivo_Objetivos = new Core.Classes.Objetivos.Objetivos() { Clave = m.Objetivo.GetValueOrDefault(), Descripcion = m.Objetivo_Descripcion }
                ,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
                ,Presion_sistolica = m.Presion_sistolica
                ,Presion_diastolica = m.Presion_diastolica
                ,Peso_actual = m.Peso_actual
                ,Estatura = m.Estatura
                ,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
                ,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
                ,Edad_Metabolica = m.Edad_Metabolica
                ,Agua_corporal = m.Agua_corporal
                ,Grasa_Visceral = m.Grasa_Visceral
                ,Grasa_Corporal = m.Grasa_Corporal
                ,Grasa_Corporal_kg = m.Grasa_Corporal_kg
                ,Masa_Muscular_kg = m.Masa_Muscular_kg
                ,Semana_de_gestacion = m.Semana_de_gestacion
                ,IMC = m.IMC
                ,IMC_Pediatria_Interpretacion_IMC = new Core.Classes.Interpretacion_IMC.Interpretacion_IMC() { Folio = m.IMC_Pediatria.GetValueOrDefault(), Descripcion = m.IMC_Pediatria_Descripcion }
                ,Interpretacion_IMC_Interpretacion_IMC = new Core.Classes.Interpretacion_IMC.Interpretacion_IMC() { Folio = m.Interpretacion_IMC.GetValueOrDefault(), Descripcion = m.Interpretacion_IMC_Descripcion }
                ,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                ,Interpretacion_agua_Interpretacion_consumo_de_agua = new Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua() { Folio = m.Interpretacion_agua.GetValueOrDefault(), Descripcion = m.Interpretacion_agua_Descripcion }
                ,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                ,Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo = new Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo() { Folio = m.Interpretacion_frecuencia.GetValueOrDefault(), Descripcion = m.Interpretacion_frecuencia_Descripcion }
                ,Indice_cintura_cadera = m.Indice_cintura_cadera
                ,Interpretacion_indice_Interpretacion_indice_cintura__cadera = new Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera() { Folio = m.Interpretacion_indice.GetValueOrDefault(), Descripcion = m.Interpretacion_indice_Descripcion }
                ,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                ,Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios = new Core.Classes.Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Interpretacion_Dificultad_de_Rutina_de_Ejercicios() { Folio = m.Interpretacion_dificultad.GetValueOrDefault(), Descripcion = m.Interpretacion_dificultad_Descripcion }
                ,Calorias = m.Calorias
                ,Interpretacion_calorias_Interpretacion_Calorias = new Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias() { Folio = m.Interpretacion_calorias.GetValueOrDefault(), Descripcion = m.Interpretacion_calorias_Descripcion }
                ,Observaciones = m.Observaciones
                ,Fecha_siguiente_Consulta = m.Fecha_siguiente_Consulta


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Consultas>("sp_ListSelCount_Consultas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Consultas.Consultas> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllConsultas>("sp_ListSelAll_Consultas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Consultas.Consultas
                {
                    Folio = m.Consultas_Folio,
                    Fecha_de_Registo = m.Consultas_Fecha_de_Registo,
                    Hora_de_Registro = m.Consultas_Hora_de_Registro,
                    Usuario_que_Registra = m.Consultas_Usuario_que_Registra,
                    Fecha_Programada = m.Consultas_Fecha_Programada,
                    Paciente = m.Consultas_Paciente,
                    Edad = m.Consultas_Edad,
                    Nombre_del_padre = m.Consultas_Nombre_del_padre,
                    Sexo = m.Consultas_Sexo,
                    Email = m.Consultas_Email,
                    Objetivo = m.Consultas_Objetivo,
                    Frecuencia_Cardiaca = m.Consultas_Frecuencia_Cardiaca,
                    Presion_sistolica = m.Consultas_Presion_sistolica,
                    Presion_diastolica = m.Consultas_Presion_diastolica,
                    Peso_actual = m.Consultas_Peso_actual,
                    Estatura = m.Consultas_Estatura,
                    Circunferencia_de_cintura_cm = m.Consultas_Circunferencia_de_cintura_cm,
                    Circunferencia_de_cadera_cm = m.Consultas_Circunferencia_de_cadera_cm,
                    Edad_Metabolica = m.Consultas_Edad_Metabolica,
                    Agua_corporal = m.Consultas_Agua_corporal,
                    Grasa_Visceral = m.Consultas_Grasa_Visceral,
                    Grasa_Corporal = m.Consultas_Grasa_Corporal,
                    Grasa_Corporal_kg = m.Consultas_Grasa_Corporal_kg,
                    Masa_Muscular_kg = m.Consultas_Masa_Muscular_kg,
                    Semana_de_gestacion = m.Consultas_Semana_de_gestacion,
                    IMC = m.Consultas_IMC,
                    IMC_Pediatria = m.Consultas_IMC_Pediatria,
                    Interpretacion_IMC = m.Consultas_Interpretacion_IMC,
                    Consumo_de_agua_resultado = m.Consultas_Consumo_de_agua_resultado,
                    Interpretacion_agua = m.Consultas_Interpretacion_agua,
                    Frecuencia_cardiaca_en_Esfuerzo = m.Consultas_Frecuencia_cardiaca_en_Esfuerzo,
                    Interpretacion_frecuencia = m.Consultas_Interpretacion_frecuencia,
                    Indice_cintura_cadera = m.Consultas_Indice_cintura_cadera,
                    Interpretacion_indice = m.Consultas_Interpretacion_indice,
                    Dificultad_de_Rutina_de_Ejercicios = m.Consultas_Dificultad_de_Rutina_de_Ejercicios,
                    Interpretacion_dificultad = m.Consultas_Interpretacion_dificultad,
                    Calorias = m.Consultas_Calorias,
                    Interpretacion_calorias = m.Consultas_Interpretacion_calorias,
                    Observaciones = m.Consultas_Observaciones,
                    Fecha_siguiente_Consulta = m.Consultas_Fecha_siguiente_Consulta,

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

        public IList<Spartane.Core.Classes.Consultas.Consultas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ConsultasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Consultas.Consultas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ConsultasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Consultas.ConsultasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllConsultas>("sp_ListSelAll_Consultas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            ConsultasPagingModel result = null;

            if (data != null)
            {
                result = new ConsultasPagingModel
                {
                    Consultass =
                        data.Select(m => new Spartane.Core.Classes.Consultas.Consultas
                {
                    Folio = m.Consultas_Folio
                    ,Fecha_de_Registo = m.Consultas_Fecha_de_Registo
                    ,Hora_de_Registro = m.Consultas_Hora_de_Registro
                    ,Usuario_que_Registra = m.Consultas_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Consultas_Usuario_que_Registra.GetValueOrDefault(), Name = m.Consultas_Usuario_que_Registra_Name }
                    ,Fecha_Programada = m.Consultas_Fecha_Programada
                    ,Paciente = m.Consultas_Paciente
                    ,Paciente_Pacientes = new Core.Classes.Pacientes.Pacientes() { Folio = m.Consultas_Paciente.GetValueOrDefault(), Nombre_Completo = m.Consultas_Paciente_Nombre_Completo }
                    ,Edad = m.Consultas_Edad
                    ,Nombre_del_padre = m.Consultas_Nombre_del_padre
                    ,Sexo = m.Consultas_Sexo
                    ,Sexo_Sexo = new Core.Classes.Sexo.Sexo() { Clave = m.Consultas_Sexo.GetValueOrDefault(), Descripcion = m.Consultas_Sexo_Descripcion }
                    ,Email = m.Consultas_Email
                    ,Objetivo = m.Consultas_Objetivo
                    ,Objetivo_Objetivos = new Core.Classes.Objetivos.Objetivos() { Clave = m.Consultas_Objetivo.GetValueOrDefault(), Descripcion = m.Consultas_Objetivo_Descripcion }
                    ,Frecuencia_Cardiaca = m.Consultas_Frecuencia_Cardiaca
                    ,Presion_sistolica = m.Consultas_Presion_sistolica
                    ,Presion_diastolica = m.Consultas_Presion_diastolica
                    ,Peso_actual = m.Consultas_Peso_actual
                    ,Estatura = m.Consultas_Estatura
                    ,Circunferencia_de_cintura_cm = m.Consultas_Circunferencia_de_cintura_cm
                    ,Circunferencia_de_cadera_cm = m.Consultas_Circunferencia_de_cadera_cm
                    ,Edad_Metabolica = m.Consultas_Edad_Metabolica
                    ,Agua_corporal = m.Consultas_Agua_corporal
                    ,Grasa_Visceral = m.Consultas_Grasa_Visceral
                    ,Grasa_Corporal = m.Consultas_Grasa_Corporal
                    ,Grasa_Corporal_kg = m.Consultas_Grasa_Corporal_kg
                    ,Masa_Muscular_kg = m.Consultas_Masa_Muscular_kg
                    ,Semana_de_gestacion = m.Consultas_Semana_de_gestacion
                    ,IMC = m.Consultas_IMC
                    ,IMC_Pediatria = m.Consultas_IMC_Pediatria
                    ,IMC_Pediatria_Interpretacion_IMC = new Core.Classes.Interpretacion_IMC.Interpretacion_IMC() { Folio = m.Consultas_IMC_Pediatria.GetValueOrDefault(), Descripcion = m.Consultas_IMC_Pediatria_Descripcion }
                    ,Interpretacion_IMC = m.Consultas_Interpretacion_IMC
                    ,Interpretacion_IMC_Interpretacion_IMC = new Core.Classes.Interpretacion_IMC.Interpretacion_IMC() { Folio = m.Consultas_Interpretacion_IMC.GetValueOrDefault(), Descripcion = m.Consultas_Interpretacion_IMC_Descripcion }
                    ,Consumo_de_agua_resultado = m.Consultas_Consumo_de_agua_resultado
                    ,Interpretacion_agua = m.Consultas_Interpretacion_agua
                    ,Interpretacion_agua_Interpretacion_consumo_de_agua = new Core.Classes.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua() { Folio = m.Consultas_Interpretacion_agua.GetValueOrDefault(), Descripcion = m.Consultas_Interpretacion_agua_Descripcion }
                    ,Frecuencia_cardiaca_en_Esfuerzo = m.Consultas_Frecuencia_cardiaca_en_Esfuerzo
                    ,Interpretacion_frecuencia = m.Consultas_Interpretacion_frecuencia
                    ,Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo = new Core.Classes.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo() { Folio = m.Consultas_Interpretacion_frecuencia.GetValueOrDefault(), Descripcion = m.Consultas_Interpretacion_frecuencia_Descripcion }
                    ,Indice_cintura_cadera = m.Consultas_Indice_cintura_cadera
                    ,Interpretacion_indice = m.Consultas_Interpretacion_indice
                    ,Interpretacion_indice_Interpretacion_indice_cintura__cadera = new Core.Classes.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera() { Folio = m.Consultas_Interpretacion_indice.GetValueOrDefault(), Descripcion = m.Consultas_Interpretacion_indice_Descripcion }
                    ,Dificultad_de_Rutina_de_Ejercicios = m.Consultas_Dificultad_de_Rutina_de_Ejercicios
                    ,Interpretacion_dificultad = m.Consultas_Interpretacion_dificultad
                    ,Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios = new Core.Classes.Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Interpretacion_Dificultad_de_Rutina_de_Ejercicios() { Folio = m.Consultas_Interpretacion_dificultad.GetValueOrDefault(), Descripcion = m.Consultas_Interpretacion_dificultad_Descripcion }
                    ,Calorias = m.Consultas_Calorias
                    ,Interpretacion_calorias = m.Consultas_Interpretacion_calorias
                    ,Interpretacion_calorias_Interpretacion_Calorias = new Core.Classes.Interpretacion_Calorias.Interpretacion_Calorias() { Folio = m.Consultas_Interpretacion_calorias.GetValueOrDefault(), Descripcion = m.Consultas_Interpretacion_calorias_Descripcion }
                    ,Observaciones = m.Consultas_Observaciones
                    ,Fecha_siguiente_Consulta = m.Consultas_Fecha_siguiente_Consulta

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Consultas.Consultas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._ConsultasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Consultas.Consultas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Consultas.Consultas>("sp_GetConsultas", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelConsultas>("sp_DelConsultas", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Consultas.Consultas entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFecha_de_Registo = _dataProvider.GetParameter();
                padreFecha_de_Registo.ParameterName = "Fecha_de_Registo";
                padreFecha_de_Registo.DbType = DbType.DateTime;
                padreFecha_de_Registo.Value = (object)entity.Fecha_de_Registo ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreUsuario_que_Registra = _dataProvider.GetParameter();
                padreUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                padreUsuario_que_Registra.DbType = DbType.Int32;
                padreUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var padreFecha_Programada = _dataProvider.GetParameter();
                padreFecha_Programada.ParameterName = "Fecha_Programada";
                padreFecha_Programada.DbType = DbType.DateTime;
                padreFecha_Programada.Value = (object)entity.Fecha_Programada ?? DBNull.Value;

                var padrePaciente = _dataProvider.GetParameter();
                padrePaciente.ParameterName = "Paciente";
                padrePaciente.DbType = DbType.Int32;
                padrePaciente.Value = (object)entity.Paciente ?? DBNull.Value;

                var padreEdad = _dataProvider.GetParameter();
                padreEdad.ParameterName = "Edad";
                padreEdad.DbType = DbType.Int32;
                padreEdad.Value = (object)entity.Edad ?? DBNull.Value;

                var padreNombre_del_padre = _dataProvider.GetParameter();
                padreNombre_del_padre.ParameterName = "Nombre_del_padre";
                padreNombre_del_padre.DbType = DbType.String;
                padreNombre_del_padre.Value = (object)entity.Nombre_del_padre ?? DBNull.Value;
                var padreSexo = _dataProvider.GetParameter();
                padreSexo.ParameterName = "Sexo";
                padreSexo.DbType = DbType.Int32;
                padreSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var padreEmail = _dataProvider.GetParameter();
                padreEmail.ParameterName = "Email";
                padreEmail.DbType = DbType.String;
                padreEmail.Value = (object)entity.Email ?? DBNull.Value;
                var padreObjetivo = _dataProvider.GetParameter();
                padreObjetivo.ParameterName = "Objetivo";
                padreObjetivo.DbType = DbType.Int32;
                padreObjetivo.Value = (object)entity.Objetivo ?? DBNull.Value;

                var padreFrecuencia_Cardiaca = _dataProvider.GetParameter();
                padreFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                padreFrecuencia_Cardiaca.DbType = DbType.Int32;
                padreFrecuencia_Cardiaca.Value = (object)entity.Frecuencia_Cardiaca ?? DBNull.Value;

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

                var padreCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                padreCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                padreCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                padreCircunferencia_de_cintura_cm.Value = (object)entity.Circunferencia_de_cintura_cm ?? DBNull.Value;

                var padreCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                padreCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                padreCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                padreCircunferencia_de_cadera_cm.Value = (object)entity.Circunferencia_de_cadera_cm ?? DBNull.Value;

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

                var padreSemana_de_gestacion = _dataProvider.GetParameter();
                padreSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                padreSemana_de_gestacion.DbType = DbType.Int32;
                padreSemana_de_gestacion.Value = (object)entity.Semana_de_gestacion ?? DBNull.Value;

                var padreIMC = _dataProvider.GetParameter();
                padreIMC.ParameterName = "IMC";
                padreIMC.DbType = DbType.Int32;
                padreIMC.Value = (object)entity.IMC ?? DBNull.Value;

                var padreIMC_Pediatria = _dataProvider.GetParameter();
                padreIMC_Pediatria.ParameterName = "IMC_Pediatria";
                padreIMC_Pediatria.DbType = DbType.Int32;
                padreIMC_Pediatria.Value = (object)entity.IMC_Pediatria ?? DBNull.Value;

                var padreInterpretacion_IMC = _dataProvider.GetParameter();
                padreInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                padreInterpretacion_IMC.DbType = DbType.Int32;
                padreInterpretacion_IMC.Value = (object)entity.Interpretacion_IMC ?? DBNull.Value;

                var padreConsumo_de_agua_resultado = _dataProvider.GetParameter();
                padreConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                padreConsumo_de_agua_resultado.DbType = DbType.Int32;
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

                var padreIndice_cintura_cadera = _dataProvider.GetParameter();
                padreIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                padreIndice_cintura_cadera.DbType = DbType.Int32;
                padreIndice_cintura_cadera.Value = (object)entity.Indice_cintura_cadera ?? DBNull.Value;

                var padreInterpretacion_indice = _dataProvider.GetParameter();
                padreInterpretacion_indice.ParameterName = "Interpretacion_indice";
                padreInterpretacion_indice.DbType = DbType.Int32;
                padreInterpretacion_indice.Value = (object)entity.Interpretacion_indice ?? DBNull.Value;

                var padreDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                padreDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                padreDificultad_de_Rutina_de_Ejercicios.DbType = DbType.Int32;
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
                var padreFecha_siguiente_Consulta = _dataProvider.GetParameter();
                padreFecha_siguiente_Consulta.ParameterName = "Fecha_siguiente_Consulta";
                padreFecha_siguiente_Consulta.DbType = DbType.DateTime;
                padreFecha_siguiente_Consulta.Value = (object)entity.Fecha_siguiente_Consulta ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsConsultas>("sp_InsConsultas" , padreFecha_de_Registo
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreFecha_Programada
, padrePaciente
, padreEdad
, padreNombre_del_padre
, padreSexo
, padreEmail
, padreObjetivo
, padreFrecuencia_Cardiaca
, padrePresion_sistolica
, padrePresion_diastolica
, padrePeso_actual
, padreEstatura
, padreCircunferencia_de_cintura_cm
, padreCircunferencia_de_cadera_cm
, padreEdad_Metabolica
, padreAgua_corporal
, padreGrasa_Visceral
, padreGrasa_Corporal
, padreGrasa_Corporal_kg
, padreMasa_Muscular_kg
, padreSemana_de_gestacion
, padreIMC
, padreIMC_Pediatria
, padreInterpretacion_IMC
, padreConsumo_de_agua_resultado
, padreInterpretacion_agua
, padreFrecuencia_cardiaca_en_Esfuerzo
, padreInterpretacion_frecuencia
, padreIndice_cintura_cadera
, padreInterpretacion_indice
, padreDificultad_de_Rutina_de_Ejercicios
, padreInterpretacion_dificultad
, padreCalorias
, padreInterpretacion_calorias
, padreObservaciones
, padreFecha_siguiente_Consulta
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

        public int Update(Spartane.Core.Classes.Consultas.Consultas entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registo = _dataProvider.GetParameter();
                paramUpdFecha_de_Registo.ParameterName = "Fecha_de_Registo";
                paramUpdFecha_de_Registo.DbType = DbType.DateTime;
                paramUpdFecha_de_Registo.Value = (object)entity.Fecha_de_Registo ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var paramUpdFecha_Programada = _dataProvider.GetParameter();
                paramUpdFecha_Programada.ParameterName = "Fecha_Programada";
                paramUpdFecha_Programada.DbType = DbType.DateTime;
                paramUpdFecha_Programada.Value = (object)entity.Fecha_Programada ?? DBNull.Value;

                var paramUpdPaciente = _dataProvider.GetParameter();
                paramUpdPaciente.ParameterName = "Paciente";
                paramUpdPaciente.DbType = DbType.Int32;
                paramUpdPaciente.Value = (object)entity.Paciente ?? DBNull.Value;

                var paramUpdEdad = _dataProvider.GetParameter();
                paramUpdEdad.ParameterName = "Edad";
                paramUpdEdad.DbType = DbType.Int32;
                paramUpdEdad.Value = (object)entity.Edad ?? DBNull.Value;

                var paramUpdNombre_del_padre = _dataProvider.GetParameter();
                paramUpdNombre_del_padre.ParameterName = "Nombre_del_padre";
                paramUpdNombre_del_padre.DbType = DbType.String;
                paramUpdNombre_del_padre.Value = (object)entity.Nombre_del_padre ?? DBNull.Value;
                var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;

                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
                var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)entity.Objetivo ?? DBNull.Value;

                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)entity.Frecuencia_Cardiaca ?? DBNull.Value;

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

                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)entity.Circunferencia_de_cintura_cm ?? DBNull.Value;

                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)entity.Circunferencia_de_cadera_cm ?? DBNull.Value;

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

                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)entity.Semana_de_gestacion ?? DBNull.Value;

                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)entity.IMC ?? DBNull.Value;

                var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)entity.IMC_Pediatria ?? DBNull.Value;

                var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)entity.Interpretacion_IMC ?? DBNull.Value;

                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.Int32;
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

                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.Int32;
                paramUpdIndice_cintura_cadera.Value = (object)entity.Indice_cintura_cadera ?? DBNull.Value;

                var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)entity.Interpretacion_indice ?? DBNull.Value;

                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.Int32;
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
                var paramUpdFecha_siguiente_Consulta = _dataProvider.GetParameter();
                paramUpdFecha_siguiente_Consulta.ParameterName = "Fecha_siguiente_Consulta";
                paramUpdFecha_siguiente_Consulta.DbType = DbType.DateTime;
                paramUpdFecha_siguiente_Consulta.Value = (object)entity.Fecha_siguiente_Consulta ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdConsultas>("sp_UpdConsultas" , paramUpdFolio , paramUpdFecha_de_Registo , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdFecha_Programada , paramUpdPaciente , paramUpdEdad , paramUpdNombre_del_padre , paramUpdSexo , paramUpdEmail , paramUpdObjetivo , paramUpdFrecuencia_Cardiaca , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdSemana_de_gestacion , paramUpdIMC , paramUpdIMC_Pediatria , paramUpdInterpretacion_IMC , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones , paramUpdFecha_siguiente_Consulta ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Consultas.Consultas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Consultas.Consultas ConsultasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registo = _dataProvider.GetParameter();
                paramUpdFecha_de_Registo.ParameterName = "Fecha_de_Registo";
                paramUpdFecha_de_Registo.DbType = DbType.DateTime;
                paramUpdFecha_de_Registo.Value = (object)entity.Fecha_de_Registo ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdFecha_Programada = _dataProvider.GetParameter();
                paramUpdFecha_Programada.ParameterName = "Fecha_Programada";
                paramUpdFecha_Programada.DbType = DbType.DateTime;
                paramUpdFecha_Programada.Value = (object)entity.Fecha_Programada ?? DBNull.Value;
                var paramUpdPaciente = _dataProvider.GetParameter();
                paramUpdPaciente.ParameterName = "Paciente";
                paramUpdPaciente.DbType = DbType.Int32;
                paramUpdPaciente.Value = (object)entity.Paciente ?? DBNull.Value;
                var paramUpdEdad = _dataProvider.GetParameter();
                paramUpdEdad.ParameterName = "Edad";
                paramUpdEdad.DbType = DbType.Int32;
                paramUpdEdad.Value = (object)entity.Edad ?? DBNull.Value;
                var paramUpdNombre_del_padre = _dataProvider.GetParameter();
                paramUpdNombre_del_padre.ParameterName = "Nombre_del_padre";
                paramUpdNombre_del_padre.DbType = DbType.String;
                paramUpdNombre_del_padre.Value = (object)entity.Nombre_del_padre ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)entity.Sexo ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)entity.Email ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)entity.Objetivo ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)ConsultasDB.Frecuencia_Cardiaca ?? DBNull.Value;
                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)ConsultasDB.Presion_sistolica ?? DBNull.Value;
                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)ConsultasDB.Presion_diastolica ?? DBNull.Value;
                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)ConsultasDB.Peso_actual ?? DBNull.Value;
                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)ConsultasDB.Estatura ?? DBNull.Value;
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)ConsultasDB.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)ConsultasDB.Circunferencia_de_cadera_cm ?? DBNull.Value;
                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)ConsultasDB.Edad_Metabolica ?? DBNull.Value;
                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)ConsultasDB.Agua_corporal ?? DBNull.Value;
                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)ConsultasDB.Grasa_Visceral ?? DBNull.Value;
                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)ConsultasDB.Grasa_Corporal ?? DBNull.Value;
                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)ConsultasDB.Grasa_Corporal_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)ConsultasDB.Masa_Muscular_kg ?? DBNull.Value;
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)ConsultasDB.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)ConsultasDB.IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)ConsultasDB.IMC_Pediatria ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)ConsultasDB.Interpretacion_IMC ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.Int32;
                paramUpdConsumo_de_agua_resultado.Value = (object)ConsultasDB.Consumo_de_agua_resultado ?? DBNull.Value;
		var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)ConsultasDB.Interpretacion_agua ?? DBNull.Value;
                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)ConsultasDB.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;
		var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)ConsultasDB.Interpretacion_frecuencia ?? DBNull.Value;
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.Int32;
                paramUpdIndice_cintura_cadera.Value = (object)ConsultasDB.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)ConsultasDB.Interpretacion_indice ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.Int32;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)ConsultasDB.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
		var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)ConsultasDB.Interpretacion_dificultad ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)ConsultasDB.Calorias ?? DBNull.Value;
		var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)ConsultasDB.Interpretacion_calorias ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)ConsultasDB.Observaciones ?? DBNull.Value;
                var paramUpdFecha_siguiente_Consulta = _dataProvider.GetParameter();
                paramUpdFecha_siguiente_Consulta.ParameterName = "Fecha_siguiente_Consulta";
                paramUpdFecha_siguiente_Consulta.DbType = DbType.DateTime;
                paramUpdFecha_siguiente_Consulta.Value = (object)ConsultasDB.Fecha_siguiente_Consulta ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdConsultas>("sp_UpdConsultas" , paramUpdFolio , paramUpdFecha_de_Registo , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdFecha_Programada , paramUpdPaciente , paramUpdEdad , paramUpdNombre_del_padre , paramUpdSexo , paramUpdEmail , paramUpdObjetivo , paramUpdFrecuencia_Cardiaca , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdSemana_de_gestacion , paramUpdIMC , paramUpdIMC_Pediatria , paramUpdInterpretacion_IMC , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones , paramUpdFecha_siguiente_Consulta ).FirstOrDefault();

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

		public int Update_Mediciones(Spartane.Core.Classes.Consultas.Consultas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Consultas.Consultas ConsultasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)ConsultasDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registo = _dataProvider.GetParameter();
                paramUpdFecha_de_Registo.ParameterName = "Fecha_de_Registo";
                paramUpdFecha_de_Registo.DbType = DbType.DateTime;
                paramUpdFecha_de_Registo.Value = (object)ConsultasDB.Fecha_de_Registo ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)ConsultasDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)ConsultasDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdFecha_Programada = _dataProvider.GetParameter();
                paramUpdFecha_Programada.ParameterName = "Fecha_Programada";
                paramUpdFecha_Programada.DbType = DbType.DateTime;
                paramUpdFecha_Programada.Value = (object)ConsultasDB.Fecha_Programada ?? DBNull.Value;
                var paramUpdPaciente = _dataProvider.GetParameter();
                paramUpdPaciente.ParameterName = "Paciente";
                paramUpdPaciente.DbType = DbType.Int32;
                paramUpdPaciente.Value = (object)ConsultasDB.Paciente ?? DBNull.Value;
                var paramUpdEdad = _dataProvider.GetParameter();
                paramUpdEdad.ParameterName = "Edad";
                paramUpdEdad.DbType = DbType.Int32;
                paramUpdEdad.Value = (object)ConsultasDB.Edad ?? DBNull.Value;
                var paramUpdNombre_del_padre = _dataProvider.GetParameter();
                paramUpdNombre_del_padre.ParameterName = "Nombre_del_padre";
                paramUpdNombre_del_padre.DbType = DbType.String;
                paramUpdNombre_del_padre.Value = (object)ConsultasDB.Nombre_del_padre ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)ConsultasDB.Sexo ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)ConsultasDB.Email ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)ConsultasDB.Objetivo ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)entity.Frecuencia_Cardiaca ?? DBNull.Value;
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
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)entity.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)entity.Circunferencia_de_cadera_cm ?? DBNull.Value;
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
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)entity.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)ConsultasDB.IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)ConsultasDB.IMC_Pediatria ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)ConsultasDB.Interpretacion_IMC ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.Int32;
                paramUpdConsumo_de_agua_resultado.Value = (object)ConsultasDB.Consumo_de_agua_resultado ?? DBNull.Value;
		var paramUpdInterpretacion_agua = _dataProvider.GetParameter();
                paramUpdInterpretacion_agua.ParameterName = "Interpretacion_agua";
                paramUpdInterpretacion_agua.DbType = DbType.Int32;
                paramUpdInterpretacion_agua.Value = (object)ConsultasDB.Interpretacion_agua ?? DBNull.Value;
                var paramUpdFrecuencia_cardiaca_en_Esfuerzo = _dataProvider.GetParameter();
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.ParameterName = "Frecuencia_cardiaca_en_Esfuerzo";
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.DbType = DbType.Int32;
                paramUpdFrecuencia_cardiaca_en_Esfuerzo.Value = (object)ConsultasDB.Frecuencia_cardiaca_en_Esfuerzo ?? DBNull.Value;
		var paramUpdInterpretacion_frecuencia = _dataProvider.GetParameter();
                paramUpdInterpretacion_frecuencia.ParameterName = "Interpretacion_frecuencia";
                paramUpdInterpretacion_frecuencia.DbType = DbType.Int32;
                paramUpdInterpretacion_frecuencia.Value = (object)ConsultasDB.Interpretacion_frecuencia ?? DBNull.Value;
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.Int32;
                paramUpdIndice_cintura_cadera.Value = (object)ConsultasDB.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)ConsultasDB.Interpretacion_indice ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.Int32;
                paramUpdDificultad_de_Rutina_de_Ejercicios.Value = (object)ConsultasDB.Dificultad_de_Rutina_de_Ejercicios ?? DBNull.Value;
		var paramUpdInterpretacion_dificultad = _dataProvider.GetParameter();
                paramUpdInterpretacion_dificultad.ParameterName = "Interpretacion_dificultad";
                paramUpdInterpretacion_dificultad.DbType = DbType.Int32;
                paramUpdInterpretacion_dificultad.Value = (object)ConsultasDB.Interpretacion_dificultad ?? DBNull.Value;
                var paramUpdCalorias = _dataProvider.GetParameter();
                paramUpdCalorias.ParameterName = "Calorias";
                paramUpdCalorias.DbType = DbType.Int32;
                paramUpdCalorias.Value = (object)ConsultasDB.Calorias ?? DBNull.Value;
		var paramUpdInterpretacion_calorias = _dataProvider.GetParameter();
                paramUpdInterpretacion_calorias.ParameterName = "Interpretacion_calorias";
                paramUpdInterpretacion_calorias.DbType = DbType.Int32;
                paramUpdInterpretacion_calorias.Value = (object)ConsultasDB.Interpretacion_calorias ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)ConsultasDB.Observaciones ?? DBNull.Value;
                var paramUpdFecha_siguiente_Consulta = _dataProvider.GetParameter();
                paramUpdFecha_siguiente_Consulta.ParameterName = "Fecha_siguiente_Consulta";
                paramUpdFecha_siguiente_Consulta.DbType = DbType.DateTime;
                paramUpdFecha_siguiente_Consulta.Value = (object)ConsultasDB.Fecha_siguiente_Consulta ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdConsultas>("sp_UpdConsultas" , paramUpdFolio , paramUpdFecha_de_Registo , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdFecha_Programada , paramUpdPaciente , paramUpdEdad , paramUpdNombre_del_padre , paramUpdSexo , paramUpdEmail , paramUpdObjetivo , paramUpdFrecuencia_Cardiaca , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdSemana_de_gestacion , paramUpdIMC , paramUpdIMC_Pediatria , paramUpdInterpretacion_IMC , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones , paramUpdFecha_siguiente_Consulta ).FirstOrDefault();

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

		public int Update_Resultados(Spartane.Core.Classes.Consultas.Consultas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Consultas.Consultas ConsultasDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)ConsultasDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registo = _dataProvider.GetParameter();
                paramUpdFecha_de_Registo.ParameterName = "Fecha_de_Registo";
                paramUpdFecha_de_Registo.DbType = DbType.DateTime;
                paramUpdFecha_de_Registo.Value = (object)ConsultasDB.Fecha_de_Registo ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)ConsultasDB.Hora_de_Registro ?? DBNull.Value;
		var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)ConsultasDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdFecha_Programada = _dataProvider.GetParameter();
                paramUpdFecha_Programada.ParameterName = "Fecha_Programada";
                paramUpdFecha_Programada.DbType = DbType.DateTime;
                paramUpdFecha_Programada.Value = (object)ConsultasDB.Fecha_Programada ?? DBNull.Value;
                var paramUpdPaciente = _dataProvider.GetParameter();
                paramUpdPaciente.ParameterName = "Paciente";
                paramUpdPaciente.DbType = DbType.Int32;
                paramUpdPaciente.Value = (object)ConsultasDB.Paciente ?? DBNull.Value;
                var paramUpdEdad = _dataProvider.GetParameter();
                paramUpdEdad.ParameterName = "Edad";
                paramUpdEdad.DbType = DbType.Int32;
                paramUpdEdad.Value = (object)ConsultasDB.Edad ?? DBNull.Value;
                var paramUpdNombre_del_padre = _dataProvider.GetParameter();
                paramUpdNombre_del_padre.ParameterName = "Nombre_del_padre";
                paramUpdNombre_del_padre.DbType = DbType.String;
                paramUpdNombre_del_padre.Value = (object)ConsultasDB.Nombre_del_padre ?? DBNull.Value;
		var paramUpdSexo = _dataProvider.GetParameter();
                paramUpdSexo.ParameterName = "Sexo";
                paramUpdSexo.DbType = DbType.Int32;
                paramUpdSexo.Value = (object)ConsultasDB.Sexo ?? DBNull.Value;
                var paramUpdEmail = _dataProvider.GetParameter();
                paramUpdEmail.ParameterName = "Email";
                paramUpdEmail.DbType = DbType.String;
                paramUpdEmail.Value = (object)ConsultasDB.Email ?? DBNull.Value;
		var paramUpdObjetivo = _dataProvider.GetParameter();
                paramUpdObjetivo.ParameterName = "Objetivo";
                paramUpdObjetivo.DbType = DbType.Int32;
                paramUpdObjetivo.Value = (object)ConsultasDB.Objetivo ?? DBNull.Value;
                var paramUpdFrecuencia_Cardiaca = _dataProvider.GetParameter();
                paramUpdFrecuencia_Cardiaca.ParameterName = "Frecuencia_Cardiaca";
                paramUpdFrecuencia_Cardiaca.DbType = DbType.Int32;
                paramUpdFrecuencia_Cardiaca.Value = (object)ConsultasDB.Frecuencia_Cardiaca ?? DBNull.Value;
                var paramUpdPresion_sistolica = _dataProvider.GetParameter();
                paramUpdPresion_sistolica.ParameterName = "Presion_sistolica";
                paramUpdPresion_sistolica.DbType = DbType.Int32;
                paramUpdPresion_sistolica.Value = (object)ConsultasDB.Presion_sistolica ?? DBNull.Value;
                var paramUpdPresion_diastolica = _dataProvider.GetParameter();
                paramUpdPresion_diastolica.ParameterName = "Presion_diastolica";
                paramUpdPresion_diastolica.DbType = DbType.Int32;
                paramUpdPresion_diastolica.Value = (object)ConsultasDB.Presion_diastolica ?? DBNull.Value;
                var paramUpdPeso_actual = _dataProvider.GetParameter();
                paramUpdPeso_actual.ParameterName = "Peso_actual";
                paramUpdPeso_actual.DbType = DbType.Decimal;
                paramUpdPeso_actual.Value = (object)ConsultasDB.Peso_actual ?? DBNull.Value;
                var paramUpdEstatura = _dataProvider.GetParameter();
                paramUpdEstatura.ParameterName = "Estatura";
                paramUpdEstatura.DbType = DbType.Decimal;
                paramUpdEstatura.Value = (object)ConsultasDB.Estatura ?? DBNull.Value;
                var paramUpdCircunferencia_de_cintura_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cintura_cm.ParameterName = "Circunferencia_de_cintura_cm";
                paramUpdCircunferencia_de_cintura_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cintura_cm.Value = (object)ConsultasDB.Circunferencia_de_cintura_cm ?? DBNull.Value;
                var paramUpdCircunferencia_de_cadera_cm = _dataProvider.GetParameter();
                paramUpdCircunferencia_de_cadera_cm.ParameterName = "Circunferencia_de_cadera_cm";
                paramUpdCircunferencia_de_cadera_cm.DbType = DbType.Int32;
                paramUpdCircunferencia_de_cadera_cm.Value = (object)ConsultasDB.Circunferencia_de_cadera_cm ?? DBNull.Value;
                var paramUpdEdad_Metabolica = _dataProvider.GetParameter();
                paramUpdEdad_Metabolica.ParameterName = "Edad_Metabolica";
                paramUpdEdad_Metabolica.DbType = DbType.Int32;
                paramUpdEdad_Metabolica.Value = (object)ConsultasDB.Edad_Metabolica ?? DBNull.Value;
                var paramUpdAgua_corporal = _dataProvider.GetParameter();
                paramUpdAgua_corporal.ParameterName = "Agua_corporal";
                paramUpdAgua_corporal.DbType = DbType.Int32;
                paramUpdAgua_corporal.Value = (object)ConsultasDB.Agua_corporal ?? DBNull.Value;
                var paramUpdGrasa_Visceral = _dataProvider.GetParameter();
                paramUpdGrasa_Visceral.ParameterName = "Grasa_Visceral";
                paramUpdGrasa_Visceral.DbType = DbType.Int32;
                paramUpdGrasa_Visceral.Value = (object)ConsultasDB.Grasa_Visceral ?? DBNull.Value;
                var paramUpdGrasa_Corporal = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal.ParameterName = "Grasa_Corporal";
                paramUpdGrasa_Corporal.DbType = DbType.Int32;
                paramUpdGrasa_Corporal.Value = (object)ConsultasDB.Grasa_Corporal ?? DBNull.Value;
                var paramUpdGrasa_Corporal_kg = _dataProvider.GetParameter();
                paramUpdGrasa_Corporal_kg.ParameterName = "Grasa_Corporal_kg";
                paramUpdGrasa_Corporal_kg.DbType = DbType.Int32;
                paramUpdGrasa_Corporal_kg.Value = (object)ConsultasDB.Grasa_Corporal_kg ?? DBNull.Value;
                var paramUpdMasa_Muscular_kg = _dataProvider.GetParameter();
                paramUpdMasa_Muscular_kg.ParameterName = "Masa_Muscular_kg";
                paramUpdMasa_Muscular_kg.DbType = DbType.Int32;
                paramUpdMasa_Muscular_kg.Value = (object)ConsultasDB.Masa_Muscular_kg ?? DBNull.Value;
                var paramUpdSemana_de_gestacion = _dataProvider.GetParameter();
                paramUpdSemana_de_gestacion.ParameterName = "Semana_de_gestacion";
                paramUpdSemana_de_gestacion.DbType = DbType.Int32;
                paramUpdSemana_de_gestacion.Value = (object)ConsultasDB.Semana_de_gestacion ?? DBNull.Value;
                var paramUpdIMC = _dataProvider.GetParameter();
                paramUpdIMC.ParameterName = "IMC";
                paramUpdIMC.DbType = DbType.Int32;
                paramUpdIMC.Value = (object)entity.IMC ?? DBNull.Value;
		var paramUpdIMC_Pediatria = _dataProvider.GetParameter();
                paramUpdIMC_Pediatria.ParameterName = "IMC_Pediatria";
                paramUpdIMC_Pediatria.DbType = DbType.Int32;
                paramUpdIMC_Pediatria.Value = (object)entity.IMC_Pediatria ?? DBNull.Value;
		var paramUpdInterpretacion_IMC = _dataProvider.GetParameter();
                paramUpdInterpretacion_IMC.ParameterName = "Interpretacion_IMC";
                paramUpdInterpretacion_IMC.DbType = DbType.Int32;
                paramUpdInterpretacion_IMC.Value = (object)entity.Interpretacion_IMC ?? DBNull.Value;
                var paramUpdConsumo_de_agua_resultado = _dataProvider.GetParameter();
                paramUpdConsumo_de_agua_resultado.ParameterName = "Consumo_de_agua_resultado";
                paramUpdConsumo_de_agua_resultado.DbType = DbType.Int32;
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
                var paramUpdIndice_cintura_cadera = _dataProvider.GetParameter();
                paramUpdIndice_cintura_cadera.ParameterName = "Indice_cintura_cadera";
                paramUpdIndice_cintura_cadera.DbType = DbType.Int32;
                paramUpdIndice_cintura_cadera.Value = (object)entity.Indice_cintura_cadera ?? DBNull.Value;
		var paramUpdInterpretacion_indice = _dataProvider.GetParameter();
                paramUpdInterpretacion_indice.ParameterName = "Interpretacion_indice";
                paramUpdInterpretacion_indice.DbType = DbType.Int32;
                paramUpdInterpretacion_indice.Value = (object)entity.Interpretacion_indice ?? DBNull.Value;
                var paramUpdDificultad_de_Rutina_de_Ejercicios = _dataProvider.GetParameter();
                paramUpdDificultad_de_Rutina_de_Ejercicios.ParameterName = "Dificultad_de_Rutina_de_Ejercicios";
                paramUpdDificultad_de_Rutina_de_Ejercicios.DbType = DbType.Int32;
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
                var paramUpdFecha_siguiente_Consulta = _dataProvider.GetParameter();
                paramUpdFecha_siguiente_Consulta.ParameterName = "Fecha_siguiente_Consulta";
                paramUpdFecha_siguiente_Consulta.DbType = DbType.DateTime;
                paramUpdFecha_siguiente_Consulta.Value = (object)entity.Fecha_siguiente_Consulta ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdConsultas>("sp_UpdConsultas" , paramUpdFolio , paramUpdFecha_de_Registo , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdFecha_Programada , paramUpdPaciente , paramUpdEdad , paramUpdNombre_del_padre , paramUpdSexo , paramUpdEmail , paramUpdObjetivo , paramUpdFrecuencia_Cardiaca , paramUpdPresion_sistolica , paramUpdPresion_diastolica , paramUpdPeso_actual , paramUpdEstatura , paramUpdCircunferencia_de_cintura_cm , paramUpdCircunferencia_de_cadera_cm , paramUpdEdad_Metabolica , paramUpdAgua_corporal , paramUpdGrasa_Visceral , paramUpdGrasa_Corporal , paramUpdGrasa_Corporal_kg , paramUpdMasa_Muscular_kg , paramUpdSemana_de_gestacion , paramUpdIMC , paramUpdIMC_Pediatria , paramUpdInterpretacion_IMC , paramUpdConsumo_de_agua_resultado , paramUpdInterpretacion_agua , paramUpdFrecuencia_cardiaca_en_Esfuerzo , paramUpdInterpretacion_frecuencia , paramUpdIndice_cintura_cadera , paramUpdInterpretacion_indice , paramUpdDificultad_de_Rutina_de_Ejercicios , paramUpdInterpretacion_dificultad , paramUpdCalorias , paramUpdInterpretacion_calorias , paramUpdObservaciones , paramUpdFecha_siguiente_Consulta ).FirstOrDefault();

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

