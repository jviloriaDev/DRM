using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Consulta_Actividades_Registro_Evento
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Consulta_Actividades_Registro_EventoService : IDetalle_Consulta_Actividades_Registro_EventoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> _Detalle_Consulta_Actividades_Registro_EventoRepository;
        #endregion

        #region Ctor
        public Detalle_Consulta_Actividades_Registro_EventoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> Detalle_Consulta_Actividades_Registro_EventoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Consulta_Actividades_Registro_EventoRepository = Detalle_Consulta_Actividades_Registro_EventoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Consulta_Actividades_Registro_EventoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento>("sp_SelAllDetalle_Consulta_Actividades_Registro_Evento");
        }

        public IList<Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Consulta_Actividades_Registro_Evento_Complete>("sp_SelAllComplete_Detalle_Consulta_Actividades_Registro_Evento");
            return data.Select(m => new Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento
            {
                Folio = m.Folio
                ,Folio_Registro_Evento = m.Folio_Registro_Evento
                ,Actividad_Detalle_Actividades_Evento = new Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento() { Folio = m.Actividad.GetValueOrDefault(), Nombre_de_la_Actividad = m.Actividad_Nombre_de_la_Actividad }
                ,Tipo_de_Actividad_Tipos_de_Actividades = new Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades() { Folio = m.Tipo_de_Actividad.GetValueOrDefault(), Descripcion = m.Tipo_de_Actividad_Descripcion }
                ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Especialidad.GetValueOrDefault(), Especialidad = m.Especialidad_Especialidad }
                ,Imparte_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Imparte.GetValueOrDefault(), Name = m.Imparte_Name }
                ,Fecha = m.Fecha
                ,Lugares_disponibles = m.Lugares_disponibles
                ,Horarios_disponibles = m.Horarios_disponibles
                ,Ubicacion = m.Ubicacion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Consulta_Actividades_Registro_Evento>("sp_ListSelCount_Detalle_Consulta_Actividades_Registro_Evento", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Consulta_Actividades_Registro_Evento>("sp_ListSelAll_Detalle_Consulta_Actividades_Registro_Evento", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento
                {
                    Folio = m.Detalle_Consulta_Actividades_Registro_Evento_Folio,
                    Folio_Registro_Evento = m.Detalle_Consulta_Actividades_Registro_Evento_Folio_Registro_Evento,
                    Actividad = m.Detalle_Consulta_Actividades_Registro_Evento_Actividad,
                    Tipo_de_Actividad = m.Detalle_Consulta_Actividades_Registro_Evento_Tipo_de_Actividad,
                    Especialidad = m.Detalle_Consulta_Actividades_Registro_Evento_Especialidad,
                    Imparte = m.Detalle_Consulta_Actividades_Registro_Evento_Imparte,
                    Fecha = m.Detalle_Consulta_Actividades_Registro_Evento_Fecha,
                    Lugares_disponibles = m.Detalle_Consulta_Actividades_Registro_Evento_Lugares_disponibles,
                    Horarios_disponibles = m.Detalle_Consulta_Actividades_Registro_Evento_Horarios_disponibles,
                    Ubicacion = m.Detalle_Consulta_Actividades_Registro_Evento_Ubicacion,

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

        public IList<Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Consulta_Actividades_Registro_EventoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Consulta_Actividades_Registro_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Consulta_Actividades_Registro_Evento>("sp_ListSelAll_Detalle_Consulta_Actividades_Registro_Evento", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Consulta_Actividades_Registro_EventoPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Consulta_Actividades_Registro_EventoPagingModel
                {
                    Detalle_Consulta_Actividades_Registro_Eventos =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento
                {
                    Folio = m.Detalle_Consulta_Actividades_Registro_Evento_Folio
                    ,Folio_Registro_Evento = m.Detalle_Consulta_Actividades_Registro_Evento_Folio_Registro_Evento
                    ,Actividad = m.Detalle_Consulta_Actividades_Registro_Evento_Actividad
                    ,Actividad_Detalle_Actividades_Evento = new Core.Classes.Detalle_Actividades_Evento.Detalle_Actividades_Evento() { Folio = m.Detalle_Consulta_Actividades_Registro_Evento_Actividad.GetValueOrDefault(), Nombre_de_la_Actividad = m.Detalle_Consulta_Actividades_Registro_Evento_Actividad_Nombre_de_la_Actividad }
                    ,Tipo_de_Actividad = m.Detalle_Consulta_Actividades_Registro_Evento_Tipo_de_Actividad
                    ,Tipo_de_Actividad_Tipos_de_Actividades = new Core.Classes.Tipos_de_Actividades.Tipos_de_Actividades() { Folio = m.Detalle_Consulta_Actividades_Registro_Evento_Tipo_de_Actividad.GetValueOrDefault(), Descripcion = m.Detalle_Consulta_Actividades_Registro_Evento_Tipo_de_Actividad_Descripcion }
                    ,Especialidad = m.Detalle_Consulta_Actividades_Registro_Evento_Especialidad
                    ,Especialidad_Especialidades = new Core.Classes.Especialidades.Especialidades() { Clave = m.Detalle_Consulta_Actividades_Registro_Evento_Especialidad.GetValueOrDefault(), Especialidad = m.Detalle_Consulta_Actividades_Registro_Evento_Especialidad_Especialidad }
                    ,Imparte = m.Detalle_Consulta_Actividades_Registro_Evento_Imparte
                    ,Imparte_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Detalle_Consulta_Actividades_Registro_Evento_Imparte.GetValueOrDefault(), Name = m.Detalle_Consulta_Actividades_Registro_Evento_Imparte_Name }
                    ,Fecha = m.Detalle_Consulta_Actividades_Registro_Evento_Fecha
                    ,Lugares_disponibles = m.Detalle_Consulta_Actividades_Registro_Evento_Lugares_disponibles
                    ,Horarios_disponibles = m.Detalle_Consulta_Actividades_Registro_Evento_Horarios_disponibles
                    ,Ubicacion = m.Detalle_Consulta_Actividades_Registro_Evento_Ubicacion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Consulta_Actividades_Registro_EventoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento>("sp_GetDetalle_Consulta_Actividades_Registro_Evento", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Consulta_Actividades_Registro_Evento>("sp_DelDetalle_Consulta_Actividades_Registro_Evento", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFolio_Registro_Evento = _dataProvider.GetParameter();
                padreFolio_Registro_Evento.ParameterName = "Folio_Registro_Evento";
                padreFolio_Registro_Evento.DbType = DbType.Int32;
                padreFolio_Registro_Evento.Value = (object)entity.Folio_Registro_Evento ?? DBNull.Value;
                var padreActividad = _dataProvider.GetParameter();
                padreActividad.ParameterName = "Actividad";
                padreActividad.DbType = DbType.Int32;
                padreActividad.Value = (object)entity.Actividad ?? DBNull.Value;

                var padreTipo_de_Actividad = _dataProvider.GetParameter();
                padreTipo_de_Actividad.ParameterName = "Tipo_de_Actividad";
                padreTipo_de_Actividad.DbType = DbType.Int32;
                padreTipo_de_Actividad.Value = (object)entity.Tipo_de_Actividad ?? DBNull.Value;

                var padreEspecialidad = _dataProvider.GetParameter();
                padreEspecialidad.ParameterName = "Especialidad";
                padreEspecialidad.DbType = DbType.Int32;
                padreEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var padreImparte = _dataProvider.GetParameter();
                padreImparte.ParameterName = "Imparte";
                padreImparte.DbType = DbType.Int32;
                padreImparte.Value = (object)entity.Imparte ?? DBNull.Value;

                var padreFecha = _dataProvider.GetParameter();
                padreFecha.ParameterName = "Fecha";
                padreFecha.DbType = DbType.DateTime;
                padreFecha.Value = (object)entity.Fecha ?? DBNull.Value;

                var padreLugares_disponibles = _dataProvider.GetParameter();
                padreLugares_disponibles.ParameterName = "Lugares_disponibles";
                padreLugares_disponibles.DbType = DbType.Int32;
                padreLugares_disponibles.Value = (object)entity.Lugares_disponibles ?? DBNull.Value;

                var padreHorarios_disponibles = _dataProvider.GetParameter();
                padreHorarios_disponibles.ParameterName = "Horarios_disponibles";
                padreHorarios_disponibles.DbType = DbType.String;
                padreHorarios_disponibles.Value = (object)entity.Horarios_disponibles ?? DBNull.Value;
                var padreUbicacion = _dataProvider.GetParameter();
                padreUbicacion.ParameterName = "Ubicacion";
                padreUbicacion.DbType = DbType.String;
                padreUbicacion.Value = (object)entity.Ubicacion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Consulta_Actividades_Registro_Evento>("sp_InsDetalle_Consulta_Actividades_Registro_Evento" , padreFolio_Registro_Evento
, padreActividad
, padreTipo_de_Actividad
, padreEspecialidad
, padreImparte
, padreFecha
, padreLugares_disponibles
, padreHorarios_disponibles
, padreUbicacion
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

        public int Update(Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Registro_Evento = _dataProvider.GetParameter();
                paramUpdFolio_Registro_Evento.ParameterName = "Folio_Registro_Evento";
                paramUpdFolio_Registro_Evento.DbType = DbType.Int32;
                paramUpdFolio_Registro_Evento.Value = (object)entity.Folio_Registro_Evento ?? DBNull.Value;
                var paramUpdActividad = _dataProvider.GetParameter();
                paramUpdActividad.ParameterName = "Actividad";
                paramUpdActividad.DbType = DbType.Int32;
                paramUpdActividad.Value = (object)entity.Actividad ?? DBNull.Value;

                var paramUpdTipo_de_Actividad = _dataProvider.GetParameter();
                paramUpdTipo_de_Actividad.ParameterName = "Tipo_de_Actividad";
                paramUpdTipo_de_Actividad.DbType = DbType.Int32;
                paramUpdTipo_de_Actividad.Value = (object)entity.Tipo_de_Actividad ?? DBNull.Value;

                var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;

                var paramUpdImparte = _dataProvider.GetParameter();
                paramUpdImparte.ParameterName = "Imparte";
                paramUpdImparte.DbType = DbType.Int32;
                paramUpdImparte.Value = (object)entity.Imparte ?? DBNull.Value;

                var paramUpdFecha = _dataProvider.GetParameter();
                paramUpdFecha.ParameterName = "Fecha";
                paramUpdFecha.DbType = DbType.DateTime;
                paramUpdFecha.Value = (object)entity.Fecha ?? DBNull.Value;

                var paramUpdLugares_disponibles = _dataProvider.GetParameter();
                paramUpdLugares_disponibles.ParameterName = "Lugares_disponibles";
                paramUpdLugares_disponibles.DbType = DbType.Int32;
                paramUpdLugares_disponibles.Value = (object)entity.Lugares_disponibles ?? DBNull.Value;

                var paramUpdHorarios_disponibles = _dataProvider.GetParameter();
                paramUpdHorarios_disponibles.ParameterName = "Horarios_disponibles";
                paramUpdHorarios_disponibles.DbType = DbType.String;
                paramUpdHorarios_disponibles.Value = (object)entity.Horarios_disponibles ?? DBNull.Value;
                var paramUpdUbicacion = _dataProvider.GetParameter();
                paramUpdUbicacion.ParameterName = "Ubicacion";
                paramUpdUbicacion.DbType = DbType.String;
                paramUpdUbicacion.Value = (object)entity.Ubicacion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Consulta_Actividades_Registro_Evento>("sp_UpdDetalle_Consulta_Actividades_Registro_Evento" , paramUpdFolio , paramUpdFolio_Registro_Evento , paramUpdActividad , paramUpdTipo_de_Actividad , paramUpdEspecialidad , paramUpdImparte , paramUpdFecha , paramUpdLugares_disponibles , paramUpdHorarios_disponibles , paramUpdUbicacion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento Detalle_Consulta_Actividades_Registro_EventoDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFolio_Registro_Evento = _dataProvider.GetParameter();
                paramUpdFolio_Registro_Evento.ParameterName = "Folio_Registro_Evento";
                paramUpdFolio_Registro_Evento.DbType = DbType.Int32;
                paramUpdFolio_Registro_Evento.Value = (object)entity.Folio_Registro_Evento ?? DBNull.Value;
		var paramUpdActividad = _dataProvider.GetParameter();
                paramUpdActividad.ParameterName = "Actividad";
                paramUpdActividad.DbType = DbType.Int32;
                paramUpdActividad.Value = (object)entity.Actividad ?? DBNull.Value;
		var paramUpdTipo_de_Actividad = _dataProvider.GetParameter();
                paramUpdTipo_de_Actividad.ParameterName = "Tipo_de_Actividad";
                paramUpdTipo_de_Actividad.DbType = DbType.Int32;
                paramUpdTipo_de_Actividad.Value = (object)entity.Tipo_de_Actividad ?? DBNull.Value;
		var paramUpdEspecialidad = _dataProvider.GetParameter();
                paramUpdEspecialidad.ParameterName = "Especialidad";
                paramUpdEspecialidad.DbType = DbType.Int32;
                paramUpdEspecialidad.Value = (object)entity.Especialidad ?? DBNull.Value;
		var paramUpdImparte = _dataProvider.GetParameter();
                paramUpdImparte.ParameterName = "Imparte";
                paramUpdImparte.DbType = DbType.Int32;
                paramUpdImparte.Value = (object)entity.Imparte ?? DBNull.Value;
                var paramUpdFecha = _dataProvider.GetParameter();
                paramUpdFecha.ParameterName = "Fecha";
                paramUpdFecha.DbType = DbType.DateTime;
                paramUpdFecha.Value = (object)entity.Fecha ?? DBNull.Value;
                var paramUpdLugares_disponibles = _dataProvider.GetParameter();
                paramUpdLugares_disponibles.ParameterName = "Lugares_disponibles";
                paramUpdLugares_disponibles.DbType = DbType.Int32;
                paramUpdLugares_disponibles.Value = (object)entity.Lugares_disponibles ?? DBNull.Value;
                var paramUpdHorarios_disponibles = _dataProvider.GetParameter();
                paramUpdHorarios_disponibles.ParameterName = "Horarios_disponibles";
                paramUpdHorarios_disponibles.DbType = DbType.String;
                paramUpdHorarios_disponibles.Value = (object)entity.Horarios_disponibles ?? DBNull.Value;
                var paramUpdUbicacion = _dataProvider.GetParameter();
                paramUpdUbicacion.ParameterName = "Ubicacion";
                paramUpdUbicacion.DbType = DbType.String;
                paramUpdUbicacion.Value = (object)entity.Ubicacion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Consulta_Actividades_Registro_Evento>("sp_UpdDetalle_Consulta_Actividades_Registro_Evento" , paramUpdFolio , paramUpdFolio_Registro_Evento , paramUpdActividad , paramUpdTipo_de_Actividad , paramUpdEspecialidad , paramUpdImparte , paramUpdFecha , paramUpdLugares_disponibles , paramUpdHorarios_disponibles , paramUpdUbicacion ).FirstOrDefault();

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

