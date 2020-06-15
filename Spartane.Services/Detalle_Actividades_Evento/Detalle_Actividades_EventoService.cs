using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Actividades_Evento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Actividades_Evento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Actividades_EventoService : IDetalle_Actividades_EventoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento> _Detalle_Actividades_EventoRepository;
        #endregion

        #region Ctor
        public Detalle_Actividades_EventoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento> Detalle_Actividades_EventoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Actividades_EventoRepository = Detalle_Actividades_EventoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Actividades_EventoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento>("sp_SelAllDetalle_Actividades_Evento");
        }

        public IList<Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Actividades_Evento_Complete>("sp_SelAllComplete_Detalle_Actividades_Evento");
            return data.Select(m => new Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento
            {
                Folio = m.Folio
                ,Folio_Eventos = m.Folio_Eventos
                ,Tipo_de_Actividad_Tipos_de_Actividades = new Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades() { Folio = m.Tipo_de_Actividad.GetValueOrDefault(), Descripcion = m.Tipo_de_Actividad_Descripcion }
                ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Especialidad.GetValueOrDefault(), Especialidad = m.Especialidad_Especialidad }
                ,Nombre_de_la_Actividad = m.Nombre_de_la_Actividad
                ,Descripcion = m.Descripcion
                ,Quien_imparte_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Quien_imparte.GetValueOrDefault(), Name = m.Quien_imparte_Name }
                ,Dia = m.Dia
                ,Hora_inicio = m.Hora_inicio
                ,Hora_fin = m.Hora_fin
                ,Tiene_receso = m.Tiene_receso.GetValueOrDefault()
                ,Hora_inicio_receso = m.Hora_inicio_receso
                ,Hora_fin_receso = m.Hora_fin_receso
                ,Duracion_maxima_por_paciente_mins = m.Duracion_maxima_por_paciente_mins
                ,Cupo_limitado = m.Cupo_limitado.GetValueOrDefault()
                ,Cupo_maximo = m.Cupo_maximo
                ,Ubicacion_Ubicaciones_Eventos_Empresa = new Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa() { Folio = m.Ubicacion.GetValueOrDefault(), Nombre = m.Ubicacion_Nombre }
                ,Estatus_de_la_Actividad_Estatus_Actividades_Evento = new Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento() { Folio = m.Estatus_de_la_Actividad.GetValueOrDefault(), Descripcion = m.Estatus_de_la_Actividad_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Actividades_Evento>("sp_ListSelCount_Detalle_Actividades_Evento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Actividades_Evento>("sp_ListSelAll_Detalle_Actividades_Evento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento
                {
                    Folio = m.Detalle_Actividades_Evento_Folio,
                    Folio_Eventos = m.Detalle_Actividades_Evento_Folio_Eventos,
                    Tipo_de_Actividad = m.Detalle_Actividades_Evento_Tipo_de_Actividad,
                    Especialidad = m.Detalle_Actividades_Evento_Especialidad,
                    Nombre_de_la_Actividad = m.Detalle_Actividades_Evento_Nombre_de_la_Actividad,
                    Descripcion = m.Detalle_Actividades_Evento_Descripcion,
                    Quien_imparte = m.Detalle_Actividades_Evento_Quien_imparte,
                    Dia = m.Detalle_Actividades_Evento_Dia,
                    Hora_inicio = m.Detalle_Actividades_Evento_Hora_inicio,
                    Hora_fin = m.Detalle_Actividades_Evento_Hora_fin,
                    Tiene_receso = m.Detalle_Actividades_Evento_Tiene_receso ?? false,
                    Hora_inicio_receso = m.Detalle_Actividades_Evento_Hora_inicio_receso,
                    Hora_fin_receso = m.Detalle_Actividades_Evento_Hora_fin_receso,
                    Duracion_maxima_por_paciente_mins = m.Detalle_Actividades_Evento_Duracion_maxima_por_paciente_mins,
                    Cupo_limitado = m.Detalle_Actividades_Evento_Cupo_limitado ?? false,
                    Cupo_maximo = m.Detalle_Actividades_Evento_Cupo_maximo,
                    Ubicacion = m.Detalle_Actividades_Evento_Ubicacion,
                    Estatus_de_la_Actividad = m.Detalle_Actividades_Evento_Estatus_de_la_Actividad,

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

        public IList<Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Actividades_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Actividades_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Actividades_Evento>("sp_ListSelAll_Detalle_Actividades_Evento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Actividades_EventoPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Actividades_EventoPagingModel
                {
                    Detalle_Actividades_Eventos =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento
                {
                    Folio = m.Detalle_Actividades_Evento_Folio
                    ,Folio_Eventos = m.Detalle_Actividades_Evento_Folio_Eventos
                    ,Tipo_de_Actividad = m.Detalle_Actividades_Evento_Tipo_de_Actividad
                    ,Tipo_de_Actividad_Tipos_de_Actividades = new Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades() { Folio = m.Detalle_Actividades_Evento_Tipo_de_Actividad.GetValueOrDefault(), Descripcion = m.Detalle_Actividades_Evento_Tipo_de_Actividad_Descripcion }
                    ,Especialidad = m.Detalle_Actividades_Evento_Especialidad
                    ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Detalle_Actividades_Evento_Especialidad.GetValueOrDefault(), Especialidad = m.Detalle_Actividades_Evento_Especialidad_Especialidad }
                    ,Nombre_de_la_Actividad = m.Detalle_Actividades_Evento_Nombre_de_la_Actividad
                    ,Descripcion = m.Detalle_Actividades_Evento_Descripcion
                    ,Quien_imparte = m.Detalle_Actividades_Evento_Quien_imparte
                    ,Quien_imparte_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Detalle_Actividades_Evento_Quien_imparte.GetValueOrDefault(), Name = m.Detalle_Actividades_Evento_Quien_imparte_Name }
                    ,Dia = m.Detalle_Actividades_Evento_Dia
                    ,Hora_inicio = m.Detalle_Actividades_Evento_Hora_inicio
                    ,Hora_fin = m.Detalle_Actividades_Evento_Hora_fin
                    ,Tiene_receso = m.Detalle_Actividades_Evento_Tiene_receso ?? false
                    ,Hora_inicio_receso = m.Detalle_Actividades_Evento_Hora_inicio_receso
                    ,Hora_fin_receso = m.Detalle_Actividades_Evento_Hora_fin_receso
                    ,Duracion_maxima_por_paciente_mins = m.Detalle_Actividades_Evento_Duracion_maxima_por_paciente_mins
                    ,Cupo_limitado = m.Detalle_Actividades_Evento_Cupo_limitado ?? false
                    ,Cupo_maximo = m.Detalle_Actividades_Evento_Cupo_maximo
                    ,Ubicacion = m.Detalle_Actividades_Evento_Ubicacion
                    ,Ubicacion_Ubicaciones_Eventos_Empresa = new Core.Classes.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa() { Folio = m.Detalle_Actividades_Evento_Ubicacion.GetValueOrDefault(), Nombre = m.Detalle_Actividades_Evento_Ubicacion_Nombre }
                    ,Estatus_de_la_Actividad = m.Detalle_Actividades_Evento_Estatus_de_la_Actividad
                    ,Estatus_de_la_Actividad_Estatus_Actividades_Evento = new Core.Classes.Estatus_Actividades_Evento.Estatus_Actividades_Evento() { Folio = m.Detalle_Actividades_Evento_Estatus_de_la_Actividad.GetValueOrDefault(), Descripcion = m.Detalle_Actividades_Evento_Estatus_de_la_Actividad_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Actividades_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento>("sp_GetDetalle_Actividades_Evento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Actividades_Evento>("sp_DelDetalle_Actividades_Evento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Eventos = _dataProvider.GetParameter();
                padreFolio_Eventos.ParameterName = "Folio_Eventos";
                padreFolio_Eventos.DbType = DbType.Int32;
                padreFolio_Eventos.Value = (object)entity.Folio_Eventos ?? DBNull.Value;
                var padreTipo_de_Actividad = _dataProvider.GetParameter();
                padreTipo_de_Actividad.ParameterName = "Tipo_de_Actividad";
                padreTipo_de_Actividad.DbType = DbType.Int32;
                padreTipo_de_Actividad.Value = (object)entity.Tipo_de_Actividad ?? DBNull.Value;

                var padreEspecialidad = _dataProvider.GetParameter();
                padreEspecialidad.ParameterName = "Especialidad";
                padreEspecialidad.DbType = DbType.Int32;
                padreEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var padreNombre_de_la_Actividad = _dataProvider.GetParameter();
                padreNombre_de_la_Actividad.ParameterName = "Nombre_de_la_Actividad";
                padreNombre_de_la_Actividad.DbType = DbType.String;
                padreNombre_de_la_Actividad.Value = (object)entity.Nombre_de_la_Actividad ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padreQuien_imparte = _dataProvider.GetParameter();
                padreQuien_imparte.ParameterName = "Quien_imparte";
                padreQuien_imparte.DbType = DbType.Int32;
                padreQuien_imparte.Value = (object)entity.Quien_imparte ?? DBNull.Value;

                var padreDia = _dataProvider.GetParameter();
                padreDia.ParameterName = "Dia";
                padreDia.DbType = DbType.DateTime;
                padreDia.Value = (object)entity.Dia ?? DBNull.Value;

                var padreHora_inicio = _dataProvider.GetParameter();
                padreHora_inicio.ParameterName = "Hora_inicio";
                padreHora_inicio.DbType = DbType.String;
                padreHora_inicio.Value = (object)entity.Hora_inicio ?? DBNull.Value;
                var padreHora_fin = _dataProvider.GetParameter();
                padreHora_fin.ParameterName = "Hora_fin";
                padreHora_fin.DbType = DbType.String;
                padreHora_fin.Value = (object)entity.Hora_fin ?? DBNull.Value;
                var padreTiene_receso = _dataProvider.GetParameter();
                padreTiene_receso.ParameterName = "Tiene_receso";
                padreTiene_receso.DbType = DbType.Boolean;
                padreTiene_receso.Value = (object)entity.Tiene_receso ?? DBNull.Value;
                var padreHora_inicio_receso = _dataProvider.GetParameter();
                padreHora_inicio_receso.ParameterName = "Hora_inicio_receso";
                padreHora_inicio_receso.DbType = DbType.String;
                padreHora_inicio_receso.Value = (object)entity.Hora_inicio_receso ?? DBNull.Value;
                var padreHora_fin_receso = _dataProvider.GetParameter();
                padreHora_fin_receso.ParameterName = "Hora_fin_receso";
                padreHora_fin_receso.DbType = DbType.String;
                padreHora_fin_receso.Value = (object)entity.Hora_fin_receso ?? DBNull.Value;
                var padreDuracion_maxima_por_paciente_mins = _dataProvider.GetParameter();
                padreDuracion_maxima_por_paciente_mins.ParameterName = "Duracion_maxima_por_paciente_mins";
                padreDuracion_maxima_por_paciente_mins.DbType = DbType.Int32;
                padreDuracion_maxima_por_paciente_mins.Value = (object)entity.Duracion_maxima_por_paciente_mins ?? DBNull.Value;

                var padreCupo_limitado = _dataProvider.GetParameter();
                padreCupo_limitado.ParameterName = "Cupo_limitado";
                padreCupo_limitado.DbType = DbType.Boolean;
                padreCupo_limitado.Value = (object)entity.Cupo_limitado ?? DBNull.Value;
                var padreCupo_maximo = _dataProvider.GetParameter();
                padreCupo_maximo.ParameterName = "Cupo_maximo";
                padreCupo_maximo.DbType = DbType.Int32;
                padreCupo_maximo.Value = (object)entity.Cupo_maximo ?? DBNull.Value;

                var padreUbicacion = _dataProvider.GetParameter();
                padreUbicacion.ParameterName = "Ubicacion";
                padreUbicacion.DbType = DbType.Int32;
                padreUbicacion.Value = (object)entity.Ubicacion ?? DBNull.Value;

                var padreEstatus_de_la_Actividad = _dataProvider.GetParameter();
                padreEstatus_de_la_Actividad.ParameterName = "Estatus_de_la_Actividad";
                padreEstatus_de_la_Actividad.DbType = DbType.Int32;
                padreEstatus_de_la_Actividad.Value = (object)entity.Estatus_de_la_Actividad ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Actividades_Evento>("sp_InsDetalle_Actividades_Evento" , padreFolio_Eventos
, padreTipo_de_Actividad
, padreEspecialidad
, padreNombre_de_la_Actividad
, padreDescripcion
, padreQuien_imparte
, padreDia
, padreHora_inicio
, padreHora_fin
, padreTiene_receso
, padreHora_inicio_receso
, padreHora_fin_receso
, padreDuracion_maxima_por_paciente_mins
, padreCupo_limitado
, padreCupo_maximo
, padreUbicacion
, padreEstatus_de_la_Actividad
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

        public int Update(Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Eventos = _dataProvider.GetParameter();
                paramUpdFolio_Eventos.ParameterName = "Folio_Eventos";
                paramUpdFolio_Eventos.DbType = DbType.Int32;
                paramUpdFolio_Eventos.Value = (object)entity.Folio_Eventos ?? DBNull.Value;
                var paramUpdTipo_de_Actividad = _dataProvider.GetParameter();
                paramUpdTipo_de_Actividad.ParameterName = "Tipo_de_Actividad";
                paramUpdTipo_de_Actividad.DbType = DbType.Int32;
                paramUpdTipo_de_Actividad.Value = (object)entity.Tipo_de_Actividad ?? DBNull.Value;

                var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var paramUpdNombre_de_la_Actividad = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Actividad.ParameterName = "Nombre_de_la_Actividad";
                paramUpdNombre_de_la_Actividad.DbType = DbType.String;
                paramUpdNombre_de_la_Actividad.Value = (object)entity.Nombre_de_la_Actividad ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdQuien_imparte = _dataProvider.GetParameter();
                paramUpdQuien_imparte.ParameterName = "Quien_imparte";
                paramUpdQuien_imparte.DbType = DbType.Int32;
                paramUpdQuien_imparte.Value = (object)entity.Quien_imparte ?? DBNull.Value;

                var paramUpdDia = _dataProvider.GetParameter();
                paramUpdDia.ParameterName = "Dia";
                paramUpdDia.DbType = DbType.DateTime;
                paramUpdDia.Value = (object)entity.Dia ?? DBNull.Value;

                var paramUpdHora_inicio = _dataProvider.GetParameter();
                paramUpdHora_inicio.ParameterName = "Hora_inicio";
                paramUpdHora_inicio.DbType = DbType.String;
                paramUpdHora_inicio.Value = (object)entity.Hora_inicio ?? DBNull.Value;
                var paramUpdHora_fin = _dataProvider.GetParameter();
                paramUpdHora_fin.ParameterName = "Hora_fin";
                paramUpdHora_fin.DbType = DbType.String;
                paramUpdHora_fin.Value = (object)entity.Hora_fin ?? DBNull.Value;
                var paramUpdTiene_receso = _dataProvider.GetParameter();
                paramUpdTiene_receso.ParameterName = "Tiene_receso";
                paramUpdTiene_receso.DbType = DbType.Boolean;
                paramUpdTiene_receso.Value = (object)entity.Tiene_receso ?? DBNull.Value;
                var paramUpdHora_inicio_receso = _dataProvider.GetParameter();
                paramUpdHora_inicio_receso.ParameterName = "Hora_inicio_receso";
                paramUpdHora_inicio_receso.DbType = DbType.String;
                paramUpdHora_inicio_receso.Value = (object)entity.Hora_inicio_receso ?? DBNull.Value;
                var paramUpdHora_fin_receso = _dataProvider.GetParameter();
                paramUpdHora_fin_receso.ParameterName = "Hora_fin_receso";
                paramUpdHora_fin_receso.DbType = DbType.String;
                paramUpdHora_fin_receso.Value = (object)entity.Hora_fin_receso ?? DBNull.Value;
                var paramUpdDuracion_maxima_por_paciente_mins = _dataProvider.GetParameter();
                paramUpdDuracion_maxima_por_paciente_mins.ParameterName = "Duracion_maxima_por_paciente_mins";
                paramUpdDuracion_maxima_por_paciente_mins.DbType = DbType.Int32;
                paramUpdDuracion_maxima_por_paciente_mins.Value = (object)entity.Duracion_maxima_por_paciente_mins ?? DBNull.Value;

                var paramUpdCupo_limitado = _dataProvider.GetParameter();
                paramUpdCupo_limitado.ParameterName = "Cupo_limitado";
                paramUpdCupo_limitado.DbType = DbType.Boolean;
                paramUpdCupo_limitado.Value = (object)entity.Cupo_limitado ?? DBNull.Value;
                var paramUpdCupo_maximo = _dataProvider.GetParameter();
                paramUpdCupo_maximo.ParameterName = "Cupo_maximo";
                paramUpdCupo_maximo.DbType = DbType.Int32;
                paramUpdCupo_maximo.Value = (object)entity.Cupo_maximo ?? DBNull.Value;

                var paramUpdUbicacion = _dataProvider.GetParameter();
                paramUpdUbicacion.ParameterName = "Ubicacion";
                paramUpdUbicacion.DbType = DbType.Int32;
                paramUpdUbicacion.Value = (object)entity.Ubicacion ?? DBNull.Value;

                var paramUpdEstatus_de_la_Actividad = _dataProvider.GetParameter();
                paramUpdEstatus_de_la_Actividad.ParameterName = "Estatus_de_la_Actividad";
                paramUpdEstatus_de_la_Actividad.DbType = DbType.Int32;
                paramUpdEstatus_de_la_Actividad.Value = (object)entity.Estatus_de_la_Actividad ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Actividades_Evento>("sp_UpdDetalle_Actividades_Evento" , paramUpdFolio , paramUpdFolio_Eventos , paramUpdTipo_de_Actividad , paramUpdEspecialidad , paramUpdNombre_de_la_Actividad , paramUpdDescripcion , paramUpdQuien_imparte , paramUpdDia , paramUpdHora_inicio , paramUpdHora_fin , paramUpdTiene_receso , paramUpdHora_inicio_receso , paramUpdHora_fin_receso , paramUpdDuracion_maxima_por_paciente_mins , paramUpdCupo_limitado , paramUpdCupo_maximo , paramUpdUbicacion , paramUpdEstatus_de_la_Actividad ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento Detalle_Actividades_EventoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Eventos = _dataProvider.GetParameter();
                paramUpdFolio_Eventos.ParameterName = "Folio_Eventos";
                paramUpdFolio_Eventos.DbType = DbType.Int32;
                paramUpdFolio_Eventos.Value = (object)entity.Folio_Eventos ?? DBNull.Value;
		var paramUpdTipo_de_Actividad = _dataProvider.GetParameter();
                paramUpdTipo_de_Actividad.ParameterName = "Tipo_de_Actividad";
                paramUpdTipo_de_Actividad.DbType = DbType.Int32;
                paramUpdTipo_de_Actividad.Value = (object)entity.Tipo_de_Actividad ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;
                var paramUpdNombre_de_la_Actividad = _dataProvider.GetParameter();
                paramUpdNombre_de_la_Actividad.ParameterName = "Nombre_de_la_Actividad";
                paramUpdNombre_de_la_Actividad.DbType = DbType.String;
                paramUpdNombre_de_la_Actividad.Value = (object)entity.Nombre_de_la_Actividad ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
		var paramUpdQuien_imparte = _dataProvider.GetParameter();
                paramUpdQuien_imparte.ParameterName = "Quien_imparte";
                paramUpdQuien_imparte.DbType = DbType.Int32;
                paramUpdQuien_imparte.Value = (object)entity.Quien_imparte ?? DBNull.Value;
                var paramUpdDia = _dataProvider.GetParameter();
                paramUpdDia.ParameterName = "Dia";
                paramUpdDia.DbType = DbType.DateTime;
                paramUpdDia.Value = (object)entity.Dia ?? DBNull.Value;
                var paramUpdHora_inicio = _dataProvider.GetParameter();
                paramUpdHora_inicio.ParameterName = "Hora_inicio";
                paramUpdHora_inicio.DbType = DbType.String;
                paramUpdHora_inicio.Value = (object)entity.Hora_inicio ?? DBNull.Value;
                var paramUpdHora_fin = _dataProvider.GetParameter();
                paramUpdHora_fin.ParameterName = "Hora_fin";
                paramUpdHora_fin.DbType = DbType.String;
                paramUpdHora_fin.Value = (object)entity.Hora_fin ?? DBNull.Value;
                var paramUpdTiene_receso = _dataProvider.GetParameter();
                paramUpdTiene_receso.ParameterName = "Tiene_receso";
                paramUpdTiene_receso.DbType = DbType.Boolean;
                paramUpdTiene_receso.Value = (object)entity.Tiene_receso ?? DBNull.Value;
                var paramUpdHora_inicio_receso = _dataProvider.GetParameter();
                paramUpdHora_inicio_receso.ParameterName = "Hora_inicio_receso";
                paramUpdHora_inicio_receso.DbType = DbType.String;
                paramUpdHora_inicio_receso.Value = (object)entity.Hora_inicio_receso ?? DBNull.Value;
                var paramUpdHora_fin_receso = _dataProvider.GetParameter();
                paramUpdHora_fin_receso.ParameterName = "Hora_fin_receso";
                paramUpdHora_fin_receso.DbType = DbType.String;
                paramUpdHora_fin_receso.Value = (object)entity.Hora_fin_receso ?? DBNull.Value;
                var paramUpdDuracion_maxima_por_paciente_mins = _dataProvider.GetParameter();
                paramUpdDuracion_maxima_por_paciente_mins.ParameterName = "Duracion_maxima_por_paciente_mins";
                paramUpdDuracion_maxima_por_paciente_mins.DbType = DbType.Int32;
                paramUpdDuracion_maxima_por_paciente_mins.Value = (object)entity.Duracion_maxima_por_paciente_mins ?? DBNull.Value;
                var paramUpdCupo_limitado = _dataProvider.GetParameter();
                paramUpdCupo_limitado.ParameterName = "Cupo_limitado";
                paramUpdCupo_limitado.DbType = DbType.Boolean;
                paramUpdCupo_limitado.Value = (object)entity.Cupo_limitado ?? DBNull.Value;
                var paramUpdCupo_maximo = _dataProvider.GetParameter();
                paramUpdCupo_maximo.ParameterName = "Cupo_maximo";
                paramUpdCupo_maximo.DbType = DbType.Int32;
                paramUpdCupo_maximo.Value = (object)entity.Cupo_maximo ?? DBNull.Value;
		var paramUpdUbicacion = _dataProvider.GetParameter();
                paramUpdUbicacion.ParameterName = "Ubicacion";
                paramUpdUbicacion.DbType = DbType.Int32;
                paramUpdUbicacion.Value = (object)entity.Ubicacion ?? DBNull.Value;
		var paramUpdEstatus_de_la_Actividad = _dataProvider.GetParameter();
                paramUpdEstatus_de_la_Actividad.ParameterName = "Estatus_de_la_Actividad";
                paramUpdEstatus_de_la_Actividad.DbType = DbType.Int32;
                paramUpdEstatus_de_la_Actividad.Value = (object)entity.Estatus_de_la_Actividad ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Actividades_Evento>("sp_UpdDetalle_Actividades_Evento" , paramUpdFolio , paramUpdFolio_Eventos , paramUpdTipo_de_Actividad , paramUpdEspecialidad , paramUpdNombre_de_la_Actividad , paramUpdDescripcion , paramUpdQuien_imparte , paramUpdDia , paramUpdHora_inicio , paramUpdHora_fin , paramUpdTiene_receso , paramUpdHora_inicio_receso , paramUpdHora_fin_receso , paramUpdDuracion_maxima_por_paciente_mins , paramUpdCupo_limitado , paramUpdCupo_maximo , paramUpdUbicacion , paramUpdEstatus_de_la_Actividad ).FirstOrDefault();

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

